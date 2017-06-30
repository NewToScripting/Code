using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Markup;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace PlaylistModule
{
    public class DesignPlaylistModule : MediaModule, IMediaModule
    {
        private static PropertyPanel _propertyPanel;

        #region IMediaModule Members

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            //PlaylistControlHolder playlistControlHolder = designContentControl.Content as PlaylistControlHolder;

            //designContentControl.Content = playlistControlHolder;

            return designContentControl;
        }

        public DesignContentControl CreateContentControl(string mediaFilePath)
        {
            return null;
        }

        public string CreatePlayerControl(DesignContentControl designContentControl, string guid)
        {
            try
            {
                string stringControl = "";
                List<string> oldSources = new List<string>();
                PlaylistControlHolder playlistControlHolder = designContentControl.Content as PlaylistControlHolder;

                if (playlistControlHolder != null)
                {
                    if (!InspireApp.IsCopying)
                        foreach (PlaylistElement playlistElement in playlistControlHolder.PlaylistItems.Items)
                        {
                            var playlistFile = playlistElement.MediaElement as PlaylistFile;
                            if (playlistFile != null)
                            {
                                string oldSource = playlistFile.Uri;

                                playlistFile.Uri = designContentControl.GUID + "/" + playlistFile.GUID + Path.GetExtension(playlistFile.Uri);

                                string saveDir = Paths.SaveDirectory + guid + "\\" + designContentControl.GUID + "\\" +
                                                 playlistFile.GUID + Path.GetExtension(playlistFile.Uri);

                                if (!File.Exists(saveDir))
                                {
                                    var newSaveDir = Paths.SaveDirectory + guid + "\\";
                                    // Create the directory if it doesn't exist
                                    if (!Directory.Exists(newSaveDir))
                                        Directory.CreateDirectory(newSaveDir);

                                    Directory.CreateDirectory(newSaveDir + designContentControl.GUID);
                                    File.Copy(oldSource, saveDir);
                                    oldSources.Add(oldSource);
                                }
                                else
                                    oldSources.Add(saveDir);
                            }

                        }

                    var playlistControl = playlistControlHolder.Content as PlaylistControl;

                    playlistControlHolder.Content = null;

                    stringControl = XamlWriter.Save(designContentControl);

                    if (!InspireApp.IsCopying)
                        foreach (PlaylistElement playlistElement in playlistControlHolder.PlaylistItems.Items)
                        {
                            PlaylistFile playlistFile = playlistElement.MediaElement as PlaylistFile;
                            if (playlistFile != null)
                            {
                                if (File.Exists(oldSources[playlistControlHolder.PlaylistItems.Items.IndexOf(playlistElement)]))
                                    playlistFile.Uri = oldSources[playlistControlHolder.PlaylistItems.Items.IndexOf(playlistElement)];
                                else
                                {
                                    if (File.Exists(Paths.ClientTempDirectory + designContentControl.GUID + "/" + playlistFile.GUID + Path.GetExtension(playlistFile.Uri)))
                                        playlistFile.Uri = Paths.ClientTempDirectory + designContentControl.GUID + "/" + playlistFile.GUID + Path.GetExtension(playlistFile.Uri);
                                }
                            }
                        }

                    playlistControlHolder.Content = playlistControl;

                    designContentControl.Content = playlistControlHolder;

                }
                return stringControl;
            }
            catch (Exception ex)
            {
                throw new FailedToCreateModuleException("Failed to save playlist.", ex);
            }
        }

        public void Dispose(DesignContentControl designContentControl)
        {
            PlaylistControlHolder playlistControlHolder = designContentControl.Content as PlaylistControlHolder;

            if (playlistControlHolder != null)
            {
                var playlistControl = playlistControlHolder.Content as PlaylistControl;
                if (playlistControl != null) playlistControl.Dispose();
            }

            designContentControl.Content = null;
        }

        public DesignContentControl EditControl(DesignContentControl designContentControl)
        {
            var oldControl = designContentControl.Content as PlaylistControlHolder;

            ModuleDialog moduleDialog = new ModuleDialog(designContentControl);
            moduleDialog.ShowDialog();
            if (moduleDialog.DialogResult == true)
            {
                if (moduleDialog.plControl.Items != null && moduleDialog.plControl.Items.Count > 0)
                {
                    PlaylistControlHolder playlistControlHolder = new PlaylistControlHolder(moduleDialog.plControl.Items);


                    playlistControlHolder.IsHitTestVisible = false;

                    designContentControl.Content = playlistControlHolder;
                }
                if (oldControl != null)
                    oldControl.Dispose();
            }
            else
                designContentControl.Content = oldControl;

            return designContentControl;
        }

        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            ModuleDialog moduleDialog = new ModuleDialog();
            moduleDialog.ShowDialog();
            if(moduleDialog.DialogResult == true)
            {
                if (moduleDialog.plControl.Items != null && moduleDialog.plControl.Items.Count > 0)
                {
                    DesignContentControl designContentControl = new DesignContentControl();

                    PlaylistControlHolder playlistControlHolder = new PlaylistControlHolder(moduleDialog.plControl.Items);

                    //PlaylistControl playlistControl = new PlaylistControl();

                    //while (moduleDialog.plControl.Items.Count > 0)
                    //{
                    //    PlaylistElement element = moduleDialog.plControl.Items[0];
                    //    moduleDialog.plControl.Items.RemoveAt(0);
                    //    playlistControl.Add(element);
                    //}

                    //moduleDialog.plControl.Dispose();

                    playlistControlHolder.IsHitTestVisible = false;

                    designContentControl.Tag = "Playlist";

                    designContentControl.Content = playlistControlHolder;
                    designContentControl.IsEditable = true;
                    designContentControl.IsNew = false;
                    designContentControl.Width = canvasWidth*.5;
                    designContentControl.Height = canvasHeight*.5;

                    // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
                    designContentControl.IsRotatable = true;

                    return designContentControl;
                }
            }
            moduleDialog.plControl.Dispose();
            return null;
        }

        public bool GetIsPanelModule()
        {
            return true;
        }

        public string GetModuleName()
        {
            return "Playlist Control";
        }

        public MediaType GetModuleType()
        {
            return MediaType.Playlist;
        }

        public System.Windows.Controls.UserControl GetPropertyPanel()
        {
            if (_propertyPanel == null)
                _propertyPanel = new PropertyPanel();
            return _propertyPanel;
        }

        public List<string> GetSupportedFileTypes()
        {
            return null;
        }

        public void PlayControl(DesignContentControl designContentControl, string filePath, string displayGuid)
        {
            PlaylistControlHolder playlistControlHolder = designContentControl.Content as PlaylistControlHolder;
            if (playlistControlHolder != null)
            {
                PlaylistControl playlistControl = playlistControlHolder.Content as PlaylistControl;
                if (playlistControl != null) playlistControl.Play();
            }
        }

        public void StopControl(DesignContentControl designContentControl, string filePath, string displayGuid)
        {
            PlaylistControlHolder playlistControlHolder = designContentControl.Content as PlaylistControlHolder;
            if (playlistControlHolder != null)
            {
                PlaylistControl playlistControl = playlistControlHolder.Content as PlaylistControl;
                if (playlistControl != null) playlistControl.Stop();
            }
        }

        public IEnumerable<string> GetRules(DesignContentControl designContentControl)
        {
            return null;
        }

        public bool GetIsApp()
        {
            return true;
        }

        #endregion
    }
}
