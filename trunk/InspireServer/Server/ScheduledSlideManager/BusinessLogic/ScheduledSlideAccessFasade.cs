using Inspire.Server.ScheduledSlideManager.DataAccess;
using Inspire.Server.ScheduledSlideManager.DataContracts;
using Inspire.Server.Common.DataContracts;



namespace Inspire.Server.ScheduledSlideManager.BusinessLogic
{
    /// <summary>
    /// Scheduled Slide Access Fasade
    /// </summary>
    public class ScheduledSlideAccessFasade
    {
        /// <summary>
        /// Get Scheduled Slides
        /// </summary>
        /// <param name="scheduleID"></param>
        /// <returns></returns>
        static public ScheduledSlides GetScheduledSlides(string scheduleID)
        {
            ScheduledSlides slides = new ScheduledSlides();
            slides = ScheduledSlideDatabaseAccess.GetScheduledSlides(scheduleID);
            return slides;
            
        }

        /// <summary>
        /// Get Scheduled Slides
        /// </summary>
        /// <param name="scheduleID"></param>
        /// <returns></returns>
        static public ScheduledSlides GetScheduledSlidesNoThumb(string scheduleID)
        {
            ScheduledSlides slides = new ScheduledSlides();
            slides = ScheduledSlideDatabaseAccess.GetScheduledSlidesNoThumb(scheduleID);
            return slides;

        }

        /// <summary>
        /// Add Scheduled Slide
        /// </summary>
        /// <param name="slide"></param>
        static public void AddScheduledSlide(ScheduledSlide slide)
        {
            ScheduledSlideDatabaseAccess.AddScheduledSlide(slide);
        }
        
        /// <summary>
        /// Updates Scheduled Slide
        /// </summary>
        /// <param name="slides"></param>
        /// <param name="scheduleID"></param>
        static public void UpdatesScheduledSlide(ScheduledSlides slides, string scheduleID)
        {
            ScheduledSlideDatabaseAccess.UpdateSlides(slides, scheduleID);
        }

        /// <summary>
        /// Delete Scheduled Slide
        /// </summary>
        /// <param name="slideID"></param>
        static public void DeleteScheduledSlide(string slideID)
        {
           ScheduledSlideDatabaseAccess.DeleteSlide(slideID);
        }

        /// <summary>
        /// Is Slide Scheduled
        /// </summary>
        /// <param name="slideID"></param>
        /// <returns></returns>
        static public bool IsSlideScheduled(string slideID)
        {
            int isScheduled = ScheduledSlideDatabaseAccess.IsSlideScheduled(slideID);

            if (isScheduled > 0) return true;
            return false;

        }

        /// <summary>
        /// Update Original Slide Ids
        /// </summary>
        /// <param name="originalSlideID"></param>
        /// <param name="newSlideID"></param>
        static public void UpdateOriginalSlideIds(string originalSlideID, string newSlideID, bool deleteExistingSlide)
        {
            ScheduledSlideDatabaseAccess.UpdateOriginalSlideIds(originalSlideID, newSlideID, deleteExistingSlide);
        }


        /// <summary>
        /// Add Scheduled Slide
        /// </summary>
        /// <param name="slide"></param>
        static public void AddButtonNavagation(Button slide)
        {
            SlideButtonDataAccess.AddButtonNavagation(slide);
        }

        /// <summary>
        /// Delete Scheduled Slide
        /// </summary>
        /// <param name="slideID"></param>
        static public void DeleteButtonNavagation(string slideID)
        {
            SlideButtonDataAccess.DeleteButtonNavagation(slideID);
        }



    }
}
