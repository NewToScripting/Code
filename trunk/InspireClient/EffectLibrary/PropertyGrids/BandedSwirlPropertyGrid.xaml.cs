using System.Windows;
using EffectLibrary.Effects;

namespace EffectLibrary.PropertyGrids
{
    /// <summary>
    /// Interaction logic for BandedSwirlPropertyGrid.xaml
    /// </summary>
    public partial class BandedSwirlPropertyGrid
    {
        public BandedSwirlPropertyGrid()
        {
            InitializeComponent();
        }

        public BandedSwirlPropertyGrid(UIElement uiElement)
        {
            InitializeComponent();

            DataContext = uiElement.Effect;
        }

        private void centerX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((BandedSwirlEffect)DataContext).Center = new Point(e.NewValue, ((BandedSwirlEffect)DataContext).Center.Y);
        }

        private void centerY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            ((BandedSwirlEffect)DataContext).Center = new Point(((BandedSwirlEffect)DataContext).Center.X, e.NewValue);
        }
    }
}
