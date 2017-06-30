using System;
using Inspire.Server.Direction.DataContracts;
using Inspire.Server.Direction.DataAccess;

namespace Inspire.Server.Direction.BusinessLogic
{
    /// <summary>
    /// Resouce Access Fasade
    /// </summary>
    public class ResouceAccessFasade
    {
        /// <summary>
        /// Get Directions
        /// </summary>
        /// <param name="DisplayID"></param>
        /// <returns></returns>
        static public Directions GetDirections(string DisplayID)
        {
            return DirectionDataAccess.GetDirections(DisplayID);
        }
        
        /// <summary>
        /// Add Directions
        /// </summary>
        /// <param name="directions"></param>
        static public void AddDirections(Directions directions)
        {
            DirectionDataAccess.AddDirections(directions);
        }

        /// <summary>
        /// Delete Directions
        /// </summary>
        /// <param name="displayID"></param>
        static public void DeleteDirections(string displayID)
        {
            DirectionDataAccess.DeleteDirections(displayID);
        }

    }
}
