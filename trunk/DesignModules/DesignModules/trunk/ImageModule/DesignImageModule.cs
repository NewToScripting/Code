using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;
using Microsoft.Win32;
using ImageConverter=Inspire.ImageConverter;

namespace ImageModule
{
    public class DesignImageModule : MediaModule, IMediaModule
    {

        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Images (*.jpg, *.png, *.gif, *.bmp, *.jpeg) |*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.ShowDialog();

            BitmapFrame bitmapFrame;
            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                bitmapFrame = BitmapFrame.Create(new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute));

                DesignImage image = new DesignImage();

                image.IsHitTestVisible = false;
                image.Source = bitmapFrame;
                image.Stretch = Stretch.Uniform;
                image.IsNewFile = true;

                DesignContentControl contentControl = new DesignContentControl();

                contentControl.Tag = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                contentControl.Content = image;

                // Mark as Copyable so that the control can be copied and pasted, through Serialization.
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
            return "Image";
        }

        public MediaType GetModuleType()
        {
            return MediaType.Image;
        }

        /// <summary>
        /// Returns a list of supported file types for the Control. Make sure that the supported file types are in lowe case and has the dot in front of it.
        /// </summary>
        /// <returns></returns>
        public List<string> GetSupportedFileTypes()
        {
            return new List<string> { ".jpg", ".png", ".gif", ".bmp" };
        }

        public DesignContentControl CreateContentControl(string fileName)
        {
            DesignContentControl contentControl = new DesignContentControl();

            // Open a Uri and decode a JPG image
            Uri uri = new Uri(fileName, UriKind.RelativeOrAbsolute);

            // Draw the DesignImage
            DesignImage image = new DesignImage();
            image.Stretch = Stretch.Uniform;
            image.IsHitTestVisible = false;

            image.Source = ImageConverter.Convert(uri);
            image.IsNewFile = true;

            contentControl.Tag = Path.GetFileNameWithoutExtension(fileName);
            contentControl.Type = MediaType.Image;

            contentControl.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            contentControl.Height = 200;
            contentControl.GUID = Guid.NewGuid().ToString();
            contentControl.Width = 200;

            // Mark as Copyable so that the control can be copied and pasted.
            contentControl.IsCopyable = true;

            // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
            contentControl.IsRotatable = true;

            contentControl.Content = image;

            return contentControl;
        }

        public string CreatePlayerControl(DesignContentControl designContentControl, string guid)
        {
            string stringControl = "";
            DesignImage image = designContentControl.Content as DesignImage;
            DesignImage newImage = new DesignImage();

            if (image != null)
            {
                string oldSource = image.Source.ToString();
                bool wasNew = image.IsNewFile;

                string tempPath = Paths.ClientTempDirectory + designContentControl.GUID +
                                      Path.GetExtension(image.Source.ToString());
                if (File.Exists(new Uri(oldSource).LocalPath))                      // TODO: Refactor the whole process for file copy on new files, this is messy
                {
                    if (wasNew)
                        Files.Copy(new Uri(oldSource).LocalPath, tempPath);
                    else
                        Files.Move(new Uri(oldSource).LocalPath, tempPath);

                    string newSource = designContentControl.GUID +
                                       Path.GetExtension(image.Source.ToString());
                    BitmapImage newBitmap = new BitmapImage(new Uri(newSource, UriKind.RelativeOrAbsolute));
                    newBitmap.CacheOption = BitmapCacheOption.OnLoad;

                    newImage.Source = newBitmap;
                    newImage.IsHitTestVisible = false;
                    newImage.IsNewFile = false;
                    newImage.Stretch = image.Stretch;
                    if (image.Extension == null)
                        newImage.Extension = Path.GetExtension(image.Source.ToString());
                    else
                        newImage.Extension = image.Extension;
                    designContentControl.Content = newImage;
                    designContentControl.IsNew = false;

                    stringControl = XamlWriter.Save(designContentControl);

                }
                if (wasNew)
                {
                    image.Source = ImageConverter.Convert(new Uri(oldSource, UriKind.RelativeOrAbsolute));
                }

                designContentControl.Content = image;
            }
            return stringControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            var designImage = (DesignImage)designContentControl.Content;
            string imageSource = Paths.ClientTempDirectory + "/" + designContentControl.SlideID + "/" +
                                 designContentControl.GUID + designImage.Extension;
            Uri uri;
            if(designImage.Source == null)
                uri = new Uri(imageSource, UriKind.RelativeOrAbsolute);
            else
                uri = new Uri(designImage.Source.ToString(), UriKind.RelativeOrAbsolute);
            designImage.Source = ImageConverter.Convert(uri);
            designContentControl.Content = designImage;
            return designContentControl;
        }

        #region IMediaModule Members


        public void PlayControl(DesignContentControl designContentControl, string _playbackPath, string _displayGuid)
        {
            var designImage = (DesignImage)designContentControl.Content;
            Uri uri = new Uri(designImage.Source.ToString(), UriKind.RelativeOrAbsolute);
            designImage.Source = null;
            designImage.Source = ImageConverter.Convert(uri);
            designContentControl.Content = designImage;
        }

        public void StopControl(DesignContentControl designContentControl, string _playbackPath, string _displayGuid)
        {

        }

        public void Dispose(DesignContentControl designContentControl)
        {
            //DesignImage designImage = (DesignImage)designContentControl.Content;
            //designImage.Source.Freeze();
            //designImage.Source = null;
            //designContentControl.Content = null;
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
