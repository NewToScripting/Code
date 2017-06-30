using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Data.SqlTypes;
using Inspire.Server.ScheduledSlideManager.DataContracts;
using Inspire.Server.Common;
using Inspire.Server.Common.DataContracts;
using Inspire.Server.ScheduledSlideManager;
using Inspire.Server.SlideManager.DataAccess;

namespace Inspire.Server.ScheduledSlideManager.DataAccess
{
    /// <summary>
    /// Scheduled Slide Database Access
    /// </summary>
    public class ScheduledSlideDatabaseAccess
    {

        /// <summary>
       /// Get Scheduled Slides
        /// </summary>
        /// <param name="ScheduleID"></param>
        /// <returns></returns>
        static public ScheduledSlides GetScheduledSlides(string ScheduleID)
        {   
            ScheduledSlides slideList = new ScheduledSlides();

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    SqlCeCommand cmdGetSlides = new SqlCeCommand("SELECT sch.[GUID],sch.[Name],sch.[Description],sch.Transition,sch.TransitionSpeed,sch.[Version],sch.Duration,sch.OriginalSlideID,sch.ScheduleID,sld.HResolution,sld.VResolution,sch.IgnoreAllRules FROM ScheduledSlide sch left join Slide sld ON sld.GUID = sch.OriginalSlideID WHERE ScheduleID = @ScheduleID", conn);
                   
                    conn.Open();

                    //SlideID
                    cmdGetSlides.Parameters.Add("@ScheduleID", SqlDbType.NVarChar, 200);
                    cmdGetSlides.Parameters["@ScheduleID"].Value = ScheduleID;

                    SqlCeDataReader reader = cmdGetSlides.ExecuteReader();

                    while (reader.Read())
                    {
                        ScheduledSlide scheduledSlide = new ScheduledSlide();

                        scheduledSlide.GUID = reader["GUID"].ToString() as string;
                        scheduledSlide.Name = reader["Name"] as string;
                        scheduledSlide.Description = reader["Description"] as string;
                        scheduledSlide.Transition = reader["Transition"] as string;
                        if (reader["TransitionSpeed"] != null)
                            scheduledSlide.TransitionSpeed = (int)reader["TransitionSpeed"];
                        scheduledSlide.Version = reader["Version"] as string;

                        DateTime? dteDuration = reader["Duration"] as DateTime?;
                        if (dteDuration != null)
                            scheduledSlide.Duration = (DateTime)dteDuration;

                        scheduledSlide.OriginalSlideID = reader["OriginalSlideID"].ToString() as string;
                        scheduledSlide.ScheduleID = reader["ScheduleID"].ToString() as string;

                        string filePath = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ThumbDirectory"] + scheduledSlide.OriginalSlideID + ".zip";
                        scheduledSlide.ThumbNail = SlideFolderAccess.GetSlideFile(filePath);

                        scheduledSlide.HResolution = reader["HResolution"] as double?;
                        scheduledSlide.VResolution = reader["VResolution"] as double?;

                        scheduledSlide.Buttons = SlideButtonDataAccess.GetButtonNavagations(scheduledSlide.OriginalSlideID, scheduledSlide.GUID);
                        scheduledSlide.IgnoreAllRules = reader["IgnoreAllRules"] as bool?;

                        slideList.Add(scheduledSlide);
                    }//end while

                    conn.Close();

                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving ScheduledSlides from database.");
            }
            return slideList;
        }//funciton

        /// <summary>
        /// Get all slides associated with a given schedule
        /// </summary>
        /// <param name="scheduleID"></param>
        /// <returns>List<Slide></returns

