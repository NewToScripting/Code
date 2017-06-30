using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Inspire.Services.WeakEventHandlers;
using System.Windows.Media;

namespace ImageModule
{
    public class DesignImage : Image , IWeakEventListener, IDisposable
    {
        //~DesignImage()
        //{
        //    //Loaded -= DesignImage_Loaded;
        //}

        public DesignImage()
        {
            LoadedEventManager.AddListener(this, this);

            
        }

        void DesignImage_Loaded(object sender, EventArgs e)
        {
            if (Source != null)
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(Source.ToString());
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                if (image.CanFreeze)
                    image.Freeze();
                Source = image;
                if (Source.CanFreeze)
                    Source.Freeze();

                //// Set the bitmap scaling mode for the image to render faster.
                //RenderOptions.SetBitmapScalingMode(this, BitmapScalingMode.LowQuality);
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
                                       typeof(DesignImage),
                                       new FrameworkPropertyMetadata(false));

        #endregion

        public string Extension
        {
            get
            {
                return (string)GetValue(ExtensionProperty);
            }
            set
            {
                SetValue(ExtensionProperty, value);
            }
        }

        public static readonly DependencyProperty ExtensionProperty =
          DependencyProperty.Register("Extension",
                                       typeof(string),
                                       typeof(DesignImage));

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                DesignImage_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        public void Dispose()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => ClearValue(SourceProperty)));
        }
    }
}
