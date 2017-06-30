using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using InfoStrat.VE;
using Inspire;
using Inspire.Services.WeakEventHandlers;

namespace MapModule
{
    [Serializable]
    public class MapContentControl : ContentControl, IWeakEventListener, IDisposable
    {
        private bool isLoaded = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public InspireMapLocation Home { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private InspireMapCategories _inspireMapCategories;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public InspireMapCategories InspireMapCategories
        {
            get { return _inspireMapCategories; }
            set { _inspireMapCategories = value; }
        }

        private InspireMapLocationCollection _inspireMapLocations = new InspireMapLocationCollection();
        public InspireMapLocationCollection InspireMapLocations
        {
            get { return _inspireMapLocations; }
            set { _inspireMapLocations = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool ShowTraffic { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string MapStyle { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool ShowBuildings { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool ShowBuildingTextures { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool Show3DCursor { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool ShowTouchPanel { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool ShowMapControls { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool ShowMapOnly { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool ShowPrintIcon { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool AutoAdvance { get; set; }

        public MapContentControl()
        {
            LoadedEventManager.AddListener(this, this);
        }

        public MapContentControl(InspireMapLocation home, InspireMapCategories inspireMapCategories, bool showTraffic, string mapStyle, bool showBuildings, bool showBuildingTextures, bool show3DCursor, bool showTouchPanel, bool showMapControls, bool showMapOnly, bool showPrintIcon, bool autoAdvance)
            : this()
        {
            Home = home;
            InspireMapCategories = inspireMapCategories;
            ShowTraffic = showTraffic;
            MapStyle = mapStyle;
            ShowBuildings = showBuildings;
            ShowBuildingTextures = showBuildingTextures;
            Show3DCursor = show3DCursor;
            ShowTouchPanel = showTouchPanel;
            ShowMapControls = showMapControls;
            ShowMapOnly = showMapOnly;
            ShowPrintIcon = showPrintIcon;
            AutoAdvance = autoAdvance;
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                MapContentControl_Loaded(sender, e);
                return true;
            }
            //else if (managerType == typeof(DispatcherTimerTickEventManager))
            //{
            //    FlightContentControl_DispatcherTick(sender, e);
            //    return true;
            //}
            return false;
        }

        public void Dispose()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                //if (_dispatcherTimer != null)
                //    _dispatcherTimer.Stop();

                if (Content is IDisposable)
                    ((IDisposable)Content).Dispose();
                ClearValue(ContentProperty);
            }));
        }

        private void MapContentControl_Loaded(object sender, EventArgs eventArgs)
        {
            if (!isLoaded)
            {
                if (IsVisible || InspireApp.IsPlayer || InspireApp.IsPreviewMode)
                    InitializeMap();
                isLoaded = true;
            }
        }

        internal void InitializeMap()
        {
            Content = new MapControl(Home, InspireMapCategories, ShowTraffic, MapStyle, ShowBuildings, ShowBuildingTextures, Show3DCursor, ShowTouchPanel, ShowMapControls, ShowMapOnly, ShowPrintIcon, AutoAdvance);
        }
    }
}
