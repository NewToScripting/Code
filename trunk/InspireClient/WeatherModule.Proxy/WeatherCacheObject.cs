using System;

namespace WeatherModule
{
    public class WeatherCacheObject
    {
        public Location Location { get; set; }
        public DateTime RequestTime { get; set; }
        public object Response { get; set; }
    }
}
