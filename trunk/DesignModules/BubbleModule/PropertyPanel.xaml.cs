using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Inspire;

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
            DataContext = InspireApp.SelectedContext;
            DataContextChanged += new DependencyPropertyChangedEventHandler(PropertyPanel_DataContextChanged);
        }

        void PropertyPanel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            propBase.SetDataContext();
        }

        #region IDisposable Members

        public void Dispose()
        {
            DataContext = null;

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

            SolidColorBrush fontBrush = ((TitleContainer)((ContentControl)((ContentControl)((Rectangle)sender).DataContext).Content).Content).Color;

            cPicker.StartingColor = fontBrush.Color;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                ((TitleContainer)((ContentControl)((ContentControl)((Rectangle)sender).DataContext).Content).Content).Color = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;

            }
            e.Handled = true;
        }

        private void ChangeBackgroundColor_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            SolidColorBrush fontBrush = ((TitleContainer)((ContentControl)((ContentControl)((Rectangle)sender).DataContext).Content).Content).BackgroundColor;

            cPicker.StartingColor = fontBrush.Color;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);
                ((TitleContainer)((ContentControl)((ContentControl)((Rectangle)sender).DataContext).Content).Content).BackgroundColor = selectedColor;
                ((Rectangle)(sender)).Fill = selectedColor;

            }
            e.Handled = true;
        }

    }
}
