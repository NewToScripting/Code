using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Inspire.Server.Rooms.DataContracts;
using Inspire.Server.Common;

namespace Inspire.Server.Rooms.DataAccess
{
    /// <summary>
    /// Rooms Database Access
    /// </summary>
    public class RoomsDatabaseAccess
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
        /// Get Rooms
        /// </summary>
        /// <returns></returns>
        static public DataContracts.Rooms GetRooms()
        {
            DataContracts.Rooms rooms = new DataContracts.Rooms();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("rooms_get_v1", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Room room = new Room();
                        room.GUID = reader["GUID"].ToString();
                        room.Name = reader["Name"] as string;
                        room.RoomAliases = RoomAliasDatabaseAccess.GetAliases(room.GUID);

                        rooms.Add(room);
                    }
                    conn.Close();
                }//using
             }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Rooms to database.");
            }

            return rooms;

        }//end function


        /// <summary>
        /// Get Rooms For Display
        /// </summary>
        /// <param name="displayID"></param>
        /// <returns></returns>
        static public DataContracts.Rooms GetRoomsForDisplay(string displayID)
        {
            DataContracts.Rooms rooms = new DataContracts.Rooms();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("rooms_get_from_displayid_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //DisplayID
                    Guid guid1 = new Guid(displayID);
                    cmd.Parameters.Add("@DisplayID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@DisplayID"].Value = guid1;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Room room = new Room();
                        room.GUID = reader["GUID"].ToString();
                        room.Name = reader["Name"] as string;
                        room.RoomAliases = RoomAliasDatabaseAccess.GetAliases(room.GUID);

                        rooms.Add(room);
                    }

                    conn.Close();

                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Rooms to database.");
            }

            return rooms;

        }//end function
        

        /// <summary>
        /// Add Room
        /// </summary>
        /// <param name="room"></param>
        static public void AddRoom(Room room)
        {
            try
            {
                using(SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("room_add_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(room.GUID);
                    cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@GUID"].Value = guid;

                    //Name
                    cmdAdd.Parameters.Add("@Name", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Name"].Value = room.Name;

                    //Aliases
                    foreach (RoomAlias item in room.RoomAliases)
                    {
                        RoomAliasDatabaseAccess.AddAlias(item);
                    }

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();
                }//using
             }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding a Room to database.");
            }


        }//end function

        /// <summary>
        /// Add Room To Display Assn
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="displayID"></param>
        static public void AddRoomToDisplayAssn(string roomID, string displayID)
        {
            try
            {
                using(SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("room_display_assn_add_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //RoomID
                    Guid guid = new Guid(roomID);
                    cmdAdd.Parameters.Add("@RoomID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@RoomID"].Value = guid;

                    //DisplayID
                    Guid guid1 = new Guid(displayID);
                    cmdAdd.Parameters.Add("@DisplayID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@DisplayID"].Value = guid1;

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();
                }//using
             }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding a RoomToDisplayAssn to database.");
            }

        }//end function

        /// <summary>
        /// Delete Room To Display Assn
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="displayID"></param>
        static public void DeleteRoomToDisplayAssn(string roomID, string displayID)
        {
            try
            {
                using(SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("room_display_assn_delete_v1", conn);
                    cmdDel.CommandType = CommandType.StoredProcedure;

                    //RoomID
                    Guid guid = new Guid(roomID);
                    cmdDel.Parameters.Add("@RoomID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@RoomID"].Value = guid;

                    //DisplayID
                    Guid guid1 = new Guid(displayID);
                    cmdDel.Parameters.Add("@DisplayID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@DisplayID"].Value = guid1;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();
                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing a RoomToDisplayAssn from database.");
            }

        }//function
        
        /// <summary>
        /// Delete Room
        /// </summary>
        /// <param name="roomID"></param>
        static public void DeleteRoom(string roomID)
        {
            try
            {
                using(SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("room_delete_v1", conn);
                    cmdDel.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(roomID);
                    cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@GUID"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();
                }//using
        
           }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing a RoomToDisplayAssn from database.");
            }

    }//function
  }
}