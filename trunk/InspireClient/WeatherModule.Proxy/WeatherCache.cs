using System;
using System.Collections.Generic;

namespace WeatherModule
{
    public class WeatherCache
    {
        public static List<WeatherCacheObject> WeatherCacheObjects { get; set; }
        public static DateTime CurrentRequestDay { get; set; }
    }
}
