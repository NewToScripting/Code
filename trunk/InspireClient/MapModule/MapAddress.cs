using System.ComponentModel;
using MapModule.MapsSearchService;

namespace MapModule
{
    public class MapAddress
    {
        public MapAddress(Address address)
        {
            Address = address.AddressLine;
            City = address.Locality;
            State = address.AdminDistrict;
            Country = address.CountryRegion;
            FormattedAddress = address.FormattedAddress;
            ZipCode = address.PostalCode;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string Address { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string FormattedAddress { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string City { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string State { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string ZipCode { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string Country { get; set; }
    }
}