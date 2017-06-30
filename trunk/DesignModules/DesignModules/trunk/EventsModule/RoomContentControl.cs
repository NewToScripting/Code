using System;
using System.Windows;
using System.Windows.Controls;
using EventsModule.EventTemplates.RoomEvents;
using Inspire.Services.WeakEventHandlers;

namespace EventsModule
{
    public class RoomContentControl : ContentControl , IWeakEventListener
    {

        public int RefreshInterval { get; set; }
        public string TemplateFileName { get; set; }

        public RoomContentControl()
        {
            LoadedEventManager.AddListener(this, this);
        }

        void RoomContentControl_Loaded(object sender, EventArgs e)
        {
            Content = new RoomEvent();
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                RoomContentControl_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
