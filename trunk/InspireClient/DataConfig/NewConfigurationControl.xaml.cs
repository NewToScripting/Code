using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Inspire.Events.Proxy;
using Inspire.Services.WeakEventHandlers;

namespace DataConfig
{
    /// <summary>
    /// Interaction logic for NewConfigurationControl.xaml
    /// </summary>
    public partial class NewConfigurationControl : IWeakEventListener
    {
        private List<Feed> feeds;

        public NewConfigurationControl()
        {
            InitializeComponent();
            LoadedEventManager.AddListener(this, this);
        }

        void ConfigurationControl_Loaded(object sender, EventArgs e)
        {
            feeds = FeedManager.GetFeeds();

            //cbdataSource.ItemsSource = feeds;

            //cbdataSource.DisplayMemberPath = "Description";

            //cbdataSource.SelectedValuePath = "GUID";

            //spDataFields.DataContext = cbdataSource.SelectedItem;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConfigureDataSource configureDataSource = new ConfigureDataSource();
            configureDataSource.ShowDialog();
            if(configureDataSource.DialogResult == true)
            {
                
            }
            e.Handled = true;
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
