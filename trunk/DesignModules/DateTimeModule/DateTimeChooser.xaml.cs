using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Inspire;
using Inspire.Services.WeakEventHandlers;

namespace DateTimeModule
{
    /// <summary>
    /// Interaction logic for DateTimeChooser.xaml
    /// </summary>
    public partial class DateTimeChooser
    {
        private readonly IDictionary<int, string> formats;

        private readonly int[] fontSizes = { 8, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 44, 46, 48, 50, 52, 54, 60, 64, 68, 72, 80, 84, 90, 96, 104, 110, 118 };

        public DateTimeChooser()
        {
            InitializeComponent();

            formats = chooseClock.GetFormats();

            fontStyler.DataContext = chooseClock.Content;

            cbFormat.ItemsSource = formats;

            cbFontSize.ItemsSource = fontSizes;

            SetComboBoxes();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void SetComboBoxes()
        {
            if (chooseClock != null)
            {
                cbFontSize.SelectedIndex = cbFontSize.Items.IndexOf(Convert.ToInt32(chooseClock.FontSize));
                cbFontFamily.SelectedIndex = cbFontFamily.Items.IndexOf(chooseClock.FontFamily);
                TextColorRectangle.Fill = chooseClock.Foreground;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void cbFontFamily_DropDownClosed(object sender, EventArgs e)
        {
            chooseClock.FontFamily = (FontFamily)cbFontFamily.SelectedItem;
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
                chooseClock.Foreground = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;
            }
        }

        private void cbFontSize_DropDownClosed(object sender, EventArgs e)
        {
            if (cbFontSize.SelectedItem != null)
                chooseClock.FontSize = Convert.ToInt32(cbFontSize.SelectedItem);
        }

        private void cbFormat_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            chooseClock.DateTimeFormat = Convert.ToInt32(this.cbFormat.SelectedValue);
        }
    }
}
