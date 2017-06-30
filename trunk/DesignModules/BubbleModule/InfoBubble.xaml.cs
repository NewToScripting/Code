using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace BubbleModule
{
    /// <summary>
    /// Interaction logic for InfoBubble.xaml
    /// </summary>
    public partial class InfoBubble : INotifyPropertyChanged, IDisposable
    {
       // public string SelectedTemplate { get; set; }

        //~InfoBubble()
        //{
        //    MessageBox.Show("Info Bubble Gone");
        //}

        public static DependencyProperty SelectedTemplateProperty = DependencyProperty.Register(
            "SelectedTemplate", typeof(string), typeof(InfoBubble));

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

        public InfoBubble()
        {
            InitializeComponent();
        }

        public InfoBubble(string title)
        {
            InitializeComponent();
            //HeaderTitle = title;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ControlTemplate controlTemplate = new ControlTemplate();

            if (!string.IsNullOrEmpty(SelectedTemplate))
            {
                controlTemplate = FindResource(SelectedTemplate) as ControlTemplate;

                if (controlTemplate != null)
                {
                    ((ContentControl) Content).Template = controlTemplate;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            ClearValue(ContentProperty);
        }
    }
}
