using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MapModule
{
    /// <summary>
    /// Interaction logic for DynamicMarker.xaml
    /// </summary>
    public partial class DynamicMarker
    {
        public DynamicMarker()
        {
            InitializeComponent();
            Resources =
                    new ResourceDictionary
                    {
                        Source =
                            new Uri(
                            "pack://application:,,,/MapModule;component/Resources/Markers.xaml")
                    };
        }

        public static DependencyProperty SelectedTemplateProperty = DependencyProperty.Register("SelectedTemplate", typeof(string), typeof(DynamicMarker), new UIPropertyMetadata("0"));

        public string SelectedTemplate
        {
            get
            {
                return (string)GetValue(SelectedTemplateProperty);
            }
            set
            {
                SetValue(SelectedTemplateProperty, value);
                OnPropertyChanged("SelectedTemplate");
            }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(DynamicMarker), new UIPropertyMetadata(string.Empty));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (!string.IsNullOrEmpty(SelectedTemplate))
            {
                ApplyTemp();
            }
        }

        private void ApplyTemp()
        {
            if (SelectedTemplate == null) return;
            var controlTemplate = FindResource(SelectedTemplate) as ControlTemplate;// = new ControlTemplate();

            if (controlTemplate != null)
            {
                if(Content != null)
                    ((ContentControl)Content).Template = controlTemplate;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        internal void ReloadTemplate()
        {
            ApplyTemp();
        }
    }
}
