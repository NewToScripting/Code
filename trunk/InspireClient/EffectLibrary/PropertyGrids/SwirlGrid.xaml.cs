using System.Windows;
using EffectLibrary.Effects;

namespace EffectLibrary.PropertyGrids
{
    /// <summary>
    /// Interaction logic for SwirlGrid.xaml
    /// </summary>
    public partial class SwirlGrid
    {
        public SwirlGrid()
        {
            InitializeComponent();
        }

        public SwirlGrid(UIElement uiElement)
        {
            InitializeComponent();

            DataContext = uiElement.Effect;
        }

        private void centerX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((SwirlEffect)DataContext).Center = new Point(e.NewValue, ((SwirlEffect)DataContext).Center.Y);
        }

        private void centerY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((SwirlEffect)DataContext).Center = new Point(((SwirlEffect)DataContext).Center.X, e.NewValue);
        }

        private void angleFrequencyX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((SwirlEffect)DataContext).AngleFrequency = new Vector(e.NewValue, ((SwirlEffect)DataContext).AngleFrequency.Y);
        }

        private void angleFrequencyY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((SwirlEffect)DataContext).AngleFrequency = new Vector(((SwirlEffect)DataContext).AngleFrequency.X, e.NewValue);
        }
    }
}
