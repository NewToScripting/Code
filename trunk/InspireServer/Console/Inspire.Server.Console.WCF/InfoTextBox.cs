using System.Windows;
using System.Windows.Controls;

namespace Inspire.Server.Console.Interface
{
    /// <summary>
    /// Custom textbox that shows a message in an empty textbox until it contains text.
    /// </summary>
    public class InfoTextBox : TextBox
    {
        static InfoTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InfoTextBox), new FrameworkPropertyMetadata(typeof(InfoTextBox)));

            TextProperty.OverrideMetadata(
                typeof(InfoTextBox),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(TextPropertyChanged)));
        }

        public static readonly DependencyProperty TextBoxInfoProperty = DependencyProperty.Register(
            "TextBoxInfo",
            typeof(string),
            typeof(InfoTextBox),
            new PropertyMetadata(string.Empty));

        public string TextBoxInfo
        {
            get { return (string)GetValue(TextBoxInfoProperty); }
            set { SetValue(TextBoxInfoProperty, value); }
        }

        private static readonly DependencyPropertyKey HasTextPropertyKey = DependencyProperty.RegisterReadOnly(
            "HasText",
            typeof(bool),
            typeof(InfoTextBox),
            new FrameworkPropertyMetadata(false));

        public static readonly DependencyProperty HasTextProperty = HasTextPropertyKey.DependencyProperty;

        public bool HasText
        {
            get
            {
                return (bool)GetValue(HasTextProperty);
            }
        }

        /// <summary>
        /// Text Property Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        static void TextPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            InfoTextBox itb = (InfoTextBox)sender;

            bool actuallyHasText = itb.Text.Length > 0;
            if (actuallyHasText != itb.HasText)
            {
                itb.SetValue(HasTextPropertyKey, actuallyHasText);
            }
        }
    }
}