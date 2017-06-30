using System;
using WeatherModule.Proxy;

namespace WeatherModule
{
    public class WeatherRange : Weather
    {

        #region Constructors

        public WeatherRange(UnitsSystems u)
            : base(u)
        {
        }

        #endregion

        #region WeatherProperties

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        private double highTemperature;
        public double HighTemperature
        {
            get { return Math.Floor(highTemperature); }
            set { highTemperature = value; }
        }

        private double lowTemperature;
        public double LowTemperature
        {
            get { return Math.Floor(lowTemperature); }
            set { lowTemperature = value; }
        }

        #endregion

        #region UIProperties

        // These properties are provided for convenient databinding in UI

        public string HighTemperatureString
        {
            get { return HighTemperature + "°"; }
        }

        public string LowTemperatureString
        {
            get { return LowTemperature + "°"; }
        }

        #endregion
    }
}
