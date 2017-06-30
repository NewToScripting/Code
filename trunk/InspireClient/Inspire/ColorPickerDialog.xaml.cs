using System.Windows;
using System.Windows.Media;

namespace Inspire
{
    public partial class ColorPickerDialog
    {


        public ColorPickerDialog()
        {
            InitializeComponent();
        }

        private void okButtonClicked(object sender, RoutedEventArgs e)
        {

            OKButton.IsEnabled = false;
            m_color = cPicker.SelectedColor;
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

            if (e.NewValue != m_color)
            {

                OKButton.IsEnabled = true;
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {

            OKButton.IsEnabled = false;
            base.OnClosing(e);
        }


        private Color m_color = new Color();
        private Color startingColor = new Color();

        public Color SelectedColor
        {
            get
            {
                return m_color;
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
