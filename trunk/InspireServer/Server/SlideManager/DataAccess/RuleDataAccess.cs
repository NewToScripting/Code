using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using Inspire.Server.SlideManager.DataContracts;
using Inspire.Server.Common;

namespace Inspire.Server.SlideManager.DataAccess
{
    public class RuleDataAccess
    {
        /// <summary>
        /// Get SQL Connection
        /// </summary>
        /// <returns></returns>
        //static private SqlCeConnection GetConnected()
        //{
        //    SqlCeConnection conn = new SqlCeConnection();
                
        //        try
        //        {
        //             string connString = ConfigurationManager.ConnectionStrings["Inspire.Data"].ConnectionString;
        //             conn.ConnectionString = connString;
        //        }
        //        catch (Exception e)
        //        {
        //            EventLogger.LogAndThrowFault(e.Message, "Error connection to Rule database.");
        //        }
            
        //    return conn;
        //}

        /// <summary>
        /// Get TOuchscreen Buttons
        /// </summary>
        /// <returns></returns>
        static public SlideRules GetRules(string SlideID)
        {
            SlideRules sliderules = new SlideRules();

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();
                    SqlCeCommand cmd = new SqlCeCommand("SELECT [GUID],[SlideID],[Rule] FROM SlideRule WHERE [SlideID] = @SlideID", conn);                    

                    //GUID
                    Guid guid = new Guid(SlideID);
                    cmd.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@SlideID"].Value = guid;

                    SqlCeDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                        while (reader.Read())
                        {
                            SlideRule sliderule = new SlideRule();

                            sliderule.GUID = reader["GUID"].ToString() as string;
                            sliderule.Rule = reader["Rule"].ToString() as string;
                            sliderule.SlideID = reader["SlideID"].ToString() as string;
                            sliderules.Add(sliderule);
                        }

                    conn.Close();

                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Rules from database.");
            }

            return sliderules;

        }//end function

        /// <summary>
        /// Add Slide
        /// </summary>
        /// <param name="slide"></param>
        static public void AddRule(SlideRule sliderule)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmdAdd = new SqlCeCommand("INSERT INTO SlideRule ([GUID],[SlideID],[Rule]) VALUES (@GUID, @SlideID, @Rule)", conn);
                 

                    //GUID
                    Guid guid = new Guid(sliderule.GUID);
                    cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@GUID"].Value = guid;

                    //Rule
                    cmdAdd.Parameters.Add("@Rule", SqlDbType.NVarChar, 100);
                    cmdAdd.Parameters["@Rule"].Value = sliderule.Rule;

                    //SlideID
                    Guid guid2 = new Guid(sliderule.SlideID);
                    cmdAdd.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@SlideID"].Value = guid2;

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();

                }//using
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding Rules from database.");
            }
            

        }//end function
        
        /// <summary>
        /// Delete Slide
        /// </summary>
        /// <param name="slideID"></param>
        static public void DeleteRules(string SlideID)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmdDel = new SqlCeCommand("DELETE FROM sliderule Where [SlideID] = @SlideID", conn);
                

                    //GUID
                    Guid guid = new Guid(SlideID);
                    cmdDel.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@SlideID"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();
                }//using
            
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing Rules from database.");
            }
            
          }//end function

    }
}
