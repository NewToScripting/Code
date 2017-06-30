using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Inspire.Events.Proxy
{
    public class FeedEntryManager
    {
        static private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            string connString = @"Data Source=testserver2008\sqldev2008;Initial Catalog=InspireFeedsDB;User Id=SA;Password=!nspire8;";
            conn.ConnectionString = connString;
            return conn;

        }

        //static public List<FeedEntry> GetFeedEntries(string feedID)
        //{
        //    using (SqlConnection conn = GetConnection())
        //    {
        //        conn.Open();

        //        SqlCommand cmd = new SqlCommand("feed_entry_get_v1", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        //GUID
        //        Guid guid = new Guid(feedID);
        //        cmd.Parameters.Add("@feed_guid", SqlDbType.UniqueIdentifier);
        //        cmd.Parameters["@feed_guid"].Value = guid;

        //        SqlDataReader reader = cmd.ExecuteReader();

        //        List<FeedEntry> entries = new List<FeedEntry>();

        //        while (reader.Read())
        //        {
        //            FeedEntry entry = new FeedEntry();

        //            entry.FeedID = reader["feed_guid"].ToString() as string;
        //            entry.NameField1 = reader["name_field1"] as string;
        //            entry.NameField2 = reader["name_field2"] as string;
        //            entry.NameField3 = reader["name_field3"] as string;
        //            entry.NameField4 = reader["name_field4"] as string;
        //            entry.DescField1 = reader["desc_field1"] as string;
        //            entry.DescField2 = reader["desc_field2"] as string;
        //            entry.DescField3 = reader["desc_field3"] as string;
        //            entry.DescField4 = reader["desc_field4"] as string;
        //            entry.TextField1 = reader["text_field1"] as string;
        //            entry.TextField2 = reader["text_field2"] as string;
        //            entry.IntField1 = reader["int_field1"] as int?;
        //            entry.IntField2 = reader["int_field2"] as int?;
        //            entry.DecimalField1 = reader["decimal_field1"] as decimal?;
        //            entry.DecimalField2 = reader["decimal_field2"] as decimal?;
        //            entries.Add(entry);
        //        }//end while

        //        conn.Close();

        //        return entries;

        //    }//using
            

        //}//function
    }//class
}//namespace