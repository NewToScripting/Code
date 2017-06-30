using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Inspire.Client.Designer.DragCanvas;
using Inspire.Commands;
using Inspire.Common.Dialogs;
using Inspire.Common.Utility;
using Inspire.Server.Proxy;
using Inspire.Services.WeakEventHandlers;
using Transitionals;
using System.Timers;
using System.Diagnostics;

namespace Inspire.Client.ScheduleWindow.Dialogs
{
    /// <summary>
    /// Interaction logic for PreviewCanvas.xaml
    /// </summary>
    public partial class PreviewCanvas : IWeakEventListener
    {
        private readonly List<ScheduledSlide> scheduledSlides;
        private readonly List<ScheduledSlide> slidePlaylist;
        private int currentSlide;

        protected static DispatcherTimer nextSlideTimer;

        private static readonly Timer _timer = new Timer();
        private readonly Stopwatch _sw = new Stopwatch();
        private string _timeString = String.Empty;
        private readonly Schedule.ScheduleTypeEnum? _scheduleType;
        private List<KeyValuePair<string, string>> _currentButtonNavigations;

        public PreviewCanvas(List<ScheduledSlide> _scheduledSlides, string displayGuid, Schedule.ScheduleTypeEnum? scheduleType)
        {
            InitializeComponent();

            _scheduleType = scheduleType;

            CommandBindings.Add(new CommandBinding(InspireCommands.TouchNavigateCommand, TouchNavigationExecuted, TouchNavigationCanExecute));
            CommandBindings.Add(new CommandBinding(InspireCommands.PlayNextSlideCommand, PlayNextSlideExecuted, PlayNextSlideCanExecute));

            scheduledSlides = _scheduledSlides;

            slidePlaylist = new List<ScheduledSlide>();
            LoadedEventManager.AddListener(this, this);
            lbSlides.SelectionChanged += lbSlides_SelectionChanged;

            InspireApp.IsPreviewMode = true;
            InspireApp.IsPlaying = true;
        }

        private void PlayNextSlideCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PlayNextSlideExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            NextSlide();
        }

        private static void TouchNavigationCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void TouchNavigationExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var sedingGuid = e.Parameter.ToString();

            var selectedGuid = _currentButtonNavigations.FirstOrDefault(c => c.Key == sedingGuid).Value;

            var selectedSlide = slidePlaylist.FirstOrDefault(s => s.GUID == selectedGuid);

            if (selectedSlide != null)
            {
                int slideIndex = slidePlaylist.IndexOf(selectedSlide); //currentSlide = slidePlaylist.IndexOf(selectedSlide);
                lbSlides.SelectedItem = lbSlides.Items[slideIndex];
            }

