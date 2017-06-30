using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Diagnostics;
using Inspire.Server.ScheduleManager.DataContracts;
using Inspire.Server.Common;
using Inspire.Server.ScheduledSlideManager.DataAccess;
using Inspire.Server.ScheduledSlideManager.DataContracts;

namespace Inspire.Server.ScheduleManager.DataAccess
{
    /// <summary>
    /// Schedule Database Access
    /// </summary>
    public class ScheduleDatabaseAccess
    {
        /// <summary>
        /// Get schedules from hostname
        /// </summary>
        /// <param name="hostName"></param>
        /// <returns></returns>
        static public Schedules GetSchedulesFromHostname(string hostName)
        {
            double doubleScheduleDaysForward = -7; //default

            try
            {
                string strScheduleDaysForward = ConfigurationManager.AppSettings["ScheduleDaysForward"];
                doubleScheduleDaysForward = Convert.ToDouble(strScheduleDaysForward);
                doubleScheduleDaysForward = doubleScheduleDaysForward * -1; //Must be negative because it must be added to DateTime.Now
            }
            catch
            {
                EventLogger.LogAndThrowFault("Error Getting ScheduleDaysForward key from config during GetSchedules", "");
            }

            Schedules schedules = new Schedules();


            try
            {
            using (SqlCeConnection conn = CommonDataConnection.GetConnection())
            {
                string sql = ScheduleSql.GetSchedulesFromHostname();

                conn.Open();
                SqlCeCommand cmd = new SqlCeCommand(sql, conn);
          

                //GUID
                cmd.Parameters.Add("@HostName", SqlDbType.NVarChar, 200);
                cmd.Parameters["@HostName"].Value = hostName;

                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar, 200);
                cmd.Parameters["@StartDate"].Value = DateTime.Now.AddDays(doubleScheduleDaysForward);

                SqlCeDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Schedule schedule = new Schedule();

                    schedule.GUID = reader["GUID"] as string;
                    schedule.Name = reader["Name"] as string;
                    schedule.Type = reader["Type"] as string;

                    int? days = reader["Days"] as int?;

                    if (days != null)
                        schedule.Days = (int)days;
                    else
                        schedule.Days = 0;

                    schedule.Mode = reader["Mode"] as string;


                    string startTime = reader["StartTime"].ToString();

                    if (!string.IsNullOrEmpty(startTime))
                        schedule.StartTime = DateTime.Parse(startTime);

                    string startDate = reader["StartDate"].ToString();

                    if (!string.IsNullOrEmpty(startDate))
                        schedule.StartDate = DateTime.Parse(startDate);

                    string endTime = reader["EndTime"].ToString();

                    if (!string.IsNullOrEmpty(endTime))
                        schedule.EndTime = DateTime.Parse(endTime);

                    string endDate = reader["EndDate"].ToString();

                    if (!string.IsNullOrEmpty(endDate))
                        schedule.EndDate = DateTime.Parse(endDate);


                    schedule.Priority = Convert.ToInt32(reader["Priority"].ToString());
                   
                    schedules.Add(schedule);

                }//end while

                conn.Close();               

            }//using
            }

            catch(Exception e)
            {
                EventLogger.LogAndThrowFault("Server failed to get schedules from database." + Environment.NewLine + e.InnerException, "");
            }

