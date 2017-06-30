namespace FlightInfoModule.Proxy
{
    public class Airport
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string AirportCode { get; set; }

        public string FAACode { get; set; }

        public string IATACode { get; set; }

        public string ICACode { get; set; }

        public string CountryCode { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string WeatherStationCode { get; set; }

        public string WeatherZone { get; set; }

        public bool? IsMajorAirport { get; set; }
    }
}
