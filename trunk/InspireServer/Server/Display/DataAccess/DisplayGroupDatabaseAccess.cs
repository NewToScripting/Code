using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using Inspire.Server.Display.DataContracts;
using Inspire.Server.Common;

namespace Inspire.Server.Display.DataAccess
{
    public class DisplayGroupDatabaseAccess
    {
      
        /// <summary>
        /// Get Groups
        /// </summary>
        /// <param name="propertyGuid"></param>
        /// <returns></returns>
        static public DisplayGroups GetGroups(string propertyGuid)
        {
            
            DisplayGroups displayGroups = new DisplayGroups();

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = DisplaySql.GetGroups(propertyGuid);

                    SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                    
                    
                    SqlCeDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                        while (reader.Read())
                        {
                            DisplayGroup displayGroup = new DisplayGroup();

                            displayGroup.GUID = reader["GUID"].ToString() as string;
                            displayGroup.GroupName = reader["Name"] as string;
                            displayGroup.GroupDescription = reader["Description"] as string;
                            displayGroup.PropertyID = reader["PropertyID"].ToString() as string;
                            displayGroups.Add(displayGroup);

                        }//reader.Read()

                    conn.Close();
                }//end using

            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Groups from database.");
            }

            return displayGroups;

        }//end function

        /// <summary>
        /// Get All Groups
        /// </summary>
        /// <returns></returns>
        static public DisplayGroups GetAllGroups()
        {
            DisplayGroups displayGroups = new DisplayGroups();

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = DisplaySql.GetAllGroups();

                    SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                   
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    
                    if (reader != null)
                        while (reader.Read())
                        {
                            DisplayGroup displayGroup = new DisplayGroup();

                            displayGroup.GUID = reader["GUID"].ToString() as string;
                            displayGroup.GroupName = reader["Name"] as string;
                            displayGroup.GroupDescription = reader["Description"] as string;
                            displayGroup.PropertyID = reader["PropertyID"].ToString() as string;
                            displayGroups.Add(displayGroup);

                        }//reader.Read()

                    conn.Close();
                }//end using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving all Groups from database.");
            }

            return displayGroups;

        }//end function

       /// <summary>
       /// Add Group
       /// </summary>
       /// <param name="displayGroup"></param>
        static public void AddGroup(DisplayGroup displayGroup)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql;
                    sql = DisplaySql.AddDisplayGroup(displayGroup.GUID, displayGroup.GroupName, displayGroup.GroupDescription, displayGroup.PropertyID);

                    SqlCeCommand cmdAdd = new SqlCeCommand(sql, conn);

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();

                }//end using
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding Group to database.");
            }

        }//end function

        /// <summary>
        /// Update Display Group
        /// </summary>
        /// <param name="displayGroup"></param>
        static public void UpdateDisplayGroup(DisplayGroup displayGroup)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = DisplaySql.UpdateDisplayGroup(displayGroup.GUID, displayGroup.GroupName,displayGroup.GroupDescription,displayGroup.PropertyID);

                    SqlCeCommand cmdAdd = new SqlCeCommand(sql, conn);
                   

                  
                    cmdAdd.ExecuteNonQuery();

                    conn.Close();

                }//end using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error updating Group on database.");
            }

        }//end function

        /// <summary>
        /// Delete Display Groups
        /// </summary>
        /// <param name="displayGroupGuid"></param>
        static public void DeleteDisplayGroups(string displayGroupGuid)
        {
            try
            { 
                //GUID
                Guid guid = new Guid(displayGroupGuid);

                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmdDel = new SqlCeCommand("DELETE FROM DisplayGroup WHERE GUID = @GUID", conn);
                    
                    cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@GUID"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    SqlCeCommand cmdSel = new SqlCeCommand("SELECT GUID FROM Display WHERE GroupID = @GUID", conn);

                    cmdSel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdSel.Parameters["@GUID"].Value = guid;

                     SqlCeDataReader reader = cmdSel.ExecuteReader();

                    string displayId;
                    while (reader.Read())
                    {
                        displayId = reader["GUID"].ToString() as string;
                        DisplayDatabaseAccess.DeleteDisplay(displayId);
                    }

                    conn.Close();

                }//end using

            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing Group from database.");
            }
        }//end function
    }//class
}//namespace


