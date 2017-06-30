using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Media;
using MapModule.MapsSearchService;
using MapModule.RouteService;
using Microsoft.MapPoint.Rendering3D;


namespace MapModule
{
    public class MapRequestManager
    {
        private static List<LatLonAlt> lla;

        public static IEnumerable<InspireMapLocation> GetSubCategories(string category, string location, string catStyle, InspireMapLocation home)
        {
            int failCount = 0;
            bool communication;

            List<InspireMapLocation> inspireMapLocations = null;

            do
            {
                failCount++;
                try
                {
                    var sr = new SearchRequest();
                    var creds = new MapsSearchService.Credentials();
                    creds.ApplicationId = "AhUefm-E3MkDAWS8S6c5khSUvwpDdkZYpbV2dXVH-rttY1ikaGaUrZ6RrvBG89gE";

                    sr.Credentials = creds;

                    sr.StructuredQuery = new StructuredSearchQuery { Location = location, Keyword = category };

                    var serviceClient = new SearchServiceClient("MapSearchServiceEndpoint");

                    var searchRes = serviceClient.Search(sr);

                    var resSet = searchRes.ResultSets;

                    serviceClient.Close();
                    communication = true;
                    inspireMapLocations = (from searchResultSet in resSet
                                           from result in searchResultSet.Results
                                           select new InspireMapLocation(result, catStyle, home.Altitude, home.MarkerPin.MinAltitude, home.Altitude + 199000.0) { CategoryName = category, MarkerVisible = true }).ToList();
                }
                catch (Exception ex)
                {
                    communication = false;
                    Thread.Sleep(500); // wait a moment before trying again.
                }

            } while (!communication && failCount < 3);

            if(!communication)
                inspireMapLocations =  new List<InspireMapLocation>();

            return inspireMapLocations;
        }

        public static List<DirectionItem> GetDirections(InspireMapLocation startLoc, InspireMapLocation endLoc)
        {
            var directions = new List<DirectionItem>();

            try
            {
                var sr = new RouteRequest();
                var creds = new RouteService.Credentials();
                creds.ApplicationId = "Avp7SYneXYaK16woSX9Nwvb-DHvUn37o74XQazKCq-tBT3bSVKy0ZuMA6fvOPl8x";

                sr.Credentials = creds;

                sr.Options = new RouteOptions { Mode = TravelMode.Driving };

                sr.Waypoints = new[] { new Waypoint { Location = new RouteService.Location { Latitude = startLoc.MarkerPin.Latitude, Longitude = startLoc.MarkerPin.Longitude } }, new Waypoint { Location = new MapModule.RouteService.Location { Latitude = endLoc.MarkerPin.Latitude, Longitude = endLoc.MarkerPin.Longitude } } };

                var serviceClient = new RouteServiceClient("MapRouteServiceEndpoint");

                var searchRes = serviceClient.CalculateRoute(sr);

                serviceClient.Close();

                lla = new List<LatLonAlt>();

                Regex rx1 = new Regex(@"<[a-zA-Z\s:]+>");
                Regex rx2 = new Regex(@"</[a-zA-Z\s:]+>");


                int instructionCount = 1;
                // Traverse the legs, extracting the directions from each
                for (int i = 0; i < searchRes.Result.Legs.Count(); i++)
                {
                    // Iterate over the items in the current leg
                    foreach (ItineraryItem item in searchRes.Result.Legs[i].Itinerary)
                    {
                        Brush brush;

                        lla.Add(new LatLonAlt(item.Location.Latitude * Math.PI / 180.0, item.Location.Longitude * Math.PI / 180.0, 0));

                        if (instructionCount.Equals(1))
                            brush = new BrushConverter().ConvertFromString("Green") as SolidColorBrush;
                        else if (instructionCount == searchRes.Result.Legs[i].Itinerary.Count())
                            brush = new BrushConverter().ConvertFromString("Red") as SolidColorBrush;
                        else
                            brush = new BrushConverter().ConvertFromString("Blue") as SolidColorBrush;

                        directions.Add(new DirectionItem(instructionCount, rx2.Replace(rx1.Replace(item.Text, ""), ""), brush));
                        instructionCount++;
                    }
                }

                VEMapManager.AddRoute(lla);

                return directions;

                //  return rx2.Replace(rx1.Replace(directions.ToString(), ""), "");
            }
            catch (Exception)
            {
                //TODO: log
                return directions;
            }
            

        }
    }
}
