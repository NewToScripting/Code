using System.Windows;
using System.Windows.Controls;

namespace EffectLibrary.PropertyGrids
{
    /// <summary>
    /// Interaction logic for SharpenGrid.xaml
    /// </summary>
    public partial class SharpenGrid : UserControl
    {
        public SharpenGrid()
        {
            InitializeComponent();
        }

        public SharpenGrid(UIElement uiElement)
        {
            InitializeComponent();

            DataContext = uiElement;
        }
    }
}
