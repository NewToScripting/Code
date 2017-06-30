using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using Inspire.Server.SlideManager.DataContracts;
using Inspire.Server.Common;
using Inspire.Server.Common.DataContracts;

namespace Inspire.Server.SlideManager.DataAccess
{
    public class ButtonDataAccess
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
        //        EventLogger.LogAndThrowFault(e.Message, "Error connection to Button database.");
        //    }

        //    return conn;
        //}

        /// <summary>
        /// Get TOuchscreen Buttons
        /// </summary>
        /// <returns></returns>
        static public Buttons GetButtons(string SlideID)
        {
            Buttons buttons = new Buttons();

            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();
                    SqlCeCommand cmd = new SqlCeCommand(@"SELECT [GUID], [ButtonName], [SlideID] FROM Button WHERE SlideID = @SlideID", conn);
                   
                    //GUID
                    Guid guid = new Guid(SlideID);
                    cmd.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@SlideID"].Value = guid;

                    SqlCeDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                        while (reader.Read())
                        {
                            Button button = new Button();

                            button.GUID = reader["GUID"].ToString() as string;
                            button.ButtonName = reader["ButtonName"] as string;
                            button.SlideID = reader["SlideID"].ToString() as string;
                            buttons.Add(button);
                        }

                    conn.Close();

                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving TouchScreenButtons from database.");
            }

            return buttons;

        }//end function

        /// <summary>
        /// Add Slide
        /// </summary>
        /// <param name="slide"></param>
        static public void AddButton(Button button)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
            {
                DeleteButton(button.GUID);

                conn.Open();

                SqlCeCommand cmdAdd = new SqlCeCommand("INSERT INTO Button ([GUID],[ButtonName],[SlideID]) VALUES (@GUID, @ButtonName,@SlideID)", conn);
               
                //GUID
                Guid guid = new Guid(button.GUID);
                cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                cmdAdd.Parameters["@GUID"].Value = guid;

                //Name
                cmdAdd.Parameters.Add("@ButtonName", SqlDbType.NVarChar, 200);
                cmdAdd.Parameters["@ButtonName"].Value = button.ButtonName;

                //SlideID
                Guid guid2 = new Guid(button.SlideID);
                cmdAdd.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
                cmdAdd.Parameters["@SlideID"].Value = guid2;

                cmdAdd.ExecuteNonQuery();

                conn.Close();

            }//using
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding TouchScreenButton from database.");
            }


        }//end function

        /// <summary>
        /// Delete Slide
        /// </summary>
        /// <param name="slideID"></param>
        static public void DeleteButton(string TouchScreenButtonID)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmdDel = new SqlCeCommand("DELETE FROM button Where [GUID] = @GUID", conn);                   

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
                EventLogger.LogAndThrowFault(e.Message, "Error removing Button from database.");
            }

        }//end function



        /// <summary>
        /// Delete Slide
        /// </summary>
        /// <param name="slideID"></param>
        static public void DeleteButtons(string SlideID)
        {
            try
            {
                using (SqlCeConnection conn = CommonDataConnection.GetConnection())
                {
                    conn.Open();

                    SqlCeCommand cmdDel = new SqlCeCommand("DELETE FROM ButtonNavagation Where SlideGuidToNavigateTo IN (select [GUID] from ScheduledSlide where OriginalSlideID = @SlideID)", conn);
                   
                    //GUID
                    Guid guid = new Guid(SlideID);
                    cmdDel.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@SlideID"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                     SqlCeCommand cmdDel2 = new SqlCeCommand("DELETE FROM button Where SlideID = @SlideID", conn);
                   
                    //GUID
                    cmdDel2.Parameters.Add("@SlideID", SqlDbType.UniqueIdentifier);
                    cmdDel2.Parameters["@SlideID"].Value = guid;

                    cmdDel2.ExecuteNonQuery();

                    conn.Close();

                }//using

            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing Buttons from database.");
            }

        }//end function


    }
}
