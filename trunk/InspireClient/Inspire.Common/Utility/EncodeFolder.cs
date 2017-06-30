using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Ionic.Zip;

//using ICSharpCode.SharpZipLib.Zip;
//using Inspire;
//using Ionic.Utils.Zip;
//using Xceed.Zip;
//using Xceed.FileSystem;
//using Xceed.Compression;
//using ZipFile=Ionic.Utils.Zip.ZipFile;

namespace Inspire.Common.Utility
{
    public class ZipUtil
    {
        //private static int m_RetryCounter; 

        //private static void OnItemException(object sender, ItemExceptionEventArgs e)
        //{
        //    if (e.CurrentItem is ZippedFile)
        //    {
        //        if (e.Exception is InvalidDecryptionPasswordException)
        //        {

        //            if (m_RetryCounter < 3)
        //            {
        //                //Console.Write("Enter the password for the file {0}: ", e.CurrentItem.Name);

        //               // ((ZipArchive)e.CurrentItem.RootFolder).DefaultDecryptionPassword = Console.ReadLine();
        //                e.Action = ItemExceptionAction.Retry;
        //                m_RetryCounter++;
        //            }
        //            else
        //            {
        //               // Console.WriteLine("{0} has been skipped due to an invalid password", e.CurrentItem.Name);
        //                e.Action = ItemExceptionAction.Ignore;
        //            }
        //        }
        //    }
        //}


        

        //private static void OnItemProgression(object sender, ItemProgressionEventArgs e)
        //{
        //    if ((e.CurrentItem != null) && (e.AllItems.Percent < 100))
        //    {
        //        m_RetryCounter = 0;
        //        //Console.WriteLine("{0} {1}...", (string)e.UserData, e.CurrentItem.FullName);
        //    }
        //}



        //private static void OnDiskRequired(object sender, DiskRequiredEventArgs e)
        //{
        //    if (e.Action == DiskRequiredAction.Fail)
        //    {
        //        //Console.WriteLine("Please insert a disk and press <Enter>.");
        //        //Console.WriteLine("Press <Ctrl-C> to cancel the operation.");
        //        //Console.ReadLine();

