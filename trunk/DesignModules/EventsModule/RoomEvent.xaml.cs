using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Inspire;
using Inspire.AnimationLibrary;
using Inspire.Commands;
using Inspire.Events.Proxy;
using Inspire.Interfaces;
using Inspire.Services.WeakEventHandlers;

namespace EventsModule
{
    /// <summary>
    /// Interaction logic for RoomEvent.xaml
    /// </summary>
    public partial class RoomEvent : IEventControl, IPlayable, IDisposable, IWeakEventListener
    {
        private List<HospitalityEvent> _eventData;
        private TextBlock roomName;
        private TextBlock groupName;
        private TextBlock description;
        private TextBlock startTime;
        private TextBlock endTime;
        private TextBlock spacer;
        private Image logo;
        private bool loadedOnce;
        private BackgroundWorker backgroundWorker;
        private BackgroundWorker eventWorker;
        private DispatcherTimer _dispatcherTimer;
        private bool noEventMessage;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ListBox EventColumns { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TextBlock HeaderRow { get; set;}

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int SecondsPerPage { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int EventToShow { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string DataSourceGuid { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TimeSpan ShowEventsAhead { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TimeSpan ShowEventssBehind { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool ShowAllTodaysEvents { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool ShowIfNoEvents { get; set; }

        public RoomEvent()
        {
            // Start the get events so the control timer and call start on our static event class and hopefully the call will fill the events before it is loaded again below
            if(InspireApp.IsPlayer)
                _eventData = EventLoader.GetEvents(true);

            InitializeComponent();

            ShowEventsAhead = EventLoader.GetShowAheadTime();
            ShowEventssBehind = EventLoader.GetShowBehindTime();

            try
            {

                if (String.IsNullOrEmpty(InspireApp.PlaybackHostName))
                    _eventData = SampleEventManager.GetEvents();
                else
                {
                    GetEvents();
                }

                if (_eventData == null || _eventData.Count < 1 && !ShowIfNoEvents)
                {
                    InspireApp.PlayNextSlide = false;
                    InspireApp.AddSkipSlide(InspireApp.CurrentSlideGuid);

                    noEventMessage = true;
                    LoadedEventManager.AddListener(this, this);
                }
                else
                {
                    InspireApp.AddDontSkipSlide(InspireApp.CurrentSlideGuid);
                    LoadedEventManager.AddListener(this, this);
                }
            }
            catch (Exception)
            {
                InspireApp.PlayNextSlide = false;
            }
        }

        public RoomEvent(bool designerLoad)
        {
            InitializeComponent();

            ShowEventsAhead = EventLoader.GetShowAheadTime();
            ShowEventssBehind = EventLoader.GetShowBehindTime();

            if (designerLoad)
            {
                EventColumns = new ListBox();

                FillTextBlocks();

                EventTextBlock roomTB = new EventTextBlock("MeetingRoomName", roomName);
                EventTextBlock groupTB = new EventTextBlock("GroupName", groupName);
                EventTextBlock meetingTB = new EventTextBlock("MeetingName", description);
                EventTextBlock startTB = new EventTextBlock("StartTime", startTime);
                EventTextBlock endTB = new EventTextBlock("EndTime", endTime);
                EventTextBlock imageTB = new EventTextBlock("GroupLogo");
                imageTB.Width = 20;
                EventColumns.Items.Add(roomTB);
                EventColumns.Items.Add(groupTB);
                EventColumns.Items.Add(meetingTB);
                EventColumns.Items.Add(startTB);
                EventColumns.Items.Add(endTB);
                EventColumns.Items.Add(imageTB);
            }
        }

        public RoomEvent(ListBox eventColumns, TimeSpan eventsAhead, TimeSpan eventsBehind, int eventToShow, bool showAllDayEvents, bool showifNoEvents)
        {
            InitializeComponent();

            ShowEventsAhead = EventLoader.GetShowAheadTime();
            ShowEventssBehind = EventLoader.GetShowBehindTime();

            ShowIfNoEvents = showifNoEvents;

            ShowAllTodaysEvents = showAllDayEvents;

            EventToShow = eventToShow;

            EventColumns = eventColumns;

            UpdateAppearance();
        }

        public RoomEvent(RoomEvent roomEvent)
        {
            InitializeComponent();

            ShowEventsAhead = EventLoader.GetShowAheadTime();

            ShowEventssBehind = EventLoader.GetShowBehindTime();

            ShowIfNoEvents = roomEvent.ShowIfNoEvents;

            EventToShow = roomEvent.EventToShow;

            EventColumns = roomEvent.EventColumns;

            UpdateAppearance();
        }

        public void UpdateAppearance()
        {
            if(groupName == null)
                FillTextBlocks();

            HospitalityEvent hospitalityEvent = GetEventToDisplay(ShowEventsAhead, ShowEventssBehind);

            if (EventColumns.Items.Count > 0 && hospitalityEvent != null)
                foreach (EventTextBlock eventTextBlock in EventColumns.Items)
                {
                    switch (eventTextBlock.Text)
                    {
                        case ("MeetingRoomName"):
                            {
                                CopyTBProperties(eventTextBlock, roomName, hospitalityEvent.MeetingRoomName);
                                if (eventTextBlock.Tag != null)
                                    AnimationManager.ApplyAnimation(roomName, eventTextBlock.Tag.ToString(), InspireApp.GetCanvasSize());
                                break;
                            }
                        case ("GroupName"):
                            {
                                CopyTBProperties(eventTextBlock, groupName, hospitalityEvent.GroupName);
                                if (eventTextBlock.Tag != null)
                                    AnimationManager.ApplyAnimation(groupName, eventTextBlock.Tag.ToString(), InspireApp.GetCanvasSize());
                                break;
                            }
                        case ("MeetingName"):
                            {
                                CopyTBProperties(eventTextBlock, description, hospitalityEvent.MeetingName);
                                if (eventTextBlock.Tag != null)
                                    AnimationManager.ApplyAnimation(description, eventTextBlock.Tag.ToString(), InspireApp.GetCanvasSize());
                                break;
                            }
                        case ("StartTime"):
                            {
                                if (hospitalityEvent.StartTime != null)
                                {
                                    CopyTBProperties(eventTextBlock, startTime,
                                                     (string.Format("{0} {1}",
                                                                    hospitalityEvent.StartTime.Value.ToString("h:mm"),
                                                                    hospitalityEvent.StartTime.Value.ToString("tt").
                                                                        ToLower())));
                                    spacer.Foreground = startTime.Foreground;
                                    if (startTime.Visibility == Visibility.Collapsed || endTime.Visibility == Visibility.Collapsed)
                                        spacer.Visibility = Visibility.Collapsed;
                                    else
                                        spacer.Visibility = Visibility.Visible;
                                }
                                if (eventTextBlock.Tag != null)
                                    AnimationManager.ApplyAnimation(startTime, eventTextBlock.Tag.ToString(), InspireApp.GetCanvasSize());
                                break;
                            }
                        case ("EndTime"):
                            {
                                if (hospitalityEvent.EndTime != null)
                                    CopyTBProperties(eventTextBlock, endTime, (string.Format("{0} {1}", hospitalityEvent.EndTime.Value.ToString("h:mm"), hospitalityEvent.EndTime.Value.ToString("tt").ToLower())));

                                if (startTime.Visibility == Visibility.Collapsed || endTime.Visibility == Visibility.Collapsed)
                                    spacer.Visibility = Visibility.Collapsed;
                                else
                                    spacer.Visibility = Visibility.Visible;

                                if (eventTextBlock.Tag != null)
                                    AnimationManager.ApplyAnimation(endTime, eventTextBlock.Tag.ToString(), InspireApp.GetCanvasSize());
                                break;
                            }
                        case ("GroupLogo"):
                            {
                                FillGroupLogo(eventTextBlock, hospitalityEvent.GroupLogo);
                                if (eventTextBlock.Tag != null)
                                    AnimationManager.ApplyAnimation(logo, eventTextBlock.Tag.ToString(), InspireApp.GetCanvasSize());
                                break;
                            }
                    }
                }
            else
                Content = null;
        }

        private HospitalityEvent GetEventToDisplay(TimeSpan showEventsAhead, TimeSpan showEventsBehind)
        {
            if (String.IsNullOrEmpty(InspireApp.PlaybackHostName))
            {
                _eventData = SampleEventManager.GetEvents();
                // var showEventsAhead = new TimeSpan(24, 0, 0);
                //var showEventssBehind = new TimeSpan(24, 0, 0);
            }
            else
            {
               // _eventData = HospitalityEventManager.GetEventsFromHostName(, InspireApp.PlaybackHostName, false);

                FilterEvents(showEventsAhead, showEventsBehind);
            }

            if(_eventData.Count > EventToShow)
                return _eventData[EventToShow];
            return null;
        }

        private void FilterEvents(TimeSpan showAhead, TimeSpan showBehind)
        {
            if (_eventData != null && _eventData.Count > 0)
            {
                DateTime currentTime = DateTime.Now;

                var tomorrowMidnight = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0) +
                                       new TimeSpan(1, 0, 0, 0);

                if (ShowAllTodaysEvents)
                    ShowEventsAhead = tomorrowMidnight - currentTime;

                _eventData =
                    _eventData.Where(
                        mediamodule =>
                        mediamodule.StartTime < currentTime + showAhead &&
                        mediamodule.EndTime > currentTime - showBehind).OrderBy(
                        mediamodule => mediamodule.StartTime).ToList();
            }
        }

        private void FillGroupLogo(EventTextBlock eventTextBlock, string groupLogo)
        {
            
            if (groupLogo.Length > 0 && !groupLogo.EndsWith("/"))
            {
                logo.Visibility = Visibility.Visible;
                logo.Width = eventTextBlock.Width;
                logo.Source = new BitmapImage(new Uri(groupLogo));
                if (eventTextBlock.Tag != null)
                    logo.Tag = eventTextBlock.Tag;
            }
            else
            {
                logo.Source = null;
                //logo.Visibility = Visibility.Collapsed;
            }
        }

        private static void CopyTBProperties(TextBlock fromTB, TextBlock toTB, string groupName)
        {
            toTB.Foreground = fromTB.Foreground;
            toTB.FontFamily = fromTB.FontFamily;
            toTB.FontSize = fromTB.FontSize;
            toTB.FontStyle = fromTB.FontStyle;
            toTB.FontWeight = fromTB.FontWeight;
            toTB.Margin = fromTB.Margin;
            toTB.Tag = fromTB.Tag;
            toTB.TextAlignment = fromTB.TextAlignment;
            toTB.TextDecorations = fromTB.TextDecorations;
            toTB.TextEffects = fromTB.TextEffects;
            toTB.FlowDirection = fromTB.FlowDirection;
            toTB.Visibility = fromTB.Visibility;
            //toTB.Width = fromTB.Width;
            toTB.TextWrapping = fromTB.TextWrapping;
            toTB.Text = groupName;
        }
        
        private void GetEvents()
        {
            if (InspireApp.IsPlayer)
                _eventData = EventLoader.GetEvents(true); // HospitalityEventManager.GetEventsFromHostName(DataSourceGuid, InspireApp.PlaybackHostName, true);
            else
                _eventData = HospitalityEventManager.GetEventsFromHostName(DataSourceGuid, InspireApp.PlaybackHostName, true);

            TimeSpan showBefore = EventLoader.GetShowAheadTime();
            TimeSpan showBehind = EventLoader.GetShowBehindTime();

            FilterEvents(showBefore, showBehind);
        }

        void RoomEventLoaded(object sender, EventArgs e)
        {
            if(noEventMessage)
            {
                Content = new TextBlock {FontSize = 20, TextWrapping = TextWrapping.Wrap,  Text = "This slide would be currently skipped since there are no events currently assigned for this display." };
            }
            else
            if(!loadedOnce)
            {

                (((Grid)Content).Children[0]).Visibility = Visibility.Collapsed;

                var verticalStack = ((Viewbox)((Grid)Content).Children[0]).Child as StackPanel;

                logo = verticalStack.Children[3] as Image;
                if (logo != null) logo.Visibility = Visibility.Collapsed;

                ((Grid)Content).Children.Insert(0, new LoadingControl(){ HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center});

                backgroundWorker = new BackgroundWorker();

                backgroundWorker.DoWork += backgroundWorker_DoWork;
                backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
                backgroundWorker.RunWorkerAsync();

                eventWorker = new BackgroundWorker();
                eventWorker.DoWork += eventWorker_DoWork;
                eventWorker.RunWorkerCompleted += eventWorker_RunWorkerCompleted;
                

                _dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);

                RefreshEventsWeakEventHandler.AddListener(_dispatcherTimer, this);

                _dispatcherTimer.Interval = TimeSpan.FromMinutes(1);
                _dispatcherTimer.Start();

                loadedOnce = true;
            }
        }

        void eventWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FilterEvents(ShowEventsAhead, ShowEventssBehind);

            _dispatcherTimer.Interval = TimeSpan.FromMinutes(1);
            _dispatcherTimer.Start();
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(UpdateAppearance));
        }

        void eventWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetEvents();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(ShowEvents));
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(2500);
        }

        private void ShowEvents()
        {
            if (EventColumns == null)
            {
                EventColumns = new ListBox();

                FillTextBlocks();

                EventTextBlock roomTB = new EventTextBlock("MeetingRoomName", roomName);
                EventTextBlock groupTB = new EventTextBlock("GroupName", groupName);
                EventTextBlock meetingTB = new EventTextBlock("MeetingName", description);
                EventTextBlock startTB = new EventTextBlock("StartTime", startTime);
                EventTextBlock endTB = new EventTextBlock("EndTime", endTime);
                EventTextBlock imageTB = new EventTextBlock("GroupLogo");
                imageTB.Width = 20;
                EventColumns.Items.Add(roomTB);
                EventColumns.Items.Add(groupTB);
                EventColumns.Items.Add(meetingTB);
                EventColumns.Items.Add(startTB);
                EventColumns.Items.Add(endTB);
                EventColumns.Items.Add(imageTB);
            }

            UpdateAppearance();
        }

        private void FillTextBlocks()
        {
            if (((Grid)Content).Children[0] is LoadingControl)
            {
                ((LoadingControl) ((Grid) Content).Children[0]).Dispose();
                ((Grid)Content).Children.RemoveAt(0);
                (((Grid) Content).Children[0]).Visibility = Visibility.Visible;
            }
            var verticalStack = ((Viewbox)((Grid)Content).Children[0]).Child as StackPanel;

            if (verticalStack.Children.Count.Equals(5))
            {
                roomName = verticalStack.Children[0] as TextBlock;
                groupName = verticalStack.Children[1] as TextBlock;
                description = verticalStack.Children[2] as TextBlock;

                var horizontalStack = verticalStack.Children[3] as StackPanel;

                startTime = horizontalStack.Children[0] as TextBlock;
                spacer = horizontalStack.Children[1] as TextBlock;
                endTime = horizontalStack.Children[2] as TextBlock;

                logo = verticalStack.Children[4] as Image;
            }
            else if (verticalStack.Children.Count.Equals(4))
            {
                groupName = verticalStack.Children[0] as TextBlock;
                description = verticalStack.Children[1] as TextBlock;

                var horizontalStack = verticalStack.Children[2] as StackPanel;

                startTime = horizontalStack.Children[0] as TextBlock;
                spacer = horizontalStack.Children[1] as TextBlock;
                endTime = horizontalStack.Children[2] as TextBlock;

                logo = verticalStack.Children[3] as Image;
            }
        }

        ~RoomEvent()
        {
            if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
            {
                Dispose();
            }
        }

        public void Play()
        {
            UpdateAppearance();
        }

        public void Stop()
        {
            
        }

        public bool IsPlaying()
        {
            return false;
        }

        public void Dispose()
        {
            EventColumns = null;

            if(backgroundWorker != null)
                backgroundWorker.Dispose();
            if (_dispatcherTimer != null)
            {
                _dispatcherTimer.Stop();
                _dispatcherTimer = null;
            }
            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => ClearValue(ContentProperty)));
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                RoomEventLoaded(sender, e);
                return true;
            }
            if (managerType == typeof(RefreshEventsWeakEventHandler))
            {
                TriggerDispatcherTimerTick(sender, e);
                return true;
            }
            return false;
        }

        void TriggerDispatcherTimerTick(object sender, EventArgs e)
        {
            if(!eventWorker.IsBusy)
                eventWorker.RunWorkerAsync();
        }

    }
}
