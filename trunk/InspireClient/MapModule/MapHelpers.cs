using System;
using System.Collections.Generic;
using System.Linq;

namespace MapModule
{
    public static class MapHelpers
    {
        const double EarthRadiusInMiles = 3956.0;

        public static string DistanceInMilesString(InspireMapLocation Loc1, InspireMapLocation Loc2)
        {
            double dMiles = CalcDistance(Loc1.MarkerPin.Latitude, Loc1.MarkerPin.Longitude, Loc2.MarkerPin.Latitude, Loc2.MarkerPin.Longitude);
            return dMiles.ToString("#0.00");
;
        }

        public static double DistanceInMiles(InspireMapLocation Loc1, InspireMapLocation Loc2)
        {
            double dMiles = CalcDistance(Loc1.MarkerPin.Latitude, Loc1.MarkerPin.Longitude, Loc2.MarkerPin.Latitude, Loc2.MarkerPin.Longitude);
            return dMiles;
        }

        const double EarthRadiusInKilometers = 6367.0;
        static double ToRadian(double val) { return val * (Math.PI / 180); }
        static double DiffRadian(double val1, double val2) { return ToRadian(val2) - ToRadian(val1); }
        /// <summary> 
        /// Calculate the distance between two geocodes. Defaults to using Miles. 
        /// </summary> 
        static double CalcDistance(double lat1, double lng1, double lat2, double lng2)
        {
            return CalcDistance(lat1, lng1, lat2, lng2, GeoCodeCalcMeasurement.Miles);
        }
        /// <summary> 
        /// Calculate the distance between two geocodes. 
        /// </summary> 
        static double CalcDistance(double lat1, double lng1, double lat2, double lng2, GeoCodeCalcMeasurement m)
        {
            double radius = EarthRadiusInMiles;
            if (m == GeoCodeCalcMeasurement.Kilometers) { radius = EarthRadiusInKilometers; }
            return radius * 2 * Math.Asin(Math.Min(1, Math.Sqrt((Math.Pow(Math.Sin((DiffRadian(lat1, lat2)) / 2.0), 2.0) + Math.Cos(ToRadian(lat1)) * Math.Cos(ToRadian(lat2)) * Math.Pow(Math.Sin((DiffRadian(lng1, lng2)) / 2.0), 2.0)))));
        }

        public static InspireMapLocation FindInspireLocation(InspirePushPin pushPin, IEnumerable<InspireMapLocation> inspireMapLocations)
        {
            return inspireMapLocations.Where(inspireMapLocation => pushPin.Longitude == inspireMapLocation.MarkerPin.Longitude && pushPin.Latitude == inspireMapLocation.MarkerPin.Latitude).FirstOrDefault();
        }

        public static double CalculateAlt(string locationDistance)
        {
            double dbl;

            double.TryParse(locationDistance, out dbl);

            return dbl*3956.0;
        }
    }
    public enum GeoCodeCalcMeasurement : int
    {
        Miles = 0,
        Kilometers = 1
    }

}
