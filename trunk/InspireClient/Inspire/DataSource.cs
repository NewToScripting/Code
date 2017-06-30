using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inspire
{
    public class DataSource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public List<DataField> DataFields { get; set; }

    }
}
