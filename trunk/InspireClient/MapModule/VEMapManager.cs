using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using InfoStrat.VE;
using InfoStrat.VE.Windows7Touch;
using Microsoft.MapPoint.Rendering3D;
using Microsoft.MapPoint.Rendering3D.Utility;
using DashStyle = Microsoft.MapPoint.Rendering3D.Utility.DashStyle;


namespace MapModule
{
    public static class VEMapManager
    {

        public static Win7TouchVEMap _veMap { get; set; }
        private static VEPushPin _firstPushPin;
        private static double _pitch;
        private static double _yaw;
        private static double _altitude;

        private static bool attemptedLoaded = false;

        public static Win7TouchVEMap GetMap()
        {
            if (!attemptedLoaded)
            {
                attemptedLoaded = true;
                _veMap = InitializeNewMap();
                _veMap.IsPivotEnabled = false;
                ResetProperties();
            }
            return _veMap;
        }

        private static Win7TouchVEMap InitializeNewMap()
        { 
            return new Win7TouchVEMap();
        }

        public static bool ResetProperties()
        {
            try
            {
                if (_veMap.GlobeControl.Host.Ready)
                {
                    if (_veMap != null)
                    {
                        if (_veMap.Items.Count > 0)
                            _veMap.Items.Clear();
                        _veMap.MapStyle = VEMapStyle.Hybrid;
                        _veMap.Altitude = 5000000.0;
                        _veMap.Roll = 0;
                        _veMap.Yaw = 0;
                        _veMap.Pitch = -90.0;
                        _veMap.LatLong = new System.Windows.Point(38.9444195081574, -77.0630161230201);
                        ShowTraffic = false;
                        ShowBuildings = true;
                        ShowBuildingTextures = true;
                        Show3DCursor = false;
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            
            return false;
        }

        public static void SetMapStyle(string mapStyle)
        {
            if (_veMap != null)
                _veMap.MapStyle = GetVEMapStyle(mapStyle);
        }

        public static VEMapStyle GetVEMapStyle(string mapStyle)
        {
            switch (mapStyle)
            {
                case ("Road"):
                    return VEMapStyle.Road;
                case ("Hybrid"):
                    return VEMapStyle.Hybrid;
                case ("Aerial"):
                    return VEMapStyle.Aerial;
                default:
                    return VEMapStyle.Hybrid;
            }
        }

        public static void AddPushPin(VEPushPin pushPin)
        {
            //if (_veMap.Items == null)
            //{
            //    if (_veMap.ItemsSource != null)
            //        if (_veMap.Items.Count > 0)
            //            _veMap.ItemsSource = null;
            //    _veMap.ItemsSource = new ObservableCollection<VEPushPin>();
            //}

            //var collection = _veMap.ItemsSource as ObservableCollection<VEPushPin>;

            //if(collection != null)
            //    collection.Add(pushPin);

            _veMap.Items.Add(pushPin);
        }

        public static void AddPushPins(IEnumerable<VEPushPin> pushPins)
        {
           // _veMap.ItemsSource = null;

            _veMap.Items.Clear();

            //var collection = new ObservableCollection<VEPushPin>();

            foreach (var vePushPin in pushPins)
            {
                _veMap.Items.Add(vePushPin);
            }

            //_veMap.ItemsSource = collection;
        }

        public static void FlyTo(VEPushPin vePushPin, double pitch, double yaw, double altitude)
        {
            if (_veMap != null)
            {
                if (_veMap.GlobeControl.FirstFrameRendered)
                    _veMap.FlyTo(vePushPin.LatLong, pitch, yaw, altitude);
                else
                {
                    _firstPushPin = vePushPin;
                    _pitch = pitch;
                    _yaw = yaw;
                    _altitude = altitude;
                    _veMap.MapLoaded += VeMapMapLoaded;
                }
            }
        }

        static void VeMapMapLoaded(object sender, EventArgs e)
        {
            _veMap.FlyTo(_firstPushPin.LatLong, _pitch, _yaw, _altitude);
        }

        public static void FlyTo(double lon, double lat, double pitch, double yaw, double altitude)
        {
            _veMap.FlyTo(new VELatLong(lat, lon), pitch, yaw, altitude);
        }

        public static bool ShowTraffic
        {
            set
            {
                if (!_veMap.GlobeControl.Host.Ready) return;
                if (value)
                    _veMap.GlobeControl.Host.DataSources.Add(new DataSourceLayerData("terrain", "traffic", "http://www.bing.com/maps/Manifests/TR.xml",
                        DataSourceUsage.TextureMap, 10, 1.0));
                else
                    _veMap.GlobeControl.Host.DataSources.Remove("terrain", "traffic");
            }
        }

        public static bool ShowBuildings
        {
            set
            {
                if(_veMap != null && _veMap.GlobeControl.Host.Ready)
                    _veMap.ShowBuildings = value;
            }
        }

        public static bool ShowBuildingTextures
        {
            set
            {
                if (_veMap != null && _veMap.GlobeControl.Host.Ready)
                    _veMap.ShowBuildingTextures = value;
            }
        }

        public static bool Show3DCursor
        {
            set
            {
                if (_veMap != null && _veMap.GlobeControl.Host.Ready)
                    _veMap.Show3DCursor = value;
            }
        }

        public static double GetCurrentAlititude()
        {
            return _veMap.Altitude;
        }

        public static double GetCurrentYaw()
        {
            return _veMap.Yaw;
        }

        public static double GetCurrentPitch()
        {
            return _veMap.Pitch;
        }

        public static double GetCurrentRoll()
        {
            return _veMap.Roll;
        }

        public static Win7TouchVEPushPin GetMarkerForCurrentLocation()
        {
            var vePushPin = new Win7TouchVEPushPin
                                {
                                    Altitude = 0,
                                    Latitude = _veMap.LatLong.X,
                                    Longitude = _veMap.LatLong.Y,
                                    PushPinBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#77000000"))
                                };
            return vePushPin;
        }

        public static void RemovePushPin(InspirePushPin markerPin)
        {
            _veMap.Items.Remove(markerPin);
            //var collection = _veMap.ItemsSource as ObservableCollection<VEPushPin>;

            //if (collection != null)
            //{
            //    var pushpin =
            //        collection.Where(pp => pp.Longitude == markerPin.Longitude && pp.Latitude == markerPin.Latitude).FirstOrDefault();

            //    if(pushpin != null)
            //        collection.Remove(pushpin);
            //}
        }

        public static double MapOpacity
        {
            get { return _veMap.Opacity; }
            set { _veMap.Opacity = value; }
        }

        public static void SetPushPins(List<InspireMapLocation> inspireMapLocations, InspireMapLocation home)
        {
            if(home == null) return;

            if (!_veMap.GlobeControl.Host.Ready) return;

            _veMap.Items.Clear();

            _veMap.GlobeControl.Host.Geometry.Clear();
            var homePin = InspirePushPin.GetMarkerPin(home.MarkerPin);

            homePin.Altitude = 0;
            homePin.MinAltitude = 0;

            _veMap.Items.Add(homePin);


            if(inspireMapLocations != null && inspireMapLocations.Count > 0)
            {
                foreach (var inspireMapLocation in inspireMapLocations)
                {
                    if(inspireMapLocation.MarkerVisible)
                    {

                        var pushpin = InspirePushPin.GetMarkerPin(inspireMapLocation.MarkerPin);
                        _veMap.Items.Add(pushpin);
                        //pushpin.UpdatePosition();
                    } 
                }
            }

            double furthestPoint = 0d;

            try
            { 
                if(inspireMapLocations != null)
                furthestPoint = inspireMapLocations.Max(pnt => Convert.ToDouble(pnt.LocationDistance));
            }
            catch (Exception)
            {
                
               // throw;
            }
           

            var alt = MapHelpers.CalculateAlt(furthestPoint.ToString());

            if (alt.Equals(0d))
                alt = home.Altitude;

            FlyTo(home.MarkerPin.Longitude, home.MarkerPin.Latitude, home.Pitch, home.Yaw, alt);
            SetStates(home.MarkerPin);
            _veMap.Roll = home.Roll;
        }

        public static void SetStates(InspirePushPin pushPin)
        {
            foreach (Win7TouchVEPushPin mapPin in _veMap.Items)
            {
                if (mapPin.DataContext is InspirePushPin && ((InspirePushPin)mapPin.DataContext).Name == pushPin.Name)
                {
                    VisualStateManager.GoToState(mapPin, "State1", true);
                    _veMap.SendToFront(mapPin);
                }
                else
                    VisualStateManager.GoToState(mapPin, "State2", true);

            }
        }

        private static readonly Action EmptyDelegate = delegate { };


        public static void Refresh(this System.Windows. UIElement uiElement)
        {
            _veMap.Dispatcher.BeginInvoke(DispatcherPriority.Render, EmptyDelegate);
        }

        internal static void FlyTo(InspireMapLocation inspireMapLocation, InspireMapLocation homeLocation)
        {
            if(inspireMapLocation == null) return;
            var newAlt = MapHelpers.CalculateAlt(inspireMapLocation.LocationDistance);

            FlyTo(inspireMapLocation.MarkerPin.Longitude, inspireMapLocation.MarkerPin.Latitude, -90.0, 0, newAlt);
            SetStates(inspireMapLocation.MarkerPin);
        }

        public static void FlyTo(InspirePushPin inspireMapLocation)
        {
            FlyTo(inspireMapLocation.Longitude, inspireMapLocation.Latitude, -90.0, 0, inspireMapLocation.FlyToAltitude);
            SetStates(inspireMapLocation);
        }

        public static void AddRoute(List<LatLonAlt> lla)
        {
            PolyInfo style = PolyInfo.DefaultPolygon;
            style.LineWidth = 3;
            style.LineColor = System.Drawing.Color.Blue;//.FromArgb(255, 0, 01);
            style.Filled = false;
            style.DashStyle = DashStyle.DashDot;

            _veMap.GlobeControl.Host.Geometry.AddGeometry(new PolylineGeometry("route", Guid.NewGuid().ToString(), null, lla.ToArray(), PolylineGeometry.PolylineFormat.Polyline2D, style));
        }

        public static void FlyToAndShow(InspireMapLocation inspireMapLocation)
        {
            //_veMap.ItemsSource = null;
            _veMap.Items.Clear();
            _veMap.GlobeControl.Host.Geometry.Clear();

           // var collection = new ObservableCollection<Win7TouchVEPushPin>();

            var mapLoc = InspirePushPin.GetMarkerPin(inspireMapLocation.MarkerPin);

            mapLoc.Altitude = inspireMapLocation.Altitude;

            _veMap.Items.Add(mapLoc);

           // double surfaceElevation = _veMap.GlobeControl.Host.WorldEngine.GetSurfaceElevation(new LatLon(_veMap.VELatLong.Latitude, _veMap.VELatLong.Longitude)) + 1500;
            FlyTo(inspireMapLocation.MarkerPin.Longitude, inspireMapLocation.MarkerPin.Latitude, -90.0, 0, mapLoc.Altitude);
        }

        public static void FlyToAndShow(InspireMapLocation inspireMapLocation, InspireMapLocation home)
        {
            //_veMap.ItemsSource = null;
            _veMap.Items.Clear();
            _veMap.GlobeControl.Host.Geometry.Clear();

            //var collection = new ObservableCollection<Win7TouchVEPushPin>();

            _veMap.Items.Add(InspirePushPin.GetMarkerPin(home.MarkerPin));
            _veMap.Items.Add(InspirePushPin.GetMarkerPin(inspireMapLocation.MarkerPin));

            double surfaceElevation = _veMap.GlobeControl.Host.WorldEngine.GetSurfaceElevation(new LatLon(_veMap.VELatLong.Latitude, _veMap.VELatLong.Longitude)) + 1500;
            FlyTo(inspireMapLocation.MarkerPin.Longitude, inspireMapLocation.MarkerPin.Latitude, -90.0, 0, surfaceElevation);
        }

        public static void ZoomIn()
        {
            _veMap.DoMapZoom(100.0);
        }

        public static void ZoomOut()
        {
            _veMap.DoMapZoom(-100.0);
        }
    }
}
