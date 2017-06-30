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
    public class FieldContractDatabaseAccess
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
        /// Get EventFileFormat
        /// </summary>
        /// <param name="feedID"></param>
        /// <returns></returns>
        static public FieldContracts GetFieldContracts(string itemID)
        {
            FieldContracts items = new FieldContracts();

            try
            {
                using (SqlConnection conn = OpenSQLConnection())
                {
                    SqlCommand cmd = new SqlCommand("field_contracts_get_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //event_file_format_guid
                    Guid guid = new Guid(itemID);
                    cmd.Parameters.Add("@event_file_format_guid", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@event_file_format_guid"].Value = guid;
                    
                    conn.Open();

                     SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        FieldContract item = new FieldContract();

                        item.Length = reader["length"] as int?;
                        item.Name = reader["name"] as string;
                        item.Start = reader["start"] as int?;
                        item.FieldType = reader["field_type"] as string;
                        item.Value = reader["value"] as string;
                        item.EventFileFormatGuid = reader["event_file_format_guid"].ToString() as string;
                        item.GUID = reader["field_contract_guid"].ToString() as string; 
                        items.Add(item);
                      
                    }//while

                    conn.Close();

                } //using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error getting field contracts from database. " + e.Message);
            }

            return items;

        }//function

        /// <summary>
        /// Add Event File Format
        /// </summary>
        /// <param name="hospitalityEvent"></param>
        static private void AddFieldContract(FieldContract item)
        {               
                    
            using (SqlConnection conn = OpenSQLConnection())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("field_contract_add_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //event_file_format_guid
                    Guid guid = new Guid(item.EventFileFormatGuid);
                    cmdAdd.Parameters.Add("@event_file_format_guid", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@event_file_format_guid"].Value = guid;

                    //field_contract_guid
                    Guid guid2 = new Guid(item.GUID);
                    cmdAdd.Parameters.Add("@field_contract_guid", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@field_contract_guid"].Value = guid2;

                    //start
                    if (item.Start != null)
                    {
                        cmdAdd.Parameters.Add("@start", SqlDbType.Int);
                        cmdAdd.Parameters["@start"].Value = item.Start;
                    } 
                    
                    //length
                    if (item.Length!= null)
                    {                       
                        cmdAdd.Parameters.Add("@length", SqlDbType.Int);
                        cmdAdd.Parameters["@length"].Value = item.Length;
                    }

                    //name
                    cmdAdd.Parameters.Add("@name", SqlDbType.NVarChar, 50);
                    cmdAdd.Parameters["@name"].Value = item.Name;

                    //value
                    cmdAdd.Parameters.Add("@value", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@value"].Value = item.Value;

                    //field_type
                    //cmdAdd.Parameters.Add("@field_type", SqlDbType.Int);
                    //cmdAdd.Parameters["@field_type"].Value = item.FieldType;


                    cmdAdd.ExecuteNonQuery();

                    conn.Close();

                }//using

        }//function

             /// <summary>
        /// Add Event File Format
        /// </summary>
        /// <param name="hospitalityEvent"></param>
        static public void AddFieldContracts(FieldContracts items)
        {
            foreach (FieldContract item in items)
            {
                try
                {
                    AddFieldContract(item);
                }
                catch (Exception e)
                {
                    EventLogger.LogAndThrowFault(e.Message, "Error adding adding event file format to database. " + e.Message);
                }
            }//foreach

        }//end function
       
        /// <summary>
        /// Delete Hospitality Event
        /// </summary>
        /// <param name="feedEntryID"></param>
        static public void DeleteFieldContracts(string itemID)
        {
            try
            {
                using (SqlConnection conn = OpenSQLConnection())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("field_contract_delete_v1", conn);
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
