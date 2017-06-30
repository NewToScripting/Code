using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Inspire;

namespace EventsModule
{
    /// <summary>
    /// Interaction logic for RoomDialog.xaml
    /// </summary>
    public partial class RoomDialog : Window
    {
        private int selectedItem = 0;

        private readonly int[] fontSizes = { 8, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 44, 46, 48, 50, 52, 54, 60, 64, 68, 72, 80, 84, 90, 96, 104, 110, 118 };

        public RoomDialog()
        {
            InitializeComponent();

            dtShowAhead.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8,0,0);

            dtShowAfterEnded.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0,0,0);

            cbFontSize.ItemsSource = fontSizes;

            var roomEvt = new RoomEvent(true);

            RoomEventHolder.Content = roomEvt;

            cbFieldToCustomize.ItemsSource = roomEvt.EventColumns.Items;

            cbFieldToCustomize.SelectedIndex = 0;

            SetComboBoxes();
        }

        public RoomDialog(RoomEvent roomEvent)
        {
            InitializeComponent();

            dtShowAfterEnded.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, roomEvent.ShowEventssBehind.Hours, roomEvent.ShowEventssBehind.Minutes, roomEvent.ShowEventssBehind.Seconds);

            dtShowAhead.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, roomEvent.ShowEventsAhead.Hours, roomEvent.ShowEventsAhead.Minutes, roomEvent.ShowEventsAhead.Seconds);

            if (roomEvent.EventToShow > -1 && roomEvent.EventToShow < 3)
                cbEventToShow.SelectedIndex = roomEvent.EventToShow;
            else
                cbEventToShow.SelectedIndex = 0;

            showAllEvents.IsChecked = roomEvent.ShowAllTodaysEvents;

            dontShowExpired.IsChecked = (roomEvent.ShowEventssBehind.TotalSeconds == 0);

            cbFontSize.ItemsSource = fontSizes;

            RoomEventHolder.Content = new RoomEvent(roomEvent);

            cbFieldToCustomize.ItemsSource = roomEvent.EventColumns.Items;

            cbFieldToCustomize.SelectedIndex = 0;

            SetComboBoxes();

        }

        private void SetComboBoxes()
        {
            var roomEvt = RoomEventHolder.Content as RoomEvent;
            tbWidth.Text = ((TextBlock) roomEvt.EventColumns.Items[selectedItem]).Width.ToString();
            cbFontType.SelectedIndex = cbFontType.Items.IndexOf(((TextBlock)roomEvt.EventColumns.Items[selectedItem]).FontFamily);
            cbFontSize.SelectedIndex = cbFontSize.Items.IndexOf(Convert.ToInt32(((TextBlock)roomEvt.EventColumns.Items[selectedItem]).FontSize));
            TextColorRectangle.Fill = ((TextBlock)roomEvt.EventColumns.Items[selectedItem]).Foreground;
            EventFontStyler.DataContext = (TextBlock) roomEvt.EventColumns.Items[selectedItem];
            if (((TextBlock)roomEvt.EventColumns.Items[selectedItem]).Visibility == Visibility.Collapsed)
                cbHideField.IsChecked = true;
            else
                cbHideField.IsChecked = false;
        }

        private void cbFieldToCustomize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItem = cbFieldToCustomize.SelectedIndex;
            SetComboBoxes();
        }

        private void cbFontType_DropDownClosed(object sender, EventArgs e)
        {
            var roomEvt = RoomEventHolder.Content as RoomEvent;
            ((TextBlock)roomEvt.EventColumns.Items[selectedItem]).FontFamily = (FontFamily)cbFontType.SelectedItem;
            roomEvt.UpdateAppearance();
        }

        private void cbFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var roomEvt = RoomEventHolder.Content as RoomEvent;
            ((TextBlock)roomEvt.EventColumns.Items[selectedItem]).FontSize = Convert.ToDouble(cbFontSize.SelectedItem);
            roomEvt.UpdateAppearance();
        }

        private void ChangeTextColor_Click(object sender, MouseButtonEventArgs e)
        {
            var roomEvt = RoomEventHolder.Content as RoomEvent;
            ColorPickerDialog cPicker = new ColorPickerDialog();

            SolidColorBrush fontBrush = (SolidColorBrush)((TextBlock)roomEvt.EventColumns.Items[selectedItem]).Foreground;

            cPicker.StartingColor = fontBrush.Color;
            //cPicker.Owner = this;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                ((TextBlock)roomEvt.EventColumns.Items[selectedItem]).Foreground = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;
            }
            roomEvt.UpdateAppearance();
            e.Handled = true;
        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void EventFontStyler_ToggleChanged(object sender, RoutedEventArgs e)
        {
            var roomEvt = RoomEventHolder.Content as RoomEvent;
            roomEvt.UpdateAppearance();
        }

        private void tbWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbWidth.Text != null)
            {
                var roomEvt = RoomEventHolder.Content as RoomEvent;

                double fieldWidth;
                if (double.TryParse(tbWidth.Text, out fieldWidth))
                {
                    ((TextBlock)roomEvt.EventColumns.Items[selectedItem]).Width = fieldWidth;
                    roomEvt.UpdateAppearance();
                }
            }
        }

        private void cbHideField_Checked(object sender, RoutedEventArgs e)
        {
            var roomEvt = RoomEventHolder.Content as RoomEvent;

            var hideField = cbHideField.IsChecked;

            if ((bool) hideField)
            {
                ((TextBlock)roomEvt.EventColumns.Items[selectedItem]).Visibility = Visibility.Collapsed;
                roomEvt.UpdateAppearance();
            }
            else
            {
                ((TextBlock)roomEvt.EventColumns.Items[selectedItem]).Visibility = Visibility.Visible;
                roomEvt.UpdateAppearance();
            }
        }
    }
}
