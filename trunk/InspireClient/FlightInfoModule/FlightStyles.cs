using System.Collections.Generic;

namespace FlightInfoModule
{
    public class FlightStyles
    {
        private static readonly List<string> _flightStyles;

        static FlightStyles()
        {
            _flightStyles = new List<string>();
            _flightStyles.Add("Standard");
            _flightStyles.Add("Bubbled");
            _flightStyles.Add("Standard_City_First");
            _flightStyles.Add("Bubbled_City_First");
            _flightStyles.Add("Standard_City_First_With_Gate");
            _flightStyles.Add("Bubbled_City_First_With_Gate");
        }

        public static List<string> GetFlightStyles
        {
            get { return _flightStyles; }
        }
    }
}
