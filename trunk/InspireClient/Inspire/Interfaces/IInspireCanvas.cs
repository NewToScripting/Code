using System.Collections.Generic;
using System.Windows.Controls;
using Inspire.MediaObjects;

namespace Inspire.Interfaces
{
    public interface IInspireCanvas
    {
        IEnumerable<ContentControl> GetDesignItems();
    }
}
