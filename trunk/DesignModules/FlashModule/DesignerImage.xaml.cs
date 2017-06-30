using System.Windows;

namespace FlashModule
{
    /// <summary>
    /// Interaction logic for DesignerImage.xaml
    /// </summary>
    public partial class DesignerImage
    {
        public static readonly DependencyProperty SWFNameProperty = DependencyProperty.Register("SWFName", typeof(string), typeof(DesignerImage));

        public string SWFName
        {
            get { return (string)GetValue(SWFNameProperty); }
            set
            {
                SetValue(SWFNameProperty, value);
            }
        }


        public DesignerImage()
        {
            InitializeComponent();
        }

        public DesignerImage(string fileName)
        {
            InitializeComponent();
            SWFName = fileName;
        }
    }
}
