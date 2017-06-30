using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ActiproSoftware.Windows.Controls.Ribbon.Input;
using EventsModule.Commands;
using Inspire;
using Inspire.Common.Utility;
using Inspire.Events.Proxy;
using System.Collections.ObjectModel;

namespace EventsModule.Dialogs
{
    /// <summary>
    /// Interaction logic for ConfigureEvents.xaml
    /// </summary>
    public partial class ConfigureEvents : INotifyPropertyChanged
    {

        private FeedContentControl evntControl;
        private string templateGuid;
        private bool allRooms;
        private FeedTemplate feedTemplate;
        private ObservableCollection<ComboBoxItem> fieldNames;

        private int[] fontSizes = {8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,44,46,48,50,52,54,60,64,68,72};

        private FontFamily selectedFontFamily;
        private Brush selectedFontForeground;
        private int selectedFontSize;

        public FontFamily SelectedFontFamily
        {
            get { return selectedFontFamily; }
            set
            {
                if (value != selectedFontFamily)
                {
                    selectedFontFamily = value;
                    OnPropertyChanged("SelectedFontFamily");
                }
            }
        }

        public Brush SelectedFontForeground
        {
            get { return selectedFontForeground; }
            set
            {
                if (value != selectedFontForeground)
                {
                    selectedFontForeground = value;
                    ChangeFont();
                    OnPropertyChanged("SelectedFontForeground");
                }
            }
        }

        public int SelectedFontSize
        {
            get { return selectedFontSize; }
            set
            {
                if (value != selectedFontSize)
                {
                    selectedFontSize = value;
                    OnPropertyChanged("SelectedFontSize");
                }
            }
        }

        public bool AllRooms
        {
            get { return allRooms; }
            set
            {
                if (value != allRooms)
                {
                    allRooms = value;
                    OnPropertyChanged("AllRooms");
                }
            }
        }

        public FeedContentControl EvntControl
        {
            get { return evntControl; }
            set
            {
                if (value != evntControl)
                {
                    evntControl = value;
                    OnPropertyChanged("EvntControl");
                }
            }
        }

        public ConfigureEvents(string _templateGuid)
        {
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(EventsModuleCommands.ApplyForeground, OnApplyForegroundExecute, OnApplyForegroundCanExecute));

            Loaded += ConfigureEvents_Loaded;

            cbFontSize.ItemsSource = fontSizes;

            AllRooms = true;
            templateGuid = _templateGuid;
        }

        public ConfigureEvents(FeedContentControl feedContentControl)
        {
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(EventsModuleCommands.ApplyForeground, OnApplyForegroundExecute, OnApplyForegroundCanExecute));

            cbFontSize.ItemsSource = fontSizes;

