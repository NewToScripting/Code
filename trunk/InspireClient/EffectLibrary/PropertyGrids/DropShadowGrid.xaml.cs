using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using EffectLibrary.ColorPicker;

namespace EffectLibrary.PropertyGrids
{
    /// <summary>
    /// Interaction logic for DropShadowGrid.xaml
    /// </summary>
    public partial class DropShadowGrid
    {
        public DropShadowGrid()
        {
            InitializeComponent();
        }

        public DropShadowGrid(UIElement uiElement)
        {
            InitializeComponent();

            DataContext = uiElement;

            TextColorRectangle.Fill = new SolidColorBrush(((DropShadowEffect) uiElement.Effect).Color);
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
                    var dropShadowEffect = contentControl.Effect as DropShadowEffect;

                    if (dropShadowEffect != null) dropShadowEffect.Color = selectedColor.Color;
                }
                ((Rectangle)(sender)).Fill = selectedColor;
            }
        }
    }
}
