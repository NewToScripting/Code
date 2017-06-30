using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace WeatherService.DataContracts
{
    [DataContract]
    public partial class WeatherRange : Weather
    {
        public System.DateTime EndTime { get; set; }

        public double HighTemperature { get; set; }

        public double LowTemperature { get; set; }

        public System.DateTime StartTime { get; set; }

    }
}