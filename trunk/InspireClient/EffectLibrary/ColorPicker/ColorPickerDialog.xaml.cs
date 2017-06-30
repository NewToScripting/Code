using System.Windows;
using System.Windows.Media;

namespace EffectLibrary.ColorPicker
{
    /// <summary>
    /// Interaction logic for ColorPickerDialog.xaml
    /// </summary>
    public partial class ColorPickerDialog
    {
        public ColorPickerDialog()
        {
            InitializeComponent();
        }

        private void okButtonClicked(object sender, RoutedEventArgs e)
        {

            OKButton.IsEnabled = false;
            _mColor = cPicker.SelectedColor;
            DialogResult = true;
            Hide();

        }


        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            OKButton.IsEnabled = false;
            DialogResult = false;
        }

        private void onSelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {

            if (e.NewValue != _mColor)
            {

                OKButton.IsEnabled = true;
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {

            OKButton.IsEnabled = false;
            base.OnClosing(e);
        }


        private Color _mColor = new Color();
        private Color startingColor = new Color();

        public Color SelectedColor
        {
            get
            {
                return _mColor;
            }

        }

        public Color StartingColor
        {
            get
            {
                return startingColor;
            }
            set
            {
                cPicker.SelectedColor = value;
                OKButton.IsEnabled = false;

            }

        }
    }
}
