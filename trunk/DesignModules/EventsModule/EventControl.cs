using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Inspire;
using Inspire.Commands;
using Inspire.Interfaces;
using Inspire.Services.WeakEventHandlers;
using Inspire.Events.Proxy;
using System.Windows.Documents;
using System.Threading;
using Timer = System.Timers.Timer;

namespace EventsModule
{
    public class EventControl : StackPanel, IWeakEventListener, IResizable, IDisposable, IEventControl, IPlayable, IFilterable
    {
        private int _secondsPerPage;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int SecondsPerPage { get { return _secondsPerPage;} set { _secondsPerPage = ValidateSecondsPerPage(value); }}

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string DataSourceGuid { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TimeSpan ShowEventsAhead { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TimeSpan ShowEventssBehind { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool ShowAllTodaysEvents { get; set; }

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //public bool SkipSlideIfNoEvents { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TextBlock HeaderRow { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ListBox EventColumns { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool ShowEventsForAllDisplays { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool AdvanceOnEnd { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int AdvanceAfterLoops { get; set; }

        private List<HospitalityEvent> _eventData;

        private int _totalEvents;
        private int _eventsShown;
        private int _firstPageEventTotal;
        private bool _forceRefresh;
        private int _numberOfCycles = 0;

        private delegate void PopulateControlsDelegate(List<HospitalityEvent> hospitalityEvents);

        private delegate void NoEventDelegate();

        private double _loadedHeight;

        private bool _isPlaying;
        private bool _hasLoadedOnce;
        private bool _isLoaded;
        private bool _isFirstPage;
        private bool _getEventsAgain;
        private BackgroundWorker _backgroundWorker;

        private DispatcherTimer _dispatcherTimer;
        private DispatcherTimer _triggerDispatcherTimer;
        private readonly Timer _refreshEventsTimer;

        public EventControl()
        {
            if(InspireApp.IsPlayer)
                _eventData = EventLoader.GetEvents(false);
            else
                HospitalityEventManager.GetEventsFromHostName(DataSourceGuid, InspireApp.PlaybackHostName, false);

            Margin = new Thickness(10);

            CommandBindings.Add(new CommandBinding(InspireCommands.FilterListCommand, OnFilterExecuted, OnFilterCanExecute));

            _refreshEventsTimer = new Timer(60000);
            _refreshEventsTimer.Elapsed += _refreshEventsTimer_Elapsed;
            _refreshEventsTimer.Start();

            LoadedEventManager.AddListener(this, this);

            if(HeaderRow == null)
                HeaderRow = new TextBlock();

            _triggerDispatcherTimer = new DispatcherTimer();
            _dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);

            RefreshEventsWeakEventHandler.AddListener(_triggerDispatcherTimer, this);
            StartEventsWeakEventHandler.AddListener(_dispatcherTimer, this);

            _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += backgroundWorker_DoWork;
            
            _backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;

            Children.Add(new LoadingControl() {Height = 100, VerticalContentAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = System.Windows.VerticalAlignment.Center});

            //var eventData = HospitalityEventManager.GetEventsFromHostName(DataSourceGuid, InspireApp.PlaybackHostName, ShowEventsForAllDisplays);

            //if (eventData.Count < 1)
            //    InspireApp.PlayNextSlide = false;
        }

        private void OnFilterCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OnFilterExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            _eventsShown = 0;
            _isFirstPage = true;
            _hasLoadedOnce = false;

            Play();

            RefreshEventData();

            var filterList = (KeyValuePair<string, IEnumerable<object>>) e.Parameter;
            FilterList(filterList.Key, filterList.Value, _eventData);
            
        }

        private void FilterList(object filterVar, IEnumerable<object> filterCollection, List<HospitalityEvent> collectionToFilter)
        {
            var results = GetRemainingCollection(filterVar, (IEnumerable<string>)filterCollection, collectionToFilter);

            _forceRefresh = true;

            UpdateEventData(HeaderRow, (List<HospitalityEvent>) results);

            _getEventsAgain = true;

            //Resized();
            _isFirstPage = true;

            _forceRefresh = true;

            _totalEvents = _eventData.Count;

            //if (FilteredItemList.ItemsSource == null)
            //    FilteredItemList.Items.Clear();

            //FilteredItemList.ItemsSource = results;
        }

        public static IEnumerable GetRemainingCollection(object filterVar, IEnumerable<string> filterCollection, List<HospitalityEvent> collectionToFilter)
        {
            var startIndex = 0;

            if (filterVar != null)
                startIndex = collectionToFilter.ToList().Select(s => s.GroupName[0].ToString().ToLower()).ToList().IndexOf(filterVar.ToString().ToLower());

            if (startIndex == -1)
                return GetRemainingCollection(CollectionHelpers.GetNext(filterVar, filterCollection), filterCollection, collectionToFilter);

            var endIndex = collectionToFilter.Count() - startIndex;

            return collectionToFilter.ToList().GetRange(startIndex, endIndex).ToList();
        }

        void _refreshEventsTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _getEventsAgain = true;
            _refreshEventsTimer.Interval = 60000;
            _refreshEventsTimer.Start();
        }

