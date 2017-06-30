using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace WeatherService.DataContracts
{
    [DataContract]
    public partial class Sky
    {
        public string SkyCondition { get; set; }

        public string SkyImage { get; set; }

    }
}