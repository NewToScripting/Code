using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Inspire;
using Inspire.Events.Proxy;
using Inspire.MediaObjects;
using System.Windows.Shapes;
using Inspire.Services.WeakEventHandlers;

namespace EventsModule
{
    /// <summary>
    /// Interaction logic for PropertyPanel.xaml
    /// </summary>
    public partial class PropertyPanel : INotifyPropertyChanged , IDisposable , IWeakEventListener
    {
        private List<Feed> feedSources;
        private FontFamily selectedFontFamily;
        private Brush selectedFontForeground;
        private int selectedFontSize;
        private ObservableCollection<ComboBoxItem> fieldNames;
        private bool IsPanelLoaded;

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

        public PropertyPanel()
        {
            InitializeComponent();
            LoadedEventManager.AddListener(this, this);

            cbFontFamily.SelectionChanged += delegate
                                                 {
                                                     if (cbFontFamily.SelectedItem != null)
                                                     {
                                                         SelectedFontFamily = (FontFamily)((ListBoxItem)cbFontFamily.SelectedItem).Content;
                                                         ChangeFont();
                                                     }
                                                 };
            cbFontSize.SelectionChanged += delegate
                                                {
                                                    if (cbFontSize.SelectedValue != null)
                                                    {
                                                        SelectedFontSize = Convert.ToInt32(cbFontSize.SelectedValue);
                                                        ChangeFont();
                                                    }
                                                };
            
        }

        void PropertyPanel_Loaded(object sender, EventArgs e)
        {
            if (!IsPanelLoaded)
            {
                //if(fieldNames != null)
                //{
                //    fieldNames.Clear();   
                //}

                //fieldNames = new ObservableCollection<ComboBoxItem>();

                //cbEventField.ItemsSource = fieldNames;

                //feedSources = FeedManager.GetFeeds();

                //cbDataSource.ItemsSource = feedSources;

                //cbDataSource.DisplayMemberPath = "Description";

                //cbDataSource.SelectedValuePath = "GUID";

                //FeedContentControl feedContentControl = (FeedContentControl)((DesignContentControl)(((UserControl)(sender)).DataContext)).Content;

                //foreach (var feed in feedSources)
                //{
                //    if (feedContentControl.TemplateDataSource == feed.GUID)
                //    {
                //        cbDataSource.SelectedValue = feedContentControl.TemplateDataSource;
                //        break;
                //    }

                //}

                //SelectedFontFamily = feedContentControl.NameField1FontFamily;

                //SelectedFontSize = feedContentControl.NameField1FontSize;

                //cbFontSize.SelectedIndex = cbFontSize.Items.IndexOf(SelectedFontSize);

                //SetFieldValues(feedContentControl);
                IsPanelLoaded = true;
            }
        }

