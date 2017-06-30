using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EffectLibrary
{
    /// <summary>
    /// Interaction logic for EffectSelector.xaml
    /// </summary>
    public partial class EffectSelector : UserControl
    {
        private UIElement uiElement;

        bool hasLoaded;

        public EffectSelector()
        {
            InitializeComponent();

            cbEffects.ItemsSource = EffectManager.GetEffectNames();

            Loaded += EffectSelector_Loaded; // TODO: Change To WeakEvent

            DataContextChanged += new DependencyPropertyChangedEventHandler(EffectSelector_DataContextChanged);
        }

        void EffectSelector_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(hasLoaded)
                ChangeEffect();
        }

        void EffectSelector_Loaded(object sender, RoutedEventArgs e)
        {
            if (!hasLoaded)
            {
                ChangeEffect();
                hasLoaded = true;
            }
        }

        private void ChangeEffect()
        {
            uiElement = DataContext as UIElement;

            if (uiElement != null)
                if (uiElement.Effect != null)
                {
                    cbEffects.SelectedIndex = EffectManager.GetEffectIndex(uiElement);

                    PropertyGridHolder.Children.Clear();

                    UIElement propertyControl = EffectManager.GetPropertyGridForEffect(uiElement);
                    if (propertyControl != null)
                        PropertyGridHolder.Children.Add(propertyControl);
                }
                else
                    cbEffects.SelectedIndex = -1;
        }

        private void cbEffects_DropDownClosed(object sender, EventArgs e)
        {
            PropertyGridHolder.Children.Clear();

            if (((ComboBox)sender).SelectedItem != null && uiElement != null)
            {
                string effectName = ((ComboBox)sender).SelectedItem.ToString();

                UIElement propertyControl = EffectManager.ApplyEffectGetPropertyGrid(effectName, uiElement);
                if(propertyControl != null)
                    PropertyGridHolder.Children.Add(propertyControl);
            }
        }

        private void ClearEffectClick(object sender, MouseButtonEventArgs e)
        {
            PropertyGridHolder.Children.Clear();

            uiElement = DataContext as UIElement;
            if (uiElement != null)
                uiElement.Effect = null;

            cbEffects.SelectedIndex = -1;
            
        }
    }
}
