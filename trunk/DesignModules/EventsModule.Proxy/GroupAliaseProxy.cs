using System;
using System.Collections.Generic;
using Inspire.Events.Proxy.GroupsReference;

namespace Inspire.Events.Proxy
{
    /// <summary>
    /// Aliase Proxy
    /// </summary>
    public class GroupAliaseProxy
    {
        /// <summary>
        /// Get Aliases
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>
        static public List<GroupAlias> GetAliases(string roomID)
        {
            var aliases = new List<Inspire.Events.Proxy.GroupAlias>();

            try
            {
                GroupsServiceContractClient client = new GroupsServiceContractClient();
                Inspire.Events.Proxy.GroupsReference.GroupAliases proxyAliases = client.GetAliases(roomID);

                client.Endpoint.Address = SeverSettings.GetGroupEndpoint();

                var alias = new Inspire.Events.Proxy.GroupAlias();
                

                foreach (Inspire.Events.Proxy.GroupsReference.GroupAlias item in proxyAliases)
                {
                    alias = ProxyAliasToAlias(item);
                    aliases.Add(alias);
                }
            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while getting aliases");
            }

            return aliases;

        }//end function

        /// <summary>
        /// Add Alias
        /// </summary>
        /// <param name="alias"></param>
        static public void AddAlias(GroupAlias alias)
        {
            try
            {
                var proxyAlias = new Inspire.Events.Proxy.GroupsReference.GroupAlias();

                proxyAlias = AliasToAliasProxy(alias);
                
                GroupsServiceContractClient client = new GroupsServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetGroupEndpoint();
                client.AddAlias(proxyAlias);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while adding an alias");
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
                 GroupsServiceContractClient client = new GroupsServiceContractClient();
                 client.Endpoint.Address = SeverSettings.GetGroupEndpoint();
                 client.DeleteAlias(aliasID);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while deleting an alias");
            }
            
        }//end function


        /// <summary>
        /// Alias To Alias Proxy
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>

        private static Inspire.Events.Proxy.GroupsReference.GroupAlias AliasToAliasProxy(Inspire.Events.Proxy.GroupAlias from)
        {
            var to = new Inspire.Events.Proxy.GroupsReference.GroupAlias();

            to.GUID = from.Guid;
            to.GroupID = from.GroupID;
            to.Value = from.Value;

            return to;
        }

        /// <summary>
        /// Proxy Alias To Alias
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static Inspire.Events.Proxy.GroupAlias ProxyAliasToAlias(Inspire.Events.Proxy.GroupsReference.GroupAlias from)
        {
            var to = new Inspire.Events.Proxy.GroupAlias();

            to.Guid = from.GUID;
            to.GroupID = from.GroupID;
            to.Value = from.Value;

            return to;
        }

        /// <summary>
        /// Proxy Aliases To Aliases
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static List<Inspire.Events.Proxy.GroupAlias> ProxyAliasesToAliases(Inspire.Events.Proxy.GroupsReference.GroupAliases from)
        {
            var to = new List<Inspire.Events.Proxy.GroupAlias>();
            var alias = new Inspire.Events.Proxy.GroupAlias();

            foreach (Inspire.Events.Proxy.GroupsReference.GroupAlias item in from)
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
        public static Inspire.Events.Proxy.GroupsReference.GroupAliases AliasesToProxyAliases(List<Inspire.Events.Proxy.GroupAlias> from)
        {
            var to = new Inspire.Events.Proxy.GroupsReference.GroupAliases();
            var alias = new Inspire.Events.Proxy.GroupsReference.GroupAlias();

            foreach (Inspire.Events.Proxy.GroupAlias item in from)
            {
                alias = AliasToAliasProxy(item);
                to.Add(alias);
            }

            return to;
        }
    }
}
