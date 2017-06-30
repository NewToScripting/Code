using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;

namespace Inspire.Server.Common
{
    public class TransactionDataAccess
    {
        /// <summary>
        /// 
        /// </summary>
        public static void ScheduleAdd()
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"INSERT INTO SystemTransactions ([TimeStamp] , TransCode, HostName ) VALUES (GETDATE(), 'SCHED_ADD', null )";
                            
                        SqlCeCommand cmdAdd = new SqlCeCommand(sql, conn);
                       
                        cmdAdd.ExecuteNonQuery();

                    conn.Close();
                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding schedule add check to the database.");
            }

        }//end function

          /// <summary>
        /// 
        /// </summary>
        public static void ScheduleUpdate()
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"INSERT INTO SystemTransactions ([TimeStamp] , TransCode, HostName ) VALUES (GETDATE(), 'SCHED_UPDT', null )";
                            
                        SqlCeCommand cmdAdd = new SqlCeCommand(sql, conn);
                       
                        cmdAdd.ExecuteNonQuery();

                    conn.Close();
                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding schedule update check to the database.");
            }

        }//end function

           /// <summary>
        /// 
        /// </summary>
        public static void ScheduleGet()
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"INSERT INTO SystemTransactions ([TimeStamp] , TransCode, HostName ) VALUES (GETDATE(), 'SCHED_GET', null )";
                            
                        SqlCeCommand cmdAdd = new SqlCeCommand(sql, conn);
                       
                        cmdAdd.ExecuteNonQuery();

                    conn.Close();
                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding schedule get check to the database.");
            }

        }//end function

        /// <summary>
        /// 
        /// </summary>
        public static void ScheduleCheck(string hostName)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = (@"INSERT INTO SystemTransactions ([TimeStamp] , TransCode, HostName ) VALUES (GETDATE(), 'UPDATE_CHK', '" + hostName +  "' )");
                    SqlCeCommand cmdAdd = new SqlCeCommand(sql, conn);

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();
                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error inserting schedule check into database.");
            }

        }//end function


    }
}
