using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace MapModule
{
	/// <summary>
	/// Interaction logic for CategorySelecter.xaml
	/// </summary>
	public partial class CategorySelecter : Window
	{
	    private readonly ObservableCollection<MapCategory> _mapCategories;

        public IEnumerable<MapCategory> Categories { get
        {
            var selectedCategories = _mapCategories.ToList();
            selectedCategories.AddRange(lbPreCategories.Items.Cast<MapCategory>().Where(selectedCategory => selectedCategory.AutoPopulate));
            return selectedCategories;
        } }

		public CategorySelecter()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.

            _mapCategories = new ObservableCollection<MapCategory>();

		    lbCategories.ItemsSource = _mapCategories;
		}

        public CategorySelecter(IEnumerable<MapCategory> mapCategories) : this()
        {
            _mapCategories = new ObservableCollection<MapCategory>(mapCategories);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var markerChooser = new MarkerChooser(string.Empty, "1");
            markerChooser.ShowDialog();
            if(markerChooser.DialogResult == true)
                _mapCategories.Add(new MapCategory(markerChooser.CategoryName, markerChooser.MarkerStyle));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (lbCategories.SelectedItem == null) return;
            var selectedCat = lbCategories.SelectedItem as MapCategory;
            if(selectedCat == null) return;

            var markerChooser = new MarkerChooser(selectedCat.Name, selectedCat.CategoryStyle);
            markerChooser.ShowDialog();
            if (markerChooser.DialogResult != true) return;
            selectedCat.Name = markerChooser.CategoryName;
            selectedCat.CategoryStyle = markerChooser.MarkerStyle;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (lbCategories.SelectedItem == null) return;

            var selectedCat = lbCategories.SelectedItem as MapCategory;
            if (selectedCat == null) return;

            _mapCategories.Remove(selectedCat);
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
	}
}