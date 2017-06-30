using System;
using System.Collections.Generic;
using System.Linq;
using WeatherModule.Proxy.WeatherService;

namespace WeatherModule.Proxy
{
    public static class WeatherProxy
    {
        public static List<Location> QueryLocations(string query)
        {
            WeatherServiceClient weatherServiceClient = null;
            try
            {
                weatherServiceClient = new WeatherServiceClient("WeatherServiceEndpoint");

                var results = weatherServiceClient.QueryLocations(query);

                weatherServiceClient.Close();

                return ConvertToLocations(results);
            }
            catch (Exception)
            {
                if (weatherServiceClient != null) weatherServiceClient.Close();
                return new List<Location>();
            }
        }

        private static List<Location> ConvertToLocations(WeatherService.Location[] results)
        {
            List<Location> locations = null;
            if (results != null)
            {
                locations = results.Select(ConvertLocation).ToList();
            }
            return locations;
        }

        private static Location ConvertLocation(WeatherService.Location serviceLocation)
        {
            Location location = null;

            if (serviceLocation != null)
            {
                location = new Location();
                location.City = serviceLocation.City;
                location.State = serviceLocation.State;
                location.FullName = serviceLocation.FullName;
                location.LocationCode = serviceLocation.LocationCode;
                location.ZipCode = serviceLocation.ZipCode;
            }
            return location;
        }

        public static WeatherReport GetLatestWeatherReport(Location location, UnitsSystems us)
        {
            WeatherServiceClient weatherServiceClient = null;//"WeatherServiceEndpoint");
            try
            {
                weatherServiceClient = new WeatherServiceClient();
                weatherServiceClient.Endpoint.Address = ServerSettings.GetWeatherServiceEndpoint();

                WeatherService.Location serviceLocation = ConvertFromLocation(location);

                WeatherService.WeatherReport.UnitsSystems serviceUs = ConvertFromUnitSystem(us);

                var serviceWeatherReport = weatherServiceClient.GetLatestWeatherReport(serviceLocation, serviceUs);

                weatherServiceClient.Close();

                return ConvertWeatherReport(serviceWeatherReport);
            }
            catch (Exception)
            {
                if (weatherServiceClient != null) weatherServiceClient.Close();
                return new WeatherReport();
            }
        }

        private static WeatherReport ConvertWeatherReport(WeatherService.WeatherReport serviceWeatherReport)
        {
            WeatherReport weatherReport = null;

            if (serviceWeatherReport != null)
            {
                weatherReport = new WeatherReport();
                weatherReport.Forecast = ConvertToForcast(serviceWeatherReport.Forecast);
                weatherReport.LatestWeather = ConvertToLatestWeather(serviceWeatherReport.LatestWeather);
                weatherReport.Location = ConvertToLocation(serviceWeatherReport.Location);
                weatherReport.SkyCode = serviceWeatherReport.SkyCode;
                weatherReport.UnitsSystem = ConvertToUnitSystem(serviceWeatherReport.UnitsSystem);
            }
            return weatherReport;
        }

        private static UnitsSystems ConvertToUnitSystem(WeatherService.WeatherReport.UnitsSystems unitsSystem)
        {
            if (unitsSystem == WeatherService.WeatherReport.UnitsSystems.Imperial)
                return UnitsSystems.Imperial;
            return UnitsSystems.Metric;
        }

        private static Location ConvertToLocation(WeatherService.Location serviceLocation)
        {
            Location location = null;

            if (serviceLocation != null)
            {
                location = new Location();
                location.City = serviceLocation.City;
                location.Country = serviceLocation.Country;
                location.FullName = serviceLocation.FullName;
                location.Latitude = serviceLocation.Latitude;
                location.LocationCode = serviceLocation.LocationCode;
                location.Longitude = serviceLocation.Longitude;
                location.State = serviceLocation.State;
                location.ZipCode = serviceLocation.ZipCode;
            }
            return location;
        }

        private static WeatherPoint ConvertToLatestWeather(WeatherService.WeatherPoint latestWeather)
        {
            WeatherPoint weatherPoint = null;

            if (latestWeather != null)
            {
                weatherPoint = new WeatherPoint(ConvertToUnitSystem(latestWeather.UnitsSystem));
                weatherPoint.FeelsLike = latestWeather.FeelsLike;
                weatherPoint.Humidity = latestWeather.Humidity;
                weatherPoint.Precipitation = latestWeather.Precipitation;
                weatherPoint.SkyCondition = ConvertToSky(latestWeather.SkyCondition);
                weatherPoint.Temperature = latestWeather.Temperature;
                weatherPoint.Time = latestWeather.Time;
                weatherPoint.WindVector = ConvertToWind(latestWeather.WindVector);
            }
            return weatherPoint;
        }

        private static Wind ConvertToWind(WeatherService.Wind serviceWind)
        {
            Wind wind = null;

            if (serviceWind != null)
            {
                wind = new Wind();
                wind.Direction = (WindDirections)serviceWind.Direction;
                wind.Speed = serviceWind.Speed;
            }
            return wind;
        }

        private static Sky ConvertToSky(WeatherService.Sky serviceSky)
        {
            Sky sky = null;
            if (serviceSky != null)
            {
                sky = new Sky();
                sky.SkyCondition = serviceSky.SkyCondition;
                sky.SkyImage = serviceSky.SkyImage;
            }
            return sky;
        }

        private static List<WeatherRange> ConvertToForcast(WeatherService.WeatherRange[] forecast)
        {
            List<WeatherRange> weatherRanges = null;

            if (forecast != null)
            {
                weatherRanges = new List<WeatherRange>();

                foreach (var w in forecast)
                {
                    weatherRanges.Add(ConvertToWeatherRange(w));
                }
            }
            return weatherRanges;
        }

        private static WeatherRange ConvertToWeatherRange(WeatherService.WeatherRange serviceWeatherRange)
        {
            WeatherRange weatherRange = null;
            if (serviceWeatherRange != null)
            {
                weatherRange = new WeatherRange(ConvertToUnitSystem(serviceWeatherRange.UnitsSystem));
                weatherRange.EndTime = serviceWeatherRange.EndTime;
                weatherRange.HighTemperature = serviceWeatherRange.HighTemperature;
                weatherRange.LowTemperature = serviceWeatherRange.LowTemperature;
                weatherRange.Precipitation = serviceWeatherRange.Precipitation;
                weatherRange.Humidity = serviceWeatherRange.Humidity;
                weatherRange.SkyCondition = ConvertToSky(serviceWeatherRange.SkyCondition);
                weatherRange.StartTime = serviceWeatherRange.StartTime;
                weatherRange.UnitsSystem = ConvertToUnitSystem(serviceWeatherRange.UnitsSystem);
                weatherRange.WindVector = ConvertToWind(serviceWeatherRange.WindVector);
            }
            return weatherRange;
        }

        private static WeatherService.WeatherReport.UnitsSystems ConvertFromUnitSystem(UnitsSystems us)
        {
            if (us == UnitsSystems.Imperial)
                return WeatherService.WeatherReport.UnitsSystems.Imperial;
            return WeatherService.WeatherReport.UnitsSystems.Metric;
        }

        private static WeatherService.Location ConvertFromLocation(Location location)
        {
            WeatherService.Location serviceLocation = null;

            if (location != null)
            {
                serviceLocation = new WeatherService.Location();
                serviceLocation.City = location.City;
                serviceLocation.State = location.State;
                serviceLocation.FullName = location.FullName;
                serviceLocation.LocationCode = location.LocationCode;
                serviceLocation.ZipCode = location.ZipCode;
            }

            return serviceLocation;
        }
    }
}
