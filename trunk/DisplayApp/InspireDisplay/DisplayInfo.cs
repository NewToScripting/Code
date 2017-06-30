using System.Windows.Forms;
using Inspire;

namespace InspireDisplay
{
    class DisplayInfo
    {
        public Display Data { get; set; }

        public DisplayInfo(string displayGuid)
        {
            displayinfo = new Display {GUID = displayGuid};
            InitializeComponent();
        }

        public DisplayInfo(Display info)
        {
            displayinfo = new Display(info);

        }

        private void InitializeComponent()
        {
            //Screen _screen = Screen.PrimaryScreen;

            displayinfo.HostName = System.Net.Dns.GetHostName();
            displayinfo.VResolution = System.Windows.SystemParameters.PrimaryScreenHeight;
            displayinfo.HResolution = System.Windows.SystemParameters.PrimaryScreenWidth;
            displayinfo.Orientation = System.Windows.SystemParameters.PrimaryScreenWidth > System.Windows.SystemParameters.PrimaryScreenHeight ? Orientation.Horizontal.ToString() : Orientation.Vertical.ToString();

        }

        #region Private Variables

        private Display displayinfo;

        #endregion

    }
}
