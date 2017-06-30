using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BubbleModule
{
    /// <summary>
    /// Interaction logic for InfoBubble.xaml
    /// </summary>
    public partial class InfoBubble : TitleContainer
    {

        public InfoBubble()
        {
            InitializeComponent();
        }

        public InfoBubble(string title)
        {
            InitializeComponent();
            //HeaderTitle = title;
        }




    }
}
