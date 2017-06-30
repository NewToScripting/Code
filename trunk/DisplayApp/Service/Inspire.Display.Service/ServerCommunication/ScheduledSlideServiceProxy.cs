using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inspire.Display.Service.ScheduledSlideServiceReference;
using System.Configuration;
using System.ServiceModel;


namespace Inspire.Display.Service.ServerCommunication
{
    class ScheduledSlideServiceProxy
    {

        public static ScheduledSlides GetScheduledSlides(string scheduleID)
        {
            string uri = ConfigurationManager.AppSettings["HttpType"] + ConfigurationManager.AppSettings["Servername"] + ConfigurationManager.AppSettings["ScheduleSlideService"];

            ScheduledSlides scheduledSlides = new ScheduledSlides();
            ScheduledSlideManagerServiceContractClient client = new ScheduledSlideManagerServiceContractClient();
            
            var endPoint = new EndpointAddress(uri);
            client.Endpoint.Address = endPoint;                

            scheduledSlides = client.GetScheduledSlidesNoThumb(scheduleID);

            return scheduledSlides;
        }

    }
}
