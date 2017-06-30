using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Inspire.Services.WeakEventHandlers
{
    public class LayoutUpdatedEventManager : WeakEventManager
    {
        public static void AddListener(FrameworkElement source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }

        public static void RemoveListener(FrameworkElement source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }

        private void OnLayoutUpdated(Object sender, EventArgs args)
        {
            DeliverEvent(sender, args);
        }

        protected override void StartListening(Object source)
        {
            FrameworkElement frameworkElement = (FrameworkElement)source;
            frameworkElement.LayoutUpdated += OnLayoutUpdated;

        }

        protected override void StopListening(Object source)
        {
            FrameworkElement frameworkElement = (FrameworkElement)source;
            frameworkElement.LayoutUpdated -= OnLayoutUpdated;
        }

        private static LayoutUpdatedEventManager CurrentManager
        {
            get
            {
                Type managerType = typeof(LayoutUpdatedEventManager);
                LayoutUpdatedEventManager manager = (LayoutUpdatedEventManager)GetCurrentManager(managerType);
                if (manager == null)
                {
                    manager = new LayoutUpdatedEventManager();
                    SetCurrentManager(managerType, manager);
                }
                return manager;
            }
        }

    }
}
