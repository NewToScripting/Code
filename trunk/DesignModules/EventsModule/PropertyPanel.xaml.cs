using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Inspire;
using Inspire.AnimationLibrary;
using System.Windows.Shapes;
using Inspire.Services.WeakEventHandlers;

namespace EventsModule
{
    /// <summary>
    /// Interaction logic for PropertyPanel.xaml
    /// </summary>
    public partial class PropertyPanel : INotifyPropertyChanged, IDisposable, IWeakEventListener
    {
        //private List<Feed> feedSources;
        private FontFamily selectedFontFamily;
        private Brush selectedFontForeground;
        private double selectedFontSize;
        private double selectedFontWidth;
        private ObservableCollection<EventTextBlock> fieldNames;
        private bool IsPanelLoaded;
        private TextAlignment selectedTextAlignment;

        private readonly int[] fontSizes = { 8, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 44, 46, 48, 50, 52, 54, 60, 64, 68, 72, 80, 84, 90, 96, 104, 110, 118 };
        private string selectedAnimation;

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
                    //ChangeFont();
                    OnPropertyChanged("SelectedFontForeground");
                }
            }
        }

        public double SelectedFontSize
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

        public double SelectedFontWidth
        {
            get { return selectedFontWidth; }
            set
            {
                if (value != selectedFontWidth)
                {
                    selectedFontWidth = value;
                    OnPropertyChanged("SelectedFontWidth");
                }
            }
        }

        public TextAlignment SelectedTextAlignment
        {
            get { return selectedTextAlignment; }
            set
            {
                if (value != selectedTextAlignment)
                {
                    selectedTextAlignment = value;
                    OnPropertyChanged("SelectedTextAlignment");
                }
            }
        }

        public string SelectedAnimation
        {
            get { return selectedAnimation;}
            set
            {
                if (value != selectedAnimation)
                {
                    selectedAnimation = value;
                    OnPropertyChanged("SelectedAnimation");
                }
            }
        }

        public PropertyPanel()
        {
            InitializeComponent();
            DataContext = InspireApp.SelectedContext;
            LoadedEventManager.AddListener(this, this);

            var alignList = new List<TextAlignment>();
            alignList.Add(TextAlignment.Right);
            alignList.Add(TextAlignment.Left);
            alignList.Add(TextAlignment.Justify);
            alignList.Add(TextAlignment.Center);

            cbAlignment.ItemsSource = alignList;

            cbFieldAnimation.ItemsSource = AnimationManager.GetControlLoadingAnimations();

            cbFontFamily.SelectionChanged += delegate
                                                 {
                                                     if (cbFontFamily.SelectedItem != null)
                                                     {
                                                         SelectedFontFamily =
                                                             (FontFamily)
                                                             ((ListBoxItem) cbFontFamily.SelectedItem).Content;
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

            tbSelectedFieldWidth.TextChanged += delegate
                                                    {
                                                        if (tbSelectedFieldWidth.Text != null)
                                                        {
                                                            double fieldWidth;
                                                            if (double.TryParse(tbSelectedFieldWidth.Text, out fieldWidth))
                                                            {
                                                                SelectedFontWidth = fieldWidth;
                                                                ChangeFont();
                                                            }
                                                        }
                                                    };

            cbFieldAnimation.SelectionChanged += delegate
                                                     {
                                                         if (cbFieldAnimation.SelectedValue != null)
                                                         {
                                                             SelectedAnimation = cbFieldAnimation.SelectedValue.ToString();
                                                             ChangeFont();
                                                         }
                                                     };

            cbAlignment.SelectionChanged += delegate
            {
                if (cbAlignment.SelectedValue != null)
                {
                    SelectedTextAlignment =  (TextAlignment)cbAlignment.SelectedValue;
                    ChangeFont();
                }
            };

            evtPanelStyler.ToggleChanged += new RoutedEventHandler(evtPanelStyler_ToggleChanged);


            DataContextChanged += new DependencyPropertyChangedEventHandler(PropertyPanel_DataContextChanged);
        }

        void PropertyPanel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            propBase.SetDataContext();
            if (IsPanelLoaded && InspireApp.SelectedContext != null)
                RefreshPropertyDropdown();
        }

        void evtPanelStyler_ToggleChanged(object sender, RoutedEventArgs e)
        {
            ChangeFont();
        }

        //private TextAlignment GetAlignment(object p)
        //{
        //    if (p.GetType() == typeof(ComboBoxItem))
        //    {
        //        switch (((ComboBoxItem)p).Content.ToString())
        //        {
        //            case("Left"):
        //                return TextAlignment.Left;
        //            case ("Center"):
        //                return TextAlignment.Center;
        //            case ("Right"):
        //                return TextAlignment.Right;
        //            case ("Justify"):
        //                return TextAlignment.Justify;
        //            default:
        //                return TextAlignment.Left;
        //        }
        //    }
        //    return TextAlignment.Center;
        //}

        private void PropertyPanel_Loaded(object sender, EventArgs e)
        {
            if (!IsPanelLoaded)
            {
                //DataContext = ((ContentControl)((FrameworkElement)sender).DataContext).Content;

                RefreshPropertyDropdown();

                //if(fieldNames.Count > 0)
                //    cbEventField.SelectedIndex = 0;

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

        private void RefreshPropertyDropdown()
        {
            if (fieldNames != null)
            {
                fieldNames.Clear();
            }

            var eventControl = ((ContentControl)((ContentControl) InspireApp.SelectedContext).Content).Content as IEventControl;

            if(eventControl == null) return;

            fieldNames = new ObservableCollection<EventTextBlock>();

            foreach (EventTextBlock block in eventControl.EventColumns.Items)
            {
                var textBlock = new EventTextBlock(block.Text);
                fieldNames.Add(textBlock);
            }

            cbEventField.ItemsSource = fieldNames;
        }

        private void FillFields(FeedContentControl feedContentControl)
        {

        }

        private void SetFieldValues(TextBlock focusedField)
        {
            if (focusedField != null)
            {
                SelectedFontFamily = focusedField.FontFamily;
                SelectedFontSize = focusedField.FontSize;
                SelectedFontForeground = focusedField.Foreground;
                SelectedFontWidth = focusedField.Width > 0 ? focusedField.Width : focusedField.ActualWidth;
                SelectedTextAlignment = focusedField.TextAlignment;
                SelectedAnimation = focusedField.Tag != null ? focusedField.Tag.ToString() : "None";
            }

            cbFontSize.Text = SelectedFontSize.ToString();

            cbFontFamily.Text = SelectedFontFamily == null ? "Arial" : SelectedFontFamily.ToString();

            cbFieldAnimation.Text = !string.IsNullOrEmpty(SelectedAnimation) ? SelectedAnimation : "None";

            tbSelectedFieldWidth.Text = SelectedFontWidth.ToString();

            btnFontColor.Fill = SelectedFontForeground ?? Brushes.White;

            cbAlignment.SelectedItem = SelectedTextAlignment;

            //ChangeFont();
        }

        private void ChangeFont()
        {
            var eventControl =
                    (IEventControl)((ContentControl)((ContentControl)(ContentControl)InspireApp.SelectedContext).Content).Content;

            if (eventControl != null)
            {
                if(eventControl is EventControl)
                {
                    lblNumLoops.Visibility = System.Windows.Visibility.Visible;
                    cbLoops.Visibility = System.Windows.Visibility.Visible;
                    lblAdvanceSlide.Visibility = System.Windows.Visibility.Visible;
                    cbLoops.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    lblNumLoops.Visibility = System.Windows.Visibility.Collapsed;
                    cbLoops.Visibility = System.Windows.Visibility.Collapsed;
                    lblAdvanceSlide.Visibility = System.Windows.Visibility.Collapsed;
                    cbLoops.Visibility = System.Windows.Visibility.Collapsed;
                }

                if (cbEventField.SelectedItem != null)
                {
                    ((EventTextBlock)eventControl.EventColumns.Items[cbEventField.SelectedIndex]).FontFamily = SelectedFontFamily;
                    ((EventTextBlock)eventControl.EventColumns.Items[cbEventField.SelectedIndex]).FontSize = SelectedFontSize;
                    ((EventTextBlock)eventControl.EventColumns.Items[cbEventField.SelectedIndex]).Foreground = SelectedFontForeground;
                    ((EventTextBlock)eventControl.EventColumns.Items[cbEventField.SelectedIndex]).Width = SelectedFontWidth;
                    ((EventTextBlock)eventControl.EventColumns.Items[cbEventField.SelectedIndex]).TextAlignment = SelectedTextAlignment;
                    ((EventTextBlock)eventControl.EventColumns.Items[cbEventField.SelectedIndex]).Tag = SelectedAnimation;
                    if (((EventTextBlock)eventControl.EventColumns.Items[cbEventField.SelectedIndex]).IsHeader)
                    {
                        eventControl.HeaderRow.FontFamily = SelectedFontFamily;
                        eventControl.HeaderRow.FontSize = SelectedFontSize;
                        eventControl.HeaderRow.Foreground = SelectedFontForeground;
                        eventControl.HeaderRow.TextAlignment = SelectedTextAlignment;
                        eventControl.HeaderRow.Tag = SelectedAnimation;
                        eventControl.HeaderRow.FontWeight = ((EventTextBlock) eventControl.EventColumns.Items[cbEventField.SelectedIndex]).FontWeight;
                        eventControl.HeaderRow.TextDecorations = ((EventTextBlock) eventControl.EventColumns.Items[cbEventField.SelectedIndex]).TextDecorations;
                        eventControl.HeaderRow.FontStyle = ((EventTextBlock) eventControl.EventColumns.Items[cbEventField.SelectedIndex]).FontStyle;
                    }
                    eventControl.UpdateAppearance();
                    evtPanelStyler.DataContext = eventControl.EventColumns.Items[cbEventField.SelectedIndex];
                }
            }
        }

        private void ChangeTitleColor_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            SolidColorBrush fontBrush = (SolidColorBrush) SelectedFontForeground;

            cPicker.StartingColor = fontBrush.Color;
            //cPicker.Owner = this;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool) dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                SelectedFontForeground = selectedColor;
                ((Rectangle) (sender)).Fill = selectedColor;
                ChangeFont();
            }
            e.Handled = true;
        }

        private void tbField_DropDownClosed(object sender, EventArgs e)
        {
            if (cbEventField.SelectedIndex > -1)
            {
                IEventControl eventControl =
                    (IEventControl)((ContentControl)((ContentControl)(ContentControl)InspireApp.SelectedContext).Content).Content;

                if (eventControl.EventColumns.Items[cbEventField.SelectedIndex] is EventTextBlock)
                {
                    if (((EventTextBlock) eventControl.EventColumns.Items[cbEventField.SelectedIndex]).IsHeader)
                        SetFieldValues(eventControl.HeaderRow);
                    else
                        SetFieldValues(((TextBlock)eventControl.EventColumns.Items[cbEventField.SelectedIndex]));
                }
                else
                    SetFieldValues(((TextBlock)eventControl.EventColumns.Items[cbEventField.SelectedIndex]));

                evtPanelStyler.DataContext = eventControl.EventColumns.Items[cbEventField.SelectedIndex];
            }
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
            //bool doUpdate = false;
            //FeedContentControl feedContentControl =
            //    (FeedContentControl) ((ContentControl)((ContentControl) (((ComboBox) (sender)).DataContext)).Content).Content;
            //if (cbDataSource.SelectedValue != null)
            //{
            //    if (feedContentControl.TemplateDataSource != cbDataSource.SelectedValue.ToString())
            //        doUpdate = true;
            //    feedContentControl.TemplateDataSource = cbDataSource.SelectedValue.ToString();
            //    // TODO: Change so that the default event DataSource can be set
            //}
            //if (doUpdate)
            //    feedContentControl.PullNewFeed(feedContentControl.TemplateDataSource);
            //FillFields(feedContentControl);
        }

        private void tbSecondsPerPage_DropDownClosed(object sender, EventArgs e)
        {
            IEventControl eventControl =
                    (IEventControl)((ContentControl)((ContentControl)(ContentControl)InspireApp.SelectedContext).Content).Content;
            eventControl.SecondsPerPage = (Convert.ToInt32(((ComboBox) sender).Text));
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (propBase != null)
                propBase.Dispose();
            propBase = null;

            BindingOperations.ClearBinding(cbFontSize, TextBlock.TextProperty);
            BindingOperations.ClearBinding(tbSelectedFieldWidth, TextBlock.TextProperty);
            BindingOperations.ClearBinding(ckbShowAllRooms, CheckBox.IsCheckedProperty);

            if(evtPanelStyler != null)
                evtPanelStyler.Content = null;
            evtPanelStyler = null;

            if(fieldNames != null)
                fieldNames.Clear();
            fieldNames = null;

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

        //#region IPropertyPanel Members

        //public static readonly RoutedEvent HidePropertiesEvent = EventManager.RegisterRoutedEvent("HideProperties", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(FrameworkElement));

        //// Provide CLR accessors for the event
        //public event RoutedEventHandler HideProperties
        //{
        //    add { AddHandler(HidePropertiesEvent, value); }
        //    remove { RemoveHandler(HidePropertiesEvent, value); }
        //}


        //public void HidePropertyPanel()
        //{
        //    RaiseEvent(new RoutedEventArgs(HidePropertiesEvent));
        //}

        //#endregion

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof (LoadedEventManager))
            {
                PropertyPanel_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion

    }
}