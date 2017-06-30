using System;
using System.Collections.Generic;
using Inspire.Events.Proxy.RoomsService;

namespace Inspire.Events.Proxy
{
    /// <summary>
    /// Aliase Proxy
    /// </summary>
    public class AliaseProxy
    {
        /// <summary>
        /// Get Aliases
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>
        static public List<Alias> GetAliases(string roomID)
        {
            var aliases = new List<Inspire.Events.Proxy.Alias>();

            try
            {
                RoomsServiceContractClient client = new RoomsServiceContractClient();
                Inspire.Events.Proxy.RoomsService.Aliases proxyAliases = client.GetAliases(roomID);
                client.Endpoint.Address = SeverSettings.GetAliasEndpoint();

                var alias = new Inspire.Events.Proxy.Alias();
                

                foreach (Inspire.Events.Proxy.RoomsService.Alias item in proxyAliases)
                {
                    alias = ProxyAliasToAlias(item);
                    aliases.Add(alias);
                }
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting aliases");
            }

            return aliases;

        }//end function

        /// <summary>
        /// Add Alias
        /// </summary>
        /// <param name="alias"></param>
        static public void AddAlias(Alias alias)
        {
            try
            {
                var proxyAlias = new Inspire.Events.Proxy.RoomsService.Alias();
                proxyAlias = AliasToAliasProxy(alias);
                
                RoomsServiceContractClient client = new RoomsServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetAliasEndpoint();
                client.AddAlias(proxyAlias);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while adding an alias");
            }

            
        }//end function

        /// <summary>
        /// Delete Alias
        /// </summary>
        /// <param name="aliasID"></param>
        static public void DeleteAlias(string aliasID)
        {
            try
            {
                 RoomsServiceContractClient client = new RoomsServiceContractClient();
                 client.Endpoint.Address = SeverSettings.GetAliasEndpoint();
                 client.DeleteAlias(aliasID);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while deleting an alias");
            }
            
        }//end function


        /// <summary>
        /// Alias To Alias Proxy
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static Inspire.Events.Proxy.RoomsService.Alias AliasToAliasProxy(Inspire.Events.Proxy.Alias from)
        {
            var to = new Inspire.Events.Proxy.RoomsService.Alias();

            to.GUID = from.Guid;
            to.RoomID = from.RoomID;
            to.Value = from.Value;

            return to;
        }

        /// <summary>
        /// Proxy Alias To Alias
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static Inspire.Events.Proxy.Alias ProxyAliasToAlias(Inspire.Events.Proxy.RoomsService.Alias from)
        {
            var to = new Inspire.Events.Proxy.Alias();

            to.Guid = from.GUID;
            to.RoomID = from.RoomID;
            to.Value = from.Value;

            return to;
        }

        /// <summary>
        /// Proxy Aliases To Aliases
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static List<Inspire.Events.Proxy.Alias> ProxyAliasesToAliases(Inspire.Events.Proxy.RoomsService.Aliases from)
        {
            var to = new List<Inspire.Events.Proxy.Alias>();
            var alias = new Inspire.Events.Proxy.Alias();

            foreach (Inspire.Events.Proxy.RoomsService.Alias item in from)
            {
                alias = ProxyAliasToAlias(item);
                to.Add(alias);
            }

            return to;
        }

        /// <summary>
        /// Aliases To Proxy Aliases
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static Inspire.Events.Proxy.RoomsService.Aliases AliasesToProxyAliases(List<Inspire.Events.Proxy.Alias> from)
        {

            var to = new Inspire.Events.Proxy.RoomsService.Aliases();
            var alias = new Inspire.Events.Proxy.RoomsService.Alias();

            foreach (Inspire.Events.Proxy.Alias item in from)
            {
                alias = AliasToAliasProxy(item);
                to.Add(alias);
            }

            return to;
        }
    }
}
