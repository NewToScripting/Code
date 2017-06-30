using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherModule.Proxy
{
    public static class WeatherFetcher
    {
        public static WeatherReport GetWeatherReport(Location location, UnitsSystems us)
        {
            WeatherReport weatherReport = null;
            if (location != null)
            {
                DailyWeatherCacheClear(); // Clears out old cached request from the static list

                if (WeatherCache.WeatherCacheObjects.Count == 0)
                {
                    weatherReport = AddWeatherReportToCache(location, us, ref weatherReport);
                }
                else
                {
                    var cachedObject = WeatherCache.WeatherCacheObjects.FirstOrDefault(c => c.Location.LocationCode == location.LocationCode);

                    if (cachedObject == null)
                        weatherReport = AddWeatherReportToCache(location, us, ref weatherReport);
                    else
                    {
                        if (DateTime.Now > cachedObject.RequestTime + TimeSpan.FromMinutes(30) || ((WeatherReport)cachedObject.Response).LatestWeather == null)
                        {
                            WeatherCache.WeatherCacheObjects.Remove(cachedObject);
                            return AddWeatherReportToCache(location, us, ref weatherReport);
                        }

                        if (cachedObject.Response != null)
                            return cachedObject.Response as WeatherReport;
                    }
                }
            }
            return weatherReport;
        }

        private static WeatherReport AddWeatherReportToCache(Location location, UnitsSystems us, ref WeatherReport weatherReport)
        {
            weatherReport = WeatherProxy.GetLatestWeatherReport(location, us);
            WeatherCache.WeatherCacheObjects.Add(new WeatherCacheObject{ Location = location, RequestTime = DateTime.Now, Response = weatherReport});
            return weatherReport;
        }

        private static void DailyWeatherCacheClear()
        {
            if (WeatherCache.WeatherCacheObjects == null)
            {
                WeatherCache.WeatherCacheObjects = new List<WeatherCacheObject>();
                WeatherCache.CurrentRequestDay = DateTime.Now;
                return;
            }

            if (WeatherCache.CurrentRequestDay.DayOfYear < DateTime.Now.DayOfYear)
            {
                for (int i = WeatherCache.WeatherCacheObjects.Count - 1; i >= 0; i--)
                {
                    if (WeatherCache.WeatherCacheObjects[i].RequestTime < DateTime.Now - TimeSpan.FromHours(2))
                        WeatherCache.WeatherCacheObjects.Remove(WeatherCache.WeatherCacheObjects[i]);
                }
                WeatherCache.CurrentRequestDay = DateTime.Now;
            }
        }
    }
}
