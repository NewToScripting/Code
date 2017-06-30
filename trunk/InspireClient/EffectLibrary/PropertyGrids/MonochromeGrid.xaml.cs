using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using EffectLibrary.ColorPicker;
using EffectLibrary.Effects;

namespace EffectLibrary.PropertyGrids
{
    /// <summary>
    /// Interaction logic for MonochromeGrid.xaml
    /// </summary>
    public partial class MonochromeGrid
    {
        public MonochromeGrid()
        {
            InitializeComponent();
        }

        public MonochromeGrid(UIElement uiElement)
        {
            InitializeComponent();

            DataContext = uiElement.Effect;

            TextColorRectangle.Fill = new SolidColorBrush(((MonochromeEffect)uiElement.Effect).FilterColor);
        }

        private void ChangeTextColor_Click(object sender, MouseButtonEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            SolidColorBrush fontBrush = (SolidColorBrush)((Rectangle)sender).Fill;

            cPicker.StartingColor = fontBrush.Color;
            //cPicker.Owner = this;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);

                var dropShadowEffect = ((Rectangle)e.Source).DataContext as MonochromeEffect;

                    if (dropShadowEffect != null) dropShadowEffect.FilterColor = selectedColor.Color;
                ((Rectangle)(sender)).Fill = selectedColor;
            }
        }
    }
}
