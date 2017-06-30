using System;
using System.Data;
using System.Data.SqlServerCe;
using Inspire.Settings.DataContracts;
using Inspire.Server.Common;



namespace Inspire.Settings.DataAccess
{
    /// <summary>
    /// User Database Access
    /// </summary>
    public class SettingDatabaseAccess
    {
       /// <summary>
       /// Get Users
       /// </summary>
       /// <returns></returns>
        static public DataContracts.Setting GetSetting(string key)
        {
            Setting setting = new Setting();

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();
                    SqlCeCommand cmd = new SqlCeCommand("SELECT [Value], [Key] FROM Setting WHERE [Key] = @Key", conn);

                    //Name
                    cmd.Parameters.Add("@Key", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Key"].Value = key;

                    SqlCeDataReader reader = cmd.ExecuteReader();
                    

                    while (reader.Read())
                    {
                        setting.Key= reader["Key"] as string;
                        setting.Value = reader["Value"] as string;
                    }

                    conn.Close();
                }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Setting from database.");
            }

            return setting;

        }//end function

       /// <summary>
       /// Add User
       /// </summary>
       /// <param name="user"></param>
        static public void AddSetting(Setting setting)
       {
           DeleteSetting(setting.Key);

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmdAdd = new SqlCeCommand(" INSERT INTO [Setting] ([Key],[Value]) VALUES (@Key, @Value)", conn);
                    
                    //Name
                    cmdAdd.Parameters.Add("@Key", SqlDbType.NVarChar, 100);
                    cmdAdd.Parameters["@Key"].Value = setting.Key;

                    //Description
                    cmdAdd.Parameters.Add("@Value", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Value"].Value = setting.Value;
                    
                    cmdAdd.ExecuteNonQuery();

                    conn.Close();

                }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding setting from database.");
            }
           
        }//end function

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="userID"></param>
        static public void DeleteSetting(string key)
       {
           try
           {
               using (SqlCeConnection conn = CommonDataConnection.GetConnection())
               {
                   conn.Open();
                   SqlCeCommand cmdDel = new SqlCeCommand(" DELETE FROM Setting WHERE [Key] = @Key", conn);
                
                   cmdDel.Parameters.Add("@Key", SqlDbType.NVarChar, 100);
                   cmdDel.Parameters["@Key"].Value = key;

                   cmdDel.ExecuteNonQuery();
                   conn.Close();

               }
           }
           catch (Exception e)
           {
               EventLogger.LogAndThrowFault(e.Message, "Error removing setting from database.");
           }

       }
            
   
    }//class
}//namespace
