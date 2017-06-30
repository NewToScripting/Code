using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
using Inspire.Services.WeakEventHandlers;
using System.Threading;

namespace RSSModule
{
    public partial class RSSContentControl : INotifyPropertyChanged, IWeakEventListener, IDisposable, IRSSControl
    {
        public ListBox RSSItems { get; set; }

        SyndicationFeed BlogFeed;

        private DispatcherTimer RSSItemTimer;
        private bool firstLoad;

        private bool playback;
        //private DispatcherTimer disposeTimer;

        private readonly BackgroundWorker backgroundWorker;

        //private delegate void NoArgDelegate();

        ~RSSContentControl()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                                                                             {
                                                                                 try
                                                                                 {
                                                                                     if (((Grid)Content).Children[0] is LoadingControl)
                                                                                         ((LoadingControl)((Grid)Content).Children[0]).Dispose();

                                                                                     if (InspireApp.IsPlayer ||
                                                                                         InspireApp.IsPreviewMode)
                                                                                     {
                                                                                         Dispose();
                                                                                     }
                                                                                 }
                                                                                 catch
                                                                                 {

                                                                                 }
                                                                                 
                                                                             }));
            //MessageBox.Show("RSS Gone");
        }

        public RSSContentControl(RSSControlHolder rssControlHolder, bool play)
        {
            InitializeComponent();
            RSSItemTimer = new DispatcherTimer();
            firstLoad = true;

            backgroundWorker = new BackgroundWorker();
            
            backgroundWorker.DoWork += backgroundWorker_DoWork;

            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;

            //Loaded +=new RoutedEventHandler(RSSContentControl_Loaded);
            //RSSItemTimer.Tick +=new EventHandler(RSSContentControl_Tick);
            LoadedEventManager.AddListener(this, this);
            DispatcherTimerTickEventManager.AddListener(RSSItemTimer, this);

            RSSItems = rssControlHolder.RSSItems;
            RSSFeedSpeed = rssControlHolder.RSSHolderFeedSpeed;

            RSSTitleFontSize = rssControlHolder.RSSHolderTitleFontSize;
            RSSTitleFontFamily = rssControlHolder.RSSHolderTitleFontFamily;
            RSSTitleForeground = rssControlHolder.RSSHolderTitleForeground;

            RSSDescriptionFontSize = rssControlHolder.RSSHolderDescriptionFontSize;
            RSSDescriptionFontFamily = rssControlHolder.RSSHolderDescriptionFontFamily;
            RSSDescriptionForeground = rssControlHolder.RSSHolderDescriptionForeground;
            RSSItemTimer.Interval = new TimeSpan(0, 0, RSSFeedSpeed);

            //UnLoadedEventManager.AddListener(this,this);

          //  disposeTimer = new DispatcherTimer();
          //  disposeTimer.Tick += delegate { Dispose(); };

            //if (InspireApp.CurrentSlideDuration > 0)
            //{
            //    disposeTimer.Interval = new TimeSpan(0, 0, InspireApp.CurrentSlideDuration + 5);

            //    if (disposeTimer.Interval > new TimeSpan(0, 0, 5))
            //        disposeTimer.Start();
            //}

            playback = play;
        }

        public RSSContentControl(RSSContentControl rssContentControl)
        {
            InitializeComponent();
            RSSItemTimer = new DispatcherTimer();
            firstLoad = true;

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += backgroundWorker_DoWork;

            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);

            LoadedEventManager.AddListener(this, this);
            DispatcherTimerTickEventManager.AddListener(RSSItemTimer, this);
            //UnLoadedEventManager.AddListener(this, this);


            RSSItems = rssContentControl.RSSItems;
            RSSFeedSpeed = rssContentControl.RSSFeedSpeed;

            RSSTitleFontSize = rssContentControl.RSSTitleFontSize;
            RSSTitleFontFamily = rssContentControl.RSSTitleFontFamily;
            RSSTitleForeground = rssContentControl.RSSTitleForeground;

            RSSDescriptionFontSize = rssContentControl.RSSDescriptionFontSize;
            RSSDescriptionFontFamily = rssContentControl.RSSDescriptionFontFamily;
            RSSDescriptionForeground = rssContentControl.RSSDescriptionForeground;
            RSSItemTimer.Interval = new TimeSpan(0, 0, RSSFeedSpeed);

            if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
                playback = true;

            //disposeTimer = new DispatcherTimer();
            //disposeTimer.Tick += delegate { Dispose(); };

            //if (InspireApp.CurrentSlideDuration > 0)
            //{
            //    disposeTimer.Interval = new TimeSpan(0, 0, InspireApp.CurrentSlideDuration + 5);

            //    if (disposeTimer.Interval > new TimeSpan(0, 0, 5))
            //        disposeTimer.Start();
            //}
        }

        //void RSSContentControl_Unloaded(object sender, EventArgs e)
        //{
        //    if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
        //    {
        //        //RSSItems.Items.Clear();
        //        //RSSItemTimer.Stop();
        //        //BlogFeed = null;
        //        //ClearValue(ContentProperty);
        //        //_rssItems = null;
        //        //LoadedEventManager.RemoveListener(this, this);
        //        //DispatcherTimerTickEventManager.RemoveListener(RSSItemTimer, this);
        //        //UnLoadedEventManager.RemoveListener(this, this);
        //        //backgroundWorker.DoWork -= backgroundWorker_DoWork;

        //        //backgroundWorker.RunWorkerCompleted -= backgroundWorker_RunWorkerCompleted;
        //        //backgroundWorker = null;
        //    }
        //}

