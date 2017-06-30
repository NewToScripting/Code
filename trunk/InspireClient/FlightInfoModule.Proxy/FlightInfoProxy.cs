using System.Collections.Generic;
using System.Linq;
using System.Net;
using FlightInfoModule.Proxy.FlightService;
using System;

namespace FlightInfoModule.Proxy
{
    public static class FlightInfoProxy
    {
        public static List<Flight> GetFlights(FlightRequest flightRequest)
        {
            flightRequest.DnsHostName = Dns.GetHostName();

            var ipAddress = Dns.GetHostAddresses(flightRequest.DnsHostName);

            flightRequest.IpAddress = ipAddress.Aggregate(string.Empty, (current, address) => current + address + ".");

            try
          {
                var flightServiceClient = new FlightInfoServiceClient("FlightInfoServiceEndpoint");//"FlightServiceEndpoint");
                flightServiceClient.Endpoint.Address = ServerSettings.GetFlightInfoServiceEndpoint();

                FlightService.Flight[] flights = flightServiceClient.GetFlights(ConvertToServiceFlightRequest(flightRequest));

                flightServiceClient.Close();

                return ConvertToFlights(flights);
            }
            catch (Exception e)
            {
                return new List<Flight>();
            }
        }

        private static List<Flight> ConvertToFlights(FlightService.Flight[] serviceFlights)
        {
            var flights = new List<Flight>();

            try
            {
                if (serviceFlights != null)
                {
                    flights = serviceFlights.Select(ConvertToFlight).ToList();
                }
            }
            catch { }

            return flights;
        }

        private static Flight ConvertToFlight(FlightService.Flight serviceFlight)
        {
            Flight flight = null;
            if (serviceFlight != null)
            {
                flight = new Flight();
                flight.ActualArrivalDeparture = serviceFlight.ActualArrivalDeparture;
                flight.Airline = ConvertToAirline(serviceFlight.Airline);
                flight.DelayMinutes = serviceFlight.DelayMinutes;
                flight.Destination = ConvertToAirport(serviceFlight.Destination);
                flight.EstimatedArrivalDeparture = serviceFlight.EstimatedArrivalDeparture;
                flight.FlightNumber = serviceFlight.FlightNumber;
                flight.FlyteType = ConvertToFlyteType(serviceFlight.FlyteType);
                flight.Gate = serviceFlight.Gate;
                flight.Origin = ConvertToAirport(serviceFlight.Origin);
                flight.ScheduleArrivalDeparture = serviceFlight.ScheduleArrivalDeparture;
                flight.Status = serviceFlight.Status;
                flight.StatusCode = serviceFlight.StatusCode;
            }
            return flight;
        }

        private static Flight.FlightTypes ConvertToFlyteType(FlightService.Flight.FlightTypes serviceFlightTypes)
        {
            if (serviceFlightTypes == FlightService.Flight.FlightTypes.Arrival)
                return Flight.FlightTypes.Arrival;
            return Flight.FlightTypes.Departure;
        }

        private static Airport ConvertToAirport(FlightService.Airport serviceAirport)
        {
            Airport airport = null;
            if (serviceAirport != null)
            {
                airport = new Airport();
                airport.AirportCode = serviceAirport.AirportCode;
                airport.City = serviceAirport.City;
                airport.CountryCode = serviceAirport.CountryCode;
                airport.Description = serviceAirport.Description;
                airport.FAACode = serviceAirport.FAACode;
                airport.IATACode = serviceAirport.IATACode;
                airport.ICACode = serviceAirport.ICACode;
                airport.IsMajorAirport = serviceAirport.IsMajorAirport;
                airport.Latitude = serviceAirport.Latitude;
                airport.Longitude = serviceAirport.Longitude;
                airport.Name = serviceAirport.Name;
                airport.PostalCode = serviceAirport.PostalCode;
                airport.State = serviceAirport.State;
                airport.WeatherStationCode = serviceAirport.WeatherStationCode;
                airport.WeatherZone = serviceAirport.WeatherZone;
            }
            return airport;
        }

        private static Airline ConvertToAirline(FlightService.Airline serviceAirline)
        {
            Airline airline = null;
            if (serviceAirline != null)
            {
                airline = new Airline();
                airline.AirlineCode = serviceAirline.AirlineCode;
                airline.Description = serviceAirline.Description;
                airline.IATACode = serviceAirline.IATACode;
                airline.ICACode = serviceAirline.ICACode;
                airline.ImageUrl = serviceAirline.ImageUrl;
                airline.Name = serviceAirline.Name;
            }
            return airline;
        }

        private static FlightService.FlightRequest ConvertToServiceFlightRequest(FlightRequest flightRequest)
        {
            FlightService.FlightRequest serviceFlightRequest = null;
            if (flightRequest != null)
            {
                serviceFlightRequest = new FlightService.FlightRequest();
                serviceFlightRequest.DnsHostName = flightRequest.DnsHostName;
                serviceFlightRequest.ShowNameInsteadOfImage = flightRequest.ShowNameInsteadOfImage;
                serviceFlightRequest.IpAddress = flightRequest.IpAddress;
                serviceFlightRequest.AirlineCode = flightRequest.AirlineCode;
                serviceFlightRequest.CustomerGuid = flightRequest.CustomerGuid;
                serviceFlightRequest.AirportCode = flightRequest.AirportCodeOrGuid;
                serviceFlightRequest.FID = flightRequest.FID;
                serviceFlightRequest.FyteType = flightRequest.FyteType;
                serviceFlightRequest.LookAheadCurrentTime = flightRequest.LookAheadCurrentTime;
                serviceFlightRequest.LookBehindCurrentTime = flightRequest.LookBehindCurrentTime;
            }
            return serviceFlightRequest;
        }

        public static List<Airline> GetAirlines(FlightRequest flightRequest)
        {
            flightRequest.DnsHostName = Dns.GetHostName();
            var ipAddress = Dns.GetHostAddresses(flightRequest.DnsHostName);

            flightRequest.IpAddress = ipAddress.Aggregate(string.Empty, (current, address) => current + address + ".");

            try
            {
                var flightServiceClient = new FlightInfoServiceClient("FlightInfoServiceEndpoint");
                flightServiceClient.Endpoint.Address = ServerSettings.GetFlightInfoServiceEndpoint();

                var airlines = flightServiceClient.GetAirlines(ConvertToServiceFlightRequest(flightRequest));

                flightServiceClient.Close();

                return ConvertToAirlines(airlines);
            }
            catch
            {
                return null;
            }
        }

        private static List<Airline> ConvertToAirlines(FlightService.Airline[] airlines)
        {
            List<Airline> _airlines = null;

            try
            {
                if (airlines != null)
                {
                    _airlines = airlines.Select(ConvertToAirline).ToList();
                }

            }
            catch { }

            return _airlines;
        }

        public static List<Airport> GetAirports(FlightRequest flightRequest)
        {
            try
            {
                flightRequest.DnsHostName = Dns.GetHostName();
                var ipAddress = Dns.GetHostAddresses(flightRequest.DnsHostName);

                flightRequest.IpAddress = ipAddress.Aggregate(string.Empty,
                                                              (current, address) => current + address + ".");

                var flightServiceClient = new FlightInfoServiceClient("FlightInfoServiceEndpoint");
                flightServiceClient.Endpoint.Address = ServerSettings.GetFlightInfoServiceEndpoint();

                var airports = flightServiceClient.GetAirports(ConvertToServiceFlightRequest(flightRequest));

                flightServiceClient.Close();

                return airports.Select(ConvertToAirport).ToList();

            }
            catch { }

            return null;
        }
    }
}