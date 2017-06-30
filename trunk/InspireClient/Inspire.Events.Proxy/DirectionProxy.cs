using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace Inspire.Events.Proxy
{
    public class DirectionProxy
    {

        static private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            string connString = @"Data Source=testserver2008\sqldev2008;Initial Catalog=InspireFeedsDB;User Id=sa;Password=!nspire8;";
            conn.ConnectionString = connString;
            return conn;
        }

        static public ObservableCollection<Direction> GetDirections(string displayID)
        {
            ObservableCollection<Direction> directions = new ObservableCollection<Direction>();

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
                

                while (reader.Read())
                {
                    Direction direction = new Direction();
                        direction.Guid = reader["GUID"].ToString();
                        direction.DirectionImage = reader["DirectionImage"] as byte[];
                        direction.Description= reader["Description"] as string;
                        direction.DisplayID = reader["DisplayID"].ToString() as string;
                        direction.RoomID = reader["RoomID"].ToString() as string;
                        direction.RoomName = reader["RoomName"] as string;
                        directions.Add(direction);
                }

                conn.Close();

            }//using

            return directions;

        }//end function

       




        static public void AddDirections(ObservableCollection<Direction> directions)
        {
            if(directions != null && directions.Count > 0)
            {
                DeleteDirections(directions[0].DisplayID);
            }
            
            SqlConnection conn = GetConnection();
            conn.Open();

            foreach(Direction item in directions)
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
                cmdAdd.Parameters.Add("@ImageID", SqlDbType.Image);
                if (item.DirectionImageID != null) cmdAdd.Parameters["@ImageID"].Value = item.DirectionImageID;

               cmdAdd.ExecuteNonQuery();
                
            }
            
            conn.Close();

      
        }//end function


         static public void DeleteDirections(string displayID)
        {
            SqlConnection conn = GetConnection();
            conn.Open();

            SqlCommand cmdDel = new SqlCommand("direction_delete_from_displayID_v1", conn);
            cmdDel.CommandType = CommandType.StoredProcedure;

            //GUID
            Guid guid = new Guid(displayID);
            cmdDel.Parameters.Add("@DisplayID", SqlDbType.UniqueIdentifier);
            cmdDel.Parameters["@DisplayID"].Value = guid;

            cmdDel.ExecuteNonQuery();

            conn.Close();






        }//end function



         static public List<DirectionalImage> GetDirectionalImages()
         {
             List<DirectionalImage> images = new List<DirectionalImage>();

             using (SqlConnection conn = GetConnection())
             {
                 conn.Open();
                 SqlCommand cmd = new SqlCommand("directional_images_get_v1", conn);
                 cmd.CommandType = CommandType.StoredProcedure;
                 
                 SqlDataReader reader = cmd.ExecuteReader();
                 
                 while (reader.Read())
                 {
                     DirectionalImage image = new DirectionalImage();
                     image.Guid = reader["GUID"].ToString();
                     image.Description = reader["description"] as string;
                     image.WebPath = @"C:\inetpub\wwwroot\images\" + reader["file_name"] as string;
                     images.Add(image);
                 }

                 conn.Close();

             }//using

             return images;

         }//end function
        

        static public void AddDirectionalImage(DirectionalImage image, Byte[] file)
        {
            using (BinaryWriter binWriter = new BinaryWriter(File.Open(@"C:\inetpub\wwwroot\images\" + image.FileName, FileMode.Create)))
            {
                binWriter.Write(file);
            }
            
            SqlConnection conn = GetConnection();
            conn.Open();

            SqlCommand cmdAdd = new SqlCommand("directional_image_add_v1", conn);
            cmdAdd.CommandType = CommandType.StoredProcedure;

                //GUID
                Guid guid = new Guid(image.Guid);
                cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                cmdAdd.Parameters["@GUID"].Value = guid;
                
                //Description
                cmdAdd.Parameters.Add("@description", SqlDbType.NVarChar, 200);
                cmdAdd.Parameters["@description"].Value = image.Description;

                //ImagePath
                cmdAdd.Parameters.Add("@image_name", SqlDbType.NVarChar, 200);
                cmdAdd.Parameters["@image_name"].Value = image.WebPath;

               cmdAdd.ExecuteNonQuery();
                
        
            conn.Close();

      
        }//end function


        static public void DeleteDirectionalImage(DirectionalImage image)
        {

            File.Delete(@"C:\inetpub\wwwroot\images\" + image.FileName);
            
            SqlConnection conn = GetConnection();
            conn.Open();

            SqlCommand cmdDel = new SqlCommand("directional_image_delete_v1", conn);
            cmdDel.CommandType = CommandType.StoredProcedure;

            //GUID
            Guid guid = new Guid(image.Guid);
            cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
            cmdDel.Parameters["@GUID"].Value = guid;

            cmdDel.ExecuteNonQuery();

            conn.Close();






        }//end function



    }
}
