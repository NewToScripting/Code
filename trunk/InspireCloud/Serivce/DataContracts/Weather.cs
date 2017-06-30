using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace WeatherService.DataContracts
{
    [DataContract]
    public partial class Weather
    {
        public System.Nullable<double> Humidity { get; set; }

        public System.Nullable<double> Precipitation { get; set; }

        public Sky SkyCondition { get; set; }

        public UnitsSystems UnitsSystem { get; set; }

        public Wind WindVector { get; set; }
    }       

}