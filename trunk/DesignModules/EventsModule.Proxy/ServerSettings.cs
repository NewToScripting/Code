﻿using System;
using System.Configuration;
using System.ServiceModel;
//using Inspire.Server.Proxy.ScheduleServiceReference;

namespace Inspire.Events.Proxy
{
    public class SeverSettings
    {
        public static string ConfigServer { get; private set; }
        public static TimeSpan LookAheadTime { get; private set; }
        public static TimeSpan LookBehindTime { get; private set; }
        public static int EventRefreshInterval { get; private set; }

        static SeverSettings()
        {

            int eventupdateInterval;

            try
            {
                Int32.TryParse(ConfigurationManager.AppSettings["EventRefreshInterval"], out eventupdateInterval);
                if (eventupdateInterval == 0)
                    eventupdateInterval = 5;
            }
            catch (Exception)
            {
                eventupdateInterval = 5;
            }

            EventRefreshInterval = eventupdateInterval;

            try
            {
                if (InspireApp.IsPlayer)
                    ConfigServer = ConfigurationManager.AppSettings["ServerHostName"];
                else
                    ConfigServer = ServerSettings.ConfigServer; //ConfigurationManager.AppSettings["ServerHostName"]; //section.Settings["ServerHostName"].Value;
            }
            catch (Exception)
            {
                ConfigServer = ConfigurationManager.AppSettings["ServerHostName"];
            }

            try
            {
                TimeSpan laTime;
                TimeSpan.TryParse(ConfigurationManager.AppSettings["LookAheadTime"], out laTime);
                LookAheadTime = laTime;
            }
            catch (Exception)
            {
                // Default to 1 hour if cannot read config
                LookAheadTime = new TimeSpan(1, 0, 0);
            }

            try
            {
                TimeSpan lbTime;
                TimeSpan.TryParse(ConfigurationManager.AppSettings["LookBehindTime"], out lbTime);
                LookBehindTime = lbTime;
            }
            catch (Exception)
            {
                // Default to not show expired events if cannot read behind
                LookBehindTime = new TimeSpan(0, 0, 0);
            }
        }

        static public EndpointAddress GetEventsEndpoint()
        {
            //string endpoint = "http://devserver2003/Inspire.Events/Svc/EventService.svc";
            string endpoint = ConfigurationManager.AppSettings["HTTP"] +
                              ConfigServer +
                              ConfigurationManager.AppSettings["EventManagerConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

        static public EndpointAddress GetRoomAliasEndpoint()
        {
            //string endpoint = "http://devserver2003/Inspire.Events/Svc/RoomService.svc";
            string endpoint = ConfigurationManager.AppSettings["HTTP"] +
                              ConfigServer +
                              ConfigurationManager.AppSettings["RoomManagerConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }



        static public EndpointAddress GetRoomsEndpoint()
        {
            //string endpoint = "http://devserver2003/Inspire.Events/Svc/RoomService.svc";
            string endpoint = ConfigurationManager.AppSettings["HTTP"] +
                              ConfigServer +
                              ConfigurationManager.AppSettings["RoomManagerConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

        static public EndpointAddress GetDirectionEndpoint()
        {
            //string endpoint = "http://devserver2003/Inspire.Events/Svc/DirectionService.svc";
            string endpoint = ConfigurationManager.AppSettings["HTTP"] +
                              ConfigServer +
                              ConfigurationManager.AppSettings["DirectionManagerConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

        static public EndpointAddress GetTemplateEndpoint()
        {
            //string endpoint = "http://devserver2003/Inspire.Events/Svc/TemplateService.svc";
            string endpoint = ConfigurationManager.AppSettings["HTTP"] +
                              ConfigServer +
                              ConfigurationManager.AppSettings["TemplateManagerConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

        static public EndpointAddress GetEventImageEndpoint()
        {
            //string endpoint = "http://devserver2003/Inspire.Events/Svc/ImageService.svc";
            string endpoint = ConfigurationManager.AppSettings["HTTP"] +
                              ConfigServer +
                              ConfigurationManager.AppSettings["EventImageConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }

        static public EndpointAddress GetGroupEndpoint()
        {
            //string endpoint = "http://devserver2003/Inspire.Events/Svc/ImageService.svc";
            string endpoint = ConfigurationManager.AppSettings["HTTP"] +
                              ConfigServer +
                              ConfigurationManager.AppSettings["GroupConfig"];

            Uri uri = new Uri(endpoint);
            return new EndpointAddress(uri);
        }
    }
}