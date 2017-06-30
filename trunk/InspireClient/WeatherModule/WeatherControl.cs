
using System;
using WeatherModule.Proxy;

namespace WeatherModule
{
    public class WeatherControl
    {
        public WeatherReport WeatherReport { get { return weatherReport; } }

        public string Day1Image { get; set; }

        public string Day2Image { get; set; }

        public string Day3Image { get; set; }

        public string Day4Image { get; set; }

        private readonly DateTime _lastUpdateTime;

        public bool IsWeatherPopulated { get { return weatherReport.Forecast.Count > 0 && _lastUpdateTime > DateTime.Now - TimeSpan.FromHours(1); } }

        public WeatherControl(){}

        public WeatherControl(Location location, string degreeType)
        {
            currentLocation = location;

            if (currentLocation == null)
            {
                currentLocation = new Location();
                LoadSettings();
            }

            _lastUpdateTime = DateTime.Now;

            //weatherProvider = new WeatherProvider();

            unitsSystem = degreeType.ToLower() == "c" ? UnitsSystems.Metric : UnitsSystems.Imperial;

            currentLocation.LocationCode = location.LocationCode;

            weatherReport = WeatherFetcher.GetWeatherReport(currentLocation, unitsSystem); //WeatherProxy.GetLatestWeatherReport(currentLocation, unitsSystem); // weatherProvider.GetLatestWeatherReport(currentLocation, unitsSystem);

            if (weatherReport != null)
                if (weatherReport.Forecast.Count > 4)
                {
                   // weatherReport.Forecast[0].
                    Day1Image = weatherReport.Forecast[1].SkyCondition.SkyImage;
                    Day2Image = weatherReport.Forecast[2].SkyCondition.SkyImage;
                    Day3Image = weatherReport.Forecast[3].SkyCondition.SkyImage;
                    Day4Image = weatherReport.Forecast[4].SkyCondition.SkyImage;
                }
                else if(weatherReport.Forecast.Count > 3)
                {
                    Day1Image = weatherReport.Forecast[1].SkyCondition.SkyImage;
                    Day2Image = weatherReport.Forecast[2].SkyCondition.SkyImage;
                    Day3Image = weatherReport.Forecast[3].SkyCondition.SkyImage;
                }
                else if (weatherReport.Forecast.Count > 2)
                {
                    Day1Image = weatherReport.Forecast[1].SkyCondition.SkyImage;
                    Day2Image = weatherReport.Forecast[2].SkyCondition.SkyImage;
                }
                else if (weatherReport.Forecast.Count > 1)
                {
                    Day1Image = weatherReport.Forecast[1].SkyCondition.SkyImage;
                }
        }

        private void LoadSettings()
        {
            currentLocation.LocationCode = Settings1.Default.LocationCode;
            currentLocation.FullName = Settings1.Default.FullName;
            currentLocation.Country = Settings1.Default.Country;
            currentLocation.State = Settings1.Default.State;
            currentLocation.City = Settings1.Default.City;
            currentLocation.ZipCode = Settings1.Default.ZipCode;
            currentLocation.Longitude = Settings1.Default.Longitude;
            currentLocation.Latitude = Settings1.Default.Latitude;

            unitsSystem = (Settings1.Default.DegreeType == 'F') ? UnitsSystems.Imperial : UnitsSystems.Metric;
        }

        #region PrivateFields

        //private IWeatherProvider weatherProvider;
        private WeatherReport weatherReport;
        private Location currentLocation;
        private UnitsSystems unitsSystem;

        #endregion



        //#region INotifyPropertyChanged Members

        //public event PropertyChangedEventHandler PropertyChanged;

        //#endregion
    }
}
