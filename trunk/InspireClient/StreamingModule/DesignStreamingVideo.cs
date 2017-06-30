using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Inspire;
using Inspire.Services.WeakEventHandlers;

namespace StreamingModule
{
    public class DesignStreamingVideo : MediaElement, IWeakEventListener
    {
        private bool isPlaying;

        private double tempVolume = 0;

        public DesignStreamingVideo()
        {
            LoadedBehavior = MediaState.Manual;

            if (!InspireApp.IsPlayer && !InspireApp.IsPreviewMode)
            {
                LoadedEventManager.AddListener(this, this);

                ScrubbingEnabled = true;
            }
            else
            {
                Play();
            }
        }

        ~DesignStreamingVideo()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => ClearValue(SourceProperty)));
        }

        public void StopVideo()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
            {
                Position = new TimeSpan(0, 0, 0, 2);
                Pause();
            }));
            isPlaying = false;
        }

        public void PlayVideo()
        {
            isPlaying = true;
            tempVolume = Volume;
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(Play));
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                Loaded_Event(sender, e);
                return true;
            }
            return false;
        }

        private void Loaded_Event(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                LoadedBehavior = MediaState.Manual;
                tempVolume = Volume;
                Position = new TimeSpan(0, 0, 0, 2);
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(Pause));
            }
        }

        #endregion
    }
}
