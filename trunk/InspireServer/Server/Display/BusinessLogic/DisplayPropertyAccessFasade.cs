using Inspire.Server.Display.DataContracts;
using Inspire.Server.Display.DataAccess;

namespace Inspire.Server.Display.BusinessLogic
{
    public class DisplayPropertyAccessFasade
    {
        /// <summary>
        /// Get All Displays
        /// </summary>
        /// <returns></returns>
        static public DisplayProperties GetAllDisplays()
        {
            DisplayProperties displayProperties = new DisplayProperties();
            displayProperties = DisplayPropertyDatabaseAccess.GetAllProperties();
            return displayProperties;
        }

        /// <summary>
        /// Update Display Property
        /// </summary>
        /// <param name="displayProperty"></param>
        static public void UpdateDisplayProperty(DisplayProperty displayProperty)
        {
            DisplayPropertyDatabaseAccess.UpdateDisplayProperty(displayProperty);
          
        }

        /// <summary>
        /// Add Display Property
        /// </summary>
        /// <param name="displayProperty"></param>
        static public void AddDisplayProperty(DisplayProperty displayProperty)
        {
            DisplayPropertyDatabaseAccess.AddProperty(displayProperty);
        }

        /// <summary>
        /// Delete Display Property
        /// </summary>
        /// <param name="guid"></param>
        static public void DeleteDisplayProperty(string guid)
        {
            DisplayPropertyDatabaseAccess.DeleteDisplayProperty(guid);
        }
    }
}
