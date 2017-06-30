using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeetingSpaceService_TestHarness.Inspire.Server.Events;

namespace MeetingSpaceService_TestHarness
{
    public class InspireServerProxy
    {
        private EventServiceContractClient client;

        public InspireServerProxy()
        {
            client = new EventServiceContractClient();
        }

        public void AddEvents(HospitalityEvents events)
        {
            client.TruncateEvents(Guid.Empty.ToString());

            foreach( HospitalityEvent item in events)
            {
                client.AddEvent(item);              

            }
        }

    }
}
