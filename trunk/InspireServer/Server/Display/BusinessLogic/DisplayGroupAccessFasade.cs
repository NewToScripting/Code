using Inspire.Server.Display.DataContracts;
using Inspire.Server.Display.DataAccess;

namespace Inspire.Server.Display.BusinessLogic
{
    /// <summary>
    /// Display Group Access Fasade
    /// </summary>
    public class DisplayGroupAccessFasade
    {
        /// <summary>
        /// Get Display Groups
        /// </summary>
        /// <param name="propertyGuid"></param>
        /// <returns></returns>
        static public DisplayGroups GetDisplayGroups(string propertyGuid)
        {
            DisplayGroups displayProperties = new DisplayGroups();
            displayProperties = DisplayGroupDatabaseAccess.GetGroups(propertyGuid);
            return displayProperties;
        }
        
        /// <summary>
        /// Get All Display Groups
        /// </summary>
        /// <returns></returns>
        static public DisplayGroups GetAllDisplayGroups()
        {
            DisplayGroups displayProperties = new DisplayGroups();
            displayProperties = DisplayGroupDatabaseAccess.GetAllGroups();
            return displayProperties;
        }

        /// <summary>
        /// Update Display Group
        /// </summary>
        /// <param name="displayGroup"></param>
        static public void UpdateDisplayGroup(DisplayGroup displayGroup)
        {
            DisplayGroupDatabaseAccess.UpdateDisplayGroup(displayGroup);
        }

        /// <summary>
        /// Add Display Group
        /// </summary>
        /// <param name="displayGroup"></param>
        static public void AddDisplayGroup(DisplayGroup displayGroup)
        {
            DisplayGroupDatabaseAccess.AddGroup(displayGroup);
        }

        /// <summary>
        /// Delete Display Group
        /// </summary>
        /// <param name="guid"></param>
        static public void DeleteDisplayGroup(string guid)
        {
            DisplayGroupDatabaseAccess.DeleteDisplayGroups(guid);
        }
    }
}
