using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Xml.Linq;
using Inspire;
using Inspire.Commands;
using Inspire.Helpers;
using InspireDisplay.Properties;
using System.Threading;
using System.Xml;
using SpinningLogo;
using Transitionals;
using System.Windows.Input;

namespace InspireDisplay
{
    using System.Runtime.InteropServices;
    using System.Windows.Interop;
    using System.Windows.Media;

    public class Interop
    {
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        public static IntPtr GetWindowHandle(Window window)
        {
            return new WindowInteropHelper(window).Handle;
        }
    }


    /// <summary>
    /// Interaction logic for InspirePlayer.xaml
    /// </summary>
    public partial class InspirePlayer
    {
        /// <summary>
        /// Using user32.dll to interact with monitor, turns monitor on and off 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
        const int SC_MONITORPOWER = 0xF170;
        const int WM_SYSCOMMAND = 0x0112;
        const int MONITOR_ON = -1;
        const int MONITOR_OFF = 2;
        const int MONITOR_STANBY = 1;
        int onFlag = 0;

        private readonly Display dispInfo = new Display(Dns.GetHostName(), true);

        private FileSystemWatcher updateWatcher;

        private bool firstRun = true;

        private static bool DefaultSlideMode = false;

        private TimeSpan closestschedule;

        readonly DispatcherTimer slideTimer = new DispatcherTimer(DispatcherPriority.Normal);

        readonly DispatcherTimer scheduleTimer = new DispatcherTimer(DispatcherPriority.Normal);

        private string currentDefaultGuid = "DefaultSlide";
        private bool _forceRefresh;

        // private readonly SlideManager _SlideManager = new SlideManager();

       // private readonly SlideManager _DefaultSlideManager = new SlideManager();

        public string CurrentSlideGuid { get; set; }

        public ScheduledSlide DefaultSlide { get; set; }

        public bool Sleep { get; set; }

       // private delegate void TriggerUpdateDelegate();


        public InspirePlayer()
        {
            try
            {
                InitializeComponent();

               // _focusTimer.Tick += new EventHandler(_focusTimer_Tick);

                CommandBindings.Add(new CommandBinding(InspireCommands.TouchNavigateCommand, TouchNavigationExecuted, TouchNavigationCanExecute));

                InspireApp.IsPlayer = true;
                InspireApp.IsPlaying = true;

                InspireApp.PlaybackHostName = Dns.GetHostName().ToLower();

                SetWindowSize(dispInfo);

                slideTimer.Tick += slideTimer_Tick;

                scheduleTimer.Tick += scheduleTimer_Tick;

                Loaded += InspirePlayer_Loaded;

                PreviewKeyDown += new KeyEventHandler(InspirePlayer_PreviewKeyDown);

                Mouse.OverrideCursor = Cursors.None;

                SingleInstance.Make("InspireDisplay", this);

                Topmost = true;

#if DEBUG
                Topmost = false;
                Mouse.OverrideCursor = Cursors.Arrow;
#endif
            }
            catch (OutOfMemoryException e)
            {
                ProxyErrorHandler.LogAndRestart(e, "Out of memeory. " + DateTime.Now);
            }
            catch (Exception ex)
            {
                ProxyErrorHandler.LogAndRestart(ex, DateTime.Now.ToString());
            }
        }

