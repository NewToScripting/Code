using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Inspire;
using Inspire.MediaObjects;
using MessageBox=System.Windows.MessageBox;
using System.Windows.Threading;


namespace FlashModule
{
    public class DesignFlash : ContentControl, IDisposable
    {
        private WindowsFormsHost windowsFormsHost;
        private FlashControl flashControl;
        private DispatcherTimer disposeTimer;
        
        public DesignFlash(Uri uri)
        {
            Url = uri;
            Tag = Path.GetFileNameWithoutExtension(Url.LocalPath);
            Content = new DesignerImage(Path.GetFileNameWithoutExtension(Url.LocalPath));

            windowsFormsHost = new WindowsFormsHost();

            if (InspireApp.CurrentSlideDuration > 0 && InspireApp.IsPlayer)
            {
                disposeTimer = new DispatcherTimer();
                disposeTimer.Tick += disposeTimer_Tick;

                disposeTimer.Interval = new TimeSpan(0, 0, InspireApp.CurrentSlideDuration + 5) ;

                if (disposeTimer.Interval > new TimeSpan(0,0,5))
                    disposeTimer.Start();
            }
            //System.Windows.Data.Binding bBrowser = new System.Windows.Data.Binding("Url");
            //bBrowser.Source = browser;
            //bBrowser.Mode = BindingMode.OneWayToSource;
            //bBrowser.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //SetBinding(UrlProperty, bBrowser);
            //Url = uri;
            //browser.ScriptErrorsSuppressed = true;
            
            //ContentControl = browser;
            //IsHitTestVisible = false;
        }

        void disposeTimer_Tick(object sender, EventArgs e)
        {
            Dispose();
        }

        public DesignFlash()
        {
            IsHitTestVisible = false;
            this.windowsFormsHost = new WindowsFormsHost();
            if (InspireApp.IsPlayer)
                Resources.Clear();

            if (InspireApp.CurrentSlideDuration > 0 && InspireApp.IsPlayer)
            {
                disposeTimer = new DispatcherTimer();
                disposeTimer.Tick += disposeTimer_Tick;

                disposeTimer.Interval = new TimeSpan(0, 0, InspireApp.CurrentSlideDuration + 5);

                if (disposeTimer.Interval > new TimeSpan(0, 0, 5))
                    disposeTimer.Start();
            }
        }

        public Uri Url
        {
            get { return (Uri)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        public void Play()
        {
            try
            {
                Content = null;

                flashControl = new FlashControl(Url, ActualWidth, ActualHeight);

                if(windowsFormsHost == null)
                    windowsFormsHost = new WindowsFormsHost();

                windowsFormsHost.Child = flashControl;

                Content = windowsFormsHost;

                //Window mainApp = System.Windows.Application.Current.Windows[0];

                //mainApp.Show();

                //this.Controls.Add (axShockwaveFlash);
                //this.Show(); // Avoids InvalidActiveXStateException.
                //axShockwaveFlash.Movie = Url.ToString();

                //axShockwaveFlash.LoadMovie(0, @"C:\flash.swf");

                ////* it is important to set Size after specifying Movie property
                ////* if Size is specified before, it is ignored
                ////axShockwaveFlash.Size = new System.Drawing.Size(20, 20);
                //axShockwaveFlash.Play();

                

            }
            catch (AxHost.InvalidActiveXStateException ex)
            {
                MessageBox.Show("Invalid ActiveX State Exception", ex.Message);
            }
            catch (Exception ex)
            {
                
                throw;
            }
            
            //if (webBrowser == null)
            //    webBrowser = new WebBrowser();
            //webBrowser.Url = Url;
            //webBrowser.Navigate(Url);
            //if (!ShowScrollBars)
            //    webBrowser.ScrollBarsEnabled = false;
            //windowsFormsHost.Child = webBrowser;

            //if (RefreshInterval > 0)
            //{
            //    refreshTrigger.Interval = new TimeSpan(0, RefreshInterval, 0);
            //    refreshTrigger.Start();
            //}
            Content = windowsFormsHost;
        }

        public void Play(DesignContentControl designContentControl, string _playbackFolder)
        {
            try
            {
                if (designContentControl.Content != null)
                {
                    Uri uri = ((DesignFlash) designContentControl.Content).IsNewFile ? Url : new Uri(_playbackFolder + designContentControl.SlideID + "/" + Url, UriKind.Absolute);

                    Content = null;

                    if(ActualWidth > 0 && ActualHeight > 0)
                        flashControl = new FlashControl(uri, ActualWidth, ActualHeight);
                    else
                        flashControl = new FlashControl(uri, designContentControl.Width, designContentControl.Height);
                }

                windowsFormsHost.Child = flashControl;

                windowsFormsHost.Width = designContentControl.Width;
                windowsFormsHost.Height = designContentControl.Height;

                Content = windowsFormsHost;

            }
            catch (AxHost.InvalidActiveXStateException ex)
            {
                MessageBox.Show("Invalid ActiveX State Exception", ex.Message);
            }
            catch (Exception ex)
            {

                throw;
            }
            Content = windowsFormsHost;
        }

        public void Stop(string tag)
        {
            Dispose();
            Content = new DesignerImage(tag);

           // refreshTrigger.Stop();
        }

        public static readonly DependencyProperty UrlProperty = DependencyProperty.Register("Url", typeof(Uri), typeof(DesignFlash));


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
                                       typeof(DesignFlash),
                                       new FrameworkPropertyMetadata(false));

        #endregion

        #region IDisposable Members

        public void Dispose()
        {

            if (flashControl != null)
            {
                if (InspireApp.IsPlayer)
                {
                    disposeTimer.Tick -= disposeTimer_Tick;
                    disposeTimer.Stop();
                    disposeTimer = null;
                }
                
                ClearValue(ContentProperty);
                Content = null;
                flashControl.Dispose();
                flashControl = null;
                windowsFormsHost.Child = null;
                if(InspireApp.IsPlayer)
                    windowsFormsHost.Dispose();
            }

        }

        #endregion

    }
}
