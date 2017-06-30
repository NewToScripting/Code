using System.Collections.Generic;
using Inspire.Server.DisplayAdmin.

namespace Inspire.Server.DisplayAdmin.BusinessLogic
{
    public class ResourceAccess
    {

        /// <summary>
        ///  Check for change and update all displays
        /// </summary>
        static public void CheckAndUpdateDisplays()
        {
            if (DisplayDatabaseAccess.CheckForLastUpdate())
            {
                List<string> hostNames = DisplayDatabaseAccess.GetDisplayHostNames();
                DisplaysProxy.UpdateDisplays(hostNames);
            }
        }

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
        static public void PingDisplays()
        {
            List<string> hostNames = DisplayDatabaseAccess.GetDisplayHostNames();
            DisplaysProxy.PingDisplays(hostNames);
        }


    }
}