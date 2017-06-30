using Inspire.Server.Events.DataAccess;
using Inspire.Server.Events.DataContracts;

namespace Inspire.Server.Events.BusinessLogic
{
    /// <summary>
    /// Entry Access Fasade
    /// </summary>
     public class EventAccessFasade
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
             HospitalityEvents item = new HospitalityEvents();

             if (!string.IsNullOrEmpty(eventDescGuid))
             {                 
                 item = HospitalityEventDatabaseAccess.GetEventsFiltered(eventDescGuid, hostName);

                 if (item == null)
                 {
                     HospitalityEventDefinition desc = HospitalityEventDescriptionsDatabaseAccess.GetDefaultEventDefinition();
                     item = HospitalityEventDatabaseAccess.GetEventsFiltered(desc.EventDefinitionGuid, hostName);
                 }
             }
             else
                 {
                     HospitalityEventDefinition desc = HospitalityEventDescriptionsDatabaseAccess.GetDefaultEventDefinition();
                     item = HospitalityEventDatabaseAccess.GetEventsFiltered(desc.EventDefinitionGuid, hostName);
                 }            

             return item;
         }

         /// <summary>
         /// Get Events NonFilteredINspire
         /// </summary>
         /// <param name="eventID"></param>
         static public HospitalityEvents GetEventsNonFiltered(string eventDescGuid, string hostName)
         {
             HospitalityEvents item = new HospitalityEvents();

             if (!string.IsNullOrEmpty(eventDescGuid))
             {
                 item = HospitalityEventDatabaseAccess.GetEventsNonFiltered(eventDescGuid, hostName);

                 if (item == null)
                 {
                     HospitalityEventDefinition desc = HospitalityEventDescriptionsDatabaseAccess.GetDefaultEventDefinition();
                     item = HospitalityEventDatabaseAccess.GetEventsNonFiltered(desc.EventDefinitionGuid, hostName);
                 }
             }
             else
             {
                 HospitalityEventDefinition desc = HospitalityEventDescriptionsDatabaseAccess.GetDefaultEventDefinition();
                 item = HospitalityEventDatabaseAccess.GetEventsNonFiltered(desc.EventDefinitionGuid, hostName);
             }

             return item;
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
         /// Load Events
         /// </summary>
         /// <param name="eventID"></param>
         static public void TuncateEvents(string item)
         {
             HospitalityEventDatabaseAccess.TruncateHospitalityEvents(item);
         }
    }
}
