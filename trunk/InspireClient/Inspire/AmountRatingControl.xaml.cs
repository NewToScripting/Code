using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Inspire
{
    /// <summary>
    /// Interaction logic for AmountRatingControl.xaml
    /// </summary>
    public partial class AmountRatingControl
    {
        public static readonly DependencyProperty RatingValueProperty = 
            DependencyProperty.Register("RatingValue", typeof(int), typeof(AmountRatingControl),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(RatingValueChanged)));


        private int _maxValue = 5;

        public int RatingValue
        {
            get { return (int)GetValue(RatingValueProperty); }
            set
            {
                if (value < 0)
                {
                    SetValue(RatingValueProperty, 0);
                }
                else if (value > _maxValue)
                {
                    SetValue(RatingValueProperty, _maxValue);
                }
                else
                {
                    SetValue(RatingValueProperty, value);
                }
            }
        }

        private static void RatingValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            AmountRatingControl parent = sender as AmountRatingControl;
            int ratingValue = (int)e.NewValue;
            UIElementCollection children = ((Grid)(parent.Content)).Children;
            ToggleButton button = null;

            for (int i = 0; i < ratingValue; i++)
            {
                button = children[i] as ToggleButton;
                if(button != null)
                    button.IsChecked = true;
            }

            for (int i = ratingValue; i < children.Count; i++)
            {
                button = children[i] as ToggleButton;
                if(button != null)
                    button.IsChecked = false;
            }
        }

        public AmountRatingControl()
        {
            InitializeComponent();
        }

        private void RatingButtonClickEventHandler(Object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;

            int newRating = int.Parse((String)button.Tag);

            if ((bool)button.IsChecked || newRating < RatingValue)
            {
                RatingValue = newRating;
            }
            else
            {
                RatingValue = newRating - 1;
            }

            e.Handled = true;
        }
    }
}
