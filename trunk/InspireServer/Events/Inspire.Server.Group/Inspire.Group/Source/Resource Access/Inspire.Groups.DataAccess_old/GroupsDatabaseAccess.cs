using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Inspire.Server.Groups.DataContracts;

namespace Inspire.Server.Groups.DataAccess
{
    /// <summary>
    /// Groups Database Access
    /// </summary>
    public class GroupsDatabaseAccess
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
        static public DataContracts.Groups GetGroups()
        {
            DataContracts.Groups rooms = new DataContracts.Groups();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("groups_get_v1", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Group room = new Group();
                        room.GUID = reader["GUID"].ToString();
                        room.Name = reader["Name"] as string;
                        room.GroupAliases = GroupAliasDatabaseAccess.GetAliases(room.GUID);
                        
                        string fileName = reader["ImageID"].ToString();
                        if (!string.IsNullOrEmpty(fileName)) room.GroupImageWebPath = ConfigurationManager.AppSettings["ImageWebFolder"].ToString() + reader["file_name"].ToString() + reader["file_extension"] as string; 
                        else room.GroupImageWebPath = null;
                        
                        room.ImageID = reader["ImageID"].ToString() as string;

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
        static public void AddGroup(Group room)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("group_add_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(room.GUID);
                    cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@GUID"].Value = guid;

                    //Name
                    cmdAdd.Parameters.Add("@Name", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Name"].Value = room.Name;


                    //Name
                    cmdAdd.Parameters.Add("@ImageID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@ImageID"].Value = room.ImageID;

                    //Aliases
                    foreach (GroupAlias item in room.GroupAliases)
                    {
                        GroupAliasDatabaseAccess.AddAlias(item);
                    }

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();
                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding a Group to database.");
            }


        }//end function


        /// <summary>
        /// Update Group
        /// </summary>
        /// <param name="room"></param>
        static public void UpdateGroup(Group group)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("group_update_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(group.GUID);
                    cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@GUID"].Value = guid;

                    //Name
                    cmdAdd.Parameters.Add("@Name", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Name"].Value = group.Name;


                    //Name
                    Guid guid2 = new Guid(group.ImageID);
                    cmdAdd.Parameters.Add("@ImageID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@ImageID"].Value = guid2;

                    //Aliases

                    GroupAliasDatabaseAccess.ClearGroupAliases(group.GUID);

                    foreach (GroupAlias item in group.GroupAliases)
                    {
                        GroupAliasDatabaseAccess.AddAlias(item);
                    }

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();
                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error updateing to database.");
            }




        }//end function

    
        /// <summary>
        /// Delete Room
        /// </summary>
        /// <param name="roomID"></param>
        static public void DeleteGroup(string roomID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("group_delete_v1", conn);
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
                EventLogger.LogAndThrowFault(e.Message, "Error removing a group from database.");
            }

        }//function
    }
}