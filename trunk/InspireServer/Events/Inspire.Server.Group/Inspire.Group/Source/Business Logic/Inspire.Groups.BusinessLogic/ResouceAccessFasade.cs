using Inspire.Server.Groups.DataAccess;
using Inspire.Server.Groups.DataContracts;


namespace Inspire.Server.Groups.BusinessLogic
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

        static public GroupAliases GetAliases(string roomID)
     
        {

            return GroupAliasDatabaseAccess.GetAliases(roomID);

        }

        /// <summary>
        /// Add Alias
        /// </summary>
        /// <param name="alias"></param>

        static public void AddAlias(GroupAlias alias)

        {
            GroupAliasDatabaseAccess.AddAlias(alias);
                    }

        /// <summary>
        /// Delete Alias
        /// </summary>
        /// <param name="aliasID"></param>
        static public void DeleteAlias(string aliasID)
        {
            GroupAliasDatabaseAccess.DeleteGroupAlias(aliasID);

        }

        /// <summary>
        /// Get Rooms
        /// </summary>
        /// <returns></returns>
        static public DataContracts.Groups GetGroups()
        {
            return GroupsDatabaseAccess.GetGroups();
        }

       
        /// <summary>
        /// Add Room
        /// </summary>
        /// <param name="room"></param>
        static public void AddGroup(Group room)
        {
            GroupsDatabaseAccess.AddGroup(room);
        }



        /// <summary>
        /// Update Room
        /// </summary>
        /// <param name="room"></param>
        static public void UpdateGroup(Group room)
        {
            GroupsDatabaseAccess.UpdateGroup(room);
        }
    
        /// <summary>
        /// Delete Room
        /// </summary>
        /// <param name="roomID"></param>
        static public void DeleteGroup(string roomID)
        {
            GroupsDatabaseAccess.DeleteGroup(roomID);
        }



    }
}