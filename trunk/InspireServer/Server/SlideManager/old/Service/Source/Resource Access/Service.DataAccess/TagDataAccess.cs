using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Inspire.Server.SlideManager.DataContracts;

namespace Inspire.Server.SlideManager.DataAccess
{
    public class TagDataAccess
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
                    EventLogger.LogAndThrowFault(e.Message, "Error connection to tag database.");
                }
            
            return conn;
        }

        /// <summary>
        /// Get TOuchscreen Buttons
        /// </summary>
        /// <returns></returns>
        static public SlideTags GetTags(string SlideID)
        {
            SlideTags slidetags = new SlideTags();

            try
            {
                using (SqlConnection conn = GetConnected())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("slidetags_get_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(SlideID);
                    cmd.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@SlideID"].Value = guid;

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                        while (reader.Read())
                        {
                            SlideTag slidetag = new SlideTag();

                            slidetag.GUID = reader["GUID"].ToString() as string;
                            slidetag.Tag = reader["Tag"].ToString() as string;
                            slidetag.SlideID = reader["SlideID"].ToString() as string;
                            slidetags.Add(slidetag);
                        }

                    conn.Close();

                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving tag from database.");
            }

            return slidetags;

        }//end function

        /// <summary>
        /// Add Slide
        /// </summary>
        /// <param name="slide"></param>
        static public void AddTag(SlideTag sliderule)
        {
            try
            {
                using (SqlConnection conn = GetConnected())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("slidetag_add_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(sliderule.GUID);
                    cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@GUID"].Value = guid;

                    //Rule
                    cmdAdd.Parameters.Add("@Tag", SqlDbType.NVarChar, 50);
                    cmdAdd.Parameters["@Tag"].Value = sliderule.Tag;

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
                EventLogger.LogAndThrowFault(e.Message, "Error adding tag from database.");
            }
            

        }//end function
        
        /// <summary>
        /// Delete Slide
        /// </summary>
        /// <param name="slideID"></param>
        static public void DeleteTags(string SlideID)
        {
            try
            {
                using(SqlConnection conn = GetConnected())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("slidetags_delete_v1", conn);
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
                EventLogger.LogAndThrowFault(e.Message, "Error removing tag from database.");
            }
            
          }//end function

    }
}
