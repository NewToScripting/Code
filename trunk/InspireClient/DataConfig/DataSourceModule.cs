using Inspire.Interfaces;

namespace DataConfig
{
    public class DataSourceModule : IConfigurable
    {
        #region IConfigurable Members

        public string GetConfigurationTitle()
        {
            return "Data Sources";
        }

        public System.Windows.Controls.UserControl GetConfigurationWindow()
        {
            return new NewConfigurationControl();
        }

        #endregion
    }
}
