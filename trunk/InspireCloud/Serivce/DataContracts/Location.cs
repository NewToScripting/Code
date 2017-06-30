using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace WeatherService.DataContracts
{    
        [DataContract]
        public class Location : INotifyPropertyChanged
        {
            public string City { get; set; }

            public string Country { get; set; }

            public string FullName { get; set; }

            public System.Nullable<double> Latitude { get; set; }

            public string LocationCode { get; set; }

            public System.Nullable<double> Longitude { get; set; }

            public string State { get; set; }

            public System.Nullable<int> ZipCode { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;

        
        }
}