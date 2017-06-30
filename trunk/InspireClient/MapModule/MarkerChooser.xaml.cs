using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MapModule
{
    /// <summary>
    /// Interaction logic for MarkerChooser.xaml
    /// </summary>
    public partial class MarkerChooser : Window
    {
        public string MarkerStyle { get; set; }
        public string CategoryName { get; set; }

        private readonly ResourceDictionary _markerDictionary;
        private readonly string _selectedMarker;

        public MarkerChooser(string categoryName, string selectedMarker)
        {
            InitializeComponent();

            CategoryName = categoryName;

            _markerDictionary = new ResourceDictionary
            {
                Source =
                    new Uri(
                    "pack://application:,,,/MapModule;component/Resources/Markers.xaml")
            };

            _selectedMarker = selectedMarker;

            Resources = _markerDictionary;

            Loaded += MarkerChooser_Loaded;
        }

        private void MarkerChooser_Loaded(object sender, RoutedEventArgs e)
        {
            var sortedList = (from DictionaryEntry entry in _markerDictionary select Convert.ToInt32(entry.Key)).ToList().OrderBy(r => r);

            foreach (var entry in sortedList)
            {
                var control = new ContentControl();
                control.Template = FindResource(entry.ToString()) as ControlTemplate;
                lbIcons.Items.Add(new Viewbox {Child = control, Width = 40, Height = 40});
            }
            var selIndex = lbIcons.Items.IndexOf(_selectedMarker);

            lbIcons.SelectedIndex = selIndex.Equals(-1) ? 0 : selIndex;

            tbName.Text = CategoryName;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            MarkerStyle = lbIcons.SelectedIndex.Equals(-1) ? "0" : lbIcons.SelectedIndex.ToString();
            CategoryName = tbName.Text;

            if (!string.IsNullOrEmpty(CategoryName))
            {
                DialogResult = true;
                Close();
            }
            else
                MessageBox.Show("Please enter a category name.");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
