using System;
using System.Windows;
using Inspire.Client.ScheduleWindow.ScheduledSlidePanel;

namespace Inspire.Client.ScheduleWindow
{
    /// <summary>
    /// Interaction logic for SlideTimeDialog.xaml
    /// </summary>
    public partial class SlideTimeDialog
    {
        public DateTime SelectedDateTime { get { return dtiDuration.Value.Value; } }
        public string SelectedTransition { get; set; }

        //private readonly string _selectedTransition = "Fade";

        public SlideTimeDialog()
        {
            InitializeComponent();
            SelectedTransition = "Fade";
            dtiDuration.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 10);
        }

        public SlideTimeDialog(ScheduledSlide slide, Schedule.ScheduleTypeEnum schedType, string transition)
        {
            InitializeComponent();

            SelectedTransition = transition;

            if(slide.DefaultDuration != null)
                dtiDuration.Value = slide.DefaultDuration.Value;

            if (schedType == Schedule.ScheduleTypeEnum.Touchscreen)
                tbText.Text = "Set the amount of time that the slide will remain on the screen for after no activity before returning to the home slide:";

            if (slide.DefaultDuration == null || (slide.DefaultDuration.Value.Hour.Equals(0) && slide.DefaultDuration.Value.Minute.Equals(0) && slide.DefaultDuration.Value.Second.Equals(10)))
            {
                dtiDuration.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 10);
                tbDefaultText.Visibility = Visibility.Collapsed;
            }
        }

        private void btnOk_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var slideTransition = new SlideTransition(SelectedTransition);
            slideTransition.ShowDialog();
            if (slideTransition.DialogResult == true)
            {
                SelectedTransition = slideTransition.SelectedTransition;
                tbTransitionName.Text = SelectedTransition;
            }
        }
    }
}
