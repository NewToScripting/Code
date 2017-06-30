using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Transitionals;
using Transitionals.Transitions;

namespace Inspire.Client.ScheduleWindow.ScheduledSlidePanel
{
    /// <summary>
    /// Interaction logic for SlideTransition.xaml
    /// </summary>
    public partial class SlideTransition
    {
        readonly Image slide1 = new Image();
        readonly Image slide2 = new Image();

        private string _transition;
        
        public string SelectedTransition
        {
            get { return _transition; }
            set { _transition = value; }
        }

        public SlideTransition() : this("Fade")
        {
            
        }

        public SlideTransition(string transition)
        {
            InitializeComponent();

            if (String.IsNullOrEmpty(transition))
                transition = "Fade";

            BitmapFrame bmf1 = BitmapFrame.Create(new Uri("pack://application:,,,/Inspire.Client.ScheduleWindow;component/ScheduledSlidePanel/Images/Slide1.jpg")); // TODO: change images
            BitmapFrame bmf2 = BitmapFrame.Create(new Uri("pack://application:,,,/Inspire.Client.ScheduleWindow;component/ScheduledSlidePanel/Images/Slide2.jpg"));

            slide1.Source = bmf1;
            slide2.Source = bmf2;

            teTransitionElement.Content = slide1;

            lbTransitions.ItemsSource = TransitionService.TransitionList;

            lbTransitions.SelectedItem = transition;

            //lbTransitions.SelectedIndex = _;

            //foreach (object trans in lbTransitions.Items)
            //{
            //    string fullname = "System.Windows.Controls.ListBoxItem: " + _transition;
            //    if (trans.ToString() == fullname)
            //    {
            //        lbTransitions.SelectedItem = trans;
            //        break;
            //    }
            //}
            //if(lbTransitions.Items.Contains(_transition))
            
            lbTransitions.SelectionChanged += lbTransitions_SelectionChanged;
        }

        void lbTransitions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedTransition = lbTransitions.SelectedItem.ToString();
            teTransitionElement.Transition = TransitionService.SetTransition(selectedTransition);
            teTransitionElement.Content = teTransitionElement.Content == slide1 ? slide2 : slide1;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            e.Handled = true;
            Close();
            
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            _transition = lbTransitions.SelectedIndex > -1 ? lbTransitions.SelectedItem.ToString() : "Fade";

            DialogResult = true;
            e.Handled = true;
            Close();
            
        }
    }
}
