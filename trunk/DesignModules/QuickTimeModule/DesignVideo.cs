using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Inspire;
using Inspire.Commands;
using Inspire.Services.WeakEventHandlers;

namespace QuickTimeModule
{
    public class DesignVideo : MediaElement , IWeakEventListener, IDisposable
    {
        public DesignVideo()
        {
            MediaEndedEventManager.AddListener(this, this);

            LoadedBehavior = MediaState.Manual;
            UnloadedBehavior = MediaState.Manual;
            IsVisibleChanged += (o, e) => Dispatcher.BeginInvoke(new DependencyPropertyChangedEventHandler(DesignVideo_IsVisibleChanged), o, e);

            ReplayOnEnd = true;

            if (!InspireApp.IsPlayer && !InspireApp.IsPreviewMode)
            {
                LoadedEventManager.AddListener(this, this);
                UnLoadedEventManager.AddListener(this, this);
                

                ScrubbingEnabled = true;
            }
            else
            {
                Pause(); //Load video but dont play until visible
               // Play();
            }
        }

        void DesignVideo_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible && InspireApp.IsPlaying)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(Play));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(Stop));
        }

        void DesignVideo_Unloaded(object sender, EventArgs e)
        {
            if (IsVisible) return;
                Dispose();
        }

        public DesignVideo(bool createPlayerControl)
        {
            
        }

        ~DesignVideo()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                                                                        {
                                                                            if (LoadedBehavior == MediaState.Manual)
                                                                                Stop();
                                                                        }));
           // Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(Stop));
        }

        private bool isPlaying;

        private double tempVolume = 0;

        public bool AdvanceOnEnd { get; set; }

        public bool ReplayOnEnd { get; set; }

        void DesignVideo_MediaEnded(object sender, EventArgs e)
        {
            MediaElement mediaElement = sender as MediaElement;
            if (mediaElement != null)
            {
                if ((InspireApp.IsPlayer || InspireApp.IsPreviewMode) && AdvanceOnEnd)
                    InspireCommands.PlayNextSlideCommand.Execute(null,null);
                else
                {
                    if (ReplayOnEnd)
                    {
                        mediaElement.Position = new TimeSpan(0);
                        mediaElement.Play();
                    }
                }
                
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
            if (managerType == typeof(UnLoadedEventManager))
            {
                DesignVideo_Unloaded(sender, e);
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