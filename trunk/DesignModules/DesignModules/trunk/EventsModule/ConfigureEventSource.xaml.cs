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
    /// Interaction logic for ConfigureEventSource.xaml
    /// </summary>
    public partial class ConfigureEventSource : Window
    {
        public ConfigureEventSource()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            
            if (lbAvailableFields.SelectedIndex > -1)
            {
                object selectedItem;
                int selectedIndex = lbAvailableFields.SelectedIndex;
                selectedItem = lbAvailableFields.SelectedItem;
                lbAvailableFields.Items.RemoveAt(lbAvailableFields.SelectedIndex);
                if(selectedIndex < lbAvailableFields.Items.Count)
                    lbAvailableFields.SelectedIndex = selectedIndex;
                else
                {
                    lbAvailableFields.SelectedIndex = selectedIndex - 1;
                }
                lbSelectedFields.Items.Add(selectedItem);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
