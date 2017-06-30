using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Markup;
using System.Xml;
using Inspire.Server.Events.DataContracts;
using System.Data.SqlTypes;
using Inspire.Server.Common;


namespace Inspire.Server.Events.DataAccess
{
    public class EventFileSourceAccess
    {
      public void LoadSeparatedData(FieldContracts items, string uri, bool skipFirstRow, string eventDefinitionGuid, string Delimiter)
        {
            string mappingFile = uri;
          
          try
          {

            //Open the flat file using a StreamReader.
            using (var reader = new StreamReader(uri))
            {
                //Load the first line of the file.
                
                string line = reader.ReadLine();    
            
                if (skipFirstRow) {line = reader.ReadLine();}

                //Loop through the file until there are no lines
                // left.
                while (!String.IsNullOrEmpty(line))
                {
                    string[] fields;
                    
                    if (Delimiter == "/t")
                    { fields = line.Split(new char[] { '\t' });}
                    else
                    { fields = line.Split(new char[] { ',' }); };  

                    var record = new HospitalityEvent();

                    foreach (FieldContract fieldContract in items)
                    {
                        switch (fieldContract.Name)
                        {
                            case ("GroupName"):
                                record.GroupName = fields[(int)fieldContract.Start - 1].Trim();
                                break;
                            case ("HotelName"):
                                record.MeetingName = fields[(int)fieldContract.Start - 1].Trim();
                                break;
                            case ("Exhibit"):
                                record.MeetingName = fields[(int)fieldContract.Start - 1].Trim();
                                break;
                            case ("GroupLogo"):
                                record.MeetingName = fields[(int)fieldContract.Start - 1].Trim();
                                break;
                            case ("BackupMeetingRoomSpace"):
                                record.MeetingName = fields[(int)fieldContract.Start - 1].Trim();
                                break;
                            case ("HostEventIdentifier"):
                                record.MeetingName = fields[(int)fieldContract.Start - 1].Trim();
                                break;
                            case ("MeetingID"):
                                record.MeetingName = fields[(int)fieldContract.Start - 1].Trim();
                                break;
                            case ("MeetingLogo"):
                                record.MeetingName = fields[(int)fieldContract.Start - 1].Trim();
                                break;
                            case ("MeetingName"):
                                record.MeetingName = fields[(int)fieldContract.Start - 1].Trim();
                                break;
                            case ("MeetingPostAs"):
                                record.MeetingName = fields[(int)fieldContract.Start - 1].Trim();
                                break;
                            case ("MeetingRoomID"):
                                record.MeetingRoomId = fields[(int)fieldContract.Start - 1].Trim();
                                break;
                            case ("MeetingRoomLogo"):
                                record.MeetingRoomId = fields[(int)fieldContract.Start - 1].Trim();
                                break;                          
                            case ("MeetingRoomName"):
                                record.MeetingRoomName = fields[(int)fieldContract.Start - 1].Trim();
                                break;
                            case ("MeetingType"):
                                record.MeetingType = fields[(int)fieldContract.Start - 1].Trim();
                                break;
                            case ("OverflowMeetingRoomSpace"):
                                record.MeetingType = fields[(int)fieldContract.Start - 1].Trim();
                                break;
                            case ("Portable"):
                                record.MeetingType = fields[(int)fieldContract.Start - 1].Trim();
                                break;
                            case ("StartTime"):
                                DateTime startTime;
                                DateTime.TryParse(fields[(int)fieldContract.Start - 1].Trim(), out startTime);
                                if (startTime == DateTime.MinValue) {startTime = SqlDateTime.MinValue.Value;};
                                record.StartDateTime = startTime;
                                break;
                            case ("EndTime"):
                                DateTime endTime;
                                DateTime.TryParse(fields[(int)fieldContract.Start - 1].Trim(), out endTime);
                                if (endTime == DateTime.MinValue) { endTime = SqlDateTime.MinValue.Value; };
                                record.EndDateTime = endTime;
                                break;

                        }//switch
                    }//foreach

                    //Add the record to our record collection
                    record.EventGuid = Guid.NewGuid().ToString();
                    record.EventDefinitionGuid = eventDefinitionGuid;

                    HospitalityEventDatabaseAccess.AddEvent(record);

                    //Read the next line.
                    line = reader.ReadLine();
                }//while
            //}//using
        }//foreach
    }

    catch (Exception e)
    {
        EventLogger.LogAndThrowFault(e.Message, "Error loading events into database.");
    }

  }


