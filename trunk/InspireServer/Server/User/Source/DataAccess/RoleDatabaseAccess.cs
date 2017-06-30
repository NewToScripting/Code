using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using Inspire.Users.DataContracts;
using System.Configuration;
using Inspire.Server.Common;

namespace Inspire.Users.DataAccess
{
    /// <summary>
    /// Role Database Access
    /// </summary>
    public class RoleDatabaseAccess
    {
       /// <summary>
        /// Get Roles from User ID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        static public Roles GetRolesFromUserID(string UserID)
        {
            Roles roles = new Roles();
            
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();
                    SqlCeCommand cmd = new SqlCeCommand("SELECT [Role].[GUID],[Role].[Name],[Role].[Description] FROM UserRoleAssn ass join [Role] ON ass.[RoleID] = [Role].[GUID] WHERE UserID = @UserID", conn);
                  

                    //DisplayID
                    Guid guid = new Guid(UserID);
                    cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@UserID"].Value = guid;

                    SqlCeDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        Role role = new Role();
                        role.GUID = reader["GUID"].ToString() as string;
                        role.Name = reader["Name"] as string;
                        role.Description = reader["Description"] as string;
                        roles.Add(role);
                    }

                    conn.Close();

                }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Roles from database.");
            }
           

            return roles;

        }//end function
        
        /// <summary>
        /// Delete Role
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        static public void DeleteRole(string userID, string roleID)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmdDel = new SqlCeCommand(" DELETE FROM [UserRoleAssn] WHERE (UserID = @UserID and RoleID = @RoleID)", conn);
                   

                    //UserID
                    Guid guid = new Guid(userID);
                    cmdDel.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@UserID"].Value = guid;

                    //RoleID
                    Guid guid2 = new Guid(roleID);
                    cmdDel.Parameters.Add("@RoleID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@RoleID"].Value = guid2;


                    cmdDel.ExecuteNonQuery();

                    conn.Close();
                }
                

                
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Roles from database.");
            }
            

        }//end function


        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        static public Roles GetAllRoles()
        {
            Roles roles = new Roles();

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();
                    SqlCeCommand cmd = new SqlCeCommand("SELECT [GUID],[Name],[Description] FROM [Role]", conn);
                  

                    SqlCeDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        Role role = new Role();
                        role.GUID = reader["GUID"].ToString() as string;
                        role.Name = reader["Name"] as string;
                        role.Description = reader["Description"] as string;
                        roles.Add(role);
                    }

                    conn.Close();

                }//using
            }
           catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Roles from database.");
            }

            return roles;

        }//end function


        /// <summary>
        /// Add Roles to User
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        static public void AddRolesToUser(string userID, string roleID)
        {
            try
            {
                using(SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmdAdd = new SqlCeCommand(" INSERT INTO [UserRoleAssn] ([UserID],[RoleID]) VALUES (@UserID, @RoleID)", conn);
                   

                    //UserID
                    Guid guid = new Guid(userID);
                    cmdAdd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@UserID"].Value = guid;

                    //RoleID
                    Guid guid2 = new Guid(roleID);
                    cmdAdd.Parameters.Add("@RoleID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@RoleID"].Value = guid2;


                    cmdAdd.ExecuteNonQuery();

                    conn.Close();

                }
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Roles from database.");
            }

        }//end function

    }
}
