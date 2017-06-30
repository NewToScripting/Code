using System.Windows;

namespace Inspire.Client.Designer.Dialogs
{
    /// <summary>
    /// Interaction logic for UpdateSchedules.xaml
    /// </summary>
    public partial class UpdateSchedules
    {
        public UpdateSchedules()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
