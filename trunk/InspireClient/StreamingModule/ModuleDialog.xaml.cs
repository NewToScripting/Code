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

namespace StreamingModule
{

    /// <summary>
    /// Interaction logic for ModuleDialog.xaml
    /// </summary>
    public partial class ModuleDialog : Window
    {
        public string StreamUrl { get; set; }

        public ModuleDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(tbStreamUrl.Text))
                StreamUrl = tbStreamUrl.Text; // TODO: Check for Valid stream

            DialogResult = true;

        }

        private void btnPreview_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(tbStreamUrl.Text))
            {
                meStreamTest.LoadedBehavior = MediaState.Manual;
                meStreamTest.Source = new Uri(tbStreamUrl.Text);
                meStreamTest.Play();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
