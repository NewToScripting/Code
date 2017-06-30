using System.Windows;
using EffectLibrary.Effects;

namespace EffectLibrary.PropertyGrids
{
    /// <summary>
    /// Interaction logic for RippleGrid.xaml
    /// </summary>
    public partial class RippleGrid
    {
        public RippleGrid()
        {
            InitializeComponent();
        }

        public RippleGrid(UIElement uiElement)
        {
            InitializeComponent();

            DataContext = uiElement.Effect;
        }

        private void centerX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((RippleEffect)DataContext).Center = new Point(e.NewValue, ((RippleEffect)DataContext).Center.Y);
        }

        private void centerY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((RippleEffect)DataContext).Center = new Point(((RippleEffect)DataContext).Center.X, e.NewValue);
        }
    }
}