        void InspirePlayer_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key.Equals(Key.Escape))
            {
                var displaySettings = new DisplaySettings();
                displaySettings.ShowDialog();
            }
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);

            IntPtr window = Interop.GetWindowHandle(this);
            IntPtr focused = Interop.GetForegroundWindow();
            if (window != focused)
            {
                Interop.SetForegroundWindow(window);
            }
        }

        private void TouchNavigationCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void TouchNavigationExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var sedingGuid = e.Parameter.ToString();

            var selectedGuid = SlideManager.CurrentButtonNavigations.FirstOrDefault(c => c.Key == sedingGuid).Value;

            var selectedSlide = SlideManager.SlidePlaylist.FirstOrDefault(s => s.GUID == selectedGuid);

            GoToSlideExecuted(selectedSlide, null);

            //int slideIndex = slidePlaylist.IndexOf(selectedSlide); //currentSlide = slidePlaylist.IndexOf(selectedSlide);
            //lbSlides.SelectedItem = lbSlides.Items[slideIndex];
        }

        void InspirePlayer_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                try
                {
                    Process[] processes = Process.GetProcessesByName("Inspire.WatchDog.Interface");

                    if(processes.Length == 0 )
                    {  
                        var pathBase = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf("\\"));

                        var path = pathBase + "\\Watchdog\\Inspire.WatchDog.Interface.exe";
                        Process.Start(path);
                    }

                    //foreach (Process process in processes)
                    //{
                    //    process.CloseMainWindow();
                    //}
                  
                }
                catch (Exception ex)
                {
                    
                }
                

                DisplayPaths.CreateDirectories();

                CreateScheduleFileWatcher();

                currentDefaultGuid = GetCurrentDefaultGuid();

                DefaultSlide = new ScheduledSlide { GUID = currentDefaultGuid };

                LoadSchedules();

                if (SlideManager.SlidePlaylist.Count == 0 && Sleep == false)
                {
                    if (closestschedule > new TimeSpan(0))
                    {
                        scheduleTimer.Interval = closestschedule;
                        scheduleTimer.Start();
                    }

                    PlayDefaultSlide();

                    return;
                }

                if (Sleep == false)
                {

                    SetFirstSlideAsActive();

                    PlayActiveSlide();
                }
                else
                {
                    MonitorOff();
                }
                if (closestschedule > (new TimeSpan(0)))
                    scheduleTimer.Interval = closestschedule;
                else
                    scheduleTimer.Interval = new TimeSpan(0, 15, 0);

                if (DefaultSlideMode)
                    scheduleTimer.Interval = TimeSpan.FromMinutes(1);

                scheduleTimer.Start();
            }
            catch (Exception ex)
            {
                ProxyErrorHandler.LogError(ex, ex.Message);
            }
        }

        #region utils

        void updateWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
            {
                Thread.Sleep(700);
                ReloadSchedules();
                //TriggerUpdateDelegate upDate = ReloadSchedules;

                //Dispatcher.Invoke(DispatcherPriority.Normal, upDate);
            }));
        }

        private void CreateScheduleFileWatcher()
        {
            updateWatcher = new FileSystemWatcher(Paths.PlayerSlideDirectory);

            updateWatcher.Path = Paths.PlayerSlideDirectory + @"\";
            updateWatcher.Filter = "Schedules.xml";
            updateWatcher.IncludeSubdirectories = false;
            updateWatcher.EnableRaisingEvents = true;
            updateWatcher.NotifyFilter = NotifyFilters.LastWrite;

            updateWatcher.Created += updateWatcher_Created;
            updateWatcher.Changed += updateWatcher_Created;
        }

        private void WakeMonitor()
        {
            if (onFlag == 1)
            {
                SendMessage(-1, WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_ON);
                onFlag = 0;
            }
        }

        private void MonitorOff()
        {
            SendMessage(-1, WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_OFF);
            onFlag = 1;
        }

        private void SetWindowSize(Display disp)
        {

            WindowStyle = System.Windows.WindowStyle.None;
            Width = disp.HResolution;
            Height = disp.VResolution;
            Top = 0;
            Left = 0;

        }

        #endregion

        #region Slides

        #region Default

            private static void SetFirstSlideAsActive()
            {
                if(SlideManager.SlidePlaylist[0].IsActive) return;
                PlayListSlide activeSlide = SlideManager.SlidePlaylist[0];
                activeSlide.IsActive = true;
                SlideManager.SlidePlaylist[0] = activeSlide;
            }

            private void PlayActiveSlide()
            {
                //ScheduledSlide slide;

                //if (DefaultSlideMode)
                //    slide = _DefaultSlideManager.GetCurrentSlide();
                //else
                   ScheduledSlide slide = SlideManager.GetCurrentSlide();
                

                if (string.IsNullOrEmpty(slide.GUID))
                {
                    PlayDefaultSlide();
                }
                else
                {
                   // if(SlideManager.IsTouchscreenMode && SlideManager.SlidePlaylist[0].IsActive) return;

                    DateTime? duration = slide.Duration;
                    slideTimer.Interval = new TimeSpan(duration.Value.Hour, duration.Value.Minute, duration.Value.Second);
                    InspireApp.CurrentSlideDuration = duration.Value.Hour * 360 + duration.Value.Minute * 60 + duration.Value.Second;
                    //LoadSlide(slide);
                    //slideTimer.Start();
                    //InspireCommands.GoToSlideCommand.Execute(slide, this);
                    
                    GoToSlideExecuted(slide, null);
                }

            }

            private void PlayDefaultSlide()
            {
                LoadSlide(DefaultSlide);
            }

            private static List<ScheduledSlide> GetDefaultSlides(IEnumerable<Schedule> _validSchedules)
            {
                var defaultSlides = new List<ScheduledSlide>();

                foreach (var schedule in _validSchedules)
                {
                    defaultSlides.AddRange(schedule.ScheduledSlides);
                }

                return defaultSlides;
            }

            private static string GetCurrentDefaultGuid()
            {
                return Settings.Default.DefaultSlideGuid;
            }
            
            private void ReplaceDefaultIfNew(XElement scheduleXML)
            {
                List<Schedule> validSchedules = new List<Schedule>();
                var validSchedule = new Schedule();
                validSchedule.GUID = scheduleXML.Element("GUID").Value;
                if (validSchedule.GUID != currentDefaultGuid)
                {
                    var schedSlides = new List<ScheduledSlide>();

                    var slidesXML = scheduleXML.Elements("ScheduleSlides").Elements("ScheduleSlide");
                    foreach (var slideXML in slidesXML)
                    {
                        var validSlide = new ScheduledSlide();
                        validSlide.GUID = slideXML.Element("GUID").Value;
                        validSlide.Transition = slideXML.Element("Transition").Value;
                        validSlide.TransitionSpeed = int.Parse(slideXML.Element("TransitionSpeed").Value);
                        validSlide.Duration = DateTime.Parse(slideXML.Element("Duration").Value);
                        validSlide.ScheduleId = slideXML.Element("ScheduleID").Value;
                        validSlide.OriginalSlideId = slideXML.Element("OriginalSlideID").Value;

                        schedSlides.Add(validSlide);
                    }

                    validSchedule.ScheduledSlides = schedSlides;
                    validSchedules.Add(validSchedule);
                    WriteDefaultSlideSchedule(validSchedules);
                    WriteNewDefaultGuid(validSchedule.GUID);
                }
                else
                {
                    currentDefaultGuid = "DefaultSlide";
                }
            }

            private void WriteDefaultSlideSchedule(List<Schedule> validSchedules)
            {
                using (XmlWriter writer = XmlWriter.Create(Paths.PlayerDefaultSlideDirectory + "Schedules.xml"))
                //using (XmlWriter writer = XmlWriter.Create(@"c:\Schedules.xml"))
                {
                    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(validSchedules.GetType());
                    x.Serialize(writer, validSchedules);

                    writer.Flush();
                }
            }

            private void WriteNewDefaultGuid(string scheduleGuid)
            {
                Settings.Default.DefaultSlideGuid = scheduleGuid;
            }

            #endregion

            private void LoadSlide(ScheduledSlide _slide)
            {
                if (DefaultSlideMode)
                {
                    if (CurrentSlideGuid != _slide.OriginalSlideId && File.Exists(Paths.PlayerSlideDirectory + @"\" + _slide.OriginalSlideId + @"\" + "Canvas.xaml"))
                    {
                        SlideToCanvas(_slide);
                    }
                    else
                    {
                        //if(_slide.is
                        if (SlideManager.SlidePlaylist.Count > 0)
                        {
                            int activeslides = 0;
                            foreach (var item in SlideManager.SlidePlaylist)
                            {
                                if (item.IsActive)
                                    activeslides++;
                            }
                            if (activeslides == 0)
                                this.MainCanvas.Content = new InspireDefault(Width, Height);
                        }
                        else
                            this.MainCanvas.Content = new InspireDefault(Width, Height);
                        //  throw new Exception("Load a generic Default Slide with a bouncing logo.");

                        //ReloadSchedules();
                        //FileStream xamlFile = new FileStream(DisplayPaths.DefaultSlideDirectory + _slide.OriginalSlideId + "Canvas.xaml", FileMode.Open, FileAccess.Read);

                        //ParserContext context = new ParserContext();

                        //context.BaseUri = new Uri(DisplayPaths.SlideDirectory + _slide.OriginalSlideId + @"\", UriKind.Absolute);

                        //Canvas canvas = XamlReader.Load(xamlFile, context) as Canvas;

                        //MainCanvas.LoadXMLtoCanvas(canvas, "Fade");
                    }
                }
                else
                {
                    if ((CurrentSlideGuid != _slide.OriginalSlideId || _forceRefresh) && File.Exists(Paths.PlayerSlideDirectory + @"\" + _slide.OriginalSlideId + @"\" + "Canvas.xaml"))//CurrentSlideGuid != _slide.OriginalSlideId && 
                    {
                        SlideToCanvas(_slide);
                        _forceRefresh = false;
                    }
                }
            }

            private static List<KeyValuePair<string, string>> GetButtonNavigations(IEnumerable<SlideButton> list)
            {
                List<KeyValuePair<string, string>> buttonNavs = null;

                if (list != null)
                {
                    buttonNavs = new List<KeyValuePair<string, string>>();
                    buttonNavs.AddRange(
                        list.Select(
                            slideButton =>
                            new KeyValuePair<string, string>(slideButton.GUID, slideButton.SlideGuidToNavigateTo)));
                }
                return buttonNavs;
            }

            private void SlideToCanvas(ScheduledSlide _slide)
            {
                if(InspireApp.SlideDontSkipList.Contains(_slide.OriginalSlideId))
                    InspireApp.RemoveDontSkipSlide(_slide.OriginalSlideId);

                if (InspireApp.SlideSkipList.Contains(_slide.OriginalSlideId))
                    InspireApp.RemoveSkipSlide(_slide.OriginalSlideId);


                var context = new ParserContext
                {
                    BaseUri =
                    new Uri(Paths.PlayerSlideDirectory + _slide.OriginalSlideId + @"/",
                            UriKind.Absolute)
                };


                InspireApp.CurrentSlideGuid = _slide.OriginalSlideId; // TODO: fix this!! this is pointed at the wrong thing. this requires changes to the playlist as well as preview canvas. should be pointed at slide.guid
                SlideManager.CurrentSlideGuid = _slide.GUID; // Temporary fix for now so that no other builds are required for client and playlist. May be better off here anyways.

                Canvas canvas;

                InspireApp.PlayNextSlide = true;
                using (FileStream fileStream = new FileStream(Paths.PlayerSlideDirectory + _slide.OriginalSlideId + @"/" + "Canvas.xaml", FileMode.Open,
                               FileAccess.Read))
                {

                    canvas = (Canvas)XamlReader.Load(fileStream, context);
                    fileStream.Dispose();
                }

                //canvas.CacheMode = new BitmapCache();

                SlideManager.CurrentButtonNavigations = GetButtonNavigations(_slide.Buttons);

                //Canvas canvas;

                //using (FileStream xamlFile =
                //    new FileStream(
                //        Paths.PlayerSlideDirectory + @"\" + _slide.OriginalSlideId + @"\" + "Canvas.xaml",
                //        FileMode.Open, FileAccess.Read))
                //{

                //    InspireApp.CurrentSlideGuid = _slide.GUID;

                //    SlideManager.CurrentButtonNavigations = GetButtonNavigations(_slide.Buttons);

                //    ParserContext context = new ParserContext();

                //    context.BaseUri = new Uri(Paths.PlayerSlideDirectory + _slide.OriginalSlideId + @"\",
                //                              UriKind.Absolute);

                //    InspireApp.PlayNextSlide = true;

                //    canvas = XamlReader.Load(xamlFile, context) as Canvas;

                //    xamlFile.Close();

                //}

                if (canvas != null && InspireApp.PlayNextSlide && CurrentSlideGuid != _slide.OriginalSlideId)
                {
                    
                        canvas.ClipToBounds = true;

                        MainCanvas.Transition = TransitionService.SetTransition(_slide.Transition);

                        InspireApp.CurrentPlayerCanvas = canvas;

                        MainCanvas.Arrange(new Rect(0,0,canvas.Width, canvas.Height));

                       // vbPlayer.Arrange(new Rect(0, 0, dispInfo.HResolution, dispInfo.VResolution));

                        //vbPlayer.Width = canvas.Width;
                        //vbPlayer.Height = canvas.Height;

                        //canvas.CacheMode = new BitmapCache();

                        MainCanvas.Content = canvas;

                        Utilities.AttachReflections(canvas.Children);


                        //Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { MainCanvas.Transition = TransitionService.SetTransition(_slide.Transition); }));

                        CurrentSlideGuid = _slide.OriginalSlideId;
                }
                else
                {
                    if (InspireApp.SlideSkipList.Count == SlideManager.GetNonDuplicateCount(SlideManager.SlidePlaylist) && !InspireApp.SlideDontSkipList.Contains(_slide.OriginalSlideId))
                    {
                        SlideManager.SlidePlaylist.Clear();
                        slideTimer.Stop();
                        scheduleTimer.Stop();

                        var validSchedules = GetDefaultSchedule();

                        var defaultSlides = GetDefaultSlides(validSchedules);

                        foreach (var scheduledSlide in defaultSlides)
                        {
                            if (File.Exists(Paths.PlayerSlideDirectory + @"\" + scheduledSlide.OriginalSlideId + @"\" + "Canvas.xaml"))
                                SlideManager.SlidePlaylist.Add(new PlayListSlide(scheduledSlide));
                        }

                        DefaultSlideMode = true;

                        AdvanceActiveSlide();

                        scheduleTimer.Interval = TimeSpan.FromMinutes(1);
                        scheduleTimer.Start();

                        if (firstRun)
                        {
                            slideTimer.Interval = TimeSpan.FromSeconds(1);
                            slideTimer.Start();
                            firstRun = false;
                        }
                    }
                    else
                    {
                        if (firstRun)
                        {
                            slideTimer.Interval = TimeSpan.FromSeconds(1);
                            firstRun = false;
                        }
                        
                        //if(slideTimer.Interval > TimeSpan.FromMinutes(1) && SlideManager.GetNonDuplicateCount(SlideManager.SlidePlaylist) == 1)
                        //    slideTimer.Interval = TimeSpan.FromMinutes(1);
                        
                        slideTimer.Start();
                    }
                    
                }

               // SlideManager.SetActiveSlide();
            }

            void slideTimer_Tick(object sender, EventArgs e)
            {
                try
                {
                    AdvanceActiveSlide();
                    PlayActiveSlide();

                }
                catch (Exception ex)
                {
                    ProxyErrorHandler.LogError(ex, ex.Message);

                    //MessageBox.Show(ex.ToString());
                }
            }

            private void AdvanceActiveSlide()
            {
                if (SlideManager.IsTouchscreenMode)
                {
                    SetFirstSlideAsActive();
                    return; 
                }

                int slideCount = SlideManager.SlidePlaylist.Count;

                int currentSlide = SlideManager.GetCurrentIndex(); // SlideManager.SlidePlaylist.IndexOf(SlideManager.GetCurrentSlide());

                if (slideCount > 1)
                {
                    if ((slideCount > 1) && (slideCount > currentSlide + 1))
                    {
                        var oldSlide = SlideManager.SlidePlaylist[currentSlide];
                        oldSlide.IsActive = false;
                        SlideManager.SlidePlaylist[currentSlide] = oldSlide;

                        var newSlide = SlideManager.SlidePlaylist[currentSlide + 1];
                        newSlide.IsActive = true;
                        SlideManager.SlidePlaylist[currentSlide + 1] = newSlide;
                    }
                    else if (slideCount == 1)
                    {
                        return;
                    }
                    else
                    {
                        var oldSlide = SlideManager.SlidePlaylist[currentSlide];
                        oldSlide.IsActive = false;
                        SlideManager.SlidePlaylist[currentSlide] = oldSlide;

                        var newSlide = SlideManager.SlidePlaylist[0];
                        newSlide.IsActive = true;
                        SlideManager.SlidePlaylist[0] = newSlide;
                    }
                }
            }

            private static IEnumerable<ScheduledSlide> GetSlides(IEnumerable<Schedule> displaySchedules)
            {
                var slides = new List<ScheduledSlide>();

                var interspersedSlides = new List<ScheduledSlide>();
                var noMixSlides = new List<ScheduledSlide>();
                var randomSlides = new List<ScheduledSlide>();
                var normalSlides = new List<ScheduledSlide>();

                foreach (Schedule schedule in displaySchedules)
                {
                    if (schedule.Mode == Schedule.ModeEnum.Default)
                        normalSlides.AddRange(schedule.ScheduledSlides);
                    else if (schedule.Mode == Schedule.ModeEnum.Intersperse)
                        interspersedSlides.AddRange(schedule.ScheduledSlides);
                    else if (schedule.Mode == Schedule.ModeEnum.Shuffle)
                        randomSlides.AddRange(schedule.ScheduledSlides);
                    else if (schedule.Mode == Schedule.ModeEnum.DoNotMix)
                        noMixSlides.AddRange(schedule.ScheduledSlides);
                }

                if (randomSlides.Count > 0)
                    slides.AddRange(Shuffler.ShuffleSlides(randomSlides, normalSlides));
                else
                    slides.AddRange(normalSlides);

                slides = Intersperser.IntersperseSlides(interspersedSlides, slides);

                slides.AddRange(noMixSlides);
                return slides;
            }

            private static List<ScheduledSlide> GetNonShuffledSlides(IEnumerable<Schedule> _validSchedules)
            {
                var noninterspersedScheduledSlides = new List<ScheduledSlide>();

                foreach (var schedule in _validSchedules)
                {
                    if (schedule.Mode == Schedule.ModeEnum.Default)
                    {
                        noninterspersedScheduledSlides.AddRange(schedule.ScheduledSlides);
                    }
                }

                return noninterspersedScheduledSlides;
            }

            private static List<ScheduledSlide> GetInterspersedSlides(IEnumerable<Schedule> _validSchedules)
            {
                var intersperseSchedules = _validSchedules.Where(schedule => schedule.Mode == Schedule.ModeEnum.Intersperse).ToList();

                List<ScheduledSlide> interspersedScheduledSlides = Intersperser.Intersperse(intersperseSchedules);
                return interspersedScheduledSlides;
            }

            private static List<ScheduledSlide> GetShuffledSlides(IEnumerable<Schedule> _validSchedules)
            {
                var randomizeScheduledSlides = new List<ScheduledSlide>();

                foreach (var schedule in _validSchedules.Where(schedule => schedule.Mode == Schedule.ModeEnum.Shuffle))
                {
                    randomizeScheduledSlides.AddRange(schedule.ScheduledSlides);
                }

                randomizeScheduledSlides = Shuffler.Shuffle(randomizeScheduledSlides);
                return randomizeScheduledSlides;
            }

        #endregion

        #region Schedules

            private void LoadSchedules()
            {
                SlideManager.SlidePlaylist.Clear();
                slideTimer.Stop();
                scheduleTimer.Stop();
                firstRun = true;

                InspireApp.SlideSkipList.Clear();
                InspireApp.SlideDontSkipList.Clear();

                var _validSchedules = GetValidSchedules();
                if (_validSchedules.Count > 0)
                {
                    var slides = GetSlides(_validSchedules);
                    foreach (var scheduledSlide in slides)
                    {
                        if (File.Exists(Paths.PlayerSlideDirectory + @"\" + scheduledSlide.OriginalSlideId + @"\" + "Canvas.xaml"))
                            SlideManager.SlidePlaylist.Add(new PlayListSlide(scheduledSlide));
                    }
                }
                else
                {
                    _validSchedules = GetDefaultSchedule();

                    var defaultSlides = GetDefaultSlides(_validSchedules);

                    foreach (var scheduledSlide in defaultSlides)
                    {
                        if (File.Exists(Paths.PlayerSlideDirectory + @"\" + scheduledSlide.OriginalSlideId + @"\" + "Canvas.xaml"))
                            SlideManager.SlidePlaylist.Add(new PlayListSlide(scheduledSlide));
                    }

                    DefaultSlideMode = true;

                }

                if(SlideManager.SlidePlaylist.Count == 0)
                {
                    _validSchedules = GetDefaultSchedule();

                    var defaultSlides = GetDefaultSlides(_validSchedules);

                    foreach (var scheduledSlide in defaultSlides)
                    {
                        if (File.Exists(Paths.PlayerSlideDirectory + @"\" + scheduledSlide.OriginalSlideId + @"\" + "Canvas.xaml"))
                            SlideManager.SlidePlaylist.Add(new PlayListSlide(scheduledSlide));
                    }

                    DefaultSlideMode = true;
                }

            }

            void scheduleTimer_Tick(object sender, EventArgs e)
            {
                try
                {
                    _forceRefresh = true;
                    ReloadSchedules();
                }
                catch (Exception ex)
                {
                    ProxyErrorHandler.LogError(ex, ex.Message);
                }
            }

            private void ReloadSchedules()
            {
                DefaultSlideMode = false;

                LoadSchedules();

                if (SlideManager.SlidePlaylist.Count == 0 && Sleep == false)
                {
                    WakeMonitor();
                    PlayDefaultSlide();


                    scheduleTimer.Start();

                    return;
                }

                if (Sleep == false)
                {
                    WakeMonitor();

                    SetFirstSlideAsActive();

                    PlayActiveSlide();

                }
                else
                {
                    MonitorOff();
                }

                scheduleTimer.Start();
            }

            private static List<Schedule> GetDefaultSchedule()
            {
                var validSchedules = new List<Schedule>();

                if (File.Exists(Paths.PlayerDefaultSlideDirectory + "Schedules.xml"))
                {
                    XElement root = XElement.Load(Paths.PlayerDefaultSlideDirectory + "Schedules.xml");

                    IEnumerable<XElement> schedulesXML = root.Elements("Schedule");
                    foreach (XElement scheduleXML in schedulesXML)
                    {
                        if (scheduleXML != null)
                        {
                            string _schedtype = scheduleXML.Element("Type").Value;
                            //var _interspersemode = scheduleXML.Element("Mode").Value;

                            var _startTime = Convert.ToDateTime(scheduleXML.Element("StartTime").Value);
                            var _startDate = Convert.ToDateTime(scheduleXML.Element("StartDate").Value);
                            var _endTime = Convert.ToDateTime(scheduleXML.Element("EndTime").Value);
                            var _endDate = Convert.ToDateTime(scheduleXML.Element("EndDate").Value);

                            var startDateTime =
                                new DateTime(_startDate.Year, _startDate.Month, _startDate.Day, _startTime.Hour,
                                             _startTime.Minute, _startTime.Second);

                            var endDateTime = new DateTime(_endDate.Year, _endDate.Month, _endDate.Day, _endTime.Hour, _endTime.Minute, _endTime.Second);

                            validSchedules.Add(GetDefaultSchedule(scheduleXML, _startDate, _startTime, _endDate, _endTime));
                        }
                    }
                }
                return validSchedules;
            }

            private List<Schedule> GetValidSchedules() //TODO: Fix null reference exception
            {
                DateTime currentDateTime = DateTime.Now;

                DateTime midnightcheck = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 1).AddDays(1);

                closestschedule = midnightcheck - currentDateTime;

                Sleep = false;

                SlideManager.IsTouchscreenMode = false;

                var validSchedules = new List<Schedule>();

                if (File.Exists(Paths.PlayerSlideDirectory + "Schedules.xml"))
                {
                    XElement root = null;

                    try
                    {
                        root = XElement.Load(Paths.PlayerSlideDirectory + "Schedules.xml");
                    }
                    catch (Exception)
                    {

                    }

                    if (root != null)
                    {
                        IEnumerable<XElement> schedulesXML = root.Elements("Schedule");
                        if (schedulesXML != null)
                            foreach (XElement scheduleXML in schedulesXML)
                            {
                                if (scheduleXML != null)
                                {
                                    Sleep = false;
                                    string _schedtype = scheduleXML.Element("Type").Value;
                                    //var _interspersemode = scheduleXML.Element("Mode").Value;

                                    var _startTime = Convert.ToDateTime(scheduleXML.Element("StartTime").Value);
                                    var _startDate = Convert.ToDateTime(scheduleXML.Element("StartDate").Value);
                                    var _endTime = Convert.ToDateTime(scheduleXML.Element("EndTime").Value);
                                    var _endDate = Convert.ToDateTime(scheduleXML.Element("EndDate").Value);

                                    Schedule.DaysEnum _days = (Schedule.DaysEnum)Convert.ToInt32(scheduleXML.Element("Days").Value);

                                    _startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _startTime.Hour, _startTime.Minute, _startTime.Second);

                                    _endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _endTime.Hour, _endTime.Minute, _endTime.Second);

                                    var startDateTime =
                                        new DateTime(_startDate.Year, _startDate.Month, _startDate.Day, _startTime.Hour,
                                                     _startTime.Minute, _startTime.Second);

                                    var endDateTime = new DateTime(_endDate.Year, _endDate.Month, _endDate.Day, _endTime.Hour, _endTime.Minute, _endTime.Second);


                                    if (_schedtype != null)
                                        switch (_schedtype)
                                        {
                                            case ("Sleep"):
                                                {

                                                    var todayStartDateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, _startTime.Hour, _startTime.Minute, _startTime.Second);

                                                    var todayEndDateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, _endTime.Hour, _endTime.Minute, _endTime.Second);

                                                    if ((startDateTime <= currentDateTime) && (endDateTime > currentDateTime) && (todayStartDateTime <= DateTime.Now) && (todayEndDateTime >= DateTime.Now))
                                                    {
                                                        if ((_endTime.TimeOfDay - currentDateTime.TimeOfDay) < closestschedule)
                                                            closestschedule = endDateTime.TimeOfDay - currentDateTime.TimeOfDay;
                                                        Sleep = true;
                                                    }
                                                    else
                                                    {
                                                        if ((_startDate <= currentDateTime) && (_endDate >= currentDateTime.Date) && (todayStartDateTime > DateTime.Now))
                                                        {
                                                            if ((startDateTime - currentDateTime) < closestschedule)
                                                                closestschedule = (todayStartDateTime - currentDateTime);
                                                        }

                                                        Sleep = false;
                                                    }
                                                    break;
                                                }
                                            case ("Daily"):
                                                {

                                                    var todayStartDateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, _startTime.Hour, _startTime.Minute, _startTime.Second);

                                                    var todayEndDateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, _endTime.Hour, _endTime.Minute, _endTime.Second);



                                                    if ((startDateTime <= currentDateTime) && (endDateTime > currentDateTime) && (todayStartDateTime <= DateTime.Now) && (todayEndDateTime >= DateTime.Now))
                                                    {
                                                        if ((_endTime.TimeOfDay - currentDateTime.TimeOfDay) < closestschedule)
                                                            closestschedule = endDateTime.TimeOfDay - currentDateTime.TimeOfDay;

                                                        validSchedules.Add(GetValidSchedule(scheduleXML, _startDate, _startTime, _endDate, _endTime));
                                                    }
                                                    else
                                                    {
                                                        // check if startTime is less than closestschedule time
                                                        if ((_startDate <= currentDateTime) && (_endDate >= currentDateTime.Date) && (todayStartDateTime > DateTime.Now))
                                                        {
                                                            if ((todayStartDateTime - currentDateTime) < closestschedule)
                                                                closestschedule = (todayStartDateTime - currentDateTime);
                                                        }
                                                    }
                                                    break;
                                                }
                                            case ("Weekly"):
                                                {
                                                    if ((_startDate <= currentDateTime.Date) && (_endDate >= currentDateTime.Date) && (_startTime <= DateTime.Now) && (_endTime >= DateTime.Now) && ContainsToday(_days))
                                                    {

                                                        if ((_endTime.TimeOfDay - currentDateTime.TimeOfDay) < closestschedule)
                                                            closestschedule = endDateTime.TimeOfDay - currentDateTime.TimeOfDay;

                                                        validSchedules.Add(GetValidSchedule(scheduleXML, _startDate, _startTime, _endDate, _endTime));
                                                    }
                                                    else
                                                    {
                                                        // check if startTime is less than closestschedule time
                                                        if ((_startDate <= currentDateTime.Date) && (_endDate >= currentDateTime.Date) && (_startTime > DateTime.Now))
                                                        {
                                                            if ((startDateTime - currentDateTime) < closestschedule)
                                                                closestschedule = (startDateTime - currentDateTime);
                                                        }
                                                    }
                                                    break;
                                                }
                                            case ("Monthly"):
                                                {
                                                    if ((_startDate <= currentDateTime.Date) && (_endDate >= currentDateTime.Date) && (_startTime <= DateTime.Now) && (_endTime >= DateTime.Now))
                                                    {
                                                        if (_startDate.Day == currentDateTime.Day)
                                                        {
                                                            if ((_endTime.TimeOfDay - currentDateTime.TimeOfDay) < closestschedule)
                                                                closestschedule = endDateTime.TimeOfDay - currentDateTime.TimeOfDay;

                                                            validSchedules.Add(GetValidSchedule(scheduleXML, _startDate, _startTime, _endDate, _endTime));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        // check if startTime is less than closestschedule time
                                                        if ((_startDate <= currentDateTime.Date) && (_endDate >= currentDateTime.Date) && (_startTime > DateTime.Now))
                                                        {
                                                            if ((startDateTime - currentDateTime) < closestschedule)
                                                                closestschedule = (startDateTime - currentDateTime);
                                                        }
                                                    }
                                                    break;
                                                }
                                            case ("Yearly"):
                                                {
                                                    if ((_startDate <= currentDateTime.Date) && (_endDate >= currentDateTime.Date) && (_startTime <= DateTime.Now) && (_endTime >= DateTime.Now))
                                                    {
                                                        if ((_startDate.Month == currentDateTime.Month) && (_startDate.Day == currentDateTime.Day))
                                                        {
                                                            if ((_endTime.TimeOfDay - currentDateTime.TimeOfDay) < closestschedule)
                                                                closestschedule = endDateTime.TimeOfDay - currentDateTime.TimeOfDay;

                                                            validSchedules.Add(GetValidSchedule(scheduleXML, _startDate, _startTime, _endDate, _endTime));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        // check if startTime is less than closestschedule time
                                                        if ((_startDate <= currentDateTime.Date) && (_endDate >= currentDateTime.Date) && (_startTime > DateTime.Now))
                                                        {
                                                            if ((startDateTime - currentDateTime) < closestschedule)
                                                                closestschedule = (startDateTime - currentDateTime);
                                                        }
                                                    }
                                                    break;
                                                }
                                            case ("Continuous"):
                                                {
                                                    if ((startDateTime <= currentDateTime && endDateTime > currentDateTime))
                                                    {
                                                        if ((endDateTime - currentDateTime) < closestschedule)
                                                            closestschedule = endDateTime - currentDateTime;
                                                        validSchedules.Add(GetValidSchedule(scheduleXML, _startDate, _startTime, _endDate, _endTime));
                                                    }
                                                    else
                                                    {
                                                        if ((_startDate <= currentDateTime.Date) && (_endDate >= currentDateTime.Date) && (_startTime > DateTime.Now))
                                                        {
                                                            if ((startDateTime - currentDateTime) < closestschedule)
                                                                closestschedule = (startDateTime - currentDateTime);
                                                        }
                                                    }
                                                    break;
                                                }
                                            case ("Touchscreen"):
                                                {
                                                    if ((startDateTime <= currentDateTime && endDateTime > currentDateTime))
                                                    {
                                                        if ((endDateTime - currentDateTime) < closestschedule)
                                                            closestschedule = endDateTime - currentDateTime;
                                                        validSchedules.Add(GetValidSchedule(scheduleXML, _startDate, _startTime, _endDate, _endTime));
                                                        SlideManager.IsTouchscreenMode = true; // Set Touchscreen Mode equal to true so that the first slide is the home slide and the time doesn't run for that slide.
                                                    }
                                                    else
                                                    {
                                                        if ((_startDate <= currentDateTime.Date) && (_endDate >= currentDateTime.Date) && (_startTime > DateTime.Now))
                                                        {
                                                            if ((startDateTime - currentDateTime) < closestschedule)
                                                                closestschedule = (startDateTime - currentDateTime);
                                                        }
                                                    }
                                                    break;
                                                }
                                            //case ("Triggerable"):
                                            //    {
                                            //        if ((_startDate <= currentDateTime.Date) && (_endDate >= currentDateTime.Date) && (_startTime <= DateTime.Now) && (_endTime >= DateTime.Now))
                                            //        {
                                            //            if ((_endTime.TimeOfDay - currentDateTime.TimeOfDay) > closestschedule)
                                            //                closestschedule = endDateTime.TimeOfDay - currentDateTime.TimeOfDay;
                                            //            validSchedules.Add(GetValidSchedule(scheduleXML, _startDate, _startTime, _endDate, _endTime));
                                            //        }
                                            //        else
                                            //        {
                                            //            // check if startTime is less than closestschedule time
                                            //            if ((_startDate <= currentDateTime.Date) && (_endDate >= currentDateTime.Date) && (_startTime > DateTime.Now))
                                            //            {
                                            //                if ((startDateTime - currentDateTime) < closestschedule)
                                            //                    closestschedule = (startDateTime - currentDateTime);
                                            //            }
                                            //        }
                                            //        break;
                                            //    }
                                            case ("Default"):
                                                {
                                                    ReplaceDefaultIfNew(scheduleXML);
                                                    break;
                                                }
                                            default:
                                                break;
                                        }
                                }

                                if (closestschedule > new TimeSpan(0))
                                    scheduleTimer.Interval = closestschedule;
                            }
                    }
                }

                return validSchedules;
            }

            private static bool ContainsToday(Schedule.DaysEnum days)
            {
                return Schedule.GetSelectedEnumValues(days).Any(item => item.ToString() == DateTime.Today.DayOfWeek.ToString());
            }

        private static Schedule GetValidSchedule(XElement scheduleXML, DateTime _startDate, DateTime _startTime, DateTime _endDate, DateTime _endTime)
            {
                var validSchedule = new Schedule();
                validSchedule.StartDate = _startDate;
                validSchedule.EndDate = _endDate;
                validSchedule.StartTime = _startTime;
                validSchedule.EndTime = _endTime;
                validSchedule.GUID = scheduleXML.Element("GUID").Value;
                validSchedule.Name = scheduleXML.Element("Name").Value;
                validSchedule.Priority = int.Parse(scheduleXML.Element("Priority").Value);
                validSchedule.Mode = ConvertToMode(scheduleXML.Element("Mode").Value);

                var schedSlides = new List<ScheduledSlide>();

                var slidesXML = scheduleXML.Elements("ScheduleSlides").Elements("ScheduleSlide");
                foreach (XElement slideXML in slidesXML)
                {
                    var validSlide = new ScheduledSlide();
                    validSlide.GUID = slideXML.Element("GUID").Value;
                    //  validSlide.Name = slideXML.Element("Name").Value;
                    validSlide.Transition = slideXML.Element("Transition").Value;
                    validSlide.TransitionSpeed = int.Parse(slideXML.Element("TransitionSpeed").Value);
                    validSlide.Duration = DateTime.Parse(slideXML.Element("Duration").Value);
                    validSlide.ScheduleId = slideXML.Element("ScheduleID").Value;
                    validSlide.OriginalSlideId = slideXML.Element("OriginalSlideID").Value;
                    validSlide.Buttons = GetButtons(slideXML.Elements("Buttons").Elements("Button"));

                    schedSlides.Add(validSlide);
                }

                validSchedule.ScheduledSlides = schedSlides;
                return validSchedule;
            }

        private static SlideButtons GetButtons(IEnumerable<XElement> iButtons)
        {
            var slideButtons = new SlideButtons();
            foreach (var iButton in iButtons)
            {
                var slideButton = new SlideButton();
                slideButton.GUID = iButton.Element("GUID").Value;
                slideButton.SlideID = iButton.Element("SlideID").Value;
                slideButton.ButtonName = iButton.Element("ButtonName").Value;
                slideButton.ScheduledSlideID = iButton.Element("ScheduledSlidSlideID").Value;
                slideButton.SlideGuidToNavigateTo = iButton.Element("SlideGuidToNavigateTo").Value;
                
                slideButtons.Add(slideButton);
            }
            return slideButtons;
        }

            private static Schedule.ModeEnum ConvertToMode(string modeString)
            {
                switch (modeString)
                {
                    case ("Default"):
                        return Schedule.ModeEnum.Default;
                    case ("DoNotMix"):
                        return Schedule.ModeEnum.DoNotMix;
                    case ("Intersperse"):
                        return Schedule.ModeEnum.Intersperse;
                    case ("Shuffle"):
                        return Schedule.ModeEnum.Shuffle;
                    default:
                        return Schedule.ModeEnum.Default;
                }
            }

            private static Schedule GetDefaultSchedule(XElement scheduleXML, DateTime _startDate, DateTime _startTime, DateTime _endDate, DateTime _endTime)
            {
                var validSchedule = new Schedule();
                validSchedule.StartDate = _startDate;
                validSchedule.EndDate = _endDate;
                validSchedule.StartTime = _startTime;
                validSchedule.EndTime = _endTime;
                validSchedule.GUID = scheduleXML.Element("GUID").Value;
                validSchedule.Name = scheduleXML.Element("Name").Value;
                validSchedule.Priority = int.Parse(scheduleXML.Element("Priority").Value);

                var schedSlides = new List<ScheduledSlide>();

                var slidesXML = scheduleXML.Elements("ScheduledSlides").Elements("ScheduledSlide");
                foreach (XElement slideXML in slidesXML)
                {
                    var validSlide = new ScheduledSlide();
                    validSlide.GUID = slideXML.Element("GUID").Value;
                    //  validSlide.Name = slideXML.Element("Name").Value;
                    validSlide.Transition = slideXML.Element("Transition").Value;
                    validSlide.TransitionSpeed = int.Parse(slideXML.Element("TransitionSpeed").Value);
                    validSlide.Duration = DateTime.Parse(slideXML.Element("Duration").Value);
                    validSlide.ScheduleId = slideXML.Element("ScheduleId").Value;
                    validSlide.OriginalSlideId = slideXML.Element("OriginalSlideId").Value;

                    schedSlides.Add(validSlide);
                }

                validSchedule.ScheduledSlides = schedSlides;
                return validSchedule;
            }

        #endregion

        #region Commands

        private void GoToSlideCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void GoToSlideExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            //if (_slide.GetType() == typeof(PlayListSlide))
            //{
            //    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
            //    {
            //        LoadSlide((ScheduledSlide)_slide);
            //        slideTimer.Start();
            //    }));
            //}
            if(sender == null) return;
            ScheduledSlide _slide = null;
            if (sender is PlayListSlide)
                _slide = sender as ScheduledSlide;
            if (_slide != null)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                {
                    LoadSlide(_slide);

                    if (SlideManager.ShouldTimerStart(_slide.GUID))
                    {
                        slideTimer.Interval = new TimeSpan(_slide.Duration.Value.Hour, _slide.Duration.Value.Minute, _slide.Duration.Value.Second);
                        slideTimer.Start();
                    }
                }));
            }
            else
            {
                PlayListSlide slide = new PlayListSlide();
                foreach (var playListSlide in SlideManager.SlidePlaylist)
                {
                    if (_slide.ToString() == playListSlide.OriginalSlideId)
                    {
                        slide = playListSlide;
                    }
                }
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                {
                    LoadSlide(slide);
                    slideTimer.Start();
                }));
            }
        }

        private void PlayNextSlideCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void PlayNextSlideExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (!SlideManager.TouchscreenOnFirstSlide)
            {
                AdvanceActiveSlide();
                PlayActiveSlide();
            }
            e.Handled = true;
        }

        private void PlayPreviousSlideCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void PlayPreviousSlideExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void RestartTimerCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void RestartTimerExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if(SlideManager.IsTouchscreenMode)
            {
                slideTimer.Stop();
                var duration = SlideManager.GetCurrentDuration();
                slideTimer.Interval = duration != null ? new TimeSpan(duration.Value.Hour, duration.Value.Minute, duration.Value.Second) : TimeSpan.FromSeconds(45);

                if (slideTimer.Interval < TimeSpan.FromSeconds(2))
                    slideTimer.Interval = TimeSpan.FromSeconds(45);
                slideTimer.Start();
            }
        }

        //private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if(SlideManager.IsTouchscreenMode)
        //        InspireCommands.RestartTimerCommand.Execute(this, this);
        //}

        private void Window_TouchDown(object sender, TouchEventArgs e)
        {
            if (SlideManager.IsTouchscreenMode)
                InspireCommands.RestartTimerCommand.Execute(this, this);
        }

        //private void SkipSlideCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        //private void SkipSlideCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        //{
        //    var test = e.Parameter.ToString();

        //    if (!skipSlides.Contains(test))
        //        skipSlides.Add(test);

        //}

        //private void DontSkipCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        //{
        //    var test = e.Parameter.ToString();

        //    if (!dontSkipList.Contains(test))
        //        dontSkipList.Add(test);
        //}

        //private void DontSkipCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        #endregion

    }
}

