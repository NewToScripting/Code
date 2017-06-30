using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EffectLibrary.PropertyGrids
{
    /// <summary>
    /// Interaction logic for LightStreakGrid.xaml
    /// </summary>
    public partial class LightStreakGrid : UserControl
    {
        public LightStreakGrid()
        {
            InitializeComponent();
        }

        public LightStreakGrid(UIElement uiElement)
        {
            InitializeComponent();

            DataContext = uiElement.Effect;
        }
    }
}
