using System;
using Inspire.Server.Proxy.DisplayAdminServiceReference1;

namespace Inspire.Server.Proxy
{
    /// <summary>
    /// Display Admin
    /// </summary>
    public class DisplayAdmin
    {
        /// <summary>
        /// Update Displays
        /// </summary>
        public static void UpdateDisplays()
        {
            try
            {
                DisplayAdminServiceContractClient client = new DisplayAdminServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetDisplayAdminEndpoint();
                client.UpdateDisplays();
            }
             catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while updating displays");
            }
        }

    }
}
