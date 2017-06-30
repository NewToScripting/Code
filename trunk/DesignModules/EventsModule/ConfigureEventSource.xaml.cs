using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using EventsModule.Dialogs;
using Inspire.Events.Proxy;

namespace EventsModule
{
    /// <summary>
    /// Interaction logic for ConfigureEventSource.xaml
    /// </summary>
    public partial class ConfigureEventSource : INotifyPropertyChanged
    {
        public HospitalityEventDefinition CurrentEventDefinition { get; set; }

        private ObservableCollection<HospitalityEventDefinition> _hospitalityEventDefs;

        private bool _isEditMode;
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                if (value != _isEditMode)
                {
                    _isEditMode = value;
                    OnPropertyChanged("IsEditMode");
                }
            }
        }
        

        public ConfigureEventSource()
        {
            InitializeComponent();

            try
            {
                //IsEditMode = false;

                //_hospitalityEventDefs =  new ObservableCollection<HospitalityEventDefinition>(HospitalityEventDefinitionManager.GetEventDefinitions());

                //cbDataSources.ItemsSource = _hospitalityEventDefs;

                //DataContext = CurrentEventDefinition;

                //CurrentEventDefinition = cbDataSources.SelectedItem as HospitalityEventDefinition;

                //cbType.ItemsSource = HospitalityEventDefinitionManager.GetEventFileFormats();

            }
            catch (Exception)
            {
                
               // throw;  TODO: handle exception
            }
        }

        private void SaveDataSource_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            if (CurrentEventDefinition != null && !string.IsNullOrEmpty(CurrentEventDefinition.Name) && !string.IsNullOrEmpty(CurrentEventDefinition.Description) && !string.IsNullOrEmpty(CurrentEventDefinition.Uri))
                e.CanExecute = true;
        }

        private void SaveDataSource_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if(cbType.SelectedItem != null)
                CurrentEventDefinition.EventFileFormat = cbType.SelectedItem as EventFileFormat;

            if (CurrentEventDefinition.EventDefinitionGUID == null)
                CurrentEventDefinition.EventDefinitionGUID = Guid.NewGuid().ToString();

            HospitalityEventDefinitionManager.AddEventDefinition(CurrentEventDefinition);
            _hospitalityEventDefs.Add(CurrentEventDefinition);

            Clear();
        }

        private void ClearDataSource_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ClearDataSource_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            CurrentEventDefinition = null;

            CurrentEventDefinition = new HospitalityEventDefinition();

            tbEventFilePath.Text = string.Empty;
            tbDataSourceName.Text = string.Empty;
            tbDataSourceDescription.Text = string.Empty;

            IsEditMode = false;

            DataContext = CurrentEventDefinition;
        }

        private void AddDataSource_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AddDataSource_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            CurrentEventDefinition = null;

            CurrentEventDefinition = new HospitalityEventDefinition();

            DataContext = CurrentEventDefinition;

            IsEditMode = true;
        }

        private void EditDataSource_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (cbDataSources.SelectedItem != null && IsEditMode != true);
        }

        private void EditDataSource_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            IsEditMode = true;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if(!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                if (File.Exists(openFileDialog.FileName))
                {
                    CurrentEventDefinition.Uri = openFileDialog.FileName;
                    tbEventFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        private void cbDataSources_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            CurrentEventDefinition = cbDataSources.SelectedItem as HospitalityEventDefinition;

            DataContext = CurrentEventDefinition;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private void EditEventDefs_Click(object sender, RoutedEventArgs e)
        {
            var eventDefinitionDialog = new EventDefinitionDialog();

            eventDefinitionDialog.ShowDialog();
            
            if(eventDefinitionDialog.DialogResult == true)
            {
                cbType.ItemsSource = HospitalityEventDefinitionManager.GetEventFileFormats();
            }
            e.Handled = true;
        }

        private void RemoveDataSource_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (cbDataSources.SelectedItem != null);
        }

        private void RemoveDataSource_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (cbDataSources.SelectedItem != null)
                HospitalityEventDefinitionManager.DeleteEventDefinition(((HospitalityEventDefinition)cbDataSources.SelectedItem).EventDefinitionGUID);
        }
    }
}
