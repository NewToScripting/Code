using System.Collections.ObjectModel;
using System.Linq;

namespace Inspire.Common.TreeViewModel
{
    public class CorporationViewModel
    {
        readonly ReadOnlyCollection<PropertyViewModel> _displayProperties;

        public CorporationViewModel(DisplayProperty[] displayProperties)
        {
            _displayProperties = new ReadOnlyCollection<PropertyViewModel>(
                (from displayProperty in displayProperties
                 select new PropertyViewModel(displayProperty))
                .ToList());
        }

        public ReadOnlyCollection<PropertyViewModel> DisplayProperties
        {
            get { return _displayProperties; }
        }
    }
}
