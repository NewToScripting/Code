using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml;
using HTMLConverter;
using Inspire;
using Inspire.Interfaces;
using Inspire.MediaObjects;
using Inspire.Services.WeakEventHandlers;

namespace RSSModule
{
    public partial class RSSContentControl : INotifyPropertyChanged, IWeakEventListener, IDesignContentControl, IDisposable
    {
        public ListBox RSSItems { get; set; }

        SyndicationFeed blogFeed;

        private DispatcherTimer dispatcherTimer;
        private bool firstLoad;
        private DispatcherTimer disposeTimer;

        private readonly BackgroundWorker backgroundWorker;

        private delegate void NoArgDelegate();

        public static DependencyProperty RSSTitleForegroundProperty = DependencyProperty.Register(
            "RSSTitleForeground", typeof(Brush), typeof(RSSContentControl));

        public static DependencyProperty RSSTitleFontFamilyProperty = DependencyProperty.Register(
            "RSSTitleFontFamily", typeof(FontFamily), typeof(RSSContentControl));

        public static DependencyProperty RSSTitleFontSizeProperty = DependencyProperty.Register(
            "RSSTitleFontSize", typeof(double), typeof(RSSContentControl));

        public static DependencyProperty RSSDescriptionForegroundProperty = DependencyProperty.Register(
            "RSSDescriptionForeground", typeof(Brush), typeof(RSSContentControl));

        public static DependencyProperty RSSDescriptionFontFamilyProperty = DependencyProperty.Register(
            "RSSDescriptionFontFamily", typeof(FontFamily), typeof(RSSContentControl));

        public static DependencyProperty RSSDescriptionFontSizeProperty = DependencyProperty.Register(
            "RSSDescriptionFontSize", typeof(double), typeof(RSSContentControl));

        public static DependencyProperty RSSFeedSpeedProperty = DependencyProperty.Register(
            "RSSFeedSpeed", typeof(int), typeof(RSSContentControl));


        public RSSContentControl()
        {
            InitializeComponent();

            disposeTimer = new DispatcherTimer();
            disposeTimer.Tick += new EventHandler(disposeTimer_Tick);

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);

            if (InspireApp.CurrentSlideDuration > 0)
            {
                disposeTimer.Interval = new TimeSpan(0, 0, InspireApp.CurrentSlideDuration + 5);

                if (disposeTimer.Interval > new TimeSpan(0, 0, 5))
                    disposeTimer.Start();
            }
        }

        void disposeTimer_Tick(object sender, EventArgs e)
        {
            Dispose();
        }

        public double RSSTitleFontSize
        {
            get
            {
                return (double)GetValue(RSSTitleFontSizeProperty);
            }
            set
            {
                SetValue(RSSTitleFontSizeProperty, value);
                OnPropertyChanged("RSSTitleFontSize");
            }
        }

        public int RSSFeedSpeed
        {
            get { return (int)GetValue(RSSFeedSpeedProperty); }
            set
            {
                SetValue(RSSFeedSpeedProperty, value);
                OnPropertyChanged("RSSFeedSpeed");
                SetTimerInterval();
            }
        }

        private void SetTimerInterval()
        {
            dispatcherTimer.Interval = new TimeSpan(0,0,RSSFeedSpeed);
        }

        public Brush RSSTitleForeground
        {
            get { return (Brush)GetValue(RSSTitleForegroundProperty); }
            set
            {
                SetValue(RSSTitleForegroundProperty, value);
                OnPropertyChanged("RSSTitleForeground");
            }
        }

        public FontFamily RSSTitleFontFamily
        {
            get 
            { return (FontFamily)GetValue(RSSTitleFontFamilyProperty); }
            set 
            { 
                SetValue(RSSTitleFontFamilyProperty, value);
                OnPropertyChanged("RSSTitleFontFamily");
            }

        }

        public double RSSDescriptionFontSize
        {
            get { return (double)GetValue(RSSDescriptionFontSizeProperty); }
            set
            {
                SetValue(RSSDescriptionFontSizeProperty, value);
                OnPropertyChanged("RSSDescriptionFontSize");
                if (!firstLoad)
                {
                    NoArgDelegate updateRSSTextDelegate = UpdateRSSText;
                    Dispatcher.BeginInvoke(updateRSSTextDelegate, null);
                }
            }
        }

