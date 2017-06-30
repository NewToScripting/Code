using System;
using System.Configuration;
using System.Windows;

namespace Inspire
{
    public class ServerSettings
    {
        static ServerSettings()
        {
            var mappedConfig = new ExeConfigurationFileMap();
            mappedConfig.ExeConfigFilename = "ServerSettings.config";
            var libConfig = ConfigurationManager.OpenMappedExeConfiguration(mappedConfig, ConfigurationUserLevel.None);
            var section = (libConfig.GetSection("appSettings") as AppSettingsSection);
            if (section != null) ConfigServer = section.Settings["ServerHostName"].Value;
        }

        public static void SetConfigServer(string configServer)
        {
            var mappedConfig = new ExeConfigurationFileMap();
            mappedConfig.ExeConfigFilename = "ServerSettings.config";
            var libConfig = ConfigurationManager.OpenMappedExeConfiguration(mappedConfig, ConfigurationUserLevel.None);
            var section = (libConfig.GetSection("appSettings") as AppSettingsSection);
            if (section != null) 
                section.Settings["ServerHostName"].Value = configServer;

            ConfigServer = configServer;

            try
            {
                libConfig.Save(ConfigurationSaveMode.Minimal, true);
            }
            catch (Exception)
            {
                MessageBox.Show("Could not write the server name, it may already be set to: " + configServer +
                                ". Please ensure that the server is running and try again.");
            }
            
        }

        public static string ConfigServer { get; private set; }

        public static void SetDemoMode()
        {
            try
            {
                var mappedConfig = new ExeConfigurationFileMap();
                mappedConfig.ExeConfigFilename = "ServerSettings.config";
                var libConfig = ConfigurationManager.OpenMappedExeConfiguration(mappedConfig, ConfigurationUserLevel.None);
                var section = (libConfig.GetSection("appSettings") as AppSettingsSection);
                if (section != null) if (section.Settings["AppMode"].Value == "Demo")
                        InspireApp.IsDemoMode = true;
            }
            catch (Exception)
            {
                // not that important
            }
            
        }
    }
}
