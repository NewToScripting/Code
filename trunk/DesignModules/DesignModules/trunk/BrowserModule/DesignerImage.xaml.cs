using System.Windows;

namespace BrowserModule
{
    /// <summary>
    /// Interaction logic for DesignerImage.xaml
    /// </summary>
    public partial class DesignerImage
    {

        public static readonly DependencyProperty WebSiteNameProperty = DependencyProperty.Register("WebSiteName", typeof(string), typeof(DesignerImage));

        public string WebSiteName
        {
            get { return (string)GetValue(WebSiteNameProperty); }
            set
            {
                SetValue(WebSiteNameProperty, value);
            }
        }

        public DesignerImage()
        {
            InitializeComponent();
        }

        public DesignerImage(string webSiteName)
        {
            InitializeComponent();
            WebSiteName = webSiteName;
        }
    }
}
