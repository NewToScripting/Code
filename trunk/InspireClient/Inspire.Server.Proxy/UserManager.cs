using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using Inspire.Server.Proxy.UserServiceReference;
using Inspire.Server.Proxy.SettingsServiceReference;

namespace Inspire.Server.Proxy
{
    /// <summary>
    /// User Manager 
    /// </summary>
    public class UserManager
    {
        /// <summary>
        /// Authenticate User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        static public AuthResult AuthenticateUser(User user)
        {
            AuthResult authResult = new AuthResult();
            
            try
            {
                UserServiceContractClient client = new UserServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetUserEndpoint();

                authResult.UserAuthorized = client.LoginAttempt(user.Login, user.Password);

                authResult.TrialVersion = IsTrialVersion();

                authResult.RegDate = GetRegDate();

            }
            catch (Exception e)
            {
                
                ProxyErrorHandler.Throw(e, "Error occured while authenticating a user");
                return authResult;
            }

            return authResult;

        }//end function


        /// <summary>
        /// Get Users
        /// </summary>
        /// <returns></returns>
        static public List<User> GetUsers()
        {
            
            List<User> users = new List<User>();

            try
            {
                UserServiceContractClient client = new UserServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetUserEndpoint();
                Inspire.Server.Proxy.UserServiceReference.Users proxyUsers = client.GetUsers();
                
                User user = new User();

                foreach(Inspire.Server.Proxy.UserServiceReference.User item in proxyUsers)
                    {
                        user = ProxyUserToDirectionUser(item);
                        users.Add(user);
                    }

            }
            catch(EndpointNotFoundException)
            {
                return null;
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting users");
                throw e;
            }
            return users;

        }//end function

