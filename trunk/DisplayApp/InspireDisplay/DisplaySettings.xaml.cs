using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InspireDisplay
{
    /// <summary>
    /// Interaction logic for DisplaySettings.xaml
    /// </summary>
    public partial class DisplaySettings : Window
    {
        public DisplaySettings()
        {
            InitializeComponent();

            PreviewKeyDown += DisplaySettings_PreviewKeyDown;
        }

        void DisplaySettings_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key.Equals(Key.Escape))
                Close();
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            Close();
            System.Windows.Forms.Application.Restart();

            Application.Current.Shutdown();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("Inspire.WatchDog.Interface");

            foreach (Process process in processes)
            {
                process.Kill();
            }

            Close();
            Application.Current.MainWindow.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var activation = new Activation();
            if(activation.ShowDialog() == true)
            {


                Close();
            }
        }

    }
}
