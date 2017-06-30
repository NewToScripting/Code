using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Inspire.Server.Events.DataContracts;
using Inspire.Server.Common;


namespace Inspire.Server.Events.DataAccess
{
    /// <summary>
    /// Entry Database Access
    /// </summary>
    public class EventFileFormatDatabaseAccess
    {       
        /// <summary>
        /// Open SQL Connection
        /// </summary>
        /// <returns></returns>
        static private SqlConnection OpenSQLConnection()
        {
            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Inspire.Events"].ToString();
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error connection to event database. " + e.Message);
            }
           
            return conn;

        }//function

        /// <summary>
        /// Get EventFileFormats
        /// </summary>
        /// <param name="feedID"></param>
        /// <returns></returns>
        static public EventFileFormats GetEventFileFormats()
        {
            EventFileFormats items = new EventFileFormats();

            try
            {
                using (SqlConnection conn = OpenSQLConnection())
                {
                    SqlCommand cmd = new SqlCommand("event_file_formats_get_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        EventFileFormat item = new EventFileFormat();

                        item.EventFormatName = reader["event_format_name"].ToString() as string;
                        item.EventFileFormatGuid = reader["event_file_format_guid"].ToString() as string;
                        item.IsReadOnly = reader["is_read_only"] as bool?;
                        item.TextFormat = reader["text_format"] as int?;
                        item.FieldDelimeter = reader["field_delimeter"] as string;
                        item.SkipFirstFile = reader["skip_first_line"] as bool?;
                        item.FieldContracts = FieldContractDatabaseAccess.GetFieldContracts(item.EventFileFormatGuid); 
                        items.Add(item);

                    }//while

                    conn.Close();

                } //using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error getting event file formats from database. " + e.Message);
            }

             return items;

        }//function


        /// <summary>
        /// Get EventFileFormat
        /// </summary>
        /// <param name="feedID"></param>
        /// <returns></returns>
        static public EventFileFormat GetEventFileFormat(string itemID)
        {
            EventFileFormat item = new EventFileFormat();

            if(!string.IsNullOrEmpty(itemID))
            {
                try
                {
                    using (SqlConnection conn = OpenSQLConnection())
                    {
                        SqlCommand cmd = new SqlCommand("event_file_format_get_v1", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        //event_file_format_guid
                        Guid guid = new Guid(itemID);
                        cmd.Parameters.Add("@event_file_format_guid", SqlDbType.UniqueIdentifier);
                        cmd.Parameters["@event_file_format_guid"].Value = guid;

                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            item.EventFormatName = reader["event_format_name"].ToString() as string;
                            item.EventFileFormatGuid = reader["event_file_format_guid"].ToString() as string;
                            item.IsReadOnly = reader["is_read_only"] as bool?;
                            item.TextFormat = reader["text_format"] as int?;
                            item.FieldDelimeter = reader["field_delimeter"] as string;
                            item.SkipFirstFile = reader["skip_first_line"] as bool?;
                            item.FieldContracts = FieldContractDatabaseAccess.GetFieldContracts(item.EventFileFormatGuid);

                        }//while

                        conn.Close();

                    } //using
                }//try

                catch (Exception e)
                {
                    EventLogger.LogAndThrowFault(e.Message, "Error getting event file formats from database. " + e.Message);
                }


            }
         
            return item;

        }//function

        /// <summary>
        /// Add Event File Format
        /// </summary>
        /// <param name="hospitalityEvent"></param>
        static public void AddEventFileFormat(EventFileFormat item)
        {
            try
            {
                using (SqlConnection conn = OpenSQLConnection())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("event_file_format_add_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //event_file_format_guid
                    Guid guid = new Guid(item.EventFileFormatGuid);
                    cmdAdd.Parameters.Add("@event_file_format_guid", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@event_file_format_guid"].Value = guid;
                    
                    //group_logo
                    cmdAdd.Parameters.Add("@text_format", SqlDbType.Int);
                    cmdAdd.Parameters["@text_format"].Value = item.TextFormat;

                    //event_format_name
                    cmdAdd.Parameters.Add("@event_format_name", SqlDbType.NVarChar, 100);
                    cmdAdd.Parameters["@event_format_name"].Value = item.EventFormatName;

                    //group_name
                    cmdAdd.Parameters.Add("@is_read_only", SqlDbType.Bit);
                    cmdAdd.Parameters["@is_read_only"].Value = item.IsReadOnly;

                    //Skip First
                    cmdAdd.Parameters.Add("@skip_first_line", SqlDbType.Bit);
                    cmdAdd.Parameters["@skip_first_line"].Value = item.SkipFirstFile;

                    //Field Delimiter
                    cmdAdd.Parameters.Add("@field_delimeter", SqlDbType.NVarChar, 10);
                    cmdAdd.Parameters["@field_delimeter"].Value = item.FieldDelimeter;






                    cmdAdd.ExecuteNonQuery();

                    conn.Close();

                    FieldContractDatabaseAccess.DeleteFieldContracts(item.EventFileFormatGuid);

                    FieldContractDatabaseAccess.AddFieldContracts(item.FieldContracts);                     
                 
                }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding adding event file format to database. " + e.Message);
            }

            
        }//end function

        /// <summary>
        /// Update Event File Format
        /// </summary>
        /// <param name="hospitalityEvent"></param>
        static public void UpdateEventFileFormat(EventFileFormat item)
        {
            try
            {
                using (SqlConnection conn = OpenSQLConnection())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("event_file_format_update_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //event_file_format_guid
                    Guid guid = new Guid(item.EventFileFormatGuid);
                    cmdAdd.Parameters.Add("@event_file_format_guid", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@event_file_format_guid"].Value = guid;

                    //event_format_name
                    cmdAdd.Parameters.Add("@event_format_name", SqlDbType.NVarChar, 100);
                    cmdAdd.Parameters["@event_format_name"].Value = item.EventFormatName;

                    //group_name
                    cmdAdd.Parameters.Add("@is_read_only", SqlDbType.Bit);
                    cmdAdd.Parameters["@is_read_only"].Value = item.IsReadOnly;

                    //group_logo
                    cmdAdd.Parameters.Add("@text_format", SqlDbType.Int);
                    cmdAdd.Parameters["@text_format"].Value = item.TextFormat;

                    //Skip First
                    cmdAdd.Parameters.Add("@skip_first_line", SqlDbType.Bit);
                    cmdAdd.Parameters["@skip_first_line"].Value = item.SkipFirstFile;

                    //Field Delimiter
                    cmdAdd.Parameters.Add("@field_delimeter", SqlDbType.NVarChar, 10);
                    cmdAdd.Parameters["@field_delimeter"].Value = item.FieldDelimeter;

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();

                    FieldContractDatabaseAccess.DeleteFieldContracts(item.EventFileFormatGuid);

                    FieldContractDatabaseAccess.AddFieldContracts(item.FieldContracts);                     
                 

                }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error updateing event file format to database. " + e.Message);
            }


        }//end function



        /// <summary>
        /// Delete Hospitality Event
        /// </summary>
        /// <param name="feedEntryID"></param>
        static public void DeleteEventFileFormat(string itemID)
        {
            try
            {
                using (SqlConnection conn = OpenSQLConnection())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("event_file_format_delete_v1", conn);
                    cmdDel.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(itemID);
                    cmdDel.Parameters.Add("@event_file_format_guid", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@event_file_format_guid"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();

                }//using
            }

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing event file format from database. " + e.Message);
            }

           
        }//end function
        
    
    }//class
}//namespace
