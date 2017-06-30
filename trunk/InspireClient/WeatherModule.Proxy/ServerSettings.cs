using System;
using System.Configuration;
using System.ServiceModel;

namespace WeatherModule.Proxy
{
    public class ServerSettings
    {
        static ServerSettings()
        {
            
        }

        static public EndpointAddress GetWeatherServiceEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["WeatherServiceConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }
    }
}
