using System;
using Inspire.Server.Console.Interface.DisplayServiceReference;

namespace Inspire.Server.Console.Interface
{
    public class DisplayProxy
    {
        /// <summary>
        /// Get All Displays
        /// </summary>
        /// <returns></returns>
        public static Displays GetDisplays()
        {
            try
            {
                ClientDisplayServiceContractClient client = new ClientDisplayServiceContractClient();
                return client.GetAllDisplays();
            }
            catch (Exception)
            {

                return null;
            }
        }
     }
}
