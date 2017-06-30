using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Inspire.SlideManager.DataContracts;

namespace Inspire.SlideManager.DataAccess
{
    public class SlideDataAccess
    {

        static private SqlConnection GetConnected()
        {
            SqlConnection conn = new SqlConnection();
            string connString = ConfigurationManager.ConnectionStrings["Inspire.Data"].ConnectionString;
            conn.ConnectionString = connString;
            return conn;
        }

        static public Slides GetAllSlides()
        {
            SqlConnection conn = GetConnected();
             conn.Open();
            
            Slides slides = new Slides();

            SqlCommand cmd = new SqlCommand("slides_get_v1", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Slide slide = new Slide();

                slide.GUID = reader["GUID"].ToString() as string;
                slide.Name = reader["Name"] as string;

                if (reader["VResolution"] != null)
                     slide.VResolution = Convert.ToDouble(reader["VResolution"].ToString() as string);
                  
                if (reader["HResolution"] != null)
                    slide.HResolution = Convert.ToDouble(reader["HResolution"].ToString() as string);

                slide.Thumbnail = reader["Thumbnail"] as Byte[];

                slides.Add(slide);
            }

            conn.Close();

           return slides;

        }//end function



        static public void AddSlide(Slide slide)
        {
            SqlConnection conn = GetConnected();
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

           //VResolution
            cmdAdd.Parameters.Add("@VResolution", SqlDbType.Float);
            cmdAdd.Parameters["@VResolution"].Value = slide.VResolution;
  
            //HResolution
            cmdAdd.Parameters.Add("@HResolution", SqlDbType.Float);
            cmdAdd.Parameters["@HResolution"].Value = slide.HResolution;

           
            //ThumbNail
            cmdAdd.Parameters.Add("@ThumbNail", SqlDbType.Image);
            cmdAdd.Parameters["@ThumbNail"].Value = slide.Thumbnail;
            
            cmdAdd.ExecuteNonQuery();

            conn.Close();

        }//end function



        static public void DeleteSlide(string slideID)
        {
            SqlConnection conn = GetConnected();
            conn.Open();

            SqlCommand cmdDel = new SqlCommand("slide_delete_v1", conn);
            cmdDel.CommandType = CommandType.StoredProcedure;

            //GUID
            Guid guid = new Guid(slideID);
            cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
            cmdDel.Parameters["@GUID"].Value = guid;

            cmdDel.ExecuteNonQuery();

            conn.Close();

          }//end function


        //static public void UpdateSlide(Slide slide)
        //{
        //    SqlConnection conn = GetConnected();
        //    conn.Open();

        //    SqlCommand cmdAdd = new SqlCommand("slide_update_v1", conn);
        //    cmdAdd.CommandType = CommandType.StoredProcedure;

        //    //GUID
        //    cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
        //    cmdAdd.Parameters["@GUID"].Value = new Guid(slide.GUID);

        //    //Name
        //    cmdAdd.Parameters.Add("@Name", SqlDbType.NVarChar, 200);
        //    cmdAdd.Parameters["@Name"].Value = slide.Name;

        //    //HResolution
        //    cmdAdd.Parameters.Add("@HResolution", SqlDbType.Float);
        //    cmdAdd.Parameters["@HResolution"].Value = slide.HResolution;

        //    //VResolution
        //    cmdAdd.Parameters.Add("@VResolution", SqlDbType.Float);
        //    cmdAdd.Parameters["@VResolution"].Value = slide.VResolution;
           
        //    //ThumbNail
        //    cmdAdd.Parameters.Add("@ThumbNail", SqlDbType.Image);
        //    cmdAdd.Parameters["@ThumbNail"].Value = slide.Thumbnail;

        //    cmdAdd.ExecuteNonQuery();

        //    conn.Close();

        //}//end function

        
     

    }
}
