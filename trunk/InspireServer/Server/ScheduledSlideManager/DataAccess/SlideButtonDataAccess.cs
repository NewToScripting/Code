using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using Inspire.Server.ScheduledSlideManager.DataContracts;
using Inspire.Server.Common;
using Inspire.Server.Common.DataContracts;

namespace Inspire.Server.ScheduledSlideManager.DataAccess
{
    public class SlideButtonDataAccess
    {
        /// <summary>
        /// Get SlideNavagations
        /// </summary>
        /// <returns></returns>
        static public Buttons GetButtonNavagations(string SlideID, string ScheduledSlideID)
        {
            Buttons items = new Buttons();
            try
            {
                    Guid guid = new Guid(SlideID);
                    Guid guid2 = new Guid(ScheduledSlideID);
                    string sql = String.Empty;


                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    //Check for buttons
                    sql = ScheduledSlideSQL.GetButtonNavagationsFromScheduleID();
                                      
                    SqlCeCommand cmd = new SqlCeCommand(sql, conn);    
                  
                    cmd.Parameters.Add("@ScheduledSlideID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@ScheduledSlideID"].Value = guid2;

                    SqlCeDataReader reader = cmd.ExecuteReader();

                    if (reader != null && reader.Read())
                    {
                        //No slide id
                        sql = ScheduledSlideSQL.GetButtonNavagationsFromScheduleIDIsNull();
                        SqlCeCommand cmd2 = new SqlCeCommand(sql, conn);

                        cmd2.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
                        cmd2.Parameters["@SlideID"].Value = guid;

                        cmd2.Parameters.Add("@ScheduledSlideID", SqlDbType.UniqueIdentifier);
                        cmd2.Parameters["@ScheduledSlideID"].Value = guid2;

                        SqlCeDataReader reader2 = cmd2.ExecuteReader();

                        if (reader2 != null)
                            while (reader2.Read())
                            {
                                Button item = new Button();

                                item.GUID = reader2["GUID"].ToString() as string;
                                item.ButtonName = reader2["ButtonName"].ToString() as string;
                                item.SlideGuidToNavigateTo = reader2["SlideGuidToNavigateTo"].ToString() as string;
                                item.ScheduledSlidSlideID = reader2["scheduledSlideID"].ToString() as string;
                                item.SlideID = reader2["SlideID"].ToString() as string;
                                items.Add(item);
                            }


                        //Has slide ID
                        sql = ScheduledSlideSQL.GetButtonNavagationsFromScheduleIDNotNull();
                        SqlCeCommand cmd3 = new SqlCeCommand(sql, conn);

                        cmd3.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
                        cmd3.Parameters["@SlideID"].Value = guid;

                        cmd3.Parameters.Add("@ScheduledSlideID", SqlDbType.UniqueIdentifier);
                        cmd3.Parameters["@ScheduledSlideID"].Value = guid2;

                        SqlCeDataReader reader3 = cmd3.ExecuteReader();

                        if (reader3 != null)
                            while (reader3.Read())
                            {
                                Button item = new Button();

                                item.GUID = reader3["GUID"].ToString() as string;
                                item.ButtonName = reader3["ButtonName"].ToString() as string;
                                item.SlideGuidToNavigateTo = reader3["SlideGuidToNavigateTo"].ToString() as string;
                                item.ScheduledSlidSlideID = reader3["scheduledSlideID"].ToString() as string;
                                item.SlideID = reader3["SlideID"].ToString() as string;
                                items.Add(item);
                            }
                    }
                    else
                    {
                        sql = ScheduledSlideSQL.GetButtonNavagationsFromSlideID();

                        SqlCeCommand cmd1 = new SqlCeCommand(sql, conn);     
                        
                        cmd1.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
                        cmd1.Parameters["@SlideID"].Value = guid;
            
                        SqlCeDataReader reader1 = cmd1.ExecuteReader();

                        if (reader1 != null)
                            while (reader1.Read())
                            {
                                Button item = new Button();

                                item.GUID = reader1["GUID"].ToString() as string;
                                item.ButtonName = reader1["ButtonName"].ToString() as string;
                                item.SlideGuidToNavigateTo = null;
                                item.ScheduledSlidSlideID = null;
                                item.SlideID = reader1["SlideID"].ToString() as string;
                                items.Add(item);
                           }

                        }

                    //old way

                    //string sql = ScheduledSlideSQL.GetButtonNavagationsFromScheduleID();
                    //SqlCeCommand cmd = new SqlCeCommand(sql, conn);     

                    ////GUID
                    //Guid guid = new Guid(SlideID);
                    //cmd.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
                    //cmd.Parameters["@SlideID"].Value = guid;

                    ////GUID
                    //Guid guid2 = new Guid(ScheduledSlideID);
                    //cmd.Parameters.Add("@ScheduledSlideID", SqlDbType.UniqueIdentifier);
                    //cmd.Parameters["@ScheduledSlideID"].Value = guid2;

                    //SqlCeDataReader reader = cmd.ExecuteReader();

                    //if (reader != null)
                    //    while (reader.Read())
                    //    {
                    //        Button item = new Button();

                    //        item.GUID = reader["GUID"].ToString() as string;
                    //        item.ButtonName = reader["ButtonName"].ToString() as string;
                    //        item.SlideGuidToNavigateTo = reader["SlideGuidToNavigateTo"].ToString() as string;
                    //        item.ScheduledSlidSlideID = reader["scheduledSlideID"].ToString() as string;
                    //        item.SlideID = reader["SlideID"].ToString() as string;
                    //        items.Add(item);
                    //    }

                    conn.Close();

                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving SlideButtons from database.");
            }

            return items;

        }//end function

