using System;

namespace FlightInfoModule.Proxy
{
    public class FlightRequest
    {
        public string AirportCodeOrGuid { get; set; }

        public string FID { get; set; }

        public string CustomerGuid { get; set; }

        public string AirlineCode { get; set; }

        public string FyteType { get; set; }

        public bool ShowNameInsteadOfImage { get; set; }

        public TimeSpan? LookBehindCurrentTime { get; set; }

        public TimeSpan? LookAheadCurrentTime { get; set; }

        public string IpAddress { get; set; }

        public string DnsHostName { get; set; }

        public FlightRequest()
        {
            AirportCodeOrGuid = string.Empty;
            FID = string.Empty;
        }
    }
}
