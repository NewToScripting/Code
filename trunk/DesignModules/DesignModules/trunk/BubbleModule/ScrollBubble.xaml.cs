namespace BubbleModule
{
    /// <summary>
    /// Interaction logic for ScrollBubble.xaml
    /// </summary>
    public partial class ScrollBubble : TitleContainer
    {
        public ScrollBubble()
        {
            InitializeComponent();
        }

        public ScrollBubble(string title)
        {
            InitializeComponent();
            HeaderTitle = title;
        }
    }
}
