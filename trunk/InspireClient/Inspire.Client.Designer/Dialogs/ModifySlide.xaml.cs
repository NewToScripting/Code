using System.Windows;

namespace Inspire.Client.Designer.Dialogs
{
    /// <summary>
    /// Interaction logic for ModifySlide.xaml
    /// </summary>
    public partial class ModifySlide
    {
        public ModifySlide()
        {
            InitializeComponent();
            ModifyCurrentSlide = false;
        }

        public bool ModifyCurrentSlide { get; set; }
        
        private bool createNewSlide;

        private void New_Click(object sender, RoutedEventArgs e)
        {
            ModifyCurrentSlide = false;
            createNewSlide = true;
            DialogResult = true;
            Close();
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            ModifyCurrentSlide = true;
            DialogResult = true;
            Close();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            if(ModifyCurrentSlide == false && !createNewSlide)
                DialogResult = false;
        }
    }
}
