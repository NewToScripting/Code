using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Inspire.Events.Proxy;

namespace EventsModule.Dialogs
{
    /// <summary>
    /// Interaction logic for EditEventDefinition.xaml
    /// </summary>
    public partial class EventDefinitionDialog : Window
    {
        public ObservableCollection<EventFileFormat> EventFormats;

        private List<TextFormats> _eventTextFormats;

        private EventFileFormat _currentEventFileFormat;

        private List<string> _startingGuids;

        public EventDefinitionDialog()
        {
            InitializeComponent();

            _eventTextFormats = new List<TextFormats>();

            _startingGuids = new List<string>();

            _eventTextFormats.Add(TextFormats.Fixed);
            _eventTextFormats.Add(TextFormats.Separated);

            EventFormats = new ObservableCollection<EventFileFormat>(HospitalityEventDefinitionManager.GetEventFileFormats());

            if(EventFormats.Count > 0)
            foreach (var fileFormat in EventFormats)
            {
                _startingGuids.Add(fileFormat.EventFileFormatGuid);
            }

            cbFileType.ItemsSource = _eventTextFormats;

            cbFileFormats.ItemsSource = EventFormats;

            DataContext = _currentEventFileFormat;

            if (EventFormats.Count > 0)
            {
                _currentEventFileFormat = EventFormats[0];

                lbFieldContracts.ItemsSource = _currentEventFileFormat.FieldContracts;
            }

            cbFileFormats.SelectedIndex = 0;
        }

        void cbFileFormats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _currentEventFileFormat = cbFileFormats.SelectedItem as EventFileFormat;
            if (_currentEventFileFormat != null)
            {
                if (_currentEventFileFormat.TextFormat == TextFormats.Fixed)
                    cbFileType.SelectedIndex = 0;
                else if (_currentEventFileFormat.TextFormat == TextFormats.Separated)
                    cbFileType.SelectedIndex = 1;

                if (_currentEventFileFormat.FieldDelimeter == "/t")
                    cbSeparator.SelectedIndex = 0;
                else if (_currentEventFileFormat.FieldDelimeter == ",")
                    cbSeparator.SelectedIndex = 1;
                else if (_currentEventFileFormat.FieldDelimeter == "|")
                    cbSeparator.SelectedIndex = 2;

                cbSkipFirst.IsChecked = _currentEventFileFormat.SkipFirstFile;

                lbFieldContracts.ItemsSource = _currentEventFileFormat.FieldContracts;
                    
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var commonDialog = new AddItem("File Definition Name:", "Enter a name for the file definition:");
            commonDialog.ShowDialog();
            if(commonDialog.DialogResult == true)
            {
                var eventFileFormat = new EventFileFormat();
                eventFileFormat.EventFormatName = commonDialog.tbItemName.Text;
                eventFileFormat.IsReadOnly = false;
                eventFileFormat.FieldContracts = CreateEmptyEventFileContracts();

                cbFileType.SelectedIndex = 0;

                EventFormats.Add(eventFileFormat);

                cbFileFormats.SelectedItem = eventFileFormat;
            }
        }

        private List<FieldContract> CreateEmptyEventFileContracts()
        {
            var fieldContracts = new List<FieldContract>();

            fieldContracts.Add(new FieldContract("Hotel", null, null));
            fieldContracts.Add(new FieldContract("GroupName", null, null));
            fieldContracts.Add(new FieldContract("GroupLogo", null, null));
            fieldContracts.Add(new FieldContract("MeetingName", null, null));
            fieldContracts.Add(new FieldContract("MeetingLogo", null, null));
            fieldContracts.Add(new FieldContract("MeetingPostAs", null, null));
            fieldContracts.Add(new FieldContract("MeetingID", null, null));
            fieldContracts.Add(new FieldContract("MeetingType", null, null));
            fieldContracts.Add(new FieldContract("MeetingRoomID", null, null));
            fieldContracts.Add(new FieldContract("MeetingRoomName", null, null));
            fieldContracts.Add(new FieldContract("MeetingRoomLogo", null, null));
            fieldContracts.Add(new FieldContract("HostEventIdentifier", null, null));
            fieldContracts.Add(new FieldContract("Postable", null, null));
            fieldContracts.Add(new FieldContract("Exhibit", null, null));
            fieldContracts.Add(new FieldContract("BackupMeetingRoomSpace", null, null));
            fieldContracts.Add(new FieldContract("OverflowMeetingRoomSpace", null, null));
            fieldContracts.Add(new FieldContract("Date", null, null));
            fieldContracts.Add(new FieldContract("StartDate", null, null));
            fieldContracts.Add(new FieldContract("EndTime", null, null));
            fieldContracts.Add(new FieldContract("IsVisible", null, null));

            return fieldContracts;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SetTextFormat();

            _currentEventFileFormat.SkipFirstFile = cbSkipFirst.IsChecked;

            var newStrings = new List<string>();
           // HospitalityEventDefinitionManager.
            foreach (var eventFormat in EventFormats)
            {
                if(_startingGuids.Contains(eventFormat.EventFileFormatGuid))
                    HospitalityEventDefinitionManager.UpdateEventFileFormat(eventFormat);
                else
                    HospitalityEventDefinitionManager.AddEventFileFormat(eventFormat);
                
                newStrings.Add(eventFormat.EventFileFormatGuid);
            }

            foreach (var startingGuid in _startingGuids)
            {
                if(!newStrings.Contains(startingGuid))
                    HospitalityEventDefinitionManager.DeleteEventFileFormat(startingGuid);
            }

            DialogResult = true;
        }

        private void cbFileType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbFileType.SelectedIndex == 0)
            {
                _currentEventFileFormat.TextFormat = TextFormats.Fixed;
                cbSeparator.IsEnabled = false;
            }
            if (cbFileType.SelectedIndex == 1)
            {
                _currentEventFileFormat.TextFormat = TextFormats.Separated;
                cbSeparator.IsEnabled = true;
            }
        }

        private void cbSeparator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetTextFormat();
        }

        private void SetTextFormat()
        {
            if (cbFileType.SelectedIndex == 0)
            {
                _currentEventFileFormat.FieldDelimeter = "/t";
            }
            else if (cbFileType.SelectedIndex == 1)
            {
                _currentEventFileFormat.FieldDelimeter = ",";
            }
            else if (cbFileType.SelectedIndex == 2)
            {
                _currentEventFileFormat.FieldDelimeter = "|";
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (cbFileFormats.SelectedItem != null)
                EventFormats.Remove((EventFileFormat)cbFileFormats.SelectedItem);
        }
    }
}