        public EventControl(string datasourceGuid, ListBox columnTextBlocks, TextBlock headerTextBlock, int secondsPerPage, TimeSpan showAheadTime, TimeSpan showBehindTime, bool showAllEventsToday, bool showEventsForAllDisplays): this()
        {
            DataSourceGuid = datasourceGuid;

            Tag = columnTextBlocks.Tag;

            EventColumns = columnTextBlocks;

            _secondsPerPage = secondsPerPage;

            ShowEventsAhead = showAheadTime;

            ShowEventssBehind = showBehindTime;

            ShowAllTodaysEvents = showAllEventsToday;

            ShowEventsForAllDisplays = showEventsForAllDisplays;

            HeaderRow.Foreground = headerTextBlock.Foreground;
            HeaderRow.FontSize = headerTextBlock.FontSize;
            HeaderRow.FontWeight = headerTextBlock.FontWeight;
            HeaderRow.Tag = headerTextBlock.Tag;
            HeaderRow.FontStyle = headerTextBlock.FontStyle;
            HeaderRow.FontFamily = headerTextBlock.FontFamily;
            HeaderRow.TextDecorations = headerTextBlock.TextDecorations;

            HeaderRow.Text = headerTextBlock.Text;

        }

        public EventControl(EventControl control): this()
        {
            DataSourceGuid = control.DataSourceGuid;

            EventColumns = control.EventColumns;

            _secondsPerPage = control.SecondsPerPage;

            ShowEventsAhead = control.ShowEventsAhead;

            ShowEventssBehind = control.ShowEventssBehind;

            ShowAllTodaysEvents = control.ShowAllTodaysEvents;

            ShowEventsForAllDisplays = control.ShowEventsForAllDisplays;

            HeaderRow.Foreground = control.HeaderRow.Foreground;
            HeaderRow.FontSize = control.HeaderRow.FontSize;
            HeaderRow.FontWeight = control.HeaderRow.FontWeight;
            HeaderRow.FontStyle = control.HeaderRow.FontStyle;
            HeaderRow.FontFamily = control.HeaderRow.FontFamily;
            HeaderRow.TextDecorations = control.HeaderRow.TextDecorations;
            HeaderRow.Tag = control.HeaderRow.Tag;
            HeaderRow.Text = control.HeaderRow.Text;

        }

        ~EventControl()
        {
            if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
            {
                Dispose();
            }
            //MessageBox.Show("RSS Gone");
        }

        public void Dispose()
        {
            EventColumns = null;
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => Children.Clear()));//Children.Clear();
            HeaderRow = null;
            if (_triggerDispatcherTimer != null)
            {
                _triggerDispatcherTimer.Stop();
                _triggerDispatcherTimer = null;
            }

            if (_dispatcherTimer != null)
            {
                _dispatcherTimer.Stop();
                _dispatcherTimer = null;
            }

