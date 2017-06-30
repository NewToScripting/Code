using System;
using System.Collections.Generic;

namespace FlightInfoModule.Proxy
{
    public class Flight
    {
        public enum FlightTypes
        {
            Arrival,
            Departure
        }

        public FlightTypes FlyteType { get; set; }

        public string FlightNumber { get; set; }

        public string Status { get; set; }

        public string StatusCode { get; set; }

        public string Gate { get; set; }

        public DateTime? ScheduleArrivalDeparture { get; set; }

        public DateTime? EstimatedArrivalDeparture { get; set; }

        public DateTime? ActualArrivalDeparture { get; set; }

        public int? DelayMinutes { get; set; }

        public Airport Origin { get; set; }

        public Airport Destination { get; set; }

        public Airline Airline { get; set; }

    }

    public class FlightCollection : List<Flight>
    {
        
    }
}
