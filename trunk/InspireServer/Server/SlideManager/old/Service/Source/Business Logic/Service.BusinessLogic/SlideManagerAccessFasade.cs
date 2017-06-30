using Inspire.Server.SlideManager.DataContracts;
using Inspire.Server.SlideManager.DataAccess;


namespace Inspire.Server.SlideManager.BusinessLogic
{
    /// <summary>
    /// Slide Manager Access Fasade
    /// </summary>
    public class SlideManagerAccessFasade
    {
        /// <summary>
        /// Get All Slides
        /// </summary>
        /// <returns></returns>
      static public Slides GetAllSlides()
        {
          Slides slides = SlideDataAccess.GetAllSlides();
          return slides;
        }

        /// <summary>
        /// Get Slide
        /// </summary>
        /// <param name="slideID"></param>
        /// <returns></returns>
      static public Slide GetSlide(string slideID)
          {
              Slide slide = SlideDataAccess.GetSlide(slideID);
              return slide;
          }

        /// <summary>
        /// Add Slide
        /// </summary>
        /// <param name="slide"></param>
      static public void AddSlide(Slide slide)
        {
             SlideDataAccess.AddSlide(slide);
        }

        /// <summary>
        /// Update Slide
        /// </summary>
        /// <param name="slide"></param>
      static public void UpdateSlide(Slide slide)
         {
             //SlideDataAccess.UpdateSlide(slide);
         }

        /// <summary>
        /// Delete Slide
        /// </summary>
        /// <param name="slideID"></param>
      static public void DeleteSlide(string slideID)
        {
            SlideDataAccess.DeleteSlide(slideID);
        }

        /// <summary>
        /// Get Slide File
        /// </summary>
        /// <param name="slideID"></param>
        /// <returns></returns>
      static public SlideFile GetSlideFile(string slideID)
      {
          SlideFile slidesFile = SlideFileDataAccess.GetSlideFile(slideID);
          return slidesFile;
      }

        /// <summary>
        /// Add Slide File
        /// </summary>
        /// <param name="slideFile"></param>
      static public void AddSlideFile(SlideFile slideFile)
      {
          SlideFileDataAccess.AddSlideFile(slideFile);
      }

        /// <summary>
        /// Update Slide File
        /// </summary>
        /// <param name="slideFile"></param>
      static public void UpdateSlideFile(SlideFile slideFile)
      {
          SlideFileDataAccess.UpdateSlideFile(slideFile);
      }

        /// <summary>
        /// Delete Slide File
        /// </summary>
        /// <param name="slideFileID"></param>
      static public void DeleteSlideFile(string slideFileID)
      {
          SlideFileDataAccess.DeleteSlideFile(slideFileID);
      }

     
        
        
      //  /// <summary>
      ///// Add TouchScreenButton
      ///// </summary>
      ///// <param name="slideFile"></param>
      //static public void AddTouchScreenButton(TouchScreenButton button)
      //{
      //    ButtonDataAccess.AddButton(button);
      //}

      ///// <summary>
      ///// Delete TouchScreenButton
      ///// </summary>
      ///// <param name="slideFileID"></param>
      //static public void DeleteTouchScreenButton(string buttonID)
      //{
      //    ButtonDataAccess.DeleteButton(buttonID);
      //}

    }
}
