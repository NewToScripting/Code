using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlashModule
{
    public partial class FlashControl : UserControl
    {
        public int ControlWidth { get; set; }
        public int ControlHeight { get; set; }
        public string Url { get; set; }

        public FlashControl()
        {
            InitializeComponent();
        }

        public FlashControl(Uri uri, double width, double height)
        {
            InitializeComponent();
            ControlWidth = Convert.ToInt32(width);
            ControlHeight = Convert.ToInt32(height);
            Url = uri.ToString();
        }
    }
}
