using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;
using System.Configuration;
using System.IO;
using Inspire.Display.Service.SlideFileServiceReference;
using Inspire.Display.Service.ScheduledSlideServiceReference;
using Inspire.Display.Service.ServerCommunication;
using Inspire.Display.Service.XML;

namespace Inspire.Display.Service.BusinessLogic
{
    public class UtilityLogic
     {
        /// <summary>
        /// Get New Slides Needed
        /// </summary>
        /// <param name="schedules"></param>
        static public List<string> GetNewSlidesNeeded(Schedules schedules)
        {
            List<string> scheduleSlideIds = new List<string>();
            List<string> folderSlideIds = new List<string>();
            List<string> addSlideIds = new List<string>();

            foreach (Schedule sched in schedules)
            {
                foreach (ScheduledSlide schedSlide in ScheduledSlideServiceProxy.GetScheduledSlides(sched.GUID))
                {
                    scheduleSlideIds.Add(schedSlide.OriginalSlideID);
                }
            }

            folderSlideIds = SlideFolderAccess.GetFoldersinSlidesFolder();

            foreach (string slide in scheduleSlideIds)
            {
                if (!folderSlideIds.Contains(slide.ToUpper()))
                {
                    addSlideIds.Add(slide);
                }

            }

            return addSlideIds;

        }

        /// <summary>
        /// Delete unused files from slides folder
        /// </summary>
        /// <param name="schedules"></param>
        static public void DeleteUnusedFiles(Schedules schedules)
        {
            List<string> scheduleSlideIds = new List<string>();
            List<string> folderSlideIds = new List<string>();
            List<string> removeSlideIds = new List<string>();

            foreach (Schedule sched in schedules)
            {
                foreach (ScheduledSlide schedSlide in ScheduledSlideServiceProxy.GetScheduledSlides(sched.GUID))
                {
                    scheduleSlideIds.Add(schedSlide.OriginalSlideID);
                }
            }

            folderSlideIds = SlideFolderAccess.GetFoldersinSlidesFolder();

            foreach (string slide in folderSlideIds)
            {
                if (!scheduleSlideIds.Contains(slide.ToUpper()))
                {
                    removeSlideIds.Add(slide);
                }

            }

            //Delete Any unused files
            SlideFolderAccess.DeleteUnusedSlides(removeSlideIds);

        }

        /// <summary>
        /// Write schedules to XML
        /// </summary>
        /// <param name="schedules"></param>
        static public void WriteSchedules(XML.Schedules schedules)
        {
            try
            {
                       
                ////Get schedules from server
                if (schedules != null)
                {
                    SlideFolderAccess.WriteScheduleToXML(schedules);
                }
                else
                    EventLogger.Log("Schedule list was null", EventLogEntryType.Warning);
            
            }
            catch (Exception ex)
            {

                EventLogger.Log("Error Writing Schedules to XML :" + ex.Message, EventLogEntryType.Error);
            }
            
            //Write schedules to local XML file

        }

        /// <summary>
        /// Get slide list
        /// </summary>
        /// <param name="schedules"></param>
        /// <returns></returns>
        static public List<string> GetSlideList(Schedules schedules)
        {
            List<string> scheduleSlideIds = new List<string>();
            
            foreach (Schedule sched in schedules)
            {
                foreach (ScheduledSlide schedSlide in ScheduledSlideServiceProxy.GetScheduledSlides(sched.GUID))
                {
                    scheduleSlideIds.Add(schedSlide.OriginalSlideID);
                }
            }

            return scheduleSlideIds;

        }

       
    }//class
}//namespace
