using System.Collections.Generic;
using Inspire.Server.DisplayAdmin.DataAccess;

namespace Inspire.Server.DisplayAdmin.BusinessLogic
{
    public class ResourceAccess
    {

       /// <summary>
        /// Update All Displays
        /// </summary>
        static public void UpdateDisplays()
        {
            List<string> hostNames = DisplayDatabaseAccess.GetDisplayHostNames();
            DisplaysProxy.UpdateDisplays(hostNames);
        }

        /// <summary>
        /// Ping All Displays
        /// </summary>
        static public void CheckDisplayStatus()
        {
            DisplayDatabaseAccess.UpdateDisplayActiveFlag();
        }


    }
}