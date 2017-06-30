using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Inspire.Server.SlideManager.DataContracts;


namespace Inspire.Server.SlideManager.DataAccess
{
    public class SlideFileDataAccess
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
                EventLogger.LogAndThrowFault(e.Message, "Error connection to Slides database.");
            }
            
            return conn;
        }

        /// <summary>
        /// Get Slide File
        /// </summary>
        /// <param name="slideID"></param>
        /// <returns></returns>
        static public SlideFile GetSlideFile(string slideID)
        {
            SlideFile slideFile = new SlideFile();

            try
            {
                using (SqlConnection conn = GetConnected())
                {
                    conn.Open();

                    Guid guid = new Guid(slideID);

                    SqlCommand cmd = new SqlCommand("slidefile_get_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //GUID
                    cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@GUID"].Value = guid;

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                        while (reader.Read())
                        {
                            slideFile.GUID = reader["GUID"].ToString() as string;
                            slideFile.File = reader["File"] as Byte[];
                        }

                    conn.Close();

                }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving to Slide from database.");
            }
            
            return slideFile;

        }//end function

        /// <summary>
        /// Add Slide File
        /// </summary>
        /// <param name="slideFile"></param>
        static public void AddSlideFile(SlideFile slideFile)
        {
            try
            {
                using(SqlConnection conn = GetConnected())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("slidefile_add_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(slideFile.GUID);
                    cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@GUID"].Value = guid;

                    //Name
                    cmdAdd.Parameters.Add("@File", SqlDbType.VarBinary);
                    cmdAdd.Parameters["@File"].Value = slideFile.File;

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding Slide to database.");
            }

        }//end function

        static public void UpdateSlideFile(SlideFile slideFile)
        {
            try
            {
                using (SqlConnection conn = GetConnected())
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("slidefile_update_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(slideFile.GUID);
                    cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@GUID"].Value = guid;

                    //Name
                    cmd.Parameters.Add("@File", SqlDbType.VarBinary);
                    cmd.Parameters["@File"].Value = slideFile.File;

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error updating Slide on database.");
            }
            
        }//end function

        /// <summary>
        /// Delete Slide File
        /// </summary>
        /// <param name="slideID"></param>
        static public void DeleteSlideFile(string slideID)
        {
            try
            {
                using(SqlConnection conn = GetConnected())
                {
                    conn.Open();
                    SqlCommand cmdDel = new SqlCommand("slidefile_delete_v1", conn);
                    cmdDel.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(slideID);
                    cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@GUID"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();
                }//using
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing Slide from database.");
            }
            

           
            

        }//end function





    }
}