#region Dependency Properties

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

#endregion

#region Public Properties

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
                if (!firstLoad)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(UpdateRSSText));
                }
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

        public Brush RSSTitleForeground
        {
            get { return (Brush)GetValue(RSSTitleForegroundProperty); }
            set
            {
                SetValue(RSSTitleForegroundProperty, value);
                OnPropertyChanged("RSSTitleForeground");
                if (!firstLoad)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(UpdateRSSText));
                }
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
                if (!firstLoad)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(UpdateRSSText));
                }
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
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(UpdateRSSText));
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
                if (!firstLoad)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(UpdateRSSText));
                }
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
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(UpdateRSSText));
                }
            }
        }

        #endregion

        

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(UpdateRSSText));
            //Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate { backgroundWorker.DoWork -= backgroundWorker_DoWork;
            //backgroundWorker.Dispose();
            //}));
        }

        private void SetTimerInterval()
        {
            RSSItemTimer.Interval = new TimeSpan(0, 0, RSSFeedSpeed);
        }

        internal void ReloadRSSFeeds()
        {
            backgroundWorker.RunWorkerAsync();
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);
            foreach (var feed in RSSItems.Items)
            {
                try
                {
                    using (XmlReader reader = XmlReader.Create((String)feed))
                    {
                        BlogFeed = SyndicationFeed.Load(reader);
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    if (ex is WebException || ex is XmlException)
                    {
                        // Handle bad url, timeout or xml error here.
                        if(!InspireApp.IsPlayer && !InspireApp.IsPreviewMode)
                            MessageBox.Show("Cannot process RSS link.");
                        //else
                        // throw;
                    }
                }
            }
        }

        //private void Load()
        //{
        //    foreach (var feed in RSSItems.Items)
        //    {
        //        try
        //        {
        //            using (XmlReader reader = XmlReader.Create((String)feed))
        //            {
        //                BlogFeed = SyndicationFeed.Load(reader);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            if (ex is WebException || ex is XmlException)
        //            {
        //                // Handle bad url, timeout or xml error here. 
        //            }
        //            //else
        //               // throw;
        //        }
        //        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(UpdateRSSText));
        //    }
        //}

        private void UpdateRSSText()
        {
            var rssItems = FindName("RSSContainerPART") as RSSControl;
            if (rssItems != null) rssItems.Items.Clear();

            int rssCount = 0;

            if (BlogFeed != null)
            {
                foreach (SyndicationItem item in BlogFeed.Items.Take(20))
                {
                    string RSSTitle = "";
                    var RSSDescription = new FlowDocument();
                    if (item.Title != null)
                        RSSTitle = (item.Title.Text).Replace("\n", "");

                    var flowDocument = new FlowDocument();
                    if (item.Summary != null)
                    {
                        try
                        {
                            string xaml = HtmlToXamlConverter.ConvertHtmlToXaml(item.Summary.Text, false,
                                                                                Convert.ToInt32(RSSDescriptionFontSize),
                                                                                RSSDescriptionFontFamily.ToString());

                            using (MemoryStream stream = new MemoryStream((new ASCIIEncoding()).GetBytes(xaml)))
                            {
                                try
                                {
                                    TextRange text = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);
                                    text.Load(stream, DataFormats.Xaml);
                                    //string test = text.Text;
                                }
                                catch (Exception)
                                {
                                    flowDocument = null;

                                }
                                finally
                                {
                                    stream.Dispose();
                                }
                            }
                        }
                        catch (Exception)
                        {
                            flowDocument = null;
                        }

                    }
                    if (flowDocument != null)
                    {
                        flowDocument.TextAlignment = TextAlignment.Left;
                        flowDocument.IsOptimalParagraphEnabled = true;
                        RSSDescription = flowDocument;
                    }

                    if (rssItems != null)
                        rssItems.Items.Add(new RSSItem(RSSTitle, RSSTitleFontSize, RSSTitleForeground,
                                                       RSSTitleFontFamily, RSSDescription, RSSDescriptionFontSize,
                                                       RSSDescriptionForeground, RSSDescriptionFontFamily, string.Empty));
                    rssCount++;
                }
            }
            if(rssCount < 1)
            {
                if (rssItems != null)
                    rssItems.Items.Add(new RSSItem("No News Data Available", RSSTitleFontSize, RSSTitleForeground, RSSTitleFontFamily, new FlowDocument(), RSSDescriptionFontSize, RSSDescriptionForeground, RSSDescriptionFontFamily, string.Empty));
            }

            if (playback)
                RSSItemTimer.Start();

            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                                                                             {
                                                                                 LoadingControlPART.Visibility = Visibility.Collapsed;

                                                                                 if (rssItems != null)
                                                                                     rssItems.Visibility = Visibility.Visible;
                                                                             }));
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
                 backgroundWorker.RunWorkerAsync();
                //Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(ReloadRSSFeeds));
                firstLoad = false;
            }
        }

        private void RSSContentControl_Tick(object sender, EventArgs e)
        {
            if(!IsVisible)
            {
                Dispose();
                return;
            }

            RSSControl rssItemControl = FindName("RSSContainerPART") as RSSControl;
            if (rssItemControl != null)
                if (rssItemControl.CurrentItemIndex < rssItemControl.ItemCount - 1)
                {
                    rssItemControl.Next();
                    //NextFeedDelegate nextFeedDelegate = RSSItemControl.Next;
                    //Dispatcher.BeginInvoke(DispatcherPriority.Render, nextFeedDelegate);
                }
                else
                {
                    try
                    {
                        Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(rssItemControl.First));
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
            //if (managerType == typeof(UnLoadedEventManager))
            //{
            //    RSSContentControl_Unloaded(sender, e);
            //    return true;
            //}
            return false;
        }

        #endregion

        public void Play()
        {
            RSSItemTimer.Start();
        }

        public void Stop()
        {
            RSSItemTimer.Stop();
            RSSControl rssItemControl = FindName("RSSContainerPART") as RSSControl;
            if (rssItemControl != null)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(rssItemControl.First));
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                if (RSSItemTimer != null)
                {
                    if (((Grid)Content).Children[0] is LoadingControl)
                        ((LoadingControl)((Grid)Content).Children[0]).Dispose();

                    RSSItemTimer.Stop();
                    RSSItemTimer = null;
                    //  disposeTimer.Tick -= disposeTimer_Tick;
                    backgroundWorker.DoWork -= backgroundWorker_DoWork;
                    backgroundWorker.Dispose();
                    ClearValue(ContentProperty);
                }
            }
            catch
            {
            }
            
        }

        #endregion
    }
}
