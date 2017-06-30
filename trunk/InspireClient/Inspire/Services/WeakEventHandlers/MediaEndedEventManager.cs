using System;
using System.Windows;
using System.Windows.Controls;

namespace Inspire.Services.WeakEventHandlers
{
    public class MediaEndedEventManager : WeakEventManager
    {
        public static void AddListener(MediaElement source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }

        public static void RemoveListener(MediaElement source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }

        private void OnMediaEnded(Object sender, EventArgs args)
        {
            DeliverEvent(sender, args);
        }

        protected override void StartListening(Object source)
        {
            MediaElement mediaElement = (MediaElement)source;
            mediaElement.MediaEnded += OnMediaEnded;

        }

        protected override void StopListening(Object source)
        {
            MediaElement mediaElement = (MediaElement)source;
            mediaElement.MediaEnded -= OnMediaEnded;
        }

        private static MediaEndedEventManager CurrentManager
        {
            get
            {
                Type managerType = typeof(MediaEndedEventManager);
                MediaEndedEventManager manager = (MediaEndedEventManager)GetCurrentManager(managerType);
                if (manager == null)
                {
                    manager = new MediaEndedEventManager();
                    SetCurrentManager(managerType, manager);
                }
                return manager;
            }
        }

    }
}