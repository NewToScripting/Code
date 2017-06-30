using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Markup;
using Inspire;
using Inspire.Common.MediaObjects;
using Inspire.Interfaces;
using Inspire.MediaObjects;
using Microsoft.Win32;

namespace FlashModule
{
    public class DesignFlashModule : MediaModule, IMediaModule
    {
        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Flash (*.swf) |*.swf";
            openFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {

                var designFlash = new DesignFlash(new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute));

                designFlash.IsNewFile = true;

                DesignContentControl contentControl = new DesignContentControl();

                contentControl.Tag = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                contentControl.Content = designFlash;

                return contentControl;
            }
            return null;
        }

        public DesignContentControl EditControl(DesignContentControl designContentControl)
        {
            throw new NotImplementedException();
        }

        public MediaType GetModuleType()
        {
            return MediaType.Flash;
        }

        public string GetModuleName()
        {
            return "Flash";
        }

        public List<string> GetSupportedFileTypes()
        {
            return new List<string> { ".swf", ".flv"};
        }

        public DesignContentControl CreateContentControl(string fileName)
        {
            DesignContentControl contentControl = new DesignContentControl();

            // Open a Uri and decode a JPG image
            Uri uri = new Uri(fileName, UriKind.RelativeOrAbsolute);

            var designFlash = new DesignFlash(uri);

            designFlash.IsNewFile = true;

            contentControl.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            contentControl.Height = 200;
            contentControl.GUID = Guid.NewGuid().ToString();
            contentControl.Width = 200;
            contentControl.Tag = Path.GetFileNameWithoutExtension(fileName);
            contentControl.Type = MediaType.Flash;

            contentControl.Content = designFlash;

            return contentControl;
        }

        public string CreatePlayerControl(DesignContentControl designContentControl, string guid)
        {
            string stringControl = "";
            DesignFlash designFlash = designContentControl.Content as DesignFlash;

            if (designFlash != null)
            {
                string oldSource = designFlash.Url.ToString();

                DesignerImage designerImage = designFlash.Content as DesignerImage;

                bool wasNew = designFlash.IsNewFile;
                if (designFlash.IsNewFile)
                {
                    string tempPath = Paths.ClientTempDirectory + designContentControl.GUID +
                                      Path.GetExtension(oldSource);
                    if (File.Exists(new Uri(oldSource).LocalPath))
                    {
                        Files.Copy(new Uri(oldSource).LocalPath, tempPath);
                        string newSource = designContentControl.GUID +
                                           Path.GetExtension(designFlash.Url.ToString());
                        designFlash.Url = new Uri(newSource, UriKind.RelativeOrAbsolute);
                        designFlash.IsNewFile = false;
                        designFlash.Content = null;
                        designContentControl.Content = designFlash;
                        designContentControl.IsNew = false;
                    }
                    else
                    {
                        return null;
                    }
                }
                stringControl = XamlWriter.Save(designContentControl);
                if (wasNew)
                    designFlash.Url = new Uri(oldSource, UriKind.RelativeOrAbsolute);
                else
                {
                    designFlash.Url = new Uri(Paths.ClientTempDirectory + designContentControl.GUID + oldSource, UriKind.RelativeOrAbsolute);
                }

                designFlash.Content = designerImage;
            }
            return stringControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            //DesignFlash designFlash = (DesignFlash)designContentControl.Content;
            //var webBrowser = (System.Windows.Forms.WebBrowser)designFlash.ContentControl;
            //webBrowser.Navigate(
            //    new Uri(Paths.ClientTempDirectory + designContentControl.SlideID + @"/" + designFlash.Url,
            //            UriKind.Absolute));
            return designContentControl;
        }

        #region IMediaModule Members


        public void PlayControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            DesignFlash designFlash = (DesignFlash)designContentControl.Content;
            designFlash.Play(designContentControl, _playbackFolder);
            //var webBrowser = (System.Windows.Forms.WebBrowser)designFlash.ContentControl;
            //if (!designFlash.IsNewFile)
            //    webBrowser.Navigate(
            //        new Uri(_playbackFolder + designContentControl.SlideID + @"/" + designFlash.Url,
            //                UriKind.Absolute));
            //else
            //    webBrowser.Navigate(designFlash.Url);
        }

        public void StopControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            DesignFlash designFlash = (DesignFlash)designContentControl.Content;
            designFlash.Stop(designContentControl.Tag.ToString());
            //var webBrowser = (System.Windows.Forms.WebBrowser)designFlash.ContentControl;
            //if (!designFlash.IsNewFile)
            //    webBrowser.Navigate(
            //        new Uri(_playbackFolder + designContentControl.SlideID + @"/" + designFlash.Url,
            //                UriKind.Absolute));
            //else
            //    webBrowser.Navigate(designFlash.Url);
        }

        public void Dispose(DesignContentControl designContentControl)
        {
            DesignFlash designFlash = (DesignFlash)designContentControl.Content;
            designFlash.Dispose();
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
