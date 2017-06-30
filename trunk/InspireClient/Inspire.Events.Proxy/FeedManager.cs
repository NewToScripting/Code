using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Inspire.Events.Proxy
{
    public class FeedManager
    {
        static private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            string connString = @"Data Source=testserver2008\sqldev2008;Initial Catalog=InspireFeedsDB;User Id=SA;Password=!nspire8;";
            conn.ConnectionString = connString;
            return conn;

        }


        static public List<Feed> GetFeeds()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("feeds_get_v1", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Feed> feeds = new List<Feed>();

                    while (reader.Read())
                    {
                        Feed feed = new Feed();
                        feed.GUID = reader["feed_guid"].ToString() as string;
                        feed.Name = reader["feed_name"] as string;
                        feed.Description = reader["feed_desc"] as string;
                        feed.NameField1Def = reader["name_field1_def"] as string;
                        feed.NameField2Def = reader["name_field2_def"] as string;
                        feed.NameField3Def = reader["name_field3_def"] as string;
                        feed.NameField4Def = reader["name_field4_def"] as string;
                        feed.DescField1Def = reader["desc_field1_def"] as string;
                        feed.DescField2Def = reader["desc_field2_def"] as string;
                        feed.DescField3Def = reader["desc_field3_def"] as string;
                        feed.DescField4Def = reader["desc_field4_def"] as string;
                        feed.TextField1Def = reader["text_field1_def"] as string;
                        feed.TextField2Def = reader["text_field2_def"] as string;
                        feed.IntField1Def = reader["int_field1_def"] as string;
                        feed.IntField2Def = reader["int_field2_def"] as string;
                        feed.DecimalField1Def = reader["decimal_field1_def"] as string;
                        feed.DecimalField2Def = reader["decimal_field2_def"] as string;

                        feeds.Add(feed);

                    }//end while

                    conn.Close();
                    return feeds;

                }//using
            }
            catch (Exception)
            {
                return null;
            }
            
        }//end function


        static public void AddFeed(Feed feed)
        {
            SqlConnection conn = GetConnection();

            conn.Open();

            SqlCommand cmdAdd = new SqlCommand("feed_add_v1", conn);
            cmdAdd.CommandType = CommandType.StoredProcedure;

            //GUID
            Guid guid = new Guid(feed.GUID);
            cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
            cmdAdd.Parameters["@GUID"].Value = guid;

            //Name
            cmdAdd.Parameters.Add("@feed_name", SqlDbType.NVarChar);
            cmdAdd.Parameters["@feed_name"].Value = feed.Description;
            
            //Desc
            cmdAdd.Parameters.Add("@feed_desc", SqlDbType.NVarChar);
            cmdAdd.Parameters["@feed_desc"].Value = feed.Description;

            //NameField1Def
            cmdAdd.Parameters.Add("@name_field1_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@name_field1_def"].Value = feed.NameField1Def;

            //NameField2Def
            cmdAdd.Parameters.Add("@name_field2_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@name_field2_def"].Value = feed.NameField2Def;

            //NameField3Def
            cmdAdd.Parameters.Add("@name_field3_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@name_field3_def"].Value = feed.NameField3Def;

            //NameField4Def
            cmdAdd.Parameters.Add("@name_field4_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@name_field4_def"].Value = feed.NameField4Def;

            //DescField1Def
            cmdAdd.Parameters.Add("@desc_field1_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@desc_field1_def"].Value = feed.DescField1Def;

            //DescField2Def
            cmdAdd.Parameters.Add("@desc_field2_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@desc_field2_def"].Value = feed.DescField2Def;

            //DescField3Def
            cmdAdd.Parameters.Add("@desc_field3_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@desc_field3_def"].Value = feed.DescField3Def;

            //DescField4Def
            cmdAdd.Parameters.Add("@desc_field4_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@desc_field4_def"].Value = feed.DescField4Def;

            //DescField4Def
            cmdAdd.Parameters.Add("@desc_field4_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@desc_field4_def"].Value = feed.DescField4Def;

            //DateField1Def
            cmdAdd.Parameters.Add("@date_field1_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@date_field1_def"].Value = feed.DateField1Def;

            //DateField2Def
            cmdAdd.Parameters.Add("@date_field2_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@date_field2_def"].Value = feed.DateField2Def;

            //DateField3Def
            cmdAdd.Parameters.Add("@date_field3_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@date_field3_def"].Value = feed.DateField3Def;

            //DateField4Def
            cmdAdd.Parameters.Add("@date_field4_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@date_field4_def"].Value = feed.DateField4Def;

            //DecimalField1Def
            cmdAdd.Parameters.Add("@decimal_field1_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@decimal_field1_def"].Value = feed.DecimalField1Def;

            //DecimalField2Def
            cmdAdd.Parameters.Add("@decimal_field2_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@decimal_field2_def"].Value = feed.DecimalField2Def;

            //TextField1Def
            cmdAdd.Parameters.Add("@text_field1_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@text_field1_def"].Value = feed.TextField1Def;

            //TextField2Def
            cmdAdd.Parameters.Add("@text_field2_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@text_field2_def"].Value = feed.TextField2Def;

            //IntField1Def
            cmdAdd.Parameters.Add("@int_field1_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@text_field1_def"].Value = feed.IntField1Def;

            //IntField2Def
            cmdAdd.Parameters.Add("@int_field2_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@text_field2_def"].Value = feed.IntField2Def;

            cmdAdd.ExecuteNonQuery();

            conn.Close();

            
        }//end function


        static public void UpdateFeed(Feed feed)
        {
            SqlConnection conn = GetConnection();

            conn.Open();

            SqlCommand cmdAdd = new SqlCommand("feed_update_v1", conn);
            cmdAdd.CommandType = CommandType.StoredProcedure;

            //GUID
            Guid guid = new Guid(feed.GUID);
            cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
            cmdAdd.Parameters["@GUID"].Value = guid;

            //Name
            cmdAdd.Parameters.Add("@feed_name", SqlDbType.NVarChar);
            cmdAdd.Parameters["@feed_name"].Value = feed.Description;

            //Desc
            cmdAdd.Parameters.Add("@feed_desc", SqlDbType.NVarChar);
            cmdAdd.Parameters["@feed_desc"].Value = feed.Description;

            //NameField1Def
            cmdAdd.Parameters.Add("@name_field1_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@name_field1_def"].Value = feed.NameField1Def;

            //NameField2Def
            cmdAdd.Parameters.Add("@name_field2_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@name_field2_def"].Value = feed.NameField2Def;

            //NameField3Def
            cmdAdd.Parameters.Add("@name_field3_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@name_field3_def"].Value = feed.NameField3Def;

            //NameField4Def
            cmdAdd.Parameters.Add("@name_field4_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@name_field4_def"].Value = feed.NameField4Def;

            //DescField1Def
            cmdAdd.Parameters.Add("@desc_field1_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@desc_field1_def"].Value = feed.DescField1Def;

            //DescField2Def
            cmdAdd.Parameters.Add("@desc_field2_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@desc_field2_def"].Value = feed.DescField2Def;

            //DescField3Def
            cmdAdd.Parameters.Add("@desc_field3_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@desc_field3_def"].Value = feed.DescField3Def;

            //DescField4Def
            cmdAdd.Parameters.Add("@desc_field4_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@desc_field4_def"].Value = feed.DescField4Def;

            //DescField4Def
            cmdAdd.Parameters.Add("@desc_field4_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@desc_field4_def"].Value = feed.DescField4Def;

            //DateField1Def
            cmdAdd.Parameters.Add("@date_field1_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@date_field1_def"].Value = feed.DateField1Def;

            //DateField2Def
            cmdAdd.Parameters.Add("@date_field2_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@date_field2_def"].Value = feed.DateField2Def;

            //DateField3Def
            cmdAdd.Parameters.Add("@date_field3_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@date_field3_def"].Value = feed.DateField3Def;

            //DateField4Def
            cmdAdd.Parameters.Add("@date_field4_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@date_field4_def"].Value = feed.DateField4Def;

            //DecimalField1Def
            cmdAdd.Parameters.Add("@decimal_field1_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@decimal_field1_def"].Value = feed.DecimalField1Def;

            //DecimalField2Def
            cmdAdd.Parameters.Add("@decimal_field2_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@decimal_field2_def"].Value = feed.DecimalField2Def;

            //TextField1Def
            cmdAdd.Parameters.Add("@text_field1_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@text_field1_def"].Value = feed.TextField1Def;

            //TextField2Def
            cmdAdd.Parameters.Add("@text_field2_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@text_field2_def"].Value = feed.TextField2Def;

            //IntField1Def
            cmdAdd.Parameters.Add("@int_field1_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@text_field1_def"].Value = feed.IntField1Def;

            //IntField2Def
            cmdAdd.Parameters.Add("@int_field2_def", SqlDbType.NVarChar);
            cmdAdd.Parameters["@text_field2_def"].Value = feed.IntField2Def;

            cmdAdd.ExecuteNonQuery();

            conn.Close();


        }//end function


        static public void DeleteFeed(string feedID)
        {
            SqlConnection conn = GetConnection();

            conn.Open();

            SqlCommand cmdDel = new SqlCommand("feed_delete_v1", conn);
            cmdDel.CommandType = CommandType.StoredProcedure;

            //GUID
            Guid guid = new Guid(feedID);
            cmdDel.Parameters.Add("@feed_guid", SqlDbType.UniqueIdentifier);
            cmdDel.Parameters["@feed_guid"].Value = guid;

            cmdDel.ExecuteNonQuery();

            conn.Close();

        }//end function


     }//class

    
}//namespace