         return schedules;

        }//end function



        /// <summary>
        /// Get Current Schedules
        /// </summary>
        /// <param name="displayID"></param>
        /// <returns></returns>
        static public Schedules GetrentCurSchedules(string displayID)
        {
            Schedules schedules = new Schedules();
            string sql = ScheduleSql.GetrentCurSchedules();

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                   

                    //GUID

                    cmd.Parameters.Add("@DisplayID", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@DisplayID"].Value = displayID;

                    SqlCeDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Schedule schedule = new Schedule();

                        schedule.GUID = reader["GUID"] as string;
                        schedule.Name = reader["Name"] as string;
                        schedule.Type = reader["Type"] as string;

                        int? days = reader["Days"] as int?;

                        if (days != null)
                            schedule.Days = (int)days;
                        else
                            schedule.Days = 0;

                        schedule.Mode = reader["Mode"] as string;


                        string startTime = reader["StartTime"].ToString();

                        if (!string.IsNullOrEmpty(startTime))
                            schedule.StartTime = DateTime.Parse(startTime);

                        string startDate = reader["StartDate"].ToString();

                        if (!string.IsNullOrEmpty(startDate))
                            schedule.StartDate = DateTime.Parse(startDate);

                        string endTime = reader["EndTime"].ToString();

                        if (!string.IsNullOrEmpty(endTime))
                            schedule.EndTime = DateTime.Parse(endTime);

                        string endDate = reader["EndDate"].ToString();

                        if (!string.IsNullOrEmpty(endDate))
                            schedule.EndDate = DateTime.Parse(endDate);


                        schedule.Priority = Convert.ToInt32(reader["Priority"].ToString());

                        schedules.Add(schedule);

                    }//end while

                    conn.Close();


                }//using
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Schedules from database.");
            }

            return schedules;
        }//end function

        
        /// <summary>
        /// Get Schedules
        /// </summary>
        /// <param name="displayID"></param>
        /// <returns></returns>
        static public Schedules GetSchedules(string displayID)
        { 
            Schedules schedules = new Schedules();
            string sql = ScheduleSql.GetSchedules();
            
            try
            {
                using(SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                 conn.Open();

                SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                
                //GUID
               
                cmd.Parameters.Add("@DisplayID", SqlDbType.NVarChar, 200);
                cmd.Parameters["@DisplayID"].Value = displayID;

                SqlCeDataReader reader = cmd.ExecuteReader();
                    
                while (reader.Read())
                {
                    Schedule schedule = new Schedule();

                    schedule.GUID = reader["GUID"] as string;
                    schedule.Name = reader["Name"] as string;
                    schedule.Type = reader["Type"] as string;
                        
                    int? days = reader["Days"] as int?;

                    if (days != null)
                        schedule.Days = (int) days;
                    else
                        schedule.Days = 0;

                    schedule.Mode = reader["Mode"] as string;
                    
                    
                        string startTime = reader["StartTime"].ToString();

                    if (!string.IsNullOrEmpty(startTime))
                        schedule.StartTime = DateTime.Parse(startTime);

                        string startDate = reader["StartDate"].ToString();

                    if (!string.IsNullOrEmpty(startDate))
                        schedule.StartDate = DateTime.Parse(startDate);

                        string endTime = reader["EndTime"].ToString();

                    if (!string.IsNullOrEmpty(endTime))
                        schedule.EndTime = DateTime.Parse(endTime);

                        string endDate = reader["EndDate"].ToString();

                    if (!string.IsNullOrEmpty(endDate))
                        schedule.EndDate = DateTime.Parse(endDate);


                    schedule.Priority = Convert.ToInt32(reader["Priority"].ToString());

                  schedules.Add(schedule);

                }//end while

                conn.Close();
               

              }//using
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Schedules from database.");
            }

             return schedules;
        }//end function



        /// <summary>
        /// Get Single Schedule
        /// </summary>
        /// <param name="scheduleID"></param>
        /// <returns></returns>
        static public Schedule GetSingleSchedule(string scheduleID)
        {
            Schedule schedule = new Schedule();
            
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmd = new SqlCeCommand("SELECT Sch.[GUID],Sch.[Name],Sch.[Type],Sch.StartTime,Sch.StartDate,Sch.EndTime,Sch.EndDate,Sch.Priority,Sch.Mode,Sch.Days FROM Schedule Sch WHERE Sch.[GUID] = @ScheduleID", conn);
                 
                    //GUID
                    cmd.Parameters.Add("@ScheduleID", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@ScheduleID"].Value = scheduleID;

                    SqlCeDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        schedule.GUID = reader["GUID"] as string;
                        schedule.Name = reader["Name"] as string;
                        schedule.Type = reader["Type"] as string;

                        int? days = reader["Days"] as int?;

                        if (days != null)
                            schedule.Days = (int)days;
                        else
                            schedule.Days = 0;

                        schedule.Mode = reader["Mode"] as string;

                        string startTime = reader["StartTime"].ToString();

                        if (!string.IsNullOrEmpty(startTime))
                            schedule.StartTime = DateTime.Parse(startTime);

                        string startDate = reader["StartDate"].ToString();

                        if (!string.IsNullOrEmpty(startDate))
                            schedule.StartDate = DateTime.Parse(startDate);

                        string endTime = reader["EndTime"].ToString();

                        if (!string.IsNullOrEmpty(endTime))
                            schedule.EndTime = DateTime.Parse(endTime);

                        string endDate = reader["EndDate"].ToString();

                        if (!string.IsNullOrEmpty(endDate))
                            schedule.EndDate = DateTime.Parse(endDate);
                        
                        schedule.Priority = Convert.ToInt32(reader["Priority"].ToString());
                        
                    }//end while

                    conn.Close();
                   

                }//using

              
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving single Schedule from database.");
            }

            return schedule;

        }//end function
      
        /// <summary>
        /// Add Schedule
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="DisplayIDs"></param>
        static public void AddSchedule(Schedule schedule, List<string> DisplayIDs)
        {
            string sql = ScheduleSql.AddSchedule();

            try
            {
                TransactionDataAccess.ScheduleAdd();

                using(SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmdAdd = new SqlCeCommand(sql, conn);
                    
                    
                    cmdAdd.Parameters.Add("@GUID", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@GUID"].Value = schedule.GUID;
                    
                    //Name
                    cmdAdd.Parameters.Add("@Name", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Name"].Value = schedule.Name;

                    //Type
                    cmdAdd.Parameters.Add("@Type", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Type"].Value = schedule.Type;
                    
                    if (schedule.StartTime != DateTime.MinValue)
                    {//Start Time
                        cmdAdd.Parameters.Add("@StartTime", SqlDbType.DateTime);
                        cmdAdd.Parameters["@StartTime"].Value = schedule.StartTime; 
                    }

                    if (schedule.StartDate != DateTime.MinValue)
                    {//Start Date
                        cmdAdd.Parameters.Add("@StartDate", SqlDbType.DateTime);
                        cmdAdd.Parameters["@StartDate"].Value = schedule.StartDate;
                    }

                    if (schedule.EndTime != DateTime.MinValue)
                    {//End Time
                         cmdAdd.Parameters.Add("@EndTime", SqlDbType.DateTime);
                         cmdAdd.Parameters["@EndTime"].Value = schedule.EndTime;
                    }
                    if (schedule.EndDate != DateTime.MinValue)
                     {//End Date
                         cmdAdd.Parameters.Add("@EndDate", SqlDbType.DateTime);
                         cmdAdd.Parameters["@EndDate"].Value = schedule.EndDate;
                     }
                        //Priority
                    cmdAdd.Parameters.Add("@Priority", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Priority"].Value = schedule.Priority;

                    //Days
                    cmdAdd.Parameters.Add("@Days", SqlDbType.Int);
                    cmdAdd.Parameters["@Days"].Value = (int)schedule.Days;

                    //Mode
                    cmdAdd.Parameters.Add("@Mode", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Mode"].Value = schedule.Mode;

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();

                 }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding Schedule from database.");
            }
            
            foreach (string item in DisplayIDs)
            {
                AddScheduleDisplayAssn(item, schedule.GUID);
            }

        }//end function


        /// <summary>
        /// Update Schedule
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="DisplayIDs"></param>
        static public void UpdateSchedule(Schedule schedule, List<string> DisplayIDs)
        {
            string sql = ScheduleSql.UpdateSchedule();
            try
            {
                TransactionDataAccess.ScheduleUpdate();

                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmdAdd = new SqlCeCommand(sql, conn);
                    

                    //GUID
                    cmdAdd.Parameters.Add("@GUID", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@GUID"].Value = schedule.GUID;

                    //Name
                    cmdAdd.Parameters.Add("@Name", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Name"].Value = schedule.Name;

                    //Type
                    cmdAdd.Parameters.Add("@Type", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Type"].Value = schedule.Type;

                    if (schedule.StartTime != DateTime.MinValue)
                    {//Start Time
                        cmdAdd.Parameters.Add("@StartTime", SqlDbType.NVarChar, 200);
                        cmdAdd.Parameters["@StartTime"].Value = schedule.StartTime;
                    }

                    if (schedule.StartDate != DateTime.MinValue)
                    {//StartDate
                        cmdAdd.Parameters.Add("@StartDate", SqlDbType.NVarChar, 200);
                        cmdAdd.Parameters["@StartDate"].Value = schedule.StartDate;
                    }

                    if (schedule.EndTime != DateTime.MinValue)
                    {//StartTime
                        cmdAdd.Parameters.Add("@EndTime", SqlDbType.NVarChar, 200);
                        cmdAdd.Parameters["@EndTime"].Value = schedule.EndTime;
                    }

                    if (schedule.EndDate != DateTime.MinValue)
                    {//EndtDate
                        cmdAdd.Parameters.Add("@EndDate", SqlDbType.NVarChar, 200);
                        cmdAdd.Parameters["@EndDate"].Value = schedule.EndDate;
                    }

                    //Location
                    cmdAdd.Parameters.Add("@Priority", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Priority"].Value = schedule.Priority;

                    //Days
                    cmdAdd.Parameters.Add("@Days", SqlDbType.Int);
                    cmdAdd.Parameters["@Days"].Value = (int)schedule.Days;

                    //Mode
                    cmdAdd.Parameters.Add("@Mode", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Mode"].Value = schedule.Mode;


                    cmdAdd.ExecuteNonQuery();

                    conn.Close();
                }//using

            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error updating Schedule from database.");
            }

            foreach (string item in DisplayIDs)
                {
                    AddScheduleDisplayAssn(item, schedule.GUID);
                }

        }//end function

        /// <summary>
        /// Delete Schedule
        /// </summary>
        /// <param name="scheduleID"></param>
        static public void DeleteSchedule(string schedule)
        {
            try
            {
                using(SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                     conn.Open();

                    SqlCeCommand cmdDel = new SqlCeCommand("DELETE FROM Schedule Where [GUID] = @GUID", conn);
                    
                    //GUID
                    cmdDel.Parameters.Add("@GUID", SqlDbType.NVarChar, 200);
                    cmdDel.Parameters["@GUID"].Value = schedule;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();
                }

                using (SqlCeConnection conn2 = CommonDataConnection.GetConnection())
                {
                    conn2.Open();

                    SqlCeCommand cmdDel = new SqlCeCommand("DELETE FROM DisplayScheduleAssn Where ScheduleID = @GUID", conn2);

                    //GUID
                    cmdDel.Parameters.Add("@GUID", SqlDbType.NVarChar, 200);
                    cmdDel.Parameters["@GUID"].Value = schedule;

                    cmdDel.ExecuteNonQuery();

                    conn2.Close();
                }
             

                foreach (ScheduledSlide item in ScheduledSlideDatabaseAccess.GetScheduledSlides(schedule))
                {
                    ScheduledSlideDatabaseAccess.DeleteSlide(item.GUID);
                }

            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error deleting Schedule from database.");
            }          

         }//end function

        /// <summary>
        /// Add Schedule Display Assn
        /// </summary>
        /// <param name="displayID"></param>
        /// <param name="scheduleID"></param>
        static private void AddScheduleDisplayAssn(string displayID, string scheduleID)
        {
            try
            {
                
                TransactionDataAccess.ScheduleUpdate();

                using(SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmd = new SqlCeCommand("INSERT INTO DisplayScheduleAssn (DisplayID, ScheduleID) VALUES (@DisplayID, @ScheduleID)", conn);
                    
                    cmd.Parameters.Add("@DisplayID", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@DisplayID"].Value = displayID;

                    cmd.Parameters.Add("@ScheduleID", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@ScheduleID"].Value = scheduleID;

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding assn Schedule from database.");
            }
            
         }

        /// <summary>
        /// Delete Schedule Display Assn
        /// </summary>
        /// <param name="displayID"></param>
        /// <param name="scheduleID"></param>
        static private void DeleteScheduleDisplayAssn(string displayID, string scheduleID)
        {
            try
            {
                TransactionDataAccess.ScheduleUpdate();

                using(SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmd = new SqlCeCommand("DELETE FROM DisplayScheduleAssn Where DisplayID = @DisplayID and ScheduleID = @ScheduleID", conn);
                   
                    Guid guid = new Guid(displayID);
                    cmd.Parameters.Add("@DisplayID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@DisplayID"].Value = guid;

                    Guid guid1 = new Guid(scheduleID);
                    cmd.Parameters.Add("@ScheduleID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@ScheduleID"].Value = guid1;

                    cmd.ExecuteNonQuery();

                    conn.Close();

                }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error deleting assn Schedule from database.");
            }

        }//function

        /// <summary>
        /// Get Displays In Schedule
        /// </summary>
        /// <param name="scheduleID"></param>
        /// <returns></returns>
        public static List<string> GetDisplaysInSchedule(string scheduleID)
        {
            List<string> displayIDs = new List<string>();

            //try
            //{
            //    using (SqlCeConnection conn = CommonDataConnection.GetConnection())
            //    {
            //        conn.Open();

            //        SqlCeCommand cmdGetDisplays = new SqlCeCommand("Get_Schedule_Displays", conn);// possibly not used 07/04/08
            //        cmdGetDisplays.CommandType = CommandType.StoredProcedure;

            //        //ScheduleID
            //        cmdGetDisplays.Parameters.Add("@ScheduleID", SqlDbType.NVarChar, 200);
            //        cmdGetDisplays.Parameters["@ScheduleID"].Value = scheduleID;

            //        SqlCeDataReader reader = cmdGetDisplays.ExecuteReader();

            //        while (reader.Read())
            //        {
            //            string display;
            //            display = reader["GUID"] as string;
            //            displayIDs.Add(display);

            //        }

            //        conn.Close();

            //    }//using
            //}//try
            //catch (Exception e)
            //{
            //    EventLogger.LogAndThrowFault(e.Message, "Error retrieving Displays in Schedule from database.");
            //}

            return displayIDs;

        }//end function



        /// <summary>
        /// Checks if last update was before last schedule change, if updateed last...return true 
        /// </summary>
        /// <returns></returns>
        static public bool CheckForLastUpdate(string hostname)
        {
            string lastUpdate = null;
            string maxDate;
            string sql;
            string sql1;
            
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    sql = ScheduleSql.CheckForLastUpdateGetMaxDate();

                    SqlCeCommand cmdAdd = new SqlCeCommand(sql, conn);
                   
                    cmdAdd.Parameters.Add("@HostName", SqlDbType.NVarChar, 100);
                    cmdAdd.Parameters["@HostName"].Value = hostname;

                    maxDate = cmdAdd.ExecuteScalar().ToString();

                    //EventLogger.Write("Maxddate: " + maxDate, EventLogEntryType.Information);
        
                    if (String.IsNullOrEmpty(maxDate))
                    {
                        TransactionDataAccess.ScheduleCheck(hostname);
                        conn.Close();
                        return true;
                    }
                   
                        sql1 = ScheduleSql.CheckForLastUpdateCheckTransDate();

                        SqlCeCommand cmdAdd1 = new SqlCeCommand(sql1, conn);

                        cmdAdd1.Parameters.Add("@MaxCheck", SqlDbType.DateTime, 100);
                        cmdAdd1.Parameters["@MaxCheck"].Value = DateTime.Parse(maxDate);

                        lastUpdate = cmdAdd1.ExecuteScalar().ToString();

                        //EventLogger.Write("lastUpdate: " + lastUpdate, EventLogEntryType.Information);

                            if (!string.IsNullOrEmpty(lastUpdate))
                            {
                                TransactionDataAccess.ScheduleCheck(hostname);
                                conn.Close();
                                return true;
                            }
                }//end using
            }

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault("Server failed to get last update from database." + Environment.NewLine + e.Message, "");
            }

            //If not already returned...       
            TransactionDataAccess.ScheduleCheck(hostname);
            return false;

        }//end function


        /// <summary>
        /// Update active flag for displays in database
        /// </summary>
        /// <param name="displayID"></param>
        /// <param name="activeFlag"></param>
        /// <param name="lastCommunication"></param>
        static public void UpdateDisplayActiveFlag(string hostname)
        {         

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = ScheduleSql.UpdateActiveFlag(hostname);

                    SqlCeCommand cmdAdd = new SqlCeCommand(sql, conn);
                  
                    cmdAdd.ExecuteNonQuery();
                    conn.Close();

                }//end using
            }

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault("Server failed to update active flag on database." + Environment.NewLine + e.InnerException, "");
            }


        }//end function



    }//class
}//namespace
