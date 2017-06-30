using System.Windows;

namespace EffectLibrary.PropertyGrids
{
    /// <summary>
    /// Interaction logic for InvertColorGrid.xaml
    /// </summary>
    public partial class InvertColorGrid
    {
        public InvertColorGrid()
        {
            InitializeComponent();
        }

        public InvertColorGrid(UIElement uiElement)
        {
            InitializeComponent();

            DataContext = uiElement.Effect;
        }
    }
}
