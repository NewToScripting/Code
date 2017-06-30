using System;
using System.Windows;
using Inspire.Common.TreeViewModel;

namespace Inspire.Client.ConfigurationWindow.Dialogs
{
    /// <summary>
    /// Interaction logic for DisplayGroupForm.xaml
    /// </summary>
    public partial class DisplayGroupForm
    {
        public string GroupName { get; set; }

        public string GroupDescription { get; set; }

        public DisplayGroupForm()
        {
            InitializeComponent();
        }

        public DisplayGroupForm(DisplayGroupViewModel treeViewItemModel)
        {
            InitializeComponent();
            tbGroupName.Text = treeViewItemModel.DisplayGroupName;
            tbGroupDescription.Text = treeViewItemModel.DisplayGroupDescription;
        }

        private void Save()
        {
            if (tbGroupName.Text != "")
            {
                GroupName = tbGroupName.Text;
                GroupDescription = tbGroupDescription.Text;
                DialogResult = true;
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void SaveGroupFormExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Save();
        }

        private void SaveGroupFormCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !String.IsNullOrEmpty(tbGroupName.Text);
        }
    }
}
