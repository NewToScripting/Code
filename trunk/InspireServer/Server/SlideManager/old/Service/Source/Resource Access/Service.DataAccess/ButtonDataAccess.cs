//using System;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using Inspire.Server.SlideManager.DataContracts;

//namespace Inspire.Server.SlideManager.DataAccess
//{
//    public class ButtonDataAccess
//    {
//        /// <summary>
//        /// Get SQL Connection
//        /// </summary>
//        /// <returns></returns>
//        static private SqlConnection GetConnected()
//        {
//            SqlConnection conn = new SqlConnection();
                
//                try
//                {
//                     string connString = ConfigurationManager.ConnectionStrings["Inspire.Data"].ConnectionString;
//                     conn.ConnectionString = connString;
//                }
//                catch (Exception e)
//                {
//                    EventLogger.LogAndThrowFault(e.Message, "Error connection to Touchscreen database.");
//                }
            
//            return conn;
//        }

//        /// <summary>
//        /// Get TOuchscreen Buttons
//        /// </summary>
//        /// <returns></returns>
//        static public TouchScreenButtons GetButtons(string SlideID)
//        {
//            TouchScreenButtons buttons = new TouchScreenButtons();

//            try
//            {
//                using (SqlConnection conn = GetConnected())
//                {
//                    conn.Open();
//                    SqlCommand cmd = new SqlCommand("touchscreenbuttons_get_v1", conn);
//                    cmd.CommandType = CommandType.StoredProcedure;

//                    //GUID
//                    Guid guid = new Guid(SlideID);
//                    cmd.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
//                    cmd.Parameters["@SlideID"].Value = guid;

//                    SqlDataReader reader = cmd.ExecuteReader();

//                    if (reader != null)
//                        while (reader.Read())
//                        {
//                             TouchScreenButton button = new TouchScreenButton();

//                            button.GUID = reader["GUID"].ToString() as string;
//                            button.ControlGuidFrom = reader["ControlGuidFrom"].ToString() as string;
//                            button.ButtonName = reader["ButtonName"] as string;
//                            button.SlideGuidToNavigateTo = reader["SlideGuidToNavigateTo"].ToString() as string;
//                            button.SlideID = reader["SlideID"].ToString() as string;
//                            buttons.Add(button);
//                        }

//                    conn.Close();

//                }//using
//            }//try

//            catch (Exception e)
//            {
//                EventLogger.LogAndThrowFault(e.Message, "Error retrieving TouchScreenButtons from database.");
//            }

//            return buttons;

//        }//end function

//        /// <summary>
//        /// Add Slide
//        /// </summary>
//        /// <param name="slide"></param>
//        static public void AddButton(TouchScreenButton button)
//        {
//            //try
//            //{
//                using (SqlConnection conn = GetConnected())
//                {
//                    conn.Open();

//                    SqlCommand cmdAdd = new SqlCommand("touchscreenbutton_add_v1", conn);
//                    cmdAdd.CommandType = CommandType.StoredProcedure;

//                    //GUID
//                    Guid guid = new Guid(button.GUID);
//                    cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
//                    cmdAdd.Parameters["@GUID"].Value = guid;

//                    //Name
//                    cmdAdd.Parameters.Add("@ButtonName", SqlDbType.NVarChar, 200);
//                    cmdAdd.Parameters["@ButtonName"].Value = button.ButtonName;

//                    //ControlGuidFrom
//                    Guid guid3 = new Guid(button.ControlGuidFrom);
//                    cmdAdd.Parameters.Add("@ControlGuidFrom", SqlDbType.UniqueIdentifier);
//                    cmdAdd.Parameters["@ControlGuidFrom"].Value = guid3;

//                    //SlideGuidToNavigateTo
//                    if (!string.IsNullOrEmpty(button.SlideGuidToNavigateTo))
//                    {
//                        Guid guid4 = new Guid(button.SlideGuidToNavigateTo);
//                        cmdAdd.Parameters.Add("@SlideGuidToNavigateTo", SqlDbType.UniqueIdentifier);
//                        cmdAdd.Parameters["@SlideGuidToNavigateTo"].Value = guid4;
//                    }
                   

//                    //SlideID
//                    Guid guid2 = new Guid(button.SlideID);
//                    cmdAdd.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
//                    cmdAdd.Parameters["@SlideID"].Value = guid2;

//                    cmdAdd.ExecuteNonQuery();

//                    conn.Close();

//                }//using
//            //}//try
//            //catch (Exception e)
//            //{
//            //    EventLogger.LogAndThrowFault(e.Message, "Error adding TouchScreenButton from database.");
//            //}
            

//        }//end function
        
//        /// <summary>
//        /// Delete Slide
//        /// </summary>
//        /// <param name="slideID"></param>
//        static public void DeleteButton(string TouchScreenButtonID)
//        {
//            try
//            {
//                using(SqlConnection conn = GetConnected())
//                {
//                    conn.Open();

//                    SqlCommand cmdDel = new SqlCommand("touchscreenbutton_delete_v1", conn);
//                    cmdDel.CommandType = CommandType.StoredProcedure;

//                    //GUID
//                    Guid guid = new Guid(TouchScreenButtonID);
//                    cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
//                    cmdDel.Parameters["@GUID"].Value = guid;

//                    cmdDel.ExecuteNonQuery();

//                    conn.Close();
//                }//using
            
//            }//try
//            catch (Exception e)
//            {
//                EventLogger.LogAndThrowFault(e.Message, "Error removing TouchScreenButton from database.");
//            }
            
//          }//end function



//        /// <summary>
//        /// Delete Slide
//        /// </summary>
//        /// <param name="slideID"></param>
//        static public void DeleteButtons(string SlideID)
//        {
//            try
//            {
//                using (SqlConnection conn = GetConnected())
//                {
//                    conn.Open();

//                    SqlCommand cmdDel = new SqlCommand("touchscreenbuttons_delete_v1", conn);
//                    cmdDel.CommandType = CommandType.StoredProcedure;

//                    //GUID
//                    Guid guid = new Guid(SlideID);
//                    cmdDel.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
//                    cmdDel.Parameters["@SlideID"].Value = guid;

//                    cmdDel.ExecuteNonQuery();

//                    conn.Close();
//                }//using

//            }//try
//            catch (Exception e)
//            {
//                EventLogger.LogAndThrowFault(e.Message, "Error removing TouchScreenButtons from database.");
//            }

//        }//end function


//    }
//}
