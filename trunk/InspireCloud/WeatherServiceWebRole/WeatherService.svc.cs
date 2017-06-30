using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WeatherService.DataContracts;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Weather" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Weather.svc or Weather.svc.cs at the Solution Explorer and start debugging.
    public class WeatherService : IWeatherService
    {        
        public List<Location> QueryLocations(string query)
        {
            var provider = new WeatherProvider();
            var locations =  provider.QueryLocationsV2(query);
            return locations;
        }

        public WeatherReport GetLatestWeatherReport(Location location, UnitsSystems us)
        {
            var provider = new WeatherProvider();
            var response = provider.GetLatestWeatherReportV2(location, us);
            return response;
        }       

    }
}
