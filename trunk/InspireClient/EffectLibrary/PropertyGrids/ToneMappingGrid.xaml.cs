using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using EffectLibrary.ColorPicker;
using EffectLibrary.Effects;

namespace EffectLibrary.PropertyGrids
{
    /// <summary>
    /// Interaction logic for ToneMappingGrid.xaml
    /// </summary>
    public partial class ToneMappingGrid
    {
        public ToneMappingGrid()
        {
            InitializeComponent();
        }

        public ToneMappingGrid(UIElement uiElement)
        {
            InitializeComponent();

            DataContext = uiElement.Effect;

            TextColorRectangleLight.Fill = new SolidColorBrush(((ToneMappingEffect)uiElement.Effect).FogColor);
        }

        private void ChangeLightColor_Click(object sender, MouseButtonEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            SolidColorBrush fontBrush = (SolidColorBrush)((Rectangle)sender).Fill;

            cPicker.StartingColor = fontBrush.Color;
            //cPicker.Owner = this;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);

                var dropShadowEffect = ((Rectangle)e.Source).DataContext as ToneMappingEffect;

                if (dropShadowEffect != null) dropShadowEffect.FogColor = selectedColor.Color;

                ((Rectangle)(sender)).Fill = selectedColor;
            }
        }

        private void centerX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((ToneMappingEffect)DataContext).VignetteCenter = new Point(e.NewValue, ((ToneMappingEffect)DataContext).VignetteCenter.Y);
        }

        private void centerY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((ToneMappingEffect)DataContext).VignetteCenter = new Point(((ToneMappingEffect)DataContext).VignetteCenter.X, e.NewValue);
        }
    }
}
