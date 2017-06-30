using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using System.Xml;
//using Inspire.Display.Service.ScheduleServiceReference;
using Inspire.Common.Utility;
//using Inspire.Display.Service.ServerCommunication;
using Inspire.Display.Service.XML;


namespace Inspire.Display.Service
{
    public class SlideFolderAccess
    {

        /// <summary>
        /// Delete unused slides
        /// </summary>
        /// <param name="removeSlideIds"></param>
        static public void DeleteUnusedSlides(List<string> removeSlideIds)
        {
            try
            {
                foreach (string slide in removeSlideIds)
                {
                    if(!string.IsNullOrEmpty(slide))
                    {
                        DeleteFoldersinSlidesFolder(slide);
                    }                    
                }
            }
            catch (Exception)
            {
                EventLogger.Log("Error deleteing unused slides folders in slides folder", EventLogEntryType.Error);
            }
        }


        /// <summary>
        /// Save stream to file
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="fileName"></param>
        static public void SaveStreamToFile(Byte[] stream, String fileName)
        {
            using (FileStream file = new FileStream(fileName, FileMode.Create))
            {
                file.Write(stream, 0, stream.Length);
                file.Flush();
                file.Close();
                file.Dispose();
            }
        }

        /// <summary>
        /// Write schedule to XML
        /// </summary>
        /// <param name="p"></param>
        static public void WriteScheduleToXML(XML.Schedules p)
        { 
            try
            {
                string slideFolderName = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["SlideDirectory"];

                using (XmlWriter writer = XmlWriter.Create(slideFolderName + "Schedules.xml"))
                {
                    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(p.GetType());

                    try
                    {
                        if (writer != null) x.Serialize(writer, p);
                        if (writer != null) writer.Flush();
                        writer.Close();
                    }
                    catch (Exception e)
                    {
                        EventLogger.Log("Error writing schedule to XML in slides folder", EventLogEntryType.Error);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Chec kFor Schedule File
        /// </summary>
        /// <param name="p"></param>
        static public bool CheckForScheduleFile()
        {
            try
            {
                string scheduleFileName = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["SlideDirectory"] + "Schedules.xml";

                if (File.Exists(scheduleFileName))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        
        /// <summary>
        /// Get files in slides folder
        /// </summary>
        /// <returns></returns>
       static private List<string> GetFilesinSlidesFolder()
        {
           List<string> slideIds = new List<string>();

            try
            {
                string slideFolderName = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["SlideDirectory"];
                   
                string[] filenames = Directory.GetFiles(slideFolderName);
                                 
                    foreach(string file in filenames)
                        {
                            string slideID;
                            slideID = Path.GetFileNameWithoutExtension(file);
                            slideIds.Add(slideID);
                        }

            }
            catch (Exception)
            {
                EventLogger.Log("Error retrieving file list in slide folder", EventLogEntryType.Error);            
            }
           
            return slideIds;
        }

        /// <summary>
        /// Get folders in slides folder
        /// </summary>
        /// <returns></returns>
       static public List<string> GetFoldersinSlidesFolder()
       { 
           List<string> slideIds = new List<string>();

           try
           {
               string slideFolderName = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["SlideDirectory"];

               //string[] foldernames = Directory.GetDirectories(slideFolderName);
               
               var di = new DirectoryInfo(slideFolderName);
               DirectoryInfo[] directories = di.GetDirectories("*", SearchOption.TopDirectoryOnly);
               
               foreach (var folder in directories)
               {
                   string slideID;
                   slideID = Path.GetFileNameWithoutExtension(folder.FullName);
                   slideIds.Add(slideID);
               }

            }
            catch (Exception)
            {
                EventLogger.Log("Error retrieving folder list in slide folder", EventLogEntryType.Error);            
            }

          
           return slideIds;
       }

        /// <summary>
        /// Delete folders in slides folder
        /// </summary>
        /// <param name="folderName"></param>
       static private void DeleteFoldersinSlidesFolder(string folderName)
       {
           string slideFileType = "";
           string slideFolderName ="";

           try
           {
               slideFileType = ConfigurationManager.AppSettings["SlideFileType"];
               slideFolderName = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["SlideDirectory"]; 
              
               if (Directory.Exists(slideFolderName + folderName))
               {
                   Directory.Delete(slideFolderName + folderName, true);
               }

           }
           catch
           {
               EventLogger.Log( "Error deleting: " + slideFolderName + folderName, EventLogEntryType.Warning);
           }

       }


       /// <summary>
       /// Write slide to file
       /// </summary>
       /// <param name="stream"></param>
       /// <param name="fileSize"></param>
       /// <param name="fileID"></param>
       static public void WriteSlideToFile(Stream stream, int fileSize, string fileID)
       {
           Byte[] slideFile = StreamToBytes.ReadFully(stream, fileSize);

           string slideFileType = ConfigurationManager.AppSettings["SlideFileType"];
           string slideFileCode = ConfigurationManager.AppSettings["SlideFileCode"];
           string slideFolderName = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["SlideDirectory"];

           string filename = slideFolderName + fileID + slideFileType;

           if (slideFile != null)
           {
               if (filename != null && Directory.Exists(slideFolderName + fileID) != true)
               {
                   SaveStreamToFile(slideFile, filename);
                   ZipUtil.NewUnZipFiles(filename, slideFolderName + fileID, slideFileCode, true);
               }

           }

       }//function


    }
}
