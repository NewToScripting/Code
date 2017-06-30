using System.Windows.Media.Imaging;
using System;
using System.IO;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Threading;
using System.Collections.Generic;
using Inspire;

namespace SpinningLogo
{
    /// <summary>
    /// Interaction logic for InspireDefault.xaml
    /// </summary>
    public partial class InspireDefault
    {
        #region Data
        private Random rand = new Random(15);
        private DispatcherTimer timer = new DispatcherTimer();
        private Double currentChangeCount = 0;
        private Boolean isActive;
        private Point mousePosition;

        #endregion


        public InspireDefault()
        {
            InitializeComponent();
        }

        public InspireDefault(double width, double height)
        {
            InitializeComponent();

            Loaded += OnLoaded;
            Width = width;
            Height = height;
        }

        #region Private Methods
        private void OnLoaded(object sender, EventArgs e)
        {
            Storyboard sb = this.TryFindResource("sbLoaded") as Storyboard;
            timer.Interval = sb.Duration.TimeSpan;
            timer.IsEnabled = true;
            timer.Tick += new EventHandler(timer_Tick);
            

            ReadInCurrentFiles();
            CreateWorkingSetOfFiles();
            FillCube();
            sb.Begin(this);

        }

        /// <summary>
        /// Creates a window of n-many images from the total list of
        /// images available. If none are available create a working
        /// set of place holder (she-hulk images)
        /// </summary>
        private void CreateWorkingSetOfFiles()
        {
            //grab n-many random images
            Int32 currentSetIndex = 0;
            Globals.WorkingSetOfImages.Clear();

            if (Globals.Files.Count > 0)
            {
                while (currentSetIndex < Globals.WorkingSetLimit)
                {
                    Int32 randomIndex = rand.Next(0, Globals.Files.Count);
                    String imageUrl = Globals.Files[randomIndex].FullName;
                    if (!Globals.WorkingSetOfImages.Contains(imageUrl))
                    {
                        Globals.WorkingSetOfImages.Add(imageUrl);
                        
                    }
                    currentSetIndex++;
                }
            }
            else
            {
                for (int i = 0; i < Globals.WorkingSetLimit; i++)
                {
                    Globals.WorkingSetOfImages.Add("Images/NoImage.jpg");
                }
            }

            //create ItemsControl
            //itemsCurrentImages.Items.Clear();
            //foreach (String imageUrl in Globals.WorkingSetOfImages)
            //{
            //    SelectableImageUrl selectableImageUrl = new SelectableImageUrl();
            //    selectableImageUrl.ImageUrl = imageUrl;
            //    selectableImageUrl.IsSelected = false;
            //    itemsCurrentImages.Items.Add(selectableImageUrl);

            //}

        }

        /// <summary>
        /// Read in all images from users currently selected directories
        /// from the file stored on disk
        /// </summary>
        private void ReadInCurrentFiles()
        {

            Globals.Files.Clear();

            String fullFileName = Paths.ApplicationDirectory + @"\" + "DefaultLogo";


            //populate the listbox by reading the file on disk if it exists
            String directoryLineRead;
           
            try
            {
                foreach (var file in
                    new DirectoryInfo(fullFileName).GetFiles().IsImageFile())
                {
                    Globals.Files.Add(file);
                }
            }
            catch (DirectoryNotFoundException dex)
            {
            }
            catch (ArgumentException ax)
            {
            }
        }

        /// <summary>
        /// Assign new image, and if at end of working set of images
        /// get a new working set of images
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {

            FillCube();
        }

        private void FillCube()
        {
            Int32 randomIndex = rand.Next(0, Globals.WorkingSetOfImages.Count);
            String imageUrl = Globals.WorkingSetOfImages[randomIndex];

            //foreach (SelectableImageUrl selectableImageUrl in itemsCurrentImages.Items)
            //{
            //    if (selectableImageUrl.ImageUrl == imageUrl)
            //        selectableImageUrl.IsSelected = true;
            //    else
            //        selectableImageUrl.IsSelected = false;
            //}

            //update 3d cube images
            img1.Source = new BitmapImage(new Uri(imageUrl, UriKind.RelativeOrAbsolute));
            img2.Source = new BitmapImage(new Uri(imageUrl, UriKind.RelativeOrAbsolute));
            img3.Source = new BitmapImage(new Uri(imageUrl, UriKind.RelativeOrAbsolute));
            img4.Source = new BitmapImage(new Uri(imageUrl, UriKind.RelativeOrAbsolute));
            img5.Source = new BitmapImage(new Uri(imageUrl, UriKind.RelativeOrAbsolute));
            img6.Source = new BitmapImage(new Uri(imageUrl, UriKind.RelativeOrAbsolute));

            if (img1.Source.CanFreeze)
                img1.Source.Freeze();
            if (img2.Source.CanFreeze)
                img2.Source.Freeze();
            if (img3.Source.CanFreeze)
                img3.Source.Freeze();
            if (img4.Source.CanFreeze)
                img4.Source.Freeze();
            if (img5.Source.CanFreeze)
                img5.Source.Freeze();
            if (img6.Source.CanFreeze)
                img6.Source.Freeze();

            //do we need to create a new working set of images
            currentChangeCount++;
            if (currentChangeCount == Globals.WorkingSetLimit)
            {
                CreateWorkingSetOfFiles();
                currentChangeCount = 0;
            }
        }
        #endregion
    }
    /// <summary>
    /// Global variables
    /// </summary>
    public class Globals
    {
        #region Data
        public static IList<FileInfo> Files = new List<FileInfo>();
        public static String TempFileName = "ScreenSaverPictureLocations.txt";
        public static IList<String> WorkingSetOfImages = new List<String>();
        public readonly static Int32 WorkingSetLimit = 15;
        #endregion
    }

    /// <summary>
    /// provides extension methods for 
    /// IEnumerable&lt;FileInfo&gt; Types
    /// </summary>
    public static class FileInfoExtensions
    {
        #region IEnumerable<FileInfo> extension methods
        public static IEnumerable<FileInfo> IsImageFile(this IEnumerable<FileInfo> files,
                                            Predicate<FileInfo> isMatch)
        {
            foreach (FileInfo file in files)
            {
                if (isMatch(file))
                    yield return file;
            }
        }

        public static IEnumerable<FileInfo> IsImageFile(this IEnumerable<FileInfo> files)
        {
            foreach (FileInfo file in files)
            {
                if (file.Name.EndsWith(".jpg") ||
                    file.Name.EndsWith(".png") ||
                    file.Name.EndsWith(".bmp"))
                    yield return file;
            }
        }
        #endregion
    }
}
