using System;
using System.Data;
using System.Data.SqlServerCe;
using Inspire.Server.Display.DataContracts;
using System.Data.SqlClient;
using System.Configuration;
using Inspire.Server.Common;

namespace Inspire.Server.Display.DataAccess
{
    public class DisplayDatabaseAccess
    {
        /// <summary>
        /// Get Displays
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        static public Displays GetDisplays(string groupID)
        {
            Guid guid = new Guid(groupID);
            Displays displays = new Displays();

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = DisplaySql.GetDisplayFromGroupID(groupID);

                    SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                
                    SqlCeDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                        while (reader.Read())
                        {
                            var display = new DataContracts.Display();

                            display.GUID = reader["GUID"].ToString() as string;
                            display.DisplayName = reader["Name"] as string;
                            display.HostName = reader["HostName"] as string;
                            display.Domain = reader["Domain"] as string;
                            display.Location = reader["Location"] as string;
                            display.ControllerModel = reader["ControllerModel"] as string;
                            display.ControllerType = reader["ControllerType"] as string;
                            display.HResolution = reader["HorizontalResolution"] == DBNull.Value ? 0 : Convert.ToInt32(reader["HorizontalResolution"]);
                            display.VResolution = reader["VerticalResolution"] == DBNull.Value ? 0 : Convert.ToInt32(reader["VerticalResolution"]);
                            display.MonitorModel = reader["MonitorModel"] as string;
                            display.MonitorSize = reader["MonitorSize"] as string;
                            display.MonitorType = reader["MonitorType"] as string;
                            display.OS = reader["OS"] as string;
                            display.SoftwareVersion = reader["SoftwareVersion"] as string;
                            display.ActiveFlag = reader["ActiveFlag"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ActiveFlag"]);
                            display.Status = reader["Status"] as string;
                            display.Orientation = reader["Orientation"] as string;
                            display.GroupID = reader["GroupID"].ToString() as string;
                            //display.PropertyID = reader["PropertyID"].ToString() as string;
                            display.LastCommunication = reader["LastCommunication"] as DateTime?;

                            displays.Add(display);

                        }//reader.Read()

                    conn.Close();

                }//end using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Displays from database.");
            }

            return displays;

        }//end function

        /// <summary>
        /// Get All Displays 
        /// </summary>
        /// <returns></returns>
        static public Displays GetAllDisplays()
        {
            Displays displays = new Displays();

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = DisplaySql.GetAllDisplays();

                    SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                    
                    SqlCeDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                        while (reader.Read())
                        {
                            var display = new DataContracts.Display();

                            display.GUID = reader["GUID"].ToString() as string;
                            display.DisplayName = reader["Name"] as string;
                            display.HostName = reader["HostName"] as string;
                            display.Domain = reader["Domain"] as string;
                            display.Location = reader["Location"] as string;
                            display.ControllerModel = reader["ControllerModel"] as string;
                            display.ControllerType = reader["ControllerType"] as string;
                            display.HResolution = reader["HorizontalResolution"] == DBNull.Value ? 0 : Convert.ToInt32(reader["HorizontalResolution"]);
                            display.VResolution = reader["VerticalResolution"] == DBNull.Value ? 0 : Convert.ToInt32(reader["VerticalResolution"]);
                            display.MonitorModel = reader["MonitorModel"] as string;
                            display.MonitorSize = reader["MonitorSize"] as string;
                            display.MonitorType = reader["MonitorType"] as string;
                            display.OS = reader["OS"] as string;
                            display.SoftwareVersion = reader["SoftwareVersion"] as string;
                            display.ActiveFlag = reader["ActiveFlag"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ActiveFlag"]);
                            display.Status = reader["Status"] as string;
                            display.Orientation = reader["Orientation"] as string;
                            display.GroupID = reader["GroupID"].ToString() as string;
                            //display.PropertyID = reader["PropertyID"].ToString() as string;
                            display.LastCommunication = reader["LastCommunication"] as DateTime?;

                            displays.Add(display);

                        }//reader.Read()

                    conn.Close();
                }//end using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving All Displays from database.");
            }

