using System.Windows;

namespace Inspire.Common.Dialogs
{
    /// <summary>
    /// Interaction logic for TextPrompt.xaml
    /// </summary>
    public partial class TextPrompt : Window
    {
        public string Text { get; set; }

        public TextPrompt()
        {
            InitializeComponent();
        }

        public TextPrompt(string title, string lblQuestion, string tbText, string tbName, string textBoxWaterMark)
        {
            InitializeComponent();
            Title = title;
            tbLabel.Text = lblQuestion;
            tbTextBoxHeader.Text = tbName;
            tbTextBox.Text = tbText;
            tbTextBox.TextBoxInfo = textBoxWaterMark;
        }

        public TextPrompt(string title, string question, string tbText, string tbName, string isTrue, string isFalse, string textBoxWaterMark)
        {
            InitializeComponent();
            Title = title;
            tbLabel.Text = question;
            tbTextBoxHeader.Text = tbName;
            tbTextBox.Text = tbText;
            tbTextBox.TextBoxInfo = textBoxWaterMark;
            btnLeft.Content = isTrue;
            btnRight.Content = isFalse;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Text = tbTextBox.Text;
            DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
