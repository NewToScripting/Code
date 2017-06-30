using System;
using System.Data;
using System.Data.SqlClient;
using Inspire.Users.DataContracts;
using System.Configuration;
using Inspire.Server.Common;
using System.Data.SqlServerCe;


namespace Inspire.Users.DataAccess
{
    /// <summary>
    /// User Database Access
    /// </summary>
   public class UserDatabaseAccess
    {
       /// <summary>
       /// Get Users
       /// </summary>
       /// <returns></returns>
        static public DataContracts.Users GetUsers()
        {
           DataContracts.Users users = new DataContracts.Users();

           try
           {
               using (SqlCeConnection conn = CommonDataConnection.GetConnection())
               {
                   conn.Open();
                   SqlCeCommand cmd = new SqlCeCommand("SELECT [GUID],[Name],[Login],[Description],[Password],[LastSuccessfulLogin],[LastLoginAttempt],[IncorrectLoginCount] FROM [User] us", conn);
              

                   SqlCeDataReader reader = cmd.ExecuteReader();


                   while (reader.Read())
                   {
                       DataContracts.User user = new DataContracts.User();
                       user.GUID = reader["GUID"].ToString() as string;
                       user.Name = reader["Name"] as string;
                       user.Login = reader["Login"] as string;
                       user.Description = reader["Description"] as string;
                       user.Password = reader["Password"] as string;

                       user.Roles = RoleDatabaseAccess.GetRolesFromUserID(user.GUID);

                       users.Add(user);
                   }

                   conn.Close();

               }//using
           }
           catch (Exception e)
           {
               EventLogger.LogAndThrowFault(e.Message, "Error retrieving Users from database.");
           }

            return users;

        }//end function

       /// <summary>
       /// Add User
       /// </summary>
       /// <param name="user"></param>
        static public void AddUser(DataContracts.User user)
        {
           try
           {
               using (SqlCeConnection conn = CommonDataConnection.GetConnection())
               {
                   conn.Open();

                   SqlCeCommand cmdAdd = new SqlCeCommand("INSERT INTO [User] ([GUID],[Name],[Login],[Description],[Password]) VALUES (@GUID,@Name,@Login,@Description, @Password)", conn);
                  

                   //GUID
                   Guid guid = new Guid(user.GUID);
                   cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                   cmdAdd.Parameters["@GUID"].Value = guid;

                   //Name
                   cmdAdd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
                   cmdAdd.Parameters["@Name"].Value = user.Name;

                   //Description
                   cmdAdd.Parameters.Add("@Description", SqlDbType.NVarChar, 200);
                   cmdAdd.Parameters["@Description"].Value = user.Description;

                   //Login
                   cmdAdd.Parameters.Add("@Login", SqlDbType.NVarChar, 100);
                   cmdAdd.Parameters["@Login"].Value = user.Login;

                   //Password
                   cmdAdd.Parameters.Add("@Password", SqlDbType.NVarChar, 50);
                   cmdAdd.Parameters["@Password"].Value = user.Password;

                   if (user.Roles != null)
                   {
                       foreach (Role item in user.Roles) RoleDatabaseAccess.AddRolesToUser(user.GUID, item.GUID);
                   }

                   cmdAdd.ExecuteNonQuery();

                   conn.Close();

               }//using
           }
           catch (Exception e)
           {
               EventLogger.LogAndThrowFault(e.Message, "Error retrieving Users from database.");
           }
           
        }//end function

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="userID"></param>
       static public void DeleteUser(string userID)
       {
           try
           {
               using (SqlCeConnection conn = CommonDataConnection.GetConnection())
               {
                   conn.Open();
                   SqlCeCommand cmdDel = new SqlCeCommand("DELETE FROM [User] WHERE [User].[GUID] = @GUID", conn);
              
                   //GUID
                   Guid guid = new Guid(userID);
                   cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                   cmdDel.Parameters["@GUID"].Value = guid;

                   cmdDel.ExecuteNonQuery();

                   SqlCeCommand cmdDel2 = new SqlCeCommand("DELETE FROM UserRoleAssn WHERE UserID = @GUID", conn);
              
                   cmdDel2.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                   cmdDel2.Parameters["@GUID"].Value = guid;

                   cmdDel2.ExecuteNonQuery();


                   conn.Close();

               }
           }
           catch (Exception e)
           {
               EventLogger.LogAndThrowFault(e.Message, "Error retrieving Users from database.");
           }

       }
            
       /// <summary>
       /// Add User
       /// </summary>
       /// <param name="user"></param>
       static public bool LoginAttempt(string user, string pass)
        {
            bool auth = false;

           try
           {
               using (SqlCeConnection conn = CommonDataConnection.GetConnection())
               {
                   conn.Open();

                   SqlCeCommand cmdAdd = new SqlCeCommand("SELECT [Login] FROM [User] us WHERE us.[Login] = @Login AND us.[Password] = @Password", conn);
              

                   //Login
                   cmdAdd.Parameters.Add("@Login", SqlDbType.NVarChar, 100);
                   cmdAdd.Parameters["@Login"].Value = user;

                   //Password
                   cmdAdd.Parameters.Add("@Password", SqlDbType.NVarChar, 50);
                   cmdAdd.Parameters["@Password"].Value = pass;

                   if (null != cmdAdd.ExecuteScalar())
                     auth = true;      
                   
                   conn.Close();

               }//using
           }
           catch (Exception e)
           {
               EventLogger.LogAndThrowFault(e.Message, "Error attempting to login.");
           }

           return auth;
           
        }//end function
    }//class
}//namespace
