using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inspire.VOI.ResourceAccess;
using Inspire.VOI.Data;
using Inspire.VOI.Logging;
using InspireVisualOneConsoleInterface.EventsServiceReference;
using System.Configuration;

namespace InspireVisualOneConsoleInterface
{
    /// 
    /// Summary description for Class1.
    /// 
    class MainApp
    {
        /// 
        /// The main entry point for the application.
        ///     
        static void Main(string[] args)
        {
            Console.WriteLine("Inspire Digital Signage LLC...");
            Console.WriteLine("Loading...");
            LoadData();
        }

        private static void LoadData()
        {
            string log = ConfigurationManager.AppSettings["WriteToTextLog"];

            EventsServiceAccess eventAccess = new EventsServiceAccess();           

                try
                {
                    FileLogger logger = new FileLogger();
                    List<HospitalityEvent> events = new List<HospitalityEvent>();
                    VisualOneEventData item = new VisualOneEventData();

                    events = item.GetEvents();                    

                    eventAccess.TruncateEvents();

                    foreach (HospitalityEvent i in events)
                    {
                        eventAccess.AddEvent(i);
                        if(log == "true" || log == "True")
                        {
                            logger.Log(i);
                        }
                    }

                    Console.WriteLine(events.Count + " events written to log file.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occoured: " + ex.Message);
                }
            }//end function

        }//end class
    }//end namespace


