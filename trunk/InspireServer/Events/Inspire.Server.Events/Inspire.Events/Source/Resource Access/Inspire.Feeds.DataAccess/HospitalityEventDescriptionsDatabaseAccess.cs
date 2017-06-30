using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Inspire.Server.Events.DataContracts;
using System.Collections.Generic;
using Inspire.Server.Common;

namespace Inspire.Server.Events.DataAccess
{
    /// <summary>
    /// Feed Database Access
    /// </summary>
    public class HospitalityEventDescriptionsDatabaseAccess
    {
        /// <summary>
        /// Get SQL Connection
        /// </summary>
        /// <returns></returns>
        static private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();

            try
            {
                string connString = ConfigurationManager.ConnectionStrings["Inspire.Events"].ToString();
                conn.ConnectionString = connString;
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error connection to Feeds database.");
            }

            return conn;

        }

        /// <summary>
        /// Get Feeds
        /// </summary>
        /// <returns></returns>
        static public HospitalityEventDefinitions GetEventDefinitions()
        {
            var items = new HospitalityEventDefinitions();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("event_definitions_get_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HospitalityEventDefinition item = new HospitalityEventDefinition();
                        item.EventDefinitionGuid = reader["event_definition_guid"].ToString() as string;
                        item.Name = reader["event_definition_name"] as string;
                        item.Desecription = reader["event_definition_description"] as string;
                        item.Uri = reader["uri"] as string;
                        item.EventFileFormat =  EventFileFormatDatabaseAccess.GetEventFileFormat(reader["event_file_format_guid"].ToString() as string);
                        item.SourceType = reader["type"] as int?;
                        item.Default = reader["default"] as bool?;
                        item.UpdateInterval = reader["update_interval"] as int?;
                        item.Active = reader["active"] as bool?;
                       
                        
                        items.Add(item);           

                    }//end while

                    conn.Close();

                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving EventDefinitions from database.");
            }

            return items;

        }//end function


        /// <summary>
        /// Get Default Event Definition
        /// </summary>
        /// <returns></returns>
        static public HospitalityEventDefinition GetDefaultEventDefinition()
        {
           HospitalityEventDefinition item = new HospitalityEventDefinition();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("event_default_definition_get_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    

                    while (reader.Read())
                    {                        
                        item.EventDefinitionGuid = reader["event_definition_guid"].ToString() as string;
                        item.Name = reader["event_definition_name"] as string;
                        item.Desecription = reader["event_definition_description"] as string;
                        item.Uri = reader["uri"] as string;
                        item.EventFileFormat = EventFileFormatDatabaseAccess.GetEventFileFormat(reader["event_file_format_guid"].ToString() as string);
                        item.SourceType = reader["type"] as int?;
                        item.Default = reader["default"] as bool?;
                        item.UpdateInterval = reader["update_interval"] as int?;
                        item.Active = reader["active"] as bool?;
                        item.EventFileFormat = EventFileFormatDatabaseAccess.GetEventFileFormat(item.EventDefinitionGuid);
                        
                    }//end while

                    conn.Close();

                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving EventDefinitions from database.");
            }

            return item;

        }//end function



        /// <summary>
        /// Add EventDefinition
        /// </summary>
        /// <param name="feed"></param>
        static public void AddEventDefinition(HospitalityEventDefinition item)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("event_definition_add_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //event_definition_guid
                    Guid guid = new Guid(item.EventDefinitionGuid);
                    cmdAdd.Parameters.Add("@event_definition_guid", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@event_definition_guid"].Value = guid;

                    //event_definition_name
                    cmdAdd.Parameters.Add("@event_definition_name", SqlDbType.NVarChar, 100);
                    cmdAdd.Parameters["@event_definition_name"].Value = item.Name;

                    //event_definition_description
                    cmdAdd.Parameters.Add("@event_definition_description", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@event_definition_description"].Value = item.Desecription;

                    //hotel_name
                    cmdAdd.Parameters.Add("@uri", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@uri"].Value = item.Uri;

                    //EventFileFormat
                    EventFileFormatDatabaseAccess.AddEventFileFormat(item.EventFileFormat);

                    //group_name
                    cmdAdd.Parameters.Add("@type", SqlDbType.Int);
                    cmdAdd.Parameters["@type"].Value = item.SourceType;

                    //default
                    cmdAdd.Parameters.Add("@default", SqlDbType.Bit);
                    cmdAdd.Parameters["@default"].Value = item.Default;
                    
                    //update_interval
                    cmdAdd.Parameters.Add("@update_interval", SqlDbType.Int);
                    cmdAdd.Parameters["@update_interval"].Value = item.UpdateInterval;

                    //active
                    cmdAdd.Parameters.Add("@active", SqlDbType.Bit);
                    cmdAdd.Parameters["@active"].Value = item.Active;
                    
                    cmdAdd.ExecuteNonQuery();

                    conn.Close();


                }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding to EventDefinition database.");
            }

        }//end function



        /// <summary>
        /// Update EventDefinition
        /// </summary>
        /// <param name="feed"></param>
        static public void UpdateEventDefinition(HospitalityEventDefinition item)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("event_definition_update_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //event_definition_guid
                    Guid guid = new Guid(item.EventDefinitionGuid);
                    cmdAdd.Parameters.Add("@event_definition_guid", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@event_definition_guid"].Value = guid;

                    //event_definition_name
                    cmdAdd.Parameters.Add("@event_definition_name", SqlDbType.NVarChar, 100);
                    cmdAdd.Parameters["@event_definition_name"].Value = item.Name;

                    //event_definition_description
                    cmdAdd.Parameters.Add("@event_definition_description", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@event_definition_description"].Value = item.Desecription;

                    //hotel_name
                    cmdAdd.Parameters.Add("@uri", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@uri"].Value = item.Uri;

                    //EventFileFormat
                    EventFileFormatDatabaseAccess.UpdateEventFileFormat(item.EventFileFormat);
                    
                    //group_name
                    cmdAdd.Parameters.Add("@type", SqlDbType.Int);
                    cmdAdd.Parameters["@type"].Value = item.SourceType;

                    //default
                    cmdAdd.Parameters.Add("@default", SqlDbType.Bit);
                    cmdAdd.Parameters["@default"].Value = item.Default;

                    //update_interval
                    cmdAdd.Parameters.Add("@update_interval", SqlDbType.Int);
                    cmdAdd.Parameters["@update_interval"].Value = item.UpdateInterval;

                    //active
                    cmdAdd.Parameters.Add("@active", SqlDbType.Bit);
                    cmdAdd.Parameters["@active"].Value = item.Active;

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();


                }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error updating to EventDefinition database.");
            }

        }//end function

        /// <summary>
        /// Get Default EventDefinition
        /// </summary>
        /// <param name="feedID"></param>
        static public void SetDefaultDefinition(string eventID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("event_definition_set_default_v1", conn);
                    cmdDel.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(eventID);
                    cmdDel.Parameters.Add("@event_definition_guid", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@event_definition_guid"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();

                }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error setting default EventDefinition in database.");
            }


        }//end function

       
        /// <summary>
        /// Delete EventDefinition
        /// </summary>
        /// <param name="feedID"></param>
        static public void DeleteEventDefinition(string eventID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("event_definition_delete_v1", conn);
                    cmdDel.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(eventID);
                    cmdDel.Parameters.Add("@event_guid", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@event_guid"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();

                }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing EventDefinition from database.");
            }


        }//end function
    }
}
