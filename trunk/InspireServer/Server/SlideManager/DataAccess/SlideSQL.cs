using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Inspire.Server.SlideManager.DataAccess
{
    class SlideSQL
    {
        public static string GetAllSlides()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT [GUID], [Name], [Description], HResolution, VResolution, DefaultDuration, LastModifiedDate, ModifiedBy FROM Slide");
            return sql.ToString();
        }

        public static string GetSlide(string slideID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT [GUID], [Name], [Description], HResolution, VResolution, DefaultDuration, LastModifiedDate, ModifiedBy FROM Slide WHERE Slide.[GUID] = '" + slideID + "'");
            return sql.ToString();
        }

          public static string AddSlide()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"INSERT INTO Slide([GUID],[Name],[Description],VResolution,HResolution,DefaultDuration,LastModifiedDate,ModifiedBy) VALUES (@GUID, @Name,@Description,@VResolution,@HResolution,@DefaultDuration,@LastModifiedDate,@ModifiedBy )");
            return sql.ToString();
        }
          public static string DeleteSlide()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"DELETE FROM Slide Where [GUID] = @GUID");
            return sql.ToString();
        }

          public static string DeleteSlideScheduledSlide()
          {
              StringBuilder sql = new StringBuilder();
              sql.Append(@"DELETE FROM ScheduledSlide WHERE ScheduledSlide.OriginalSlideID = @GUID");
              return sql.ToString();
          }
          public static string DeleteSlideButton()
          {
              StringBuilder sql = new StringBuilder();
              sql.Append(@"DELETE FROM Button Where SlideID = @GUID");
              return sql.ToString();
          }
       

    }
}
