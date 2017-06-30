using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Inspire.Events.Proxy
{
    public class AliaseProxy
    {
        static private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            string connString = @"Data Source=testserver2008\sqldev2008;Initial Catalog=InspireFeedsDB;User Id=sa;Password=!nspire8;";
            conn.ConnectionString = connString;
            return conn;
        }

        static public ObservableCollection<Alias> GetAliases(string roomID)
        {
            ObservableCollection<Alias> aliases = new ObservableCollection<Alias>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("alias_get_from_roomID_v1", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                    
                    //GUID
                    Guid guid = new Guid(roomID);
                    cmd.Parameters.Add("@RoomID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@RoomID"].Value = guid;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Alias alias = new Alias();
                        alias.Guid = reader["GUID"].ToString() as string;
                        alias.Value = reader["Value"] as string;
                        alias.RoomID = reader["RoomID"].ToString() as string;
                        aliases.Add(alias);
                    }

                conn.Close();

            }//using

            return aliases;

        }//end function

        static public void AddAlias(Alias alias)
        {
            SqlConnection conn = GetConnection();
            conn.Open();

            SqlCommand cmdAdd = new SqlCommand("alias_add_v1", conn);
            cmdAdd.CommandType = CommandType.StoredProcedure;

                //GUID
                Guid guid = Guid.NewGuid();
                cmdAdd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
                cmdAdd.Parameters["@GUID"].Value = guid;

                //Alias
                cmdAdd.Parameters.Add("@Value", SqlDbType.NVarChar, 200);
                cmdAdd.Parameters["@Value"].Value = alias.Value;

                //RoomID
                Guid guid1 = new Guid(alias.RoomID);
                cmdAdd.Parameters.Add("@RoomID", SqlDbType.UniqueIdentifier);
                cmdAdd.Parameters["@RoomID"].Value = guid1;

            cmdAdd.ExecuteNonQuery();

            conn.Close();

        }//end function


        static public void DeleteAlias(string aliasID)
        {
            SqlConnection conn = GetConnection();
            conn.Open();

            SqlCommand cmdDel = new SqlCommand("alias_delete_v1", conn);
            cmdDel.CommandType = CommandType.StoredProcedure;

            //GUID
            Guid guid = new Guid(aliasID);
            cmdDel.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier);
            cmdDel.Parameters["@GUID"].Value = guid;

            cmdDel.ExecuteNonQuery();

            conn.Close();






        }//end function
    }
}
