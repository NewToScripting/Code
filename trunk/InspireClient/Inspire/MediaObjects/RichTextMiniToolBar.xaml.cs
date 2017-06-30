using System.Windows;
using System.Windows.Media;
using ActiproSoftware.Windows.Controls.Ribbon.Input;
using Inspire.Commands;
using Inspire.Common.MediaObjects;

namespace Inspire.MediaObjects
{
    /// <summary>
    /// Interaction logic for RichTextMiniToolBar.xaml
    /// </summary>
    public partial class RichTextMiniToolBar
    {
        public RichTextMiniToolBar()
        {
            InitializeComponent();
        }

        private void MoreColors_Click(object sender, ActiproSoftware.Windows.Controls.Ribbon.Controls.ExecuteRoutedEventArgs e)
        {
            ColorPickerDialog cPicker = new ColorPickerDialog();

            var tb = ((FrameworkElement) sender).DataContext as DesignTextBox;

            if (tb != null)
                if (tb.SelectionForeground != null)
                    cPicker.StartingColor = ((SolidColorBrush) tb.SelectionForeground).Color;

            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult)
            {
                SolidColorBrush selectedColor = new SolidColorBrush(cPicker.SelectedColor);

                var param = new BrushValueCommandParameter();

                param.Value = selectedColor;

                param.Action = ValueCommandParameterAction.Commit;

                InspireCommands.ApplyForeground.Execute(param, (FrameworkElement)((FrameworkElement)sender).DataContext);

            }
        }
    }
}
