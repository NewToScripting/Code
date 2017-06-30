using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Inspire;
using Inspire.Events.Proxy;

namespace EventsModule
{
    /// <summary>
    /// Interaction logic for ModuleDialog.xaml
    /// </summary>
    public partial class ModuleDialog
    {

        public ObservableCollection<EventTextBlock> EventTextBlocks { get; set; }

        public ObservableCollection<UIElement> ModuleEventTextBlocks { get; set; }

        public ObservableCollection<EventTextBlock> AvailableTextBlocks { get; set; }

        public TextBlock HeaderTextBlock { get; set; }

        public int SecondsPerPage { get; set; }

        public bool ShowAllEventsToday { get; set; }

        public bool DontShowExpiredEvents { get; set; }

        public bool? ShowEventsForAllDisplays { get; set; }

        public string SelectedAnimation { get; set; }

        //public bool SelectedFieldIsBold { get; set; }

        //public bool SelectedFieldIsItalic { get; set; }

        //public bool SelectedFieldIsUnderlined { get; set; }

        private readonly int[] fontSizes = { 8, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 44, 46, 48, 50, 52, 54, 60, 64, 68, 72 };
        private readonly int[] secondsPerPage = { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 22, 24, 26, 28, 30, 35, 40, 45, 50, 60, 70, 80, 100, 120, 150, 180 };

        private int headerIndex = -1;

        public static readonly DependencyProperty CurrentItemIndexProperty =
            DependencyProperty.Register("CurrentItemIndex", typeof(int), typeof(ModuleDialog),
            new PropertyMetadata(new PropertyChangedCallback(currentItemIndex_changed)));

        public static readonly DependencyProperty SelectedFieldIsBold =
            DependencyProperty.Register("SelectedFieldIsBold", typeof (bool), typeof (ModuleDialog),
                                        new PropertyMetadata());

        public int CurrentItemIndex
        {
            get { return (int)GetValue(CurrentItemIndexProperty); }
            set { SetValue(CurrentItemIndexProperty, value); }
        }

        private static void currentItemIndex_changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            ModuleDialog moduleDialog = (ModuleDialog)element;
            moduleDialog.OnCurrentItemIndexChanged((int)e.OldValue, (int)e.NewValue);
        }

        protected virtual void OnCurrentItemIndexChanged(int oldValue, int newValue)
        {
            //resetEdgeCommands();
            RoutedPropertyChangedEventArgs<int> args = new RoutedPropertyChangedEventArgs<int>(oldValue, newValue);
            args.RoutedEvent = CurrentItemIndexChangedEvent;
            RaiseEvent(args);
        }

