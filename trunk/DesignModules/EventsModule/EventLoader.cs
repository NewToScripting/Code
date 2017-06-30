using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Timers;
using Inspire;
using Inspire.Events.Proxy;
using HospitalityEvent = Inspire.Events.Proxy.HospitalityEvent;

namespace EventsModule
{
    internal static class EventLoader
    {

        private static List<HospitalityEvent> _nonFilteredEvents;

        private static List<HospitalityEvent> _filteredEvents;

        private static readonly BackgroundWorker EventWorker;

        private static readonly Timer GetEventTimer;

        private static bool _eventFlag;

        private static readonly double UpdateInterval;

        private static readonly TimeSpan ShowEventsAhead;

        private static readonly TimeSpan ShowEventsBehind;

        static EventLoader()
        {
            if (InspireApp.IsPlayer)
            {
                _nonFilteredEvents = new List<HospitalityEvent>();
                _filteredEvents = new List<HospitalityEvent>();

                _eventFlag = true;

                try
                {
                    UpdateInterval = SeverSettings.EventRefreshInterval * 60000;

                    ShowEventsAhead = SeverSettings.LookAheadTime;

                    ShowEventsBehind = SeverSettings.LookBehindTime;
                }
                catch (Exception)
                {
                    UpdateInterval = 60000.0;
                    ShowEventsAhead = new TimeSpan(1, 0, 0);
                    ShowEventsBehind = new TimeSpan(0, 0, 0);
                }

                EventWorker = new BackgroundWorker();
                EventWorker.DoWork += EventWorkerDoWork;
                EventWorker.RunWorkerCompleted += EventWorkerRunWorkerCompleted;
                EventWorker.RunWorkerAsync();

                GetEventTimer = new Timer(UpdateInterval);
                GetEventTimer.Elapsed += GetEventTimerElapsed;
                GetEventTimer.Start();
            }

        }

        static void GetEventTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if(_eventFlag)
                if(!EventWorker.IsBusy)
                    EventWorker.RunWorkerAsync();
        }

        static void EventWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _eventFlag = false;
            GetEventTimer.Interval = UpdateInterval;
        }

        static void EventWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string dataSourceGuid = string.Empty;

                var nonFilt = HospitalityEventManager.GetEventsFromHostName(dataSourceGuid, InspireApp.PlaybackHostName, false);
                var filtEvents = HospitalityEventManager.GetEventsFromHostName(dataSourceGuid, InspireApp.PlaybackHostName, true);

                if (nonFilt != null)
                    _nonFilteredEvents = nonFilt;
                if (filtEvents != null)
                    _filteredEvents = filtEvents;
            }
            catch (Exception)
            {
                _nonFilteredEvents = new List<HospitalityEvent>();
                _filteredEvents = new List<HospitalityEvent>();
            }
        }

        internal static List<HospitalityEvent> GetEvents(bool filtered)
        {
            _eventFlag = true;

            if (filtered)
                return _filteredEvents;
            return _nonFilteredEvents;
        }

        internal static TimeSpan GetShowAheadTime()
        {
            return ShowEventsAhead;
        }

        internal static TimeSpan GetShowBehindTime()
        {
            return ShowEventsBehind;
        }
    }
}
