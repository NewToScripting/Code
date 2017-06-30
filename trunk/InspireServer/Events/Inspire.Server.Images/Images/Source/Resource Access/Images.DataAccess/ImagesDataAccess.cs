using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Inspire.Server.Images.DataContracts;
using Inspire.Server.Common;
using System.Configuration;

namespace Inspire.Server.Images.DataAccess
{
    /// <summary>
    /// Direction Database Access
    /// </summary>
    public class ImagesDataAccess
    {
        /// <summary>
        /// Get SQL Connection
        /// </summary>
        /// <returns></returns>
        static private SqlConnection GetConnection()
        {
            var conn = new SqlConnection();

            try
            {
                string connString = ConfigurationManager.ConnectionStrings["Inspire.Events"].ToString();
                conn.ConnectionString = connString;
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error connecting to Direction database.");
            }

            return conn;

        }



        /// <summary>
        /// Get Directional Images
        /// </summary>
        /// <returns></returns>
        static public EventImages GetDirectionalImages(int type)
        {
            EventImages images = new EventImages();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("event_images_get_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Description
                    cmd.Parameters.Add("@type", SqlDbType.Int);
                    cmd.Parameters["@type"].Value = type;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        EventImage image = new EventImage();
                        image.GUID = reader["GUID"].ToString();
                        image.Description = reader["description"] as string;
                        image.WebPath = ConfigurationManager.AppSettings["ImageWebFolder"].ToString() + image.GUID + reader["file_extension"] as string;
                        image.FileExtension = reader["file_extension"] as string;
                        image.Type = reader["type"] as int?;
                        images.Add(image);
                    }

                    conn.Close();

                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Directional Image from database.");
            }
            return images;

        }//end function


        /// <summary>
        /// Add Directional Image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        static public string AddDirectionalImage(EventImage image, Byte[] file)
        {
            try
            {
                using (BinaryWriter binWriter = new BinaryWriter(File.Open(System.AppDomain.CurrentDomain.BaseDirectory + "/" + ConfigurationManager.AppSettings["ImageLocalFolder"].ToString() + "/" + image.GUID + image.FileExtension, FileMode.Create)))
                {
                    binWriter.Write(file);
                }

            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding Directional Image to server file system.");
            }

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("event_image_add_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(image.GUID);
                    cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@GUID"].Value = guid;

                    //Description
                    cmdAdd.Parameters.Add("@description", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@description"].Value = image.Description;

                    //ImagePath
                    cmdAdd.Parameters.Add("@file_extension", SqlDbType.NVarChar, 50);
                    cmdAdd.Parameters["@file_extension"].Value = image.FileExtension;

                    //Type
                    cmdAdd.Parameters.Add("@type", SqlDbType.Int);
                    cmdAdd.Parameters["@type"].Value = image.Type;

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();
                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding Directional Image to database");
            }

            return ConfigurationManager.AppSettings["ImageWebFolder"].ToString() + image.GUID + image.FileExtension;

        }//end function


        /// <summary>
        /// Delete Directional Image
        /// </summary>
        /// <param name="image"></param>
        static public void DeleteDirectionalImage(EventImage image)
        {
            try
            {
                File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "/" + ConfigurationManager.AppSettings["ImageLocalFolder"].ToString() + "/" + image.GUID + image.FileExtension);
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing Directional Images from server file system.");
            }

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("event_image_delete_v1", conn);
                    cmdDel.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(image.GUID);
                    cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@GUID"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();

                }//using

            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing Directional Images from database.");
            }

        }//end function
    }//class
}//namespace
