using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using InspireVisualOneConsoleInterface.EventsServiceReference;

namespace Inspire.VOI.Logging
{
    public class FileLogger
    {  
       public void Log(HospitalityEvent item)
        {
          StringBuilder line = new StringBuilder();
           line.Append(AddDateTimeToLine()); 
           line.Append("ID=" + item.EventId + ", ");
           line.Append("GroupName=" + item.GroupName + ", ");
           line.Append("MeetingRoomName=" + item.MeetingRoomName + ", ");
           line.Append("MeetingName=" + item.MeetingName + ", ");
           line.Append("StartDateTime=" + item.StartDateTime + ", ");
           line.Append("EndDateTime=" + item.EndDateTime + ", ");
           WriteLineToLog(line.ToString());
         }
                
       public void LogEvent(string item)
       {
           StringBuilder line = new StringBuilder();
           line.Append(AddDateTimeToLine());
           line.Append(" " + item);
           
           WriteLineToLog(line.ToString());
       }


        private string AddDateTimeToLine()                
        {            
            string sLogFormat;

            //sLogFormat used to create log files format :
            // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
            sLogFormat = DateTime.Now.ToShortDateString().ToString()+" "+DateTime.Now.ToLongTimeString().ToString()+" ==> ";
            
            return sLogFormat;
        }

        private void WriteLineToLog(string sErrMsg)
        {
            StreamWriter sw = new StreamWriter("InspireVisualOneLog.txt", true);
            sw.WriteLine(sErrMsg);
            sw.Flush();
            sw.Close();

        }

    }//end class   
}//end namespace
    
       
