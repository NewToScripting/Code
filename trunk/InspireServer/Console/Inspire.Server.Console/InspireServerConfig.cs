//using System.Configuration;
//using System.Windows.Forms;


//namespace Inspire.Server.Console
//{
//   class InspireServerConfig
//    {

//        static private Configuration GetConfiguration()
//        {
//            ExeConfigurationFileMap filemap = new ExeConfigurationFileMap();
//            filemap.ExeConfigFilename = Application.StartupPath + @"\InspireSettings.config";
//            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(filemap, ConfigurationUserLevel.None);
//            return config;
//        }

//        static public string GetValue(string KeyName)
//        {
//            Configuration config = GetConfiguration();
//            string keyValue = config.AppSettings.Settings[KeyName].Value;
//            return keyValue;
//        }

//        static public void UpdateValue(string keyName, string keyValue)
//        {
//            ExeConfigurationFileMap filemap = new ExeConfigurationFileMap();
//            filemap.ExeConfigFilename = Application.StartupPath + @"\InspireSettings.config";
//            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(filemap, ConfigurationUserLevel.None);

//            config.AppSettings.Settings.Remove(keyName);
//            config.AppSettings.Settings.Add(keyName, keyValue);
//            config.Save();

//        }


//    }

//}

