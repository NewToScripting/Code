using System;
using System.Collections.Generic;
using Inspire.Events.Proxy.GroupsReference;

namespace Inspire.Events.Proxy
{
    /// <summary>
    /// Group Proxy
    /// </summary>
    public class GroupProxy
    {
        /// <summary>
        /// Get Rooms
        /// </summary>
        /// <returns></returns>
        static public List<Group> GetGroups()
        {
            var groups = new List<Inspire.Events.Proxy.Group>();

            try
            {
                GroupsServiceContractClient client = new GroupsServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetGroupEndpoint();

                var proxyRooms = new Inspire.Events.Proxy.GroupsReference.Groups();
                var group = new Inspire.Events.Proxy.Group();
                
                proxyRooms = client.GetGroups();

                foreach (Inspire.Events.Proxy.GroupsReference.Group item in proxyRooms)
                {
                    group = proxyRoomToRoom(item);
                    groups.Add(group);
                }
            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while getting rooms");
            }

            return groups;

        }//end function

      
        /// <summary>
        /// Add Room
        /// </summary>
        /// <param name="room"></param>
        static public void AddGroup(Group group)
        {
            try
            {
                GroupsServiceContractClient client = new GroupsServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetGroupEndpoint();

                var proxyGroup = new Inspire.Events.Proxy.GroupsReference.Group();
                proxyGroup = GroupToProxyGroup(group);

                client.AddGroup(proxyGroup);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while adding rooms");
            }

        }//end function


        /// <summary>
        /// Add Room
        /// </summary>
        /// <param name="room"></param>
        static public void UpdateGroup(Group group)
        {
            try
            {
                GroupsServiceContractClient client = new GroupsServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetGroupEndpoint();

                var proxyGroup = new Inspire.Events.Proxy.GroupsReference.Group();
                proxyGroup = GroupToProxyGroup(group);

                client.UpdateGroup(proxyGroup);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while updateing rooms");
            }

        }//end function
      
        /// <summary>
         /// Delete Room
        /// </summary>
        /// <param name="roomID"></param>
        static public void DeleteGroup(string groupID)
        {
            try
            {
                GroupsServiceContractClient client = new GroupsServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetGroupEndpoint();
                client.DeleteGroup(groupID);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while deleting room");
            }
        }

        /// <summary>
        /// Room To Proxy Room
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static Inspire.Events.Proxy.GroupsReference.Group GroupToProxyGroup(Inspire.Events.Proxy.Group from)
        {
            var to = new Inspire.Events.Proxy.GroupsReference.Group();


            to.GroupAliases = GroupAliaseProxy.AliasesToProxyAliases(from.Aliases);

            to.GUID = from.Guid;
            to.Name = from.Name;
            to.GroupImageWebPath = from.GroupImageWebPath;
            to.ImageID = from.GroupImageID;
            
            return to;
        }

        /// <summary>
        /// proxy Room To Room
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static Inspire.Events.Proxy.Group proxyRoomToRoom(Inspire.Events.Proxy.GroupsReference.Group from)
        {
            var to = new Inspire.Events.Proxy.Group();

            to.Aliases = GroupAliaseProxy.ProxyAliasesToAliases(from.GroupAliases);

            to.Guid = from.GUID;
            to.Name = from.Name;
            to.GroupImageWebPath = from.GroupImageWebPath;
            to.GroupImageID = from.ImageID;
            
            return to;
        }
    }
}
