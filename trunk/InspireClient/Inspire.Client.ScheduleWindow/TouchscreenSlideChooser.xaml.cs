using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Inspire.Client.ScheduleWindow
{
    /// <summary>
    /// Interaction logic for TouchscreenSlideChooser.xaml
    /// </summary>
    public partial class TouchscreenSlideChooser
    {
        public string ChoosenGuid { get; set; }

        public TouchscreenSlideChooser()
        {
            InitializeComponent();
        }

        public TouchscreenSlideChooser(IEnumerable<ScheduledSlide> scheduledSlides, ButtonViewModel selectedButton, string currentSlideGuid)
            : this()
        {
            ChoosenGuid = string.Empty;

            DataContext = selectedButton;

            lbTouchscreenSlides.ItemsSource = new ObservableCollection<ScheduledSlide>(scheduledSlides.Where(s => s.GUID != currentSlideGuid));
        }

        private void ChooseSlide(object sender, MouseButtonEventArgs e)
        {
            var choosenSlide = ((FrameworkElement)sender).DataContext as ScheduledSlide;
            if (choosenSlide != null) ChoosenGuid = choosenSlide.GUID;
            DialogResult = true;
        }

        private void ClearLink_Click(object sender, RoutedEventArgs e)
        {
            var choosenSlide = ((FrameworkElement)sender).DataContext as ScheduledSlide;
            if (choosenSlide != null) ChoosenGuid = string.Empty;
            DialogResult = true;
        }
    }
}
