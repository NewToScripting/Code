using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using InfoStrat.VE;
using InfoStrat.VE.Windows7Touch;
using Inspire.Common.Dialogs;
using Inspire.Services.WeakEventHandlers;
using Microsoft.MapPoint.Rendering3D.Utility;

namespace MapModule
{
    /// <summary>
    /// Interaction logic for PushPointPicker.xaml
    /// </summary>
    public partial class PushPointPicker : Window , IWeakEventListener
    {
        private bool _loaded;
        //public ObservableCollection<InspireMapLocation> InspireMapLocations { get; set; }
        public ObservableCollection<MapCategory> MapCategories { get; set; }
        public InspireMapLocation Home { get; set; }
        public bool ShowTraffic { get; set; }
        public VEMapStyle MapStyle { get; set; }
        public bool ShowBuildings { get; set; }
        public bool ShowBuildingTextures { get; set; }
        public bool Show3DCursor { get; set; }
        public bool ShowMapControls { get; set; }
        public bool ShowMapOnly { get; set; }
        public bool ShowPrintIcon { get; set; }
        public bool AutoAdvanceLocations { get; set; }

        public bool ShowTouchPanel { get; set; }

        public PushPointPicker()
        {
            InitializeComponent();
            LoadedEventManager.AddListener(this, this);
            MapStyle = VEMapStyle.Road;
        }

        public PushPointPicker(InspireMapLocation home, IEnumerable<MapCategory> mapCategories, bool showTraffic, string veMapStyle, bool showBuildings, bool showBuildingTextures, bool show3DCursor, bool showTouchPanel, bool showMapControls, bool mapOnly, bool showPrint, bool autoAdvance)
        {
            InitializeComponent();
            LoadedEventManager.AddListener(this, this);

            MapCategories = mapCategories == null ? new ObservableCollection<MapCategory>() : new ObservableCollection<MapCategory>(mapCategories);
            //InspireMapLocations = new ObservableCollection<InspireMapLocation>(pushPoints);
            //lbPushPins.ItemsSource = InspireMapLocations;
            Home = home;
            tvCategories.ItemsSource = MapCategories;
            
            dmtempl.DataContext = Home;

            cbShowTraffic.IsChecked = ShowTraffic = showTraffic;
            cbShowBuildings.IsChecked = ShowBuildings = showBuildings;
            cbShowBuildingTextures.IsChecked = ShowBuildingTextures = showBuildingTextures;
            cbShow3DCursor.IsChecked = Show3DCursor = show3DCursor;
            cbShowMapControls.IsChecked = ShowMapControls = showMapControls;
            cbShowMapOnly.IsChecked = ShowMapOnly = mapOnly;
            cbShowPrint.IsChecked = ShowPrintIcon = showPrint;
            cbAutoAdvance.IsChecked = AutoAdvanceLocations = autoAdvance;
            cbShowPrint.IsChecked = ShowPrintIcon = showPrint;

            MapStyle = VEMapManager.GetVEMapStyle(veMapStyle);

            switch (MapStyle)
            {
                case (VEMapStyle.Road):
                    rbRoad.IsChecked = true;
                    break;
                case (VEMapStyle.Hybrid):
                    rbHybrid.IsChecked = true;
                    break;
                case (VEMapStyle.Aerial):
                    rbAerial.IsChecked = true;
                    break;
            }
        }

        public PushPointPicker(IEnumerable<MapCategory> mapCategories)
        {
            InitializeComponent();
            LoadedEventManager.AddListener(this, this);

            MapStyle = VEMapStyle.Hybrid;

            MapCategories = new ObservableCollection<MapCategory>(mapCategories);
            tvCategories.ItemsSource = MapCategories;
        }

