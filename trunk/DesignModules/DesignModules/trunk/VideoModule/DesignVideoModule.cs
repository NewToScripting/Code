using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;
using Microsoft.Win32;

namespace VideoModule
{
    public class DesignVideoModule : MediaModule, IMediaModule
    {

        private delegate void PlayVideoDelegate();

        private delegate void StopVideoDelegate();

        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Images (*.wmv, *.avi, *.mpeg, *.mov) |*.wmv;*.wmv9;*.avi;*.mpeg;*.mov";
            openFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {

                var mediaElement = new DesignVideo();

                mediaElement.Source = new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute);
                mediaElement.IsHitTestVisible = false;
                mediaElement.Stretch = Stretch.Uniform;
                mediaElement.IsNewFile = true;

                mediaElement.LoadedBehavior = MediaState.Manual;

                StopVideoDelegate stopVideoDelegate = mediaElement.StopVideo;

                stopVideoDelegate.BeginInvoke(null, null);


                DesignContentControl contentControl = new DesignContentControl();

                contentControl.Tag = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                contentControl.Content = mediaElement;

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
            return "Video";
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
            return new List<string> { ".wmv", ".mp4", ".3g2", ".3gp", ".m4v", ".m2v", ".flv", ".mpg", ".avi", ".asx" };
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


            contentControl.VerticalAlignment = VerticalAlignment.Top;
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
            DesignVideo newVideo = new DesignVideo();

            if (designVideo != null)
            {
                string oldSource = designVideo.Source.ToString();
                bool wasNew = designVideo.IsNewFile;

                string tempPath = Paths.ClientTempDirectory + designContentControl.GUID +
                                      Path.GetExtension(designVideo.Source.ToString());
                if (wasNew)
                {
                    if (File.Exists(new Uri(oldSource).LocalPath))
                        Files.Copy(new Uri(oldSource).LocalPath, tempPath);
                }
                else
                {
                    string filePath = Path.GetFileName(oldSource);
                    Files.Move(new Uri(Paths.ClientTempDirectory + "/" + guid + "/" + filePath).LocalPath, tempPath);
                }

                string newSource = designContentControl.GUID +
                                   Path.GetExtension(designVideo.Source.ToString());


                newVideo.Source = new Uri(newSource, UriKind.RelativeOrAbsolute);
                newVideo.IsHitTestVisible = false;
                newVideo.IsNewFile = false;
                newVideo.Stretch = designVideo.Stretch;
                //if (designVideo.Extension == null)
                //    newImage.Extension = Path.GetExtension(image.Source.ToString());
                //else
                //    newImage.Extension = image.Extension;
                designContentControl.Content = newVideo;
                designContentControl.IsNew = false;

                stringControl = XamlWriter.Save(designContentControl);

                if (wasNew)
                {
                    designVideo.Source = new Uri(oldSource, UriKind.RelativeOrAbsolute);
                }
                else
                {
                    designVideo.Source = new Uri(tempPath, UriKind.RelativeOrAbsolute);
                }

                StopVideoDelegate stopVideoDelegate = designVideo.StopVideo;

                stopVideoDelegate.BeginInvoke(null, null);

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

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            DesignVideo designVideo = (DesignVideo)designContentControl.Content;
            StopVideoDelegate stopVideoDelegate = designVideo.StopVideo;

            stopVideoDelegate.BeginInvoke(null, null);
            designContentControl.Content = designVideo;
            return designContentControl;
        }

        #region IMediaModule Members


        public void PlayControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            DesignVideo designVideo = (DesignVideo)designContentControl.Content;

            designVideo.LoadedBehavior = MediaState.Manual;

            designVideo.PlayVideo();
           // designContentControl.Content = designVideo;
        }

        public void StopControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            DesignVideo designVideo = (DesignVideo)designContentControl.Content;
            designVideo.LoadedBehavior = MediaState.Manual;

            designVideo.Position = TimeSpan.FromSeconds(3);

            designVideo.Volume = 0;

            StopVideoDelegate stopVideoDelegate = designVideo.StopVideo;

            stopVideoDelegate.BeginInvoke(null, null);

            //designContentControl.Content = designVideo;
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