        /// <summary>
        /// Add Slide
        /// </summary>
        /// <param name="slide"></param>
        static public void AddButtonNavagation(Button item)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
            {
                conn.Open();

                SqlCeCommand cmdAdd = new SqlCeCommand("INSERT INTO ButtonNavagation([GUID],[SlideGuidToNavigateTo],[ButtonID],[ScheduledSlideID]) VALUES (@GUID, @SlideGuidToNavigateTo,@ButtonID,@ScheduledSlideID)", conn);
                

                //GUID
                Guid guid = new Guid(item.GUID);
                cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                cmdAdd.Parameters["@GUID"].Value = guid;

                //Name
                //cmdAdd.Parameters.Add("@ButtonName", SqlDbType.NVarChar, 100);
                //cmdAdd.Parameters["@ButtonName"].Value = item.ButtonName;

                //ButtonID
                Guid guid3 = new Guid(item.GUID);
                cmdAdd.Parameters.Add("@ButtonID", SqlDbType.UniqueIdentifier);
                cmdAdd.Parameters["@ButtonID"].Value = guid3;

                //SlideGuidToNavigateTo
                if (!string.IsNullOrEmpty(item.SlideGuidToNavigateTo))
                {
                    Guid guid4 = new Guid(item.SlideGuidToNavigateTo);
                    cmdAdd.Parameters.Add("@SlideGuidToNavigateTo", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@SlideGuidToNavigateTo"].Value = guid4;
                }
                
                //SlideID
                if (!string.IsNullOrEmpty(item.ScheduledSlidSlideID))
                {
                    Guid guid2 = new Guid(item.ScheduledSlidSlideID);
                    cmdAdd.Parameters.Add("@ScheduledSlideID", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@ScheduledSlideID"].Value = guid2;
                }
                
                cmdAdd.ExecuteNonQuery();

                conn.Close();

            }//using
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding SlideNavagation from database.");
            }


        }//end function

        /// <summary>
        /// Delete Slide
        /// </summary>
        /// <param name="slideID"></param>
        static public void DeleteButtonNavagation(string TouchScreenButtonID)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmdDel = new SqlCeCommand("DELETE FROM buttonnavagation Where [GUID] = @GUID", conn);
                    

                    //GUID
                    Guid guid = new Guid(TouchScreenButtonID);
                    cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@GUID"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();
                }//using

            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing SlideButtons from database.");
            }

        }//end function



        /// <summary>
        /// Delete Slide
        /// </summary>
        /// <param name="slideID"></param>
        static public void DeleteButtonNavagations(string SlideID)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmdDel = new SqlCeCommand("DELETE FROM buttonnavagation Where [ScheduledSlideID] = @ScheduledSlideID", conn);
                    

                    //GUID
                    Guid guid = new Guid(SlideID);
                    cmdDel.Parameters.Add("@ScheduledSlideID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@ScheduledSlideID"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();
                }//using

            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing SlideButtons from database.");
            }

        }//end function


    }
}
