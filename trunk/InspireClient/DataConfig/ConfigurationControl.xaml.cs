
using System;
using System.Collections.Generic;
using System.Windows;
using Inspire.Events.Proxy;
using Inspire.Services.WeakEventHandlers;

namespace DataConfig
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ConfigurationControl : IWeakEventListener
    {

        private List<Feed> feeds;

        public ConfigurationControl()
        {
            InitializeComponent();
            LoadedEventManager.AddListener(this, this);
        }

        void ConfigurationControl_Loaded(object sender, EventArgs e)
        {
            feeds = FeedManager.GetFeeds();

            cbdataSource.ItemsSource = feeds;

            cbdataSource.DisplayMemberPath = "Description";

            cbdataSource.SelectedValuePath = "GUID";

            spDataFields.DataContext = cbdataSource.SelectedItem;

        }

        private void cbdataSource_DropDownClosed(object sender, EventArgs e)
        {
            spDataFields.DataContext = (cbdataSource.SelectedItem);
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                ConfigurationControl_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
