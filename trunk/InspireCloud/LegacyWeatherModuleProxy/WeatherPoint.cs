using System;
using WeatherModule.Proxy;

namespace WeatherModule
{
    public class WeatherPoint : Weather
    {
        public WeatherPoint(UnitsSystems u)
            : base(u)
        {
        }

        public DateTime Time { get; set; }

        private double temperature;
        public double Temperature
        {
            get { return Math.Floor(temperature); }
            set { temperature = value; }
        }

        public string TemperatureString
        {
            get { return Temperature + "°"; }
        }

        private double feelsLike;
        public double FeelsLike
        {
            get { return Math.Floor(feelsLike); }
            set { feelsLike = value; }
        }
    }
}
