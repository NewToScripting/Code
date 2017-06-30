using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Inspire.Events.Proxy
{
    public class RoomProxy
    {


        static private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            string connString = @"Data Source=testserver2008\sqldev2008;Initial Catalog=InspireFeedsDB;User Id=sa;Password=!nspire8;";
            conn.ConnectionString = connString;
            return conn;
        }

        static public ObservableCollection<Room> GetRooms()
        {
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();

           using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("rooms_get_v1", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Room room = new Room();
                    room.Guid = reader["GUID"].ToString();
                    room.Name = reader["Name"] as string;
                    room.Aliases = AliaseProxy.GetAliases(room.Guid);

                    rooms.Add(room);
                }

                conn.Close();

            }//using

            return rooms;

        }//end function

        static public ObservableCollection<Room> GetRoomsForDisplay(string displayID)
        {
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();

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
                    room.Guid = reader["GUID"].ToString();
                    room.Name = reader["Name"] as string;
                    room.Aliases = AliaseProxy.GetAliases(room.Guid);

                    rooms.Add(room);
                }

                conn.Close();

            }//using

            return rooms;

        }//end function





        static public void AddRoom(Room room)
        {
            SqlConnection conn = GetConnection();
            conn.Open();

            SqlCommand cmdAdd = new SqlCommand("room_add_v1", conn);
            cmdAdd.CommandType = CommandType.StoredProcedure;

                //GUID
                Guid guid = new Guid(room.Guid);
                cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                cmdAdd.Parameters["@GUID"].Value = guid;

                //Name
                cmdAdd.Parameters.Add("@Name", SqlDbType.NVarChar, 200);
                cmdAdd.Parameters["@Name"].Value = room.Name;

                //Aliases
                foreach (Alias item in room.Aliases)
                {
                    AliaseProxy.AddAlias(item);
                }
                    

            cmdAdd.ExecuteNonQuery();

            conn.Close();

        }//end function


         static public void AddRoomToDisplayAssn(string roomID, string displayID)
        {
            SqlConnection conn = GetConnection();
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

        }//end function


         static public void DeleteRoomToDisplayAssn(string roomID, string displayID)
         {
             SqlConnection conn = GetConnection();
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

         }










        static public void DeleteRoom(string roomID)
        {
            SqlConnection conn = GetConnection();
            conn.Open();

            SqlCommand cmdDel = new SqlCommand("delete_room_v1", conn);
            cmdDel.CommandType = CommandType.StoredProcedure;

            //GUID
            Guid guid = new Guid(roomID);
            cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
            cmdDel.Parameters["@GUID"].Value = guid;

            cmdDel.ExecuteNonQuery();

            conn.Close();

        }

    }
}
