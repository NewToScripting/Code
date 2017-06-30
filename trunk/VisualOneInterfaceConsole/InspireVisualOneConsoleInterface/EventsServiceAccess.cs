using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InspireVisualOneConsoleInterface.EventsServiceReference;
using System.Configuration;

namespace Inspire.VOI.ResourceAccess
{
    public class EventsServiceAccess
    {
        public string EventDefinitionID { get; set; }

        public EventsServiceAccess()
        {        
            EventDefinitionID = ConfigurationManager.AppSettings["EventDefinitionID"];
        }       

        public void AddEvent(HospitalityEvent item)
        {
            EventServiceContractClient client = new EventServiceContractClient();
            client.AddEvent(item);
        }
        public void TruncateEvents()
        {
            EventServiceContractClient client = new EventServiceContractClient();
            client.TruncateEvents(EventDefinitionID);
        }


    }
}