            //if(selectedSlide != null)
            //{
            //    LoadCanvasXamlDelegate loadCanvasXamlDelegate = SlideXamlToCanvas;
            //    try
            //    {
            //        Dispatcher.Invoke(DispatcherPriority.Normal, loadCanvasXamlDelegate, selectedSlide, "Client");
            //    }
            //    catch (Exception)
            //    {
            //        Dispatcher.Invoke(DispatcherPriority.Normal, loadCanvasXamlDelegate, selectedSlide, "Client");
            //    }
            //}
        }

        private void ResumeTimers()
        {
            _timeString = "00:00:00";
            _sw.Start();
            _timer.Enabled = true;
            if (nextSlideTimer != null)
                nextSlideTimer.Start();
        }

        public void StartTimer(DateTime? duration)
        {
            if (duration != null)
                nextSlideTimer.Interval = TimeSpan.FromHours(duration.Value.Hour) + TimeSpan.FromMinutes(duration.Value.Minute) + TimeSpan.FromSeconds(duration.Value.Second);

            _sw.Reset();
            _timeString = "00:00:00";

            if (_scheduleType != null && (_scheduleType != Schedule.ScheduleTypeEnum.Touchscreen || (_scheduleType == Schedule.ScheduleTypeEnum.Touchscreen && currentSlide > 0)))
            {
                _sw.Start();
                _timer.Enabled = true;

                if (nextSlideTimer != null)
                    nextSlideTimer.Start();
            }
            else
                nextSlideTimer.Stop();
        }

        public void StopTimer()
        {
            _sw.Stop();
            _sw.Reset();
            _timer.Enabled = false;
            if (nextSlideTimer != null)
                nextSlideTimer.Stop();
        }

        void lbSlides_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            currentSlide = lbSlides.SelectedIndex;

            LoadCanvasXamlDelegate loadCanvasXamlDelegate = SlideXamlToCanvas;
            if (slidePlaylist.Count > 0)
                try
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, loadCanvasXamlDelegate, slidePlaylist[currentSlide], "Client");
                }
                catch (Exception)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, loadCanvasXamlDelegate, slidePlaylist[0], "Client");
                }


            e.Handled = true;
        }

        private delegate void LoadCanvasXamlDelegate(ScheduledSlide slide, string displayGuid);

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timeString = _sw.Elapsed.Minutes.ToString("00") + ":" + _sw.Elapsed.Seconds.ToString("00") + ":" +
                          _sw.Elapsed.Milliseconds.ToString("00").Substring(0, 2);
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => tbTimer.Text = _timeString));
        }

        void PreviewCanvas_Loaded(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => tbTimer.Text = "00:00:00"));

            _timer.Interval = 100;
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);

            nextSlideTimer = new DispatcherTimer();
            nextSlideTimer.Tick += nextSlideTimer_Tick;

            lbSlides.ItemsSource = scheduledSlides;

            ProgressDialog dialog = new ProgressDialog();
            dialog.Owner = this;
            dialog.ShowProgressBar = true;
            dialog.DialogText = "Loading Slides. Please wait....";

            if (SchedulerPreview != null)
            {

                dialog.RunWorkerThread(GetSlidesFromServer);

                if (dialog.Error != null)
                {
                    String msg = "An error occurred on the worker thread:\n\n {0}";
                    msg = String.Format(msg, dialog.Error);
                    MessageBox.Show(msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private delegate void SelectFirstItemDelegate();

        private void GetSlidesFromServer(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;

            const string message = "Loading Slides From Server...";

            worker.ReportProgress(int.MinValue, message);

            Files.ClearDirectory(Paths.ClientPlaybackTempDirectory);

            int currentSlideCount = 1;

            foreach (var scheduledSlide in scheduledSlides)
            {
                worker.ReportProgress(Convert.ToInt32((currentSlideCount * 100) / scheduledSlides.Count), "Loading slide " + currentSlideCount + " of " + scheduledSlides.Count);
                currentSlideCount++;

                var slidefile = SlideManager.GetSlideFile(scheduledSlide.OriginalSlideId, worker, false); // TODO: only get files for distinct slides, interspersed slides can be duplicates

                string filename = Paths.ClientPlaybackTempDirectory + slidefile.GUID + ".insp";

                if (!File.Exists(filename) && slidefile.File != null)
                {
                    Files.SaveStreamToFile(slidefile.File, filename);

                    slidefile.File = null;

                    scheduledSlide.HResolution = slidefile.HResolution;
                    scheduledSlide.VResolution = slidefile.VResolution;

                    slidePlaylist.Add(scheduledSlide);

                    ZipUtil.NewUnZipFiles(filename, Paths.ClientPlaybackTempDirectory + slidefile.GUID, "wookie", true);
                    if (File.Exists(filename))
                        // Probably will want to spin the delete off to another thread to speed things up // TODO: do this for all deletes, make a delete class in framework to spin off delete jobs - background worker
                        File.Delete(filename);
                }
            }

            SelectFirstItemDelegate selectFirstItemDelegate = SelectFirstItem;

            Dispatcher.BeginInvoke(DispatcherPriority.Normal, selectFirstItemDelegate);
        }

        private void SelectFirstItem()
        {
            if (lbSlides.Items.Count > 0)
            {
                lbSlides.IsHitTestVisible = true;
                lbSlides.SelectedIndex = 0;
            }
        }

        void nextSlideTimer_Tick(object sender, EventArgs e)
        {
            NextSlide();
        }

        private void SlideXamlToCanvas(ScheduledSlide slide, string displayGuid)
        {
            var context = new ParserContext
            {
                BaseUri =
                    new Uri(Paths.ClientPlaybackTempDirectory + slide.OriginalSlideId + @"/",
                            UriKind.Absolute)
            };

            try
            {
                InspireApp.CurrentSlideGuid = slide.OriginalSlideId;

                Canvas canvas;
                using (FileStream fileStream = new FileStream(Paths.ClientPlaybackTempDirectory + slide.OriginalSlideId + @"/" + "Canvas.xaml", FileMode.Open,
                               FileAccess.Read))
                {

                    canvas = (Canvas)XamlReader.Load(fileStream, context);
                    fileStream.Dispose();
                }

                if (canvas != null)
                {
                    canvas.ClipToBounds = true;
                    canvas.Width = slide.HResolution;
                    canvas.Height = slide.VResolution;

                    if (canvas.Background == null)
                        canvas.Background = Brushes.Black;

                    InspireApp.CurrentPreviewCanvas = canvas; // set the current preview canvas so that we can dig through the controls when directing commands
                }

                _currentButtonNavigations = GetButtonNavigations(slide.Buttons);

                SchedulerPreview.Transition = TransitionService.SetTransition(slide.Transition);
                
                SchedulerPreview.Content = canvas; //LoadXMLtoCanvas(canvas, slide);

                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => DragCanvas.AttachReflections(canvas.Children)));

                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => tbTimer.Text = _timeString));

                StartTimer(slide.Duration);
            }
            catch (Exception)
            {
                var commonDialog = new CommonDialog("Error", "An error occured while saving/loading slide. Try refreshing your slides, and or reloading/resaving.");
                commonDialog.ShowDialog();
                //MessageBox.Show("Unable to load the slide"); // TODO: Gracefull error handling
                //throw;
            }

            // InvalidateVisual();

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

        protected override void OnClosed(EventArgs e)
        {
            try
            {
                InspireApp.PlaybackHostName = null;
                InspireApp.IsPreviewMode = false;
                InspireApp.IsPlaying = false;

                InspireApp.CurrentPreviewCanvas = null;

                SchedulerPreview.Content = null;
                var scheduledS = lbSlides.ItemsSource as List<ScheduledSlide>;
                scheduledS.Clear();
                Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                       new Action(() => Files.ClearDirectory(Paths.ClientPlaybackTempDirectory)));

                nextSlideTimer.Stop();
                _timer.Stop();
                _sw.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            base.OnClosed(e);
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (lbSlides.Items.Count > 0)
            {
                if (currentSlide == 0)
                    lbSlides.SelectedItem = lbSlides.Items[lbSlides.Items.Count - 1];
                else
                {
                    currentSlide--;
                    lbSlides.SelectedItem = lbSlides.Items[currentSlide];
                }
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            StopTimer();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            ResumeTimers();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            NextSlide();
        }

        private void NextSlide()
        {
            if (lbSlides.Items.Count > 0)
            {
                if (currentSlide == lbSlides.Items.Count - 1 || (_scheduleType != null && (_scheduleType == Schedule.ScheduleTypeEnum.Touchscreen && currentSlide > 0)))
                    lbSlides.SelectedItem = lbSlides.Items[0];
                else
                {
                    currentSlide++;
                    lbSlides.SelectedItem = lbSlides.Items[currentSlide];
                }
            }
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                PreviewCanvas_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion

    }
}