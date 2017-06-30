using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Inspire;
using Inspire.Interfaces;
using Inspire.Services.WeakEventHandlers;


namespace ScrollModule
{
    public class ScrollContentControl : ContentControl , IWeakEventListener, IDisposable
    {

        private List<ScrollItem> _scrollItems = new List<ScrollItem>();

        private bool _isLoaded;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<ScrollItem> ScrollItems { get { return _scrollItems; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string ScrollDirection { get; set; }

        public double ScrollSpeed { get; set; }

        public ScrollContentControl()
        {
            if(InspireApp.IsPlayer || InspireApp.IsPreviewMode)
            {
                LoadedEventManager.AddListener(this, this);
                ScrollDirection = "Left";
            }
        }

        public ScrollContentControl(double scrollSpeed, IEnumerable<ScrollItem> scrollItems, string scrollDirection, string scrollStyle)
        {
            var frameworkElements = new List<FrameworkElement>();

           // scrollDirection = "Left";

            foreach (var item in scrollItems)
            {
                _scrollItems.Add(item);
                frameworkElements.AddRange(item.GetScrollItems(scrollDirection));
            }

            if (scrollStyle == "Scroll")
                Content = new ScrollControl(scrollSpeed, frameworkElements, scrollDirection, false);
            else if (scrollStyle == "ESPNStyle")
                Content = new ESPNScroller(scrollSpeed, frameworkElements, scrollDirection, false);
            else
                Content = new ScrollControl(scrollSpeed, frameworkElements, scrollDirection, false);

            Tag = scrollStyle;

            ScrollSpeed = scrollSpeed;
        }

        public ScrollContentControl( ScrollContentControl scrollContentControl)
        {
            var frameworkElements = new List<FrameworkElement>();

            Tag = scrollContentControl.Tag;

            ScrollDirection = scrollContentControl.ScrollDirection;

            foreach (var item in scrollContentControl.ScrollItems)
            {
                _scrollItems.Add(item);
                frameworkElements.AddRange(item.GetScrollItems(scrollContentControl.ScrollDirection));
            }

            if (Tag != null && Tag.ToString() == "Scroll")
                Content = new ScrollControl(scrollContentControl.ScrollSpeed, frameworkElements, scrollContentControl.ScrollDirection, false);
            else if (Tag != null && Tag.ToString() == "ESPNStyle")
                Content = new ESPNScroller(scrollContentControl.ScrollSpeed, frameworkElements, scrollContentControl.ScrollDirection, false);
            else
                Content = new ScrollControl(scrollContentControl.ScrollSpeed, frameworkElements, scrollContentControl.ScrollDirection, false);

            scrollContentControl.Dispose();
            
            ScrollSpeed = scrollContentControl.ScrollSpeed;
        }

        ~ScrollContentControl()
        {
            try
            {
                if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
                {
                    Dispose();
                }
            }
            catch (Exception)
            {
            }
        }

        public void Dispose()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
            {
                if (ScrollItems != null)
                    ScrollItems.Clear();
                if (_scrollItems != null)
                    _scrollItems.Clear();

                ClearValue(ContentProperty);
            }));
        }

        public void LoadControl()
        {
            var frameworkElements = new List<FrameworkElement>();

            foreach (var item in ScrollItems)
            {
                frameworkElements.AddRange(item.GetScrollItems(ScrollDirection));
            }

            if (Tag != null)
            {
                if (Tag.ToString() == "Scroll")
                    Content = new ScrollControl(ScrollSpeed, frameworkElements, ScrollDirection, true);
                else if (Tag.ToString() == "ESPNStyle")
                    Content = new ESPNScroller(ScrollSpeed, frameworkElements, ScrollDirection, true);
            }
            else
                Content = new ScrollControl(ScrollSpeed, frameworkElements, ScrollDirection, true);
        }

        void ScrollContentControl_Loaded(object sender, EventArgs e)
        {
            if (!_isLoaded)
            {
                //NoArgDelegate noArgDelegate = LoadControl;
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(()=> LoadControl()));
                _isLoaded = true;
            }

           // NoArgDelegate noArgDelegate2 = Play;
            //Dispatcher.BeginInvoke(DispatcherPriority.Normal, noArgDelegate2);
        }

        public void Play()
        {
            if (Content != null)
            {
                var scrollControl = Content as IPlayable;
                if (scrollControl != null)
                    scrollControl.Play();
            }
            else
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(LoadControl));
            }
        }

        public void Stop()
        {
            var scrollControl = Content as IPlayable;
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