        public Brush RSSDescriptionForeground
        {
            get { return (Brush)GetValue(RSSDescriptionForegroundProperty); }
            set
            {
                SetValue(RSSDescriptionForegroundProperty, value);
                OnPropertyChanged("RSSDescriptionForeground");
            }
        }

        public FontFamily RSSDescriptionFontFamily
        {
            get { return (FontFamily)GetValue(RSSDescriptionFontFamilyProperty); }
            set
            {
                SetValue(RSSDescriptionFontFamilyProperty, value);
                OnPropertyChanged("RSSDescriptionFontFamily");
                if (!firstLoad)
                {
                    NoArgDelegate updateRSSTextDelegate = UpdateRSSText;
                    Dispatcher.BeginInvoke(updateRSSTextDelegate, null);
                }
            }
        }

        public RSSContentControl(List<string> _rssFeeds, int _rssSpeed, TextBlock _rssTitle, TextBlock _rssDescription)
        {
            InitializeComponent();
            dispatcherTimer = new DispatcherTimer();

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);

            RSSItems = new ListBox();
            firstLoad = true;


            LoadedEventManager.AddListener(this, this);
            DispatcherTimerTickEventManager.AddListener(dispatcherTimer, this);

            foreach (var feed in _rssFeeds)
            {
                RSSItems.Items.Add(feed);
            }

            RSSFeedSpeed = _rssSpeed;

            RSSTitleFontSize = (int)_rssTitle.FontSize;
            RSSTitleFontFamily = _rssTitle.FontFamily;
            RSSTitleForeground = _rssTitle.Foreground;

            RSSDescriptionFontSize = _rssDescription.FontSize;
            RSSDescriptionFontFamily = _rssDescription.FontFamily;
            RSSDescriptionForeground = _rssDescription.Foreground;
            dispatcherTimer.Interval = new TimeSpan(0,0,_rssSpeed);

            disposeTimer = new DispatcherTimer();
            disposeTimer.Tick += new EventHandler(disposeTimer_Tick);

