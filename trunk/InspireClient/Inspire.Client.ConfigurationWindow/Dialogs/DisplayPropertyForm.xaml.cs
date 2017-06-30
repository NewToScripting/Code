using System;
using System.Windows;
using Inspire.Common.TreeViewModel;

namespace Inspire.Client.ConfigurationWindow.Dialogs
{
    /// <summary>
    /// Interaction logic for DisplayPropertyForm.xaml
    /// </summary>
    public partial class DisplayPropertyForm
    {
        public DisplayPropertyForm()
        {
            InitializeComponent();
        }

        public DisplayPropertyForm(PropertyViewModel treeViewItemModel)
        {
            InitializeComponent();
            tbPropertyName.Text = treeViewItemModel.PropertyName;
            tbPropertyDescription.Text = treeViewItemModel.PropertyDescription;
        }

        public string PropertyName { get; set; }

        public string PropertyDescription { get; set; }

        private void Save()
        {
            if (tbPropertyName.Text != "")
            {
                PropertyName = tbPropertyName.Text;
                PropertyDescription = tbPropertyDescription.Text;
                DialogResult = true;
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SavePropertyFormExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Save();
        }

        private void SavePropertyFormCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !String.IsNullOrEmpty(tbPropertyName.Text);
        }
    }
}
