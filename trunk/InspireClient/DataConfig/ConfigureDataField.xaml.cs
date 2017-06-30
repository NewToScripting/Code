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

namespace DataConfig
{
    /// <summary>
    /// Interaction logic for ConfigureDataField.xaml
    /// </summary>
    public partial class ConfigureDataField : Window
    {
        public ConfigureDataField()
        {
            InitializeComponent();
        }

        public ConfigureDataField(string name, string type)
        {
            InitializeComponent();
            tbFieldName.Text = name;
            cbFieldType.Text = type;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbFieldName.Text))
            {
                DialogResult = true;
                Close();
            }
        }
    }
}
