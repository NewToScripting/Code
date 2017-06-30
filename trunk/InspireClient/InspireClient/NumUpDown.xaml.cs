using System;
using System.Windows;
using System.Windows.Controls;

namespace Inspire.Client
{
    public partial class NumUpDown : System.Windows.Controls.UserControl
    {
        /// <summary>
        /// Initializes a new instance of the NumUpDownControl.
        /// </summary>
        public NumUpDown()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Identifies the Value dependency property.
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value", typeof(string), typeof(NumUpDown),
                new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnValueChanged),
                                              new CoerceValueCallback(CoerceValue)));

        /// <summary>
        /// Gets or sets the value assigned to the control.
        /// </summary>
        public string Value
        {
            get { return GetValue(ValueProperty).ToString(); }
            set { SetValue(ValueProperty, value); }
        }

        private static object CoerceValue(DependencyObject element, object value)
        {
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                decimal newValue;
                if (decimal.TryParse(value.ToString(), out newValue))
                {
                    NumUpDown control = (NumUpDown) element;

                    newValue = Math.Max(MinValue, Math.Min(MaxValue, newValue));
                }

                return newValue.ToString();
            }

            return string.Empty;
        }

        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue != null && !string.IsNullOrEmpty(args.NewValue.ToString()))
            {
                NumUpDown control = (NumUpDown) obj;

                RoutedPropertyChangedEventArgs<string> e = new RoutedPropertyChangedEventArgs<string>(args.OldValue.ToString(), args.NewValue.ToString(), ValueChangedEvent);
                control.OnValueChanged(e);
            }
        }

        /// <summary>
        /// Identifies the ValueChanged routed event.
        /// </summary>
        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
            "ValueChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<string>), typeof(NumUpDown));

        /// <summary>
        /// Occurs when the Value property changes.
        /// </summary>
        public event RoutedPropertyChangedEventHandler<decimal> ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }

        /// <summary>
        /// Raises the ValueChanged event.
        /// </summary>
        /// <param name="args">Arguments associated with the ValueChanged event.</param>
        protected virtual void OnValueChanged(RoutedPropertyChangedEventArgs<string> args)
        {
            RaiseEvent(args);
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            double newValue;
            if (double.TryParse(Value, out newValue))
                newValue++;
            Value = newValue.ToString();

        }

        private void downButton_Click(object sender, EventArgs e)
        {
            decimal newValue;
            if (decimal.TryParse(Value, out newValue))
                newValue--;
            Value = newValue.ToString();
        }

        public static decimal MinValue = -12000, MaxValue = 12000;

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            double newValue;
            if (double.TryParse(((TextBox)sender).Text, out newValue))
            {
                Value = newValue.ToString();
            }
        }
    }
}
