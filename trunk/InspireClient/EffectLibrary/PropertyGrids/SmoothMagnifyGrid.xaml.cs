using System.Windows;
using EffectLibrary.Effects;

namespace EffectLibrary.PropertyGrids
{
    /// <summary>
    /// Interaction logic for SmoothMagnifyGrid.xaml
    /// </summary>
    public partial class SmoothMagnifyGrid 
    {
        public SmoothMagnifyGrid()
        {
            InitializeComponent();
        }

        public SmoothMagnifyGrid(UIElement uiElement)
        {
            InitializeComponent();

            DataContext = uiElement.Effect;
        }

        private void centerY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((SmoothMagnifyEffect)DataContext).Center = new Point(((SmoothMagnifyEffect)DataContext).Center.X,e.NewValue);
        }

        private void centerX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((SmoothMagnifyEffect)DataContext).Center = new Point(e.NewValue, ((SmoothMagnifyEffect)DataContext).Center.Y);
        }
    }
}
