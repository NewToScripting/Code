using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Inspire.Events.Proxy
{
    public class FeedTemplateProxy
    {

        static private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            string connString = @"Data Source=testserver2008\sqldev2008;Initial Catalog=InspireFeedsDB;User Id=sa;Password=!nspire8;";
            conn.ConnectionString = connString;
            return conn;
        }

        static public List<FeedTemplate> GetTemplates()
        {
            List<FeedTemplate> templates = new List<FeedTemplate>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("templates_get_v1", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FeedTemplate template = new FeedTemplate();
                    template.Guid = reader["guid"].ToString() as string;
                    template.Name = reader["name"] as string;
                    template.Rows = reader["rows"] as int?;
                    template.Description = reader["description"] as string;
                    template.Thumb_Nail = reader["thumb_nail"] as Byte[];
                    template.Type = reader["type"] as string;
                    int? tempFields = reader["fields"] as int?;
                    if (tempFields != null) template.Fields = (FeedTemplate.FieldsEnum)tempFields;

                    templates.Add(template);
                }

                conn.Close();

            }//using

            return templates;

        }//end function



        static public FeedTemplate GetSingleTemplate(string templateID)
        {
           FeedTemplate template = new FeedTemplate();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("template_get_single_v1", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                //templateID
                Guid guid1 = new Guid(templateID);
                cmd.Parameters.Add("@guid", SqlDbType.UniqueIdentifier);
                cmd.Parameters["@guid"].Value = guid1;

                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    template.Guid = reader["guid"].ToString() as string;
                    template.Name = reader["name"] as string;
                    template.Rows = reader["rows"] as int?;
                    template.Description = reader["description"] as string;
                    template.Thumb_Nail = reader["thumb_nail"] as Byte[];
                    template.File = reader["file"] as Byte[];
                    template.Type = reader["type"] as string;
                    int? tempFields = reader["fields"] as int?;
                    if (tempFields != null) template.Fields = (FeedTemplate.FieldsEnum)tempFields;
                   
                }

                conn.Close();

            }//using

            return template;

        }//end function

        static public void AddTemplate(FeedTemplate template)
        {
            SqlConnection conn = GetConnection();
            conn.Open();

            SqlCommand cmdAdd = new SqlCommand("template_add_v1", conn);
            cmdAdd.CommandType = CommandType.StoredProcedure;

            //GUID
            Guid guid = new Guid(template.Guid);
            cmdAdd.Parameters.Add("@guid", SqlDbType.UniqueIdentifier);
            cmdAdd.Parameters["@guid"].Value = guid;

            //Name
            cmdAdd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
            cmdAdd.Parameters["@Name"].Value = template.Name;

            //Rows
            cmdAdd.Parameters.Add("@rows", SqlDbType.Int);
            cmdAdd.Parameters["@rows"].Value = template.Rows;

            //File
            cmdAdd.Parameters.Add("@file", SqlDbType.VarBinary);
            cmdAdd.Parameters["@file"].Value = template.File;

            //Thumbnail
            cmdAdd.Parameters.Add("@thumb_nail", SqlDbType.Image);
            cmdAdd.Parameters["@thumb_nail"].Value = template.Thumb_Nail;

            //Type
            cmdAdd.Parameters.Add("@type", SqlDbType.NVarChar, 50);
            cmdAdd.Parameters["@type"].Value = template.Type;

            //Description
            cmdAdd.Parameters.Add("@description", SqlDbType.NVarChar, 200);
            cmdAdd.Parameters["@description"].Value = template.Description;

            //Fields
            cmdAdd.Parameters.Add("@fields", SqlDbType.Int);
            cmdAdd.Parameters["@fields"].Value = (int)template.Fields;

            cmdAdd.ExecuteNonQuery();

            conn.Close();

        }//end function

        static public void DeleteTemplate(string templateID)
        {
            SqlConnection conn = GetConnection();
            conn.Open();

            SqlCommand cmdDel = new SqlCommand("template_delete_v1", conn);
            cmdDel.CommandType = CommandType.StoredProcedure;

            //GUID
            Guid guid = new Guid(templateID);
            cmdDel.Parameters.Add("@guid", SqlDbType.UniqueIdentifier);
            cmdDel.Parameters["@guid"].Value = guid;

            cmdDel.ExecuteNonQuery();

            conn.Close();

        }



    }
}
