using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inspire.Server.Console.Events.Proxy.EventServiceReference;
using System.Diagnostics;

namespace Inspire.Server.Console.Events.Proxy
{
   public class EventsProxy
    {
       static public void LoadEvents()
       {
           try
           {
                EventServiceContractClient client = new EventServiceContractClient();
                client.LoadEvents();
           }
           catch
           {
               EventLogger.Log("Error connecting to events service to load events from file.", EventLogEntryType.Error);               
           }
           
       }


   }
}
