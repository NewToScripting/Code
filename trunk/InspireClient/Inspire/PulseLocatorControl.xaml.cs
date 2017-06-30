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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inspire
{
    /// <summary>
    /// Interaction logic for PulseLocatorControl.xaml
    /// </summary>
    public partial class PulseLocatorControl : UserControl
    {
        private bool _isLoaded;

        public PulseLocatorControl()
        {
            InitializeComponent();
        }

        private void Viewbox_Loaded(object sender, RoutedEventArgs e)
        {
            if(!_isLoaded)
            {
                var storyBoard = Resources["YouAreHerePulse"] as Storyboard;
                if(storyBoard != null)
                    BeginStoryboard(storyBoard);
                _isLoaded = true;
            }
        }
    }
}
