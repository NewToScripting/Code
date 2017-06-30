using System;
using Inspire.Server.Images.DataContracts;
using Inspire.Server.Images.DataAccess;

namespace Inspire.Server.Images.BusinessLogic
{
    /// <summary>
    /// Resouce Access Fasade
    /// </summary>
    public class ResouceAccessFasade
    {
         /// <summary>
        /// Directional Images
        /// </summary>
        /// <returns></returns>
        static public EventImages GetDirectionalImages(int type)
        {
            return ImagesDataAccess.GetDirectionalImages(type);
        }

        /// <summary>
        /// Add Directional Image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        static public string AddDirectionalImage(EventImage image, Byte[] file)
        {
            return ImagesDataAccess.AddDirectionalImage(image, file);
        }

        /// <summary>
        /// Delete Directional Image
        /// </summary>
        /// <param name="image"></param>
        static public void DeleteDirectionalImage(EventImage image)
        {
            ImagesDataAccess.DeleteDirectionalImage(image);
        }


    }
}
