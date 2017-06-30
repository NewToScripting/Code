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

namespace StreamingModule
{
    public class DesignStreamingModule : MediaModule, IMediaModule
    {
        private static PropertyPanel _propertyPanel;

        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            ModuleDialog moduleDialog = new ModuleDialog();
            moduleDialog.ShowDialog();

            if (moduleDialog.DialogResult == true)
            {

                var mediaElement = new DesignStreamingVideo();

                mediaElement.Source = new Uri(moduleDialog.StreamUrl, UriKind.RelativeOrAbsolute);
                mediaElement.IsHitTestVisible = false;
                mediaElement.Stretch = Stretch.Uniform;

                mediaElement.LoadedBehavior = MediaState.Manual;

                mediaElement.StopVideo();

                DesignContentControl contentControl = new DesignContentControl();

                contentControl.Tag = moduleDialog.StreamUrl;
                contentControl.Content = mediaElement;

                contentControl.Width = 200;
                contentControl.Height = 200;

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
            return designContentControl;
        }

        public string GetModuleName()
        {
            return "Streaming Video";
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
            return null;
        }

        public DesignContentControl CreateContentControl(string fileName)
        {
            DesignContentControl contentControl = new DesignContentControl();
            //Open a Uri and decode a JPG image
            Uri uri = new Uri(fileName, UriKind.RelativeOrAbsolute);

            DesignStreamingVideo mediaElement = new DesignStreamingVideo();
            mediaElement.Stretch = Stretch.Uniform;
            mediaElement.IsHitTestVisible = false;
            mediaElement.Source = uri;

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
            DesignStreamingVideo designVideo = designContentControl.Content as DesignStreamingVideo;
            DesignStreamingVideo newVideo = new DesignStreamingVideo();

            if (designVideo != null)
            {
                string oldSource = designVideo.Source.ToString();

                newVideo.Source = new Uri(oldSource, UriKind.RelativeOrAbsolute);
                newVideo.IsHitTestVisible = false;

                newVideo.Stretch = designVideo.Stretch;

                //if (designVideo.Extension == null)
                //    newImage.Extension = Path.GetExtension(image.Source.ToString());
                //else
                //    newImage.Extension = image.Extension;
                designContentControl.Content = newVideo;
                designContentControl.IsNew = false;

                stringControl = XamlWriter.Save(designContentControl);

                designVideo.Source = new Uri(oldSource, UriKind.RelativeOrAbsolute);

                designVideo.StopVideo();

                designContentControl.Content = designVideo;
            }
            return stringControl;

            //string stringControl = "";
            //DesignVideo mediaElement = designContentControl.Content as DesignVideo;
            //if (mediaElement != null)
            //{
            //    string oldSource = mediaElement.Source.ToString();
            //    bool wasNew = mediaElement.IsNewFile;
            //    if (mediaElement.IsNewFile)
            //    {
            //        string tempPath = Paths.ClientTempDirectory + designContentControl.GUID +
            //                          Path.GetExtension(mediaElement.Source.ToString());
            //        if (File.Exists(new Uri(oldSource).LocalPath))
            //        {
            //            Files.Copy(new Uri(oldSource).LocalPath, tempPath);

            //            string newSource = designContentControl.GUID +
            //                               Path.GetExtension(mediaElement.Source.ToString());
            //            mediaElement.Source = new Uri(newSource, UriKind.RelativeOrAbsolute);
            //            mediaElement = DesignVideo.GetPlayerVideo(mediaElement);
            //            mediaElement.IsNewFile = false;
            //            designContentControl.Content = mediaElement;
            //            designContentControl.IsNew = false;
            //        }
            //        else
            //        {
            //            return null;
            //        }
            //    }
            //    stringControl = XamlWriter.Save(designContentControl);
            //    if (wasNew)
            //    {
            //        mediaElement.Source = new Uri(oldSource, UriKind.RelativeOrAbsolute);
            //        mediaElement = DesignVideo.GetMediaImage(mediaElement);
            //        designContentControl.Content = mediaElement;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Fix this, new Guid is created throwing off the path, either copy the file when the guid is changed or keep the same guid.");
            //        mediaElement.Source = new Uri(oldSource, UriKind.Relative);
            //    }
            //}
            //return stringControl;
        }

        public DesignContentControl GetPlayerControl(DesignContentControl designContentControl)
        {
            return designContentControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            DesignStreamingVideo designVideo = (DesignStreamingVideo)designContentControl.Content;
            designVideo.StopVideo();

            designContentControl.Content = designVideo;
            return designContentControl;
        }

        #region IMediaModule Members


        public void PlayControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            DesignStreamingVideo designVideo = (DesignStreamingVideo)designContentControl.Content;

            designVideo.LoadedBehavior = MediaState.Manual;

            designVideo.PlayVideo();
            // designContentControl.Content = designVideo;
        }

        public void StopControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            DesignStreamingVideo designVideo = (DesignStreamingVideo)designContentControl.Content;

            designVideo.LoadedBehavior = MediaState.Manual;

            designVideo.StopVideo();

            //designContentControl.Content = designVideo;
        }

        public void Dispose(DesignContentControl designContentControl)
        {

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
            return null;
        }

        public bool GetIsApp()
        {
            return true;
        }

        #endregion
    }
}