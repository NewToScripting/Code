using Inspire.Server.Display.DataAccess;
using Inspire.Server.Display.DataContracts;

namespace Inspire.Server.Display.BusinessLogic
{
    /// <summary>
    /// Display Access Fasade
    /// </summary>
    public class DisplayAccessFasade
    {
        /// <summary>
        /// Get Displays
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        static public Displays GetDisplays(string groupID)
        {
            Displays displays = new Displays();
            displays = DisplayDatabaseAccess.GetDisplays(groupID);
            return displays;
        }

        /// <summary>
        /// Get Single Display
        /// </summary>
        /// <param name="displayID"></param>
        /// <returns></returns>
        static public DataContracts.Display GetSingleDisplays(string displayID)
        {
            var display = new DataContracts.Display();
            display = DisplayDatabaseAccess.GetSingleDisplay(displayID);
            return display;
        }

        /// <summary>
        /// Get Displays In Schedule
        /// </summary>
        /// <param name="scheduleID"></param>
        /// <returns></returns>
        static public Displays GetDisplaysInSchedule(string scheduleID)
        {
            Displays displays = DisplayDatabaseAccess.GetDisplaysInSchedule(scheduleID);
            return displays;

        }

        /// <summary>
        /// Get All Displays
        /// </summary>
        /// <returns></returns>
        static public Displays GetAllDisplays()
        {
            Displays displays = new Displays();
            displays = DisplayDatabaseAccess.GetAllDisplays();
            return displays;

        }

        /// <summary>
        /// Update Display
        /// </summary>
        /// <param name="display"></param>
        static public void UpdateDisplay(DataContracts.Display display)
        {
             DisplayDatabaseAccess.UpdateDisplay(display);
        }
        
        /// <summary>
        /// Add Display
        /// </summary>
        /// <param name="display"></param>
        static public void AddDisplay(DataContracts.Display display)
        {
            DisplayDatabaseAccess.AddDisplay(display);
        }

        /// <summary>
        /// Delete Display
        /// </summary>
        /// <param name="guid"></param>
        static public void DeleteDisplay(string guid)
        {
           DisplayDatabaseAccess.DeleteDisplay(guid);
        }
    }//class
}//namespace
