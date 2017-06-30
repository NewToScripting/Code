using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Documents;
using Inspire.Interfaces;
using System.Windows;
using System.ComponentModel;
using Inspire.Events.Proxy;
using System.Windows.Threading;
using Inspire;
using Inspire.Services.WeakEventHandlers;

namespace EventsModule
{
    public class RoomEventControl : StackPanel, IWeakEventListener, IDisposable
    {
        private int _refreshInterval;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int RefreshInterval { get { return _refreshInterval; } set { _refreshInterval = ValidateRefreshInterval(value); } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string DataSourceGuid { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TimeSpan ShowEventsAhead { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TimeSpan ShowEventssBehind { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ListBox EventColumns { get; set; }

        private List<HospitalityEvent> _eventData;
        private bool _isPlaying;
        private bool _hasLoadedOnce;
        private bool _isLoaded;
        private int _eventsShown;
        private bool _isFirstPage;
        private int _totalEvents;
        private BackgroundWorker backgroundWorker;
        private DispatcherTimer _dispatcherTimer;
        private DispatcherTimer _triggerDispatcherTimer;

        public List<HospitalityEvent> GetEventData()
        {
            return _eventData;
        }

        private static int ValidateRefreshInterval(int value)
        {
            return value > 2 ? value : 2;
        }

        public RoomEventControl()
        {
            Margin = new Thickness(10);

            LoadedEventManager.AddListener(this, this);

            _triggerDispatcherTimer = new DispatcherTimer();
            _dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);

            RefreshEventsWeakEventHandler.AddListener(_triggerDispatcherTimer, this);
            StartEventsWeakEventHandler.AddListener(_dispatcherTimer, this);

            backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;

            Children.Add(new LoadingControl());
        }

        public RoomEventControl(string datasourceGuid, ListBox columnTextBlocks, int refreshInterval, TimeSpan showAheadTime, TimeSpan showBehindTime): this()
        {
            DataSourceGuid = datasourceGuid;

            Tag = columnTextBlocks.Tag;

            EventColumns = columnTextBlocks;

            _refreshInterval = refreshInterval;

            ShowEventsAhead = showAheadTime;

            ShowEventssBehind = showBehindTime;

        }

        public RoomEventControl(RoomEventControl control)
            : this()
        {
            DataSourceGuid = control.DataSourceGuid;

            EventColumns = control.EventColumns;

            _refreshInterval = control.RefreshInterval;

            ShowEventsAhead = control.ShowEventsAhead;

            ShowEventssBehind = control.ShowEventssBehind;

        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var results = e.Result as object[];
            if (results != null)
            {
                var filtEventData = results[1] as List<HospitalityEvent>;
                if (filtEventData != null)
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => UpdateEventData(filtEventData)));
            }
        }

        private void UpdateEventData(List<HospitalityEvent> filtEventData)
        {
            
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000); // wait for a second so the loading pop

            var args = e.Argument as object[];

            List<HospitalityEvent> eventData;
            List<HospitalityEvent> filteredEventData = null;

            if (args != null)
            {
                TimeSpan showEventsAhead = args[0] is TimeSpan ? (TimeSpan)args[0] : new TimeSpan();
                TimeSpan showEventssBehind = args[1] is TimeSpan ? (TimeSpan)args[1] : new TimeSpan();

                string dsGuid = args[2].ToString();
                var showEvntsForAllDisplays = (bool)args[3];
                string hdrRow = args[4].ToString();

                if (dsGuid == null)
                    dsGuid = "";

                DateTime currentTime = DateTime.Now;

                var tomorrowMidnight = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0) + new TimeSpan(1, 0, 0, 0);

                if (showEvntsForAllDisplays)
                    showEventsAhead = tomorrowMidnight - currentTime;

                if (String.IsNullOrEmpty(InspireApp.PlaybackHostName))
                {
                    eventData = SampleEventManager.GetEvents();
                    showEventsAhead = new TimeSpan(24, 0, 0);
                    showEventssBehind = new TimeSpan(24, 0, 0);
                }
                else
                {
                    //eventData = HospitalityEventManager.GetEvents(DataSourceGuid);
                    eventData = HospitalityEventManager.GetEventsFromHostName(dsGuid, InspireApp.PlaybackHostName, showEvntsForAllDisplays);
                    //if (SkipSlideIfNoEvents)
                    //{
                    //if (eventData.Count < 1)
                    //    InspireApp.PlayNextSlide = false;
                    //}
                }

                string sortByField = String.IsNullOrEmpty(hdrRow) ? "GroupName" : hdrRow;

                if (eventData != null)
                    switch (sortByField)
                    {
                        case ("GroupName"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.GroupName).ToList();
                            //filteredEventData = eventData.OrderBy(mediamodule => mediamodule.GroupName).ToList();
                            break;
                        case ("HotelName"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.HotelName).ToList();
                            break;
                        //case ("Date"):
                        //    filteredEventData = eventData.OrderBy(mediamodule => mediamodule.Date).ToList();
                        //    break;
                        //case ("EndDate"):
                        //    filteredEventData = eventData.OrderBy(mediamodule => mediamodule.EndDate).ToList();
                        //    break;
                        case ("EndTime"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.EndTime).ToList();
                            break;
                        case ("Exhibit"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.Exhibit).ToList();
                            break;
                        case ("GroupLogo"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.GroupLogo).ToList();
                            break;
                        case ("BackupMeetingRoomSpace"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.BackupMeetingRoomSpace).ToList();
                            break;
                        case ("HostEventIdentifier"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.HostEventIdentifier).ToList();
                            break;
                        case ("MeetingID"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.MeetingID).ToList();
                            break;
                        case ("MeetingLogo"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.MeetingLogo).ToList();
                            break;
                        case ("MeetingName"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.MeetingName).ToList();
                            break;
                        case ("MeetingPostAs"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.MeetingPostAs).ToList();
                            break;
                        case ("MeetingRoomID"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.MeetingRoomID).ToList();
                            break;
                        case ("MeetingRoomLogo"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.MeetingRoomLogo).ToList();
                            break;
                        case ("MeetingRoomName"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.MeetingRoomName).ToList();
                            break;
                        case ("MeetingType"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.MeetingType).ToList();
                            break;
                        case ("OverflowMeetingRoomSpace"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.OverflowMeetingRoomSpace).ToList();
                            break;
                        case ("Postable"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.Postable).ToList();
                            break;
                        //case ("StartDate"):
                        //    filteredEventData = eventData.OrderBy(mediamodule => mediamodule.StartDate).ToList();
                        //    break;
                        case ("StartTime"):
                            filteredEventData = eventData.Where(mediamodule => mediamodule.StartTime < currentTime + showEventsAhead && mediamodule.EndTime > currentTime - showEventssBehind).OrderBy(mediamodule => mediamodule.StartTime).ToList();
                            break;
                    }

                var results = new object[2];
                results[0] = hdrRow;
                results[1] = filteredEventData;

                e.Result = results;

            }
        }

