using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inspire.Display.Service.ServerCommunication;


namespace Inspire.Display.Service.BusinessLogic
{
    public class ResourceAccessFasade
    {
        public static void GetSmartUpdate(string hostName)
        {
            bool updated;
            XML.Schedules scheds = new XML.Schedules();
            scheds = ScheduleServiceProxy.GetSchedules(hostName, false, out updated);
              
            //If schedules are null, you have no schedules or new updates

               if (updated)//if the schedules have been updated...write, if not, the schedules will be blank anyway
                {
                    foreach (string file in UtilityLogic.GetNewSlidesNeeded(scheds))
                    {
                        ProxySlideFile proxyFile = SlideFileProxy.GetSlideFile(file);
                        SlideFolderAccess.WriteSlideToFile(proxyFile.SlideFileStream, proxyFile.SlideFileSize, proxyFile.SlideFileID);
                        proxyFile.SlideFileStream.Dispose();
                    }
                    
                    UtilityLogic.WriteSchedules(scheds);

                }        
           

        }


        public static void GetHardUpdate(string hostName, bool deleteUnusedSlides)
        {
            bool updated;
            XML.Schedules scheds = new XML.Schedules();
            scheds = ScheduleServiceProxy.GetSchedules(hostName, true, out updated);

            //If schedules are null, you have no schedules or new updates

                foreach (string file in UtilityLogic.GetNewSlidesNeeded(scheds))
                {
                    ProxySlideFile proxyFile = SlideFileProxy.GetSlideFile(file);
                    SlideFolderAccess.WriteSlideToFile(proxyFile.SlideFileStream, proxyFile.SlideFileSize, proxyFile.SlideFileID);
                    proxyFile.SlideFileStream.Dispose();
                }

                UtilityLogic.WriteSchedules(scheds);

                if (deleteUnusedSlides) { UtilityLogic.DeleteUnusedFiles(scheds); }

        }
         



    }
}
