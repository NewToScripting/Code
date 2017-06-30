using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inspire
{
    public class DataField
    {
        public DataField(string _name, string _type)
        {
            Name = _name;
            Type = _type;
        }

        public string Name { get; set; }
        public string Type { get; set; } // TODO: Change to Enum
    }
}
