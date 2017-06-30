using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using Inspire.Server.Common;

using Inspire.Server.Display.DataContracts;

namespace Inspire.Server.Display.DataAccess
{
    /// <summary>
    /// Display Property Database Access
    /// </summary>
    public class DisplayPropertyDatabaseAccess
    {
       

        /// <summary>
        /// Get All Properties
        /// </summary>
        /// <returns></returns>
        static public DisplayProperties GetAllProperties()
        {
            DisplayProperties displayProperties = new DisplayProperties();

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = DisplaySql.GetDisplayProperties();

                    SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    
                    if (reader != null)
                        while (reader.Read())
                        {
                            DisplayProperty displayProperty = new DisplayProperty();
                            displayProperty.GUID = reader["GUID"].ToString() as string;
                            displayProperty.PropertyName = reader["Name"] as string;
                            displayProperty.PropertyDescription = reader["Description"] as string;
                            displayProperties.Add(displayProperty);

                        }//reader.Read()
                    conn.Close();
                }//end using
            }//try
           
               catch (Exception e)
               {
                   EventLogger.LogAndThrowFault(e.Message, "Error retrieving Properties from database.");
               }
            
            return displayProperties;

            }//end function

        /// <summary>
        /// Add Property
        /// </summary>
        /// <param name="displayProperty"></param>
        static public void AddProperty(DisplayProperty displayProperty)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = DisplaySql.AddDisplayProperty(displayProperty.GUID, displayProperty.PropertyName, displayProperty.PropertyDescription);

                    SqlCeCommand cmdAdd = new SqlCeCommand(sql, conn);

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();
                }//end using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding a Property to database.");
            }

        }//end function

        /// <summary>
        /// Update Display Property
        /// </summary>
        /// <param name="displayProperty"></param>
        static public void UpdateDisplayProperty(DisplayProperty displayProperty)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = DisplaySql.UpdateDisplayProperty(displayProperty.GUID, displayProperty.PropertyName,displayProperty.PropertyDescription);

                    SqlCeCommand cmdAdd = new SqlCeCommand(sql, conn);
                  
                    
                    cmdAdd.ExecuteNonQuery();
                    conn.Close();
                }//end using
              }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error updating a Property on database.");
            }


        }//end function

        /// <summary>
        /// Delete Display Property
        /// </summary>
        /// <param name="displayPropertyGuid"></param>
        static public void DeleteDisplayProperty(string displayPropertyGuid)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmdDel = new SqlCeCommand("DELETE From DisplayProperty WHERE GUID = @GUID", conn);

                    cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@GUID"].Value = displayPropertyGuid;
                    
                    cmdDel.ExecuteNonQuery();

                    SqlCeCommand cmdSel = new SqlCeCommand("SELECT GUID FROM DisplayGroup WHERE PropertyID = @GUID", conn);

                    cmdSel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdSel.Parameters["@GUID"].Value = displayPropertyGuid;

                    SqlCeDataReader reader = cmdSel.ExecuteReader();

                    string groupId;
                    while (reader.Read())
                    {
                        groupId = reader["GUID"].ToString() as string;
                        DisplayGroupDatabaseAccess.DeleteDisplayGroups(groupId);
                    }
                    
                    conn.Close();

                }//end using

            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing a Property from database.");
            }

        }//end function
    }//class
}//namespace
