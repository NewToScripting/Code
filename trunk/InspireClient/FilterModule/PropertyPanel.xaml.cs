using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Inspire;
using Inspire.Interfaces;

namespace FilterModule
{
    /// <summary>
    /// Interaction logic for PropertyPanel.xaml
    /// </summary>
    public partial class PropertyPanel
    {
        public PropertyPanel()
        {
            InitializeComponent();
            DataContext = InspireApp.SelectedContext;
            DataContextChanged += PropertyPanel_DataContextChanged;
            Loaded += PropertyPanel_Loaded;
        }

        void PropertyPanel_Loaded(object sender, RoutedEventArgs e)
        {
            cbItemToFilter.ItemsSource = (InspireApp.GetDesignItems()).Where(c => c.Content is IFilterable);

            var alphaFilter = (FilterControl)((ContentControl)((ContentControl)(InspireApp.SelectedContext)).Content).Content;
            if(string.IsNullOrEmpty(alphaFilter.GuidToFilterOn))
            {
                if (cbItemToFilter.Items.Count > 0)
                {
                    cbItemToFilter.SelectedItem = cbItemToFilter.Items[0];
                }
            }
        }

        void PropertyPanel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            propBase.SetDataContext();
        }

        private void ChangeForegroundColor_Click(object sender, MouseButtonEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            var alphaFilter =
                (AlphabitFilter)
                 ((ContentControl)
                  ((ContentControl) ((ContentControl) ((Rectangle) sender).DataContext).Content).Content).Content;

            SolidColorBrush fontBrush = alphaFilter.CharacterForeground;

            cPicker.StartingColor = fontBrush.Color;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                alphaFilter.CharacterForeground = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;

            }
            e.Handled = true;
        }

        private void ChangeSelectedForegroundColor_Click(object sender, MouseButtonEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            var alphaFilter =
                (AlphabitFilter)
                 ((ContentControl)
                  ((ContentControl)((ContentControl)((Rectangle)sender).DataContext).Content).Content).Content;

            SolidColorBrush fontBrush = alphaFilter.SelectedCharacterBrush;

            cPicker.StartingColor = fontBrush.Color;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                alphaFilter.SelectedCharacterBrush = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;

            }
            e.Handled = true;
        }

        private void ChangeGlowColor_Click(object sender, MouseButtonEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            var alphaFilter =
                (AlphabitFilter)
                 ((ContentControl)
                  ((ContentControl)((ContentControl)((Rectangle)sender).DataContext).Content).Content).Content;

            SolidColorBrush fontBrush = alphaFilter.GlowForeground;

            cPicker.StartingColor = fontBrush.Color;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                alphaFilter.GlowForeground = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;

            }
            e.Handled = true;
        }

        private void cbItemToFilter_DropDownClosed(object sender, System.EventArgs e)
        {
            var selectedItem = ((ComboBox)sender).SelectedItem;
            if (selectedItem != null)
                ((FilterControl)((ContentControl)((ContentControl)(InspireApp.SelectedContext)).Content).Content).GuidToFilterOn = ((IDesignContentControl)selectedItem).GUID;
        }
    }
}
