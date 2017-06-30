using System;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Forms.Integration;
using System.Windows.Threading;
using Cjc.ChromiumBrowser;
using Inspire;
using Inspire.Services.WeakEventHandlers;
//using WebBrowser=System.Windows.Forms.WebBrowser;

namespace BrowserModule
{
    public class DesignWebControl : ContentControl, IDisposable , IWeakEventListener
    {

        private Cjc.ChromiumBrowser.WebBrowser webBrowser;
        //private WindowsFormsHost windowsFormsHost;
        private DispatcherTimer refreshTrigger;
        public bool ShowScrollBars { get; set; }
        public int RefreshInterval { get; set; }

        //private delegate void SetScrollBarsDelegate();

        //System.Timers.Timer timer = new System.Timers.Timer(1000);
        //System.Timers.Timer resetScrollBars = new System.Timers.Timer(1000);

        public DesignWebControl()
        {
           // windowsFormsHost = new WindowsFormsHost();
            refreshTrigger = new DispatcherTimer();
            DispatcherTimerTickEventManager.AddListener(refreshTrigger, this);
            LoadedEventManager.AddListener(this,this);

            //LoadedEventManager.AddListener(this, this);
            //timer.Elapsed += timer_Elapsed;
            //timer.Enabled = false;
            //resetScrollBars.Enabled = false;

            //resetScrollBars.Elapsed += delegate
            //                               {
            //                                   resetScrollBars_Elapsed();
            //                               };
        }

        public DesignWebControl(string _Url , bool _ShowScrollbars, int _RefreshInterval)
        {
            Url = GetUrl(_Url);
            ShowScrollBars = _ShowScrollbars;
            RefreshInterval = _RefreshInterval;
            Content = new DesignerImage(Url.ToString());
           // windowsFormsHost = new WindowsFormsHost();
            refreshTrigger = new DispatcherTimer();
            DispatcherTimerTickEventManager.AddListener(refreshTrigger, this);
        }

        void refreshTrigger_Tick(object sender, EventArgs e)
        {
            if(webBrowser != null)
                webBrowser.Navigate(Url.ToString());
            refreshTrigger.Interval = new TimeSpan(0,RefreshInterval,0);
        }

        //public DesignWebControl(WebBrowser _webBrowser, int _topScroll, int _leftScroll)
        //{
        //    IsHitTestVisible = true;
        //    Browser = new WebBrowser();
        //    Browser.Width = _webBrowser.Width;
        //    Browser.Height = _webBrowser.Height;
        //    Browser.ScrollBarsEnabled = false;
        //    Browser.ScriptErrorsSuppressed = true;
        //    Browser.Url = _webBrowser.Url;
        //    TopScroll = _topScroll;
        //    LeftScroll = _leftScroll;
        //    //ContentControl = Browser;
        //    LoadedEventManager.AddListener(this, this);
        //    timer.Elapsed += timer_Elapsed;
        //    timer.Enabled = false;
        //    resetScrollBars.Enabled = false;

        //    resetScrollBars.Elapsed += delegate
        //    {
        //        resetScrollBars_Elapsed();
        //    };
        //}

        void DesignWebControl_Loaded(object sender, EventArgs e)
        {
            if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
            {
                Play();
            }
            else
            {
                if(Content == null)
                    Content = new DesignerImage(Url.ToString());
            }

            //Browser.DocumentCompleted += delegate
            //                                 {
            //                                     resetScrollBars.Enabled = true;
            //                                 };
        }

        public string Url
        {
            get { return (String)GetValue(UrlProperty); }
            set { 
                    SetValue(UrlProperty, value);
                   // Browser.Navigate(value);
                }
        }

        public void Play()
        {
            Content = null;
            if (webBrowser == null)
                webBrowser = new Cjc.ChromiumBrowser.WebBrowser();
            webBrowser.Source = GetUrl(Url.ToString());
            webBrowser.Navigate(Url);
            //if(!ShowScrollBars)
            //    webBrowser.ScrollBarsEnabled = false;
            //windowsFormsHost.Child = webBrowser;

            if (RefreshInterval > 0)
            {
                refreshTrigger.Interval = new TimeSpan(0, RefreshInterval, 0);
                refreshTrigger.Start();
            }
            Content = webBrowser;
        }

        public void Stop()
        {
            Dispose();
            Content = new DesignerImage(Url.ToString());
            
            refreshTrigger.Stop();
        }

        public static readonly DependencyProperty UrlProperty = DependencyProperty.Register("Url", typeof(String), typeof(DesignWebControl));

        public int TopScroll
        {
            get { return (int)GetValue(TopScrollProperty); }
            set
            {
                SetValue(TopScrollProperty, value);
            }
        }

        public static readonly DependencyProperty TopScrollProperty = DependencyProperty.Register("TopScroll", typeof(int), typeof(DesignWebControl));

        public int LeftScroll
        {
            get { return (int)GetValue(LeftScrollProperty); }
            set
            {
                SetValue(LeftScrollProperty, value);
            }
        }

        private string GetUrl(string address)
        {
            var source = address.Trim();

            return source.Contains(":") ? source : "http://" + source;
        }

        public static readonly DependencyProperty LeftScrollProperty = DependencyProperty.Register("LeftScroll", typeof(int), typeof(DesignWebControl));

        //void resetScrollBars_Elapsed()
        //{
        //    SetScrollBarsDelegate setScrollbars = SetScrollBars;
        //    Dispatcher.Invoke(DispatcherPriority.Normal, setScrollbars);
        //    resetScrollBars.Enabled = false;
        //}

        //void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    SetScrollBarsDelegate setScrollbars = SetScrollBars;
        //    Dispatcher.Invoke(DispatcherPriority.Normal, setScrollbars);
        //    timer.Enabled = false;
        //}

        //public void SetScrollBars()
        //{
        //    if (Browser.Document != null)
        //        if (Browser.Document.Window != null) Browser.Document.Window.ScrollTo(LeftScroll, TopScroll);
        //}

        #region IDisposable Members

        public void Dispose()
        {
            while(webBrowser != null)
            {
                webBrowser.Dispose();
                webBrowser = null;
            }    
        }
        #endregion

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                DesignWebControl_Loaded(sender, e);
                return true;
            }
            if(managerType == typeof(DispatcherTimerTickEventManager))
            {
                refreshTrigger_Tick(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
