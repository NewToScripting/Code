using System.Windows;

namespace Inspire.Client
{
    /// <summary>
    /// Interaction logic for Activation.xaml
    /// </summary>
    public partial class Activation : Window
    {
        public Activation()
        {
            InitializeComponent();
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            tbRegistrationCode.Clear();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {


            Close();
        }
    }
}
