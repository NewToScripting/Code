using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using Inspire.Server.SlideManager.DataContracts;
using Inspire.Server.Common;
using Inspire.Server.Common.DataContracts;

namespace Inspire.Server.SlideManager.DataAccess
{
    public class SlideDataAccess
    {

        /// <summary>
        /// Get All Slides
        /// </summary>
        /// <returns></returns>
        static public Slides GetAllSlides()
        {
            Slides slides = new Slides();

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();
                    string sql = SlideSQL.GetAllSlides();

                    SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                    SqlCeDataReader reader = cmd.ExecuteReader();

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

                            //slide.Thumbnail = reader["Thumbnail"] as Byte[];
                            string filePath = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ThumbDirectory"] + slide.GUID + ".zip";
                            slide.Thumbnail = SlideFolderAccess.GetSlideFile(filePath);

                            slide.LastModifiedDate = reader["LastModifiedDate"] as DateTime?;
                            slide.ModifiedBy = reader["ModifiedBy"] as string;
                            slide.DefaultDuration = reader["DefaultDuration"] as DateTime?;

                            slide.Rules = RuleDataAccess.GetRules(slide.GUID);
                            slide.Tags = TagDataAccess.GetTags(slide.GUID);
                            slide.Buttons = ButtonDataAccess.GetButtons(slide.GUID);

                            slides.Add(slide);
                        }

                    conn.Close();

                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Slides from database.");
            }
             
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
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    string sql = SlideSQL.GetSlide(slideID);

                    conn.Open();

                    SqlCeCommand cmd = new SqlCeCommand(sql, conn);                  


                    SqlCeDataReader reader = cmd.ExecuteReader();

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

                            //slide.Thumbnail = reader["Thumbnail"] as Byte[];
                            string filePath = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ThumbDirectory"] + slide.GUID + ".zip";
                            slide.Thumbnail = SlideFolderAccess.GetSlideFile(filePath);

                            slide.LastModifiedDate = reader["LastModifiedDate"] as DateTime?;
                            slide.ModifiedBy = reader["ModifiedBy"] as string;
                            slide.DefaultDuration = reader["DefaultDuration"] as DateTime?;

                            slide.Rules = RuleDataAccess.GetRules(slide.GUID);
                            slide.Tags = TagDataAccess.GetTags(slide.GUID);
                            slide.Buttons = ButtonDataAccess.GetButtons(slide.GUID);

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

            try

            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = SlideSQL.AddSlide();

                    SqlCeCommand cmdAdd = new SqlCeCommand(sql, conn);
                    

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
                    //cmdAdd.Parameters.Add("@ThumbNail", SqlDbType.Image);
                    //cmdAdd.Parameters["@ThumbNail"].Value = slide.Thumbnail;
                    string filePath = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ThumbDirectory"] + slide.GUID + ".zip";
                    SlideFolderAccess.AddSlideFile(slide.Thumbnail, filePath);


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
                    foreach (Button item in slide.Buttons)
                    {
                        ButtonDataAccess.AddButton(item);
                    }  
            
                }//using
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding Slide from database.");
            }
            

        }//end function
        
        /// <summary>
        /// Delete Slide
        /// </summary>
        /// <param name="slideID"></param>
        static public void DeleteSlide(string slideID)
        {
            try
              {

                    RuleDataAccess.DeleteRules(slideID);
                    TagDataAccess.DeleteTags(slideID);
                    ButtonDataAccess.DeleteButtons(slideID);

                    using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();
                    string sql = SlideSQL.DeleteSlide();
                    SqlCeCommand cmdDel = new SqlCeCommand(sql, conn);

                    //GUID
                    Guid guid = new Guid(slideID);
                    cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@GUID"].Value = guid;

                    cmdDel.ExecuteNonQuery();


                    sql = SlideSQL.DeleteSlideScheduledSlide();
                    SqlCeCommand cmdDel2 = new SqlCeCommand(sql, conn);

                    //GUID
                    Guid guid2 = new Guid(slideID);
                    cmdDel2.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdDel2.Parameters["@GUID"].Value = guid2;

                    cmdDel2.ExecuteNonQuery();

                    sql = SlideSQL.DeleteSlideButton();
                    SqlCeCommand cmdDel3 = new SqlCeCommand(sql, conn);

                    //GUID
                    Guid guid3 = new Guid(slideID);
                    cmdDel3.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdDel3.Parameters["@GUID"].Value = guid3;

                    cmdDel3.ExecuteNonQuery();

                    conn.Close();

                               
                }//using

                string filePath = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ThumbDirectory"] + slideID + ".zip";
                File.Delete(filePath);
            
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing Slide from database.");
            }
            
          }//end function

    }
}
