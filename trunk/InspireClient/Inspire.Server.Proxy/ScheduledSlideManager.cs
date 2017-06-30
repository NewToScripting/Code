using System;
using System.Collections.Generic;
using Inspire.Server.Proxy.ScheduledSlideServiceReference;

namespace Inspire.Server.Proxy
{
    /// <summary>
    /// Scheduled Slide Manager
    /// </summary>
    public class ScheduledSlideManager
    {
        /// <summary>
        /// Get Scheduled Slides
        /// </summary>
        /// <param name="scheduleID"></param>
        /// <returns></returns>
        static public List<Inspire.ScheduledSlide> GetScheduledSlides(string scheduleID)
        {
            List<Inspire.ScheduledSlide> slides = new List<Inspire.ScheduledSlide>();
            try
            {
                var client = new ScheduledSlideManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetScheduledSlideEndpoint();
                Inspire.Server.Proxy.ScheduledSlideServiceReference.ScheduledSlides proxySlides = client.GetScheduledSlides(scheduleID);

                foreach (Inspire.Server.Proxy.ScheduledSlideServiceReference.ScheduledSlide item in proxySlides)
                    {
                        Inspire.ScheduledSlide newSlide = ScheduledSlideTranslators.CommonScheduledSlideOut(item);
                        slides.Add(newSlide);
                    }
            }//try
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting scheduled slides");
            }
            
            return slides;
        }
        
        /// <summary>
        /// Add Scheduled Slide
        /// </summary>
        /// <param name="slide"></param>
        static public void AddScheduledSlide(Inspire.ScheduledSlide slide)
        {
            try
            {
                var client = new ScheduledSlideManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetScheduledSlideEndpoint();
                client.AddScheduledSlide(ScheduledSlideTranslators.ProxyScheduledSlideOut(slide));
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while adding scheduled slide");
            }
          
        }

       /// <summary>
        /// Update Scheduled Slides
       /// </summary>
       /// <param name="slides"></param>
       /// <param name="scheduleID"></param>
        static public void UpdateScheduledSlides(List<Inspire.ScheduledSlide> slides, string scheduleID)
        {
            try
           {
                var client = new ScheduledSlideManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetScheduledSlideEndpoint();
                var proxyslides = new Inspire.Server.Proxy.ScheduledSlideServiceReference.ScheduledSlides();

               if (slides != null)
                   foreach (ScheduledSlide item in slides)
                   {
                       Inspire.Server.Proxy.ScheduledSlideServiceReference.ScheduledSlide proxyslide = ScheduledSlideTranslators.ProxyScheduledSlideOut(item);
                       proxyslides.Add(proxyslide); 
                   }

               client.UpdateScheduleSlides(scheduleID, proxyslides);
           }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while updating scheduled slide");
            }
      
        }
        
        /// <summary>
        /// Delete Scheduled Slide
        /// </summary>
        /// <param name="scheduledslideID"></param>
        static public void DeleteScheduledSlide(string scheduledslideID)
        {
            try
            {
                var client = new ScheduledSlideManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetScheduledSlideEndpoint();
                client.DeleteScheduledSlide(scheduledslideID);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while deleting scheduled slide");
            }
            
        }
        
        /// <summary>
        /// Is Slide Scheduled
        /// </summary>
        /// <param name="slideID"></param>
        /// <returns></returns>
        static public bool IsSlideScheduled(string slideID)
        { 
            bool isScheduled = false;

            try
            {
                var client = new ScheduledSlideManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetScheduledSlideEndpoint();
                isScheduled = client.IsSlideScheduled(slideID);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while checking scheduled slide status");
            }
            
            return isScheduled;
        }

        /// <summary>
        /// Update Original SlideIds
        /// </summary>
        /// <param name="newSlideID"></param>
        /// <param name="originalSlideID"></param>
        static public void UpdateOriginalSlideIds(string newSlideID, string originalSlideID, bool deleteOriginalSlide)
        {
            try
            {
                var client = new ScheduledSlideManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetScheduledSlideEndpoint();
                client.UpdateOriginalSlideIds(true, newSlideID, originalSlideID);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while updating original slide ID");
            }

            
        }
    }
}