        private void map_MapLoaded(object sender, EventArgs e)
        {
            VEMapManager.SetMapStyle(MapStyle.ToString());
            if (_loaded) return;
            mapHolder.Content = VEMapManager.GetMap();

            if (Home != null)
            {
                tbHomLoc.DataContext = Home;
                dmtempl.DataContext = Home;
                dmtempl.SelectedTemplate = Home.MarkerPin.CategoryStyle;
                dmtempl.ReloadTemplate();
            }

           // VEMapManager.ResetProperties();

            if(MapCategories != null && MapCategories.Count > 0)
            {
                var mapLocations = new List<InspireMapLocation>();

                foreach (var mapCategory in MapCategories.Where(mapCategory => mapCategory.MapLocations != null && mapCategory.MapLocations.Count > 0))
                    mapLocations.AddRange(mapCategory.MapLocations);

                VEMapManager.SetPushPins(mapLocations, Home);
            }

            VEMapManager.SetMapStyle(MapStyle.ToString());

            _loaded = true;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Home != null)
                {
                    ShowTraffic = (bool) cbShowTraffic.IsChecked;

                    ShowBuildings = (bool) cbShowBuildings.IsChecked;
                    ShowBuildingTextures = (bool) cbShowBuildingTextures.IsChecked;
                    Show3DCursor = (bool) cbShow3DCursor.IsChecked;
                    AutoAdvanceLocations = (bool) cbAutoAdvance.IsChecked;
                    ShowMapControls = (bool) cbShowMapControls.IsChecked;
                    ShowMapOnly = (bool) cbShowMapOnly.IsChecked;
                    ShowPrintIcon = (bool) cbShowPrint.IsChecked;
                    DialogResult = true;
                }
                else
                {
                    CommonDialog commonDialog = new CommonDialog("No Home Location Added.", "There was no home location specified. Add a home location to the map before submitting.");
                    commonDialog.ShowDialog();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            // Remove the map, there can only be once instance.
            mapHolder.Content = null;
            base.OnClosing(e);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void rbRoad_Checked(object sender, RoutedEventArgs e)
        {
            if (!_loaded) return;
            VEMapManager.SetMapStyle("Road");
            MapStyle = VEMapStyle.Road;
        }

        private void rbHybrid_Checked(object sender, RoutedEventArgs e)
        {
            if (!_loaded) return;
            VEMapManager.SetMapStyle("Hybrid");
            MapStyle = VEMapStyle.Hybrid;
        }

        private void rbAerial_Checked(object sender, RoutedEventArgs e)
        {
            if (!_loaded) return;
            VEMapManager.SetMapStyle("Aerial");
            MapStyle = VEMapStyle.Aerial;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var selectedCat = tvCategories.SelectedItem as MapCategory;

            if(selectedCat == null) return;

            if(selectedCat.MapLocations == null)
            {
                selectedCat.MapLocations = new InspireMapLocationCollection();
                //lbPushPins.ItemsSource = InspireMapLocations;
            }
            var addPushPin = new AddPushPin(selectedCat.Name);
            addPushPin.ShowDialog();
            if(addPushPin.DialogResult == true)
            {
                var inspireMapLocation = new InspireMapLocation();
                inspireMapLocation.CategoryName = selectedCat.Name;
                inspireMapLocation.LocationDescription = addPushPin.PushPinDescription;
                inspireMapLocation.LocationName = addPushPin.PushPinName;
                inspireMapLocation.PriceRating = addPushPin.AvgPrice;
                inspireMapLocation.ShowPriceRating = addPushPin.ShowPriceIndicator;
                inspireMapLocation.MarkerVisible = addPushPin.ShowMarker;
                inspireMapLocation.Roll = VEMapManager.GetCurrentRoll();
                inspireMapLocation.Pitch = VEMapManager.GetCurrentPitch();
                inspireMapLocation.Yaw = VEMapManager.GetCurrentYaw();
                inspireMapLocation.Altitude = VEMapManager.GetCurrentAlititude();
                var marker = GetCurrentMarkerPoint();
                marker.Content = inspireMapLocation.GetMarkerContent();

                string pushPinStyle = selectedCat.CategoryStyle;

                if (string.IsNullOrEmpty(pushPinStyle))
                    pushPinStyle = "0";

                inspireMapLocation.AddMarker(marker, pushPinStyle, inspireMapLocation.LocationName, inspireMapLocation.Altitude, inspireMapLocation.LocationDescription);
                marker.DataContext = inspireMapLocation.MarkerPin;
                if (inspireMapLocation.MarkerVisible)
                    VEMapManager.AddPushPin(marker);

                selectedCat.MapLocations.Add(inspireMapLocation);
            }

        }

        private static Win7TouchVEPushPin GetCurrentMarkerPoint()
        {
            return VEMapManager.GetMarkerForCurrentLocation();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

            if (tvCategories.SelectedItem != null)
            {
                var selectedItem = tvCategories.SelectedItem as InspireMapLocation;

                if(selectedItem == null) return;

                TreeViewItem selectedTVI = tvCategories.Tag as TreeViewItem;

                if (selectedTVI != null)
                {

                    var parentTv = tvCategories.ContainerFromElement(selectedTVI) as TreeViewItem;

                    if (parentTv != null)
                    {
                        var parent = parentTv.DataContext as MapCategory;

                        VEMapManager.RemovePushPin(selectedItem.MarkerPin);
                        if (parent != null) parent.MapLocations.Remove(selectedItem);
                    }
                }
            }
        }

        private void cbShowTraffic_Checked(object sender, RoutedEventArgs e)
        {
            if (!_loaded) return;
            VEMapManager.ShowTraffic = true;
            ShowTraffic = true;
        }

        private void cbShowTraffic_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!_loaded) return;
            VEMapManager.ShowTraffic = false;
            ShowTraffic = false;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MarkerChooser markerChooser = Home == null ? new MarkerChooser("Home", "1") : new MarkerChooser(Home.CategoryName, Home.MarkerPin.CategoryStyle);

