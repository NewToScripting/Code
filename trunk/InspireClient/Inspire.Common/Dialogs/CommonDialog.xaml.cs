using System.Windows;
using System.Windows.Input;

namespace Inspire.Common.Dialogs
{
    /// <summary>
    /// Interaction logic for CommonDialog.xaml
    /// </summary>
    public partial class CommonDialog
    {
        public CommonDialog()
        {
            InitializeComponent();
        }

        public CommonDialog(string title, string lblQuestion) : this()
        {
            Title = title;
            tbLabel.Text = lblQuestion;
        }

        public CommonDialog(string title, string question, bool onlyOkButton) : this(title, question)
        {
            if (onlyOkButton)
                btnRight.Visibility = Visibility.Collapsed;
        }

        public CommonDialog(string title, string question, string isTrue, string isFalse) : this(title, question)
        {
            btnLeft.Content = isTrue;
            btnRight.Content = isFalse;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void OkCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OkExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
