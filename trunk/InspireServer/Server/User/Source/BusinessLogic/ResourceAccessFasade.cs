using Inspire.Users.DataAccess;
using Inspire.Users.DataContracts;

namespace Inspire.Users.BusinessLogic
{
    /// <summary>
    /// Resource Access Fasade
    /// </summary>
     public class ResourceAccessFasade
    {
        /// <summary>
        /// Login Attempt
        /// </summary>
        /// <returns></returns>
        static public bool LoginAttempt(string login, string pass)
        {
            return UserDatabaseAccess.LoginAttempt(login, pass);
        }

         /// <summary>
         /// Get Users
         /// </summary>
         /// <returns></returns>
         static public DataContracts.Users GetUsers()
        {
           return UserDatabaseAccess.GetUsers();
        }

         /// <summary>
         /// Add a User
         /// </summary>
         /// <param name="user"></param>
         static public void AddUser(DataContracts.User user)
        {
            UserDatabaseAccess.AddUser(user);
        }

         /// <summary>
         /// Delete User
         /// </summary>
         /// <param name="userID"></param>
        static public void DeleteUser(string userID)
        {
            UserDatabaseAccess.DeleteUser(userID);
        }

         /// <summary>
         /// Get Roles From User ID
         /// </summary>
         /// <param name="userID"></param>
         /// <returns></returns>
        static public Roles GetRolesFromUserID(string userID)
        {
            return RoleDatabaseAccess.GetRolesFromUserID(userID);
        }

         /// <summary>
         /// Delete Role
         /// </summary>
         /// <param name="userID"></param>
         /// <param name="roleID"></param>
        static public void DeleteRole(string userID, string roleID)
        {
            RoleDatabaseAccess.DeleteRole(userID, roleID);
        }

         /// <summary>
         /// Get All Roles
         /// </summary>
         /// <returns></returns>
        static public Roles GetAllRoles()
        {
            return RoleDatabaseAccess.GetAllRoles();
        }

         /// <summary>
         /// Add Roles To User
         /// </summary>
         /// <param name="userID"></param>
         /// <param name="roleID"></param>
        static public void AddRolesToUser(string userID, string roleID)
        {
            RoleDatabaseAccess.AddRolesToUser(userID, roleID);
        }


    }
}
