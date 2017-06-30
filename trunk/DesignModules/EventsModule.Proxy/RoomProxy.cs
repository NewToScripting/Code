using System;
using System.Collections.Generic;
using Inspire.Events.Proxy.RoomsService;

namespace Inspire.Events.Proxy
{
    /// <summary>
    /// Room Proxy
    /// </summary>
    public class RoomProxy
    {
        /// <summary>
        /// Get Rooms
        /// </summary>
        /// <returns></returns>
        static public List<Room> GetRooms()
        {
            var rooms = new List<Inspire.Events.Proxy.Room>();

            try
            {
                RoomsServiceContractClient client = new RoomsServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetRoomsEndpoint();

                var proxyRooms = new Inspire.Events.Proxy.RoomsService.Rooms();
                var room = new Inspire.Events.Proxy.Room();
                
                proxyRooms = client.GetRooms();

                foreach (Inspire.Events.Proxy.RoomsService.Room item in proxyRooms)
                {
                    room = proxyRoomToRoom(item);
                    rooms.Add(room);
                }
            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while getting rooms");
            }

            return rooms;

        }//end function

        /// <summary>
        /// Get Rooms For Display
        /// </summary>
        /// <param name="displayID"></param>
        /// <returns></returns>
        static public List<Room> GetRoomsForDisplay(string displayID)
        { 
            var rooms = new List<Inspire.Events.Proxy.Room>();

            try
            {
               RoomsServiceContractClient client = new RoomsServiceContractClient();
               client.Endpoint.Address = SeverSettings.GetRoomsEndpoint();
               var proxyRooms = new Inspire.Events.Proxy.RoomsService.Rooms();
               var room = new Inspire.Events.Proxy.Room();
               
                proxyRooms = client.GetRoomsFromDisplayID(displayID);

                foreach (Inspire.Events.Proxy.RoomsService.Room item in proxyRooms)
                {
                    room = proxyRoomToRoom(item);
                    rooms.Add(room);
                }
            }

            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while getting rooms for display");
            }
            
            return rooms;
       
        }//end function

        /// <summary>
        /// Add Room
        /// </summary>
        /// <param name="room"></param>
        static public void AddRoom(Room room)
        {
            try
            {
                RoomsServiceContractClient client = new RoomsServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetRoomsEndpoint();

                var proxyRoom = new Inspire.Events.Proxy.RoomsService.Room();
                proxyRoom = RoomToProxyRoom(room);

                client.AddRoom(proxyRoom);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while adding rooms");
            }

        }//end function

        /// <summary>
        /// Add Room To DisplayAssn
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="displayID"></param>
         static public void AddRoomToDisplayAssn(string roomID, string displayID)
        {
             try
             {
                RoomsServiceContractClient client = new RoomsServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetRoomsEndpoint();
                client.AddRoomToDisplayAssn(displayID, roomID);

             }
             catch (Exception e)
             {
                 ProxyErrorHandler.LogError(e, "Error occured while adding room to display assn");
             }
            
        }//end function

        /// <summary>
         /// Delete Room To DisplayAssn
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="displayID"></param>
         static public void DeleteRoomToDisplayAssn(string roomID, string displayID)
         {
             try
             {
                 RoomsServiceContractClient client = new RoomsServiceContractClient();
                 client.Endpoint.Address = SeverSettings.GetRoomsEndpoint();
                 client.DeleteRoomToDisplayAssn(displayID, roomID);
             }
             catch (Exception e)
             {
                 ProxyErrorHandler.LogError(e, "Error occured while deleting room to display assn");
             }
         }  
        
        /// <summary>
         /// Delete Room
        /// </summary>
        /// <param name="roomID"></param>
        static public void DeleteRoom(string roomID)
        {
            try
            {
                RoomsServiceContractClient client = new RoomsServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetRoomsEndpoint();
                client.DeleteRoom(roomID);
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
        private static Inspire.Events.Proxy.RoomsService.Room RoomToProxyRoom(Inspire.Events.Proxy.Room from)
        {
            var to = new Inspire.Events.Proxy.RoomsService.Room();


            to.RoomAliases = RoomAliaseProxy.AliasesToProxyAliases(from.Aliases);

            to.GUID = from.Guid;
            to.Name = from.Name;

            return to;
        }

        /// <summary>
        /// proxy Room To Room
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static Inspire.Events.Proxy.Room proxyRoomToRoom(Inspire.Events.Proxy.RoomsService.Room from)
        {
            var to = new Inspire.Events.Proxy.Room();

           to.Aliases = RoomAliaseProxy.ProxyAliasesToAliases(from.RoomAliases);
           to.Guid = from.GUID;
           to.Name = from.Name;

            return to;
        }
    }
}
