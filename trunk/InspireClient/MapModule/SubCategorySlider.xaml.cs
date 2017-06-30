using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Transitionals.Controls;

namespace MapModule
{
    /// <summary>
    /// Interaction logic for SubCategorySlider.xaml
    /// </summary>
    public partial class SubCategorySlider
    {
        private readonly TransitionElement _contentHolder;
        private readonly TransitionElement _detailHolder;
        private readonly IEnumerable<MapCategory> _cats;
        private readonly InspireMapLocation _home;
        private readonly IEnumerable<InspireMapLocation> _entries;
        private readonly string _catName;
        private readonly string _cStyle;
        private readonly bool _searchBing;

        private readonly BackgroundWorker _backgroundWorker = new BackgroundWorker();
        private readonly bool _showPrint;

        public SubCategorySlider()
        {
            InitializeComponent();

            _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += new DoWorkEventHandler(_backgroundWorker_DoWork);
            _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_backgroundWorker_RunWorkerCompleted);
        }

        void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingControl.Visibility = Visibility.Collapsed;

            if (ICSubCategories.Items.Count == 0)
            {
                tbCategory.FontSize = 28.0;
                tbCategory.Text = "Please try searching again.";
            }
        }

        void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<InspireMapLocation> searchList = _entries != null ? new List<InspireMapLocation>(_entries) : new List<InspireMapLocation>();

            if (_searchBing)
                searchList.AddRange(MapRequestManager.GetSubCategories(_catName, _home.MarkerPin.Latitude + ", " + _home.MarkerPin.Longitude, _cStyle, _home));

            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                                                                        {
                                                                            if (searchList.Count > 0)
                                                                                _detailHolder.Content =
                                                                                    new InspireLocationDetails(
                                                                                        searchList[0], _detailHolder);

                                                                            ICSubCategories.ItemsSource =
                                                                                searchList.OrderBy(
                                                                                    sc =>
                                                                                    Convert.ToDouble(sc.LocationDistance));

                                                                            if (searchList.Count > 0)
                                                                            {
                                                                                tbCategory.Text = _catName;
                                                                                tbCategory.FontSize = 48.0;
                                                                                catStyle.DataContext = searchList.ToList()[0];
                                                                                catStyle.ReloadTemplate();
                                                                            }
                                                                            else
                                                                            {
                                                                                tbCategory.Text = "No (" + _catName +
                                                                                                  ") locations found.";
                                                                                tbCategory.FontSize = 28.0;
                                                                            }

                                                                            searchList.Add(_home);

                                                                            VEMapManager.SetPushPins(searchList, _home);
                                                                        }));
        }

        public SubCategorySlider(IEnumerable<MapCategory> cats, IEnumerable<InspireMapLocation> entries, TransitionElement categoryHolder, TransitionElement detailHolder, InspireMapLocation home, string catName, string cStyle, bool searchBing, bool showPrint): this()
        {
            _cats = cats;
            _contentHolder = categoryHolder;
            _home = home;
            _detailHolder = detailHolder;
            _entries = entries;
            _catName = catName;
            _cStyle = cStyle;
            _searchBing = searchBing;
            _showPrint = showPrint;

            tbCategory.Text = _catName;

            while (_backgroundWorker.IsBusy)
            {
                Thread.Sleep(200);
            }

            _backgroundWorker.RunWorkerAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var catView = new CategorySlider(_cats, _contentHolder, _detailHolder, _home, _showPrint);
            _contentHolder.Content = catView;
            _detailHolder.Content = null;
            VEMapManager.SetPushPins(new List<InspireMapLocation>(){_home}, _home);
        }

        private void SubCat_TouchDown(object sender, TouchEventArgs touchEventArgs)
        {
            var inspireMapLocation = ((FrameworkElement) sender).DataContext as InspireMapLocation;
            FlyTo(inspireMapLocation);
        }

        private void FlyTo(InspireMapLocation inspireMapLocation)
        {
            VEMapManager.FlyTo(inspireMapLocation, _home);
            _detailHolder.Content = new InspireLocationDetails(inspireMapLocation, _detailHolder);
        }


        private void SubCat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var inspireMapLocation = ((FrameworkElement)sender).DataContext as InspireMapLocation;
            FlyTo(inspireMapLocation);
        }

        private void GetDirections_Click(object sender, RoutedEventArgs e)
        {
            var endingLoc = ((Button) sender).DataContext as InspireMapLocation;
            var catView = new DirectionsControl(_home, endingLoc, _contentHolder, _detailHolder, _cats, _showPrint);
            _contentHolder.Content = catView;
            VEMapManager.SetPushPins(new List<InspireMapLocation> { endingLoc }, _home);
        }

        private void ICSubCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var inspireMapLocation = ICSubCategories.SelectedItem as InspireMapLocation;
            if(inspireMapLocation != null)
                FlyTo(inspireMapLocation);
        }
    }
}
