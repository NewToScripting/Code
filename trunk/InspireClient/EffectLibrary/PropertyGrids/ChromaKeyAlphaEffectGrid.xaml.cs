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
    /// Interaction logic for ColorKeyAlphaEffectGrid.xaml
    /// </summary>
    public partial class ChromaKeyAlphaEffectGrid
    {
        public ChromaKeyAlphaEffectGrid()
        {
            InitializeComponent();
        }

        public ChromaKeyAlphaEffectGrid(UIElement uiElement)
        {
            InitializeComponent();

            DataContext = uiElement;

            TextColorRectangle.Fill = new SolidColorBrush(((ChromaKeyAlphaEffect)uiElement.Effect).ColorKey);
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

                var contentControl = ((Rectangle)e.Source).DataContext as ContentControl;

                if (contentControl != null)
                {
                    var dropShadowEffect = contentControl.Effect as ChromaKeyAlphaEffect;

                    if (dropShadowEffect != null) dropShadowEffect.ColorKey = selectedColor.Color;
                }
                ((Rectangle)(sender)).Fill = selectedColor;
            }
        }
    }
}
