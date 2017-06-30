using Inspire.Server.Events.DataAccess;
using Inspire.Server.Events.DataContracts;


namespace Inspire.Server.Events.BusinessLogic
{
    /// <summary>
    /// Event Description Access Fasade 
    /// </summary>
    public class EventDescriptionAccessFasade
    {

        /// <summary>
        /// Get HospitalityEventDefinitions
        /// </summary>
        /// <returns></returns>
        static public HospitalityEventDefinition GetDefaultEventDefinition()
        {
            HospitalityEventDefinition item = new HospitalityEventDefinition();
            item = HospitalityEventDescriptionsDatabaseAccess.GetDefaultEventDefinition();
            return item;
        }

        /// <summary>
        /// Get HospitalityEventDefinitions
        /// </summary>
        /// <returns></returns>
        static public HospitalityEventDefinitions GetEventDefinitions()
        {
            HospitalityEventDefinitions items = new HospitalityEventDefinitions();
            items = HospitalityEventDescriptionsDatabaseAccess.GetEventDefinitions();
            return items;
        }

        /// <summary>
        /// Add HospitalityEventDefinition
        /// </summary>
        /// <param name="item"></param>
        static public void AddEventDefinitions(HospitalityEventDefinition item)
        {
            HospitalityEventDescriptionsDatabaseAccess.AddEventDefinition(item);
        }

        /// <summary>
        /// Delete HospitalityEventDefinition
        /// </summary>
        /// <param name="feedID"></param>
        static public void DeleteFeed(string itemID)
        {
            HospitalityEventDescriptionsDatabaseAccess.DeleteEventDefinition(itemID);
        }


        /// <summary>
        /// Set Default Definition
        /// </summary>
        /// <param name="feedID"></param>
        static public void SetDefaultDefinition(string itemID)
        {
            HospitalityEventDescriptionsDatabaseAccess.SetDefaultDefinition(itemID);
        }


        /// <summary>
        /// Update Event Definition
        /// </summary>
        /// <param name="feedID"></param>
        static public void UpdateEventDefinition(HospitalityEventDefinition item)
        {
            HospitalityEventDescriptionsDatabaseAccess.UpdateEventDefinition(item);
        }

    }
}
