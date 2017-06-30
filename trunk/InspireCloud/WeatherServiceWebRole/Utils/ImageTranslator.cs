using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherService
{
    public static class ImageTranslator
    {
        public static string Translate(string input)
        {

            switch(input)
            {
                case "01d" : return "31"; //clear/sunny day
                case "01n": return "31n"; //clear night
                case "02d": return "34"; //partly cloudy day
                case "02n": return "34n"; //partly cloudy night
                case "03d": return "26"; //cloudy day
                case "03n": return "26n"; //cloudy night
                case "04d": return "27"; //fully cloudy day
                case "04n": return "27n"; //fully cloudy night
                case "09d": return "35"; //shower rainy day
                case "09n": return "35n"; //shower rainy night
                case "10d": return "35"; //rainy day
                case "10n": return "35n"; //rainy night
                case "11d": return "38"; //tstorm day
                case "11n": return "38n"; //tstorm night
                case "13d": return "5"; //snow day
                case "13n": return "5n"; //snow night
                case "50d": return "21"; //misty day
                case "50n": return "21"; //misty night
                default: return "31";
            }           
            
        }
    }
}