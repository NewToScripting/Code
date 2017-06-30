using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;
using Microsoft.Win32;

namespace QuickTimeModule
{
    public class DesignQuickTimeModule : MediaModule, IMediaModule
    {
        private static PropertyPanel _propertyPanel;

        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "QuickTime (*.mov, *.qt) |*.mov;*.qt";
            openFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {

                var mediaElement = new DesignVideo();

                mediaElement.Source = new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute);
                mediaElement.IsHitTestVisible = false;
                mediaElement.Stretch = Stretch.Uniform;
                mediaElement.IsNewFile = true;

                mediaElement.LoadedBehavior = MediaState.Manual;

                mediaElement.StopVideo();

                DesignContentControl contentControl = new DesignContentControl();

                contentControl.Tag = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                contentControl.Content = mediaElement;

                contentControl.Width = 200;
                contentControl.Height = 200;

                // Mark as Copyable so that the control can be copied and pasted.
                contentControl.IsCopyable = true;

                contentControl.IsEditable = true;

                // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
                contentControl.IsRotatable = true;

                return contentControl;
            }
            return null;
        }

        public DesignContentControl EditControl(DesignContentControl contentControl)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "QuickTime (*.mov, *.qt) |*.mov;*.qt";
            openFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {

                var mediaElement = contentControl.Content as DesignVideo;

                if (mediaElement != null)
                {
                    mediaElement.Source = new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute);
                    mediaElement.IsHitTestVisible = false;
                    mediaElement.Stretch = Stretch.Uniform;
                    mediaElement.IsNewFile = true;

                    mediaElement.LoadedBehavior = MediaState.Manual;

                    mediaElement.StopVideo();
                }

                contentControl.Tag = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                contentControl.Content = mediaElement;

                contentControl.IsEditable = true;

                // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
                contentControl.IsRotatable = true;

                return contentControl;
            }
            return contentControl;
        }

        public string GetModuleName()
        {
            return "QuickTime";
        }

        public MediaType GetModuleType()
        {
            return MediaType.Video;
        }

        public Image GetModuleImage()
        {
            return null;
        }

        public List<string> GetSupportedFileTypes()
        {
            return new List<string> { ".mov", ".h264", ".hdmov" };
        }

        public DesignContentControl CreateContentControl(string fileName)
        {
            DesignContentControl contentControl = new DesignContentControl();
            //Open a Uri and decode a JPG image
            Uri uri = new Uri(fileName, UriKind.RelativeOrAbsolute);

            DesignVideo mediaElement = new DesignVideo();
            mediaElement.Stretch = Stretch.Uniform;
            mediaElement.IsHitTestVisible = false;
            mediaElement.Source = uri;
            mediaElement.IsNewFile = true;

            mediaElement.LoadedBehavior = MediaState.Manual;

            mediaElement.StopVideo();

            contentControl.VerticalAlignment = VerticalAlignment.Stretch;
            contentControl.Height = 200;
            contentControl.GUID = Guid.NewGuid().ToString();
            contentControl.Width = 200;

            contentControl.Tag = Path.GetFileNameWithoutExtension(fileName);
            contentControl.Type = MediaType.Video;

            // Mark as Copyable so that the control can be copied and pasted.
            contentControl.IsCopyable = true;

            // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
            contentControl.IsRotatable = true;

            contentControl.Content = mediaElement;

            return contentControl;
        }

        public string CreatePlayerControl(DesignContentControl designContentControl, string guid)
        {
            string stringControl = "";
            DesignVideo designVideo = designContentControl.Content as DesignVideo;
            DesignVideo newVideo = new DesignVideo(true);

            if (designVideo != null)
            {
                string oldSource = designVideo.Source.ToString();
                bool wasNew = designVideo.IsNewFile;

                string tempPath = Paths.ClientTempDirectory + guid + "\\" + designContentControl.GUID +
                                      Path.GetExtension(designVideo.Source.ToString());

                if (!File.Exists(tempPath))
                    tempPath = Paths.ClientTempDirectory + guid + "\\" + designVideo.Source;

                string savePath = Paths.SaveDirectory + guid + "//" + designContentControl.GUID +
                                      Path.GetExtension(designVideo.Source.ToString());

                if (!InspireApp.IsCopying)
                    if (!File.Exists(savePath))
                        try
                        {
                            // Create the directory if it doesn't exist
                            if (!Directory.Exists(Paths.SaveDirectory + guid))
                                Directory.CreateDirectory(Paths.SaveDirectory + guid);

                            var u = new Uri(oldSource);

                            if (u.LocalPath != null)
                                if (File.Exists(u.LocalPath))
                                    Files.Copy(u.LocalPath, savePath);
                        }
                        catch (UriFormatException)
                        {

                            if (File.Exists(tempPath))
                                Files.Copy(tempPath, savePath);
                            else
                            {
                                string copyPath = Paths.ClientTempDirectory + guid + "//" + designContentControl.GUID +
                                          Path.GetExtension(designVideo.Source.ToString());

                                if (File.Exists(copyPath))
                                {
                                    Files.Copy(copyPath, savePath);
                                    tempPath = copyPath;
                                }
                            }
                        }

                string newSource = designContentControl.GUID +
                                   Path.GetExtension(designVideo.Source.ToString());


                newVideo.Source = new Uri(newSource, UriKind.RelativeOrAbsolute);
                newVideo.IsHitTestVisible = false;
                newVideo.IsNewFile = false;
                newVideo.Stretch = designVideo.Stretch;
                newVideo.AdvanceOnEnd = designVideo.AdvanceOnEnd;
                newVideo.ReplayOnEnd = designVideo.ReplayOnEnd;
                newVideo.Volume = designVideo.Volume;

                if (InspireApp.IsCopying)
                {
                    if (!File.Exists(tempPath))
                        Files.Copy(new Uri(oldSource).LocalPath, tempPath);

                    newVideo.Source = new Uri(tempPath, UriKind.RelativeOrAbsolute);
                    newVideo.IsNewFile = true;
                }

                designContentControl.Content = newVideo;
                designContentControl.IsNew = false;

                stringControl = XamlWriter.Save(designContentControl);

                if (wasNew)
                {
                    designVideo.Source = new Uri(oldSource, UriKind.RelativeOrAbsolute);
                }
                else
                {
                    if (File.Exists(tempPath))
                        designVideo.Source = new Uri(tempPath, UriKind.RelativeOrAbsolute);
                    else
                    {
                        if (File.Exists(oldSource))
                            designVideo.Source = new Uri(oldSource, UriKind.RelativeOrAbsolute);
                        else
                        {
                            var u = new Uri(oldSource);

                            if (u.LocalPath != null)
                                if (File.Exists(u.LocalPath))
                                    designVideo.Source = u;
                        }
                    }
                }

                designVideo.StopVideo();

                designContentControl.Content = designVideo;
            }
            return stringControl;
        }

        public DesignContentControl GetPlayerControl(DesignContentControl designContentControl)
        {
            return designContentControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            DesignVideo designVideo = (DesignVideo)designContentControl.Content;
            designVideo.StopVideo();

            designContentControl.Content = designVideo;
            return designContentControl;
        }

        #region IMediaModule Members


        public void PlayControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            DesignVideo designVideo = (DesignVideo)designContentControl.Content;

            designVideo.LoadedBehavior = MediaState.Manual;

            designVideo.PlayVideo();
        }

        public void StopControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            DesignVideo designVideo = (DesignVideo)designContentControl.Content;

            designVideo.LoadedBehavior = MediaState.Manual;

            designVideo.StopVideo();
        }

        public void Dispose(DesignContentControl designContentControl)
        {
            DesignVideo designVideo = (DesignVideo)designContentControl.Content;
            designVideo.Dispose();
        }

        public UserControl GetPropertyPanel()
        {
            if (_propertyPanel == null)
                _propertyPanel = new PropertyPanel();
            return _propertyPanel;
        }

        public bool GetIsPanelModule()
        {
            return true;
        }

        public IEnumerable<string> GetRules(DesignContentControl designContentControl)
        {
            DesignVideo designVideo = (DesignVideo)designContentControl.Content;
            return designVideo.AdvanceOnEnd ? new List<string>() { designContentControl.Tag + ": The slide is advanced when this video ends. Video Duration: " + designVideo.NaturalDuration } : null;
        }

        public bool GetIsApp()
        {
            return false;
        }

        #endregion
    }
}