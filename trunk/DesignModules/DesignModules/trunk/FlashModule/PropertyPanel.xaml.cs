using System;

namespace FlashModule
{
    /// <summary>
    /// Interaction logic for PropertyPanel.xaml
    /// </summary>
    public partial class PropertyPanel : IDisposable
    {
        public PropertyPanel()
        {
            InitializeComponent();
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
