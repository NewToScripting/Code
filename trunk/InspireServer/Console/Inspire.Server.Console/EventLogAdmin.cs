using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Inspire.Server.Console
{
    public class EventLogAdmin
    {
        static public IEnumerable getLog()
        {
            System.Diagnostics.EventLog log = new System.Diagnostics.EventLog("Application");

            var query = from EventLogEntry el in log.Entries
                        //where el.Source == "Inspire Servc"
                        orderby el.TimeGenerated descending
                        select new
                        {
                            Time = el.TimeGenerated,
                            Source = el.Source,
                            Message = el.Message
                        };

            return query.ToList();
        }
    }
}
