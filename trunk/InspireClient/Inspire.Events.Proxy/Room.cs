using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Inspire.Events.Proxy
{


    public class Room
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Alias> Aliases { get; set; }

    }

    public class Alias
    {
        public string Guid { get; set; }
        public string Value { get; set; }
        public string RoomID { get; set; }

    }
}
