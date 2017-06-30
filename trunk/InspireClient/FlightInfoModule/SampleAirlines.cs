using System.Collections.Generic;
using FlightInfoModule.Proxy;

namespace FlightInfoModule
{
    public static class SampleAirlines
    {
        public static List<Airline> GetAirlines()
        {
            var airlines = new List<Airline>();

            for (int i = 0; i < 30; i++)
            {
                airlines.Add(GetAirline());
            }
            return airlines;
        }

        private static Airline GetAirline()
        {
            return new Airline
            {
                ImageUrl = "pack://application:,,,/FlightInfoModule;component/Resources/Images/Inspire.png",
                Name = "Inspire Airlines"
            };
        }
    }
}
