using System;
using System.Windows;
using System.Windows.Controls;

namespace Inspire.Services.WeakEventHandlers
{
    public class MouseDownEventHandler : WeakEventManager
    {
        public static void AddListener(ContentControl source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }

        public static void RemoveListener(ContentControl source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }

        private void OnMouseDown(Object sender, EventArgs args)
        {
            DeliverEvent(sender, args);
        }

        protected override void StartListening(Object source)
        {
            ContentControl contentControl = (ContentControl)source;
            contentControl.PreviewMouseLeftButtonUp += OnMouseDown;

        }

        protected override void StopListening(Object source)
        {
            ContentControl contentControl = (ContentControl)source;
            contentControl.PreviewMouseLeftButtonUp -= OnMouseDown;
        }

        private static MouseDownEventHandler CurrentManager
        {
            get
            {
                Type managerType = typeof(MouseDownEventHandler);
                MouseDownEventHandler manager = (MouseDownEventHandler)GetCurrentManager(managerType);
                if (manager == null)
                {
                    manager = new MouseDownEventHandler();
                    SetCurrentManager(managerType, manager);
                }
                return manager;
            }
        }

    }
}
