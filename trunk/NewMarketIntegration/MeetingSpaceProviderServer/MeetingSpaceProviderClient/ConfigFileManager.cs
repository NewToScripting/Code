
using System.Configuration;

namespace MeetingSpaceService_TestHarness
{
    public class ConfigFileManager
    {
        public static string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["NewmarketServerURL"];
        }

        public static string GetPropertyLogin()
        {
            return ConfigurationManager.AppSettings["NewmarketPropertyLogin"];
        }

        public static string GetPropertyPassword()
        {
            return ConfigurationManager.AppSettings["NewmarketPropertyPassword"];
        }

        public static string GetPropertyKey()
        {
            return ConfigurationManager.AppSettings["NewmarketPropertyKey"];
        }

        public static int GetAheadDays()
        {
            return int.Parse(ConfigurationManager.AppSettings["DaysAhead"]);
        }

        public static int GetBehindDays()
        {
            return int.Parse(ConfigurationManager.AppSettings["DaysBehind"]);
        }

        public static bool FilterVisible()
        {
            return bool.Parse(ConfigurationManager.AppSettings["FilterVisible"]);
        }
    }
}
