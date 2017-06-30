using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Inspire.Server.Rooms.DataContracts;
using Inspire.Server.Common;


namespace Inspire.Server.Rooms.DataAccess
{
    /// <summary>
    /// Alias Database Access
    /// </summary>
    public class RoomAliasDatabaseAccess
    {
        /// <summary>
        /// Get SQL Connection
        /// </summary>
        /// <returns></returns>
        static private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(); 
            string connString = ConfigurationManager.ConnectionStrings["Inspire.Events"].ToString();
            conn.ConnectionString = connString;
            return conn;
        }

        /// <summary>
        /// Get Aliases
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>
        static public RoomAliases GetAliases(string roomID)
        {
            RoomAliases aliases = new RoomAliases();
            try
            {

                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("room_alias_get_from_roomID_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                        
                    //GUID
                    Guid guid = new Guid(roomID);
                    cmd.Parameters.Add("@RoomID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@RoomID"].Value = guid;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        RoomAlias alias = new RoomAlias();
                        alias.GUID = reader["GUID"].ToString() as string;
                        alias.Value = reader["Value"] as string;
                        alias.RoomID = reader["RoomID"].ToString() as string;
                        aliases.Add(alias);
                    }

                    conn.Close();

                }//using
            }//try
            catch (Exception e)
            {
                //EventLogger.LogAndThrowFault(e.Message, "Error retrieving Aliases from database.");
            }
           
            return aliases;

        }//end function


        /// <summary>
        /// Add Alias
        /// </summary>
        /// <param name="alias"></param>
        static public void AddAlias(RoomAlias alias)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("room_alias_add_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = Guid.NewGuid();
                    cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@GUID"].Value = guid;

                    //Alias
                    cmdAdd.Parameters.Add("@Value", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Value"].Value = alias.Value;

                    //RoomID
                    Guid guid1 = new Guid(alias.RoomID);
                    cmdAdd.Parameters.Add("@RoomID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@RoomID"].Value = guid1;

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();
                } //using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding RoomAlias to database.");
            }

        }//end function


        /// <summary>
        /// Delete Alias
        /// </summary>
        /// <param name="aliasID"></param>
        static public void DeleteRoomAlias(string aliasID)
        {
            try
            {
                 using(SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("room_alias_delete_v1", conn);
                    cmdDel.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(aliasID);
                    cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@GUID"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();
                    
                }//using
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error deleteing Alias to database.");
            }

        }//end function
    }
}