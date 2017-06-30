using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using Inspire.Server.DisplayAdmin.BusinessEntities;
using Inspire.Server.DisplayAdmin.ServiceReference1;
using System.Configuration;
using System.IO;
using Inspire.Server.Common;

namespace Inspire.Server.DisplayAdmin.DataAccess
{
    public class DisplaysProxy
    {

        /// <summary>
        /// Update Displays 
        /// </summary>
        /// <param name="displayHostNames"></param>
        static public void UpdateDisplays(List<string> displayHostNames)
        {
            foreach (string hostName in displayHostNames)
            {
                EventLogger.Write("Sending update command to " + hostName, EventLogEntryType.Information);

                try
                {
                    string uri = ConfigurationManager.AppSettings["HttpType"] + hostName + ConfigurationManager.AppSettings["DisplayService"];
                    var client = new DisplayServiceContractClient();

                    var endPoint = new EndpointAddress(uri);
                    client.Endpoint.Address = endPoint;

                    client.UpdateDisplay();
                    
        //            List<string> fileNames = GetFileNames(client, hostName);

        //            foreach (string file in fileNames)
        //            {
        //                SendFile(client, file);
        //            }

        //            SendScheduleFile(client, hostName);

        //            ClearUnusedFiles(client, hostName);

                }
                catch (Exception e)
                {
                    EventLogger.Write("Error sending update to " + hostName + Environment.NewLine + @"Please confirm the display is available and/or check connectivity between display and server." + e.Message, EventLogEntryType.Error);
                }

           }

        }

        ///// <summary>
        ///// Ping displays 
        ///// </summary>
        ///// <param name="displayHostNames"></param>
        //static public void PingDisplays(List<string> displayHostNames)
        //{
        //    foreach (string hostName in displayHostNames)
        //    {




                //try
                //{
                //    string uri = ConfigurationManager.AppSettings["HttpType"] + hostName + ConfigurationManager.AppSettings["DisplayService"];
                //    var client = new DisplayServiceContractClient();

                //    var endPoint = new EndpointAddress(uri);
                //    client.Endpoint.Address = endPoint;

                //    client.StayAlive();

                //    string displayID = DisplayDatabaseAccess.GetDisplayID(hostName);
                //    DisplayDatabaseAccess.UpdateDisplayActiveFlag(displayID, 1, DateTime.Now);
                                     
                //}
                //catch(Exception e)
                //{
                //    string displayID = DisplayDatabaseAccess.GetDisplayID(hostName);
                //    DisplayDatabaseAccess.UpdateDisplayActiveFlag(displayID, 0, DateTime.Now);
                //    EventLogger.Write("Error sending ping to " + hostName + Environment.NewLine + @"Please confirm the display is available and/or check connectivity between display and server." + e.Message, EventLogEntryType.Error);
        //        //}
        //    }
        //}



        // <summary>
        // Get filenames from display folder
        // </summary>
        // <param name="client"></param>
        // <param name="hostName"></param>
        // <returns>File names</returns>
        //static private List<string> GetFileNames(DisplayServiceContractClient client, string hostName)
        //{
        //    List<string> fileNameList = new List<string>();

        //    try
        //    {
        //        Inspire.Server.DisplayAdmin.ServiceReference1.Schedules schedules = ScheduleDatabaseAccess.GetSchedules(hostName);
        //        List<string> fileNameArray = client.SendScheduleList(schedules);
        //        fileNameList = fileNameArray.ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        EventLogger.Write("Error getting file names from " + hostName + " " + e.Message, EventLogEntryType.Error);
        //    }

        //    return fileNameList;

        //}


        ///// <summary>
        ///// Send schedule to display folder
        ///// </summary>
        ///// <param name="client"></param>
        ///// <param name="hostName"></param>
        //static private void SendScheduleFile(DisplayServiceContractClient client, string hostName)
        //{
        //    try
        //    {
        //        Inspire.Server.DisplayAdmin.ServiceReference1.Schedules schedules = ScheduleDatabaseAccess.GetSchedules(hostName);
                
        //        if (schedules.Count > 0)
        //        {
        //        client.SendSchedule(schedules);
        //        }
        //    }
        //    catch (Exception e )
        //    {
        //        EventLogger.Write("Error sending schedule file to " + hostName + " " + e.Message, EventLogEntryType.Error);
        //    }
        //}

        /////// <summary>
        /////// Send individual file
        /////// </summary>
        /////// <param name="client"></param>
        /////// <param name="fileName"></param>

        //static private void SendFile(DisplayServiceContractClient client, string fileName)
        //{
        //    try
        //    {
        //        SlideFile slideFile = SlideDatabaseAccess.GetSlideFile(fileName);
        //        Stream stream = new MemoryStream(slideFile.File);
        //        client.SendSlide(slideFile.GUID, slideFile.File.Length, stream);
        //    }
        //    catch (Exception e)
        //    {
        //        EventLogger.Write("Error sending slide file " + fileName + " " + e.Message, EventLogEntryType.Error);
        //    }


        //}


        ///// <summary>
        ///// Clear Unused Files
        ///// </summary>
        ///// <param name="client"></param>
        ///// <param name="fileName"></param>
        ///// <summary>
        //static private void ClearUnusedFiles(DisplayServiceContractClient client, string hostName)
        //{
        //    try
        //    {
        //        Inspire.Server.DisplayAdmin.ServiceReference1.Schedules schedules = ScheduleDatabaseAccess.GetSchedules(hostName);
        //        client.ClearNonScheduledFiles(schedules);
               
        //    }
        //    catch (Exception e)
        //    {
        //        EventLogger.Write("Error clearing unused files from " + hostName + " " + e.Message, EventLogEntryType.Error);
        //    }
                       
        //}


        
    }//class
}//namespace


