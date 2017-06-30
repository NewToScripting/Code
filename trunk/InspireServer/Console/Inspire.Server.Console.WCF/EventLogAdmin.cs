using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Inspire.Server.Console.Interface
{
    public class EventLogAdmin
    {
        /// <summary>
        /// Get Event Log
        /// </summary>
        /// <returns></returns>
        static public IEnumerable getLog()
        {
            try
            {
                System.Diagnostics.EventLog log = new System.Diagnostics.EventLog("Application");

                var query = from EventLogEntry el in log.Entries
                            where el.Source == "Inspire Server Service"
                            orderby el.TimeGenerated descending
                            select new
                            {
                                Time = el.TimeGenerated,
                                Source = el.Source,
                                Message = el.Message
                            };

                return query.ToList();
            }
            catch (Exception)
            {               
                return null;
            }
            
        }
    }
}
