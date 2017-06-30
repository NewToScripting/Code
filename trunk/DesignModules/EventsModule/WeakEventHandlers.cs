using System;
using System.Windows;
using System.Windows.Threading;

namespace EventsModule
{
    public class RefreshEventsWeakEventHandler : WeakEventManager
    {
        public static void AddListener(DispatcherTimer source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }

        public static void RemoveListener(DispatcherTimer source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }

        private void OnTimerTick(Object sender, EventArgs args)
        {
            DeliverEvent(sender, args);
        }

        protected override void StartListening(Object source)
        {
            DispatcherTimer dispatcherTimer = (DispatcherTimer)source;
            dispatcherTimer.Tick += OnTimerTick;

        }

        protected override void StopListening(Object source)
        {
            DispatcherTimer dispatcherTimer = (DispatcherTimer)source;
            dispatcherTimer.Tick -= OnTimerTick;
        }

        private static RefreshEventsWeakEventHandler CurrentManager
        {
            get
            {
                Type managerType = typeof(RefreshEventsWeakEventHandler);
                RefreshEventsWeakEventHandler manager = (RefreshEventsWeakEventHandler)GetCurrentManager(managerType);
                if (manager == null)
                {
                    manager = new RefreshEventsWeakEventHandler();
                    SetCurrentManager(managerType, manager);
                }
                return manager;
            }
        }

    }

    public class StartEventsWeakEventHandler : WeakEventManager
    {
        public static void AddListener(DispatcherTimer source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }

        public static void RemoveListener(DispatcherTimer source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }

        private void OnTimerTick(Object sender, EventArgs args)
        {
            DeliverEvent(sender, args);
        }

        protected override void StartListening(Object source)
        {
            DispatcherTimer dispatcherTimer = (DispatcherTimer)source;
            dispatcherTimer.Tick += OnTimerTick;

        }

        protected override void StopListening(Object source)
        {
            DispatcherTimer dispatcherTimer = (DispatcherTimer)source;
            dispatcherTimer.Tick -= OnTimerTick;
        }

        private static StartEventsWeakEventHandler CurrentManager
        {
            get
            {
                Type managerType = typeof(StartEventsWeakEventHandler);
                StartEventsWeakEventHandler manager = (StartEventsWeakEventHandler)GetCurrentManager(managerType);
                if (manager == null)
                {
                    manager = new StartEventsWeakEventHandler();
                    SetCurrentManager(managerType, manager);
                }
                return manager;
            }
        }

    }
}
