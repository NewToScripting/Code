using System;
using System.Windows.Media;
using System.Windows.Shapes;
using Inspire;
using Inspire.MediaObjects;

namespace BubbleModule
{
    /// <summary>
    /// Interaction logic for PropertyPanel.xaml
    /// </summary>
    public partial class PropertyPanel : IDisposable
    {
        public PropertyPanel()
        {
            InitializeComponent();
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (Content != null)
                Content = null;
            if (grid != null)
            {
                if (grid.Child != null)
                    grid.Child = null;

                grid = null;
            }
            GC.SuppressFinalize(this);
        }

        #endregion

        private void ChangeTitleColor_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            SolidColorBrush fontBrush = ((TitleContainer)((DesignContentControl)((Rectangle)sender).DataContext).Content).Color;

            cPicker.StartingColor = fontBrush.Color;
            //cPicker.Owner = this;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                ((TitleContainer)((DesignContentControl)((Rectangle)sender).DataContext).Content).Color = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;

            }
            e.Handled = true;
        }

    }
}
