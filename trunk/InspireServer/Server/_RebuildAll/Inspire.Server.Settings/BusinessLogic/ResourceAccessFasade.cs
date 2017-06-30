using Inspire.Settings.DataAccess;
using Inspire.Settings.DataContracts;

namespace Inspire.Settings.BusinessLogic
{
    /// <summary>
    /// Resource Access Fasade
    /// </summary>
     public class ResourceAccessFasade
    {
       
         /// <summary>
        /// Get Settings
         /// </summary>
         /// <returns></returns>
         static public DataContracts.Setting GetSetting(string key)
        {
            return SettingDatabaseAccess.GetSetting(key);
        }

         /// <summary>
         /// Add a User
         /// </summary>
         /// <param name="user"></param>
         static public void AddSetting(Setting setting)
        {
            SettingDatabaseAccess.AddSetting(setting);
        }

         /// <summary>
         /// Delete User
         /// </summary>
         /// <param name="userID"></param>
         static public void DeleteSetting(string key)
        {
            SettingDatabaseAccess.DeleteSetting(key);
        }

         

    }
}
