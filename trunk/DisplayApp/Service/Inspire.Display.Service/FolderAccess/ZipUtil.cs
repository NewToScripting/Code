using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Ionic.Zip;


namespace Inspire.Common.Utility
{
    public class ZipUtil
    {
        public static void NewZipFiles(string sourceFolder, string zipFilename, string zipPassword)
        {
            try
            {
                using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile(zipFilename))
                {
                    zip.AddDirectory(sourceFolder);
                    zip.Password = zipPassword;
                    zip.Save(zipFilename);
                    zip.Dispose();
                }
            }
            catch (System.Exception ex1)
            {
                //MessageBox.Show("exception: " + ex1);
            }

        }      

        public static void NewUnZipFiles(string zipFilename, string destFolder, string zipPassword, bool deleteZipFile)
        {
            try
            {
                using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipFilename))
                {
                    foreach (Ionic.Zip.ZipEntry e in zip)
                    {
                        e.ExtractWithPassword(destFolder, ExtractExistingFileAction.OverwriteSilently, zipPassword);  // overwrite == true
                      
                    }
                    
                    zip.Dispose();
                }
                
                File.Delete(zipFilename);
            }
            catch (Exception ex1)
            {
                //MessageBox.Show("exception: " + ex1); // TODO: Handle this through the UI
            }
            

        } 
   
      }//class
      
    }

