using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using InfoStrat.VE;
using InfoStrat.VE.Windows7Touch;
using Inspire;
using Inspire.Interfaces;
using Inspire.Services.WeakEventHandlers;
using Microsoft.MapPoint.Rendering3D.Utility;
using Transitionals;
using Transitionals.Transitions;

namespace MapModule
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MapControl : IWeakEventListener, IDisposable, IPlayable
    {
        public MapControl()
        {
            InitializeComponent();

            PART_CategoryHolder.Transition = new FadeTransition();

            detailsHolder.Transition = new FadeTransition();

            LoadedEventManager.AddListener(this, this);
        }


        private readonly List<MapCategory> _inspireMapCategories;
        private List<InspireMapLocation> _inspireMapLocations;
        private List<InspireMapLocation> InspireMapLocations
        {
            get { return _inspireMapLocations; }
            set { _inspireMapLocations = value; }
        }

        private readonly List<InspireMapLocation> _autoAdvanceLocations;
        private readonly InspireMapLocation _home;
        private bool _isLoaded;
        private readonly bool _showTraffic;
        private readonly string _mapStyle;
        private readonly bool _showBuildings;
        private readonly bool _showBuildingTextures;
        private readonly bool _show3DCursor;
        private readonly bool _showTouchPanel;
        private readonly bool _showMapControls;
        private readonly bool _showMapOnly;
        private readonly bool _showPrint;
        private readonly bool _autoAdvance;
        private int _currentAutoadvanceIndex;

        private readonly DispatcherTimer _idleTimer;
        private readonly DispatcherTimer _autoAdvanceTimer;
        private readonly BackgroundWorker _goGetCategoryItemsWorker;
        private bool _isPlaying;

        //private InspireMapLocation _homeLocation;

        //public InspireMapLocation CurrentMapLocation
        //{
        //    get { return (InspireMapLocation)GetValue(CurrentMapLocationProperty); }
        //    set { SetValue(CurrentMapLocationProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for CurrentMapLocation.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty CurrentMapLocationProperty =
        //    DependencyProperty.Register("CurrentMapLocation", typeof(InspireMapLocation), typeof(MapControl), new UIPropertyMetadata(null));

        public MapControl(InspireMapLocation home, List<MapCategory> mapCategories, bool showTraffic, string mapStyle, bool showBuildings, bool showBuildingTextures, bool show3DCursor, bool showTouchPanel, bool showMapControls, bool showMapOnly, bool showPrint, bool autoAdvance) : this()
        {
            _home = home;
            mapHolder.Content = VEMapManager.GetMap();
            _inspireMapCategories = mapCategories;
            _showTraffic = showTraffic;
            _mapStyle = mapStyle;
            _showBuildings = showBuildings;
            _showBuildingTextures = showBuildingTextures;
            _show3DCursor = show3DCursor;
            _showTouchPanel = showTouchPanel;
            _showMapControls = showMapControls;
            _showMapOnly = showMapOnly;
            _showPrint = showPrint;
            _autoAdvance = autoAdvance;

            if (_inspireMapCategories == null)
            {
                _inspireMapCategories = new List<MapCategory>();
                _showMapOnly = true;
            }

            _idleTimer = new DispatcherTimer();

            _idleTimer.Interval = TimeSpan.FromSeconds(30);
            _idleTimer.Tick += _idleTimer_Tick;

            _goGetCategoryItemsWorker = new BackgroundWorker();
            _goGetCategoryItemsWorker.DoWork += _goGetCategoryItemsWorker_DoWork;

            if (_autoAdvance)
            {
                _autoAdvanceTimer = new DispatcherTimer();
                _autoAdvanceTimer.Tick += _autoAdvanceTimer_Tick;

                if (_inspireMapCategories.Where(mc => mc.AutoPopulate).Count() > 0)
                {
                    _autoAdvanceLocations = new List<InspireMapLocation>();
                }
            }

            if (_showMapOnly)
                HideAllButMap();
            
        }

        public void Play()
        {
            VEMapManager.SetPushPins(null, _home);
            if (!_autoAdvance) return;
            if (_autoAdvanceTimer != null)
            {
                _autoAdvanceTimer.Interval = TimeSpan.FromSeconds(30);
                _autoAdvanceTimer.Start();
            }
            _isPlaying = true;
        }

        public void Stop()
        {
            if (_autoAdvanceTimer != null) _autoAdvanceTimer.Stop();
            _isPlaying = false;
        }

        public bool IsPlaying()
        {
            return _isPlaying;
        }

        void _goGetCategoryItemsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (InspireMapLocations == null)
                InspireMapLocations = new List<InspireMapLocation>();

            foreach (var mapCategory in _inspireMapCategories.Where(mc => mc.AutoPopulate))
            {
                var locs = MapRequestManager.GetSubCategories(mapCategory.Name,
                                                              _home.MarkerPin.Latitude + ", " +
                                                              _home.MarkerPin.Longitude,
                                                              mapCategory.CategoryStyle, _home);
                InspireMapLocations.AddRange(locs);
                if(_autoAdvance)
                    _autoAdvanceLocations.AddRange(locs);
            }

            InspireMapLocations.Shuffle();
        }

        void _autoAdvanceTimer_Tick(object sender, EventArgs e)
        {
            if (InspireMapLocations.Count > 0)
                NextItem();
        }

        private void NextItem()
        {
            if (_currentAutoadvanceIndex >= InspireMapLocations.Count -1)
                _currentAutoadvanceIndex = 0;
            VEMapManager.FlyToAndShow(_autoAdvanceLocations[_currentAutoadvanceIndex], _home);

            detailsHolder.Content = new InspireLocationDetails(_autoAdvanceLocations[_currentAutoadvanceIndex], detailsHolder);
            _currentAutoadvanceIndex++;
        }

        private void PreviousItem()
        {
            if (_currentAutoadvanceIndex == 0)
                _currentAutoadvanceIndex = InspireMapLocations.Count - 1;
            VEMapManager.FlyToAndShow(_autoAdvanceLocations[_currentAutoadvanceIndex], _home);

            detailsHolder.Content = new InspireLocationDetails(_autoAdvanceLocations[_currentAutoadvanceIndex], detailsHolder);
            _currentAutoadvanceIndex++;
        }

        void _idleTimer_Tick(object sender, EventArgs e)
        {
            PART_CategoryHolder.Content = new CategorySlider(_inspireMapCategories, PART_CategoryHolder, detailsHolder, _home, _showPrint);
            RestartTimer();
            VEMapManager.SetPushPins(null, _home);
        }

        private void RestartTimer()
        {
            //Play();

            if (_showMapOnly) return;

            if (_idleTimer == null) return;
            _idleTimer.Stop();
            _idleTimer.Interval = TimeSpan.FromSeconds(30);

            if(PART_CategoryHolder.Content is CategorySlider)
                _idleTimer.Stop();
            else
                _idleTimer.Start();
        }

        private void HideAllButMap()
        {
            PART_SearchButton.Visibility = Visibility.Collapsed;
            PART_CategoryHolder.Visibility = Visibility.Collapsed;
        }

        private void Map_MapLoaded(object sender, EventArgs e)
        {
            
            if (!_isLoaded)
            {
                if(_mapStyle.Equals("Aerial"))
                    tglArial.IsChecked = true;
                else if(_mapStyle.Equals("Road"))
                    tglRoad.IsChecked = true;
                else if(_mapStyle.Equals("Hybrid"))
                    tglHybrid.IsChecked = true;

                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                                                                                 {
                                                                                     try
                                                                                     {
                                                                                         InspireMapLocations = _inspireMapCategories.
                                                                                             SelectMany(
                                                                                                 inspireMapCategory =>
                                                                                                 inspireMapCategory.
                                                                                                     MapLocations).
                                                                                             ToList();

                                                                                         foreach (var inspireMapLocation in InspireMapLocations)
                                                                                         {
                                                                                             inspireMapLocation.LocationDistance = MapHelpers.DistanceInMilesString(_home, inspireMapLocation);
                                                                                         }

                                                                                         //while (
                                                                                         //    !VEMapManager._veMap.GlobeControl.Host.Ready)
                                                                                         //{
                                                                                         //}

                                                                                         if(InspireApp.IsPreviewMode || InspireApp.IsPlayer)
                                                                                             if (!_goGetCategoryItemsWorker.IsBusy)
                                                                                                 _goGetCategoryItemsWorker.RunWorkerAsync();

                                                                                         if (_autoAdvance)
                                                                                         {

                                                                                             if (_inspireMapCategories.Where(mc => mc.AutoPopulate).Count() > 0)
                                                                                             {
                                                                                                 if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
                                                                                                     Play();
                                                                                             }
                                                                                         }

                                                                                         //VEMapManager.ResetProperties();

                                                                                         if(VEMapManager._veMap.GlobeControl.Host.Ready)
                                                                                         {
                                                                                             VEMapManager.SetMapStyle(_mapStyle);

                                                                                             VEMapManager.ShowBuildings =
                                                                                                 _showBuildings;

                                                                                             VEMapManager.ShowBuildingTextures =
                                                                                                 _showBuildingTextures;

                                                                                             VEMapManager.Show3DCursor =
                                                                                                 _show3DCursor;

                                                                                             VEMapManager.ShowTraffic =
                                                                                                 _showTraffic;

                                                                                             VEMapManager.FlyToAndShow(_home);
                                                                                         }
                                                                                         else
                                                                                            VEMapManager._veMap.Initialized += _veMap_Initialized;

                                                                                         // VEMapManager.GetMap().GlobeControl.Refresh();

                                                                                     }
                                                                                     catch (Exception)
                                                                                     {

                                                                                     }
                                                                                 }));

                ShowMapControls(_showMapControls);

                if(!_showMapOnly)
                    PART_CategoryHolder.Content = new CategorySlider(_inspireMapCategories, PART_CategoryHolder, detailsHolder, _home, _showPrint);
                _isLoaded = true;
            }

        }

        void _veMap_Initialized(object sender, EventArgs e)
        {
            VEMapManager.SetMapStyle(_mapStyle);

            VEMapManager.ShowBuildings =
                _showBuildings;

            VEMapManager.ShowBuildingTextures =
                _showBuildingTextures;

            VEMapManager.Show3DCursor =
                _show3DCursor;

            VEMapManager.ShowTraffic =
                _showTraffic;

            VEMapManager.FlyToAndShow(_home);
        }

        private void ShowMapControls(bool show)
        {
            if (show)
            {
                PART_MapMode.Visibility = System.Windows.Visibility.Visible;
                PART_ZoomControls.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                PART_MapMode.Visibility = System.Windows.Visibility.Collapsed;
                PART_ZoomControls.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                Map_MapLoaded(sender, e);
                return true;
            }
            //else if (managerType == typeof(DispatcherTimerTickEventManager))
            //{
            //    FlightContentControl_DispatcherTick(sender, e);
            //    return true;
            //}
            return false;
        }

        ~MapControl()
        {
            Dispose();
        }


        public void Dispose()
        {
            if (_idleTimer != null)
                _idleTimer.Stop();
            if (_autoAdvanceTimer != null)
                _autoAdvanceTimer.Stop();

            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                                                                        {
                                                                            try
                                                                            {
                                                                                if (detailsHolder != null)
                                                                                    detailsHolder.Content = null;
                                                                                if (PART_CategoryHolder != null)
                                                                                    PART_CategoryHolder.Content = null;
                                                                                mapHolder.Content = null;
                                                                            }
                                                                            catch (Exception)
                                                                            {

                                                                            }
                                                                        }));
        }

        private void DynamicMarker_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            var pushPin = ((FrameworkElement)sender).DataContext as InspirePushPin;
            if (pushPin != null)
            {
                

                //VEMapManager.SetStates(pushPin);

                VEMapManager.FlyTo(pushPin);
                
                var location = MapHelpers.FindInspireLocation(pushPin, InspireMapLocations);

                if (location == null)//return;
                    location = _home;

                //VEMapManager.FlyTo(location, _home);

                detailsHolder.Content = new InspireLocationDetails(location, detailsHolder);
            }
        }

        private void DynamicMarker_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            if(!InspireApp.IsPlayer) return;
            var pushPin = ((FrameworkElement)sender).DataContext as InspirePushPin;
            if (pushPin != null)
            {
                VEMapManager.FlyTo(pushPin);

                var location = MapHelpers.FindInspireLocation(pushPin, InspireMapLocations) ?? _home;

                detailsHolder.Content = new InspireLocationDetails(location,detailsHolder);
            }
        }

        

        private void StackPanel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_showMapOnly || PART_CategoryHolder.Content is SearchControl) return;
            PART_CategoryHolder.Content = new SearchControl(_inspireMapCategories, PART_CategoryHolder, detailsHolder, _home, _showPrint);
            _idleTimer.Start();
        }

        private void StackPanel_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            if (_showMapOnly || PART_CategoryHolder.Content is SearchControl) return;
            PART_CategoryHolder.Content = new SearchControl(_inspireMapCategories, PART_CategoryHolder, detailsHolder, _home, _showPrint);
            _idleTimer.Start();
        }

        private void tglMap_Checked(object sender, RoutedEventArgs e)
        {
            if(tglArial.IsChecked == true)
                VEMapManager.SetMapStyle("Aerial");
            else if(tglHybrid.IsChecked == true)
                VEMapManager.SetMapStyle("Hybrid");
            else if (tglRoad.IsChecked == true)
                VEMapManager.SetMapStyle("Road");
        }

        private void UserControl_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RestartTimer();
        }

        private void UserControl_PreviewTouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            RestartTimer();
        }

        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            VEMapManager.ZoomIn();
        }

        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            VEMapManager.ZoomOut();
        }

        private void UserControl_TouchMove(object sender, System.Windows.Input.TouchEventArgs e)
        {
            RestartTimer();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(IsVisible) return;

            _idleTimer.Stop();
            if (_autoAdvanceTimer != null)
                _autoAdvanceTimer.Stop();
        }

    }

    public static class ExtentionMethods
    {
        public static void Shuffle<T>(this List<T> source)
        {
            Random rnd = new Random();

            for (int i = 0; i < source.Count; i++)
            {
                int index = rnd.Next(0, source.Count);
                T o = source[0];

                source.RemoveAt(0);
                source.Insert(index, o);
            }
        } 
    }

}