            if (InspireApp.CurrentSlideDuration > 0)
            {
                disposeTimer.Interval = new TimeSpan(0, 0, InspireApp.CurrentSlideDuration + 5);

                if (disposeTimer.Interval > new TimeSpan(0, 0, 5))
                    disposeTimer.Start();
            }
        }

        public RSSContentControl(RSSContentControl _rssContentControl)
        {
            InitializeComponent();
            dispatcherTimer = new DispatcherTimer();
            firstLoad = true;

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);

            LoadedEventManager.AddListener(this, this);
            DispatcherTimerTickEventManager.AddListener(dispatcherTimer, this);

            RSSItems = _rssContentControl.RSSItems;
            RSSFeedSpeed = _rssContentControl.RSSFeedSpeed;

            RSSTitleFontSize = _rssContentControl.RSSTitleFontSize;
            RSSTitleFontFamily = _rssContentControl.RSSTitleFontFamily;
            RSSTitleForeground = _rssContentControl.RSSTitleForeground;

            RSSDescriptionFontSize = _rssContentControl.RSSDescriptionFontSize;
            RSSDescriptionFontFamily = _rssContentControl.RSSDescriptionFontFamily;
            RSSDescriptionForeground = _rssContentControl.RSSDescriptionForeground;
            dispatcherTimer.Interval = new TimeSpan(0, 0, RSSFeedSpeed);

            disposeTimer = new DispatcherTimer();
            disposeTimer.Tick += new EventHandler(disposeTimer_Tick);

            if (InspireApp.CurrentSlideDuration > 0)
            {
                disposeTimer.Interval = new TimeSpan(0, 0, InspireApp.CurrentSlideDuration + 5);

                if (disposeTimer.Interval > new TimeSpan(0, 0, 5))
                    disposeTimer.Start();
            }
        }

        public void ReloadRSSFeeds()
        {
            backgroundWorker.RunWorkerAsync();
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Load();
        }

        private void Load()
        {
            foreach (var feed in RSSItems.Items)
            {
                try
                {
                    using (XmlReader reader = XmlReader.Create((String)feed))
                    {
                        blogFeed = SyndicationFeed.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    if (ex is WebException || ex is XmlException)
                    {
                        // Handle bad url, timeout or xml error here. 
                    }
                    //else
                       // throw;
                }
                NoArgDelegate updateRSS = UpdateRSSText;
                Dispatcher.BeginInvoke(updateRSS, null);
            }
           // InvalidateVisual();
        }

        private void UpdateRSSText()
        {
            RSSControl RSSItemControl = Content as RSSControl;
            if (RSSItemControl != null) RSSItemControl.Items.Clear();

            int rssCount = 0;

            if (blogFeed != null)
                foreach (SyndicationItem item in blogFeed.Items)
                {
                    string RSSTitle = "";
                    FlowDocument RSSDescription;
                    if (item.Title != null) 
                        RSSTitle = (item.Title.Text).Replace("\n", " ");

                    var flowDocument = new FlowDocument();
                    if (item.Summary != null)
                    {
                        string xaml = HtmlToXamlConverter.ConvertHtmlToXaml(item.Summary.Text, false, Convert.ToInt32(RSSDescriptionFontSize), RSSDescriptionFontFamily.ToString());

                        using (MemoryStream stream = new MemoryStream((new ASCIIEncoding()).GetBytes(xaml)))
                        {
                            try
                            {
                                TextRange text = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);
                                text.Load(stream, DataFormats.Xaml);
                            }
                            catch (Exception)
                            {
                                flowDocument = null;
                                stream.Close();
                            }
                            
                        }
                    }

                    RSSDescription = flowDocument;
                    RSSItemControl.Items.Add(new RSSItem(RSSTitle, RSSDescription));
                    rssCount++;
                }
            if(rssCount < 1)
            {
                RSSItemControl.Items.Add(new RSSItem("No News Data Available",new FlowDocument()));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }




        void RSSContentControl_Loaded(object sender, EventArgs e)
        {
            if (firstLoad)
            {
                NoArgDelegate loadDelegate = ReloadRSSFeeds;
                Dispatcher.BeginInvoke(loadDelegate,null);
                firstLoad = false;
                //if (InspireApp.IsPlayer)
                //{
                //    dispatcherTimer.Interval = new TimeSpan(0, 0, RSSFeedSpeed);
                //    dispatcherTimer.Start();
                //}
            }
        }

        private void RSSContentControl_Tick(object sender, EventArgs e)
        {
            RSSControl RSSItemControl = Content as RSSControl;
            if (RSSItemControl != null)
                if (RSSItemControl.CurrentItemIndex < RSSItemControl.ItemCount - 1)
                {
                    RSSItemControl.Next();
                    //NextFeedDelegate nextFeedDelegate = RSSItemControl.Next;
                    //Dispatcher.BeginInvoke(DispatcherPriority.Render, nextFeedDelegate);
                }
                else
                {
                    try
                    {
                        NoArgDelegate first = RSSItemControl.First;
                        Dispatcher.BeginInvoke(first,null);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                RSSContentControl_Loaded(sender, e);
                return true;
            }
            if (managerType == typeof(DispatcherTimerTickEventManager))
            {
                RSSContentControl_Tick(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        public void Play()
        {
            dispatcherTimer.Start();
        }

        public void Stop()
        {
            dispatcherTimer.Stop();
            RSSControl RSSItemControl = Content as RSSControl;
            if (RSSItemControl != null)
            {
                NoArgDelegate first = RSSItemControl.First;
                Dispatcher.BeginInvoke(first,null);
            }
        }

        #region IDesignContentControl Members

        public ContentControl Create(DesignContentControl designContentControl)
        {
            var rssContentControl = new RSSContentControl();

            return rssContentControl;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (dispatcherTimer != null)
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;
                disposeTimer.Tick -= new EventHandler(disposeTimer_Tick);
                disposeTimer.Stop();
                disposeTimer = null;
                backgroundWorker.DoWork -= backgroundWorker_DoWork;
                backgroundWorker.Dispose();
                this.myRSS.ClearValue(ContentProperty);
            }
        }

        #endregion
    }
}
