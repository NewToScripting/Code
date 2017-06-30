
  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Inspire.Display.Service.ServerCommunication
{
    public class ProxySlideFile
    {      
        public string SlideFileID { get; set; }      
        public int SlideFileSize { get; set; }       
        public Stream SlideFileStream { get; set; }
    }
}
