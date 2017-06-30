using System.Windows;
using Inspire.Client.ScheduleWindow.ScheduledSlidePanel;

namespace Inspire.Client.ScheduleWindow.Dialogs
{
    /// <summary>
    /// Interaction logic for SlideTransitionDialog.xaml
    /// </summary>
    public partial class SlideTransitionDialog
    {
        public string SelectedTransition { get; set; }

        public SlideTransitionDialog()
        {
            InitializeComponent();
            SelectedTransition = "Fade";
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SlideTransition slideTransition = new SlideTransition("Fade");
            slideTransition.ShowDialog();
            if(slideTransition.DialogResult == true)
            {
                SelectedTransition = slideTransition.SelectedTransition;
                tbTransitionName.Text = SelectedTransition;
            }
        }
    }
}
