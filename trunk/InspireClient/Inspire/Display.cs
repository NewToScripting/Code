using System;
using System.Windows;

namespace Inspire
{
    public class Display
    {
        public Display()
        {
            GUID = Guid.NewGuid().ToString();
        }

        public Display(string _hostname, bool _isPlayerCreated)
        {
            IsPlayerCreated = _isPlayerCreated;
            GUID = Guid.NewGuid().ToString();
            Domain = Environment.UserDomainName;
            DisplayName = System.Net.Dns.GetHostName();
            HostName = _hostname;
            HResolution = SystemParameters.PrimaryScreenWidth;
            VResolution = SystemParameters.PrimaryScreenHeight;
            OS = Environment.OSVersion.ToString();
            Orientation = SystemParameters.PrimaryScreenWidth > SystemParameters.PrimaryScreenHeight ? "Landscape" : "Portrait";
        }

        public Display(Display _display)
        {
            IsPlayerCreated = false;
            GUID = _display.GUID;
            Domain = _display.Domain;
            DisplayName = _display.DisplayName;
            HostName = _display.HostName;
            Location = _display.Location;
            HResolution = _display.HResolution;
            VResolution = _display.VResolution;
            ControllerType = _display.ControllerType;
            ControllerModel = _display.ControllerModel;
            MonitorModel = _display.MonitorModel;
            MonitorType = _display.MonitorType;
            OS = _display.OS;
            MonitorSize = _display.MonitorSize;
            SoftwareVersion = _display.SoftwareVersion;
            ActiveFlag = _display.ActiveFlag;
            LastCommunication = _display.LastCommunication;
            Group = _display.Group;
            Status = _display.Status;
            Orientation = _display.Orientation;
        }

        public string GUID { get; set; }
        public string DisplayName { get; set; }
        public string HostName { get; set; }
        public string Domain { get; set; }
        public string Location { get; set; }
        public double HResolution { get; set; }
        public double VResolution { get; set; }
        public string ControllerType { get; set; }
        public string ControllerModel { get; set; }
        public string MonitorModel { get; set; }
        public string MonitorType { get; set; }
        public string OS { get; set; }
        public string MonitorSize { get; set; }
        public string SoftwareVersion { get; set; }
        public DateTime LastCommunication { get; set; }
        public int ActiveFlag { get; set; }
        public string Group { get; set; }
        public string Property { get; set; }
        //public List<Schedule> Schedules { get; set; }
        public string Orientation { get; set; }
        public bool IsPlayerCreated { get; set; }
        public StatusEnum Status { get; set; }


        public enum OrientationEnum { Landscape, Portait, NotSet }
        public enum StatusEnum { Online, Offline, OutOfService, NotSet }

    }

    //public class DisplaysCollection
    //{
    //    //private List<Display> displayCollection = new List<Display>();

    //    public DisplaysCollection()
    //    {
    //        //Constructor
    //        Items = new List<Display>();

    //    }

    //    public List<Display> Items { get; set; }

    //}
}
