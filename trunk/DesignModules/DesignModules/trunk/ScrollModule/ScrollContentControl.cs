using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Inspire;
using Inspire.Services.WeakEventHandlers;

namespace ScrollModule
{
    public class ScrollContentControl : ContentControl , IWeakEventListener
    {

        //public ListBox ScrollItems { get; set; }

        private delegate void NoArgDelegate();

        private List<ScrollItem> _scrollItems = new List<ScrollItem>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<ScrollItem> ScrollItems { get { return _scrollItems; } }


        public int ScrollSpeed { get; set; }

        public ScrollContentControl()
        {
            if(InspireApp.IsPlayer)
            {
                LoadedEventManager.AddListener(this, this);
            }
        }

        public ScrollContentControl(int scrollSpeed, IEnumerable<ScrollItem> scrollItems)
        {
            var frameworkElements = new List<FrameworkElement>();

            foreach (var item in scrollItems)
            {
                _scrollItems.Add(item);
                frameworkElements.Add(item.GetScrollItem());
            }

            Content = new ScrollControl(scrollSpeed, frameworkElements, false);

            ScrollSpeed = scrollSpeed;
        }

        public ScrollContentControl( ScrollContentControl scrollContentControl)
        {
            var frameworkElements = new List<FrameworkElement>();

            foreach (var item in scrollContentControl.ScrollItems)
            {
                _scrollItems.Add(item);
                frameworkElements.Add(item.GetScrollItem());
            }

            Content = new ScrollControl(scrollContentControl.ScrollSpeed, frameworkElements, false);
            ScrollSpeed = scrollContentControl.ScrollSpeed;
        }

        public void LoadControl()
        {
            var frameworkElements = new List<FrameworkElement>();

            foreach (var item in ScrollItems)
            {
                frameworkElements.Add(item.GetScrollItem());
            }

            Content = new ScrollControl(ScrollSpeed, frameworkElements, true);

            Play();
        }

        void ScrollContentControl_Loaded(object sender, EventArgs e)
        {
            NoArgDelegate noArgDelegate = LoadControl;
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, noArgDelegate);

           // NoArgDelegate noArgDelegate2 = Play;
            //Dispatcher.BeginInvoke(DispatcherPriority.Normal, noArgDelegate2);
        }

        public void Play()
        {
            ScrollControl scrollControl = Content as ScrollControl;
            if (scrollControl != null) scrollControl.Play();
        }

        public void Stop()
        {
            ScrollControl scrollControl = Content as ScrollControl;
            if (scrollControl != null) scrollControl.Stop();
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                ScrollContentControl_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
