using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Controls;
using Inspire;
using Inspire.Services.WeakEventHandlers;
using System.Windows.Threading;
using System.Windows;

namespace PlaylistModule
{
    public class PlaylistControlHolder : ContentControl, IDisposable ,IWeakEventListener
    {
        bool _hasLoaded;

        public PlaylistControlHolder()
        {
            if(PlaylistItems == null)
                PlaylistItems = new ListBox();

            LoadedEventManager.AddListener(this, this);
        }

        public PlaylistControlHolder(IEnumerable<PlaylistElement> playlistElements)
        {
            PlaylistItems = new ListBox();
            foreach (var element in playlistElements)
            {
                PlaylistItems.Items.Add(element);
            }
            LoadedEventManager.AddListener(this, this);

        }

        ~PlaylistControlHolder()
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

        void PlaylistControlHolderLoaded(object sender, EventArgs e)
        {
            if (!_hasLoaded)
            {
                if (InspireApp.IsPlayer)
                {
                    foreach (PlaylistElement playlistElement in PlaylistItems.Items)
                    {
                        PlaylistFile playlistFile = playlistElement.MediaElement as PlaylistFile;
                        if (playlistFile != null)
                        {
                            int fileLenth = playlistFile.Uri.IndexOf("/");
                            string designContentControlGuid = playlistFile.Uri.Substring(0, fileLenth);
                            if (
                                File.Exists(Paths.PlayerSlideDirectory + InspireApp.CurrentSlideGuid + "\\" +
                                            designContentControlGuid + "\\" + Path.GetFileName(playlistFile.Uri)))
                            {
                                playlistFile.Uri = Paths.PlayerSlideDirectory + InspireApp.CurrentSlideGuid + "\\" +
                                                   designContentControlGuid + "\\" + Path.GetFileName(playlistFile.Uri);
                            }
                            playlistElement.MediaElement = playlistFile;
                        }
                        //PlaylistItems.Items.Add(playlistElement);
                    }
                }
                else
                {
                    foreach (PlaylistElement playlistElement in PlaylistItems.Items)
                    {
                        PlaylistFile playlistFile = playlistElement.MediaElement as PlaylistFile;
                        if (playlistFile != null)
                        {
                            int fileLength = playlistFile.Uri.IndexOf("/");
                            if (fileLength > 0)
                            {
                                string designContentControlGuid = playlistFile.Uri.Substring(0, fileLength);
                                if (File.Exists(Paths.ClientPlaybackTempDirectory + InspireApp.CurrentSlideGuid + "\\" + designContentControlGuid + "\\" + Path.GetFileName(playlistFile.Uri)))
                                {
                                    playlistFile.Uri = Paths.ClientPlaybackTempDirectory + InspireApp.CurrentSlideGuid + "\\" + designContentControlGuid + "\\" + Path.GetFileName(playlistFile.Uri);
                                }
                                else if(File.Exists(Paths.ClientTempDirectory + InspireApp.CurrentSlideGuid + "\\" + designContentControlGuid + "\\" + Path.GetFileName(playlistFile.Uri)))
                                {
                                    playlistFile.Uri = Paths.ClientTempDirectory + InspireApp.CurrentSlideGuid + "\\" + designContentControlGuid + "\\" + Path.GetFileName(playlistFile.Uri);
                                }
                                playlistElement.MediaElement = playlistFile;
                               // PlaylistItems.Items.Add(playlistElement);
                            }
                        }
                    }
                }

                Content = new PlaylistControl(this, (InspireApp.IsPlayer || InspireApp.IsPreviewMode));
                _hasLoaded = true;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ListBox PlaylistItems { get; set; }


        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                PlaylistControlHolderLoaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    if (Content != null)
                    {

                        if (PlaylistItems != null)
                            PlaylistItems = null;
                        ClearValue(ContentProperty);
                    }
                }));

                //var playlistControl = Content as PlaylistControl;
                //if (playlistControl != null) playlistControl = null; //.Dispose();
        }

        #endregion
    }
}
