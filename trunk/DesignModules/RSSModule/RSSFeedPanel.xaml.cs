using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml;
using Inspire;
using Inspire.Services.WeakEventHandlers;

namespace RSSModule
{
    /// <summary>
    /// Interaction logic for RSSFeedPanel.xaml
    /// </summary>
    public partial class RSSFeedPanel : INotifyPropertyChanged, IWeakEventListener, IDisposable, IRSSControl
    {
        
        List<SyndicationItem> BlogFeed;
        private bool firstLoad;

        private readonly BackgroundWorker backgroundWorker;

        public ListBox RSSItems { get; set; }

        public RSSFeedPanel(RSSContentControl rssContentControl)
        {
            InitializeComponent();
            firstLoad = true;

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += backgroundWorker_DoWork;

            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);

            LoadedEventManager.AddListener(this, this);

            //UnLoadedEventManager.AddListener(this, this);


            RSSItems = rssContentControl.RSSItems;

            RSSTitleFontSize = rssContentControl.RSSTitleFontSize;
            RSSTitleFontFamily = rssContentControl.RSSTitleFontFamily;
            RSSTitleForeground = rssContentControl.RSSTitleForeground;

            RSSDescriptionFontSize = rssContentControl.RSSDescriptionFontSize;
            RSSDescriptionFontFamily = rssContentControl.RSSDescriptionFontFamily;
            RSSDescriptionForeground = rssContentControl.RSSDescriptionForeground;

        }

        public RSSFeedPanel(RSSControlHolder rssControlHolder, bool play)
        {
            InitializeComponent();
            firstLoad = true;

            backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += backgroundWorker_DoWork;

            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;

            LoadedEventManager.AddListener(this, this);

            RSSItems = rssControlHolder.RSSItems;

            RSSTitleFontSize = rssControlHolder.RSSHolderTitleFontSize;
            RSSTitleFontFamily = rssControlHolder.RSSHolderTitleFontFamily;
            RSSTitleForeground = rssControlHolder.RSSHolderTitleForeground;

            RSSDescriptionFontSize = rssControlHolder.RSSHolderDescriptionFontSize;
            RSSDescriptionFontFamily = rssControlHolder.RSSHolderDescriptionFontFamily;
            RSSDescriptionForeground = rssControlHolder.RSSHolderDescriptionForeground;
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(UpdateRSSText));
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(100);
            foreach (var feed in RSSItems.Items)
            {
                try
                {
                    //using (XmlReader reader = XmlReader.Create((String)feed))
                    //{
                    var list = RSSHelpers.GetFeed(feed.ToString(), true);
                    if (list != null)
                        if (list.Count() > 0)
                        {
                            BlogFeed = new List<SyndicationItem>();
                            BlogFeed.AddRange(list.Take(20)); // SyndicationFeed.Load(reader);
                        }
                    //reader.Close();
                    //}
                }
                catch (Exception ex)
                {
                    if (ex is WebException || ex is XmlException)
                    {
                        // Handle bad url, timeout or xml error here.
                        if (!InspireApp.IsPlayer && !InspireApp.IsPreviewMode)
                            MessageBox.Show("Cannot process RSS link.");
                        //else
                        // throw;
                    }
                }
            }
        }

        private void UpdateRSSText()
        {
            var rssItems = new List<RSSItem>();

            int rssCount = 0;

            if (BlogFeed != null)
            {
                foreach (SyndicationItem item in BlogFeed)
                {
                    string RSSTitle = "";

                    if (item.Title != null)
                        RSSTitle = (item.Title.Text).Replace("\n", "");

                    if (!string.IsNullOrEmpty(item.Summary.Text))
                    {
                        rssItems.Add(new RSSItem(RSSTitle, RSSTitleFontSize, RSSTitleForeground,
                                                 RSSTitleFontFamily, null, RSSDescriptionFontSize,
                                                 RSSDescriptionForeground, RSSDescriptionFontFamily, item.Summary.Text));
                        rssCount++;
                    }
                }
            }
            if (rssCount < 1)
                rssItems.Add(new RSSItem("No News Data Available", RSSTitleFontSize, RSSTitleForeground, RSSTitleFontFamily, new FlowDocument(), RSSDescriptionFontSize, RSSDescriptionForeground, RSSDescriptionFontFamily, string.Empty));

            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
            {
                RSSContainerPART.ItemsSource = rssItems;
                LoadingControlPART.Visibility = Visibility.Collapsed;
                RSSContainerPART.Visibility = Visibility.Visible;
            }));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Dependency Properties

        public static DependencyProperty RSSTitleForegroundProperty = DependencyProperty.Register(
            "RSSTitleForeground", typeof(Brush), typeof(RSSFeedPanel));

        public static DependencyProperty RSSTitleFontFamilyProperty = DependencyProperty.Register(
            "RSSTitleFontFamily", typeof(FontFamily), typeof(RSSFeedPanel));

        public static DependencyProperty RSSTitleFontSizeProperty = DependencyProperty.Register(
            "RSSTitleFontSize", typeof(double), typeof(RSSFeedPanel));

        public static DependencyProperty RSSDescriptionForegroundProperty = DependencyProperty.Register(
            "RSSDescriptionForeground", typeof(Brush), typeof(RSSFeedPanel));

        public static DependencyProperty RSSDescriptionFontFamilyProperty = DependencyProperty.Register(
            "RSSDescriptionFontFamily", typeof(FontFamily), typeof(RSSFeedPanel));

        public static DependencyProperty RSSDescriptionFontSizeProperty = DependencyProperty.Register(
            "RSSDescriptionFontSize", typeof(double), typeof(RSSFeedPanel));
        private RSSControlHolder rSSControlHolder;
        private bool p;

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

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                RSSContentControl_Loaded(sender, e);
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

        void RSSContentControl_Loaded(object sender, EventArgs e)
        {
            if (firstLoad)
            {
                backgroundWorker.RunWorkerAsync();
                //Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(ReloadRSSFeeds));
                firstLoad = false;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                if (((Grid) Content).Children[0] is LoadingControl)
                    ((LoadingControl) ((Grid) Content).Children[0]).Dispose();

                //  disposeTimer.Tick -= disposeTimer_Tick;
                backgroundWorker.DoWork -= backgroundWorker_DoWork;
                backgroundWorker.Dispose();
                ClearValue(ContentProperty);
            }
            catch (Exception){}
        }

        public int RSSFeedSpeed
        {
            get { return 8; }
            set { value = 8; }
        }

        #endregion

    }
}
