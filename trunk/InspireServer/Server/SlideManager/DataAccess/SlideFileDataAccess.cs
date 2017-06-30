using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Inspire.Server.SlideManager.DataContracts;
using Inspire.Server.Common;
using System.IO;
using System.Collections.Generic;


namespace Inspire.Server.SlideManager.DataAccess
{
    public class SlideFileDataAccess
    {
        /// <summary>
        /// Get Slide File
        /// </summary>
        /// <param name="slideID"></param>
        /// <returns></returns>
        static public SlideFile GetSlideFile(string fileName)
        {
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["SlideDirectory"] + fileName + ".zip";
            
            SlideFile slideFile = new SlideFile();      

            slideFile.File = SlideFolderAccess.GetSlideFile(filePath);
            slideFile.GUID = fileName;
         
            return slideFile;

        }//end function

        /// <summary>
        /// Add Slide File
        /// </summary>
        /// <param name="slideFile"></param>
        static public void AddSlideFile(SlideFile slideFile)
        {
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["SlideDirectory"] + slideFile.GUID + ".zip";


            SlideFolderAccess.AddSlideFile(slideFile.File, filePath);
        }//end function

        static public void UpdateSlideFile(SlideFile slideFile)
        {
            try
            {
                DeleteSlideFile(slideFile.GUID);
                AddSlideFile(slideFile);

            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error updating Slide on database.");
            }
            
        }//end function

        /// <summary>
        /// Delete Slide File
        /// </summary>
        /// <param name="slideID"></param>
        static public void DeleteSlideFile(string slideID)
        {
            try
            {

                string filePath = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["SlideDirectory"] + slideID + ".zip";

                File.Delete(filePath);
               
               
            }//try
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error removing Slide from database.");
            }

            //DeleteUnusedSlides();
           
            

        }//end function

       ///// <summary>
       ///// 
       ///// </summary>
       ///// <param name="folderName"></param>
       // static private void DeleteUnusedSlides()
       // {           
           
       //     try
       //     {
       //         string slideFolderName = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["SlideDirectory"]; 
       //         List<string> slideIds = new List<string>();

       //         Slides slides = SlideDataAccess.GetAllSlides();                
              
       //         foreach (Slide slide in slides)
       //         {
       //             slideIds.Add(slideFolderName + slide.GUID.ToUpper() + ".zip");
       //         }

       //         string[] filenames = Directory.GetFiles(slideFolderName);

       //         foreach (string slide in filenames)
       //         {
       //             if (!slideIds.Contains(slide.ToUpper()))
       //             {
       //                 File.Delete(slide);
       //             }

       //         }

             







       //     }
       //     catch 
       //     {
       //         EventLogger.LogAndThrowFault( "Error deleting unused files in slide folder", "");
       //     }

       // }




    }
}
