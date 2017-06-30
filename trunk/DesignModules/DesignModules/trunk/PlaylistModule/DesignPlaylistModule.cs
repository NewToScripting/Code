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

        #region IMediaModule Members

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            PlaylistControl playlistControl = designContentControl.Content as PlaylistControl;
            PlaylistControl newPlaylistControl = new PlaylistControl {IsHitTestVisible = false};

            if (playlistControl != null)
            {
                foreach (PlaylistElement playlistElement in playlistControl.Items)
                {
                    PlaylistFile playlistFile = playlistElement.MediaElement as PlaylistFile;
                    if (playlistFile != null)
                    {
                        if (File.Exists(Paths.ClientTempDirectory + designContentControl.SlideID + "\\" + designContentControl.GUID + "\\" + Path.GetFileName(playlistFile.Uri)))
                        {
                            playlistFile.Uri = Paths.ClientTempDirectory + designContentControl.SlideID + "\\" + designContentControl.GUID + "\\" + Path.GetFileName(playlistFile.Uri);
                            newPlaylistControl.Items.Add(playlistElement);
                        }
                    }
                }
            }

            designContentControl.Content = newPlaylistControl;

            return designContentControl;
        }

        public DesignContentControl CreateContentControl(string mediaFilePath)
        {
            return null;
        }

        public string CreatePlayerControl(DesignContentControl designContentControl, string guid)
        {
            string stringControl = "";
            PlaylistControl playlistControl = designContentControl.Content as PlaylistControl;

            if (playlistControl != null)
            {
                foreach (PlaylistElement playlistElement in playlistControl.Items)
                {
                    PlaylistFile playlistFile = playlistElement.MediaElement as PlaylistFile;
                    if (playlistFile != null) 
                    {
                        string oldSource = playlistFile.Uri;
                        playlistFile.Uri = designContentControl.GUID + "/" + playlistFile.GUID + Path.GetExtension(playlistFile.Uri);
                        
                        if (!File.Exists(Paths.ClientTempDirectory + designContentControl.GUID + "\\" + playlistFile.GUID + Path.GetExtension(playlistFile.Uri)))
                        {
                            Directory.CreateDirectory(Paths.ClientTempDirectory + designContentControl.GUID);
                            File.Copy(oldSource, Paths.ClientTempDirectory + designContentControl.GUID + "\\" + playlistFile.GUID + Path.GetExtension(playlistFile.Uri));
                            
                        }
                    }

                }

                designContentControl.Content = playlistControl;

                stringControl = XamlWriter.Save(designContentControl);

                foreach (PlaylistElement playlistElement in playlistControl.Items)
                {
                    PlaylistFile playlistFile = playlistElement.MediaElement as PlaylistFile;
                    if (playlistFile != null)
                    {
                       // string oldSource = playlistFile.Uri;
                        playlistFile.Uri = Paths.ClientTempDirectory + designContentControl.GUID + "/" + playlistFile.GUID + Path.GetExtension(playlistFile.Uri);
                    }

                }

                designContentControl.Content = playlistControl;

                //string oldSource = image.Source.ToString();
                //bool wasNew = image.IsNewFile;

                //string tempPath = Paths.ClientTempDirectory + designContentControl.GUID +
                //                      Path.GetExtension(image.Source.ToString());
                //if (File.Exists(new Uri(oldSource).LocalPath))
                //{
                //    if (wasNew)
                //        Files.Copy(new Uri(oldSource).LocalPath, tempPath);
                //    else
                //        Files.Move(new Uri(oldSource).LocalPath, tempPath);

                //    string newSource = designContentControl.GUID +
                //                       Path.GetExtension(image.Source.ToString());
                //    BitmapImage newBitmap = new BitmapImage(new Uri(newSource, UriKind.RelativeOrAbsolute));
                //    newBitmap.CacheOption = BitmapCacheOption.OnLoad;

                //    newImage.Source = newBitmap;
                //    newImage.IsHitTestVisible = false;
                //    newImage.IsNewFile = false;
                //    newImage.Stretch = image.Stretch;
                //    if (image.Extension == null)
                //        newImage.Extension = Path.GetExtension(image.Source.ToString());
                //    else
                //        newImage.Extension = image.Extension;
                //    designContentControl.Content = newImage;
                //    designContentControl.IsNew = false;

                  //  stringControl = XamlWriter.Save(designContentControl);

                //}
                //if (wasNew)
                //{
                //    image.Source = ImageConverter.Convert(new Uri(oldSource, UriKind.RelativeOrAbsolute));
                //}

                //designContentControl.Content = image;
            }
            return stringControl;
        }

        public void Dispose(DesignContentControl designContentControl)
        {
            PlaylistControl playlistControl = designContentControl.Content as PlaylistControl;

            if (playlistControl != null) playlistControl.Dispose();

            designContentControl.Content = null;
        }

        public DesignContentControl EditControl(DesignContentControl designContentControl)
        {
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

                    PlaylistControl playlistControl = new PlaylistControl();

                    while (moduleDialog.plControl.Items.Count > 0)
                    {
                        PlaylistElement element = moduleDialog.plControl.Items[0];
                        moduleDialog.plControl.Items.RemoveAt(0);
                        playlistControl.Add(element);
                    }

                    moduleDialog.plControl.Dispose();

                    playlistControl.IsHitTestVisible = false;

                    designContentControl.Tag = "Playlist";

                    designContentControl.Content = playlistControl;
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
            return new PropertyPanel();
        }

        public List<string> GetSupportedFileTypes()
        {
            return null;
        }

        public void PlayControl(DesignContentControl designContentControl, string filePath, string displayGuid)
        {
            PlaylistControl playlistControl = designContentControl.Content as PlaylistControl;
            if (playlistControl != null) playlistControl.Play();
        }

        public void StopControl(DesignContentControl designContentControl, string filePath, string displayGuid)
        {
            PlaylistControl playlistControl = designContentControl.Content as PlaylistControl;
            if (playlistControl != null) playlistControl.Stop();
        }

        #endregion
    }
}