        public static RoutedEvent CurrentItemIndexChangedEvent =
            EventManager.RegisterRoutedEvent("CurrentItemIndexChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<int>), typeof(ModuleDialog));

        public event RoutedPropertyChangedEventHandler<int> CurrentItemChanged
        {
            add { AddHandler(CurrentItemIndexChangedEvent, value); }
            remove { RemoveHandler(CurrentItemIndexChangedEvent, value); }
        }

        public ModuleDialog()
        {
            InitializeComponent();

            DataContext = this;

            DontShowExpiredEvents = true;

            ShowAllEventsToday = true;

            EventTextBlocks = new ObservableCollection<EventTextBlock>();

            ModuleEventTextBlocks = new ObservableCollection<UIElement>();

            HeaderTextBlock = new TextBlock();

            dtShowAhead.Value = DateTime.Today.AddHours(8);
            dtShowAfterEnded.Value = DateTime.Today.AddHours(2);

           // List<HospitalityEventDefinition> hospitalityEventDefinitions = HospitalityEventDefinitionManager.GetEventDefinitions();
            try
            {
                HospitalityEventDefinition hospitalityEventDefinition = HospitalityEventDefinitionManager.GetDefaultEventDefinition();

                cbDataSource.Items.Add(hospitalityEventDefinition);

                cbDataSource.DataContext = hospitalityEventDefinition;

                cbShowEventsForAllDisplays.IsChecked = true;

                //List<FieldContract> fieldContracts = EventSource.GetFields(hospitalityEventDefinition.XMLConfig); // TODO: Get Fields for the DataSource Selected

                //foreach (FieldContract contract in fieldContracts)
                //{
                //    EventTextBlocks.Add(AddEventTextBlock(contract.Name));
                //}

                EventTextBlocks = PopulateDefaultTextBlocks();

                FillModuleTextBlocks(EventTextBlocks);

                AvailableTextBlocks = GetRemainingEventFields(EventTextBlocks);
            
            }
            catch (Exception e)
            {
                MessageBox.Show("TODO: Create error window. " + e.Message);
            }
            
            // Adding optional Logo Fields, this will be an EventTextBlock with a flag that denotes that it is an image.

            cbFontSize.ItemsSource = fontSizes;

            cbSecondsPerPage.ItemsSource = secondsPerPage;

            cbSecondsPerPage.SelectedIndex = cbSecondsPerPage.Items.IndexOf(8);

            cbGroupBy.ItemsSource = EventTextBlocks;
            
            lbSelectedFields.ItemsSource = EventTextBlocks;

            lbAvailableFields.ItemsSource = AvailableTextBlocks;

            cbFieldToCustomize.ItemsSource = EventTextBlocks;

            lbEventItems.ItemsSource = ModuleEventTextBlocks;

            HeaderTextBlock.Foreground = Brushes.Black;
            HeaderTextBlock.FontSize = 14;

            tbHeader.Foreground = Brushes.Black;
            tbHeader.FontSize = 14;

            SetComboBoxes();

            TextColorRectangle.Fill = Brushes.Black;
        }

        public ModuleDialog(EventControl eventControl)
        {
            InitializeComponent();

            DataContext = this;

            EventTextBlocks = new ObservableCollection<EventTextBlock>();

            ModuleEventTextBlocks = new ObservableCollection<UIElement>();

            HeaderTextBlock = new TextBlock();

            HeaderTextBlock.Foreground = eventControl.HeaderRow.Foreground;
            HeaderTextBlock.TextWrapping = eventControl.HeaderRow.TextWrapping;
            HeaderTextBlock.FontWeight = eventControl.HeaderRow.FontWeight;
            HeaderTextBlock.FontStyle = eventControl.HeaderRow.FontStyle;
            HeaderTextBlock.TextDecorations = eventControl.HeaderRow.TextDecorations;
            HeaderTextBlock.FontSize = eventControl.HeaderRow.FontSize;
            HeaderTextBlock.FontFamily = eventControl.HeaderRow.FontFamily;

            tbHeader.Foreground = eventControl.HeaderRow.Foreground;
            tbHeader.TextWrapping = eventControl.HeaderRow.TextWrapping;
            tbHeader.FontWeight = eventControl.HeaderRow.FontWeight;
            tbHeader.FontStyle = eventControl.HeaderRow.FontStyle;
            tbHeader.TextDecorations = eventControl.HeaderRow.TextDecorations;
            tbHeader.FontSize = eventControl.HeaderRow.FontSize;
            tbHeader.FontFamily = eventControl.HeaderRow.FontFamily;

            if (eventControl.ShowEventssBehind.Hours == 0 && eventControl.ShowEventssBehind.Minutes == 0)
            {
                DontShowExpiredEvents = true;
                dtShowAfterEnded.Value = DateTime.Today.AddHours(2);
            }
            else
            {
                dtShowAfterEnded.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, eventControl.ShowEventssBehind.Hours, eventControl.ShowEventssBehind.Minutes, eventControl.ShowEventssBehind.Seconds);
            }

            if (eventControl.ShowAllTodaysEvents)
            {
                ShowAllEventsToday = true;
                dtShowAhead.Value = DateTime.Today.AddHours(8);
            }
            else
            {
                dtShowAhead.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, eventControl.ShowEventsAhead.Hours, eventControl.ShowEventsAhead.Minutes, eventControl.ShowEventsAhead.Seconds);
            }

