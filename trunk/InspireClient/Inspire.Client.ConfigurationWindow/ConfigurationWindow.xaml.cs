using System;
using System.Windows;
using Inspire.Client.Designer.DragCanvas;
using Inspire.Services.WeakEventHandlers;

namespace Inspire.Client.ConfigurationWindow
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : IWeakEventListener
    {
        public ConfigurationWindow()
        {
            InitializeComponent();
            LoadedEventManager.AddListener(this, this);
        }

        void ConfigurationWindow_Loaded(object sender, EventArgs e)
        {
            if(!Designer.DesignWindow.IsDesignerMode)
                RefreshTree();
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                ConfigurationWindow_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
