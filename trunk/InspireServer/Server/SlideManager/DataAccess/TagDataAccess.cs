using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using Inspire.Server.SlideManager.DataContracts;
using Inspire.Server.Common;

namespace Inspire.Server.SlideManager.DataAccess
{
    public class TagDataAccess
    {
        /// <summary>
        /// Get SQL Connection
        /// </summary>
        /// <returns></returns>
        //static private SqlCeConnection GetConnected()
        //{
        //    SqlCeConnection conn = new SqlCeConnection();

        //    try
        //    {
        //        string connString = ConfigurationManager.ConnectionStrings["Inspire.Data"].ConnectionString;
        //        conn.ConnectionString = connString;
        //    }
        //    catch (Exception e)
        //    {
        //        EventLogger.LogAndThrowFault(e.Message, "Error connection to tag database.");
        //    }

        //    return conn;
        //}

        /// <summary>
        /// Get TOuchscreen Buttons
        /// </summary>
        /// <returns></returns>
        static public SlideTags GetTags(string SlideID)
        {
            SlideTags slidetags = new SlideTags();

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();
                    SqlCeCommand cmd = new SqlCeCommand("SELECT[GUID], [SlideID],[Tag] FROM SlideTag WHERE [SlideID] = @SlideID", conn);
               

                    //GUID
                    Guid guid = new Guid(SlideID);
                    cmd.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@SlideID"].Value = guid;

                    SqlCeDataReader reader = cmd.ExecuteReader();

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
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmdAdd = new SqlCeCommand("INSERT INTO SlideTag ([GUID],[SlideID],[Tag]) VALUES (@GUID, @SlideID, @Tag)", conn);
               
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
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmdDel = new SqlCeCommand("DELETE FROM slidetag Where [SlideID] = @SlideID", conn);
                    
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