        public static ScheduledSlides GetScheduledSlidesNoThumb(string scheduleID)
        {
            ScheduledSlides slideList = new ScheduledSlides();

            try
            {
                SqlCeConnection conn = CommonDataConnection.GetConnection();

            SqlCeCommand cmdGetSlides = new SqlCeCommand("SELECT [GUID],[Name],[Description],Transition,TransitionSpeed,Duration,OriginalSlideID,ScheduleID,IgnoreAllRules,Version FROM ScheduledSlide WHERE ScheduleID = @ScheduleID", conn);
          
            conn.Open();

            //SlideID
            cmdGetSlides.Parameters.Add("@ScheduleID", SqlDbType.NVarChar, 200);
            cmdGetSlides.Parameters["@ScheduleID"].Value = scheduleID;

            SqlCeDataReader reader = cmdGetSlides.ExecuteReader();



            if (reader != null)
                while (reader.Read())
                {
                    ScheduledSlide scheduledSlide = new ScheduledSlide();

                    scheduledSlide.GUID = reader["GUID"].ToString() as string;
                    scheduledSlide.Name = reader["Name"] as string;
                    scheduledSlide.Transition = reader["Transition"] as string;

                    if (reader["TransitionSpeed"] != null)
                        scheduledSlide.TransitionSpeed = (int)reader["TransitionSpeed"];
                    else
                        scheduledSlide.TransitionSpeed = 0;

                    DateTime? dteDuration = reader["Duration"] as DateTime?;
                    if (dteDuration != null)
                        scheduledSlide.Duration = (DateTime)dteDuration;

                    scheduledSlide.OriginalSlideID = reader["OriginalSlideID"].ToString() as string;
                    scheduledSlide.ScheduleID = reader["ScheduleID"].ToString() as string;
                    scheduledSlide.Version = reader["Version"] as string;

                    scheduledSlide.Buttons = SlideButtonDataAccess.GetButtonNavagations(scheduledSlide.OriginalSlideID, scheduledSlide.GUID);

                    slideList.Add(scheduledSlide);

                }//end while

            conn.Close();
              }

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault("Server failed to getting slides in schedule from database." + Environment.NewLine + e.InnerException, "");
            }