        private void FillFields(FeedContentControl feedContentControl)
        {
            fieldNames.Clear();

            foreach (FeedTemplate.FieldsEnum fieldsEnum in Schedule.GetSelectedEnumValues(feedContentControl.TemplateFields))
            {
                //TODO: Change to switch statement to speed up
                if (fieldsEnum.ToString() == "NameField1" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).NameField1Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed) cbDataSource.SelectedItem).NameField1Def;
                    comboBoxItem.Tag = "NameField1";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "NameField1")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "NameField1";
                    comboBoxItem.Tag = "NameField1";
                    fieldNames.Add(comboBoxItem);
                }

                if (fieldsEnum.ToString() == "NameField2" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).NameField2Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed)cbDataSource.SelectedItem).NameField2Def;
                    comboBoxItem.Tag = "NameField2";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "NameField2")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "NameField2";
                    comboBoxItem.Tag = "NameField2";
                    fieldNames.Add(comboBoxItem);
                }
                if (fieldsEnum.ToString() == "NameField3" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).NameField3Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed)cbDataSource.SelectedItem).NameField3Def;
                    comboBoxItem.Tag = "NameField3";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "NameField3")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "NameField3";
                    comboBoxItem.Tag = "NameField3";
                    fieldNames.Add(comboBoxItem);
                }
                if (fieldsEnum.ToString() == "NameField4" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).NameField4Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed)cbDataSource.SelectedItem).NameField4Def;
                    comboBoxItem.Tag = "NameField4";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "NameField4")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "NameField4";
                    comboBoxItem.Tag = "NameField4";
                    fieldNames.Add(comboBoxItem);
                }
                if (fieldsEnum.ToString() == "DescField1" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).DescField1Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed)cbDataSource.SelectedItem).DescField1Def;
                    comboBoxItem.Tag = "DescField1";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "DescField1")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "DescField1";
                    comboBoxItem.Tag = "DescField1";
                    fieldNames.Add(comboBoxItem);
                }
                if (fieldsEnum.ToString() == "DescField2" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).DescField2Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed)cbDataSource.SelectedItem).DescField2Def;
                    comboBoxItem.Tag = "DescField2";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "DescField2")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "DescField2";
                    comboBoxItem.Tag = "DescField2";
                    fieldNames.Add(comboBoxItem);
                }
                if (fieldsEnum.ToString() == "DescField3" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).DescField3Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed)cbDataSource.SelectedItem).DescField3Def;
                    comboBoxItem.Tag = "DescField3";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "DescField3")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "DescField3";
                    comboBoxItem.Tag = "DescField3";
                    fieldNames.Add(comboBoxItem);
                }
                if (fieldsEnum.ToString() == "DescField4" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).DescField4Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed)cbDataSource.SelectedItem).DescField4Def;
                    comboBoxItem.Tag = "DescField4";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "DescField4")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "DescField4";
                    comboBoxItem.Tag = "DescField4";
                    fieldNames.Add(comboBoxItem);
                }
                if (fieldsEnum.ToString() == "IntField1" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).IntField1Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed)cbDataSource.SelectedItem).IntField1Def;
                    comboBoxItem.Tag = "IntField1";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "IntField1")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "IntField1";
                    comboBoxItem.Tag = "IntField1";
                    fieldNames.Add(comboBoxItem);
                }
                if (fieldsEnum.ToString() == "IntField2" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).IntField2Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed)cbDataSource.SelectedItem).IntField2Def;
                    comboBoxItem.Tag = "IntField2";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "IntField2")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "IntField2";
                    comboBoxItem.Tag = "IntField2";
                    fieldNames.Add(comboBoxItem);
                }
                if (fieldsEnum.ToString() == "DecimalField1" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).DecimalField1Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed)cbDataSource.SelectedItem).DecimalField1Def;
                    comboBoxItem.Tag = "DecimalField1";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "DecimalField1")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "DecimalField1";
                    comboBoxItem.Tag = "DecimalField1";
                    fieldNames.Add(comboBoxItem);
                }
                if (fieldsEnum.ToString() == "DecimalField2" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).DecimalField2Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed)cbDataSource.SelectedItem).DecimalField2Def;
                    comboBoxItem.Tag = "DecimalField2";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "DecimalField2")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "DecimalField2";
                    comboBoxItem.Tag = "DecimalField2";
                    fieldNames.Add(comboBoxItem);
                }
                if (fieldsEnum.ToString() == "DateField1" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).DateField1Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed)cbDataSource.SelectedItem).DateField1Def;
                    comboBoxItem.Tag = "DateField1";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "DateField1")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "DateField1";
                    comboBoxItem.Tag = "DateField1";
                    fieldNames.Add(comboBoxItem);
                }
                if (fieldsEnum.ToString() == "DateField2" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).DateField2Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed)cbDataSource.SelectedItem).DateField2Def;
                    comboBoxItem.Tag = "DateField2";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "DateField2")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "DateField2";
                    comboBoxItem.Tag = "DateField2";
                    fieldNames.Add(comboBoxItem);
                }
                if (fieldsEnum.ToString() == "DateField3" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).DateField3Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed)cbDataSource.SelectedItem).DateField3Def;
                    comboBoxItem.Tag = "DateField3";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "DateField3")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "DateField3";
                    comboBoxItem.Tag = "DateField3";
                    fieldNames.Add(comboBoxItem);
                }
                if (fieldsEnum.ToString() == "DateField4" && !string.IsNullOrEmpty(((Feed)cbDataSource.SelectedItem).DateField4Def))
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((Feed)cbDataSource.SelectedItem).DateField4Def;
                    comboBoxItem.Tag = "DateField4";
                    fieldNames.Add(comboBoxItem);
                }
                else if (fieldsEnum.ToString() == "DateField4")
                {
                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = "DateField4";
                    comboBoxItem.Tag = "DateField4";
                    fieldNames.Add(comboBoxItem);
                }
            }

            if (cbEventField.Items.Count > 0)
                cbEventField.SelectedItem = cbEventField.Items[0]; // TODO: Change to choose last Field Clicked On
        }

        private void SetFieldValues(FeedContentControl feedControl)
        {
            if(cbEventField.Items.Count > 0)
            switch (((ComboBoxItem)cbEventField.SelectedItem).Tag.ToString())
            {
                case ("NameField1"):
                    {
                        if (feedControl != null)
                        {
                            if (feedControl.NameField1FontFamily != null)
                                SelectedFontFamily = feedControl.NameField1FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (feedControl.NameField1FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = feedControl.NameField1FontSize;
                            if (feedControl.NameField1Foreground != null)
                                SelectedFontForeground = feedControl.NameField1Foreground;
                            else
                                SelectedFontForeground = null;
                        }
                        break;
                    }
                case ("NameField2"):
                    {
                        if (feedControl != null)
                        {
                            if (feedControl.NameField2FontFamily != null)
                                SelectedFontFamily = feedControl.NameField2FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (feedControl.NameField2FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = feedControl.NameField2FontSize;
                            if (feedControl.NameField2Foreground != null)
                                SelectedFontForeground = feedControl.NameField2Foreground;
                            else
                                SelectedFontForeground = null;
                        }
                        break;
                    }
                case ("NameField3"):
                    {
                        if (feedControl != null)
                        {
                            if (feedControl.NameField3FontFamily != null)
                                SelectedFontFamily = feedControl.NameField3FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (feedControl.NameField3FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = feedControl.NameField3FontSize;
                            if (feedControl.NameField3Foreground != null)
                                SelectedFontForeground = feedControl.NameField3Foreground;
                            else
                                SelectedFontForeground = null;
                        }
                        break;
                    }
                case ("NameField4"):
                    {
                        if (feedControl != null)
                        {
                            if (feedControl.NameField4FontFamily != null)
                                SelectedFontFamily = feedControl.NameField4FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (feedControl.NameField4FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = feedControl.NameField4FontSize;
                            if (feedControl.NameField4Foreground != null)
                                SelectedFontForeground = feedControl.NameField4Foreground;
                            else
                                SelectedFontForeground = null;
                        }
                        break;
                    }
                case ("DescField1"):
                    {
                        if (feedControl != null)
                        {
                            if (feedControl.DescField1FontFamily != null)
                                SelectedFontFamily = feedControl.DescField1FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (feedControl.DescField1FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = feedControl.DescField1FontSize;
                            if (feedControl.DescField1Foreground != null)
                                SelectedFontForeground = feedControl.DescField1Foreground;
                            else
                                SelectedFontForeground = null;
                        }
                        break;
                    }
                case ("DescField2"):
                    {
                        if (feedControl != null)
                        {
                            if (feedControl.DescField2FontFamily != null)
                                SelectedFontFamily = feedControl.DescField2FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (feedControl.DescField2FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = feedControl.DescField2FontSize;
                            if (feedControl.DescField2Foreground != null)
                                SelectedFontForeground = feedControl.DescField2Foreground;
                            else
                                SelectedFontForeground = null;
                        }
                        break;
                    }
                case ("DescField3"):
                    {
                        if (feedControl != null)
                        {
                            if (feedControl.DescField3FontFamily != null)
                                SelectedFontFamily = feedControl.DescField3FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (feedControl.DescField3FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = feedControl.DescField3FontSize;
                            if (feedControl.DescField3Foreground != null)
                                SelectedFontForeground = feedControl.DescField3Foreground;
                            else
                                SelectedFontForeground = null;
                        }
                        break;
                    }
                case ("DescField4"):
                    {
                        if (feedControl != null)
                        {
                            if (feedControl.DescField4FontFamily != null)
                                SelectedFontFamily = feedControl.DescField4FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (feedControl.DescField4FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = feedControl.DescField4FontSize;
                            if (feedControl.DescField4Foreground != null)
                                SelectedFontForeground = feedControl.DescField4Foreground;
                            else
                                SelectedFontForeground = null;
                        }
                        break;
                    }
                case ("DateField1"):
                    {
                        if (feedControl != null)
                        {
                            if (feedControl.DateTime1FontFamily != null)
                                SelectedFontFamily = feedControl.DateTime1FontFamily;
                            else
                                SelectedFontFamily = null;

                            if (feedControl.DateTime1FontSize == 0)
                                SelectedFontSize = 12;
                            else
                                SelectedFontSize = feedControl.DateTime1FontSize;
                            if (feedControl.DateTime1Foreground != null)
                                SelectedFontForeground = feedControl.DateTime1Foreground;
                            else
                                SelectedFontForeground = null;
                        }
                        break;
                    }
                case ("DateField2"):
                    {
                        if (feedControl.DateTime2FontFamily != null)
                            SelectedFontFamily = feedControl.DateTime2FontFamily;
                        else
                            SelectedFontFamily = null;

                        if (feedControl.DateTime2FontSize == 0)
                            SelectedFontSize = 12;
                        else
                            SelectedFontSize = feedControl.DateTime2FontSize;
                        if (feedControl.DateTime2Foreground != null)
                            SelectedFontForeground = feedControl.DateTime2Foreground;
                        else
                            SelectedFontForeground = null;
                        break;
                    }
                case ("DateField3"):
                    {
                        if (feedControl.DateTime3FontFamily != null)
                            SelectedFontFamily = feedControl.DateTime3FontFamily;
                        else
                            SelectedFontFamily = null;

                        if (feedControl.DateTime3FontSize == 0)
                            SelectedFontSize = 12;
                        else
                            SelectedFontSize = feedControl.DateTime3FontSize;
                        if (feedControl.DateTime3Foreground != null)
                            SelectedFontForeground = feedControl.DateTime3Foreground;
                        else
                            SelectedFontForeground = null;
                        break;
                    }
                case ("DateField4"):
                    {
                        if (feedControl.DateTime4FontFamily != null)
                            SelectedFontFamily = feedControl.DateTime4FontFamily;
                        else
                            SelectedFontFamily = null;

                        if (feedControl.DateTime4FontSize == 0)
                            SelectedFontSize = 12;
                        else
                            SelectedFontSize = feedControl.DateTime4FontSize;
                        if (feedControl.DateTime4Foreground != null)
                            SelectedFontForeground = feedControl.DateTime4Foreground;
                        else
                            SelectedFontForeground = null;
                        break;
                    }
                case ("IntField1"):
                    {
                        if (feedControl.IntField1FontFamily != null)
                            SelectedFontFamily = feedControl.IntField1FontFamily;
                        else
                            SelectedFontFamily = null;

                        if (feedControl.IntField1FontSize == 0)
                            SelectedFontSize = 12;
                        else
                            SelectedFontSize = feedControl.IntField1FontSize;
                        if (feedControl.IntField1Foreground != null)
                            SelectedFontForeground = feedControl.IntField1Foreground;
                        else
                            SelectedFontForeground = null;
                        break;
                    }
                case ("IntField2"):
                    {
                        if (feedControl.IntField2FontFamily != null)
                            SelectedFontFamily = feedControl.IntField2FontFamily;
                        else
                            SelectedFontFamily = null;

                        if (feedControl.IntField2FontSize == 0)
                            SelectedFontSize = 12;
                        else
                            SelectedFontSize = feedControl.IntField2FontSize;
                        if (feedControl.IntField2Foreground != null)
                            SelectedFontForeground = feedControl.IntField2Foreground;
                        else
                            SelectedFontForeground = null;
                        break;
                    }
                case ("DecimalField1"):
                    {
                        if (feedControl.DecimalField1FontFamily != null)
                            SelectedFontFamily = feedControl.DecimalField1FontFamily;
                        else
                            SelectedFontFamily = null;

                        if (feedControl.DecimalField1FontSize == 0)
                            SelectedFontSize = 12;
                        else
                            SelectedFontSize = feedControl.DecimalField1FontSize;
                        if (feedControl.DecimalField1Foreground != null)
                            SelectedFontForeground = feedControl.DecimalField1Foreground;
                        else
                            SelectedFontForeground = null;
                        break;
                    }
                case ("DecimalField2"):
                    {
                        if (feedControl.DecimalField2FontFamily != null)
                            SelectedFontFamily = feedControl.DecimalField2FontFamily;
                        else
                            SelectedFontFamily = null;

                        if (feedControl.DecimalField2FontSize == 0)
                            SelectedFontSize = 12;
                        else
                            SelectedFontSize = feedControl.DecimalField2FontSize;
                        if (feedControl.DecimalField2Foreground != null)
                            SelectedFontForeground = feedControl.DecimalField2Foreground;
                        else
                            SelectedFontForeground = null;
                        break;
                    }
            }

            cbFontSize.Text = SelectedFontSize.ToString();

            if (SelectedFontFamily == null)
            {
                cbFontFamily.Text = "Arial";
            }
            else
                cbFontFamily.Text = SelectedFontFamily.ToString();

            if(SelectedFontForeground == null)
            {
                btnFontColor.Fill = Brushes.White;
            }
            else
            {
                btnFontColor.Fill = SelectedFontForeground;
            }

            ChangeFont();
        }

        private void ChangeFont()
        {
            FeedContentControl EvntControl = (FeedContentControl)((DesignContentControl)((cbDataSource).DataContext)).Content;
            if(cbEventField.SelectedItem != null)
            switch (((ComboBoxItem)cbEventField.SelectedItem).Tag.ToString())
            {
                case ("NameField1"):
                    {
                        if (EvntControl != null)
                        {
                            if (SelectedFontFamily != null)
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

        private void ChangeTitleColor_Click(object sender, RoutedEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            SolidColorBrush fontBrush = (SolidColorBrush)SelectedFontForeground;

            cPicker.StartingColor = fontBrush.Color;
            //cPicker.Owner = this;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                SelectedFontForeground = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;
                ChangeFont();
            }
            e.Handled = true;
        }

        private void tbField_DropDownClosed(object sender, EventArgs e)
        {
            FeedContentControl feedContentControl = (FeedContentControl)((DesignContentControl)(((ComboBox)(sender)).DataContext)).Content;
            SetFieldValues(feedContentControl);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private void cbDataSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool doUpdate = false;
            FeedContentControl feedContentControl = (FeedContentControl)((DesignContentControl)(((ComboBox)(sender)).DataContext)).Content;
            if (cbDataSource.SelectedValue != null)
            {
                if(feedContentControl.TemplateDataSource != cbDataSource.SelectedValue.ToString())
                    doUpdate = true;
                feedContentControl.TemplateDataSource = cbDataSource.SelectedValue.ToString();
                    // TODO: Change so that the default event DataSource can be set
            }
            if(doUpdate)
                feedContentControl.PullNewFeed(feedContentControl.TemplateDataSource);
            FillFields(feedContentControl);
        }

        private void tbSecondsPerPage_DropDownClosed(object sender, EventArgs e)
        {
            FeedContentControl feedContentControl = (FeedContentControl)((DesignContentControl)(((ComboBox)(sender)).DataContext)).Content;
            feedContentControl.ChangeScrollSpeed(Convert.ToInt32(((ComboBox)sender).Text));
        }


        #region IDisposable Members

        public void Dispose()
        {
            if (Content != null)
                Content = null;
            if (grid != null)
            {
                if (grid.Child != null)
                    grid.Child = null;

                grid = null;
            }
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                PropertyPanel_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
