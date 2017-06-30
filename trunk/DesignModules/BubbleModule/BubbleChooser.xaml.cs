using System.Windows;

namespace BubbleModule
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class BubbleChooser : Window
    {
        public enum BubbleType
        {
            ScrollBubble,
            InfoBubble
        }

        public string BubbleStyle { get; set; }

        public BubbleType ChoosenType { get; set; }

        public BubbleChooser()
        {
            InitializeComponent();
            ChoosenType = BubbleType.InfoBubble;
            BubbleStyle = "BubbleContainer";
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void rbScrollBubble_Checked(object sender, RoutedEventArgs e)
        {
            if (rbInfoBubble != null)
            {
                ChoosenType = BubbleType.ScrollBubble;
                rbInfoBubble.IsChecked = false;
                BubbleStyle = "ScrollBubble";
            }
        }

        private void rbInfoBubble_Checked(object sender, RoutedEventArgs e)
        {
            if (rbScrollBubble != null)
            {
                ChoosenType = BubbleType.InfoBubble;
                rbScrollBubble.IsChecked = false;
                BubbleStyle = "BubbleContainer";
            }
        }

    }
}
