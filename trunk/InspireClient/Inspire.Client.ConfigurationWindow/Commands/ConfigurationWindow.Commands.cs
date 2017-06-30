using System;
using Inspire.Common.TreeViewModel;
using Inspire.Server.Proxy;

namespace Inspire.Client.ConfigurationWindow
{
    public partial class ConfigurationWindow
    {

        private void RefreshTree()
        {
            try
            {
                DisplayProperty[] displayProperties = DisplayPropertyManager.GetAllDisplayProperties().ToArray();
                CorporationViewModel viewModel = new CorporationViewModel(displayProperties);
                DataContext = viewModel;
            }
            catch (Exception)
            {
                // TODO: Check for database to be off line, also handle adding properties because an exception is thrown there
                //MessageBox.Show("Loading the AdminTree Failed." + ex);
            }
        }
    }
}
