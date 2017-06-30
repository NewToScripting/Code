namespace EventsModule.Dialogs
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem
    {
        public AddItem()
        {
            InitializeComponent();
        }

        public AddItem(string titleName, string labelName)
        {
            InitializeComponent();
            Title = titleName;
            lblAddItem.Content = labelName;
        }

        private void btnOk_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
