using Inspire.Server.Rooms.DataAccess;
using Inspire.Server.Rooms.DataContracts;


namespace Inspire.Server.Rooms.BusinessLogic
{
    /// <summary>
    /// Resource Access Fasade
    /// </summary>
    public class ResouceAccessFasade
    {
        /// <summary>
        /// Get Aliases
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>

        static public RoomAliases GetAliases(string roomID)

        {

            return RoomAliasDatabaseAccess.GetAliases(roomID);

        }

        /// <summary>
        /// Add Alias
        /// </summary>
        /// <param name="alias"></param>

        static public void AddAlias(RoomAlias alias)

        {
            RoomAliasDatabaseAccess.AddAlias(alias);
        }

        /// <summary>
        /// Delete Alias
        /// </summary>
        /// <param name="aliasID"></param>
        static public void DeleteAlias(string aliasID)
        {
            RoomAliasDatabaseAccess.DeleteRoomAlias(aliasID);

        }

        /// <summary>
        /// Get Rooms
        /// </summary>
        /// <returns></returns>
        static public DataContracts.Rooms GetRooms()
        {
            return RoomsDatabaseAccess.GetRooms();
        }


        /// <summary>
        /// Add Room
        /// </summary>
        /// <param name="room"></param>
        static public void AddRoom(Room room)
        {
            RoomsDatabaseAccess.AddRoom(room);
        }



        /// <summary>
        /// Update Room
        /// </summary>
        /// <param name="room"></param>
        static public DataContracts.Rooms GetRoomsForDisplay(string room)
        {
            return RoomsDatabaseAccess.GetRoomsForDisplay(room);
        }

        
        /// <summary>
        /// AddRoomToDisplayAssn
        /// </summary>
        /// <param name="room"></param>
        static public void AddRoomToDisplayAssn(string roomID, string displayID)       
        {
            RoomsDatabaseAccess.AddRoomToDisplayAssn(roomID, displayID);
        }


        /// <summary>
        /// DeleteRoomToDisplayAssn
        /// </summary>
        /// <param name="room"></param>
        static public void DeleteRoomToDisplayAssn(string roomID, string displayID)
        {
            RoomsDatabaseAccess.DeleteRoomToDisplayAssn(roomID, displayID);
        }

        /// <summary>
        /// Delete Room
        /// </summary>
        /// <param name="roomID"></param>
        static public void DeleteRoom(string roomID)
        {
            RoomsDatabaseAccess.DeleteRoom(roomID);
        }



    }
}