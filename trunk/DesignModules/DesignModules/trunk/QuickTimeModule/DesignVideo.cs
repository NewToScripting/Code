using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Inspire.Services.WeakEventHandlers;

namespace QuickTimeModule
{
    public class DesignVideo : MediaElement, IWeakEventListener
    {
        public DesignVideo()
        {
            MediaEndedEventManager.AddListener(this, this);
        }

        private bool IsPlayLoaded;
        private bool IsPauseLoaded;

        void DesignVideo_MediaEnded(object sender, EventArgs e)
        {
            MediaElement mediaElement = sender as MediaElement;
            if (mediaElement != null)
            {
                mediaElement.Position = new TimeSpan(0, 0, 0, 0);
                mediaElement.LoadedBehavior = MediaState.Manual;
                mediaElement.Play();
            }
        }

        #region IsNewFile Members

        public bool IsNewFile
        {
            get
            {
                return (bool)GetValue(IsNewFileProperty);
            }
            set
            {
                SetValue(IsNewFileProperty, value);
            }
        }

        public static readonly DependencyProperty IsNewFileProperty =
          DependencyProperty.Register("IsNewFile",
                                       typeof(bool),
                                       typeof(DesignVideo),
                                       new FrameworkPropertyMetadata(false));

        #endregion

        private delegate void RenderVideoImageDelegate(MediaElement mediaElement);

        public static DesignVideo GetMediaImage(DesignVideo mediaElement)
        {
            // Draw the DesignImage

            mediaElement.Position = TimeSpan.FromSeconds(3);
            mediaElement.LoadedBehavior = MediaState.Manual;
            if (mediaElement.IsPlayLoaded)
                mediaElement.Loaded -= mediaElement_PlayerLoaded;
            if (!mediaElement.IsPauseLoaded)
                mediaElement.Loaded += mediaElement_CanvasLoaded;
            return mediaElement;
        }

        public static DesignVideo GetPlayerVideo(DesignVideo mediaElement)
        {
            mediaElement.LoadedBehavior = MediaState.Play;
            mediaElement.Volume = 100;
            if (mediaElement.IsPauseLoaded)
                mediaElement.Loaded -= mediaElement_CanvasLoaded;
            if (!mediaElement.IsPlayLoaded)
                mediaElement.Loaded += mediaElement_PlayerLoaded;
            return mediaElement;
        }

        static void mediaElement_CanvasLoaded(object sender, RoutedEventArgs e)
        {
            var mediaElement = (DesignVideo)sender;
            RenderVideoImageDelegate renderVideoImageDelegate = RenderVideoImage;
            mediaElement.Dispatcher.BeginInvoke(DispatcherPriority.Normal, renderVideoImageDelegate, mediaElement);
            mediaElement.IsPlayLoaded = false;
            mediaElement.IsPauseLoaded = true;
        }

        static void mediaElement_PlayerLoaded(object sender, RoutedEventArgs e)
        {
            var mediaElement = (DesignVideo)sender;
            mediaElement.LoadedBehavior = MediaState.Manual;
            mediaElement.Play();
            mediaElement.IsPlayLoaded = true;
            mediaElement.IsPauseLoaded = false;
        }

        private static void RenderVideoImage(MediaElement mediaElement)
        {
            mediaElement.Position = TimeSpan.FromSeconds(3);
            mediaElement.Play();
            mediaElement.Volume = 0;
            Thread.Sleep(1000);
            mediaElement.Pause();
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(MediaEndedEventManager))
            {
                DesignVideo_MediaEnded(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}