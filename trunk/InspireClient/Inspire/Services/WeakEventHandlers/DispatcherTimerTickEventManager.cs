using System;
using System.Windows;
using System.Windows.Threading;

namespace Inspire.Services.WeakEventHandlers
{
    public class DispatcherTimerTickEventManager : WeakEventManager
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

        private static DispatcherTimerTickEventManager CurrentManager
        {
            get
            {
                Type managerType = typeof(DispatcherTimerTickEventManager);
                DispatcherTimerTickEventManager manager = (DispatcherTimerTickEventManager)GetCurrentManager(managerType);
                if (manager == null)
                {
                    manager = new DispatcherTimerTickEventManager();
                    SetCurrentManager(managerType, manager);
                }
                return manager;
            }
        }

    }
}