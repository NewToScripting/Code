using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace Inspire.Client
{
    /// <summary>
    /// Interaction logic for DesignerLogin.xaml
    /// </summary>
    public partial class DesignerLogin
    {
        public DesignerLogin()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;            
            Close();
            e.Handled = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
            e.Handled = true;
        }

    }
}
