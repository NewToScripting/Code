using System;
using System.Windows.Controls;

namespace Inspire.MediaObjects
{
    public class MediaModule
    {
        public bool IsPanelModule { get; set; }

        public Image ModuleImage { get; set; }

        public string Name { get; set; }

        public string Assembly { get; set; }

        public MediaType Type { get; set; }

        public bool IsEditable { get; set; }

        public bool IsApp { get; set; }
    }
}
