using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Inspire.Server.Direction.DataContracts;
using Inspire.Server.Common;
using System.Configuration;

namespace Inspire.Server.Direction.DataAccess
{
    /// <summary>
    /// Direction Database Access
    /// </summary>
    public class DirectionDataAccess
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
        /// Get Directions
        /// </summary>
        /// <param name="displayID"></param>
        /// <returns></returns>
        static public Directions GetDirections(string displayID)
        {
            Directions directions = new Directions();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("direction_get_from_displayid_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //DisplayID
                    Guid guid2 = new Guid(displayID);
                    cmd.Parameters.Add("@DisplayID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@DisplayID"].Value = guid2;
                    
                    SqlDataReader reader = cmd.ExecuteReader();


                    if (reader != null)
                        while (reader.Read())
                        {
                            var direction = new DataContracts.Direction();
                            direction.GUID = reader["GUID"].ToString() as string;

                            string fileName = reader["file_name"].ToString();
                            if (!string.IsNullOrEmpty(fileName)) direction.DirectionImageWebPath = ConfigurationManager.AppSettings["ImageWebFolder"].ToString() + reader["file_name"].ToString() + reader["file_extension"] as string; 
                            else direction.DirectionImageWebPath = null;
                            direction.DirectionImageID = reader["RoomName"] as string;
                            direction.Description= reader["Description"] as string;
                            direction.DisplayID = reader["DisplayID"].ToString() as string;
                            direction.RoomID = reader["RoomID"].ToString() as string;
                            direction.RoomName = reader["RoomName"] as string;
                            direction.DirectionImageID = reader["ImageID"].ToString() as string;
                            directions.Add(direction);
                        }

                    conn.Close();

                }//using
            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving Directions from database.");
            }

            return directions;

        }//end function
        
        /// <summary>
        /// Add Directions
        /// </summary>
        /// <param name="directions"></param>
        static public void AddDirections(Directions directions)
        {
            if(directions != null && directions.Count > 0)
            {
                DeleteDirections(directions[0].DisplayID);
            }

            try
            {
                using(SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    if (directions != null)
                        foreach (Direction.DataContracts.Direction item in directions)
                        {

                            SqlCommand cmdAdd = new SqlCommand("directions_add_v1", conn);
                            cmdAdd.CommandType = CommandType.StoredProcedure;

                            //GUID
                            Guid guid = Guid.NewGuid();
                            cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                            cmdAdd.Parameters["@GUID"].Value = guid;

                            //RoomID
                            if (item.RoomID != null)
                            {
                                Guid guid1 = new Guid(item.RoomID);
                                cmdAdd.Parameters.Add("@RoomID", SqlDbType.UniqueIdentifier);
                                cmdAdd.Parameters["@RoomID"].Value = guid1;
                            }

                            //DisplayID
                            if (item.DisplayID != null)
                            {
                                Guid guid2 = new Guid(item.DisplayID);
                                cmdAdd.Parameters.Add("@DisplayID", SqlDbType.UniqueIdentifier);
                                cmdAdd.Parameters["@DisplayID"].Value = guid2;
                            }

                            //Description
                            cmdAdd.Parameters.Add("@Description", SqlDbType.NVarChar, 200);
                            if (item.Description != null) cmdAdd.Parameters["@Description"].Value = item.Description;

                            //ImageID
                            //cmdAdd.Parameters.Add("@ImageID", SqlDbType.UniqueIdentifier);
                            //if (item.DirectionImageID != null) cmdAdd.Parameters["@ImageID"].Value = item.DirectionImageID;

                            //ImageID
                            if (!string.IsNullOrEmpty(item.DirectionImageID))
                            {
                                Guid guid3 = new Guid(item.DirectionImageID);
                                cmdAdd.Parameters.Add("@ImageID", SqlDbType.UniqueIdentifier);
                                cmdAdd.Parameters["@ImageID"].Value = guid3;
                            }

                            cmdAdd.ExecuteNonQuery();

                        }


                    conn.Close();
                }//using

            }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding Direction to database.");
            }

        }//end function


        /// <summary>
        /// Delete Directions
        /// </summary>
        /// <param name="displayID"></param>
         static public void DeleteDirections(string displayID)
        {
            try
            {
                using(SqlConnection conn = GetConnection())
                {
                     conn.Open();

                    SqlCommand cmdDel = new SqlCommand("direction_delete_from_displayID_v1", conn);
                    cmdDel.CommandType = CommandType.StoredProcedure;

                    //GUID
                    Guid guid = new Guid(displayID);
                    cmdDel.Parameters.Add("@DisplayID", SqlDbType.UniqueIdentifier);
                    cmdDel.Parameters["@DisplayID"].Value = guid;

                    cmdDel.ExecuteNonQuery();

                    conn.Close();

                }//using
              }//try

            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error delete Direction from database.");
            }
             
        }//end function       
      
    }//class
}//namespace
