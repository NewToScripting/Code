using System;
using System.Configuration;
using System.ServiceModel;

namespace Inspire.Server.Proxy
{
    public class SeverSettings
    {

        static public EndpointAddress GetSettingsEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["HTTP"] + ServerSettings.ConfigServer +
                              ConfigurationManager.AppSettings["SettingsServiceConfig"]; //ConfigurationManager.AppSettings["ServerHostName"]

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }
        
       static public EndpointAddress GetDisplayEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["HTTP"] + ServerSettings.ConfigServer +
                              ConfigurationManager.AppSettings["DisplayManagerConfig"]; //ConfigurationManager.AppSettings["ServerHostName"]

           Uri uri = new Uri(endpoint);
           return new EndpointAddress(uri);
        }

       static public EndpointAddress GetGroupEndpoint()
       {
           string endpoint = ConfigurationManager.AppSettings["HTTP"] + ServerSettings.ConfigServer +
                             ConfigurationManager.AppSettings["GroupManagerConfig"];

           Uri uri = new Uri(endpoint);
           return new EndpointAddress(uri);
       }
       
        static public EndpointAddress GetPropertyEndpoint()
       {
           string endpoint = ConfigurationManager.AppSettings["HTTP"] + ServerSettings.ConfigServer +
                             ConfigurationManager.AppSettings["PropertyManagerConfig"];

           Uri uri = new Uri(endpoint);
           return new EndpointAddress(uri);
       }
        
        static public EndpointAddress GetScheduledSlideEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["HTTP"] + ServerSettings.ConfigServer +
                              ConfigurationManager.AppSettings["ScheduledSlideManagerConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

        static public EndpointAddress GetSlideEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["HTTP"] + ServerSettings.ConfigServer +
                              ConfigurationManager.AppSettings["SlideManagerConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

        static public EndpointAddress GetSlideFileEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["HTTP"] + ServerSettings.ConfigServer +
                              ConfigurationManager.AppSettings["SlideFileManagerConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

        static public EndpointAddress GetScheduleEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["HTTP"] + ServerSettings.ConfigServer +
                              ConfigurationManager.AppSettings["ScheduleManagerConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

        static public EndpointAddress GetUserEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["HTTP"] + ServerSettings.ConfigServer +
                              ConfigurationManager.AppSettings["UserManagerConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

        static public EndpointAddress GetDisplayAdminEndpoint()
        {
            string endpoint = ConfigurationManager.AppSettings["HTTP"] + ServerSettings.ConfigServer +
                              ConfigurationManager.AppSettings["DisplayAdminConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

    }
}