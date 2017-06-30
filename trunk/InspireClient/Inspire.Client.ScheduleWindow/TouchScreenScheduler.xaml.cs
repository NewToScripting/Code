using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Inspire.Client.ScheduleWindow
{
    /// <summary>
    /// Interaction logic for TouchScreenScheduler.xaml
    /// </summary>
    public partial class TouchScreenScheduler
    {
        private ObservableCollection<ScheduledSlide> _scheduledSlides;

        private ObservableCollection<ButtonViewModel> _buttons;
        public ObservableCollection<ButtonViewModel> Buttons
        {
            get { return _buttons; }
            set { _buttons = value; }
        }

        public TouchScreenScheduler()
        {
            InitializeComponent();
        }

        public void SetTouchScreenButtons(ScheduledSlide scheduledSlide, List<ScheduledSlide> scheduledSlides)
        {
            DataContext = scheduledSlide;
            _scheduledSlides = new ObservableCollection<ScheduledSlide>(scheduledSlides);

            if (scheduledSlide.Buttons == null || scheduledSlide.Buttons.Count <= 0) return;
            _buttons = new ObservableCollection<ButtonViewModel>();

            foreach (var touchScreenButton in scheduledSlide.Buttons)
            {
                var matchingSlide = scheduledSlides.FirstOrDefault(s => s.GUID == touchScreenButton.SlideGuidToNavigateTo);
                _buttons.Add(matchingSlide != null ? new ButtonViewModel(matchingSlide, scheduledSlide.GUID, touchScreenButton.ButtonName, touchScreenButton.GUID, touchScreenButton.SlideID) : new ButtonViewModel(touchScreenButton, scheduledSlide.GUID));
            }
            lbTouchscreenSlides.ItemsSource = _buttons;
        }

        private void ShowAvailableSlides_Click(object sender, RoutedEventArgs e)
        {
            var buttonView = ((FrameworkElement) sender).DataContext as ButtonViewModel;

            var tsChooser = new TouchscreenSlideChooser(_scheduledSlides, buttonView, buttonView.SlideFromGuid);
            tsChooser.ShowDialog();
            if (tsChooser.DialogResult != true) return;

            int btnIndex = _buttons.IndexOf(buttonView);

            _buttons[btnIndex] = new ButtonViewModel(_scheduledSlides.FirstOrDefault(s => s.GUID == tsChooser.ChoosenGuid), buttonView.SlideFromGuid, buttonView.ButtonName, buttonView.GUID, buttonView.OriginalSlideGuid);
            
            lbTouchscreenSlides.ItemsSource = new ObservableCollection<ButtonViewModel>(_buttons);
        }

        public SlideButtons GetButtons()
        {
            return ConvertToSlideButtons(_buttons);
        }

        private static SlideButtons ConvertToSlideButtons(IEnumerable<ButtonViewModel> buttons)
        {
            var slideButtons = new SlideButtons();
            if(buttons != null)
            {
                slideButtons.AddRange(buttons.Select(buttonViewModel => new SlideButton
                {
                    ButtonName = buttonViewModel.ButtonName, GUID = buttonViewModel.GUID, SlideGuidToNavigateTo = buttonViewModel.SlideToGuid, SlideID = buttonViewModel.OriginalSlideGuid //JBH need scheduledslideid
                }).ToList());
            }
            return slideButtons;
        }
    }
}
