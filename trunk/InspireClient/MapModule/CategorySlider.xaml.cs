using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Transitionals.Controls;

namespace MapModule
{
    /// <summary>
    /// Interaction logic for CategorySlider.xaml
    /// </summary>
    public partial class CategorySlider : UserControl
    {
        private readonly TransitionElement _contentHolder;
        private readonly TransitionElement _detailHolder;
        private readonly IEnumerable<MapCategory> _cats;
        private readonly InspireMapLocation _home;
        private readonly bool _showPrint;

        public CategorySlider()
        {
            InitializeComponent();

            Resources =
                    new ResourceDictionary
                    {
                        Source =
                            new Uri(
                            "pack://application:,,,/MapModule;component/Resources/Markers.xaml")
                    };
        }

        public CategorySlider(IEnumerable<MapCategory> cats, TransitionElement categoryHolder, TransitionElement detailHolder, InspireMapLocation home, bool showPrint) : this()
        {
            _contentHolder = categoryHolder;
            _detailHolder = detailHolder;
            _home = home;
            _cats = cats;
            _showPrint = showPrint;
            ICCategories.ItemsSource = cats;
        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_contentHolder.Content is SubCategorySlider) return;

            var sendingCat = ((FrameworkElement)sender).DataContext as MapCategory;//IGrouping<string, InspireMapLocation>;
            if (sendingCat != null)
            {
                var subCatView = new SubCategorySlider(_cats, sendingCat.MapLocations, _contentHolder, _detailHolder, _home, sendingCat.Name, sendingCat.CategoryStyle, sendingCat.AutoPopulate, _showPrint);
                _contentHolder.Content = subCatView;
            }
            
        }

        private void TextBlock_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            if (_contentHolder.Content is SubCategorySlider) return;

            var sendingCat = ((FrameworkElement)sender).DataContext as MapCategory;//IGrouping<string, InspireMapLocation>;
            if (sendingCat != null)
            {
                var subCatView = new SubCategorySlider(_cats, sendingCat.MapLocations, _contentHolder, _detailHolder, _home, sendingCat.Name, sendingCat.CategoryStyle, sendingCat.AutoPopulate, _showPrint);
                _contentHolder.Content = subCatView;

               // _detailHolder.Content = new InspireLocationDetails(sendingCat.MapLocations.ToList()[0], _detailHolder);
            }
        }
    }
}