        ~RoomEventControl()
        {
            if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
            {
                Dispose();
            }
            //MessageBox.Show("RSS Gone");
        }

        void RoomEventControlLoaded(object sender, EventArgs e)
        {
            if (!_isLoaded)
            {
                var args = new object[3];
                args[0] = ShowEventsAhead;
                args[1] = ShowEventssBehind;
                args[2] = DataSourceGuid;

                backgroundWorker.RunWorkerAsync(args);
                _isLoaded = true;
            }
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                RoomEventControlLoaded(sender, e);
                return true;
            }
            if (managerType == typeof(RefreshEventsWeakEventHandler))
            {
                //TriggerDispatcherTimerTick(sender, e);
                return true;
            }
            if (managerType == typeof(StartEventsWeakEventHandler))
            {
               // DispatcherTimerTick(sender, e);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            EventColumns = null;
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => Children.Clear()));//Children.Clear();
            //HeaderRow = null;

            //_triggerDispatcherTimer.Stop();
            //_dispatcherTimer.Stop();

            //_triggerDispatcherTimer = null;
            //_dispatcherTimer = null;

            //backgroundWorker.DoWork -= backgroundWorker_DoWork;

            //backgroundWorker.RunWorkerCompleted -= backgroundWorker_RunWorkerCompleted;
            //backgroundWorker = null;
        }

    }
}