        //        e.Action = DiskRequiredAction.Continue;
        //    }
        //}

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
                MessageBox.Show("exception: " + ex1);
            }

        }

        ///// <summary>
        ///// Adds files to a zip file.
        ///// </summary>
        ///// <param name="zipFilename">Name of the zip file. If it does not exist, it will be created. If it exists, it will be updated.</param>
        ///// <param name="sourceFolder">Name of the folder from which to add files.</param>
        ///// <param name="fileMask">Name of the file to add to the zip file. Can include wildcards.</param>
        ///// <param name="recursive">Specifies if the files in the sub-folders of <paramref name="sourceFolder"/> should also be added.</param>
        ///// <param name="password"></param>
        ///// <param name="method"></param>

        //public static void ZipFiles(string sourceFolder, string zipFilename, string password)
        //{
        //    string fileMask = "*";
        //    bool recursive = true;
        //    EncryptionMethod encryptionMethod = EncryptionMethod.Compatible;

        //    //zipFilename = sourceFolder + zipFilename;


        //    if (sourceFolder.Length == 0)
        //        throw new ArgumentException("You must specify a source folder from which files will be added to the zip file.", "sourceFolder");
        //    // Create a DiskFile object for the specified zip filename

        //    DiskFile zipFile = new DiskFile(zipFilename);

           

        //    // Check if the file exists

        //    if (!zipFile.Exists)
        //    {
        //       // Console.WriteLine("Creating a new zip file \"{0}\"...", zipFilename);
        //        zipFile.Create();
        //    }
        //    else
        //    {
        //        //Console.WriteLine("Updating existing zip file \"{0}\"...", zipFilename);
        //    }

        //    Console.WriteLine();

        //    // Create a ZipArchive object to access the zipfile.

        //    ZipArchive zip = new ZipArchive(zipFile);

        //    zip.DefaultCompressionMethod = Xceed.Compression.CompressionMethod.Stored; 
        //    zip.DefaultEncryptionPassword = password;
        //    zip.DefaultEncryptionMethod = encryptionMethod;
        //    zip.AllowSpanning = true;

        //    // Create a DiskFolder object for the source folder

        //    DiskFolder source = new DiskFolder(sourceFolder);

        //    // Create a ZipEvents object for handling the ItemProgression event

        //    ZipEvents events = new ZipEvents();

        //    // Subscribe to the ItemProgression event and DiskRequired event

        //    events.ItemProgression += new ItemProgressionEventHandler(OnItemProgression);
        //    events.DiskRequired += new DiskRequiredEventHandler(OnDiskRequired);


        //    // Copy the contents of the zip to the destination folder.
        //    source.CopyFilesTo(events, "Zipping", zip, recursive, true, fileMask);
        //}

        public static void NewUnZipFiles(string zipFilename, string destFolder, string zipPassword, bool deleteZipFile)
        {
            try
            {
                using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipFilename))
                {
                    foreach (Ionic.Zip.ZipEntry e in zip)
                    {
                        try
                        {
                            e.ExtractWithPassword(destFolder, ExtractExistingFileAction.OverwriteSilently, zipPassword);  // overwrite == true
                        }
                        catch (Exception)
                        {
                            // file handle on a video... ignore
                        }
                        
                    }
                }
            }
            catch (Exception ex1)
            {
                //MessageBox.Show("exception: " + ex1); // TODO: Handle this through the UI
            }
            

        }

        ///// <summary>
        ///// Extracts the contents of a zip file to a specified folder, based on a file mask (wildcard).
        ///// </summary>
        ///// <param name="zipFilename">Name of the zip file. The file must exist.</param>
        ///// <param name="destFolder">Folder into which the files should be extracted.</param>
        ///// <param name="fileMask">Wildcard for filtering the files to be extracted.</param>
        
        //public static void UnZipFiles(string zipFilename, string destFolder, string password, bool deleteZipFile)
        //{
        //    try
        //    {
        //        //UnZipFiles(string zipPathAndFile, string outputFolder, string password, bool deleteZipFile)
        //        // Create a DiskFile object for the specified zip filename

        //        string fileMask = "*";

        //        DiskFile zipFile = new DiskFile(zipFilename);

        //        if (!zipFile.Exists)
        //        {   //Console.WriteLine("The specified zip file does not exist.");
        //            return;
        //        }

        //        //Console.WriteLine("Extracting all files matching the mask \"{0}\" to \"{1}\"...", fileMask, destFolder);
        //        //Console.WriteLine();

        //        // Create a ZipArchive object to access the zipfile.

        //        ZipArchive zip = new ZipArchive(zipFile);
        //        zip.DefaultDecryptionPassword = password;

        //        // Create a DiskFolder object for the destination folder

        //        DiskFolder destinationFolder = new DiskFolder(destFolder);

        //        // Create a FileSystemEvents object for handling the ItemProgression event

        //        FileSystemEvents events = new FileSystemEvents();

        //        // Subscribe to the ItemProgression event

        //        events.ItemProgression += new ItemProgressionEventHandler(OnItemProgression);
        //        events.ItemException += new ItemExceptionEventHandler(OnItemException);

        //        // Copy the contents of the zip to the destination folder.

        //        zip.CopyFilesTo(events, "Extracting", destinationFolder, true, true, fileMask);

        //        File.Delete(zipFilename);
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(" " + ex);
        //    }
        //}


        //public static void ZipFiles(string inputFolderPath, string outputPathAndFile, string password)
        //{
        //    //    ArrayList ar = GenerateFileList(inputFolderPath); // generate file list
            //    if (inputFolderPath != null)
            //    {
            //        // ReSharper disable PossibleNullReferenceException
            //        int TrimLength = (Directory.GetParent(inputFolderPath)).ToString().Length;
            //        // ReSharper restore PossibleNullReferenceException
            //        // find number of chars to remove     // from orginal file path
            //        TrimLength += 1; //remove '\'
            //        FileStream ostream;
            //        byte[] obuffer;
            //        string outPath = inputFolderPath + @"\" + outputPathAndFile;
            //        ZipOutputStream oZipStream = new ZipOutputStream(File.Create(outPath)); // create zip stream
            //        if (password != null && password != String.Empty)
            //            oZipStream.Password = password;
            //        oZipStream.SetLevel(9); // maximum compression
            //        foreach (string Fil in ar) // for each file, generate a zipentry
            //        {
            //            ZipEntry oZipEntry = new ZipEntry(Fil.Remove(0, TrimLength));
            //            oZipStream.PutNextEntry(oZipEntry);

            //            if (!Fil.EndsWith(@"/")) // if a file ends with '/' its a directory
            //            {
            //                ostream = File.OpenRead(Fil);
            //                obuffer = new byte[ostream.Length];
            //                ostream.Read(obuffer, 0, obuffer.Length);
            //                oZipStream.Write(obuffer, 0, obuffer.Length);
            //            }
            //        }
            //        oZipStream.Finish();
            //        oZipStream.Close();
            //    }
       // }

        //public static void ZipFilesToNewFolder(string inputFolderPath, string outputPathAndFile, string password)
        //{
        //    ArrayList ar = GenerateFileList(inputFolderPath); // generate file list
        //    if (inputFolderPath != null)
        //    {
        //        // ReSharper disable PossibleNullReferenceException
        //        int TrimLength = (Directory.GetParent(inputFolderPath)).ToString().Length;
        //        // ReSharper restore PossibleNullReferenceException
        //        // find number of chars to remove     // from orginal file path
        //        TrimLength += 1; //remove '\'
        //        FileStream ostream;
        //        byte[] obuffer;
        //        string outPath = outputPathAndFile;
        //        //string outPath = inputFolderPath + @"\" + outputPathAndFile;
        //        using (ZipOutputStream oZipStream = new ZipOutputStream(File.Create(outPath)))
        //        {// create zip stream
        //            if (password != null && password != String.Empty)
        //                oZipStream.Password = password;
        //            oZipStream.SetLevel(9); // maximum compression
        //            foreach (string Fil in ar) // for each file, generate a zipentry
        //            {
        //                ZipEntry oZipEntry = new ZipEntry(Fil.Remove(0, TrimLength));
        //                oZipStream.PutNextEntry(oZipEntry);

        //                if (!Fil.EndsWith(@"/")) // if a file ends with '/' its a directory
        //                {
        //                    ostream = File.OpenRead(Fil);
        //                    obuffer = new byte[ostream.Length];
        //                    ostream.Read(obuffer, 0, obuffer.Length);
        //                    oZipStream.Write(obuffer, 0, obuffer.Length);
        //                }
        //            }
        //            oZipStream.Finish();
        //            oZipStream.Close();
        //        }
        //    }
        //}





        //private static ArrayList GenerateFileList(string Dir)
        //{
        //    ArrayList fils = new ArrayList();
        //    bool Empty = true;
        //    foreach (string file in Directory.GetFiles(Dir)) // add each file in directory
        //    {
        //        fils.Add(file);
        //        Empty = false;
        //    }

        //    if (Empty)
        //    {
        //        if (Directory.GetDirectories(Dir).Length == 0)
        //        // if directory is completely empty, add it
        //        {
        //            fils.Add(Dir + @"/");
        //        }
        //    }

        //    foreach (string dirs in Directory.GetDirectories(Dir)) // recursive
        //    {
        //        foreach (object obj in GenerateFileList(dirs))
        //        {
        //            fils.Add(obj);
        //        }
        //    }
        //    return fils; // return file list
        //}


        //public static void UnZipFiles(string zipPathAndFile, string outputFolder, string password, bool deleteZipFile)
        //{
        //            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipPathAndFile)))
        //            {
        //                if (password != null && password != String.Empty)
        //                    s.Password = password;
        //                ZipEntry theEntry;

        //                while ((theEntry = s.GetNextEntry()) != null)
        //                {
        //                    string directoryName = outputFolder;
        //                    string fileName = Path.GetFileName(theEntry.Name);
        //                    // create directory 
        //                    if (directoryName != string.Empty)
        //                    {
        //                        Directory.CreateDirectory(directoryName);
        //                    }
        //                    if (fileName != String.Empty)
        //                    {
        //                        if (theEntry.Name.IndexOf(".ini") < 0)
        //                        {
        //                            string fullPath = directoryName + "\\" + theEntry.Name;
        //                            fullPath = fullPath.Replace("\\ ", "\\");
        //                            string fullDirPath = Path.GetDirectoryName(fullPath);
        //                            if (!Directory.Exists(fullDirPath)) Directory.CreateDirectory(fullDirPath);
        //                            using (FileStream streamWriter = File.Create(fullPath))
        //                            {
        //                                byte[] data = new byte[2048];
        //                                while (true)
        //                                {
        //                                    int size = s.Read(data, 0, data.Length);
        //                                    if (size > 0)
        //                                    {
        //                                        streamWriter.Write(data, 0, size);
        //                                    }
        //                                    else
        //                                    {
        //                                        break;
        //                                    }
        //                                }
        //                            }//using
        //                        }
        //                    }
        //                }
        //            }//using
        //            if (deleteZipFile)
        //                File.Delete(zipPathAndFile);
        //        }
        
    }//class

    }

