using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Markup;
using System.Windows.Threading;
using Inspire.Helpers;

namespace Inspire
{   
    public class Slide : INotifyPropertyChanged

    {
        private bool isSaving;
        private bool isOnline;

        public Slide()
        {
            GUID = Guid.NewGuid().ToString();
            DefaultDuration = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 10);
            Buttons = new SlideButtons();
            Rules = new SlideRules();
        }

        //public Slide(string guid, TimeSpan defaultDuration)
        //{
        //    Guid = guid;
        //    DefaultDuration = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, defaultDuration.Hours, defaultDuration.Minutes, defaultDuration.Seconds);
        //}

        public Slide(Slide file)
        {
            GUID = file.GUID;
            Name = file.Name;
            Description = file.Description;
            HResolution = file.HResolution;
            VResolution = file.VResolution;
            Background = file.Background;
            DefaultDuration = file.DefaultDuration;
            IsExternalFile = false;
            Buttons = file.Buttons;
            LastModifiedDate = file.LastModifiedDate;
            ModifiedBy = file.ModifiedBy;
            Tags = file.Tags;
            Rules = file.Rules;
        }

        public string GUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double HResolution { get; set; }
        public double VResolution { get; set; }
        public string Background { get; set; }
        public string ModifiedBy { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DateTime? LastModifiedDate { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SlideButtons Buttons { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SlideTags Tags { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SlideRules Rules { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Byte[] ThumbNail { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DateTime? DefaultDuration { get; set; }

        public static readonly Func<object, string, bool> NameSearchStrategy = (element, pattern) =>
        {
            var slide = element as Slide;
            if (string.IsNullOrEmpty(pattern) ||
                slide != null &&
                slide.Name.ToLower().Contains(pattern.ToLower()))
            {
                return true;
            }

            if (string.IsNullOrEmpty(pattern) ||
                slide != null &&
                slide.Description.ToLower().Contains(pattern.ToLower()))
                return true;
            return false;
        };

        /// <summary>
        /// Set IsSaving equal to true when it is being saved to the server, and False when the save is complete. This shows the saving animation in the DataTemplate in the DesignerSlideControl.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HasTouchElements
        {
            get { return (Buttons != null && Buttons.Count > 0); }
            set { value = (Buttons != null && Buttons.Count > 0); }
        }

        /// <summary>
        /// Set IsSaving equal to true when it is being saved to the server, and False when the save is complete. This shows the saving animation in the DataTemplate in the DesignerSlideControl.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSaving
        {
            get { return isSaving; }

            set
            {
                if (value != isSaving)
                {
                    isSaving = value;
                    NotifyPropertyChanged("IsSaving");
                }
            }
        }

        /// <summary>
        /// Set IsOnline equal to true when it has been saved to the server, and False when it resides local. This shows the Offline flag on the Slides in designer mode.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsOnline
        {
            get { return isOnline; }

            set
            {
                if (value != isOnline)
                {
                    isOnline = value;
                    NotifyPropertyChanged("IsOnline");
                }
            }
        }

        /// <summary>
        /// Used for loading slides from files, so that the SlideManager doesn't try and load the slide.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsExternalFile { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        static public void SerializeToXML(Slide slide, string path)
        {
            
           // XmlSerializer serializer = new XmlSerializer(typeof (Slide));
            using (TextWriter textWriter = new StreamWriter(path + "Slide.isf"))
            {
               // serializer.Serialize(textWriter, slide);
                XamlWriter.Save(slide, textWriter);
                textWriter.Dispose();
            }
        }

    }

    public class SlideCollection
    {
        ///// <remarks/>
        //public List<Slide> Items { get; set; }

        static public void SerializeOfflineSlidesToXML(SlideItemCollection slideCollection)
        {
            try
            {
                SlideItemCollection offLineSlides = new SlideItemCollection();

                //foreach (SlideFile slide in slideCollection.Where(sl => !sl.IsOnline).OfType<SlideFile>())
                //{
                //       // Slide newSlide = new Slide(slide);
                //        offLineSlides.Add(new Slide(slide));
                //}

                foreach (Slide slide in slideCollection.Where(sl => !sl.IsOnline))
                {
                    // Slide newSlide = new Slide(slide);
                    offLineSlides.Add(new Slide(slide));
                }

                // XmlSerializer serializer = new XmlSerializer(typeof(List<Slide>));
                using (TextWriter textWriter = new StreamWriter(Paths.ClientLocalSlidesFile))
                {
                    // serializer.Serialize(textWriter, slide);
                    XamlWriter.Save(offLineSlides, textWriter);
                    textWriter.Dispose();
                }
            }
            catch (Exception)
            {
                // dont error here TODO: log something here.
            }
            
        }

        static public void CleanRemovedOfflineSlides()
        {
            try
            {
                SlideItemCollection slideItemCollection;
                using (var xamlFile = new FileStream(Paths.ClientLocalSlidesFile,
                                                     FileMode.Open, FileAccess.Read))
                {
                    slideItemCollection = (SlideItemCollection)XamlReader.Load(xamlFile);
                    xamlFile.Dispose();
                }
                if (slideItemCollection != null)
                {
                    var slideList = slideItemCollection.Select(sl => sl.GUID).ToList();

                    Files.ClearDirectoryExceptForFiles(Paths.ClientLocalSlidePackagesDirectory, slideList);

                    Files.ClearDirectoryExceptForFiles(Paths.ClientLocalSlideImagesDirectory, slideList);
                }
            }
            catch (Exception)
            {

            }
            
        }
    }

    #region ObservableCollection of SlideItems
    public class SlideItemCollection : UpdatableSlideCollection
    {
        static public SlideItemCollection Slides = new SlideItemCollection();

        static public SlideItemCollection SlidesSaving = new SlideItemCollection();

        static public void RePopulateSlides(string id, bool saveGood)
        {
            Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Send, new Action(() =>
                                          {
                                              //int removeIndex = 0;
                                              if (saveGood)
                                              {
                                                  foreach (
                                                      var slide in
                                                          Slides)
                                                  {
                                                      if (slide.GUID == id)
                                                      {
                                                          slide.
                                                              IsSaving
                                                              = false;
                                                          slide.IsOnline = true;
                                                      }
                                                  }
                                                  SlideCollection.SerializeOfflineSlidesToXML(Slides);
                                              }
                                              //else
                                              //{
                                              //    foreach (var slide in Slides.Where(slide => slide.IsSaving))
                                              //    {
                                              //          removeIndex = Slides. IndexOf(slide);
                                              //    }
                                              //    Slides.RemoveAt(removeIndex);
                                              //}
                                          }));
            
            //SortSlidesByName();
        }

        public static void SortSlidesByName()
        {
           Slides.Sort(new SlideSortByName());
        }

        public void Sort()
        {

            Sort(Comparer<Slide>.Default);

        }

        public void Sort(IComparer<Slide> comparer)
        {
            int i, j;

            Slide index;

            for (i = 1; i < Count; i++)
            {
                index = this[i];     //If you can't read it, it should be index = this[x], where x is i :-)

                j = i;

                while ((j > 0) && (comparer.Compare(this[j - 1], index) == 1))
                {

                    this[j] = this[j - 1];

                    j = j - 1;

                }

                this[j] = index;
            }
        }
        
        public static bool CheckIfSaving()
        {
            return Slides.Any(slide => slide.IsSaving);
        }

        public static void SetOnlineSlides(List<Slide> slides)
        {
            foreach (var slide in slides)
            {
                slide.IsOnline = true;
                Slides.Add(slide);
            }
        }

        public static void SetOfflineSlides(SlideItemCollection slides)
        {
            foreach (var slide in slides)
            {
                slide.IsOnline = false;
                Slides.Add(slide);
            }
        }

        public static void UpdateOnlineSlideCollection(List<Slide> serverSlides)
        {
            var savingSlides = Slides.Where(sl => sl.IsSaving);

            var savingSlidesStrings = savingSlides.Select(s => s.GUID);

            Slides.Clear();

            SetOnlineSlides(serverSlides);

            foreach (var savingSlidesString in savingSlidesStrings)
            {
                if(Slides.Select(slid => slid.GUID == savingSlidesString).Count().Equals(0))
                {
                    Slides.Add(savingSlides.FirstOrDefault(sv => sv.GUID == savingSlidesString));
                }
            }
        }

        /// <summary>
        /// Load slides offline from the temp folder offlineslides.asf file.
        /// </summary>
        public static void LoadOffLineSlides()
        {
            if (File.Exists(Paths.ClientLocalSlidesFile))
            {
                try
                {
                    SlideItemCollection slideItemCollection;
                    using (var xamlFile = new FileStream(Paths.ClientLocalSlidesFile,
                                                         FileMode.Open, FileAccess.Read))
                    {
                        slideItemCollection = (SlideItemCollection)XamlReader.Load(xamlFile);
                        xamlFile.Dispose();
                    }
                    if (slideItemCollection != null)
                    {
                        foreach (var slideFile in slideItemCollection)
                        {
                            // .Select(offLineSlide => new SlideFile(offLineSlide))
                            //slideFile.IsOnline = false;
                            slideFile.ThumbNail =
                                ThumbnailCreator.LoadImagetoByteArray(Paths.ClientLocalSlideImagesDirectory + slideFile.GUID + ".png");
                            //SlideItemCollection.Slides.Add(slideFile);
                        }

                        SetOfflineSlides(slideItemCollection);
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
        }
    }

    
    #endregion

    public class SlideSortByName : IComparer<Slide>
    {
        #region IComparer<Contact> Members
        public int Compare(Slide x, Slide y)
        {
            return string.Compare(x.Name, y.Name);  // sort by name
        }
        #endregion
    }

    [Serializable]
    public class SlideRule
    {
        public string GUID { get; set; }
        public string Rule { get; set; }
        public string SlideID { get; set; }

        public SlideRule()
        {
            GUID = Guid.NewGuid().ToString();
        }
    }

    [Serializable]
    public class SlideTag
    {
        public string GUID { get; set; }
        public string Tag { get; set; }
        public string SlideID { get; set; }
    }

}
