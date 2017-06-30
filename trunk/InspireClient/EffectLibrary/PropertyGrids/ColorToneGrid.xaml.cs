using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using EffectLibrary.ColorPicker;
using EffectLibrary.Effects;

namespace EffectLibrary.PropertyGrids
{
    /// <summary>
    /// Interaction logic for ColorToneGrid.xaml
    /// </summary>
    public partial class ColorToneGrid
    {
        public ColorToneGrid()
        {
            InitializeComponent();
        }

        public ColorToneGrid(UIElement uiElement)
        {
            InitializeComponent();

            DataContext = uiElement.Effect;

            TextColorRectangleLight.Fill = new SolidColorBrush(((ColorToneEffect)uiElement.Effect).LightColor);
            TextColorRectangleDark.Fill = new SolidColorBrush(((ColorToneEffect)uiElement.Effect).DarkColor);
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

                var dropShadowEffect = ((Rectangle)e.Source).DataContext as ColorToneEffect;

                    if (dropShadowEffect != null) dropShadowEffect.LightColor = selectedColor.Color;
                ((Rectangle)(sender)).Fill = selectedColor;
            }
        }

        private void ChangeDarkColor_Click(object sender, MouseButtonEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            SolidColorBrush fontBrush = (SolidColorBrush)((Rectangle)sender).Fill;

            cPicker.StartingColor = fontBrush.Color;
            //cPicker.Owner = this;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);

                var dropShadowEffect = ((Rectangle)e.Source).DataContext as ColorToneEffect;

                if (dropShadowEffect != null) dropShadowEffect.DarkColor = selectedColor.Color;

                ((Rectangle)(sender)).Fill = selectedColor;
            }
        }
    }
}
