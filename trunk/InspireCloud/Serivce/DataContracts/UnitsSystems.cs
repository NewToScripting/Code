using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace WeatherService.DataContracts
{
    [DataContract]
    public enum UnitsSystems : int
    {
        Imperial = 0,
        Metric = 1
    }
}