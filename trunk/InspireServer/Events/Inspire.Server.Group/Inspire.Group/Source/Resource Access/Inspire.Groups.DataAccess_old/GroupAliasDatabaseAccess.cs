using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Inspire.Server.Groups.DataContracts;


namespace Inspire.Server.Groups.DataAccess
{
    /// <summary>
    /// Alias Database Access
    /// </summary>
    public class GroupAliasDatabaseAccess
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
        static public GroupAliases GetAliases(string roomID)
        {
            GroupAliases aliases = new GroupAliases();
            try
            {

                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("group_alias_get_from_groupID_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(roomID);
                    cmd.Parameters.Add("@GroupID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@GroupID"].Value = guid;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        GroupAlias alias = new GroupAlias();
                        alias.GUID = reader["GUID"].ToString() as string;
                        alias.Value = reader["Value"] as string;
                        alias.GroupID = reader["GroupID"].ToString() as string;
                        aliases.Add(alias);
                    }

                    conn.Close();

                }//using
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Aliases from database.");
            }

            return aliases;

        }//end function


        /// <summary>
        /// Add Alias
        /// </summary>
        /// <param name="alias"></param>
        static public void AddAlias(GroupAlias alias)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("group_alias_add_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = Guid.NewGuid();
                    cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@GUID"].Value = guid;

                    //Alias
                    cmdAdd.Parameters.Add("@Value", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Value"].Value = alias.Value;

                    //RoomID
                    Guid guid1 = new Guid(alias.GroupID);
                    cmdAdd.Parameters.Add("@GroupID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@GroupID"].Value = guid1;

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();
                } //using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding GroupAlias to database.");
            }

        }//end function


        /// <summary>
        /// Delete Alias
        /// </summary>
        /// <param name="aliasID"></param>
        static public void DeleteGroupAlias(string aliasID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("group_alias_delete_v1", conn);
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


        /// <summary>
        /// Clear Aliases
        /// </summary>
        /// <param name="aliasID"></param>
        static public void ClearGroupAliases(string groupID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("group_aliases_clear_v1", conn);
                    cmdDel.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(groupID);
                    cmdDel.Parameters.Add("@GroupID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@GroupID"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();

                }//using
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error clearing Aliases to database.");
            }

        }//end function

    }
}