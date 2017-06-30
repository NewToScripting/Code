using System;
using System.Windows;
using Inspire;

namespace StreamingModule
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PropertyPanel : IDisposable
    {
        public PropertyPanel()
        {
            InitializeComponent();
            DataContext = InspireApp.SelectedContext;
            DataContextChanged += new DependencyPropertyChangedEventHandler(PropertyPanel_DataContextChanged);
        }

        void PropertyPanel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            propBase.SetDataContext();
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (Content != null)
                Content = null;
            if (grid != null)
            {
                if (grid.Child != null)
                    grid.Child = null;

                grid = null;
            }
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}