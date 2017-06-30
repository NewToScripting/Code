using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Diagnostics;
using Inspire.Server.Common;
using Inspire.Server.Display.DataAccess;

namespace Inspire.Server.DisplayAdmin.DataAccess
{
    public class DisplayDatabaseAccess
    {
        /// <summary>
        /// Get display host names 
        /// </summary>
        /// <returns>List of host names</returns>
        static public List<string> GetDisplayHostNames()
        {
            var hostNames = new List<string>();

            try
            {
                using(SqlCeConnection conn = CommonDataConnection.GetConnection())
                    {
                        conn.Open();

                        string sql = DisplaySql.GetDisplayHostnames();
                        var cmd = new SqlCeCommand(sql, conn);
                        SqlCeDataReader reader = cmd.ExecuteReader();

                        if (reader != null)
                            while (reader.Read())
                            {
                                string hostName = reader["HostName"] as string;
                                hostNames.Add(hostName);
                            }

                        conn.Close();

                    }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault("Server failed to getting hostnames from database." + Environment.NewLine + e.InnerException, "");
            }
           
            return hostNames;
        }//end function


        /// <summary>
        /// Get display ID from hostname
        /// </summary>
        /// <param name="hostName">Hostname</param>
        /// <returns>Display ID</returns>
        static public string GetDisplayID(string hostName)
        {
            string guid = null;
            
            try
            {
                  using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                    {
                        conn.Open();

                        string sql = DisplaySql.GetDisplayFromHostName(hostName);

                        SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                     
                        guid = cmd.ExecuteScalar().ToString();
                        conn.Close();

                    }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault("Server failed to get display ID from database." + Environment.NewLine + e.InnerException, "");
            }

            return guid;

        }//end function


        /// <summary>
        /// Update active flag for displays in database
        /// </summary>
        /// <param name="displayID"></param>
        /// <param name="activeFlag"></param>
        /// <param name="lastCommunication"></param>
        static public void UpdateDisplayActiveFlag()
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = DisplaySql.UpdateDisplayActiveFlag();
                    var cmd = new SqlCeCommand(sql, conn);
                    SqlCeDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                        while (reader.Read())
                        {
                            string hostName = reader["HostName"] as string;
                            EventLogger.LogAndThrowFault("Display with hostname " + hostName + " is not reporting to the server.", "");
                        }

                    conn.Close();

                }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault("Server failed to update active flags in database." + Environment.NewLine + e.InnerException, "");
            }
        }

    }
}
