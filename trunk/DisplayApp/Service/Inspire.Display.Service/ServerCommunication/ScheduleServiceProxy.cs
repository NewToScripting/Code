using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inspire.Display.Service.ScheduleServiceReference;
using System.Configuration;
using System.ServiceModel;
using Inspire.Display.Service.XML;

namespace Inspire.Display.Service.ServerCommunication
{
    public class ScheduleServiceProxy
    {
        public static XML.Schedules GetSchedules(string hostname, bool alwaysUpdateSchedule, out bool updated)
        {
            string uri = ConfigurationManager.AppSettings["HttpType"] + ConfigurationManager.AppSettings["Servername"] + ConfigurationManager.AppSettings["ScheduleService"];
            ScheduleServiceReference.Schedules proxyscheds = new ScheduleServiceReference.Schedules();
            XML.Schedules xmlscheds = new XML.Schedules();

            ServiceManagerServiceContractClient client = new ServiceManagerServiceContractClient();
            var endPoint = new EndpointAddress(uri);
            client.Endpoint.Address = endPoint;

            proxyscheds = client.GetSchedulesFromHostName(alwaysUpdateSchedule, hostname, out updated);

            xmlscheds = ScheduleTranslator.Translate(proxyscheds);

            return xmlscheds;
        }

    }
}
