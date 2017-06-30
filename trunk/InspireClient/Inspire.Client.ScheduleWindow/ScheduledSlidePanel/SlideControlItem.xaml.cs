using System;
using System.Windows;
using System.Windows.Controls;

namespace Inspire.Client.ScheduleWindow.ScheduledSlidePanel
{
    /// <summary>
    /// Interaction logic for SlideControlItem.xaml
    /// </summary>
    public partial class SlideControlItem
    {
        private ScheduledSlide scheduledslide;

        public SlideControlItem()
        {
            InitializeComponent();
        }

        public SlideControlItem(ScheduledSlide _slide)
        {
            InitializeComponent();
            scheduledslide = _slide;

            DataContext = _slide;


            //// Convert the Byte Array of the image to an image stream to set as the source
            ScheduledSlide.ThumbNail = _slide.ThumbNail;
            //if(_slide.ThumbNail != null)
            //{
            //    BitmapImage slideImage = new BitmapImage();
            //    slideImage.BeginInit();
            //    Stream ImageStream = new MemoryStream(_slide.ThumbNail);
                
            //    slideImage.StreamSource = ImageStream;
            //    slideImage.EndInit();

            //    imgSlideImage.Source = slideImage;

            //    if(imgSlideImage.Source.CanFreeze)
            //        imgSlideImage.Source.Freeze();

            //}

            //dtiDuration.Value = DateTime.Today.AddSeconds(10);

        }

        public ScheduledSlide ScheduledSlide
        {
            get { return scheduledslide; }
            set { scheduledslide = value; }
        }

        private void DeleteSlide(object sender, RoutedEventArgs e)
        {

            MenuItem mItem = (MenuItem)sender;   
            ContextMenu cMenu = (ContextMenu)mItem.Parent;
            Grid gr1 = (Grid)cMenu.PlacementTarget;
            SlideControlItem sci = (SlideControlItem)gr1.Parent;

            if (Application.Current.Windows.Count > 0)
            {
                UserControl SchedulerWindow = Application.Current.Windows[0].FindName("SchedulerWindow") as UserControl;

                if (SchedulerWindow != null)
                {
                    ScheduledSlideControl scheduledSlideControl =
                        SchedulerWindow.FindName("SchedulerSlideControl") as ScheduledSlideControl;

                    if (scheduledSlideControl != null) scheduledSlideControl.SlideControlItems.Remove(sci);
                }
            }
        }

        private void btnTransition_Click(object sender, RoutedEventArgs e)
        {

            SlideTransition stForm = new SlideTransition(scheduledslide.Transition);
            stForm.ShowDialog();
            if (stForm.SelectedTransition != null)
                scheduledslide.Transition = stForm.SelectedTransition;
            e.Handled = true;
        }

        //private void ScheduledSlide_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    SlideControlItem scheduleGrid = (SlideControlItem) ((Grid)sender).Parent;
            
        //    DragDrop.DoDragDrop(this, scheduleGrid, DragDropEffects.Copy);
        //}

        //private void LayoutRoot_Drop(object sender, DragEventArgs e)
        //{

        //}

        //private void ScheduledSlide_Drop(object sender, DragEventArgs e)
        //{
        //    Slide _slide = e.Data.GetData(typeof(Slide)) as Slide;
        //    UserControl SchedulerWindow = Application.Current.Windows[0].FindName("SchedulerWindow") as UserControl;
    
        //    ScheduledSlideControl scheduledSlideControl = SchedulerWindow.FindName("SchedulerSlideControl") as ScheduledSlideControl;
            
        //    if (_slide != null)
        //    {

        //        ScheduledSlide _scheduledslide = new ScheduledSlide(_slide);

                
        //        scheduledSlideControl.AddSlide(2,new SlideControlItem(_scheduledslide), null);
        //        return;
        //    }

        //    if (true)
        //        _slide = e.Data.GetData(typeof(SlideFile)) as Slide;

        //    if (_slide != null)
        //    {
        //        Slide _slideFile = e.Data.GetData(typeof(SlideFile)) as Slide;

        //        ScheduledSlide _scheduledslide = new ScheduledSlide(_slideFile);

        //        scheduledSlideControl.AddSlide(2, new SlideControlItem(_scheduledslide), null);
        //    }
        //}
    }
}
