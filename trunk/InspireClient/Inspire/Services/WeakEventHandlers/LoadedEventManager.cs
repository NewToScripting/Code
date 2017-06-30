using System;
using System.Windows;

namespace Inspire.Services.WeakEventHandlers
{
    public class LoadedEventManager : WeakEventManager
    {
        public static void AddListener(FrameworkElement source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }

        public static void RemoveListener(FrameworkElement source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }

        private void OnLoaded(Object sender, EventArgs args)
        {
            DeliverEvent(sender, args);
        }

        protected override void StartListening(Object source)
        {
            FrameworkElement frameworkElement = (FrameworkElement)source;
            frameworkElement.Loaded += OnLoaded;

        }

        protected override void StopListening(Object source)
        {
            FrameworkElement frameworkElement = (FrameworkElement)source;
            frameworkElement.Loaded -= OnLoaded;
        }

        private static LoadedEventManager CurrentManager
        {
            get
            {
                Type managerType = typeof(LoadedEventManager);
                LoadedEventManager manager = (LoadedEventManager)GetCurrentManager(managerType);
                if (manager == null)
                {
                    manager = new LoadedEventManager();
                    SetCurrentManager(managerType, manager);
                }
                return manager;
            }
        }

    }
}

