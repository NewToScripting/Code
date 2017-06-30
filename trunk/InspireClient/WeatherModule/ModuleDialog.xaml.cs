using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WeatherModule.Proxy;

namespace WeatherModule
{
    /// <summary>
    /// Interaction logic for ModuleDialog.xaml
    /// </summary>
    public partial class ModuleDialog
    {
        private readonly ObjectDataProvider _searchResultsProvider;
        
        private string _pendingSearchQuery;
        
        private bool _aSearchRequestIsInProgress;
        
        // Original Webservice provider
        //private readonly IWeatherDataProvider _weatherProvider;

        // Cloud WCF service provider
       // private readonly WeatherServiceClient _weatherProvider;

        private BackgroundWorker _backgroundHandleSearchRequest;

        private Location _newLocation;

        public string SelectedStyle { get; set; }

        public Location Location { get; set; }

        public string DegreeType { get; set; }

        public ModuleDialog()
        {
            InitializeComponent();

            Loaded += ModuleDialog_Loaded;

            _searchResultsProvider = FindResource("searchResults") as ObjectDataProvider;

            // Original Webservice provider
            //_weatherProvider = new WeatherDataProvider();

            // Cloud WCF Service
            //_weatherProvider = new WeatherServiceClient("BasicHttpBinding_IWeatherService");

            cbWeatherResource.ItemsSource = WeatherStyles.GetWeatherStyles;
            cbWeatherResource.SelectedValuePath = "Key";

            cbWeatherResource.SelectedIndex = 1;

        }

        void ModuleDialog_Loaded(object sender, RoutedEventArgs e)
        {
            //cbWeatherResource.SelectedIndex = 1;
            //cbWeatherResource.Text = ((KeyValuePair<string, string>) cbWeatherResource.SelectedItem).Value;
            cbWeatherResource.SelectedIndex = 1;
        }

        private void tbLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = ((TextBox)sender).Text.Trim();
            if (!(query.Equals(_pendingSearchQuery)))
            {
                _pendingSearchQuery = query;
                if (!_aSearchRequestIsInProgress)
                {
                    _aSearchRequestIsInProgress = true;
                    _backgroundHandleSearchRequest = new BackgroundWorker();
                    _backgroundHandleSearchRequest.DoWork += HandleSearchRequest;
                    _backgroundHandleSearchRequest.RunWorkerAsync();
                }
            }
        }

        private void HandleSearchRequest(object sender, DoWorkEventArgs e)
        {
            string currentSearchQuery = _pendingSearchQuery;
            _searchResultsProvider.ObjectInstance = WeatherProxy.QueryLocations(currentSearchQuery); //_weatherProvider.QueryLocations(currentSearchQuery);
            if (currentSearchQuery.Equals(_pendingSearchQuery))
                _aSearchRequestIsInProgress = false;
            else
                HandleSearchRequest(sender, e);
        }

        private void btnCancelFeed_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void resultsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var source = sender as ListBox;
            if (source != null)
            {
                if (source.SelectedItem == null)
                    return;
                _newLocation = source.SelectedItem as Location;
            }

            if ((bool)rbC.IsChecked)
                DegreeType = "c";
            else
                DegreeType = "f";
        }

        private void InsertWeatherExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            DegreeType = (bool)rbC.IsChecked ? "c" : "f";

            if (_newLocation != null)
                Location = _newLocation;

            if (cbWeatherResource.SelectedItem != null)
                SelectedStyle = ((KeyValuePair<string, string>)cbWeatherResource.SelectedItem).Key;

            DialogResult = true;
        }

        private void InsertWeatherCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (cbWeatherResource.SelectedItem != null && cbWeatherResource.SelectedItem != null)
                e.CanExecute = true;
        }
    }
}
