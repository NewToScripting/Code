using System;
using System.Collections.Generic;
using System.Windows;
using Inspire.Server.Proxy;

namespace Inspire.Client.ConfigurationWindow.Dialogs
{
    /// <summary>
    /// Interaction logic for NewDisplay.xaml
    /// </summary>
    public partial class DisplayForm
    {
        private Display tempdisplay;

        public DisplayForm()
        {
            InitializeComponent();

            List<DisplayProperty> displayProperties = DisplayPropertyManager.GetAllDisplayProperties();
            foreach (var displayProperty in displayProperties)
            {
                cbProperty.Items.Add(displayProperty);
            }

            txtDispName.Focus();
        }

        public DisplayForm(string _groupGuid)
        {
            InitializeComponent();

            // This will set a new displays GUID
            lblGuid.Content = Guid.NewGuid().ToString();

            SetPropertyandGroups(_groupGuid);
        }

        public DisplayForm(Display _display)
        {
            InitializeComponent();
            txtDispName.Focus();

            SetPropertyandGroups(_display.Group);

            lblGuid.Content = _display.Group;

            txtDispName.Text = _display.DisplayName;
            txtHostName.Text = _display.HostName;
            txtHRes.Text = _display.HResolution.ToString();
            txtVRes.Text = _display.VResolution.ToString();
            txtLoc.Text = _display.Location;
            txtContType.Text = _display.ControllerType;
            txtContModel.Text = _display.ControllerModel;
            txtMonType.Text = _display.MonitorType;
            txtMonMod.Text = _display.MonitorModel;
            txtMonSize.Text = _display.MonitorSize;
            txtOS.Text = _display.OS;
            txtDomain.Text = _display.Domain;
            txtOrientation.Text = _display.Orientation;

        }

        public Display TempDisplay
        {
            get { return tempdisplay; }
            set { tempdisplay = value; } 
        }

        private void cbProperty_DropDownClosed(object sender, EventArgs e)
        {
            if (cbGroup.SelectedItem is DisplayGroup)
            {
                string currentGroupGuid = ((DisplayGroup) cbGroup.SelectedItem).GUID;
                cbGroup.Items.Clear();
                List<DisplayGroup> displayGroups = DisplayGroupManager.GetAllDisplayGroups();

                if (cbProperty.SelectedItem != null)
                    if (cbProperty != null)
                        SetGroups(displayGroups, ((DisplayProperty) cbProperty.SelectedItem).GUID,
                                  currentGroupGuid);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SetPropertyandGroups(string _groupGuid)
        {
            List<DisplayGroup> displayGroups = DisplayGroupManager.GetAllDisplayGroups();

            string propertyGuid = string.Empty;

            foreach (var displayGroup in displayGroups)
            {
                if (displayGroup.GUID == _groupGuid)
                {
                    propertyGuid = displayGroup.PropertyID;
                }
            }

            List<DisplayProperty> displayProperties = DisplayPropertyManager.GetAllDisplayProperties();

            int i = 0;
            int propertyIndex = 0;
            foreach (var displayProperty in displayProperties)
            {
                cbProperty.Items.Add(displayProperty);
                if (displayProperty.GUID == propertyGuid)
                    propertyIndex = i;
                i++;
            }

            cbProperty.SelectedIndex = propertyIndex;

            SetGroups(displayGroups, propertyGuid, _groupGuid);
        }

        private void SetGroups(List<DisplayGroup> displayGroups, string propertyGuid, string groupGuid)
        {
            
            int i = 0;
            int groupIndex = 0;
            bool groupFound = false;

            foreach (var displayGroup in displayGroups)
            {
                if (displayGroup.PropertyID == propertyGuid)
                {
                    cbGroup.Items.Add(displayGroup);
                    if (groupGuid == displayGroup.GUID)
                    {
                        groupIndex = i;
                        groupFound = true;
                    }
                    i++;
                }
            }
            if (groupFound)
                cbGroup.SelectedIndex = groupIndex;
            else
            {
                for (int j = 0; j < cbGroup.Items.Count; j++)
                {
                    //cbGroup.Items.RemoveAt(j -1); //TODO: Fix this
                    cbGroup.SelectedIndex = j-1;

                }
            }

        }

        public void ClearForm()
        {
            txtDispName.Text = string.Empty;
            txtHostName.Text = string.Empty;
            txtHRes.Text = string.Empty;
            txtVRes.Text = string.Empty;
            txtLoc.Text = string.Empty;
            txtContType.Text = string.Empty;
            txtContModel.Text = string.Empty;
            txtMonType.Text = string.Empty;
            txtMonMod.Text = string.Empty;
            txtMonSize.Text = string.Empty;
            txtOS.Text = string.Empty;
            txtDomain.Text = string.Empty;

            txtOrientation.Text = string.Empty;
            txtDispName.Focus();
        }

        private void SaveDisplayFormExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            try
            {
                Display _display = new Display();

                if (cbGroup.SelectedIndex < 0 || cbProperty.SelectedIndex < 0)
                    throw new NotSupportedException("A Property and Group must be selected to save a display.");

                if (lblGuid.Content != null || (string)lblGuid.Content != string.Empty)
                    if (lblGuid.Content != null) _display.GUID = lblGuid.Content.ToString();
                _display.DisplayName = txtDispName.Text;
                _display.HostName = txtHostName.Text;
                if (txtHRes.Text != string.Empty)
                    _display.HResolution = Convert.ToInt32(txtHRes.Text);
                if (txtVRes.Text != string.Empty)
                    _display.VResolution = Convert.ToInt32(txtVRes.Text);
                _display.Location = txtLoc.Text;
                _display.ControllerType = txtContType.Text;
                _display.ControllerModel = txtContModel.Text;
                _display.MonitorType = txtMonType.Text;
                _display.MonitorModel = txtMonMod.Text;
                _display.MonitorSize = txtMonSize.Text;
                _display.OS = txtOS.Text;
                _display.Domain = txtDomain.Text;
                DisplayGroup selectedGroup = cbGroup.SelectedItem as DisplayGroup;
                if (selectedGroup != null) _display.Group = selectedGroup.GUID;

                //_display.Orientation = Orientation.Horizontal;

                tempdisplay = _display;
                DialogResult = true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
            }
        }

        private void SaveDisplayFormCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(txtVRes.Text) && !String.IsNullOrEmpty(txtHRes.Text))
                try
                {
                    e.CanExecute = (!String.IsNullOrEmpty(txtHostName.Text) && !String.IsNullOrEmpty(txtDispName.Text) && Convert.ToInt32(txtHRes.Text) > 0 && Convert.ToInt32(txtVRes.Text) > 0);
                }
                catch (Exception)
                {
                    e.CanExecute = false;
                }
        }

    }
}
