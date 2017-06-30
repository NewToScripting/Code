using WeatherModule.Proxy;

namespace WeatherModule
{
    public abstract class Weather
    {
        public Weather(UnitsSystems unit)
        {
            unitsSystem = unit;
            skyCondition = new Sky();
            windVector = new Wind();
        }

        private double? humidity;
        public double? Humidity
        {
            get { return humidity; }
            set { humidity = value; }
        }

        private double? precipitation;
        public double? Precipitation
        {
            get { return precipitation; }
            set { precipitation = value; }
        }

        private Sky skyCondition;
        public Sky SkyCondition
        {
            get { return skyCondition; }
            set { skyCondition = value; }
        }

        private Wind windVector;
        public Wind WindVector
        {
            get { return windVector; }
            set { windVector = value; }
        }

        private UnitsSystems unitsSystem;
        public UnitsSystems UnitsSystem
        {
            get { return unitsSystem; }
            set { unitsSystem = value; }
        }
    }
}
