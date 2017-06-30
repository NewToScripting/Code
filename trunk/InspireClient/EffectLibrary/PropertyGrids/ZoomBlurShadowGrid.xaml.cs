using System.Windows;
using EffectLibrary.Effects;

namespace EffectLibrary.PropertyGrids
{
    /// <summary>
    /// Interaction logic for ZoomBlurShadowGrid.xaml
    /// </summary>
    public partial class ZoomBlurShadowGrid
    {
        public ZoomBlurShadowGrid()
        {
            InitializeComponent();
        }

        public ZoomBlurShadowGrid(UIElement uiElement)
        {
            InitializeComponent();

            DataContext = uiElement.Effect;
        }

        private void centerX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((ZoomBlurEffect)DataContext).Center = new Point(e.NewValue, ((ZoomBlurEffect)DataContext).Center.Y);
        }

        private void centerY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((ZoomBlurEffect)DataContext).Center = new Point(((ZoomBlurEffect)DataContext).Center.X, e.NewValue);
        }
    }
}
