using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inspire.Server.SlideManager.DataAccess
{
    class SlideFileSql
    {

        public static string GetSlideFile(string slideID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT [GUID], [File] FROM SlideFile WHERE GUID = '" + slideID + "'");
            return sql.ToString();
        }

        public static string AddSlideFile()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"INSERT INTO SlideFile([GUID], [File]) VALUES (@GUID, @File)");
            return sql.ToString();
        }

        public static string UpdateSlideFile()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"UPDATE Slidefile SET [GUID] = @GUID, [File] = @File WHERE [GUID] = @GUID");
            return sql.ToString();
        }

          public static string DeleteSlideFile(string slideID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"DELETE FROM slidefile Where [GUID] = '" + slideID + "'");
            return sql.ToString();
        }

       
    }
}
