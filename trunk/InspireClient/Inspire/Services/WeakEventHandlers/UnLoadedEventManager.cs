using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Inspire.Services.WeakEventHandlers
{
    public class UnLoadedEventManager : WeakEventManager
    {
        public static void AddListener(FrameworkElement source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }

        public static void RemoveListener(FrameworkElement source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }

        private void UnLoaded(Object sender, EventArgs args)
        {
            DeliverEvent(sender, args);
        }

        protected override void StartListening(Object source)
        {
            FrameworkElement frameworkElement = (FrameworkElement)source;
            frameworkElement.Unloaded += UnLoaded;

        }

        protected override void StopListening(Object source)
        {
            FrameworkElement frameworkElement = (FrameworkElement)source;
            frameworkElement.Unloaded -= UnLoaded;
        }

        private static UnLoadedEventManager CurrentManager
        {
            get
            {
                Type managerType = typeof(UnLoadedEventManager);
                UnLoadedEventManager manager = (UnLoadedEventManager)GetCurrentManager(managerType);
                if (manager == null)
                {
                    manager = new UnLoadedEventManager();
                    SetCurrentManager(managerType, manager);
                }
                return manager;
            }
        }

    }
}
