using System;
using System.Collections.Generic;
using FlightInfoModule.Proxy;

namespace FlightInfoModule
{
    public static class SampleFlights
    {
        static SampleFlights()
        {
            _sampleCities = new List<string>
                                {
                                    "Atlanta",
                                    "Atlanta",
                                    "Atlanta",
                                    "Austin",
                                    "Boston",
                                    "Charleston",
                                    "Charolotte",
                                    "Charolotte",
                                    "Chicago",
                                    "Chicago",
                                    "Chicago",
                                    "Dallas",
                                    "Dallas",
                                    "Denver",
                                    "Denver",
                                    "Denver",
                                    "Houston",
                                    "Houston",
                                    "Fargo",
                                    "Nashville",
                                    "New York",
                                    "New York",
                                    "San Diego",
                                    "Tulsa"
                                };
        }

        public static List<Flight> GetFlights(FlightRequest flightRequest)
        {
            var flights = new List<Flight>();

            for (int i = 0; i < 23; i++)
            {
                Random random = new Random();
                var flight = GetFlight(i, random.Next(1000, 9999));
                if (flightRequest.ShowNameInsteadOfImage)
                    flight.Airline.ImageUrl = string.Empty;
                flights.Add(flight);
            }
            return flights;
        }

        private static readonly List<string> _sampleCities;

        private static Flight GetFlight(int hour, int flightNumber)
        {
            return new Flight
            {
                ActualArrivalDeparture =
                    new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                                 hour, 15, 0),
                Airline = new Airline
                {
                    ImageUrl = "pack://application:,,,/FlightInfoModule;component/Resources/Images/Inspire.png",
                    Name = "Inspire Airlines"
                },
                DelayMinutes = 15,
                Destination = new Airport
                {
                    AirportCode = "TPA",
                    City = _sampleCities[hour],
                    CountryCode = "US",
                    Name = "Tampa International Airport",
                    State = "Florida"
                },
                EstimatedArrivalDeparture = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                                                         hour, 15, 0),
                FlightNumber = "F" + flightNumber,
                FlyteType = Flight.FlightTypes.Departure,
                Gate = "34B",
                ScheduleArrivalDeparture = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                                                        hour, 15, 0),
                Status = "On Time",
                StatusCode = "On Time"
            };
        }
    }
}
