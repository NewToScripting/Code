using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Inspire.Server.Events.DataContracts;
using Inspire.Server.Common;


namespace Inspire.Server.Events.DataAccess
{
    /// <summary>
    /// Entry Database Access
    /// </summary>
    public class HospitalityEventDatabaseAccess
    {       
        /// <summary>
        /// Open SQL Connection
        /// </summary>
        /// <returns></returns>
        static private SqlConnection OpenSQLConnection()
        {
            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Inspire.Events"].ToString();
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error connection to Entry database. " + e.Message);
            }
           
            return conn;

        }//function

        /// <summary>
        /// Get HospitalityEvents
        /// </summary>
        /// <param name="feedID"></param>
        /// <returns></returns>
        static public HospitalityEvents GetEvents(string eventDescID)
        {
            HospitalityEvents items = new HospitalityEvents();

            try
            {
                using (SqlConnection conn = OpenSQLConnection())
                {
                    SqlCommand cmd = new SqlCommand("events_get_with_event_definition_id_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    Guid guid1 = new Guid(eventDescID);
                    cmd.Parameters.Add("@event_definition_guid", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@event_definition_guid"].Value = guid1;

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HospitalityEvent item = new HospitalityEvent();

                        item.EventDefinitionGuid = reader["event_definition_guid"].ToString() as string;
                        item.EventGuid = reader["guid"].ToString() as string;
                        item.HotelName = reader["hotel_name"] as string;
                        item.GroupName = reader["group_name"] as string;
                        item.GroupLogo = reader["group_logo"] as string;
                        item.MeetingName = reader["meeting_name"] as string;
                        item.MeetingLogo = reader["meeting_logo"] as string;
                        item.MeetingPostAs = reader["meeting_post_as"] as string;
                        item.MeetingId = reader["meeting_id"].ToString() as string;
                        item.MeetingType = reader["meeting_type"].ToString() as string;
                        item.MeetingRoomId = reader["meeting_room_id"].ToString() as string;
                        item.MeetingRoomName = reader["meeting_room_name"].ToString() as string;
                        item.MeetingRoomLogo = reader["meeting_room_logo"].ToString() as string;
                        item.HostEventIdentifier = reader["host_event_identifier"].ToString() as string;
                        item.Postable = reader["postable"] as bool?;
                        item.BackupMeetingRoomSpace = reader["backup_meeting_room_space"].ToString() as string;
                        item.OverFlowMeetingRoomSpace = reader["over_flow_meeting_room_space"].ToString();
                        item.StartDateTime = reader["start_datetime"] as DateTime?;
                        item.EndDateTime= reader["end_datetime"] as DateTime?;
                        item.IsVisible = reader["is_visible"] as bool?;
                        
                        items.Add(item);

                    }//while

                    conn.Close();

                } //using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving HospitalityEvents from database. " + e.Message);
            }

             return items;

        }//function

        /// <summary>
        /// Add Event
        /// </summary>
        /// <param name="hospitalityEvent"></param>
        static public void AddEvent(HospitalityEvent hospitalityEvent)
        {
            try
            {
                using (SqlConnection conn = OpenSQLConnection())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("event_add_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //event_definition_guid
                    Guid guid = new Guid(hospitalityEvent.EventDefinitionGuid);
                    cmdAdd.Parameters.Add("@event_definition_guid", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@event_definition_guid"].Value = guid;

                    //guid
                    Guid guid1 = new Guid(hospitalityEvent.EventGuid);
                    cmdAdd.Parameters.Add("@event_guid", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@event_guid"].Value = guid1;

                    //hotel_name
                    cmdAdd.Parameters.Add("@hotel_name", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@hotel_name"].Value = hospitalityEvent.HotelName;

                    //group_name
                    cmdAdd.Parameters.Add("@group_name", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@group_name"].Value = hospitalityEvent.GroupName;

                    //group_logo
                    cmdAdd.Parameters.Add("@group_logo", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@group_logo"].Value = hospitalityEvent.GroupLogo;

                    //meeting_name
                    cmdAdd.Parameters.Add("@meeting_name", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_name"].Value = hospitalityEvent.MeetingName;

                    //meeting_logo
                    cmdAdd.Parameters.Add("@meeting_logo", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_logo"].Value = hospitalityEvent.MeetingLogo;

                    //meeting_post_as
                    cmdAdd.Parameters.Add("@meeting_post_as", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_post_as"].Value = hospitalityEvent.MeetingPostAs;

                    //meeting_id
                    cmdAdd.Parameters.Add("@meeting_id", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_id"].Value = hospitalityEvent.MeetingId;

                    //meeting_type
                    cmdAdd.Parameters.Add("@meeting_type", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_type"].Value = hospitalityEvent.MeetingType;

                    //meeting_room_id
                    cmdAdd.Parameters.Add("@meeting_room_id", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_room_id"].Value = hospitalityEvent.MeetingRoomId;

                    //meeting_room_name
                    cmdAdd.Parameters.Add("@meeting_room_name", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_room_name"].Value = hospitalityEvent.MeetingRoomName;

                    //meeting_room_logo
                    cmdAdd.Parameters.Add("@meeting_room_logo", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_room_logo"].Value = hospitalityEvent.MeetingLogo;

                    //host_event_identifier
                    cmdAdd.Parameters.Add("@host_event_identifier", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@host_event_identifier"].Value = hospitalityEvent.HostEventIdentifier;

                    //postable
                    cmdAdd.Parameters.Add("@postable", SqlDbType.Bit);
                    cmdAdd.Parameters["@postable"].Value = hospitalityEvent.Postable;

                    //backup_meeting_room_space
                    cmdAdd.Parameters.Add("@backup_meeting_room_space", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@backup_meeting_room_space"].Value = hospitalityEvent.BackupMeetingRoomSpace;

                    //over_flow_meeting_room_space
                    cmdAdd.Parameters.Add("@over_flow_meeting_room_space", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@over_flow_meeting_room_space"].Value = hospitalityEvent.OverFlowMeetingRoomSpace;

                    //start_date
                    cmdAdd.Parameters.Add("@start_datetime", SqlDbType.DateTime);
                    cmdAdd.Parameters["@start_datetime"].Value = hospitalityEvent.StartDateTime;
                 
                    //end_date
                    cmdAdd.Parameters.Add("@end_datetime", SqlDbType.DateTime);
                    cmdAdd.Parameters["@end_datetime"].Value = hospitalityEvent.EndDateTime;

                    //is_visible
                    cmdAdd.Parameters.Add("@is_visible", SqlDbType.Bit);
                    cmdAdd.Parameters["@is_visible"].Value = hospitalityEvent.IsVisible;

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();

                }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding Entry to database. " + e.Message );
            }

            
        }//end function

        /// <summary>
        /// Update Event
        /// </summary>
        /// <param name="hospitalityEvent"></param>
        static public void UpdateEvent(HospitalityEvent hospitalityEvent)
        {
            try
            {
                using (SqlConnection conn = OpenSQLConnection())
                {
                    conn.Open();

                    SqlCommand cmdAdd = new SqlCommand("event_update_v1", conn);
                    cmdAdd.CommandType = CommandType.StoredProcedure;

                    //event_definition_guid
                    Guid guid = new Guid(hospitalityEvent.EventDefinitionGuid);
                    cmdAdd.Parameters.Add("@event_definition_guid", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@event_definition_guid"].Value = guid;

                    //guid
                    Guid guid1 = new Guid(hospitalityEvent.EventGuid);
                    cmdAdd.Parameters.Add("@event_guid", SqlDbType.UniqueIdentifier);
                    cmdAdd.Parameters["@event_guid"].Value = guid1;

                    //hotel_name
                    cmdAdd.Parameters.Add("@hotel_name", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@hotel_name"].Value = hospitalityEvent.HotelName;

                    //group_name
                    cmdAdd.Parameters.Add("@group_name", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@group_name"].Value = hospitalityEvent.GroupName;

                    //group_logo
                    cmdAdd.Parameters.Add("@group_logo", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@group_logo"].Value = hospitalityEvent.GroupLogo;

                    //meeting_name
                    cmdAdd.Parameters.Add("@meeting_name", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_name"].Value = hospitalityEvent.MeetingName;

                    //meeting_logo
                    cmdAdd.Parameters.Add("@meeting_logo", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_logo"].Value = hospitalityEvent.MeetingLogo;

                    //meeting_post_as
                    cmdAdd.Parameters.Add("@meeting_post_as", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_post_as"].Value = hospitalityEvent.MeetingPostAs;

                    //meeting_id
                    cmdAdd.Parameters.Add("@meeting_id", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_id"].Value = hospitalityEvent.MeetingId;

                    //meeting_type
                    cmdAdd.Parameters.Add("@meeting_type", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_type"].Value = hospitalityEvent.MeetingType;

                    //meeting_room_id
                    cmdAdd.Parameters.Add("@meeting_room_id", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_room_id"].Value = hospitalityEvent.MeetingRoomId;

                    //meeting_room_name
                    cmdAdd.Parameters.Add("@meeting_room_name", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_room_name"].Value = hospitalityEvent.MeetingRoomName;

                    //meeting_room_logo
                    cmdAdd.Parameters.Add("@meeting_room_logo", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@meeting_room_logo"].Value = hospitalityEvent.MeetingLogo;

                    //host_event_identifier
                    cmdAdd.Parameters.Add("@host_event_identifier", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@host_event_identifier"].Value = hospitalityEvent.HostEventIdentifier;

                    //postable
                    cmdAdd.Parameters.Add("@postable", SqlDbType.Bit);
                    cmdAdd.Parameters["@postable"].Value = hospitalityEvent.Postable;

                    //backup_meeting_room_space
                    cmdAdd.Parameters.Add("@backup_meeting_room_space", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@backup_meeting_room_space"].Value = hospitalityEvent.BackupMeetingRoomSpace;

                    //over_flow_meeting_room_space
                    cmdAdd.Parameters.Add("@over_flow_meeting_room_space", SqlDbType.NVarChar, 200);
                    cmdAdd.Parameters["@over_flow_meeting_room_space"].Value = hospitalityEvent.OverFlowMeetingRoomSpace;
                           
                    //start_date
                    cmdAdd.Parameters.Add("@start_datetime", SqlDbType.DateTime);
                    cmdAdd.Parameters["@start_datetime"].Value = hospitalityEvent.StartDateTime;

                    //end_date
                    cmdAdd.Parameters.Add("@end_datetime", SqlDbType.DateTime);
                    cmdAdd.Parameters["@end_datetime"].Value = hospitalityEvent.EndDateTime;

                    //is_visible
                    cmdAdd.Parameters.Add("@is_visible", SqlDbType.Bit);
                    cmdAdd.Parameters["@is_visible"].Value = hospitalityEvent.IsVisible;

                    cmdAdd.ExecuteNonQuery();

                    conn.Close();

                }//using
            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error updateing Entry to database. " + e.Message);
            }


        }//end function



        /// <summary>
        /// Delete Hospitality Event
        /// </summary>
        /// <param name="feedEntryID"></param>
        static public void DeleteHospitalityEvent(string hospitalityEventID)
        {
            try
            {
                using (SqlConnection conn = OpenSQLConnection())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("event_delete_v1", conn);
                    cmdDel.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(hospitalityEventID);
                    cmdDel.Parameters.Add("@event_guid", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@event_guid"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();

                }//using
            }

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing Entry from database. " + e.Message);
            }

           
        }//end function


        /// <summary>
        /// Truncate Hospitality Event
        /// </summary>
        /// <param name="feedEntryID"></param>
        static public void TruncateHospitalityEvents(string eventDefID)
        {
            try
            {
                using (SqlConnection conn = OpenSQLConnection())
                {
                    conn.Open();

                    SqlCommand cmdDel = new SqlCommand("events_delete_v1", conn);
                    cmdDel.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(eventDefID);
                    cmdDel.Parameters.Add("@event_definition_guid", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@event_definition_guid"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();

                }//using
            }

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing Entry from database. " + e.Message);
            }


        }//end function        


      /// <summary>
      /// Get Events Filtered hostname
      /// </summary>
      /// <param name="eventDesc"></param>
      /// <param name="hostName"></param>
      /// <returns></returns>
        static public HospitalityEvents GetEventsFiltered(string eventDescGuid, string hostName)
        {
            HospitalityEvents items = new HospitalityEvents();
            
            try
            {
                using (SqlConnection conn = OpenSQLConnection())
                {
                    SqlCommand cmd = new SqlCommand("populate_events_filtered_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    
                    cmd.Parameters.Add("@host_name", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@host_name"].Value = hostName;

                    Guid guid2 = new Guid(eventDescGuid);
                    cmd.Parameters.Add("@event_description_guid", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@event_description_guid"].Value = guid2;
             
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HospitalityEvent item = new HospitalityEvent();

                        item.EventDefinitionGuid = reader["event_definition_guid"].ToString() as string;
                        item.EventGuid = reader["guid"].ToString() as string;
                        item.HotelName = reader["hotel_name"] as string;
                        item.GroupName = reader["group_name"] as string;
                        item.GroupLogo = reader["group_logo"] as string;
                        item.MeetingName = reader["meeting_name"] as string;
                        item.MeetingLogo = reader["meeting_logo"] as string;
                        item.MeetingPostAs = reader["meeting_post_as"] as string;
                        item.MeetingId = reader["meeting_id"].ToString() as string;
                        item.MeetingType = reader["meeting_type"].ToString() as string;
                        item.MeetingRoomId = reader["meeting_room_id"].ToString() as string;
                        item.MeetingRoomName = reader["meeting_room_name"].ToString() as string;
                        item.MeetingRoomLogo = reader["meeting_room_logo"].ToString() as string;
                        item.HostEventIdentifier = reader["host_event_identifier"].ToString() as string;
                        item.Postable = reader["postable"] as bool?;
                        item.BackupMeetingRoomSpace = reader["backup_meeting_room_space"].ToString() as string;
                        item.OverFlowMeetingRoomSpace = reader["over_flow_meeting_room_space"].ToString();

                        string startDate = reader["start_datetime"].ToString();
                            if (!string.IsNullOrEmpty(startDate))
                                item.StartDateTime = DateTime.Parse(startDate);

                        string endDate = reader["end_datetime"].ToString();
                            if (!string.IsNullOrEmpty(startDate))
                                item.EndDateTime = DateTime.Parse(endDate);   

                        item.IsVisible = reader["is_visible"] as bool?;

                        if (string.IsNullOrEmpty(hostName))     
                            item.DirectionalImage = ConfigurationManager.AppSettings["ImageWebFolder"] + "default.jpg";
                        else
                            item.DirectionalImage = ConfigurationManager.AppSettings["ImageWebFolder"] + reader["image_file_name"].ToString() + reader["image_file_extension"].ToString() as string;

                        if (string.IsNullOrEmpty(hostName))
                            item.GroupLogo = ConfigurationManager.AppSettings["ImageWebFolder"] + "default.jpg";
                        else
                        {
                            string filename2 = reader["group_image_file_name"].ToString() as string;
                            string fileext2 = reader["group_image_file_extension"].ToString() as string;
                            item.GroupLogo = ConfigurationManager.AppSettings["ImageWebFolder"] + filename2 + fileext2;
                        }

                          item.Alias = reader["alias"] as string;
                     
                        items.Add(item);

                    }//while

                    conn.Close();

                } //using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving filtered HospitalityEvents  from database. " + e.Message);
            }

            return items;

        }//function


        /// <summary>
        /// Get NonEvents Filtered hostname
        /// </summary>
        /// <param name="eventDesc"></param>
        /// <param name="hostName"></param>
        /// <returns></returns>
        static public HospitalityEvents GetEventsNonFiltered(string eventDesc, string hostName)
        {
            HospitalityEvents items = new HospitalityEvents();
                         
            try
            {
                using (SqlConnection conn = OpenSQLConnection())
                {
                    SqlCommand cmd = new SqlCommand("populate_events_nonfiltered_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@host_name", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@host_name"].Value = hostName;

                    Guid guid2 = new Guid(eventDesc);
                    cmd.Parameters.Add("@event_description_guid", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@event_description_guid"].Value = guid2;

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HospitalityEvent item = new HospitalityEvent();

                        item.EventDefinitionGuid = reader["event_definition_guid"].ToString() as string;
                        item.EventGuid = reader["guid"].ToString() as string;
                        item.HotelName = reader["hotel_name"] as string;
                        item.GroupName = reader["group_name"] as string;
                        item.GroupLogo = reader["group_logo"] as string;
                        item.MeetingName = reader["meeting_name"] as string;
                        item.MeetingLogo = reader["meeting_logo"] as string;
                        item.MeetingPostAs = reader["meeting_post_as"] as string;
                        item.MeetingId = reader["meeting_id"].ToString() as string;
                        item.MeetingType = reader["meeting_type"].ToString() as string;
                        item.MeetingRoomId = reader["meeting_room_id"].ToString() as string;
                        item.MeetingRoomName = reader["meeting_room_name"].ToString() as string;
                        item.MeetingRoomLogo = reader["meeting_room_logo"].ToString() as string;
                        item.HostEventIdentifier = reader["host_event_identifier"].ToString() as string;
                        item.Postable = reader["postable"] as bool?;
                        item.BackupMeetingRoomSpace = reader["backup_meeting_room_space"].ToString() as string;
                        item.OverFlowMeetingRoomSpace = reader["over_flow_meeting_room_space"].ToString();

                        string startDate = reader["start_datetime"].ToString();
                            if (!string.IsNullOrEmpty(startDate))
                                item.StartDateTime = DateTime.Parse(startDate);

                        string endDate = reader["end_datetime"].ToString();
                            if (!string.IsNullOrEmpty(startDate))
                                item.EndDateTime = DateTime.Parse(endDate);                

                        item.IsVisible = reader["is_visible"] as bool?;

                        if (string.IsNullOrEmpty(hostName))
                            item.DirectionalImage = ConfigurationManager.AppSettings["ImageWebFolder"] + "default.jpg";
                        else
                        {
                            string filename = reader["image_file_name"].ToString() as string;
                            string fileext = reader["image_file_extension"].ToString() as string;
                            item.DirectionalImage = ConfigurationManager.AppSettings["ImageWebFolder"] + filename + fileext;
                        }

                        if (string.IsNullOrEmpty(hostName))
                            item.GroupLogo = ConfigurationManager.AppSettings["ImageWebFolder"] + "default.jpg";
                        else
                        {
                            string filename2 = reader["group_image_file_name"].ToString() as string;
                            string fileext2 = reader["group_image_file_extension"].ToString() as string;
                            item.GroupLogo = ConfigurationManager.AppSettings["ImageWebFolder"] + filename2 + fileext2;
                        }

                        item.Alias = reader["alias"] as string;

                        items.Add(item);

                    }//while

                    conn.Close();

                } //using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving HospitalityEvents from database. " + e.Message);
            }

            return items;

        }//function




     }//class
}//namespace
