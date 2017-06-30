using System;
using System.Windows;
using System.Windows.Controls;

namespace Inspire.Services.WeakEventHandlers
{
    public class MouseDoubleClickEventHandler : WeakEventManager
    {
        public static void AddListener(ContentControl source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }

        public static void RemoveListener(ContentControl source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }

        private void OnMouseDoubleClick(Object sender, EventArgs args)
        {
            DeliverEvent(sender, args);
        }

        protected override void StartListening(Object source)
        {
            ContentControl contentControl = (ContentControl)source;
            contentControl.MouseDoubleClick += OnMouseDoubleClick;

        }

        protected override void StopListening(Object source)
        {
            ContentControl contentControl = (ContentControl)source;
            contentControl.MouseDoubleClick -= OnMouseDoubleClick;
        }

        private static MouseDoubleClickEventHandler CurrentManager
        {
            get
            {
                Type managerType = typeof(MouseDoubleClickEventHandler);
                MouseDoubleClickEventHandler manager = (MouseDoubleClickEventHandler)GetCurrentManager(managerType);
                if (manager == null)
                {
                    manager = new MouseDoubleClickEventHandler();
                    SetCurrentManager(managerType, manager);
                }
                return manager;
            }
        }

    }
}
