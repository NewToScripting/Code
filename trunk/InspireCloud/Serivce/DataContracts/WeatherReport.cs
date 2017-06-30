using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace WeatherService.DataContracts
{
    [DataContract]
    public class WeatherReport
    {
        public List<WeatherRange> Forecast { get; set; }

        public WeatherPoint LatestWeather { get; set; }

        public Location Location { get; set; }

        public int SkyCode { get; set; }

        public UnitsSystems UnitsSystem { get; set; }

    }
}