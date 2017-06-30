using System;
using System.Collections.Generic;
using Inspire.Events.Proxy.DirectionReference;

namespace Inspire.Events.Proxy
{
    /// <summary>
    /// Direction Proxy
    /// </summary>
    public class DirectionProxy
    {
        /// <summary>
        /// Get Directions
        /// </summary>
        /// <param name="displayID"></param>
        /// <returns></returns>
        static public List<Direction> GetDirections(string displayID)
        {
            var directions = new List<Direction>();

            try
            {
                DirectionServiceContractClient client = new DirectionServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetDirectionEndpoint();
                Directions proxyDirections = client.GetDirections(displayID);

               foreach(Inspire.Events.Proxy.DirectionReference.Direction item in proxyDirections)
               {
                   Direction direction = ProxyDirectionToDirection(item);
                   directions.Add(direction);
               }

            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting directions");
            }
           
           return directions;

        }//end function

       /// <summary>
       /// Add Directions
       /// </summary>
       /// <param name="directions"></param>
        static public void AddDirections(List<Direction> directions)
        {
            var proxyDirections = new Directions();

           try
           {
                foreach(Inspire.Events.Proxy.Direction item in directions)
                {
                    DirectionReference.Direction proxyDirection = DirectionToProxyDirection(item);
                    proxyDirections.Add(proxyDirection);
                }

                DirectionServiceContractClient client = new DirectionServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetDirectionEndpoint();
                client.AddDirection(proxyDirections); 
          
           }
           catch (Exception e)
           {
               ProxyErrorHandler.Throw(e, "Error occured while adding directions");
           }

           
        }//end function

        /// <summary>
        /// Delete Directions
        /// </summary>
        /// <param name="displayID"></param>
        static public void DeleteDirections(string displayID)
        {
            try
            {
                DirectionServiceContractClient client = new DirectionServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetDirectionEndpoint();

                client.DeleteDirection(displayID);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while deleting directions");
            }
           
             
        }//end function
        
        /// <summary>
        /// Get Directional Images
        /// </summary>
        /// <returns></returns>
         static public List<DirectionalImage> GetDirectionalImages()
         {
             var directionalImages = new List<DirectionalImage>();

            try
            { 
                 DirectionServiceContractClient client = new DirectionServiceContractClient();
                 client.Endpoint.Address = SeverSettings.GetDirectionEndpoint();

                 Inspire.Events.Proxy.DirectionReference.DirectionalImages proxyImages = client.GetAllImages();

                 foreach(Inspire.Events.Proxy.DirectionReference.DirectionalImage item in proxyImages)
                 {
                     DirectionalImage directionalImage = ProxyDirectionToDirectionImage(item);
                     directionalImages.Add(directionalImage);
                 }

            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while deleting directional images");
            }
            
             return directionalImages;

         }//end function
        
        /// <summary>
         /// Add Directional Image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        static public string AddDirectionalImage(DirectionalImage image, Byte[] file)
        {
            string webPath = "";

            try
            {   
                var directionalImage = DirectionImageToProxyImage(image);
                DirectionServiceContractClient client = new DirectionServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetDirectionEndpoint();

                webPath = client.AddImage(directionalImage, file);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while adding directional images");
            }
            
            return webPath; 

        }//end function

        /// <summary>
        /// Delete Directional Image
        /// </summary>
        /// <param name="image"></param>
        static public void DeleteDirectionalImage(DirectionalImage image)
        {
            try
            {
                var directionalImage = DirectionImageToProxyImage(image);

                DirectionServiceContractClient client = new DirectionServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetDirectionEndpoint();

                client.DeleteImage(directionalImage);      
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while deleting directional images");
            }
            
            
        }//end function

        /// <summary>
        /// Proxy Direction To Direction
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static Direction ProxyDirectionToDirection(DirectionReference.Direction from)
        {
            var to = new Direction();

            to.Description = from.Description;
            to.DirectionImageID = from.DirectionImageID;
            to.DirectionImageWebPath = from.DirectionImageWebPath;
            to.DisplayID = from.DisplayID;
            to.Guid = from.GUID;
            to.RoomID = from.RoomID;
            to.RoomName = from.RoomName;

            return to;
        }

        /// <summary>
        /// Direction To Proxy Direction
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static DirectionReference.Direction DirectionToProxyDirection(Direction from)
        {
            var to = new DirectionReference.Direction();

            to.Description = from.Description;
            to.DirectionImageID = from.DirectionImageID;
            to.DirectionImageWebPath = from.DirectionImageWebPath;
            to.DisplayID = from.DisplayID;
            to.GUID = from.Guid;
            to.RoomID = from.RoomID;
            to.RoomName = from.RoomName;

            return to;
        }

        /// <summary>
        /// Proxy Direction To Direction Image
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static DirectionalImage ProxyDirectionToDirectionImage(DirectionReference.DirectionalImage from)
        {
            var to = new DirectionalImage();

            to.Description = from.Description;
            to.WebPath = from.WebPath;
            to.Guid = from.GUID;
            to.FileExtention = from.FileExtension;

            return to;
        }

        /// <summary>
        /// Direction Image To Proxy Image
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private static DirectionReference.DirectionalImage DirectionImageToProxyImage(DirectionalImage from)
        {
            var to = new DirectionReference.DirectionalImage();

            to.Description = from.Description;
            to.WebPath = from.WebPath;
            to.GUID = from.Guid;
            to.FileExtension = from.FileExtention;

            return to;
        }
    }
}
