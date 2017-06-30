using System;
using System.Configuration;
using System.ServiceModel;

namespace MapModule
{
    public class ServerSettings
    {

        static ServerSettings()
        {


        }

        static public EndpointAddress GetMapSearchServiceEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["MapSearchServiceConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

    }
}
