using System;
using System.Collections.Generic;
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

namespace EventsModule
{
    /// <summary>
    /// Interaction logic for ModuleDialog.xaml
    /// </summary>
    public partial class ModuleDialog : Window
    {
        public ModuleDialog()
        {
            InitializeComponent();
        }

        private void ChangeTextColor_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
