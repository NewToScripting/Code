using Inspire.Server.Events.DataAccess;
using Inspire.Server.Events.DataContracts;

namespace Inspire.Server.Events.BusinessLogic
{
    /// <summary>
    /// Entry Access Fasade
    /// </summary>
     public class EventFileFormatAccessFasade
    {
      
        /// <summary>
        /// Delete Event
        /// </summary>
        /// <param name="feedID"></param>
        /// <returns></returns>
         static public void DeleteEvent(string eventID)
        {
            HospitalityEventDatabaseAccess.DeleteHospitalityEvent(eventID);
        }
        
         /// <summary>
         // Add Entry
         /// </summary>
         /// <param name="feedEntry"></param>
         static public void AddEvent(HospitalityEvent hospEvent)
         {
             HospitalityEventDatabaseAccess.AddEvent(hospEvent);
         }
         
         /// <summary>
         // Update Entry
         /// </summary>
         /// <param name="feedEntry"></param>
         static public void UpdateEvent(HospitalityEvent hospEvent)
         {
             HospitalityEventDatabaseAccess.UpdateEvent(hospEvent);
         }
         
         /// <summary>
         /// Get Events
         /// </summary>
         /// <param name="eventID"></param>
         static public HospitalityEvents GetEvents(string eventDescID)
         {
             return HospitalityEventDatabaseAccess.GetEvents(eventDescID);
         }

         /// <summary>
         /// Get Events Filtered
         /// </summary>
         /// <param name="eventID"></param>
         static public HospitalityEvents GetEventsFiltered(string eventDescGuid, string hostName)
         {
             return HospitalityEventDatabaseAccess.GetEventsFiltered(eventDescGuid, hostName);
         }

         /// <summary>
         /// Get Events NonFiltered
         /// </summary>
         /// <param name="eventID"></param>
         static public HospitalityEvents GetEventsNonFiltered(string eventDescGuid, string hostName)
         {
             return HospitalityEventDatabaseAccess.GetEventsNonFiltered(eventDescGuid, hostName);
         }

         /// <summary>
         /// Load Events
         /// </summary>
         /// <param name="eventID"></param>
         static public void LoadEvents()
         {
             //EventFileSourceAccess.LoadGetEventData();
         }

         /// <summary>
         /// Get Event File Format
         /// </summary>
         /// <param name="guid"></param>
         /// <returns></returns>
         static public EventFileFormat GetEventFileFormat(string guid)
         {
             return EventFileFormatDatabaseAccess.GetEventFileFormat(guid);
         }

         /// <summary>
         /// Get Event File Formats
         /// </summary>
         /// <returns></returns>
         static public EventFileFormats GetEventFileFormats()
         {
             return EventFileFormatDatabaseAccess.GetEventFileFormats();
         }

         /// <summary>
         /// Add Event File Format
         /// </summary>
         /// <param name="item"></param>
         static public void AddEventFileFormat(EventFileFormat item)
         {
             EventFileFormatDatabaseAccess.AddEventFileFormat(item);
         }

         /// <summary>
         /// Update Event File Format
         /// </summary>
         /// <param name="item"></param>
         static public void UpdateEventFileFormat(EventFileFormat item)
         {
             EventFileFormatDatabaseAccess.UpdateEventFileFormat(item);
         }

         /// <summary>
         /// Delete Event File Format
         /// </summary>
         /// <param name="guid"></param>
         static public void DeleteEventFileFormat(string guid)
         {
             EventFileFormatDatabaseAccess.DeleteEventFileFormat(guid);
         }

    }
}
