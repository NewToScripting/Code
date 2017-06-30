using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WeatherService.DataContracts;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWeather" in both code and config file together.
    [ServiceContract]
    public interface IWeatherService
    {
        [OperationContract]      
        Location[] QueryLocations(string query);

        [OperationContract]    
        WeatherReport GetLatestWeatherReport(Location location, UnitsSystems us);

    }
}
