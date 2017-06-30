using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using WeatherService.DataContracts; 

namespace WeatherService
{
public class WeatherProvider //: IWeatherDataProvider
{
    #region IWeatherDataProvider Members

    public List<Location> QueryLocationsV2(string query)
    {
        if (query == "" || query.Length < 2)
            return null;
        List<Location> results = new List<Location>();
        string searchUrl = "http://api.openweathermap.org/data/2.5/weather?q=" + query + "&mode=xml&units=imperial&APPID=476942e963ce68d59957a01e9f67781c";
        XmlTextReader reader = new XmlTextReader(searchUrl);
               
            while (reader.Read())
            {

                var location = new Location();

                //Get City
                reader.ReadToFollowing("city");
                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("city"))
                {
                    reader.MoveToAttribute("id");
                    location.LocationCode = reader.Value; 
                   
                    reader.MoveToAttribute("name");
                    location.City = reader.Value;                  

                }

                //Get Coord
                reader.ReadToFollowing("coord");
                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("coord"))
                {
                    double longitude;
                    reader.MoveToAttribute("lon");
                    double.TryParse(reader.Value, out longitude);
                    location.Longitude = longitude;

                    double latitude;
                    reader.MoveToAttribute("lat");
                    double.TryParse(reader.Value, out latitude);
                    location.Latitude = latitude;
                }

                //Get Country
                reader.ReadToFollowing("country");

                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("country"))
                {
                    location.Country = reader.ReadElementContentAsString();                   
                }

               

