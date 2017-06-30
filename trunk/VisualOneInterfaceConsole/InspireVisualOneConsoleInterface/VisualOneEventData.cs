using System;
using System.Data.Odbc;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using Inspire.VOI.Logging;
using InspireVisualOneConsoleInterface.EventsServiceReference;

namespace Inspire.VOI.Data
{    
    /// <summary>
    /// Alias Database Access
    /// </summary>
    public class VisualOneEventData
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public VisualOneEventData()
        {
            EventDefinitionID = ConfigurationManager.AppSettings["EventDefinitionID"];
        }


        public string EventDefinitionID { get; set; }
                        
        /// <summary>
        /// Get SQL Connection
        /// </summary>
        /// <returns></returns>
        private OdbcConnection GetConnection()
        {
            OdbcConnection conn = new OdbcConnection();
            string connString = ConfigurationManager.ConnectionStrings["VisualOne"].ToString();
            conn.ConnectionString = connString;
            return conn;
        }

        /// <summary>
        /// Get Aliases
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>
        public List<HospitalityEvent> GetEvents()
        {
            string sql = "SELECT RB.BKNAME AS 'GroupName', MNAME AS 'MeetingName', RMNAME AS 'MeetingRoomName', ACT_BEG_DATE AS 'StartDateTime', ACT_END_DATE AS 'EndDateTime' FROM NGFUNCT F JOIN NGFMBOOK B ON F.BOOKID = B.BOOKID JOIN NGFNROOM R ON F.RMCODE = R.RMCODE JOIN NGFMBOOK RB ON F.BOOKID = RB.BOOKID LEFT JOIN NGFSR2 C ON C.uniquenumid = F.FUNCID WHERE END_DATE > (GETDATE() - 1) AND (BEG_DATE <= (GETDATE() + 1)) AND (B.BOOKACTIVITY <> 'C') AND isnull(C.CHECK1,0) <> 1 ORDER BY BEG_DATE DESC";


            FileLogger logger = new FileLogger();
            List<HospitalityEvent> events = new List<HospitalityEvent>();

            try
            {

                using (OdbcConnection conn = GetConnection())
                {
                    logger.LogEvent("Opening DSN Connection...");

                    conn.Open();

                    logger.LogEvent("DSN Connection Opened... " + conn.ConnectionString);

                    OdbcCommand cmd = new OdbcCommand(sql, conn);
                   
                    OdbcDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HospitalityEvent item = new HospitalityEvent();
                        item.EventId = Guid.NewGuid().ToString();
                        item.EventDefinitionId = EventDefinitionID;
                        item.MeetingName = reader["MeetingName"] as string;
                        item.GroupName = reader["GroupName"] as string;
                        item.MeetingRoomName = reader["MeetingRoomName"] as string;
                        item.StartDateTime = reader["StartDateTime"] as DateTime?;
                        item.EndDateTime = reader["EndDateTime"] as DateTime?;
                        events.Add(item);
                    }

                    conn.Close();

                }//using
            }//try
            catch (Exception e)
            {
                logger.LogEvent("Error occoured: " + e.Message);
                throw e;
            }

            return events;

        }//end function    
    }//end class
}//end namespace


