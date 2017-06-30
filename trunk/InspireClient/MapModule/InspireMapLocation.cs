using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using InfoStrat.VE;
using InfoStrat.VE.Windows7Touch;
using MapModule.MapsSearchService;

namespace MapModule
{
    [Serializable]
    public class InspireMapLocation
    {

        public InspireMapLocation(){}

        public InspireMapLocation(SearchResultBase result, string catStyle, double altitude, double minAlt, double  maxAlt)
        {
            Altitude = altitude;
            LocationName = result.Name;
            LocationDistance = result.Distance.ToString("#0.00"); ;
            Pitch = -90;
            MarkerPin = new InspirePushPin(result.LocationData.Locations[0].Latitude, result.LocationData.Locations[0].Longitude, 0d, maxAlt, minAlt, catStyle, LocationName, altitude, string.Empty);
            if(result is BusinessSearchResult)
            {
                var busRes = result as BusinessSearchResult;
                if (busRes.Address != null) Address = new MapAddress(busRes.Address);
                PhoneNumber = busRes.PhoneNumber;
                RatingCount = busRes.RatingCount;
                UserRating = busRes.UserRating/10;
                ReviewCount = busRes.ReviewCount;
                if (busRes.Website != null) Website = busRes.Website.ToString();
            }
        }

        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool ShowPriceRating { get; set;}
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public InspirePushPin MarkerPin { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public double Altitude { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public double Yaw { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public double Pitch { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public double Roll { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string LocationName { get; set; }

        private string _locationDescription;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string LocationDescription
        {
            get
            {
                return Address != null ? Address.FormattedAddress : _locationDescription;
            }
            set { _locationDescription = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string LocationDistance { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string CategoryName { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string PreferedModeOfTravel { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public double PriceRating { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public double UserRating { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int RatingCount { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int ReviewCount { get; set; }
        //public Collection<string> Tags { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool IsHome { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool MarkerVisible { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string PhoneNumber { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MapAddress Address { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string Website { get; set; }
    
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal UIElement GetMarkerContent()
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = LocationName;
            textBlock.Foreground = Brushes.White;
            textBlock.Effect = new DropShadowEffect();
            textBlock.FontSize = 20;
            textBlock.Margin = new Thickness(5);
            return textBlock;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void AddMarker(Win7TouchVEPushPin marker, string categoryStyle, string markerName, double flyToAltitude, string markerDescription)
        {
            marker.Click += MarkerPin_Click;
            MarkerPin = InspirePushPin.GetInspireMarker(marker, categoryStyle, markerName, flyToAltitude, markerDescription);
            //MarkerPin.Click += new EventHandler<InfoStrat.VE.VEPushPinClickedEventArgs>(MarkerPin_Click);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        void MarkerPin_Click(object sender, InfoStrat.VE.VEPushPinClickedEventArgs e)
        {
            VEMapManager.FlyTo(InspirePushPin.GetMarkerPin(MarkerPin), Pitch, Yaw, Altitude);
        }
    }
}