            try
            {
                HospitalityEventDefinition hospitalityEventDefinition = HospitalityEventDefinitionManager.GetDefaultEventDefinition();

                cbDataSource.Items.Add(hospitalityEventDefinition);

                foreach (EventTextBlock eventTextBlock in eventControl.EventColumns.Items)
                {
                    EventTextBlock textBlock = new EventTextBlock(eventTextBlock.Text, eventTextBlock);

                    if (eventTextBlock.Text == "GroupLogo")
                    {
                        if (eventTextBlock.Visibility != Visibility.Collapsed)
                        {
                            imgHeaderLogo =
                                new LogoTextBlock(
                                    "pack://application:,,,/EventsModule;component/Resources/Images/Logo.png",
                                    eventTextBlock);
                            imgHeaderLogo.Width = textBlock.Width;
                        }
                    }

                    EventTextBlocks.Add(textBlock);
                }

                AvailableTextBlocks = TotalEventListBoxCollection();

                new EventColumnListManager(AvailableTextBlocks, EventTextBlocks);

                cbFontSize.ItemsSource = fontSizes;

                cbSecondsPerPage.ItemsSource = secondsPerPage;

                cbSecondsPerPage.SelectedIndex = cbSecondsPerPage.Items.IndexOf(eventControl.SecondsPerPage);

                cbGroupBy.ItemsSource = EventTextBlocks;

                cbShowEventsForAllDisplays.IsChecked = eventControl.ShowEventsForAllDisplays;

                lbSelectedFields.ItemsSource = EventTextBlocks;

                lbAvailableFields.ItemsSource = AvailableTextBlocks;

                cbFieldToCustomize.ItemsSource = EventTextBlocks;

                FillModuleTextBlocks(EventTextBlocks);

                lbEventItems.ItemsSource = ModuleEventTextBlocks;

                SetComboBoxes();

                TextColorRectangle.Fill = tbHeader.Foreground;
            }
            catch (Exception)
            {

            }
        }

        private void FillModuleTextBlocks(ObservableCollection<EventTextBlock> collection)
        {
            ModuleEventTextBlocks.Clear();
            
            foreach (EventTextBlock eventTextBlock in collection)
            {
                if (eventTextBlock.Text == "GroupLogo")
                {
                    var image = spHeaderRow.Children[0];
                    spHeaderRow.Children.RemoveAt(0);
                     image = new LogoTextBlock("pack://application:,,,/EventsModule;component/Resources/Images/Logo.png", eventTextBlock);
                    spHeaderRow.Children.Insert(0,image);
                }
                else if (eventTextBlock.Text == "DirectionalImage")
                {
                    ModuleEventTextBlocks.Add(new LogoTextBlock("pack://application:,,,/EventsModule;component/Resources/Images/arrow.png", eventTextBlock));
                }
                else
                {
                    ModuleEventTextBlocks.Add(eventTextBlock);
                }
            }
        }

        private static ObservableCollection<EventTextBlock> GetRemainingEventFields(ObservableCollection<EventTextBlock> collection) // TODO: Fix so that the only fields that are returned are the ones that arent included
        {
            var remainingTextBlocks = new ObservableCollection<EventTextBlock> 
                                {
                                    AddEventTextBlock("DirectionalImage"),
                                    AddEventTextBlock("MeetingPostAs"),
                                    AddEventTextBlock("MeetingType"),
                                    AddEventTextBlock("GroupLogo")
                                };
            return remainingTextBlocks;
        }

        private static ObservableCollection<EventTextBlock> PopulateDefaultTextBlocks()
        {
            var textBlocks = new ObservableCollection<EventTextBlock>
                                 {
                                     AddEventTextBlock("GroupName"),
                                     AddEventTextBlock("MeetingName"),
                                     AddEventTextBlock("MeetingRoomName"),
                                     AddEventTextBlock("StartTime"),
                                     AddEventTextBlock("EndTime")
                                 };
            return textBlocks;
        }

        private static ObservableCollection<EventTextBlock> TotalEventListBoxCollection()
        {
            return new ObservableCollection<EventTextBlock>
                       {
                            AddEventTextBlock("GroupName"),
                            AddEventTextBlock("MeetingName"),
                            AddEventTextBlock("MeetingRoomName"),
                            AddEventTextBlock("StartTime"),
                            AddEventTextBlock("EndTime"),
                            AddEventTextBlock("DirectionalImage"),
                            AddEventTextBlock("MeetingPostAs"),
                            AddEventTextBlock("MeetingType"),
                            AddEventTextBlock("GroupLogo")
                       };
        }

        private static EventTextBlock AddEventTextBlock(string name)
        {
            var eventTextBlock = new EventTextBlock(name);
            return eventTextBlock;
        }

        private void ChangeTextColor_Click(object sender, MouseButtonEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            SolidColorBrush fontBrush = (SolidColorBrush)((Rectangle)sender).Fill;

            cPicker.StartingColor = fontBrush.Color;
            //cPicker.Owner = this;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                EventTextBlocks[cbFieldToCustomize.SelectedIndex].Foreground = selectedColor;
                if (EventTextBlocks[cbFieldToCustomize.SelectedIndex].IsHeader)
                {
                    HeaderTextBlock.Foreground = selectedColor;
                    tbHeader.Foreground = selectedColor;
                }
                ((Rectangle)(sender)).Fill = selectedColor;
            }
        }

        private void SetHeader(EventTextBlock eventTextBlock)
        {
            if(eventTextBlock != null)
            foreach (EventTextBlock textBlock in EventTextBlocks)
            {
                if (eventTextBlock.Text == textBlock.Text)
                {
                    textBlock.IsHeader = true;
                }
                else
                {
                    textBlock.IsHeader = false;
                }
            }
        }

        private void FillAppearanceView()
        {
            foreach (EventTextBlock eventTextBlock in EventTextBlocks)
            {
                if (eventTextBlock.IsHeader)
                {
                    eventTextBlock.Visibility = Visibility.Collapsed;
                    HeaderTextBlock.Text = eventTextBlock.Text;
                    tbHeader.Text = eventTextBlock.Text;
                    tbHeader.Foreground = eventTextBlock.Foreground;
                }
                else
                    eventTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(EventRowAnimationPicker.SelectedAnimation))
            //    SelectedAnimation = EventRowAnimationPicker.SelectedAnimation;
            //else
            //    SelectedAnimation = string.Empty;

            SecondsPerPage = Convert.ToInt32(cbSecondsPerPage.SelectedItem);
            ShowEventsForAllDisplays = cbShowEventsForAllDisplays.IsChecked;

            SetFontStylesFromHeader(cbFieldToCustomize.SelectedIndex);

            DialogResult = true;
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnFieldUp_Click(object sender, RoutedEventArgs e)
        {
            if (lbSelectedFields.SelectedItem == null) return;
            int originalIndex = lbSelectedFields.SelectedIndex;
            if (originalIndex > 0)
            {
                EventTextBlock evtIr = lbSelectedFields.SelectedItem as EventTextBlock;
                EventTextBlocks.RemoveAt(originalIndex);
                EventTextBlocks.Insert(originalIndex -1, evtIr);
                lbSelectedFields.SelectedIndex = originalIndex - 1;

                FillModuleTextBlocks(EventTextBlocks);
            }
        }

        

        private void btnSelectField_Click(object sender, RoutedEventArgs e)
        {
            if (lbAvailableFields.SelectedIndex > -1)
            {
                var availableFields = lbAvailableFields.ItemsSource as ObservableCollection<EventTextBlock>;
                var selectedTextBlock = lbAvailableFields.SelectedItem as EventTextBlock;

                if (availableFields != null) availableFields.RemoveAt(lbAvailableFields.SelectedIndex);

                var selectedFields = lbSelectedFields.ItemsSource as ObservableCollection<EventTextBlock>;

                if (selectedFields != null) selectedFields.Add(selectedTextBlock);

                FillModuleTextBlocks(selectedFields);
            }
        }

        private void btnUnSelectField_Click(object sender, RoutedEventArgs e)
        {
            if (lbSelectedFields.SelectedIndex > -1)
            {
                var selectedFields = lbSelectedFields.ItemsSource as ObservableCollection<EventTextBlock>;
                var selectedTextBlock = lbSelectedFields.SelectedItem as EventTextBlock;

                if (selectedFields != null) selectedFields.RemoveAt(lbSelectedFields.SelectedIndex);

                var availableFields = lbAvailableFields.ItemsSource as ObservableCollection<EventTextBlock>;

                if (availableFields != null) availableFields.Add(selectedTextBlock);

                FillModuleTextBlocks(selectedFields);
            }
        }

        private void btnFieldDown_Click(object sender, RoutedEventArgs e)
        {
            if (lbSelectedFields.SelectedItem == null) return;
            int originalIndex = lbSelectedFields.SelectedIndex;
            if (originalIndex < lbSelectedFields.Items.Count - 1)
            {
                EventTextBlock evtIr = lbSelectedFields.SelectedItem as EventTextBlock;
                EventTextBlocks.RemoveAt(lbSelectedFields.SelectedIndex);
                EventTextBlocks.Insert(originalIndex + 1, evtIr);
                lbSelectedFields.SelectedIndex = originalIndex + 1;

                FillModuleTextBlocks(EventTextBlocks);
            }
        }

        private void cbFontType_DropDownClosed(object sender, EventArgs e)
        {
            if (cbFieldToCustomize.Items.Count > 0)
            {
                EventTextBlocks[cbFieldToCustomize.SelectedIndex].FontFamily = (FontFamily)cbFontType.SelectedItem;

                if (EventTextBlocks[cbFieldToCustomize.SelectedIndex].IsHeader)
                    tbHeader.FontFamily = (FontFamily)cbFontType.SelectedItem;
            }
        }

        private void cbFieldToCustomize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbFieldToCustomize.SelectedIndex == -1)
                cbFieldToCustomize.SelectedIndex = 0;

            CurrentItemIndex = cbFieldToCustomize.SelectedIndex;
            SetComboBoxes();
        }

        private void SetComboBoxes()
        {
            cbFontType.SelectedIndex = cbFontType.Items.IndexOf(EventTextBlocks[cbFieldToCustomize.SelectedIndex].FontFamily);
            cbFontSize.SelectedIndex = cbFontSize.Items.IndexOf(Convert.ToInt32(EventTextBlocks[cbFieldToCustomize.SelectedIndex].FontSize));
            TextColorRectangle.Fill = EventTextBlocks[cbFieldToCustomize.SelectedIndex].Foreground;
            tbWidth.Text = EventTextBlocks[cbFieldToCustomize.SelectedIndex].Width.ToString();
            
            if (EventTextBlocks[cbFieldToCustomize.SelectedIndex].IsHeader)
            {
                SetFontStylesFromHeader(headerIndex);
                headerIndex = cbFieldToCustomize.SelectedIndex;
            }

            if (EventTextBlocks[cbFieldToCustomize.SelectedIndex].IsHeader)
                EventFontStyler.DataContext = tbHeader;
            else
                EventFontStyler.DataContext = EventTextBlocks[cbFieldToCustomize.SelectedIndex];

                //HeaderTextBlock.Foreground = TextColorRectangle.Fill;
            
            //headerIndex = cbFieldToCustomize.SelectedIndex;
        }

        private void SetFontStylesFromHeader(int initialSelectedIndex)
        {
            if(initialSelectedIndex > -1 && EventTextBlocks[initialSelectedIndex] != null)
            {
                EventTextBlocks[initialSelectedIndex].FontStyle = tbHeader.FontStyle;
                EventTextBlocks[initialSelectedIndex].FontWeight = tbHeader.FontWeight;
                EventTextBlocks[initialSelectedIndex].TextDecorations = tbHeader.TextDecorations;

                HeaderTextBlock.FontStyle = tbHeader.FontStyle;
                HeaderTextBlock.FontWeight = tbHeader.FontWeight;
                HeaderTextBlock.TextDecorations = tbHeader.TextDecorations;
            }
        }

        private void tbWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            int newInt;
            if(Int32.TryParse(tbWidth.Text, out newInt))
            {
                EventTextBlocks[cbFieldToCustomize.SelectedIndex].Width = newInt;

                if (EventTextBlocks[cbFieldToCustomize.SelectedIndex].Text == "GroupLogo" || EventTextBlocks[cbFieldToCustomize.SelectedIndex].Text == "DirectionalImage")
                {
                    FillModuleTextBlocks(EventTextBlocks);
                }
            }
        }

        private void cbFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EventTextBlocks[cbFieldToCustomize.SelectedIndex].FontSize = Convert.ToInt32(cbFontSize.SelectedItem);

            if (EventTextBlocks[cbFieldToCustomize.SelectedIndex].IsHeader)
                tbHeader.FontSize = Convert.ToInt32(cbFontSize.SelectedItem);
        }

        private void cbGroupBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetHeader((EventTextBlock)(((ComboBox)sender).SelectedItem));
            FillAppearanceView();
        }
    }
}
