using System.Collections.Generic;
using FlightInfoModule.Proxy;

namespace FlightInfoModule
{
    public interface IFlightPanel
    {
        TemplatedFlight FlightTemplate { get; set; }
        string PanelAnimation { get; set; }
        void RefreshCollection(bool changeItem, bool updateCollection);
        void RefreshItemsTemplate();
        void ReloadFlightsNow(List<Flight> flights);
    }
}