            AllRooms = feedContentControl.ShowAllRooms;
            templateGuid = feedContentControl.TemplateGuid;
            Loaded += EditEvents_Loaded;
            EvntControl = feedContentControl;
            
        }

        private void EditEvents_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                fieldNames = new ObservableCollection<ComboBoxItem>();

                feedTemplate = Inspire.Events.Proxy.FeedTemplateProxy.GetSingleTemplate(templateGuid);

                cbTemplateField.ItemsSource = fieldNames;

                try
                {
                   // cbTemplateSources.ItemsSource = FeedManager.GetFeeds();

                    cbTemplateSources.DisplayMemberPath = "Description";

                    cbTemplateSources.SelectedValuePath = "GUID";

                    if (cbTemplateSources.Items.Count > 0)                              // TODO: Need to choose datasource that was assigned, not just the first one. (See the the Loading of the Events Property Panel for example)
                        cbTemplateSources.SelectedItem = cbTemplateSources.Items[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The DataSources failed to load. " + ex);
                }

                SelectedFontFamily = EvntControl.NameField1FontFamily;

                SelectedFontSize = EvntControl.NameField1FontSize;
                cbFontSize.SelectedIndex = cbFontSize.Items.IndexOf(SelectedFontSize);

                SetFieldValues();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void ConfigureEvents_Loaded(object sender, RoutedEventArgs e)
        {
            fieldNames = new ObservableCollection<ComboBoxItem>();

            feedTemplate = Inspire.Events.Proxy.FeedTemplateProxy.GetSingleTemplate(templateGuid);

            cbTemplateField.ItemsSource = fieldNames;

            try
            {
               // cbTemplateSources.ItemsSource = FeedManager.GetFeeds();

                cbTemplateSources.DisplayMemberPath = "Description";

                cbTemplateSources.SelectedValuePath = "GUID";

                if(cbTemplateSources.Items.Count >0)
                    cbTemplateSources.SelectedItem = cbTemplateSources.Items[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show("The DataSources failed to load. " + ex);
            }

            try
            {
                //Files.ClearDirectory(Paths.ClientTemplateTempDirectory);
                
                if(feedTemplate != null)
                {

                    if (feedTemplate.File != null)
                    {
                        string filename = Paths.ClientTemplateTempDirectory + feedTemplate.Guid + ".inst";
                        Files.SaveStreamToFile(feedTemplate.File, filename);
                        ZipUtil.NewUnZipFiles(filename, Paths.ClientTemplateTempDirectory, "wookie", true);
                    }

                    FeedContentControl feedContentControl = new FeedContentControl(Convert.ToInt32(cbSecondsPerPage.Text), (int)feedTemplate.Rows, "Client", feedTemplate.Guid, new Uri(Paths.ClientTemplateTempDirectory + feedTemplate.Guid + ".xaml", UriKind.RelativeOrAbsolute), cbTemplateSources.SelectedValue.ToString(), true);

                    feedContentControl.TemplateFields = feedTemplate.Fields;

                    if (EvntControl != null)
                        EvntControl.Dispose();

                    EvntControl = feedContentControl;

                    if(feedTemplate.Type == "Room")
                    {
                        if (EvntControl.NameField1FontSize == 0)
                            EvntControl.NameField1FontSize = 30;
                        if (EvntControl.NameField2FontSize == 0)
                            EvntControl.NameField2FontSize = 26;
                        if (EvntControl.NameField3FontSize == 0)
                            EvntControl.NameField3FontSize = 26;
                        if (EvntControl.NameField4FontSize == 0)
                            EvntControl.NameField4FontSize = 26;
                        if (EvntControl.DescField1FontSize == 0)
                            EvntControl.DescField1FontSize = 26;
                        if (EvntControl.DescField2FontSize == 0)
                            EvntControl.DescField2FontSize = 26;
                        if (EvntControl.DescField3FontSize == 0)
                            EvntControl.DescField3FontSize = 26;
                        if (EvntControl.DescField4FontSize == 0)
                            EvntControl.DescField4FontSize = 26;
                        if (EvntControl.DateTime1FontSize == 0)
                            EvntControl.DateTime1FontSize = 26;
                        if (EvntControl.DateTime2FontSize == 0)
                            EvntControl.DateTime2FontSize = 26;
                        if (EvntControl.DateTime3FontSize == 0)
                            EvntControl.DateTime3FontSize = 26;
                        if (EvntControl.DateTime4FontSize == 0)
                            EvntControl.DateTime4FontSize = 26;
                        if (EvntControl.IntField1FontSize == 0)
                            EvntControl.IntField1FontSize = 26;
                        if (EvntControl.IntField2FontSize == 0)
                            EvntControl.IntField2FontSize = 26;
                        if (EvntControl.DecimalField1FontSize == 0)
                            EvntControl.DecimalField1FontSize = 26;
                        if (EvntControl.DecimalField2FontSize == 0)
                            EvntControl.DecimalField2FontSize = 26;
                    }

                    if (feedTemplate.Type == "Directory")
                    {
                        if (EvntControl.NameField1FontSize == 0)
                            EvntControl.NameField1FontSize = 26;
                        if (EvntControl.NameField2FontSize == 0)
                            EvntControl.NameField2FontSize = 24;
                        if (EvntControl.NameField3FontSize == 0)
                            EvntControl.NameField3FontSize = 24;
                        if (EvntControl.NameField4FontSize == 0)
                            EvntControl.NameField4FontSize = 24;
                        if (EvntControl.DescField1FontSize == 0)
                            EvntControl.DescField1FontSize = 24;
                        if (EvntControl.DescField2FontSize == 0)
                            EvntControl.DescField2FontSize = 24;
                        if (EvntControl.DescField3FontSize == 0)
                            EvntControl.DescField3FontSize = 24;
                        if (EvntControl.DescField4FontSize == 0)
                            EvntControl.DescField4FontSize = 24;
                        if (EvntControl.DateTime1FontSize == 0)
                            EvntControl.DateTime1FontSize = 22;
                        if (EvntControl.DateTime2FontSize == 0)
                            EvntControl.DateTime2FontSize = 20;
                        if (EvntControl.DateTime3FontSize == 0)
                            EvntControl.DateTime3FontSize = 20;
                        if (EvntControl.DateTime4FontSize == 0)
                            EvntControl.DateTime4FontSize = 20;
                        if (EvntControl.IntField1FontSize == 0)
                            EvntControl.IntField1FontSize = 20;
                        if (EvntControl.IntField2FontSize == 0)
                            EvntControl.IntField2FontSize = 20;
                        if (EvntControl.DecimalField1FontSize == 0)
                            EvntControl.DecimalField1FontSize = 24;
                        if (EvntControl.DecimalField2FontSize == 0)
                            EvntControl.DecimalField2FontSize = 24;
                    }

                    SelectedFontFamily = EvntControl.NameField1FontFamily;

                    SelectedFontSize = EvntControl.NameField1FontSize;
                    cbFontSize.SelectedIndex = cbFontSize.Items.IndexOf(SelectedFontSize);

                }

                SetFieldValues();

            }
            catch(Exception ex)
            {
                MessageBox.Show("The Template Failed to Load. " + ex);
            }
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        private void OnApplyForegroundCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //BrushValueCommandParameter parameter = e.Parameter as BrushValueCommandParameter;
            //if ((parameter != null))
            //{
            //    parameter.UpdatedValue = SelectedFontForeground;
            //    parameter.Handled = true;
            //}
            e.CanExecute = true;
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> is executed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An <see cref="ExecutedRoutedEventArgs"/> that contains the event data.</param>
        private void OnApplyForegroundExecute(object sender, ExecutedRoutedEventArgs e)
        {
            BrushValueCommandParameter parameter = e.Parameter as BrushValueCommandParameter;
            if (parameter != null)
            {
                switch (parameter.Action)
                {
                    case ValueCommandParameterAction.Commit:
                        SelectedFontForeground = parameter.Value;
                        break;
                    case ValueCommandParameterAction.Preview:
                        SelectedFontForeground = parameter.PreviewValue;
                        break;
                }
            }
            else
            {
                SelectedFontForeground = null;
            }
            e.Handled = true;
        }

        private void FillFields()
        {
            //fieldNames.Clear();

            //foreach (FeedTemplate.FieldsEnum fieldsEnum in Schedule.GetSelectedEnumValues(feedTemplate.Fields))
            //{
            //    //TODO: Change to switch statement to speed up
            //    if (fieldsEnum.ToString() == "NameField1" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).NameField1Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed) cbTemplateSources.SelectedItem).NameField1Def;
            //        comboBoxItem.Tag = "NameField1";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "NameField1")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "NameField1";
            //        comboBoxItem.Tag = "NameField1";
            //        fieldNames.Add(comboBoxItem);
            //    }

            //    if (fieldsEnum.ToString() == "NameField2" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).NameField2Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed)cbTemplateSources.SelectedItem).NameField2Def;
            //        comboBoxItem.Tag = "NameField2";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "NameField2")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "NameField2";
            //        comboBoxItem.Tag = "NameField2";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    if (fieldsEnum.ToString() == "NameField3" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).NameField3Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed)cbTemplateSources.SelectedItem).NameField3Def;
            //        comboBoxItem.Tag = "NameField3";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "NameField3")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "NameField3";
            //        comboBoxItem.Tag = "NameField3";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    if (fieldsEnum.ToString() == "NameField4" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).NameField4Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed)cbTemplateSources.SelectedItem).NameField4Def;
            //        comboBoxItem.Tag = "NameField4";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "NameField4")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "NameField4";
            //        comboBoxItem.Tag = "NameField4";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    if (fieldsEnum.ToString() == "DescField1" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).DescField1Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed)cbTemplateSources.SelectedItem).DescField1Def;
            //        comboBoxItem.Tag = "DescField1";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "DescField1")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "DescField1";
            //        comboBoxItem.Tag = "DescField1";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    if (fieldsEnum.ToString() == "DescField2" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).DescField2Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed)cbTemplateSources.SelectedItem).DescField2Def;
            //        comboBoxItem.Tag = "DescField2";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "DescField2")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "DescField2";
            //        comboBoxItem.Tag = "DescField2";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    if (fieldsEnum.ToString() == "DescField3" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).DescField3Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed)cbTemplateSources.SelectedItem).DescField3Def;
            //        comboBoxItem.Tag = "DescField3";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "DescField3")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "DescField3";
            //        comboBoxItem.Tag = "DescField3";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    if (fieldsEnum.ToString() == "DescField4" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).DescField4Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed)cbTemplateSources.SelectedItem).DescField4Def;
            //        comboBoxItem.Tag = "DescField4";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "DescField4")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "DescField4";
            //        comboBoxItem.Tag = "DescField4";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    if (fieldsEnum.ToString() == "IntField1" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).IntField1Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed)cbTemplateSources.SelectedItem).IntField1Def;
            //        comboBoxItem.Tag = "IntField1";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "IntField1")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "IntField1";
            //        comboBoxItem.Tag = "IntField1";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    if (fieldsEnum.ToString() == "IntField2" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).IntField2Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed)cbTemplateSources.SelectedItem).IntField2Def;
            //        comboBoxItem.Tag = "IntField2";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "IntField2")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "IntField2";
            //        comboBoxItem.Tag = "IntField2";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    if (fieldsEnum.ToString() == "DecimalField1" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).DecimalField1Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed)cbTemplateSources.SelectedItem).DecimalField1Def;
            //        comboBoxItem.Tag = "DecimalField1";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "DecimalField1")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "DecimalField1";
            //        comboBoxItem.Tag = "DecimalField1";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    if (fieldsEnum.ToString() == "DecimalField2" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).DecimalField2Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed)cbTemplateSources.SelectedItem).DecimalField2Def;
            //        comboBoxItem.Tag = "DecimalField2";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "DecimalField2")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "DecimalField2";
            //        comboBoxItem.Tag = "DecimalField2";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    if (fieldsEnum.ToString() == "DateField1" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).DateField1Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed)cbTemplateSources.SelectedItem).DateField1Def;
            //        comboBoxItem.Tag = "DateField1";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "DateField1")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "DateField1";
            //        comboBoxItem.Tag = "DateField1";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    if (fieldsEnum.ToString() == "DateField2" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).DateField2Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed)cbTemplateSources.SelectedItem).DateField2Def;
            //        comboBoxItem.Tag = "DateField2";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "DateField2")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "DateField2";
            //        comboBoxItem.Tag = "DateField2";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    if (fieldsEnum.ToString() == "DateField3" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).DateField3Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed)cbTemplateSources.SelectedItem).DateField3Def;
            //        comboBoxItem.Tag = "DateField3";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "DateField3")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "DateField3";
            //        comboBoxItem.Tag = "DateField3";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    if (fieldsEnum.ToString() == "DateField4" && !string.IsNullOrEmpty(((Feed)cbTemplateSources.SelectedItem).DateField4Def))
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = ((Feed)cbTemplateSources.SelectedItem).DateField4Def;
            //        comboBoxItem.Tag = "DateField4";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //    else if (fieldsEnum.ToString() == "DateField4")
            //    {
            //        ComboBoxItem comboBoxItem = new ComboBoxItem();
            //        comboBoxItem.Content = "DateField4";
            //        comboBoxItem.Tag = "DateField4";
            //        fieldNames.Add(comboBoxItem);
            //    }
            //}

            //if (cbTemplateField.Items.Count > 0)
            //    cbTemplateField.SelectedItem = cbTemplateField.Items[0];
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private void btnTemplatetoCanvas(object sender, RoutedEventArgs e)
        {
            Uri tempFileName;
            if(EvntControl.TemplateFileName != null)
                tempFileName = EvntControl.TemplateFileName;
            else
                tempFileName = new Uri(Paths.ClientTemplateTempDirectory + templateGuid + ".xaml",UriKind.RelativeOrAbsolute);
            FeedContentControl feedContentControl = new FeedContentControl(Convert.ToInt32(cbSecondsPerPage.Text) ,(int)feedTemplate.Rows, "Client", feedTemplate.Guid, tempFileName, cbTemplateSources.SelectedValue.ToString(), AllRooms);
            feedContentControl.SetFontValues(EvntControl);
            feedContentControl.TemplateFields = feedTemplate.Fields;
            EvntControl = feedContentControl;
            //EvntControl = null;
            DialogResult = true;
            Close();
        }

        private void cbTemplateSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillFields();
        }

        private void ChangeFont()
        {
            switch (((ComboBoxItem)cbTemplateField.SelectedItem).Tag.ToString())
            {
                case("NameField1"):
                    {
                        if (EvntControl != null)
                        {
                            if(SelectedFontFamily != null)
                                EvntControl.NameField1FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.NameField1Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.NameField1FontSize = SelectedFontSize;
                        }
                        break;
                    }
                case ("NameField2"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
                                EvntControl.NameField2FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.NameField2Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.NameField2FontSize = SelectedFontSize;
                        }
                        break;
                    }
                case ("NameField3"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
                                EvntControl.NameField3FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.NameField3Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.NameField3FontSize = SelectedFontSize;
                        }
                        break;
                    }
                case ("NameField4"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
                                EvntControl.NameField4FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.NameField4Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.NameField4FontSize = SelectedFontSize;
                        }
                        break;
                    }
                case ("DescField1"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
                                EvntControl.DescField1FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.DescField1Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.DescField1FontSize = SelectedFontSize;
                        }
                        break;
                    }
                case ("DescField2"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
                                EvntControl.DescField2FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.DescField2Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.DescField2FontSize = SelectedFontSize;
                        }
                        break;
                    }
                case ("DescField3"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
                                EvntControl.DescField3FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.DescField3Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.DescField3FontSize = SelectedFontSize;
                        }
                        break;
                    }
                case ("DescField4"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
                                EvntControl.DescField4FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.DescField4Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.DescField4FontSize = SelectedFontSize;
                        }
                        break;
                    }
                case ("DateField1"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
                                EvntControl.DateTime1FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.DateTime1Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.DateTime1FontSize = SelectedFontSize;
                        }
                        break;
                    }
                case ("DateField2"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
                                EvntControl.DateTime2FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.DateTime2Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.DateTime2FontSize = SelectedFontSize;
                        }
                        break;
                    }
                case ("DateField3"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
                                EvntControl.DateTime3FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.DateTime3Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.DateTime3FontSize = SelectedFontSize;
                        }
                        break;
                    }
                case ("DateField4"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
                                EvntControl.DateTime4FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.DateTime4Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.DateTime4FontSize = SelectedFontSize;
                        }
                        break;
                    }
                case ("IntField1"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
                                EvntControl.IntField1FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.IntField1Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.IntField1FontSize = SelectedFontSize;
                        }
                        break;
                    }
                case ("IntField2"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
                                EvntControl.IntField2FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.IntField2Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.IntField2FontSize = SelectedFontSize;
                        }
                        break;
                    }
                case ("DecimalField1"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
                                EvntControl.DecimalField1FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.DecimalField1Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.DecimalField1FontSize = SelectedFontSize;
                        }
                        break;
                    }
                case ("DecimalField2"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
                                EvntControl.DecimalField2FontFamily = SelectedFontFamily;
                            if (SelectedFontForeground != null)
                                EvntControl.DecimalField2Foreground = (SolidColorBrush)SelectedFontForeground;
                            EvntControl.DecimalField2FontSize = SelectedFontSize;
                        }
                        break;
                    }  
            }
        }

        private void cbTemplateField_DropDownClosed(object sender, EventArgs e)
        {
            SetFieldValues();
        }

        private void SetFieldValues()
        {
            if (cbTemplateField.SelectedItem != null)
            {
                switch (((ComboBoxItem)cbTemplateField.SelectedItem).Tag.ToString())
                {
                    case ("NameField1"):
                        {
                            if (EvntControl != null)
                            {
                                if (EvntControl.NameField1FontFamily != null)
                                    SelectedFontFamily = EvntControl.NameField1FontFamily;
                                else
                                    SelectedFontFamily = null;

                                if (EvntControl.NameField1FontSize == 0)
                                    SelectedFontSize = 12;
                                else
                                    SelectedFontSize = EvntControl.NameField1FontSize;
                                if (EvntControl.NameField1Foreground != null)
                                    SelectedFontForeground = EvntControl.NameField1Foreground;
                                else
                                    SelectedFontForeground = null;
                            }
                            break;
                        }
                    case ("NameField2"):
                        {
                            if (EvntControl != null)
                            {
                                if (EvntControl.NameField2FontFamily != null)
                                    SelectedFontFamily = EvntControl.NameField2FontFamily;
                                else
                                    SelectedFontFamily = null;

                                if (EvntControl.NameField2FontSize == 0)
                                    SelectedFontSize = 12;
                                else
                                    SelectedFontSize = EvntControl.NameField2FontSize;
                                if (EvntControl.NameField2Foreground != null)
                                    SelectedFontForeground = EvntControl.NameField2Foreground;
                                else
                                    SelectedFontForeground = null;
                            }
                            break;
                        }
                    case ("NameField3"):
                        {
                            if (EvntControl != null)
                            {
                                if (EvntControl.NameField3FontFamily != null)
                                    SelectedFontFamily = EvntControl.NameField3FontFamily;
                                else
                                    SelectedFontFamily = null;

                                if (EvntControl.NameField3FontSize == 0)
                                    SelectedFontSize = 12;
                                else
                                    SelectedFontSize = EvntControl.NameField3FontSize;
                                if (EvntControl.NameField3Foreground != null)
                                    SelectedFontForeground = EvntControl.NameField3Foreground;
                                else
                                    SelectedFontForeground = null;
                            }
                            break;
                        }
                    case ("NameField4"):
                        {
                            if (EvntControl != null)
                            {
                                if (EvntControl.NameField4FontFamily != null)
                                    SelectedFontFamily = EvntControl.NameField4FontFamily;
                                else
                                    SelectedFontFamily = null;

                                if (EvntControl.NameField4FontSize == 0)
                                    SelectedFontSize = 12;
                                else
                                    SelectedFontSize = EvntControl.NameField4FontSize;
                                if (EvntControl.NameField4Foreground != null)
                                    SelectedFontForeground = EvntControl.NameField4Foreground;
                                else
                                    SelectedFontForeground = null;
                            }
                            break;
                        }
                    case ("DescField1"):
                        {
                            if (EvntControl != null)
                            {
                                if (EvntControl.DescField1FontFamily != null)
                                    SelectedFontFamily = EvntControl.DescField1FontFamily;
                                else
                                    SelectedFontFamily = null;

                                if (EvntControl.DescField1FontSize == 0)
                                    SelectedFontSize = 12;
                                else
                                    SelectedFontSize = EvntControl.DescField1FontSize;
                                if (EvntControl.DescField1Foreground != null)
                                    SelectedFontForeground = EvntControl.DescField1Foreground;
                                else
                                    SelectedFontForeground = null;
                            }
                            break;
                        }
                    case ("DescField2"):
                        {
                            if (EvntControl != null)
                            {
                                if (EvntControl.DescField2FontFamily != null)
                                    SelectedFontFamily = EvntControl.DescField2FontFamily;
                                else
                                    SelectedFontFamily = null;

                                if (EvntControl.DescField2FontSize == 0)
                                    SelectedFontSize = 12;
                                else
                                    SelectedFontSize = EvntControl.DescField2FontSize;
                                if (EvntControl.DescField2Foreground != null)
                                    SelectedFontForeground = EvntControl.DescField2Foreground;
                                else
                                    SelectedFontForeground = null;
                            }
                            break;
                        }
                    case ("DescField3"):
                        {
                            if (EvntControl != null)
                            {
                                if (EvntControl.DescField3FontFamily != null)
                                    SelectedFontFamily = EvntControl.DescField3FontFamily;
                                else
                                    SelectedFontFamily = null;

                                if (EvntControl.DescField3FontSize == 0)
                                    SelectedFontSize = 12;
                                else
                                    SelectedFontSize = EvntControl.DescField3FontSize;
                                if (EvntControl.DescField3Foreground != null)
                                    SelectedFontForeground = EvntControl.DescField3Foreground;
                                else
                                    SelectedFontForeground = null;
                            }
                            break;
                        }
                    case ("DescField4"):
                        {
                            if (EvntControl != null)
                            {
                                if (EvntControl.DescField4FontFamily != null)
                                    SelectedFontFamily = EvntControl.DescField4FontFamily;
                                else
                                    SelectedFontFamily = null;

                                if (EvntControl.DescField4FontSize == 0)
                                    SelectedFontSize = 12;
                                else
                                    SelectedFontSize = EvntControl.DescField4FontSize;
                                if (EvntControl.DescField4Foreground != null)
                                    SelectedFontForeground = EvntControl.DescField4Foreground;
                                else
                                    SelectedFontForeground = null;
                            }
                            break;
                        }
                    case ("DateField1"):
                        {
                            if (EvntControl != null)
                            {
                                if (EvntControl.DateTime1FontFamily != null)
                                    SelectedFontFamily = EvntControl.DateTime1FontFamily;
                                else
                                    SelectedFontFamily = null;

                                if (EvntControl.DateTime1FontSize == 0)
                                    SelectedFontSize = 12;
                                else
                                    SelectedFontSize = EvntControl.DateTime1FontSize;
                                if (EvntControl.DateTime1Foreground != null)
                                    SelectedFontForeground = EvntControl.DateTime1Foreground;
                                else
                                    SelectedFontForeground = null;
                            }
                            break;
                        }
                    case ("DateField2"):
                        {
                            if (EvntControl.DateTime2FontFamily != null)
                                SelectedFontFamily = EvntControl.DateTime2FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (EvntControl.DateTime2FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = EvntControl.DateTime2FontSize;
                            if (EvntControl.DateTime2Foreground != null)
                                SelectedFontForeground = EvntControl.DateTime2Foreground;
                            else
                                SelectedFontForeground = null;
                            break;
                        }
                    case ("DateField3"):
                        {
                            if (EvntControl.DateTime3FontFamily != null)
                                SelectedFontFamily = EvntControl.DateTime3FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (EvntControl.DateTime3FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = EvntControl.DateTime3FontSize;
                            if (EvntControl.DateTime3Foreground != null)
                                SelectedFontForeground = EvntControl.DateTime3Foreground;
                            else
                                SelectedFontForeground = null;
                            break;
                        }
                    case ("DateField4"):
                        {
                            if (EvntControl.DateTime4FontFamily != null)
                                SelectedFontFamily = EvntControl.DateTime4FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (EvntControl.DateTime4FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = EvntControl.DateTime4FontSize;
                            if (EvntControl.DateTime4Foreground != null)
                                SelectedFontForeground = EvntControl.DateTime4Foreground;
                            else
                                SelectedFontForeground = null;
                            break;
                        }
                    case ("IntField1"):
                        {
                            if (EvntControl.IntField1FontFamily != null)
                                SelectedFontFamily = EvntControl.IntField1FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (EvntControl.IntField1FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = EvntControl.IntField1FontSize;
                            if (EvntControl.IntField1Foreground != null)
                                SelectedFontForeground = EvntControl.IntField1Foreground;
                            else
                                SelectedFontForeground = null;
                            break;
                        }
                    case ("IntField2"):
                        {
                            if (EvntControl.IntField2FontFamily != null)
                                SelectedFontFamily = EvntControl.IntField2FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (EvntControl.IntField2FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = EvntControl.IntField2FontSize;
                            if (EvntControl.IntField2Foreground != null)
                                SelectedFontForeground = EvntControl.IntField2Foreground;
                            else
                                SelectedFontForeground = null;
                            break;
                        }
                    case ("DecimalField1"):
                        {
                            if (EvntControl.DecimalField1FontFamily != null)
                                SelectedFontFamily = EvntControl.DecimalField1FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (EvntControl.DecimalField1FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = EvntControl.DecimalField1FontSize;
                            if (EvntControl.DecimalField1Foreground != null)
                                SelectedFontForeground = EvntControl.DecimalField1Foreground;
                            else
                                SelectedFontForeground = null;
                            break;
                        }
                    case ("DecimalField2"):
                        {
                            if (EvntControl.DecimalField2FontFamily != null)
                                SelectedFontFamily = EvntControl.DecimalField2FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (EvntControl.DecimalField2FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = EvntControl.DecimalField2FontSize;
                            if (EvntControl.DecimalField2Foreground != null)
                                SelectedFontForeground = EvntControl.DecimalField2Foreground;
                            else
                                SelectedFontForeground = null;
                            break;
                        }
                }

                cbFontSize.SelectedIndex = cbFontSize.Items.IndexOf(SelectedFontSize);

                if (SelectedFontFamily == null)
                {
                    cbFontFamily.Text = "Arial";
                }
                else
                    cbFontFamily.SelectedValue = SelectedFontFamily;
                ChangeFont();
            }
        }

        private void cbFontFamily_DropDownClosed(object sender, EventArgs e)
        {
            if (EvntControl != null)
            {
                SelectedFontFamily = (FontFamily)cbFontFamily.SelectedItem;
                ChangeFont();
            }
        }

        private void cbFontSize_DropDownClosed(object sender, EventArgs e)
        {
            if (EvntControl != null)
            {
                if (cbFontSize.SelectedValue != null)
                {
                    SelectedFontSize = Convert.ToInt32(cbFontSize.SelectedValue);
                    ChangeFont();
                }
            }
        }
    }
}
