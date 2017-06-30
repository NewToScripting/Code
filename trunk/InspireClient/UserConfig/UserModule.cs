using System.Windows.Controls;
using Inspire.Interfaces;

namespace UserConfig
{
    public class UserModule : IConfigurable
    {
        #region IConfigurable Members

        public string GetConfigurationTitle()
        {
            return "Users";
        }

        public UserControl GetConfigurationWindow()
        {
            return new UserConfigurationControl();
        }

        #endregion
    }
}
