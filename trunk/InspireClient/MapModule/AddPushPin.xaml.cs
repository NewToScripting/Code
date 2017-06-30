using System.Windows;

namespace MapModule
{
    /// <summary>
    /// Interaction logic for AddPushPin.xaml
    /// </summary>
    public partial class AddPushPin
    {
       // private readonly ObservableCollection<string> _categories;
        public string PushPinName { get; set; }
        public string PushPinDescription { get; set; }
        //public string PushPinCategoryName { get; set; }
        //public string PushPinCategoryStyle { get; set; }
        public int AvgPrice { get; set; }
        public bool ShowPriceIndicator { get; set; }
        public bool ShowMarker { get; set; }

        public AddPushPin(string category)
        {
            InitializeComponent();
            //_categories = new ObservableCollection<string>();
            //foreach (var category in categories)
            //{
            //    if(!_categories.Contains(category))
            //        _categories.Add(category);
            //}
            //cbCategory.ItemsSource = _categories;
            tbCategory.Text = category;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            //PushPinCategoryName = tbCategory.Text;
            //if(string.IsNullOrEmpty(PushPinCategoryStyle))
            //    PushPinCategoryStyle = "0";
            PushPinName = tbName.Text;
            PushPinDescription = tbDescription.Text;
            AvgPrice = amtControl.RatingValue;
            ShowPriceIndicator = cbShowAvgPriceControl.IsChecked is bool ? (bool) cbShowAvgPriceControl.IsChecked : false;
            ShowMarker = cbMarkerVisible.IsChecked is bool ? (bool)cbMarkerVisible.IsChecked : true;
            DialogResult = true;
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            //var textPromt = new MarkerChooser(PushPinCategoryName, PushPinCategoryStyle);
            //textPromt.ShowDialog();
            //if (textPromt.DialogResult == true)
            //{
            //    PushPinCategoryName = textPromt.CategoryName;
            //    PushPinCategoryStyle = textPromt.MarkerStyle;
            //    if (!_categories.Contains(textPromt.CategoryName))
            //        _categories.Add(textPromt.CategoryName);
            //    cbCategory.SelectedItem = textPromt.CategoryName;
            //}
        }
    }
}
