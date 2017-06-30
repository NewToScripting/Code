using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Inspire;
using Inspire.Services.WeakEventHandlers;

namespace VideoModule
{
    public class DesignVideo : MediaElement , IWeakEventListener
    {
        public DesignVideo()
        {
            MediaEndedEventManager.AddListener(this, this);
            LoadedEventManager.AddListener(this, this);
            //Position = new TimeSpan(0, 0, 0, 3);
            //Pause();

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            RenderVideoImage();
        }

        private delegate void IsPlayerDelegate();

        private delegate void OneArgDelegate(double arg);

        private readonly BackgroundWorker backgroundWorker;

        private bool isPlaying;

        private double tempVolume = 0;

        void DesignVideo_MediaEnded(object sender, EventArgs e)
        {
            MediaElement mediaElement = sender as MediaElement;
            if (mediaElement != null)
            {
                mediaElement.Position = new TimeSpan(0, 0, 0, 3);
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

        private delegate void PlayVideoDelegate();

        private delegate void PauseVideoDelegate();


        public void StopVideo()
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        public void PlayVideo()
        {
            isPlaying = true;
            tempVolume = Volume;
            PlayVideoDelegate playVideoDelegate = Play;
            playVideoDelegate.BeginInvoke(null, null);
        }

        private void RenderVideoImage()
        {
            Thread.Sleep(2000);
            OneArgDelegate pauseDelegate = DoPause;
            Dispatcher.BeginInvoke(pauseDelegate, tempVolume);
        }

        private void DoPause(double vol)
        {
            Pause();
            Volume = vol;
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(MediaEndedEventManager))
            {
                DesignVideo_MediaEnded(sender, e);
                return true;
            }
            if (managerType == typeof(LoadedEventManager))
            {
                Loaded_Event(sender, e);
                return true;
            }
            return false;
        }

        private void Loaded_Event(object sender, EventArgs e)
        {
            if (InspireApp.IsPlayer)
            {
                IsPlayerDelegate isPlayerDelegate = PlayVideo;
                Dispatcher.BeginInvoke(isPlayerDelegate, null);
            }
            else
            {
                if(!isPlaying)
                    {
                        LoadedBehavior = MediaState.Manual;
                        Position = TimeSpan.FromSeconds(3);
                        tempVolume = Volume;
                        IsPlayerDelegate stopDelegate = StopVideo;
                        Dispatcher.BeginInvoke(stopDelegate, null);
                    }
            }
        }

        #endregion
    }
}
