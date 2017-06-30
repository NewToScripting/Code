using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Inspire.Server.SlideManager.DataContracts;

namespace Inspire.Server.SlideManager.DataAccess
{
    public class RuleDataAccess
    {
        /// <summary>
        /// Get SQL Connection
        /// </summary>
        /// <returns></returns>
        static private SqlConnection GetConnected()
        {
            SqlConnection conn = new SqlConnection();
                
                try
                {
                     string connString = ConfigurationManager.ConnectionStrings["Inspire.Data"].ConnectionString;
                     conn.ConnectionString = connString;
                }
                catch (Exception e)
                {
                    EventLogger.LogAndThrowFault(e.Message, "Error connection to Rule database.");
                }
            
            return conn;
        }

        /// <summary>
        /// Get TOuchscreen Buttons
        /// </summary>
        /// <returns></returns>
        static public SlideRules GetRules(string SlideID)
        {
            SlideRules sliderules = new SlideRules();

            try
            {
                using (SqlConnection conn = GetConnected())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sliderules_get_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(SlideID);
                    cmd.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@SlideID"].Value = guid;

                    SqlDataReader reader = cmd.ExecuteReader();

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
                using (SqlConnection conn = GetConnected())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("sliderule_add_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(sliderule.GUID);
                    cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@GUID"].Value = guid;

                    //Rule
                    cmdAdd.Parameters.Add("@Rule", SqlDbType.NVarChar, 50);
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
                using(SqlConnection conn = GetConnected())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("sliderules_delete_v1", conn);
                    cmdDel.CommandType = CommandType.StoredProcedure;

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
