using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inspire.Server.ScheduledSlideManager.DataAccess
{
    class ScheduledSlideSQL
    {
        public static string AddScheduledSlide()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"INSERT INTO ScheduledSlide ([GUID], [Name],[Description],Transition,TransitionSpeed,Duration,OriginalSlideID,ScheduleID) VALUES (@GUID,@Name,@Description,@Transition,@TransitionSpeed,@Duration,@OriginalSlideID,@ScheduleID)");
            return sql.ToString();
        }

         public static string DeleteScheduledSlide()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@" DELETE FROM ScheduledSlide Where GUID = @GUID");
            return sql.ToString();
        }

         public static string DeleteScheduledSlideNavButtons()
         {
             StringBuilder sql = new StringBuilder();
             sql.Append(@" DELETE FROM ButtonNavagation Where ScheduledSlideID = @GUID");
             return sql.ToString();
         }


         public static string UpdateOriginalSlideIds()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"UPDATE ScheduledSlide SET OriginalSlideID = @NewSlideID WHERE OriginalSlideID = @OriginalSlideID");
            return sql.ToString();
        }

         public static string UpdateOriginalSlideIdsDeleteExisting()
         {
             StringBuilder sql = new StringBuilder();
             sql.Append(@" DELETE FROM slide Where [GUID] = @OriginalSlideID ");
             return sql.ToString();
         }

        //   public static string GetButtonNavagations()
        //{
        //    StringBuilder sql = new StringBuilder();

        //    sql.Append(@"IF EXISTS (select [GUID]from buttonnavagation where scheduledSlideID = @ScheduledSlideID)");
        //    sql.Append(@" BEGIN SELECT bn.[SlideGuidToNavigateTo],b.[GUID],bn.[scheduledSlideID],bn.[ButtonID],b.[ButtonName],b.[SlideID] FROM button b left join buttonnavagation bn on bn.ButtonID = b.[GUID] WHERE (b.SlideID = @SlideID and scheduledslideid is null)");
        //    sql.Append(@" Union	SELECT bn.[SlideGuidToNavigateTo],b.[GUID],bn.[scheduledSlideID],bn.[ButtonID],b.[ButtonName],b.[SlideID] FROM button b left join buttonnavagation bn on bn.ButtonID = b.[GUID] WHERE (bn.ScheduledSlideID = @ScheduledSlideID)");
        //    sql.Append(@" END ELSE BEGIN SELECT null as 'SlideGuidToNavigateTo',[GUID],null as 'scheduledSlideID',null as 'ButtonID',[ButtonName],[SlideID] FROM button WHERE SlideID = @SlideID END");
              
        //    return sql.ToString();
        //}

         public static string GetButtonNavagationsFromScheduleID()
         {
             StringBuilder sql = new StringBuilder();
             sql.Append(@"select [GUID]from buttonnavagation where scheduledSlideID = @ScheduledSlideID");
             return sql.ToString();
         }

         public static string GetButtonNavagationsFromScheduleIDIsNull()
         {
             StringBuilder sql = new StringBuilder();
             sql.Append(@" SELECT bn.[SlideGuidToNavigateTo],b.[GUID],bn.[scheduledSlideID],bn.[ButtonID],b.[ButtonName],b.[SlideID] FROM button b left join buttonnavagation bn on bn.ButtonID = b.[GUID] WHERE (b.SlideID = @SlideID and scheduledslideid is null)");
             return sql.ToString();
         }

         public static string GetButtonNavagationsFromScheduleIDNotNull()
         {
             StringBuilder sql = new StringBuilder();
             sql.Append(@" SELECT bn.[SlideGuidToNavigateTo],b.[GUID],bn.[scheduledSlideID],bn.[ButtonID],b.[ButtonName],b.[SlideID] FROM button b left join buttonnavagation bn on bn.ButtonID = b.[GUID] WHERE (bn.ScheduledSlideID = @ScheduledSlideID)");
             return sql.ToString();
         }


         public static string GetButtonNavagationsFromSlideID()
         {
             StringBuilder sql = new StringBuilder();
             sql.Append(@" SELECT [GUID],[ButtonName],[SlideID] FROM button WHERE SlideID = @SlideID");
             return sql.ToString();
         }
		



    }
}
