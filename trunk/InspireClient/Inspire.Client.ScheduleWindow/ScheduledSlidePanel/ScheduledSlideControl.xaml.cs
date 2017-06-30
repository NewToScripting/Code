using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Inspire.Server.Proxy;

namespace Inspire.Client.ScheduleWindow.ScheduledSlidePanel
{
    /// <summary>
    /// Interaction logic for ScheduledSlideControl.xaml
    /// </summary>
    public partial class ScheduledSlideControl
    {
        public ScheduledSlideControl()
        {
            InitializeComponent();
            SlideControlItems = new ObservableCollection<SlideControlItem>();
            ScheduledSlidePanel.ItemsSource = SlideControlItems;

            _isEditMode = false;
            _isNoEditShowing = true;
        }

        public ObservableCollection<SlideControlItem> SlideControlItems { get; set; }

        private bool _isEditMode;

        private bool _isNoEditShowing;

        private void ScheduledSlidePanel_Drop(object sender, DragEventArgs e)
        {
            if (_isEditMode)
            {
                DropGrabber.Visibility = Visibility.Collapsed;

                SlideControlItem slideControlItem = e.Data.GetData(typeof (SlideControlItem)) as SlideControlItem;

                if (slideControlItem != null)
                {
                    SlideControlItems.Add(slideControlItem);
                    return;
                }
            }
            e.Handled = true;
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);

            if (!_isEditMode && !_isNoEditShowing)
            {
                ShowNoEditPrompt();
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if(!_isEditMode && !_isNoEditShowing)
            {
                this.ShowNoEditPrompt();
            }
            else if(_isEditMode)
            {
                PART_No_Slide_Grid.Visibility = Visibility.Collapsed;
            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);

            if (_isNoEditShowing)
            {
                HideNoEditPrompt();
            }
        }

        public void SetEditMode(bool editMode)
        {
            if (editMode)
            {
                _isEditMode = true;

                if (_isNoEditShowing)
                {
                    HideNoEditPrompt();
                }
                else
                    PART_No_Slide_Grid.Visibility = Visibility.Collapsed;
            }
            else
            {
                _isEditMode = false;
                if (!_isNoEditShowing)
                {
                    PART_No_Slide_Grid.Visibility = Visibility.Visible;
                   // ShowNoEditPrompt();
                }
            }
        }

        private void ShowNoEditPrompt()
        {
            _isNoEditShowing = true;

            Storyboard storyboard = new Storyboard();
            TimeSpan duration = new TimeSpan(0, 0, 1);

            // Create a DoubleAnimation to fade the not selected option control
            DoubleAnimation animation = new DoubleAnimation();

            //animation.From = 0.0;
            animation.To = 1.0;
            animation.Duration = new Duration(duration);
            // Configure the animation to target de property Opacity
            Storyboard.SetTargetName(animation, PART_No_Slide_Grid.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(OpacityProperty));
            // Add the animation to the storyboard
            storyboard.Children.Add(animation);

            // Begin the storyboard
            storyboard.Begin(this);
        }

        private void HideNoEditPrompt()
        {
            _isNoEditShowing = false;

            Storyboard storyboard = new Storyboard();
            TimeSpan duration = new TimeSpan(0, 0, 1);

            // Create a DoubleAnimation to fade the not selected option control
            DoubleAnimation animation = new DoubleAnimation();

            animation.To = 0.0;
            animation.Duration = new Duration(duration);
            // Configure the animation to target de property Opacity
            Storyboard.SetTargetName(animation, PART_No_Slide_Grid.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(OpacityProperty));
            // Add the animation to the storyboard
            storyboard.Children.Add(animation);

            // Begin the storyboard
            storyboard.Begin(this);
        }

        public void Clear()
        {
            SlideControlItems.Clear();
            InspireApp.CurrentScheduleGuidLoaded = string.Empty;
        }

        //public List<ScheduledSlide> GetScheduledSlides(Schedule sched)
        //{
        //    List<ScheduledSlide> schedSlides;

        //    if (sched.ScheduledSlides == null)
        //        schedSlides = new List<ScheduledSlide>();
        //    else
        //        schedSlides = sched.ScheduledSlides;


        //    foreach (SlideControlItem _slideCI in ScheduledSlidePanel.Items)
        //    {
        //        ScheduledSlide _scheduledslide = new ScheduledSlide();
        //        _scheduledslide.OriginalSlideId = _slideCI.ScheduledSlide.OriginalSlideId;
        //       _scheduledslide.ScheduleId = sched.GUID;
        //       _scheduledslide.Name = _slideCI.ScheduledSlide.Name;
        //        _scheduledslide.Description = _slideCI.ScheduledSlide.Description;
        //        _scheduledslide.ThumbNail = _slideCI.ScheduledSlide.ThumbNail;
        //        // Note: Decide where to convert to hour min sec from DateTime
        //        DateTime? dtConvert = _slideCI.dtiDuration.Value;
        //        int seconds = dtConvert.Value.Hour * 3600 + dtConvert.Value.Minute * 60 + dtConvert.Value.Second;
        //        _scheduledslide.Duration = DateTime.Today.Date.AddSeconds(seconds);
        //        _scheduledslide.Transition = _slideCI.ScheduledSlide.Transition;
        //        if (_scheduledslide.Transition == null)
        //            _scheduledslide.Transition = "Fade";
        //        _scheduledslide.TransitionSpeed = 1;

        //        schedSlides.Add(_scheduledslide);
        //    }
        //    return schedSlides;
        //}

        //public List<ScheduledSlide> GetScheduledSlides(string schedId)
        //{
        //    List<ScheduledSlide> schedSlides = new List<ScheduledSlide>();

