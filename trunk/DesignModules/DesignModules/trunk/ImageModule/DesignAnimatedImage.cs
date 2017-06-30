using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Image=System.Windows.Controls.Image;

namespace ImageModule
{
    public class DesignAnimatedImageControl : Image
    {
        delegate void OnFrameChangedDelegate();
        private Bitmap _Bitmap;

        public DesignAnimatedImageControl()
        {

        }

        public DesignAnimatedImageControl(string path)
        {
            _Bitmap = (Bitmap)Bitmap.FromFile(path);
            ImageAnimator.Animate(_Bitmap, OnFrameChanged);
        }


        private void OnFrameChanged(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                new OnFrameChangedDelegate(OnFrameChangedInMainThread));
        }

        private void OnFrameChangedInMainThread()
        {
            ImageAnimator.UpdateFrames(_Bitmap);
            Source = GetBitmapSource(_Bitmap);
            InvalidateVisual();
        }

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern IntPtr DeleteObject(IntPtr hDc);

        private BitmapSource GetBitmapSource(Bitmap gdiBitmap)
        {
            IntPtr hBitmap = gdiBitmap.GetHbitmap();
            BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(hBitmap,
                                                                 IntPtr.Zero,
                                                                 Int32Rect.Empty,
                                                                 BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(hBitmap);
            return bitmapSource;
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
    }
}
