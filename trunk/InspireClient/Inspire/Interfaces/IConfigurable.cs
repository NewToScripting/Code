using System.Windows.Controls;

namespace Inspire.Interfaces
{
    public interface IConfigurable
    {
        UserControl GetConfigurationWindow();
        string GetConfigurationTitle();
    }
}