        //    foreach (SlideControlItem _slideCI in ScheduledSlidePanel.Items)
        //    {
        //        ScheduledSlide _scheduledslide = new ScheduledSlide();
        //        _scheduledslide.OriginalSlideId = _slideCI.ScheduledSlide.OriginalSlideId;
        //        _scheduledslide.ScheduleId = schedId;
        //        _scheduledslide.Name = _slideCI.ScheduledSlide.Name;
        //        _scheduledslide.Description = _slideCI.ScheduledSlide.Description;
        //        _scheduledslide.ThumbNail = _slideCI.ScheduledSlide.ThumbNail;
        //        // Note: Decide where to convert to hour min sec from DateTime
        //        DateTime? dtConvert = _slideCI.dtiDuration.Value;
        //        int seconds = dtConvert.Value.Hour * 3600 + dtConvert.Value.Minute * 60 + dtConvert.Value.Second;
        //        _scheduledslide.Duration = DateTime.Today.Date.AddSeconds(seconds);
        //        _scheduledslide.Transition = _slideCI.ScheduledSlide.Transition;
        //        if (_scheduledslide.Transition == null)
        //            _scheduledslide.Transition = "Fade";
        //        _scheduledslide.TransitionSpeed = 1;

        //        schedSlides.Add(_scheduledslide);
        //    }
        //    return schedSlides;
        //}

        public List<ScheduledSlide> GetSlidesForPreview(string _scheduleGuid)
        {
            List<ScheduledSlide> schedSlides = new List<ScheduledSlide>();

            foreach (SlideControlItem _slideCI in ScheduledSlidePanel.Items)
            {
                ScheduledSlide _scheduledslide = new ScheduledSlide();
                _scheduledslide.OriginalSlideId = _slideCI.ScheduledSlide.OriginalSlideId;
                _scheduledslide.Name = _slideCI.ScheduledSlide.Name;
                _scheduledslide.Description = _slideCI.ScheduledSlide.Description;
                _scheduledslide.ScheduleId = _scheduleGuid;

                _scheduledslide.ThumbNail = _slideCI.ScheduledSlide.ThumbNail;
                // Note: Decide where to convert to hour min sec from DateTime
               // DateTime? dtConvert = _slideCI.dtiDuration.Value;
                //int seconds = dtConvert.Value.Hour * 3600 + dtConvert.Value.Minute * 60 + dtConvert.Value.Second;

                _scheduledslide.Duration = _slideCI.ScheduledSlide.Duration;
                //_scheduledslide.Duration = DateTime.Today.Date.AddSeconds(seconds);
                _scheduledslide.Transition = _slideCI.ScheduledSlide.Transition;
                if (_scheduledslide.Transition == null)
                    _scheduledslide.Transition = "Fade";
                _scheduledslide.TransitionSpeed = 1;

                schedSlides.Add(_scheduledslide);

            }
            return schedSlides;
        }

        public void LoadSlides(IEnumerable<ScheduledSlide> _scheduledSlides)
        {
            SlideControlItems.Clear();

            foreach (ScheduledSlide _scheduledslide in _scheduledSlides)
            {
                SlideControlItem _slideCI = new SlideControlItem(_scheduledslide);

                // Convert the Byte Array of the image to an image stream to set as the source
                BitmapImage slideImage = new BitmapImage();
                slideImage.BeginInit();
                if (_scheduledslide.ThumbNail != null)
                {
                    Stream ImageStream = new MemoryStream(_scheduledslide.ThumbNail);
                    
                    slideImage.StreamSource = ImageStream;
                    slideImage.EndInit();

                    _slideCI.imgSlideImage.Source = slideImage;
                    
                }
                _slideCI.ScheduledSlide.Transition = _scheduledslide.Transition;
               // _slideCI.dtiDuration.Value = _scheduledslide.Duration.Value;
                _slideCI.ScheduledSlide.Buttons = _scheduledslide.Buttons;
                _slideCI.ScheduledSlide.Duration = _scheduledslide.Duration;
                _slideCI.ScheduledSlide.Rules = _scheduledslide.Rules;
                _slideCI.ScheduledSlide.Tags = _scheduledslide.Tags;
                _slideCI.ScheduledSlide.GUID = _scheduledslide.GUID;
                _slideCI.ScheduledSlide.Name = _scheduledslide.Name;
                _slideCI.ScheduledSlide.Description = _scheduledslide.Description;
                _slideCI.ScheduledSlide.OriginalSlideId = _scheduledslide.OriginalSlideId;

                SlideControlItems.Add(_slideCI);
            }

            InvalidateVisual();
        }

        private void btnSlideRight_Click(object sender, RoutedEventArgs e)
        {
            ScrollViewer listViewScrollViewer = new ScrollViewer();

            DependencyObject border = VisualTreeHelper.GetChild(ScheduledSlidePanel, 0); 
                    if (border != null) 
                    { 
                        listViewScrollViewer = VisualTreeHelper.GetChild(border, 0) as ScrollViewer; 
                    } 

            if (listViewScrollViewer != null)
            {
                listViewScrollViewer.ScrollToHorizontalOffset(listViewScrollViewer.HorizontalOffset + 1);
            }
        }

        private void SlideGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DropGrabber.Visibility = Visibility.Collapsed;
        }

        private void btnSlideLeft_Click(object sender, RoutedEventArgs e)
        {
            ScrollViewer listViewScrollViewer = new ScrollViewer();

            DependencyObject border = VisualTreeHelper.GetChild(ScheduledSlidePanel, 0);
            if (border != null)
            {
                listViewScrollViewer = VisualTreeHelper.GetChild(border, 0) as ScrollViewer;
            }

            if (listViewScrollViewer != null)
            {
                listViewScrollViewer.ScrollToHorizontalOffset(listViewScrollViewer.HorizontalOffset - 1);
            }
        }

    }
}
