using System.Collections.Generic;
using WeatherModule.Proxy;

namespace WeatherModule
{
    public class WeatherReport
    {

        #region WeatherProperties

        public WeatherReport()
        {
            Forecast = new List<WeatherRange>();
        }

        public WeatherPoint LatestWeather { get; set; }

        public List<WeatherRange> Forecast { get; set; }

        public Location Location { get; set; }

        public UnitsSystems UnitsSystem { get; set; }

        #endregion

        #region UIProperties

        public int SkyCode { get; set; }

        #region BackgroundProperties
        public string BackgroundImage
        {
            get
            {
                if (isNight())
                {
                    return "pack://application:,,,/WeatherModule;component/Resources/Images/" + SkyCode + "n.png";
                }
                return "pack://application:,,,/WeatherModule;component/Resources/Images/" + SkyCode + ".png";
            }
        }

        #endregion

        #endregion

        #region PrivateMethods

        private string weatherState(int code)
        {
            string theWeatherState = code.ToString();
            switch (code)
            {
                case (26):
                case (27):
                case (28):
                    theWeatherState = "cloudy";
                    break;
                case (35):
                case (39):
                case (45):
                case (46):
                    theWeatherState = "few-showers";
                    break;
                case (19):
                case (20):
                case (21):
                case (22):
                    theWeatherState = "foggy";
                    break;
                case (29):
                case (30):
                case (33):
                    theWeatherState = "partly-cloudy";
                    break;
                case (5):
                case (13):
                case (14):
                case (15):
                case (16):
                case (18):
                case (25):
                case (41):
                case (42):
                case (43):
                    theWeatherState = "snow";
                    break;
                case (1):
                case (2):
                case (3):
                case (4):
                case (37):
                case (38):
                case (47):
                    theWeatherState = "thunderstorm";
                    break;
                case (31):
                case (32):
                case (34):
                case (36):
                case (44):        // Note 44- "Data Not Available"
                    theWeatherState = "";
                    break;
                case (23):
                case (24):
                    theWeatherState = "windy";
                    break;
                case (9):
                case (10):
                case (11):
                case (12):
                case (40):
                    theWeatherState = "rainy";
                    break;
                case (6):
                case (7):
                case (8):
                case (17):
                    theWeatherState = "hail";
                    break;
                default:
                    theWeatherState = "";
                    break;
            }
            return theWeatherState;
        }

        private bool isNight()
        {

            // TODO: Make the isNight algorithm more sophisticated when night implementation is enabled
            //if ((LatestWeather.SkyCondition.SkyCondition.Contains("Cloudy")) ||
            //               (LatestWeather.SkyCondition.SkyCondition.Contains("Fair")) ||
            //               (LatestWeather.SkyCondition.SkyCondition.Contains("Sprinkles")))
            //{
            //    return true;
            //}

            if (LatestWeather == null)
                return false;

            return (LatestWeather.Time.Hour >= 6 && LatestWeather.Time.Hour <= 19) ? false : true;

        }

        #endregion

    }
}
