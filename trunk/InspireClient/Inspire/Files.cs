using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Inspire
{
    public class Files
    {
        public static void Copy(string sourcePath, string targetPath)
        {
            File.Copy(sourcePath, targetPath, true);
            File.SetAttributes(targetPath, FileAttributes.Normal);
        }

        public static void Move(string sourcePath, string targetPath)
        {
            File.Move(sourcePath, targetPath);
            File.SetAttributes(targetPath, FileAttributes.Normal);
        }

        public static void ClearDirectory(string dirPath)
        {
            try
            {
                // Delete all file in the directory if directory exists
                if (Directory.Exists(dirPath))
                {
                    foreach (string fileReturned in Directory.GetFiles(dirPath))
                    {
                        try
                        {
                            File.SetAttributes(fileReturned, FileAttributes.Normal);
                            // TODO: Need to accept delete confirmation in vista
                            File.Delete(fileReturned);
                        }
                        catch (Exception)
                        {
                            // TODO: fix
                            //Surpress this, it seems to be working even though it is throwing an error we need to look into
                            // MessageBox.Show("File protected or in use." + ex);

                        }
                    }

                    foreach (string fileReturned in Directory.GetDirectories(dirPath))
                    {
                        try
                        {
                            // TODO: Need to accept delete confirmation in vista
                            Directory.Delete(fileReturned, true);
                        }
                        catch (Exception)
                        {
                            // TODO: fix
                            //Surpress this, it seems to be working even though it is throwing an error we need to look into
                            // MessageBox.Show("File protected or in use." + ex);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("File protected or in use." + ex);
            }

        }

        public static void ClearDirectoryExceptForFiles(string dirPath, List<string> keepFiles)
        {
            try
            {
                // Delete all file in the directory if directory exists
                if (Directory.Exists(dirPath))
                {
                    foreach (string fileReturned in Directory.GetFiles(dirPath))
                    {
                        try
                        {
                            if (!keepFiles.Contains(Path.GetFileNameWithoutExtension(fileReturned)))
                            {
                                File.SetAttributes(fileReturned, FileAttributes.Normal);
                                // TODO: Need to accept delete confirmation in vista
                                File.Delete(fileReturned);
                            }
                        }
                        catch (Exception)
                        {
                            // TODO: fix
                            //Surpress this, it seems to be working even though it is throwing an error we need to look into
                            // MessageBox.Show("File protected or in use." + ex);

                        }
                    }

                    foreach (string fileReturned in Directory.GetDirectories(dirPath))
                    {
                        try
                        {
                            // TODO: Need to accept delete confirmation in vista
                            Directory.Delete(fileReturned, true);
                        }
                        catch (Exception)
                        {
                            // TODO: fix
                            //Surpress this, it seems to be working even though it is throwing an error we need to look into
                            // MessageBox.Show("File protected or in use." + ex);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("File protected or in use." + ex);
            }

        }

        public static void CopyFolderToFolder(DirectoryInfo source, DirectoryInfo target)
        {
            try
            {
                // Check if the target directory exists, if not, create it.
                if (Directory.Exists(target.FullName) == false)
                {
                    Directory.CreateDirectory(target.FullName);
                }

                // Copy each file into it’s new directory.
                foreach (FileInfo fi in source.GetFiles())
                {
                    fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
                }

                // Copy each subdirectory using recursion.
                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir =
                        target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyFolderToFolder(diSourceSubDir, nextTargetSubDir);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File protected or in use." + ex);
            }
        }

        public static void CopyTemplateToSlide(string templateGuid)
        {
            try
            {
                // Delete all file in the directory if directory exists
                if (Directory.Exists(Paths.ClientTemplateTempDirectory))
                {

                    string templateFolder = Paths.ClientTempDirectory + templateGuid + "\\";
                    Directory.CreateDirectory(templateFolder);

                    foreach (string fileReturned in Directory.GetFiles(Paths.ClientTemplateTempDirectory))
                    {
                        try
                        {
                            File.SetAttributes(fileReturned, FileAttributes.Normal);
                            File.Copy(fileReturned, templateFolder + Path.GetFileName(fileReturned), true);
                        }
                        catch (Exception)
                        {
                            // TODO: fix
                            //Surpress this, it seems to be working even though it is throwing an error we need to look into
                            // MessageBox.Show("File protected or in use." + ex);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File protected or in use." + ex);
            }
        }

        static public void SaveStreamToFile(Byte[] stream, String fileName)
        {
            using (FileStream file = new FileStream(fileName, FileMode.Create))
            {
                file.Write(stream, 0, stream.Length);
                file.Flush();
                file.Dispose();
            }
        }

        public static void DeleteOldSlideFolder(string guid)
        {
            string oldFolder = Paths.ClientTempDirectory + "/" + guid;
            if (Directory.Exists(oldFolder))
            {
                ClearDirectory(oldFolder);
                DirectoryInfo diSource = new DirectoryInfo(oldFolder);
                try
                {
                    diSource.Delete();
                }
                catch (Exception)
                {
                    //MessageBox.Show("There are files that aren't being deleted in the following directory: " + oldFolder +" (Need to investigate before ship)"); //TODO: FIX
                    //throw;
                }
                
            }
        }
    }
}
