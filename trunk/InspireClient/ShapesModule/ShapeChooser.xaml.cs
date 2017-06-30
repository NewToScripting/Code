using System;
using System.Collections;
using System.Windows;

namespace ShapesModule
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ShapeChooser
    {
        public string ShapeStyle { get; set; }

        private readonly ResourceDictionary shapeDictionary;

        public ShapeChooser()
        {
            InitializeComponent();

            shapeDictionary = new ResourceDictionary
            {
                Source =
                    new Uri(
                    "pack://application:,,,/ShapesModule;component/Resources/Shapes.xaml")
            };

            Loaded += new RoutedEventHandler(ShapeChooser_Loaded);
        }

        void ShapeChooser_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (DictionaryEntry entry in shapeDictionary)
            {
                ShapeControl shapeControl = new ShapeControl();
                shapeControl.Width = 100;
                shapeControl.Height = 100;
                shapeControl.SelectedTemplate = entry.Key.ToString();
                shapePanel.Items.Add(shapeControl);
            }
            shapePanel.SelectedIndex = 0;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if(shapePanel.SelectedItem != null)
                ShapeStyle = ((ShapeControl) shapePanel.SelectedItem).SelectedTemplate;
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
