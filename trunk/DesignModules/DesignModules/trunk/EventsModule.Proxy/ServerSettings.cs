using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
//using Inspire.Server.Proxy.ScheduleServiceReference;

namespace Inspire.Events.Proxy
{
    public class SeverSettings
    {
        static public EndpointAddress GetFeedsEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["HTTP"] +
                              ConfigurationManager.AppSettings["ServerHostName"] +
                              ConfigurationManager.AppSettings["FeedManagerConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

        static public EndpointAddress GetAliasEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["HTTP"] +
                              ConfigurationManager.AppSettings["ServerHostName"] +
                              ConfigurationManager.AppSettings["RoomManagerConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }



        static public EndpointAddress GetRoomsEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["HTTP"] +
                              ConfigurationManager.AppSettings["ServerHostName"] +
                              ConfigurationManager.AppSettings["RoomManagerConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

        static public EndpointAddress GetDirectionEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["HTTP"] +
                              ConfigurationManager.AppSettings["ServerHostName"] +
                              ConfigurationManager.AppSettings["DirectionManagerConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

        static public EndpointAddress GetTemplateEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["HTTP"] +
                              ConfigurationManager.AppSettings["ServerHostName"] +
                              ConfigurationManager.AppSettings["TemplateManagerConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }


    }
}