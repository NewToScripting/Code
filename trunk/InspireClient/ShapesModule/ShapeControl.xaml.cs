using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ShapesModule
{
    public partial class ShapeControl : INotifyPropertyChanged
    {
        public static DependencyProperty SelectedTemplateProperty = DependencyProperty.Register(
            "SelectedTemplate", typeof(string), typeof(ShapeControl));

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

        public ShapeControl()
        {
            InitializeComponent();
            Resources =
                    new ResourceDictionary
                    {
                        Source =
                            new Uri(
                            "pack://application:,,,/ShapesModule;component/Resources/Shapes.xaml")
                    };
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ControlTemplate controlTemplate;// = new ControlTemplate();

            if (!string.IsNullOrEmpty(SelectedTemplate))
            {
                controlTemplate = FindResource(SelectedTemplate) as ControlTemplate;//SelectedTemplate

                if (controlTemplate != null)
                {
                    ((ContentControl)Content).Template = controlTemplate;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
