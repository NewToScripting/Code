using System;
using System.Collections.Generic;
using Inspire.Events.Proxy.ImageReference;

namespace Inspire.Events.Proxy
{
    /// <summary>
    /// Direction Proxy
    /// </summary>
    public class EventImagesProxy
    {
        /// <summary>
        /// Get Directional Images
        /// </summary>
        /// <returns></returns>
         static public List<EventImage> GetEventImages( EventImageType type)
         {
             var directionalImages = new List<EventImage>();

            try
            { 
                 ImageServiceContractClient client = new ImageServiceContractClient();
                 client.Endpoint.Address = SeverSettings.GetEventImageEndpoint();

                 Inspire.Events.Proxy.ImageReference.EventImages proxyImages = client.GetImages((int)type);

                 foreach (Inspire.Events.Proxy.ImageReference.EventImage item in proxyImages)
                 {
                     EventImage directionalImage = ProxyDirectionToDirectionImage(item);
                     directionalImages.Add(directionalImage);
                 }

            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while deleting event images");
            }
            
             return directionalImages;

         }//end function
        
        /// <summary>
         /// Add Directional Image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        static public string AddEventImage(EventImage image, Byte[] file)
        {
            string webPath = "";

            try
            {   
                var directionalImage = DirectionImageToProxyImage(image);
                ImageServiceContractClient client = new ImageServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetEventImageEndpoint();

                webPath = client.AddImage(directionalImage, file);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while adding event image");
            }
            
            return webPath; 

        }//end function

        /// <summary>
        /// Delete Directional Image
        /// </summary>
        /// <param name="image"></param>
        static public void DeleteEventImage(EventImage image)
        {
            try
            {
                var eventImage = DirectionImageToProxyImage(image);

                ImageServiceContractClient client = new ImageServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetEventImageEndpoint();

                client.DeleteImage(eventImage);      
            }
            catch (Exception e)
            {
                ProxyErrorHandler.LogError(e, "Error occured while deleting event image");
            }
            
            
        }//end function

    
        /// <summary>
        /// Proxy Direction To Direction Image
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static EventImage ProxyDirectionToDirectionImage(ImageReference.EventImage from)
        {
            var to = new EventImage();

            to.Description = from.Description;
            to.WebPath = from.WebPath;
            to.Guid = from.GUID;
            to.FileExtention = from.FileExtension;
            if (from.Type != null)
            {
                to.Type = (EventImageType)from.Type;
            }
            

            return to;
        }

        /// <summary>
        /// Event Image To Proxy Image
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static ImageReference.EventImage DirectionImageToProxyImage(EventImage from)
        {
            var to = new ImageReference.EventImage();

            to.Description = from.Description;
            to.WebPath = from.WebPath;
            to.GUID = from.Guid;
            to.FileExtension = from.FileExtention;
            to.Type = (int)from.Type;
            return to;
        }
    }
}
