using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using System.Xml;
using Inspire.Common.Utility;
using Inspire.Server.Common;


namespace Inspire.Server.SlideManager.DataAccess
{
    public class SlideFolderAccess
    {

        /// <summary>
        /// Get Slide File
        /// </summary>
        /// <param name="slideID"></param>
        /// <returns></returns>
        static public byte[] GetSlideFile(string filePath)
        {
            byte[] file = null;

           try
            {

                byte[] buff = null;
               
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                long numBytes = new FileInfo(filePath).Length;
                buff = br.ReadBytes((int)numBytes);

                file = buff;
               
                fs.Dispose();
                br.Dispose();

            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error retrieving to Slide from folder");
                return file;
            }
           
               return file;
       
           
        }//end function


        /// <summary>
        /// Add Slide File
        /// </summary>
        /// <param name="slideFile"></param>
        static public void AddSlideFile(byte[] fileBytes, string filePath)
        {
            
            try
            {
                {
                    using (FileStream file = new FileStream(filePath, FileMode.Create))
                    {
                        file.Write(fileBytes, 0, fileBytes.Length);
                        file.Flush();
                        file.Close();
                    }
                }

            }
            catch (Exception e)
            {
                EventLogger.LogAndThrowFault(e.Message, "Error adding Slide to folder.");
            }

        }//end function




//        /// <summary>
//        /// Save stream to file
//        /// </summary>
//        /// <param name="stream"></param>
//        /// <param name="fileName"></param>
//        static public void SaveStreamToFile(Byte[] stream, String fileName)
//        {
//            using (FileStream file = new FileStream(fileName, FileMode.Create))
//            {
//                file.Write(stream, 0, stream.Length);
//                file.Flush();
//                file.Close();
//            }
//        }

//        /// <summary>
//        /// Open file stream 
//        /// </summary>
//        /// <param name="stream"></param>
//        /// <param name="fileName"></param>
//        static public void SaveStreamToFile(Byte[] stream, String fileName)
//        {
//            using (FileStream file = new FileStream(fileName, FileMode.Create))
//            {
//                file.Write(stream, 0, stream.Length);
//                file.Flush();
//                file.Close();
//            }
//        }


        
//       // /// <summary>
//       // /// Get files in slides folder
//       // /// </summary>
//       // /// <returns></returns>
//       //static private List<string> GetFilesinSlidesFolder()
//       // {
//       //    List<string> slideIds = new List<string>();

//       //     try
//       //     {
//       //         string slideFolderName = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["SlideDirectory"];
                   
//       //         string[] filenames = Directory.GetFiles(slideFolderName);
                                 
//       //             foreach(string file in filenames)
//       //                 {
//       //                     string slideID;
//       //                     slideID = Path.GetFileNameWithoutExtension(file);
//       //                     slideIds.Add(slideID);
//       //                 }

//       //     }
//       //     catch (Exception)
//       //     {
//       //         EventLogger.LogAndThrowFault("Error retrieving file list in slide folder", EventLogEntryType.Error.ToString());            
//       //     }
           
//       //     return slideIds;
//       // }

//       // /// <summary>
//       // /// Get folders in slides folder
//       // /// </summary>
//       // /// <returns></returns>
//       //static public byte[] GetSlideFileFromFolder()
//       //{ 
//       //    List<string> slideIds = new List<string>();

//       //    try
//       //    {
//       //        string slideFolderName = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["SlideDirectory"];

//       //        File.ReadAllBytes
               
//       //        string[] foldernames = Directory.GetDirectories(slideFolderName);
               
//       //        foreach (string file in foldernames)
//       //        {
//       //            string slideID;
//       //            slideID = Path.GetFileNameWithoutExtension(file);
//       //            slideIds.Add(slideID);
//       //        }

//       //     }
//       //     catch (Exception)
//       //     {
//       //         EventLogger.LogAndThrowFault("Error retrieving folder list in slide folder", EventLogEntryType.Error.ToString());            
//       //     }

//       //    return slideIds;
//       //}

//       // /// <summary>
//       // /// Delete folders in slides folder
//       // /// </summary>
//       // /// <param name="folderName"></param>
//       //static private void DeleteFoldersinSlidesFolder(string folderName)
//       //{
//       //    string slideFileType = "";
//       //    string slideFolderName ="";

//       //    try
//       //    {
//       //        slideFileType = ConfigurationManager.AppSettings["SlideFileType"];
//       //        slideFolderName = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["SlideDirectory"]; 
              
//       //        if (Directory.Exists(slideFolderName + folderName))
//       //        {
//       //            Directory.Delete(slideFolderName + folderName, true);
//       //        }

//       //    }
//       //    catch 
//       //    {
//       //        EventLogger.LogAndThrowFault( "Error deleting: " + slideFolderName + folderName, EventLogEntryType.Warning.ToString());
//       //    }

//       //}


//       ///// <summary>
//       ///// Write slide to file
//       ///// </summary>
//       ///// <param name="stream"></param>
//       ///// <param name="fileSize"></param>
//       ///// <param name="fileID"></param>
//       //static public void WriteSlideToFile(Stream stream, int fileSize, string fileID)
//       //{
//       //    Byte[] slideFile = StreamToBytes.ReadFully(stream, fileSize);

//       //    string slideFileType = ConfigurationManager.AppSettings["SlideFileType"];
//       //    string slideFileCode = ConfigurationManager.AppSettings["SlideFileCode"];
//       //    string slideFolderName = System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["SlideDirectory"];

//       //    string filename = slideFolderName + fileID + slideFileType;

//       //    if (slideFile != null)
//       //    {
//       //        if (filename != null && Directory.Exists(slideFolderName + fileID) != true)
//       //        {
//       //            SaveStreamToFile(slideFile, filename);
//       //            ZipUtil.NewUnZipFiles(filename, slideFolderName + fileID, slideFileCode, true);
//       //        }

//       //    }

//       //}//function


    }
}
