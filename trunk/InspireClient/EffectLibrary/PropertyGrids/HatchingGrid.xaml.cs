using System.Windows;
using EffectLibrary.Effects;

namespace EffectLibrary.PropertyGrids
{
    /// <summary>
    /// Interaction logic for HatchingGrid.xaml
    /// </summary>
    public partial class HatchingGrid
    {
        public HatchingGrid()
        {
            InitializeComponent();
        }

        public HatchingGrid(UIElement uiElement)
        {
            InitializeComponent();

            DataContext = uiElement.Effect;
        }
    }
}