            return displays;

        }//end function

        /// <summary>
        /// Get Single Display
        /// </summary>
        /// <param name="displayID"></param>
        /// <returns></returns>
        static public DataContracts.Display GetSingleDisplay(string displayID)
        {
            Guid guid = new Guid(displayID);
            var display = new DataContracts.Display();
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = DisplaySql.GetDisplayWithDisplayID(displayID);

                    SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                    
                    SqlCeDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                        while (reader.Read())
                        {
                            display.GUID = reader["GUID"].ToString() as string;
                            display.DisplayName = reader["Name"] as string;
                            display.HostName = reader["HostName"] as string;
                            display.Domain = reader["Domain"] as string;
                            display.Location = reader["Location"] as string;
                            display.ControllerModel = reader["ControllerModel"] as string;
                            display.ControllerType = reader["ControllerType"] as string;
                            display.HResolution = reader["HorizontalResolution"] == DBNull.Value ? 0 : Convert.ToInt32(reader["HorizontalResolution"]);
                            display.VResolution = reader["VerticalResolution"] == DBNull.Value ? 0 : Convert.ToInt32(reader["VerticalResolution"]);
                            display.MonitorModel = reader["MonitorModel"] as string;
                            display.MonitorSize = reader["MonitorSize"] as string;
                            display.MonitorType = reader["MonitorType"] as string;
                            display.OS = reader["OS"] as string;
                            display.SoftwareVersion = reader["SoftwareVersion"] as string;
                            display.ActiveFlag = reader["ActiveFlag"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ActiveFlag"]);
                            display.Status = reader["Status"] as string;
                            display.Orientation = reader["Orientation"] as string;
                            display.GroupID = reader["GroupID"].ToString() as string;
                            //display.PropertyID = reader["PropertyID"].ToString() as string;
                            display.LastCommunication = reader["LastCommunication"] as DateTime?;

                        }//reader.Read()

                    conn.Close();
                }//end using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Single Display from database.");
            }

            return display;

        }//end function


        /// <summary>
        /// Get Displays In Schedule
        /// </summary>
        /// <param name="scheduleID"></param>
        /// <returns></returns>
        public static Displays GetDisplaysInSchedule(string scheduleID)
        {
            Displays displays = new Displays();

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = DisplaySql.GetDisplayFromScheduleID(scheduleID);

                    SqlCeCommand cmdGetDisplays = new SqlCeCommand(sql, conn);
                    
                    //ScheduleID
                    cmdGetDisplays.Parameters.Add("@ScheduleID", SqlDbType.NVarChar, 200);
                    cmdGetDisplays.Parameters["@ScheduleID"].Value = scheduleID;

                    SqlCeDataReader reader = cmdGetDisplays.ExecuteReader();

                    while (reader.Read())
                    {
                        var display = new DataContracts.Display();

                        display.GUID = reader["GUID"].ToString() as string;
                        display.DisplayName = reader["Name"] as string;
                        display.HostName = reader["HostName"] as string;
                        display.Domain = reader["Domain"] as string;
                        display.Location = reader["Location"] as string;
                        display.ControllerModel = reader["ControllerModel"] as string;
                        display.ControllerType = reader["ControllerType"] as string;
                        display.HResolution = reader["HorizontalResolution"] == DBNull.Value ? 0 : Convert.ToInt32(reader["HorizontalResolution"]);
                        display.VResolution = reader["VerticalResolution"] == DBNull.Value ? 0 : Convert.ToInt32(reader["VerticalResolution"]);
                        display.MonitorModel = reader["MonitorModel"] as string;
                        display.MonitorSize = reader["MonitorSize"] as string;
                        display.MonitorType = reader["MonitorType"] as string;
                        display.OS = reader["OS"] as string;
                        display.SoftwareVersion = reader["SoftwareVersion"] as string;
                        display.ActiveFlag = reader["ActiveFlag"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ActiveFlag"]);
                        display.Status = reader["Status"] as string;
                        display.Orientation = reader["Orientation"] as string;
                        display.GroupID = reader["GroupID"].ToString() as string;
                        //display.PropertyID = reader["PropertyID"].ToString() as string;
                        display.LastCommunication = reader["LastCommunication"] as DateTime?;

                        displays.Add(display);

                    }

                    conn.Close();
                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Displays In Schedule from database.");
            }

            return displays;

        }//end function

        /// <summary>
        /// Add Display
        /// </summary>
        /// <param name="display"></param>
        static public void AddDisplay(DataContracts.Display display)
        {
            Displays displays = GetAllDisplays();
            
            if (displays.Count < DisplayLicense.GetLicense())
            {
                try
                {
                    using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                    {
                        conn.Open();

                        string sql = DisplaySql.AddDislay(
                            display.GUID, 
                            display.HostName, 
                            display.Domain, 
                            display.DisplayName,
                            display.Location,
                            display.HResolution.ToString(),
                            display.VResolution.ToString(),
                            display.ControllerType,
                            display.ControllerModel,
                            display.MonitorModel,
                            display.MonitorType,
                            display.MonitorSize,
                            display.Orientation, 
                            display.Status,
                            display.SoftwareVersion,
                            display.OS,
                            display.ActiveFlag.ToString(),
                            display.GroupID,
                            display.LastCommunication);
                     
                            
                        SqlCeCommand cmdAdd = new SqlCeCommand(sql, conn);
                       
                        cmdAdd.ExecuteNonQuery();

                        conn.Close();

                    }//end using
                }//try

                catch (Exception e)
                {
                    EventLogger.LogAndThrowFault(e.Message, "Error adding Display to database.");
                }
            }//if 
        }//end function

        /// <summary>
        /// Update Display
        /// </summary>
        /// <param name="display"></param>
        static public void UpdateDisplay(DataContracts.Display display)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    
                    
                    string sql = DisplaySql.UpdateDisplay(
                           display.GUID,
                           display.HostName,
                           display.Domain,
                           display.DisplayName,
                           display.Location,
                           display.HResolution.ToString(),
                           display.VResolution.ToString(),
                           display.ControllerType,
                           display.ControllerModel,
                           display.MonitorModel,
                           display.MonitorType,
                           display.MonitorSize,
                           display.Orientation,
                           display.Status,
                           display.SoftwareVersion,
                           display.OS,
                           display.ActiveFlag.ToString(),
                           display.GroupID,
                           display.LastCommunication.ToString());

                    SqlCeCommand cmdAdd = new SqlCeCommand(sql, conn);

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();

                }//end using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error updating Display on database.");
            }

        }//end function

        /// <summary>
        /// Delete Display
        /// </summary>
        /// <param name="displayGuid"></param>
        static public void DeleteDisplay(string displayGuid)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = DisplaySql.DeleteDisplay(displayGuid);
                    SqlCeCommand cmdDel = new SqlCeCommand(sql, conn);
                    cmdDel.ExecuteNonQuery();

                    sql = DisplaySql.DeleteDisplayAssn(displayGuid);
                    SqlCeCommand cmdDel2 = new SqlCeCommand(sql, conn);
                    cmdDel2.ExecuteNonQuery();

                    sql = DisplaySql.DeleteDisplaySchedules(displayGuid);
                    SqlCeCommand cmdDel3 = new SqlCeCommand(sql, conn);
                    cmdDel3.ExecuteNonQuery();

                    conn.Close();

                }//end using
            }

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing Display from database.");
            }

        }//end function
    }//class
}//namespace