            markerChooser.ShowDialog();
            if (markerChooser.DialogResult == true)
            {
                var addPushPin = new AddPushPin(markerChooser.CategoryName);
                addPushPin.ShowDialog();
                if (addPushPin.DialogResult == true)
                {
                    var inspireMapLocation = new InspireMapLocation();
                    inspireMapLocation.CategoryName = "Home";
                    inspireMapLocation.LocationDescription = addPushPin.PushPinDescription;
                    inspireMapLocation.LocationName = addPushPin.PushPinName;
                    inspireMapLocation.PriceRating = addPushPin.AvgPrice;
                    inspireMapLocation.ShowPriceRating = addPushPin.ShowPriceIndicator;
                    inspireMapLocation.MarkerVisible = addPushPin.ShowMarker;
                    inspireMapLocation.Roll = VEMapManager.GetCurrentRoll();
                    inspireMapLocation.Pitch = VEMapManager.GetCurrentPitch();
                    inspireMapLocation.Yaw = VEMapManager.GetCurrentYaw();
                    inspireMapLocation.Altitude = VEMapManager.GetCurrentAlititude();
                    var marker = GetCurrentMarkerPoint();
                    marker.Content = inspireMapLocation.GetMarkerContent();

                    string pushPinStyle = markerChooser.MarkerStyle;

                    if (string.IsNullOrEmpty(pushPinStyle))
                        pushPinStyle = "0";

                    inspireMapLocation.AddMarker(marker, pushPinStyle, inspireMapLocation.LocationName,
                                                 inspireMapLocation.Altitude, inspireMapLocation.LocationDescription);
                    marker.DataContext = inspireMapLocation.MarkerPin;
                    if (inspireMapLocation.MarkerVisible)
                        VEMapManager.AddPushPin(marker);

                    Home = inspireMapLocation;

                    tbHomLoc.DataContext = Home;

                    dmtempl.DataContext = Home;
                    dmtempl.SelectedTemplate = pushPinStyle;
                    dmtempl.ReloadTemplate();
                }
            }

        }

        private void cbShowBuildings_Checked(object sender, RoutedEventArgs e)
        {
            if (!_loaded) return;
            VEMapManager.ShowBuildings = true;
        }

        private void cbShowBuildings_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!_loaded) return;
            VEMapManager.ShowBuildings = false;
        }

        private void cbShowBuildingTextures_Checked(object sender, RoutedEventArgs e)
        {
            if (!_loaded) return;
            VEMapManager.ShowBuildingTextures = true;
        }

        private void cbShowBuildingTextures_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!_loaded) return;
            VEMapManager.ShowBuildingTextures = false;
        }

        private void cbShow3DCursor_Checked(object sender, RoutedEventArgs e)
        {
            if (!_loaded) return;
            VEMapManager.Show3DCursor = true;
        }

        private void cbShow3DCursor_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!_loaded) return;
            VEMapManager.Show3DCursor = false;
        }

        private void cbShowMapControls_Checked(object sender, RoutedEventArgs e)
        {
            if (!_loaded) return;
            // TODO show and hide map controls
        }

        private void cbShowMapControls_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!_loaded) return;
            // TODO show and hide map controls
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                map_MapLoaded(sender, e);
                return true;
            }
            return false;
        }

        private void OnItemSelected(object sender, RoutedEventArgs e)
        {
            tvCategories.Tag = e.OriginalSource;

            if (e.OriginalSource is MapCategory)
                cbAutoPopCat.DataContext = e.OriginalSource;
            else
            {
                var parentTv = tvCategories.ContainerFromElement((TreeViewItem)e.OriginalSource) as TreeViewItem;

                if (parentTv != null)
                {
                    cbAutoPopCat.DataContext = parentTv.DataContext as MapCategory;
                }
            }
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            var markerChooser = new MarkerChooser(string.Empty, "1");
            markerChooser.ShowDialog();
            if (markerChooser.DialogResult == true)
                MapCategories.Add(new MapCategory(markerChooser.CategoryName, markerChooser.MarkerStyle));
        }

        private void btnRemoveCategory_Click(object sender, RoutedEventArgs e)
        {
            if (tvCategories.SelectedItem == null) return;

            var selectedCat = tvCategories.SelectedItem as MapCategory;
            if (selectedCat == null) return;

            MapCategories.Remove(selectedCat);
        }
    }
}
