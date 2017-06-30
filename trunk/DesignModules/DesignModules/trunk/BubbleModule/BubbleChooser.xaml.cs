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

        public BubbleType ChoosenType { get; set; }

        public BubbleChooser()
        {
            InitializeComponent();
            ChoosenType = BubbleType.InfoBubble;
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
            ChoosenType = BubbleType.ScrollBubble;
            rbInfoBubble.IsChecked = false;
        }

        private void rbScrollBubble_Unchecked(object sender, RoutedEventArgs e)
        {
            ChoosenType = BubbleType.InfoBubble;
            rbScrollBubble.IsChecked = false;
        }

    }
}