            if (_backgroundWorker != null)
            {
                try
                {
                    _backgroundWorker.DoWork -= backgroundWorker_DoWork;

                    _backgroundWorker.RunWorkerCompleted -= backgroundWorker_RunWorkerCompleted;
                    _backgroundWorker = null;

                }
                catch{}
            }
        }

        void EventControlLoaded(object sender, EventArgs e) 
        {
            if (!_isLoaded)
            {
                var args = new object[5];
                args[0] = ShowEventsAhead;
                args[1] = ShowEventssBehind;
                args[2] = DataSourceGuid;
                args[3] = ShowEventsForAllDisplays;
                args[4] = HeaderRow.Text;

                if (!_backgroundWorker.IsBusy)
                    _backgroundWorker.RunWorkerAsync(args);
                _isLoaded = true;
            }
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var results = e.Result as object[];
            if (results != null)
            {
                if (results.Count() > 1)
                {
                    var filtEventData = results[1] as List<HospitalityEvent>;
                    if (filtEventData != null)
                        Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                               new Action(() => UpdateEventData(HeaderRow, filtEventData)));
                }
            }
        }

        private void RefreshEventData()
        {
            List<HospitalityEvent> eventData = null;
            
            if(InspireApp.IsPlayer)
                eventData = EventLoader.GetEvents(!ShowEventsForAllDisplays);
            else if (string.IsNullOrEmpty(InspireApp.PlaybackHostName))
                eventData = SampleEventManager.GetEvents();
            else
                eventData = HospitalityEventManager.GetEventsFromHostName(DataSourceGuid, InspireApp.PlaybackHostName, !ShowEventsForAllDisplays);

            var currentTime = DateTime.Now;

            string sortByField = String.IsNullOrEmpty(HeaderRow.Text) ? "GroupName" : HeaderRow.Text;

            TimeSpan showEventsAhead = ShowEventsAhead;
            TimeSpan showEventssBehind = ShowEventssBehind;

            var tomorrowMidnight = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0) + new TimeSpan(1, 0, 0, 0);

            if (ShowEventsForAllDisplays)
                showEventsAhead = tomorrowMidnight - currentTime;

            if (String.IsNullOrEmpty(InspireApp.PlaybackHostName))
            {
                showEventsAhead = new TimeSpan(24, 0, 0);
                showEventssBehind = new TimeSpan(24, 0, 0);
            }

            if(eventData != null)
                _eventData = GetFilteredEventData(currentTime, eventData, sortByField, showEventsAhead, showEventssBehind);

            //if (filtEventData != null)
            //    Dispatcher.Invoke(DispatcherPriority.Normal,
            //                           new Action(() => UpdateEventData(HeaderRow, filtEventData)));

        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _isFirstPage = true;
            _firstPageEventTotal = 0;

            Thread.Sleep(2000); // wait for a second so the aniimations don't double play.

            var args = e.Argument as object[];

            if (args != null)
            {
                TimeSpan showEventsAhead = args[0] is TimeSpan ? (TimeSpan) args[0] : new TimeSpan();
                TimeSpan showEventssBehind = args[1] is TimeSpan ? (TimeSpan) args[1] : new TimeSpan();

                var showEvntsForAllDisplays = (bool)args[3];
                string hdrRow = args[4].ToString();

                DateTime currentTime = DateTime.Now;

                var tomorrowMidnight = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0) + new TimeSpan(1, 0, 0, 0);

                if (ShowAllTodaysEvents)
                    showEventsAhead = tomorrowMidnight - currentTime;

                List<HospitalityEvent> eventData;
                if (String.IsNullOrEmpty(InspireApp.PlaybackHostName))
                {
                    eventData = SampleEventManager.GetEvents();
                    showEventsAhead = new TimeSpan(24, 0, 0);
                    showEventssBehind = new TimeSpan(24, 0, 0);
                }
                else
                {
                    if(InspireApp.IsPlayer)
                        eventData = EventLoader.GetEvents(!showEvntsForAllDisplays);
                    else
                        eventData = HospitalityEventManager.GetEventsFromHostName(DataSourceGuid, InspireApp.PlaybackHostName, !showEvntsForAllDisplays);                    
                    //eventData = HospitalityEventManager.GetEventsFromHostName(dsGuid, InspireApp.PlaybackHostName, !showEvntsForAllDisplays);
                    //if (SkipSlideIfNoEvents)
                    //{
                    //if (eventData.Count < 1)
                    //    InspireApp.PlayNextSlide = false;
                    //}
                }

                string sortByField = String.IsNullOrEmpty(hdrRow) ? "GroupName" : hdrRow;

                List<HospitalityEvent> filteredEventData = GetFilteredEventData(currentTime, eventData, sortByField, showEventsAhead, showEventssBehind);

                var results = new object[2];
                results[0] = hdrRow;
                results[1] = filteredEventData;

                e.Result = results;

            }

        }

        private static List<HospitalityEvent> GetFilteredEventData(DateTime currentTime, IEnumerable<HospitalityEvent> eventData, string sortByField, TimeSpan showEventsAhead, TimeSpan showEventssBehind)
        {
            List<HospitalityEvent> filteredEventData = null;
            if (eventData != null)
            {
                switch (sortByField)
                {
                    case ("GroupName"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.GroupName).ToList();//
                                
                        //filteredEventData = eventData.OrderBy(mediamodule => mediamodule.GroupName).ToList();
                        break;
                    case ("HotelName"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.HotelName).ToList();
                        break;
                        //case ("Date"):
                        //    filteredEventData = eventData.OrderBy(mediamodule => mediamodule.Date).ToList();
                        //    break;
                        //case ("EndDate"):
                        //    filteredEventData = eventData.OrderBy(mediamodule => mediamodule.EndDate).ToList();
                        //    break;
                    case ("EndTime"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.EndTime).ToList();
                        break;
                    case ("Exhibit"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.Exhibit).ToList();
                        break;
                    case ("GroupLogo"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.GroupLogo).ToList();
                        break;
                    case ("BackupMeetingRoomSpace"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.BackupMeetingRoomSpace).ToList();
                        break;
                    case ("HostEventIdentifier"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.HostEventIdentifier).ToList();
                        break;
                    case ("MeetingID"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.MeetingID).ToList();
                        break;
                    case ("MeetingLogo"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.MeetingLogo).ToList();
                        break;
                    case ("MeetingName"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.MeetingName).ToList();
                        break;
                    case ("MeetingPostAs"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.MeetingPostAs).ToList();
                        break;
                    case ("MeetingRoomID"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.MeetingRoomID).ToList();
                        break;
                    case ("MeetingRoomLogo"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.MeetingRoomLogo).ToList();
                        break;
                    case ("MeetingRoomName"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.MeetingRoomName).ToList();
                        break;
                    case ("MeetingType"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.MeetingType).ToList();
                        break;
                    case ("OverflowMeetingRoomSpace"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.OverflowMeetingRoomSpace).ToList();
                        break;
                    case ("Postable"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.Postable).ToList();
                        break;
                        //case ("StartDate"):
                        //    filteredEventData = eventData.OrderBy(mediamodule => mediamodule.StartDate).ToList();
                        //    break;
                    case ("StartTime"):
                        filteredEventData =
                            eventData.Where(
                                mediamodule =>
                                mediamodule.StartTime < currentTime + showEventsAhead &&
                                mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).OrderBy(
                                mediamodule => mediamodule.StartTime).ToList();
                        break;
                }
            }
            return filteredEventData;
        }

        private void UpdateEventData(TextBlock headerRow, List<HospitalityEvent> events)
        {
            if(Children.Count > 0)
                if(Children[0] is LoadingControl)
                    ((LoadingControl)Children[0]).Dispose();

            Children.Clear();
            if (events != null)
                if (events.Count == 0)
                {
                    var textBlock = new TextBlock(new Run(""));
                    textBlock.FontSize = headerRow.FontSize;
                    textBlock.Foreground = headerRow.Foreground;
                    Children.Add(textBlock);
                }
                else
                {
                    _eventData = events;

                    _totalEvents = events.Count;

                    SetHeaderFormat();

                    PopulateControl(events);

                    if ((InspireApp.IsPlayer || InspireApp.IsPreviewMode) && !_isPlaying)
                        Play();
                }
            _isFirstPage = false;
        }

        private static int ValidateSecondsPerPage(int value)
        {
            return value > 3 ? value : 3;
        }

        public List<HospitalityEvent> GetEventData()
        {
            _totalEvents = _eventData.Count;
            return _eventData;
        }

        public void Play()
        {
            _dispatcherTimer.Interval = new TimeSpan(0,0,0, SecondsPerPage);
            _dispatcherTimer.Start();
            _isPlaying = true;
        }

        public void Stop()
        {
            _dispatcherTimer.Stop();
            _isPlaying = false;
        }

        public bool IsPlaying()
        {
            return _isPlaying;
        }

        public void TriggerScreenRefresh()
        {
            _triggerDispatcherTimer.Interval = new TimeSpan(0,0,1);
            _triggerDispatcherTimer.Start();
        }

        void TriggerDispatcherTimerTick(object sender, EventArgs e)
        {
            Resized();
            _triggerDispatcherTimer.Stop();
        }

        void DispatcherTimerTick(object sender, EventArgs e)
        {
            if(!IsVisible)
            {
                _dispatcherTimer.Stop();
                _triggerDispatcherTimer.Stop();
                _refreshEventsTimer.Stop();
                Dispose();
                return;
            }

            int remainingEvents = _totalEvents - _eventsShown;

            if (remainingEvents < 1 || (_totalEvents.Equals(_firstPageEventTotal)))
            {
                _eventsShown = 0;
                remainingEvents = _totalEvents;

                _numberOfCycles++;

                if(_getEventsAgain)
                {
                    _forceRefresh = true;
                    RefreshEventData();
                    _getEventsAgain = false;
                }
            }
            
            

            if (AdvanceOnEnd && AdvanceAfterLoops <= _numberOfCycles)
            {
                UIElement currentCanvas = null;
                if (InspireApp.IsPreviewMode)
                    currentCanvas = InspireApp.CurrentPreviewCanvas;
                else if (InspireApp.IsPlayer)
                    currentCanvas = InspireApp.CurrentPlayerCanvas;

                InspireCommands.PlayNextSlideCommand.Execute(this, currentCanvas);
            }

            _hasLoadedOnce = false;

            List<HospitalityEvent> eventData = GetEventData();

            if (eventData != null)
                if (eventData.Count >= _eventsShown + remainingEvents)
                {
                    remainingEvents = _totalEvents - _eventsShown;
                    eventData = eventData.GetRange(_eventsShown, remainingEvents);
                }

            PopulateControlsDelegate populateControlsDelegate = PopulateControl;

            Dispatcher.BeginInvoke(populateControlsDelegate, eventData);
        }

        public void UpdateAppearance()
        {
            PopulateControl(_eventData);
        }

        private void PopulateControl(List<HospitalityEvent> sortedEvents)
        {
            if (_totalEvents > _firstPageEventTotal || _forceRefresh)
            {
                Children.Clear(); // TODO: Check if the resources are being released

                if (sortedEvents != null)
                {
                    var orderGroups =
                        sortedEvents.GroupBy(p => p.GroupName).Select(g => new {GroupName = g.Key, HospitalityEvent = g});

                    foreach (var orderGroup in orderGroups)
                    {
                        var groupControl = new GroupControl(orderGroup.HospitalityEvent, EventColumns, HeaderRow);

                        Children.Add(groupControl);
                    }
                }

                NoEventDelegate noEventDelegate = TriggerScreenRefresh;

                noEventDelegate.BeginInvoke(null, null);
                
                _forceRefresh = false;
            }
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            Resized();
            base.OnRenderSizeChanged(sizeInfo);
        }

        private void Resized()
        {
            if (Parent == null)
            {
                Dispose();
                return;
            }

            _loadedHeight = ((ContentControl) Parent).ActualHeight;

            if (!_isPlaying && !_hasLoadedOnce)
                _eventsShown = 0;

            if (Children.Count > 0)
            {
                if (Children[0].GetType() != typeof (LoadingControl))
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                        new Action(() => FormatGroupControls(_loadedHeight)));
                }
            }
        }

        public void RePopulateBasedOnSize(SizeChangedInfo sizeChangedInfo)
        {
            Resized();
        }

        private void FormatGroupControls(double viewableSize)
        {
                bool collapseRest = false;

                int eventsCurrentLoop = 0;

                double usedRoom = 0;
                
                if(Children[0] != null && Children[0] is GroupControl)
                foreach (GroupControl groupControl in Children)
                {
                    if (groupControl.Visibility == Visibility.Collapsed && !collapseRest)
                        groupControl.Visibility = Visibility.Visible;

                    if (viewableSize > groupControl.ActualHeight + usedRoom && !collapseRest)
                    {
                        groupControl.Visibility = Visibility.Visible;
                        double availableRoom = viewableSize - usedRoom;
                        eventsCurrentLoop += FormatEventRows(availableRoom, groupControl);
                    }
                    else
                    {
                        if (viewableSize > ((StackPanel)((StackPanel)groupControl.Content).Children[0]).ActualHeight + usedRoom && !collapseRest)
                        {
                            groupControl.Visibility = Visibility.Visible;
                            double availableRoom = viewableSize - usedRoom;
                            eventsCurrentLoop += FormatEventRows(availableRoom, groupControl);
                            collapseRest = true;
                        }
                        else
                        {
                            groupControl.Visibility = Visibility.Collapsed;
                            collapseRest = true;
                        }
                    }
                    usedRoom += groupControl.ActualHeight;
                }
                if (!_hasLoadedOnce)
                {
                    _firstPageEventTotal = eventsCurrentLoop;
                    _eventsShown += eventsCurrentLoop;
                    _hasLoadedOnce = true;
                }
        }

        private static int FormatEventRows(double rowRoomToWorkWith, GroupControl groupControl)
        {
            bool collapseRest = false;

            int eventsInGroup = 0;

            double usedRoom = 0;

            rowRoomToWorkWith = rowRoomToWorkWith - (((StackPanel)((StackPanel)groupControl.Content).Children[0]).ActualHeight + 50);

            foreach (EventRow eventRow in ((StackPanel)((StackPanel)groupControl.Content).Children[1]).Children)
            {
                if (eventRow.Visibility == Visibility.Collapsed && !collapseRest)
                    eventRow.Visibility = Visibility.Visible;

                if (rowRoomToWorkWith > eventRow.ActualHeight + usedRoom && !collapseRest)
                {
                    eventRow.Visibility = Visibility.Visible;
                    eventsInGroup++;
                }
                else
                {
                    eventRow.Visibility = Visibility.Collapsed;
                    collapseRest = true;
                }
                usedRoom += eventRow.ActualHeight;
            }
            if (((EventRow)((StackPanel)((StackPanel)groupControl.Content).Children[1]).Children[0]).ActualHeight == 0)
                groupControl.Visibility = Visibility.Collapsed;

            return eventsInGroup;
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                EventControlLoaded(sender, e);
                return true;
            }
            if (managerType == typeof(RefreshEventsWeakEventHandler))
            {
                TriggerDispatcherTimerTick(sender, e);
                return true;
            }
            if (managerType == typeof(StartEventsWeakEventHandler))
            {
                DispatcherTimerTick(sender, e);
                return true;
            }
            return false;
        }

        public void SetHeaderFormat()
        {
            foreach (EventTextBlock textBlock in EventColumns.Items)
            {
                if (textBlock.IsHeader)
                {
                    HeaderRow.Foreground = textBlock.Foreground;
                    HeaderRow.FontSize = textBlock.FontSize;
                    HeaderRow.FontWeight = textBlock.FontWeight;
                    HeaderRow.FontFamily = textBlock.FontFamily;
                    HeaderRow.FontStyle = textBlock.FontStyle;
                    HeaderRow.TextAlignment = textBlock.TextAlignment;
                    HeaderRow.TextWrapping = textBlock.TextWrapping;
                    HeaderRow.Tag = textBlock.Tag;
                }
            }
        }

        //#region ICloneable Members

        //public object Clone()
        //{
        //    return MemberwiseClone();
        //}

        //#endregion
    }
}
