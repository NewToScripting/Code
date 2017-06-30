using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace WeatherService.DataContracts
{
    [DataContract]
    public partial class Wind 
    {
        public WindDirections Direction { get; set; }

        public System.Nullable<double> Speed { get; set; }
       
    }
}