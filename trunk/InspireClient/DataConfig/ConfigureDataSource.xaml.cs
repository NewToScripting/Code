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
using Inspire;

namespace DataConfig
{
    /// <summary>
    /// Interaction logic for ConfigureDataSource.xaml
    /// </summary>
    public partial class ConfigureDataSource : Window
    {
        public ConfigureDataSource()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConfigureDataField configureDataField = new ConfigureDataField();
            configureDataField.ShowDialog();
            if(configureDataField.DialogResult == true)
            {
                DataField dataField = new DataField(configureDataField.tbFieldName.Text, configureDataField.cbFieldType.Text);
                lbFields.Items.Add(dataField);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(lbFields.SelectedIndex > -1)
                lbFields.Items.RemoveAt(lbFields.SelectedIndex);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(lbFields.SelectedIndex > -1)
            {
                DataField dataField = lbFields.SelectedItem as DataField;
                if (dataField != null)
                {
                    ConfigureDataField configureDataField = new ConfigureDataField(dataField.Name, dataField.Type);
                    configureDataField.ShowDialog();
                    if (configureDataField.DialogResult == true)
                    {
                        int index = lbFields.SelectedIndex;
                        lbFields.Items.RemoveAt(index);
                        lbFields.Items.Insert(index,new DataField(configureDataField.tbFieldName.Text,
                                                                               configureDataField.cbFieldType.Text));
                    }
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           // if()
        }
    }
}