      public void LoadFixedData(FieldContracts items, string uri, bool skipFirstRow, string eventDefinitionGuid)
      {
          string mappingFile = uri;

          try
          {

          //Open the flat file using a StreamReader.
          using (var reader = new StreamReader(uri))
          {
              //Load the first line of the file.

              string line = reader.ReadLine();

              if (skipFirstRow) { line = reader.ReadLine(); }

              //Loop through the file until there are no lines
              // left.
              while (!String.IsNullOrEmpty(line))
              {
                  //string[] fields;

                  var record = new HospitalityEvent();

                  foreach (FieldContract fieldContract in items)
                  {
                      switch (fieldContract.Name)
                      {
                          case ("GroupName"):
                              record.GroupName = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;
                          case ("HotelName"):
                              record.MeetingName = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;
                          case ("Exhibit"):
                              record.MeetingName = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;
                          case ("GroupLogo"):
                              record.MeetingName = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;
                          case ("BackupMeetingRoomSpace"):
                              record.MeetingName = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;
                          case ("HostEventIdentifier"):
                              record.MeetingName = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;
                          case ("MeetingID"):
                              record.MeetingName = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;
                          case ("MeetingLogo"):
                              record.MeetingName = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;
                          case ("MeetingName"):
                              record.MeetingName = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;
                          case ("MeetingPostAs"):
                              record.MeetingName = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;
                          case ("MeetingRoomID"):
                              record.MeetingRoomId = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;
                          case ("MeetingRoomLogo"):
                              record.MeetingRoomId = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;
                          case ("MeetingRoomName"):
                              record.MeetingRoomName = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;
                          case ("MeetingType"):
                              record.MeetingType = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;
                          case ("OverflowMeetingRoomSpace"):
                              record.MeetingType = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;
                          case ("Portable"):
                              record.MeetingType = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                              break;


                          //case ("GroupName"):
                          //    record.GroupName = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                          //    break;
                          //case ("MeetingName"):
                          //    record.MeetingName = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                          //    break;
                          //case ("MeetingID"):
                          //    record.MeetingId = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                          //    break;
                          //case ("MeetingPostAs"):
                          //    record.MeetingPostAs = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                          //    break;
                          //case ("MeetingRoomID"):
                          //    record.MeetingRoomId = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                          //    break;
                          //case ("MeetingRoomName"):
                          //    record.MeetingRoomName = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                          //    break;
                          //case ("MeetingType"):
                          //    record.MeetingType = line.Substring((int)fieldContract.Start, (int)fieldContract.Length).Trim();
                          //    break;



                          case ("StartTime"):
                              DateTime startTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, Convert.ToInt32(line.Substring((int)fieldContract.Start, 2)), Convert.ToInt32(line.Substring((int)fieldContract.Start + 2, 2)), 0);
                              record.StartDateTime = startTime;
                              break;
                          case ("EndTime"):
                              record.EndDateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, Convert.ToInt32(line.Substring((int)fieldContract.Start, 2)), Convert.ToInt32(line.Substring((int)fieldContract.Start + 2, 2)), 0);
                              break;

                      }//switch
                  }//foreach

                  //Add the record to our record collection
                  record.EventGuid = Guid.NewGuid().ToString();
                  record.EventDefinitionGuid = eventDefinitionGuid;

                  HospitalityEventDatabaseAccess.AddEvent(record);

                  //Read the next line.
                  line = reader.ReadLine();
              }//while
              //}//using
          }//foreach
      }
      catch (Exception e)
      {
          EventLogger.LogAndThrowFault(e.Message, "Error loading events into database.");
      }

   }//
    


        public void LoadGetEventData()
        {
          
                List<HospitalityEventDefinition> defs = HospitalityEventDescriptionsDatabaseAccess.GetEventDefinitions();

                foreach (HospitalityEventDefinition item in defs)
                {
                    HospitalityEventDatabaseAccess.TruncateHospitalityEvents(item.EventDefinitionGuid);
                   
                    switch (item.EventFileFormat.TextFormat)
                    {
                        case 1: LoadSeparatedData(item.EventFileFormat.FieldContracts, item.Uri, (bool)item.EventFileFormat.SkipFirstFile, item.EventDefinitionGuid, item.EventFileFormat.FieldDelimeter);
                            break;
                        case 2: LoadFixedData(item.EventFileFormat.FieldContracts, item.Uri, (bool)item.EventFileFormat.SkipFirstFile, item.EventDefinitionGuid);
                            break;
                    }
                }                       
        }//end function

        

    } //end class
}//end namespace