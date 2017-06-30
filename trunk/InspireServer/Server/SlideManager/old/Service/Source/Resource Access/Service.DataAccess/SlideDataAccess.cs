using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Inspire.Server.SlideManager.DataContracts;

namespace Inspire.Server.SlideManager.DataAccess
{
    public class SlideDataAccess
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
        /// Get All Slides
        /// </summary>
        /// <returns></returns>
        static public Slides GetAllSlides()
        {
            Slides slides = new Slides();

            //try
            //{
                using (SqlConnection conn = GetConnected())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("slides_get_v1", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                        while (reader.Read())
                        {
                            Slide slide = new Slide();

                            slide.GUID = reader["GUID"].ToString() as string;
                            slide.Name = reader["Name"] as string;
                            slide.Description = reader["Description"] as string;

                            if (reader["VResolution"] != null)
                                slide.VResolution = Convert.ToDouble(reader["VResolution"].ToString() as string);

                            if (reader["HResolution"] != null)
                                slide.HResolution = Convert.ToDouble(reader["HResolution"].ToString() as string);

                            slide.Thumbnail = reader["Thumbnail"] as Byte[];

                            slide.LastModifiedDate = reader["LastModifiedDate"] as DateTime?;
                            slide.ModifiedBy = reader["ModifiedBy"] as string;
                            slide.DefaultDuration = reader["DefaultDuration"] as DateTime?;

                            slide.Rules = RuleDataAccess.GetRules(slide.GUID);
                            slide.Tags = TagDataAccess.GetTags(slide.GUID);
                            //slide.TouchScreenButtons = ButtonDataAccess.GetButtons(slide.GUID);

                            slides.Add(slide);
                        }

                    conn.Close();

                }//using
            //}//try

            //catch (Exception e)
            //{
            //    EventLogger.LogAndThrowFault(e.Message, "Error retrieving Slides from database.");
            //}
             
           return slides;

        }//end function

        /// <summary>
        /// Get Slide
        /// </summary>
        /// <param name="slideID"></param>
        /// <returns></returns>
        static public Slide GetSlide(string slideID)
        {
            Slide slide = new Slide();

            try
            {
                using (SqlConnection conn = GetConnected())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("slide_get_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(slideID);
                    cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@GUID"].Value = guid;

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                        while (reader.Read())
                        {
                            slide.GUID = reader["GUID"].ToString() as string;
                            slide.Name = reader["Name"] as string;
                            slide.Description = reader["Description"] as string;

                            if (reader["VResolution"] != null)
                                slide.VResolution = Convert.ToDouble(reader["VResolution"].ToString() as string);

                            if (reader["HResolution"] != null)
                                slide.HResolution = Convert.ToDouble(reader["HResolution"].ToString() as string);

                            slide.Thumbnail = reader["Thumbnail"] as Byte[];

                            slide.LastModifiedDate = reader["LastModifiedDate"] as DateTime?;
                            slide.ModifiedBy = reader["ModifiedBy"] as string;
                            slide.DefaultDuration = reader["DefaultDuration"] as DateTime?;

                            slide.Rules = RuleDataAccess.GetRules(slide.GUID);
                            slide.Tags = TagDataAccess.GetTags(slide.GUID);
                            //slide.TouchScreenButtons = ButtonDataAccess.GetButtons(slide.GUID);

                        }
                    conn.Close();

                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Slide from database.");
            }
            
            return slide;

        }//end function

        /// <summary>
        /// Add Slide
        /// </summary>
        /// <param name="slide"></param>
        static public void AddSlide(Slide slide)
        {
            //try
            //{
                using (SqlConnection conn = GetConnected())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("slide_add_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(slide.GUID);
                    cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@GUID"].Value = guid;

                    //Name
                    cmdAdd.Parameters.Add("@Name", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Name"].Value = slide.Name;

                    //Description
                    cmdAdd.Parameters.Add("@Description", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@Description"].Value = slide.Description;

                    //VResolution
                    cmdAdd.Parameters.Add("@VResolution", SqlDbType.Float);
                    cmdAdd.Parameters["@VResolution"].Value = slide.VResolution;

                    //HResolution
                    cmdAdd.Parameters.Add("@HResolution", SqlDbType.Float);
                    cmdAdd.Parameters["@HResolution"].Value = slide.HResolution;


                    //ThumbNail
                    cmdAdd.Parameters.Add("@ThumbNail", SqlDbType.Image);
                    cmdAdd.Parameters["@ThumbNail"].Value = slide.Thumbnail;

                    //LastModifiedDate
                    cmdAdd.Parameters.Add("@LastModifiedDate", SqlDbType.DateTime);
                    cmdAdd.Parameters["@LastModifiedDate"].Value = slide.LastModifiedDate;

                    //ModifiedBy
                    cmdAdd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar, 100);
                    cmdAdd.Parameters["@ModifiedBy"].Value = slide.ModifiedBy;

                    //DefaultDuration
                    cmdAdd.Parameters.Add("@DefaultDuration", SqlDbType.DateTime);
                    cmdAdd.Parameters["@DefaultDuration"].Value = slide.DefaultDuration;

                          
                    cmdAdd.ExecuteNonQuery();

                    conn.Close();

                    foreach(SlideRule item in slide.Rules)
                    { 
                        RuleDataAccess.AddRule(item);
                    }
                    foreach (SlideTag item in slide.Tags)
                    {
                        TagDataAccess.AddTag(item);
                    }
                    //foreach (TouchScreenButton item in slide.TouchScreenButtons)
                    //{
                    //   ButtonDataAccess.AddButton(item);
                    //}  
            
                }//using
            //}//try
            //catch (Exception e)
            //{
            //    EventLogger.LogAndThrowFault(e.Message, "Error adding Slide from database.");
            //}
            

        }//end function
        
        /// <summary>
        /// Delete Slide
        /// </summary>
        /// <param name="slideID"></param>
        static public void DeleteSlide(string slideID)
        {
            try
            {
                using(SqlConnection conn = GetConnected())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("slide_delete_v1", conn);
                    cmdDel.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(slideID);
                    cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@GUID"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();

                    RuleDataAccess.DeleteRules(slideID);
                    TagDataAccess.DeleteTags(slideID);
                    //ButtonDataAccess.DeleteButtons(slideID);
                               
                }//using
            
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing Slide from database.");
            }
            
          }//end function

    }
}
