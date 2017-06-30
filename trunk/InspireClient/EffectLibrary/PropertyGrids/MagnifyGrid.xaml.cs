using System.Windows;
using EffectLibrary.Effects;

namespace EffectLibrary.PropertyGrids
{
    /// <summary>
    /// Interaction logic for MagnifyGrid.xaml
    /// </summary>
    public partial class MagnifyGrid
    {
        public MagnifyGrid()
        {
            InitializeComponent();
        }

        public MagnifyGrid(UIElement uiElement)
        {
            InitializeComponent();

            DataContext = uiElement.Effect;
        }

        private void centerX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((MagnifyEffect)DataContext).Center = new Point(e.NewValue, ((MagnifyEffect)DataContext).Center.Y);
        }

        private void centerY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((MagnifyEffect)DataContext).Center = new Point(((MagnifyEffect)DataContext).Center.X, e.NewValue);
        }

        private void radiiX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((MagnifyEffect)DataContext).Radii = new Size(e.NewValue, ((MagnifyEffect)DataContext).Radii.Height);
        }

        private void radiiY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((MagnifyEffect) DataContext).Radii = new Size(((MagnifyEffect) DataContext).Radii.Width, e.NewValue);
        }
    }
}
