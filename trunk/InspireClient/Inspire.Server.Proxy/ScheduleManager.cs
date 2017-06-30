using System;
using System.Collections.Generic;
using Inspire.Server.Proxy.ScheduleServiceReference;

namespace Inspire.Server.Proxy
{
    /// <summary>
    /// Schedule Manager
    /// </summary>
    public class ScheduleManager
    {
        /// <summary>
        /// Get Schedules
        /// </summary>
        /// <param name="displayID"></param>
        /// <returns></returns>
        static public List<Schedule> GetSchedules(string displayID)
        { 
            List<Schedule> scheduleList = new List<Schedule>();
            try
            {
                var client = new ServiceManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetScheduleEndpoint();
                GetSchedulesRequestMessage request = new GetSchedulesRequestMessage();

                request.DisplayID = displayID;

                Schedules schedules = client.GetSchedules(request.DisplayID);

                foreach (ScheduleServiceReference.Schedule item in schedules)
                {
                    Schedule schedule = ScheduleTranslators.CommonScheduleOut(item);
                    scheduleList.Add(schedule);
                }
               
            }//try
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting schedules");
            }

        return scheduleList;
        }

        /// <summary>
        /// Get Single Schedule
        /// </summary>
        /// <param name="scheduleID"></param>
        /// <returns></returns>
        static public Schedule GetSingleSchedule(string scheduleID)
        {
            var commonSchedule = new Schedule();
            try
            {
                ServiceManagerServiceContractClient client = new ServiceManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetScheduleEndpoint();
                GetSingleSchedulesRequestMessage request = new GetSingleSchedulesRequestMessage();

                Inspire.Server.Proxy.ScheduleServiceReference.Schedule schedule = client.GetSingleSchedule(scheduleID);

                commonSchedule = ScheduleTranslators.CommonScheduleOut(schedule);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting single schedule");
            }
            
            return commonSchedule;

        }//function

        /// <summary>
        /// Get Displays In Schedule
        /// </summary>
        /// <param name="scheduleID"></param>
        /// <returns></returns>
        static public List<string> GetDisplaysInSchedule(string scheduleID)
        {
            List<string> displayList = null;
            try
            {
                ServiceManagerServiceContractClient client = new ServiceManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetScheduleEndpoint();
                GetDisplaysInScheduleRequestMessage request = new GetDisplaysInScheduleRequestMessage();

                string[] displayIDs = client.GetDisplaysInSchedule(scheduleID);

                displayList = new List<string>(displayIDs.Length);
                displayList.AddRange(displayIDs);

            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting displays in schedule");
            }

            return displayList;
            
        }

        /// <summary>
        /// Add Schedule
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="displayIDs"></param>
        static public void AddSchedule(Schedule schedule, List<string> displayIDs)
        {
            try
            {
                ServiceManagerServiceContractClient client = new ServiceManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetScheduleEndpoint();
                AddScheduleRequestMessage request = new AddScheduleRequestMessage();

                ScheduleServiceReference.Schedule sched = ScheduleTranslators.ServiceScheduleOut(schedule);

                client.AddSchedule(displayIDs.ToArray(), sched);

            }//try
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while adding display");
            }
          
        }

        /// <summary>
        /// Update Schedule
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="displayIDs"></param>
        static public void UpdateSchedule(Schedule schedule, List<string> displayIDs)
        {
            DeleteSchedule(schedule.GUID);
            AddSchedule(schedule, displayIDs);

        }

        static public void DeleteSchedule(string scheduleID)
        {
            try
            {
                ServiceManagerServiceContractClient client = new ServiceManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetScheduleEndpoint();
                DeleteScheduleRequestMessage request = new DeleteScheduleRequestMessage();

                client.DeleteSchedule(scheduleID);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while deleting display");
            }
           

        }








    }
}