                //Add only if data is present
                if (location.Country != null && location.City != null) 
                { 
                    location.FullName = location.City + ", " + location.Country;
                    results.Add(location);
                }                
                
                             
                                
            }               

        return results;

    }
    
    public WeatherReport GetLatestWeatherReportV2(Location location, UnitsSystems us)
    {
        var result = new WeatherReport();               

        if (location.LocationCode != null && location.City != null)
        {
            result.Forecast = BuildForcast(location);           
            result.LatestWeather = GetCurrentWeather(location);        
            result.Location = location;
            result.UnitsSystem = us;
            result.SkyCode = result.LatestWeather.SkyCode;           
        }       

        return result;
    }

    private WeatherPoint GetCurrentWeather(Location location)
    {       
        //Initialize
        var result = new WeatherPoint();
       
        result.SkyCondition = new Sky();

        //Execute
        string searchUrl;

        if (!String.IsNullOrEmpty(location.LocationCode) && location.LocationCode != "0")
        {
            searchUrl = "http://api.openweathermap.org/data/2.5/weather?id=" + location.LocationCode + "&mode=xml&units=imperial&APPID=476942e963ce68d59957a01e9f67781c";
        }
        else
        {
            searchUrl = "http://api.openweathermap.org/data/2.5/weather?q=" + location.City + "&mode=xml&units=imperial&APPID=476942e963ce68d59957a01e9f67781c";
        }
       
        
        XmlTextReader reader = new XmlTextReader(searchUrl);
                
            while (reader.Read())
            {

                double temperature = 0;
                double humidity = 0;
                string skyCondition = String.Empty;
                string skyImage = String.Empty;
                //result.Precipitation = ??;            
                result.UnitsSystem = UnitsSystems.Imperial;
                result.Time = DateTime.Now;  
                

                //Get Temp
                reader.ReadToFollowing("temperature");
                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("temperature"))
                {
                    reader.MoveToAttribute("value");
                    double.TryParse(reader.Value, out temperature);                
                    result.Temperature = temperature;
                    result.FeelsLike = temperature;
                }

                //Get Humidity
                reader.ReadToFollowing("humidity");
                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("humidity"))
                {
                    reader.MoveToAttribute("value");
                    double.TryParse(reader.Value, out humidity);                
                    result.Humidity = humidity;
                }

                //Get Humidity
                reader.ReadToFollowing("weather");
                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("weather"))
                {
                    reader.MoveToAttribute("value");
                    skyCondition = reader.Value;
                    result.SkyCondition.SkyCondition = skyCondition;

                    reader.MoveToAttribute("icon");
                    skyImage = reader.Value;
                    //result.SkyCondition.SkyImage = skyImage;                   
                    result.SkyCondition.SkyImage = "pack://application:,,,/WeatherModule;component/Resources/Images/" + ImageTranslator.Translate(skyImage) + ".png"; //feedSkyImage;
                    
                    //Add Image code to response
                    string tempString = ImageTranslator.Translate(skyImage);
                    tempString = tempString.Replace("n", String.Empty);
                    int code;
                    int.TryParse(tempString, out code);
                    result.SkyCode = code;
                }             
                
            }          

        
        return result;

    }

    private List<WeatherRange> BuildForcast(Location location)
    {       
        var forcasts = new List<WeatherRange>();

        string feedUrl;

        if (!String.IsNullOrEmpty(location.LocationCode) && location.LocationCode != "0")
        {
            feedUrl = "http://api.openweathermap.org/data/2.5/forecast/daily?id=" + location.LocationCode + "&mode=xml&units=imperial&cnt=7&APPID=476942e963ce68d59957a01e9f67781c";
        }
        else
        {
            feedUrl = "http://api.openweathermap.org/data/2.5/forecast/daily?q=" + location.City + "&mode=xml&units=imperial&cnt=7&APPID=476942e963ce68d59957a01e9f67781c";
        }
       
        XmlTextReader reader = new XmlTextReader(feedUrl);

        while (reader.Read())
        {
            //reader.ReadToFollowing("forecast");

            if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("time"))
            {  
                double minTemp = 0;
                double maxTemp = 0;             
                double precip = 0;                
                double humidity = 0;
                string iconCode = String.Empty;
                string iconName = String.Empty;
                DateTime date;

                var forcast = new WeatherRange();

                //Get Date
                reader.MoveToAttribute("day");                
                DateTime.TryParse(reader.Value, out date);
                
                //Get Symbol and Image
                reader.ReadToFollowing("symbol");
                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("symbol"))
                {
                    reader.MoveToAttribute("var");
                    iconCode = reader.Value;

                    reader.MoveToAttribute("name");
                    iconName = reader.Value;

                }

                //Get Precip
                reader.ReadToFollowing("precipitation");
                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("precipitation"))
                {
                    reader.MoveToAttribute("value");
                    double.TryParse(reader.Value, out precip);

                }

                //Get Temp
                reader.ReadToFollowing("temperature");

                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("temperature"))
                {    
                    reader.MoveToAttribute("min");
                    double.TryParse(reader.Value, out minTemp);

                    reader.MoveToAttribute("max");
                    double.TryParse(reader.Value, out maxTemp);
                   
                }

                //Get Humidity
                reader.ReadToFollowing("humidity");

                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("humidity"))
                {
                    reader.MoveToAttribute("value");
                    double.TryParse(reader.Value, out humidity);                 

                }

                forcast.UnitsSystem = UnitsSystems.Imperial;
                forcast.HighTemperature = maxTemp;
                forcast.LowTemperature = minTemp;
                forcast.Precipitation = precip;
                forcast.Humidity = humidity;
                forcast.SkyCondition = new Sky();
                forcast.SkyCondition.SkyCondition = iconName;
                forcast.SkyCondition.SkyImage = "pack://application:,,,/WeatherModule;component/Resources/Images/" + ImageTranslator.Translate(iconCode) + ".png"; //feedSkyImage;
                forcast.StartTime = date;
                forcast.EndTime = date.AddHours(23).AddMinutes(59).AddSeconds(59);    
               
                //forcast.StartTime = ??;
                //forcast.EndTime = ??;

                forcasts.Add(forcast);
            }           

        }

        return forcasts;
    }



    //public List<Location> QueryLocations(string query)
    //{
    //    if (query == "" || query.Length < 2)
    //        return null;
    //    List<Location> results = new List<Location>();
    //    string searchUrl = "http://weather.service.msn.com/find.aspx?outputview=search&src=vista&weasearchstr=" + query;
    //    XmlTextReader reader = new XmlTextReader(searchUrl);

    //    try
    //    {
    //        while (reader.Read())
    //        {
    //            reader.ReadToFollowing("weather");

    //            if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("weather"))
    //            {
    //                string weatherLocationName, city, state = "", country = "", locationCode;
    //                int zipcode;
    //                double longitude, latitude;

    //                reader.MoveToAttribute("weatherlocationname");
    //                weatherLocationName = reader.Value;

    //                reader.MoveToAttribute("zipcode");
    //                bool isZipCodeValid = int.TryParse(reader.Value, out zipcode);

    //                reader.MoveToAttribute("lon");
    //                bool isLongitudeValid = double.TryParse(reader.Value, out longitude);

    //                reader.MoveToAttribute("lat");
    //                bool isLatitudeValid = double.TryParse(reader.Value, out latitude);

    //                //reader.MoveToAttribute("searchlocation");
    //                char[] splitter = { ',' };
    //                string[] cityAndCountry = weatherLocationName.Split(splitter);
    //                for (int i = 0; i < cityAndCountry.Length; i++)
    //                {
    //                    if (cityAndCountry.Length > 1)
    //                        if (cityAndCountry[i][0] == ' ')
    //                            cityAndCountry[i] = cityAndCountry[i].Substring(1);
    //                }
    //                city = cityAndCountry[0];
    //                if (cityAndCountry.Length == 2)
    //                {
    //                    country = cityAndCountry[1];
    //                }
    //                else if (cityAndCountry.Length == 3)
    //                {
    //                    state = cityAndCountry[1];
    //                    country = cityAndCountry[2];
    //                }

    //                // Sometimes, "weatherfullname" is different than "searchlocation"
    //                //  this happens when the original location doesn't have weather station
    //                //  and the station at the nearest place is used instead.
    //                // In this case, "searchlocation" does not hold the actual city
    //                //  or state names, we have to use those in "weatherfullname"

    //                //double searchDistance = 0.0;
    //                //double.TryParse(reader.MoveToAttribute("searchdistance"), out searchDistance);
    //                //if (searchDistance > 0.0)
    //                //{
    //                //    reader.MoveToAttribute("searchlocation");
    //                //    string[] cityAndCountry2 = weatherLocationName.Split(splitter);
    //                //    for (int i = 0; i < cityAndCountry2.Length; i++)
    //                //        if (cityAndCountry2[i][0] == ' ')
    //                //            cityAndCountry2[i] = cityAndCountry2[i].Substring(1);
    //                //    city = cityAndCountry2[0];
    //                //    if (cityAndCountry2.Length == 2)
    //                //    {
    //                //        country = cityAndCountry2[1];
    //                //    }
    //                //    else if (cityAndCountry2.Length == 3)
    //                //    {
    //                //        state = cityAndCountry2[1];
    //                //        country = cityAndCountry2[2];
    //                //    }
    //                //}

    //                reader.MoveToAttribute("weatherlocationcode");
    //                locationCode = reader.Value;

    //                Location location = new Location();
    //                location.City = city;
    //                location.Country = country;
    //                location.FullName = weatherLocationName;
    //                location.Latitude = (isLatitudeValid) ? latitude : (double?)null;
    //                location.Longitude = (isLongitudeValid) ? longitude : (double?)null;
    //                location.State = state;
    //                location.ZipCode = (isZipCodeValid) ? zipcode : (int?)null;
    //                location.LocationCode = locationCode;

    //                results.Add(location);
    //            }
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        //gulp
    //    }

    //    return results;

    //}

        //public WeatherReport GetLatestWeatherReport(Location location, UnitsSystems us)
        //{
        //    WeatherReport result = new WeatherReport();
           
        //    //string feedUrl = "http://weather.service.msn.com/data.aspx?src=vista&wealocations=" + location.LocationCode;
        //    //XmlTextReader reader = new XmlTextReader(feedUrl);
        //    ////string skyImageRelativeUrl = "";
        //    ////string skyImageRelativeUrl = "Images/";
        //    //while (reader.Read())
        //    //{
        //    //    if (reader.NodeType == XmlNodeType.Element)
        //    //    {
        //    //        if (reader.Name.Equals("forecast"))
        //    //        {
        //    //            WeatherRange forecast = new WeatherRange();
        //    //            forecast.UnitsSystem = UnitsSystems.Imperial;
        //    //            double high, low, precip;

        //    //            reader.MoveToAttribute("high");
        //    //            double.TryParse(reader.Value, out high);
        //    //            forecast.HighTemperature = high;

        //    //            reader.MoveToAttribute("low");
        //    //            double.TryParse(reader.Value, out low);
        //    //            forecast.LowTemperature = low;

        //    //            // There is no humidity for forecasts in MSN weather feed
        //    //            forecast.Humidity = null;

        //    //            reader.MoveToAttribute("precip");
        //    //            double.TryParse(reader.Value, out precip);
        //    //            forecast.Precipitation = precip;

        //    //            reader.MoveToAttribute("skytextday");
        //    //            forecast.SkyCondition.SkyCondition = reader.Value;
        //    //            reader.MoveToAttribute("skycodeday");
        //    //            //forecast.SkyCondition.SkyImage = new Image();
        //    //            // BitmapImage feedSkyImage = new BitmapImage(new Uri(skyImageRelativeUrl + reader.Value + ".png", UriKind.RelativeOrAbsolute));
        //    //            forecast.SkyCondition.SkyImage = "pack://application:,,,/WeatherModule;component/Resources/Images/" + reader.Value + ".png"; //feedSkyImage;

        //    //            //reader.MoveToAttribute("winddisplay");
        //    //            //char[] splitter = { ' ' };
        //    //            //string[] windInfo = reader.Value.Split(splitter);
        //    //            //forecast.WindVector.Speed = double.Parse(windInfo[0]);
        //    //            //forecast.WindVector.Direction = (WindDirections)Enum.Parse(typeof(WindDirections), windInfo[2]);

        //    //            reader.MoveToAttribute("date");
        //    //            char[] splitter = { '-' };
        //    //            string[] yearMonthDay = reader.Value.Split(splitter);
        //    //            int day, month, year;
        //    //            int.TryParse(yearMonthDay[0], out year);
        //    //            int.TryParse(yearMonthDay[1], out month);
        //    //            int.TryParse(yearMonthDay[2], out day);
        //    //            DateTime start = new DateTime(year, month, day, 0, 0, 0);
        //    //            DateTime end = new DateTime(year, month, day, 23, 59, 59);
        //    //            forecast.StartTime = start;
        //    //            forecast.EndTime = end;

        //    //            result.Forecast.Add(forecast);
        //    //        }
        //    //        else if (reader.Name.Equals("current"))
        //    //        {
        //    //            WeatherPoint current = new WeatherPoint();
        //    //            current.UnitsSystem = UnitsSystems.Imperial;
        //    //            double temperature, feelsLike, humidity, precip;

        //    //            reader.MoveToAttribute("temperature");
        //    //            double.TryParse(reader.Value, out temperature);
        //    //            current.Temperature = temperature;

        //    //            reader.MoveToAttribute("feelslike");
        //    //            double.TryParse(reader.Value, out feelsLike);
        //    //            current.FeelsLike = feelsLike;

        //    //            reader.MoveToAttribute("humidity");
        //    //            double.TryParse(reader.Value, out humidity);
        //    //            current.Humidity = humidity;

        //    //            reader.MoveToAttribute("precip");
        //    //            double.TryParse(reader.Value, out precip);
        //    //            current.Precipitation = precip;

        //    //            reader.MoveToAttribute("skytext");
        //    //            current.SkyCondition.SkyCondition = reader.Value;
        //    //            reader.MoveToAttribute("skycode");
        //    //            int skyCode;
        //    //            int.TryParse(reader.Value, out skyCode);
        //    //            result.SkyCode = skyCode;
        //    //            //current.SkyCondition.SkyImage = new Image();
        //    //            //BitmapImage feedSkyImage = new BitmapImage(new Uri(skyImageRelativeUrl + reader.Value + ".png", UriKind.Relative));
        //    //            current.SkyCondition.SkyImage = "pack://application:,,,/WeatherModule;component/Resources/Images/" + reader.Value + ".png";

        //    //            reader.MoveToAttribute("winddisplay");
        //    //            char[] splitter = { ' ' };
        //    //            string[] windInfo = reader.Value.Split(splitter);
        //    //            double speed;
        //    //            double.TryParse(windInfo[0], out speed);
        //    //            current.WindVector.Speed = speed;
        //    //            if (windInfo.Length == 3)
        //    //                //current.WindVector.Direction = (WindDirections)Enum.Parse(typeof(WindDirections), windInfo[2]);

        //    //                reader.MoveToAttribute("observationtime");
        //    //            splitter[0] = ':';
        //    //            string[] hourMinuteSecond = reader.Value.Split(splitter);
        //    //            int hour, minute, second;
        //    //            int.TryParse(hourMinuteSecond[0], out hour);
        //    //            int.TryParse(hourMinuteSecond[1], out minute);
        //    //            int.TryParse(hourMinuteSecond[2], out second);
        //    //            reader.MoveToAttribute("date");
        //    //            splitter[0] = '-';
        //    //            string[] yearMonthDay = reader.Value.Split(splitter);
        //    //            int year, month, day;
        //    //            int.TryParse(yearMonthDay[0], out year);
        //    //            int.TryParse(yearMonthDay[1], out month);
        //    //            int.TryParse(yearMonthDay[2], out day);
        //    //            DateTime observationTime = new DateTime(year, month, day, hour, minute, second);
        //    //            current.Time = observationTime;

        //    //            result.LatestWeather = current;
        //    //        }
        //    //        // Uncomment this code to use feed's image
        //    //        //else if (reader.Name.Equals("weather"))
        //    //        //{
        //    //        //    reader.MoveToAttribute("imagerelativeurl");
        //    //        //    skyImageRelativeUrl = reader.Value;
        //    //        //}
        //    //    }
        //    //}
        //    //result.Location = location;

        //    //if (UnitsSystems.Metric == us)
        //    //{
        //    //    result = convertToMetric(result);
        //    //}

        //    return result;
        //}

        #endregion

        //private WeatherReport convertToMetric(WeatherReport result)
        //{
        //    result.LatestWeather.Temperature = 5.0 / 9.0 * (result.LatestWeather.Temperature - 32.0);
        //    foreach (WeatherRange wr in result.Forecast)
        //    {
        //        wr.HighTemperature = 5.0 / 9.0 * (wr.HighTemperature - 32.0);
        //        wr.LowTemperature = 5.0 / 9.0 * (wr.LowTemperature - 32.0);
        //    }
        //    return result;
        //}
    }
}

