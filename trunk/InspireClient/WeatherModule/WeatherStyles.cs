using System.Collections.Generic;

namespace WeatherModule
{
    public class WeatherStyles
    {
        private static readonly List<KeyValuePair<string, string>> weatherStyles;

        static WeatherStyles()
        {
            weatherStyles = new List<KeyValuePair<string, string>>();
            weatherStyles.Add(new KeyValuePair<string, string>("TodayTemp","Current Temperature"));
            weatherStyles.Add(new KeyValuePair<string, string>("Today", "Today's Weather"));
            weatherStyles.Add(new KeyValuePair<string, string>("TodayImageHiLow", "Today's Weather + Hi Low"));
            weatherStyles.Add(new KeyValuePair<string, string>("3Day", "Today plus 3 Day forcast"));
            weatherStyles.Add(new KeyValuePair<string, string>("3DayHorizontal", "3 Day Horizontal forcast"));
            weatherStyles.Add(new KeyValuePair<string, string>("3DayVertical", "3 Day Vertical forecast"));
            weatherStyles.Add(new KeyValuePair<string, string>("5DayHorizontal", "5 Day Horizontal forcast"));
            weatherStyles.Add(new KeyValuePair<string, string>("5DayVertical", "5 Day Vertical forecast"));
            weatherStyles.Add(new KeyValuePair<string, string>("TodayHiLow", "Today's Hi / Low"));
            weatherStyles.Add(new KeyValuePair<string, string>("CurrentCondition", "Current Condition"));
            weatherStyles.Add(new KeyValuePair<string, string>("5DayDetailed", "5 Day Detailed forecast"));
        }

        public static List<KeyValuePair<string, string>> GetWeatherStyles
        {
            get { return weatherStyles; }
        }
    }
}
