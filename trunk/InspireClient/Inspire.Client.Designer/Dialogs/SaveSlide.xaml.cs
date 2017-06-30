using System.Windows;

namespace Inspire.Client.Designer.Dialogs
{
    /// <summary>
    /// Interaction logic for SaveSlide.xaml
    /// </summary>
    public partial class SaveSlide
    {
        public SaveSlide()
        {
            InitializeComponent();
        }

        public SaveSlide(string slideName, string slideDescription)
        {
            InitializeComponent();
            SlideName = slideName;
            SlideDescription = slideDescription;
        }

        public string SlideName
        {
            get { return tbSlideName.Text; }
            set { tbSlideName.Text = value; }
        }

        public string SlideDescription
        {
            get { return tbSlideDescription.Text; }
            set { tbSlideDescription.Text = value; }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