        /// <summary>
        /// Get Roles from UserID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        static public List<Role> GetRolesFromUserID(string UserID)
        {
            List<Role> roles = new List<Role>();

            try
            {
                UserServiceContractClient client = new UserServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetUserEndpoint();

                Inspire.Server.Proxy.UserServiceReference.Roles proxyRoles = client.GetRolesFromUserID(UserID);

                Role role;
                foreach (Inspire.Server.Proxy.UserServiceReference.Role item in proxyRoles)
                {
                    role = ProxyRoleToDirectionRole(item);
                    roles.Add(role);
                }
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting roles from user ID");
            }

            return roles;

        }//end function

        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        static public List<Role> GetAllRoles()
        {
            List<Role> roles = new List<Role>();

            try
            {
                UserServiceContractClient client = new UserServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetUserEndpoint();

                Inspire.Server.Proxy.UserServiceReference.Roles proxyRoles = client.GetAllRoles();
                
                Role role = new Role();
                foreach (Inspire.Server.Proxy.UserServiceReference.Role item in proxyRoles)
                {
                    role = ProxyRoleToDirectionRole(item);
                    roles.Add(role);
                }
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting all users");
            }

            return roles;

        }//end function

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="user"></param>
        static public void AddUser(User user)
        {
            Inspire.Server.Proxy.UserServiceReference.User proxyUser = UserDirectionToProxyUser(user);

            try
            {
                UserServiceContractClient client = new UserServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetUserEndpoint();
                client.AddUser(proxyUser);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting a user");
            }
            
                
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
                UserServiceContractClient client = new UserServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetUserEndpoint();
                client.AddRolesToUser(roleID, userID);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while adding role to a user");
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
                UserServiceContractClient client = new UserServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetUserEndpoint();
                client.DeleteUser(userID);

            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while deleting a user");
            }
           

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
                UserServiceContractClient client = new UserServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetUserEndpoint();
                client.DeleteRole(roleID, userID);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while deleting a role");
            }


        }//end function

        /// <summary>
        /// Translate ProxyUser To DirectionUser
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static User ProxyUserToDirectionUser(UserServiceReference.User from)
        {
            User to = new User();

            to.Description = from.Description;
            to.GUID = from.GUID;
            to.Login = from.Login;
            to.Name = from.Name;
            to.Password = from.Password;
            to.Roles = DirectionRolesToProxyRoles(from.Roles);

            return to;
        }

        /// <summary>
        /// Translate UserDirection To ProxyUser
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static UserServiceReference.User UserDirectionToProxyUser(User from)
        {
            UserServiceReference.User to = new UserServiceReference.User();
            
            to.Description = from.Description;
            to.GUID = from.GUID;
            to.Login = from.Login;
            to.Password = from.Password;
            to.Name = from.Name;
            to.Roles = DirectionRolesToProxyRoles(from.Roles);

            return to;
        }

        /// <summary>
        /// Translate DirectionRoles To ProxyRoles
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static Roles DirectionRolesToProxyRoles(List<Role> from)
        {
            Inspire.Server.Proxy.UserServiceReference.Roles to = new Roles();
            Inspire.Server.Proxy.UserServiceReference.Role role = new UserServiceReference.Role();

            foreach (Role item in from)
                {
                    role = DirectionRoleToProxyRole(item);
                    to.Add(role);
                }

            return to;
        }

        /// <summary>
        /// Translate DirectionRoles To ProxyRoles
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static List<Role> DirectionRolesToProxyRoles(Roles from)
        {
            List<Role> to = new List<Role>();
            Role role;

            foreach (UserServiceReference.Role item in from)
            {
                role = ProxyRoleToDirectionRole(item);
                to.Add(role);
            }

            return to;
        }

        /// <summary>
        /// Translate ProxyRole To DirectionRole
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static Role ProxyRoleToDirectionRole(UserServiceReference.Role from)
        {
            Role to = new Role();

            to.Description = from.Description;
            to.GUID = from.GUID;
            to.Name = from.Name;

            return to;
        }

        /// <summary>
        /// Translate DirectionRole To ProxyRole
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static UserServiceReference.Role DirectionRoleToProxyRole(Role from)
        {
            Inspire.Server.Proxy.UserServiceReference.Role to = new UserServiceReference.Role();

            to.Description = from.Description;
            to.GUID = from.GUID;
            to.Name = from.Name;
            

            return to;
        }

        /// <summary>
        /// Get Valid Registation Key
        /// </summary>
        /// <returns></returns>
        private static bool IsTrialVersion()
        {
            try
            {
                if (ConfigurationManager.AppSettings["RegId"] == "737B5018-5847-4049-8D38-BF6542BB721A")
                {
                    return false;
                    //Enterprise version does not require registration
                }

                SettingServiceContractClient client = new SettingServiceContractClient();
                     client.Endpoint.Address = SeverSettings.GetSettingsEndpoint();

                     Setting regSetting = client.GetSetting("RegKey");

                     if (String.IsNullOrEmpty(regSetting.Value))
                     {
                         Setting newSetting = new Setting();
                         newSetting.Key = "RegKey";
                         newSetting.Value = Guid.Empty.ToString();

                         client.AddSetting(newSetting);

                         return true;
                     }

                     if (regSetting.Value == Guid.Empty.ToString())
                     {
                         return true;
                     }

                     if (regSetting.Value != Guid.Empty.ToString())
                     {
                         return false;
                     }

                 
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting reg key");
                //throw e;
            }
            
            return true;
        }


        /// <summary>
        /// Get Valid Registation Date
        /// </summary>
        /// <returns></returns>
        private static DateTime GetRegDate()
        {
            Setting regSetting = new Setting();
            Setting newSetting = new Setting();

            int demoDays = 30;

            if (ConfigurationManager.AppSettings["DebugVal"] != null)
            {
                demoDays = (int.Parse(ConfigurationManager.AppSettings["DebugVal"]));
            }
            
            try
            {
                SettingServiceContractClient client = new SettingServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetSettingsEndpoint();

                regSetting = client.GetSetting("RegDate");

                if (String.IsNullOrEmpty(regSetting.Value))
                {
                    newSetting.Key = "RegDate";
                    newSetting.Value = DateTime.Now.AddDays(demoDays).ToString();

                    client.AddSetting(newSetting);

                    return DateTime.Parse(newSetting.Value);
                }
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting users");
                //throw e;
            }

            return DateTime.Parse(regSetting.Value);
        }


    }//class

}//namespace