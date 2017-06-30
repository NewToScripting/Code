using Inspire.Server.ScheduleManager.DataAccess;
using Inspire.Server.ScheduleManager.DataContracts;
using System.Collections.Generic;


namespace Inspire.Server.ScheduleManager.BusinessLogic
{
    /// <summary>
    /// Schedule Access Fasade
    /// </summary>
    public class ScheduleAccessFasade
    {





        /// <summary>
        /// Get Schedules from hostname
        /// </summary>
        /// <param name="displayID"></param>
        /// <returns></returns>
        static public Schedules GetSchedulesFromHostname(string displayID, bool alwaysSendSchedule, out bool updated)
        {
            updated = false;
            Schedules schedules = new Schedules();

            ScheduleDatabaseAccess.UpdateDisplayActiveFlag(displayID);


            if (!alwaysSendSchedule)
            {
                if (ScheduleDatabaseAccess.CheckForLastUpdate(displayID))
                {   updated = true;
                schedules = ScheduleDatabaseAccess.GetSchedulesFromHostname(displayID);
                }
            }
            else
            {
                schedules = ScheduleDatabaseAccess.GetSchedulesFromHostname(displayID);
            }

            
            return schedules;
        }

        /// <summary>
        /// Get Schedules
        /// </summary>
        /// <param name="displayID"></param>
        /// <returns></returns>
       static public Schedules GetSchedules(string displayID)
       {
           return ScheduleDatabaseAccess.GetSchedules(displayID);
       }
        
       /// <summary>
       /// Get Current Schedules
       /// </summary>
       /// <param name="displayID"></param>
       /// <returns></returns>
       static public Schedules GeCurrentSchedules(string displayID)
       {
           return ScheduleDatabaseAccess.GetSchedules(displayID);
       }
        
        /// <summary>
       /// Get Single Schedule
        /// </summary>
        /// <param name="scheduleID"></param>
        /// <returns></returns>
       static public Schedule GetSingleSchedule(string scheduleID)
       {
           return ScheduleDatabaseAccess.GetSingleSchedule(scheduleID);
       }

        /// <summary>
       /// Get Displays In Schedule
        /// </summary>
        /// <param name="scheduleID"></param>
        /// <returns></returns>
       static public string[] GetDisplaysInSchedule(string scheduleID)
       {
           List<string> displayIDs = ScheduleDatabaseAccess.GetDisplaysInSchedule(scheduleID);
           return displayIDs.ToArray();
       }

        /// <summary>
       /// Add Schedule
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="displayIDs"></param>
       static public void AddSchedule(Schedule schedule, string[] displayIDs)
       {
           List<string> disps = new List<string>(displayIDs.Length);
           disps.AddRange(displayIDs);

           ScheduleDatabaseAccess.AddSchedule(schedule, disps);
       }

        /// <summary>
       /// Update Schedule
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="displayIDs"></param>
       static public void UpdateSchedule(Schedule schedule, string[] displayIDs)
       {
           List<string> disps = new List<string>(displayIDs.Length);
           disps.AddRange(displayIDs);

           ScheduleDatabaseAccess.UpdateSchedule(schedule, disps);
       }

        /// <summary>
       /// Delete Schedule
        /// </summary>
        /// <param name="scheduleID"></param>
       static public void DeleteSchedule(string schedule)
       {
           ScheduleDatabaseAccess.DeleteSchedule(schedule);
       }
        
    }
}
