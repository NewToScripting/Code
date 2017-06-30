using System.Collections;
using System.Windows.Controls;

namespace Inspire.AnimationLibrary
{
    /// <summary>
    /// Interaction logic for LoadAnimationPicker.xaml
    /// </summary>
    public partial class LoadAnimationPicker
    {
        public LoadAnimationPicker()
        {
            InitializeComponent();
            cbLoadAnimation.ItemsSource = AnimationManager.GetInAnimations();
            cbLoadAnimation.SelectionChanged += cbLoadAnimation_SelectionChanged;
        }

        void cbLoadAnimation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DictionaryEntry)
                SelectedAnimation = ((DictionaryEntry)sender).Key.ToString();
            else if (sender is ComboBox)
                if(((ComboBox) sender).SelectedValue != null)
                SelectedAnimation = ((DictionaryEntry) ((ComboBox) sender).SelectedValue).Key.ToString();
        }

        public string SelectedAnimation { get; set; }

        private void ClearEffectClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            cbLoadAnimation.SelectedIndex = -1;
            SelectedAnimation = null;
        }
    }
}
