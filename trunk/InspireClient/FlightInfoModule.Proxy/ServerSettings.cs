using System;
using System.ServiceModel;
using System.Configuration;

namespace FlightInfoModule.Proxy
{
    public class ServerSettings
    {

        static ServerSettings()
        {

            
        }

        static public EndpointAddress GetFlightInfoServiceEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["FlightInfoConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

    }
}
