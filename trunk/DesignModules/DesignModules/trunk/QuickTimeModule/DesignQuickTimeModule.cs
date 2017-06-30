using System;
using System.Collections.Generic;
using System.IO;
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

                DesignVideo newMediaElement = DesignVideo.GetMediaImage(mediaElement);

                DesignContentControl contentControl = new DesignContentControl();

                contentControl.Tag = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                contentControl.Content = newMediaElement;

                // Mark as Copyable so that the control can be copied and pasted.
                contentControl.IsCopyable = true;

                // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
                contentControl.IsRotatable = true;

                return contentControl;
            }
            return null;
        }

        public DesignContentControl EditControl(DesignContentControl designContentControl)
        {
            throw new NotImplementedException();
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
            return new List<string> { ".mov", ".qt" };
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

            DesignVideo newMediaElement = DesignVideo.GetMediaImage(mediaElement);

            contentControl.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            contentControl.Height = 200;
            contentControl.GUID = Guid.NewGuid().ToString();
            contentControl.Width = 200;

            contentControl.Tag = Path.GetFileNameWithoutExtension(fileName);
            contentControl.Type = MediaType.Video;

            contentControl.Content = newMediaElement;
            contentControl.IsNew = false;

            // Mark as Copyable so that the control can be copied and pasted.
            contentControl.IsCopyable = true;

            // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
            contentControl.IsRotatable = true;



            return contentControl;
        }

        public string CreatePlayerControl(DesignContentControl designContentControl, string guid)
        {
            string stringControl = "";
            DesignVideo mediaElement = designContentControl.Content as DesignVideo;
            if (mediaElement != null)
            {
                string oldSource = mediaElement.Source.ToString();
                bool wasNew = mediaElement.IsNewFile;
                if (mediaElement.IsNewFile)
                {
                    string tempPath = Paths.ClientTempDirectory + designContentControl.GUID +
                                      Path.GetExtension(mediaElement.Source.ToString());
                    if (File.Exists(new Uri(oldSource).LocalPath))
                    {
                        Files.Copy(new Uri(oldSource).LocalPath, tempPath);

                        string newSource = designContentControl.GUID +
                                           Path.GetExtension(mediaElement.Source.ToString());
                        mediaElement.Source = new Uri(newSource, UriKind.RelativeOrAbsolute);
                        mediaElement = DesignVideo.GetPlayerVideo(mediaElement);
                        mediaElement.IsNewFile = false;
                        designContentControl.Content = mediaElement;
                    }
                    else
                    {
                        return null;
                    }
                }
                stringControl = XamlWriter.Save(designContentControl);
                if (wasNew)
                {
                    mediaElement.Source = new Uri(oldSource, UriKind.RelativeOrAbsolute);
                    mediaElement = DesignVideo.GetMediaImage(mediaElement);
                    designContentControl.Content = mediaElement;
                }
                else
                {
                    mediaElement.Source = new Uri(Paths.ClientTempDirectory + designContentControl.GUID + oldSource, UriKind.RelativeOrAbsolute);
                }
            }
            return stringControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            DesignVideo designVideo = (DesignVideo)designContentControl.Content;
            designVideo = DesignVideo.GetMediaImage(designVideo);
            designContentControl.Content = designVideo;
            return designContentControl;
        }

        #region IMediaModule Members


        public void PlayControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            DesignVideo designVideo = (DesignVideo)designContentControl.Content;
            designVideo = DesignVideo.GetPlayerVideo(designVideo);
            designContentControl.Content = designVideo;
        }

        public void StopControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            DesignVideo designVideo = (DesignVideo)designContentControl.Content;
            designVideo = DesignVideo.GetMediaImage(designVideo);
            designContentControl.Content = designVideo;
        }

        public void Dispose(DesignContentControl designContentControl)
        {

        }

        public UserControl GetPropertyPanel()
        {
            return new PropertyPanel();
        }

        #endregion

        #region IMediaModule Members


        public bool GetIsPanelModule()
        {
            return true;
        }

        #endregion
    }
}