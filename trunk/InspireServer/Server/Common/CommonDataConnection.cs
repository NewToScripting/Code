using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;

namespace Inspire.Server.Common
{
  public class CommonDataConnection
    {
        /// <summary>
        /// Get SQL Connection
        /// </summary>
        /// <returns></returns>
        static public SqlCeConnection GetConnection()
        {
            SqlCeConnection conn = new SqlCeConnection();
            try
            {
                //remove C://
                string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Remove(0, 8);

                string connString = "Data Source=" + path + @"\InspireServerDB.sdf; Password=!nspire8DB;";
              
                //string connString = ConfigurationManager.ConnectionStrings["Inspire.Data"].ToString();

                conn.ConnectionString = connString;
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error connecting to User database.");
            }
            return conn;
        }
    }
}
