using System;
using System.ComponentModel;
using InfoStrat.VE;
using InfoStrat.VE.Windows7Touch;

namespace MapModule
{
    [Serializable]
    public class InspirePushPin
    {
        public InspirePushPin(){}

        public InspirePushPin(double latitude, double longitude, double altitude, double maxAltitude, double minAltitude, string categoryStyle, string markerName, double flyToAltitude, string markerDescription)
        {
            Longitude = longitude;
            Latitude = latitude;
            MaxAltitude = maxAltitude;
            MinAltitude = minAltitude;
            Altitude = altitude;
            CategoryStyle = categoryStyle;
            Name = markerName;
            Description = markerDescription;
            FlyToAltitude = flyToAltitude;
        }

        internal static Win7TouchVEPushPin GetMarkerPin(InspirePushPin markerPin)
        {
            return new Win7TouchVEPushPin
                              {
                                  Latitude = markerPin.Latitude,
                                  Longitude = markerPin.Longitude,
                                  MinAltitude = markerPin.MinAltitude,
                                  MaxAltitude = markerPin.MaxAltitude,
                                  Altitude = markerPin.Altitude,
                                  DataContext = markerPin
                              };
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public double MaxAltitude { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public double MinAltitude { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public double Longitude { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public double Latitude { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public double Altitude { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public double FlyToAltitude { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string CategoryStyle { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string Name { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string Description { get; set; }

        internal static InspirePushPin GetInspireMarker(Win7TouchVEPushPin marker, string categoryStyle, string markerName, double flyToAltitude, string markerDescription)
        {
            return new InspirePushPin(marker.LatLong.Latitude, marker.LatLong.Longitude, marker.Altitude, 99999999.0, 0d, categoryStyle, markerName, flyToAltitude, markerDescription);
        }
    }
}