            return slideList;

        }
     



        /// <summary>
        /// Add Scheduled Slide
        /// </summary>
        /// <param name="scheduledSlide"></param>
        static public void AddScheduledSlide(ScheduledSlide scheduledSlide)
        {
            try
            {
                TransactionDataAccess.ScheduleUpdate();

                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    //AddSlideSchedule to database

                    string sql = ScheduledSlideSQL.AddScheduledSlide();
                    SqlCeCommand cmdadd = new SqlCeCommand(sql, conn);
                    

                    //GUID
                    Guid guid = new Guid(scheduledSlide.GUID);
                    cmdadd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdadd.Parameters["@GUID"].Value = guid;

                    //Name
                    cmdadd.Parameters.Add("@Name", SqlDbType.NVarChar, 200);
                    cmdadd.Parameters["@Name"].Value = scheduledSlide.Name;

                    //Name
                    cmdadd.Parameters.Add("@Description", SqlDbType.NVarChar, 200);
                    cmdadd.Parameters["@Description"].Value = scheduledSlide.Description;

                    //Transition
                    cmdadd.Parameters.Add("@Transition", SqlDbType.NVarChar, 200);
                    cmdadd.Parameters["@Transition"].Value = scheduledSlide.Transition;

                    //TransitionSpeed
                    cmdadd.Parameters.Add("@TransitionSpeed", SqlDbType.Int);
                    cmdadd.Parameters["@TransitionSpeed"].Value = scheduledSlide.TransitionSpeed;

                    //Duration
                    SqlDateTime sqlDuration = new SqlDateTime(scheduledSlide.Duration);
                    cmdadd.Parameters.Add("@Duration", SqlDbType.DateTime);
                    cmdadd.Parameters["@Duration"].Value = sqlDuration;

                    //OriginalSlideID
                    Guid guid2 = new Guid(scheduledSlide.OriginalSlideID);
                    cmdadd.Parameters.Add("@OriginalSlideID", SqlDbType.UniqueIdentifier);
                    cmdadd.Parameters["@OriginalSlideID"].Value = guid2;

                    //ScheduleID
                    Guid guid3 = new Guid(scheduledSlide.ScheduleID);
                    cmdadd.Parameters.Add("@ScheduleID", SqlDbType.UniqueIdentifier);
                    cmdadd.Parameters["@ScheduleID"].Value = guid3;

                    //Version
                    //cmdadd.Parameters.Add("@Version", SqlDbType.NVarChar, 200);
                    //cmdadd.Parameters["@Version"].Value = scheduledSlide.Version;

                    //Thumbnail
                    //cmdadd.Parameters.Add("@ThumbNail", SqlDbType.Image);
                    //cmdadd.Parameters["@ThumbNail"].Value = scheduledSlide.ThumbNail;

                    //Version
                    //cmdadd.Parameters.Add("@IgnoreAllRules", SqlDbType.Bit);
                    //cmdadd.Parameters["@IgnoreAllRules"].Value = scheduledSlide.IgnoreAllRules;

                    cmdadd.ExecuteNonQuery();
                    conn.Close();

                    foreach (Button item in scheduledSlide.Buttons)
                    {
                        SlideButtonDataAccess.AddButtonNavagation(item);
                    }

                  } //using

            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding ScheduledSlide to database");
            }

        }//end function
        

        /// <summary>
        /// Update Slides
        /// </summary>
        /// <param name="scheduledSlides"></param>
        /// <param name="scheduleID"></param>
        static public void UpdateSlides(ScheduledSlides scheduledSlides, string scheduleID)
        {
            foreach (var item in GetScheduledSlides(scheduleID))
                DeleteSlide(item.GUID);

            foreach (ScheduledSlide scheduledSlide in scheduledSlides)
                AddScheduledSlide(scheduledSlide);
        
        }//end function
        
        /// <summary>
        /// Delete Slide
        /// </summary>
        /// <param name="slideID"></param>
        static public void DeleteSlide(string slideID)
        {
            try
            {
                TransactionDataAccess.ScheduleUpdate();

                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    string sql = ScheduledSlideSQL.DeleteScheduledSlide();
                    SqlCeCommand cmdDel = new SqlCeCommand(sql, conn);

                    //GUID
                    Guid guid = new Guid(slideID); 
                    cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@GUID"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    //sql = ScheduledSlideSQL.DeleteScheduledSlide();
                    //SqlCeCommand cmdDel1 = new SqlCeCommand(sql, conn);

                    //cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    //cmdDel.Parameters["@GUID"].Value = guid;

                    //cmdDel1.ExecuteNonQuery();

                    conn.Close();
                }//using

             }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error deleteing ScheduledSlide from database.");
            }

        }//end function
        

        /// <summary>
        /// Is Slide Scheduled
        /// </summary>
        /// <param name="slideID"></param>
        /// <returns></returns>
        static public int IsSlideScheduled(string slideID)
        {
            int numberOfRows = 0;

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {

                    SqlCeCommand cmd = new SqlCeCommand("SELECT count(GUID) FROM ScheduledSlide WHERE OriginalSlideID = @SlideID", conn);
                    
                    conn.Open();

                    //SlideID
                    Guid guid = new Guid(slideID);
                    cmd.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@SlideID"].Value = guid;

                    numberOfRows = (int)cmd.ExecuteScalar();

                    conn.Close();
                } //using
            }//try
        
           catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error checking is slide scheduled in database.");
            }

            return numberOfRows;
        }//function

        /// <summary>
        /// Update Original Slide Ids
        /// </summary>
        /// <param name="OriginalSlideID"></param>
        /// <param name="NewSlideID"></param>
        static public void  UpdateOriginalSlideIds(string OriginalSlideID, string NewSlideID, bool deleteExistingSlide)
        {
            try
            {
                TransactionDataAccess.ScheduleGet();

              

                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    string sql = ScheduledSlideSQL.UpdateOriginalSlideIds();

                    SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                    
                    conn.Open();

                    //OriginalSlideID
                    Guid guid = new Guid(OriginalSlideID);
                    cmd.Parameters.Add("@OriginalSlideID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@OriginalSlideID"].Value = guid;

                    //NewSlideID
                    Guid guid2 = new Guid(NewSlideID);
                    cmd.Parameters.Add("@NewSlideID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@NewSlideID"].Value = guid2;
                 
                    cmd.ExecuteNonQuery();

                    conn.Close();

                    if (deleteExistingSlide)
                    {
                        string sql2 = ScheduledSlideSQL.UpdateOriginalSlideIdsDeleteExisting();

                        SqlCeCommand cmd2 = new SqlCeCommand(sql2, conn);

                        conn.Open();

                        //OriginalSlideID
                        cmd2.Parameters.Add("@OriginalSlideID", SqlDbType.UniqueIdentifier);
                        cmd2.Parameters["@OriginalSlideID"].Value = guid;

                        //NewSlideID
                        cmd2.Parameters.Add("@NewSlideID", SqlDbType.UniqueIdentifier);
                        cmd2.Parameters["@NewSlideID"].Value = guid2;

                        cmd2.ExecuteNonQuery();

                        conn.Close();

                    }
                        

                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error updateing ScheduledSlide on database.");
            }

        }//function
    }//class
}//namespace
