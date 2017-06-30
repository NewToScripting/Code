using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inspire.Server.ScheduleManager.DataAccess
{
    public class ScheduleSql
    {
        //Display

        public static string UpdateActiveFlag(string hostName)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE Display SET ActiveFlag = '1', LastCommunication = GETDATE() WHERE HostName = '" + hostName + "'");
            return sql.ToString();
        }

          public static string GetSchedulesFromHostname()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT Distinct Sch.[GUID],Sch.[Name],Sch.[Type],Sch.StartTime,Sch.StartDate,Sch.EndTime,Sch.EndDate,Sch.Priority,Sch.Mode,Sch.Days FROM Schedule Sch");
            sql.Append(@" join DisplayScheduleAssn Assn on Assn.ScheduleID = Sch.GUID");
            sql.Append(@" join Display Disp on Assn.DisplayID = Disp.GUID");
            sql.Append(@" WHERE (Disp.HostName = @HostName AND DATEDIFF(DAYOFYEAR,Sch.EndDate, @StartDate) <= 0 AND DATEDIFF(DAYOFYEAR,Sch.StartDate, GETDATE()) >= 0) OR (Sch.Type = 'Default' and Disp.HostName = @HostName)");
              
            return sql.ToString();
        }

          public static string GetrentCurSchedules()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT Sch.[GUID],Sch.[Name],Sch.[Type],Sch.StartTime,Sch.StartDate,Sch.EndTime,Sch.EndDate,Sch.Priority,Sch.Mode,Sch.Days FROM Schedule Sch");
            sql.Append(@" join DisplayScheduleAssn Assn on Assn.ScheduleID = Sch.GUID WHERE Assn.DisplayID = @DisplayID");
                 
            return sql.ToString();
        }

          public static string GetSchedules()
          {
              StringBuilder sql = new StringBuilder();
              sql.Append(@"SELECT Sch.[GUID],Sch.[Name],Sch.[Type],Sch.StartTime,Sch.StartDate,Sch.EndTime,Sch.EndDate,Sch.Priority,Sch.Mode,Sch.Days FROM Schedule Sch");
              sql.Append(@" join DisplayScheduleAssn Assn on Assn.ScheduleID = Sch.GUID WHERE Assn.DisplayID = @DisplayID");

              return sql.ToString();
          }

         public static string AddSchedule()
          {
              StringBuilder sql = new StringBuilder();
              sql.Append(@" INSERT INTO Schedule([GUID], [Name], [Type], StartTime, StartDate, EndTime, EndDate, Priority, Mode, Days)");
              sql.Append(@" VALUES (@GUID, @Name, @Type, @StartTime, @StartDate, @EndTime, @EndDate, @Priority, @Mode, @Days)");
     
          

              return sql.ToString();
          }

         public static string UpdateSchedule()
          {
              StringBuilder sql = new StringBuilder();
              sql.Append(@"UPDATE Schedule SET [GUID] = @GUID,[Name] = @Name,[Type] = @Type,StartTime = @StartTime,StartDate = @StartDate,EndTime = @EndTime, EndDate = @EndDate,Priority = @Priority,Mode = @Mode,Days = @Days WHERE [GUID] = @GUID");
              //sql.Append(@" INSERT INTO SystemTransactions ([TimeStamp] , TransCode, HostName ) VALUES (CURRENT_TIMESTAMP, 'SCHED_UPDT', null )");
          

              return sql.ToString();
          }


         //public static string CheckForLastUpdate()
         // {
         //     StringBuilder sql = new StringBuilder();
         //     sql.Append(@"DECLARE @MAXCHECK DATETIME SET @MAXCHECK = (SELECT MAX([TimeStamp])FROM SystemTransactions WHERE TransCode = 'UPDATE_CHK' AND @HostName = HostName)");
         //     sql.Append(@" SELECT MAX(TransCode) AS TransCode FROM SystemTransactions WHERE [TimeStamp] > @MAXCHECK AND TransCode <> 'UPDATE_CHK'");
         //     sql.Append(@" INSERT INTO SystemTransactions ([TimeStamp] , TransCode, HostName ) VALUES (CURRENT_TIMESTAMP, 'UPDATE_CHK', @HostName )");
          

         //     return sql.ToString();
         // }

         public static string CheckForLastUpdateGetMaxDate()
         {
             StringBuilder sql = new StringBuilder();
             sql.Append(@"SELECT MAX([TimeStamp])FROM SystemTransactions WHERE TransCode = 'UPDATE_CHK' AND @HostName = HostName");
             return sql.ToString();
         }


         public static string CheckForLastUpdateCheckTransDate()
         {
             StringBuilder sql = new StringBuilder();
             sql.Append(@"SELECT MAX(TransCode) AS TransCode FROM SystemTransactions WHERE [TimeStamp] > @MaxCheck AND TransCode <> 'UPDATE_CHK'");
             return sql.ToString();
         }

    }
}




        
	
		 
	

