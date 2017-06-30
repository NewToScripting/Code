using System.ComponentModel;

namespace Inspire.Events.Proxy
{
    public class Direction : INotifyPropertyChanged
    {
        private string directionImageWebPath;


        public string Guid { get; set; }
        public string DisplayID { get; set; }
        public string RoomID { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }
        public string DirectionImageWebPath
        {
            get { return directionImageWebPath; }
            set
            {
                if (value != directionImageWebPath)
                {
                    directionImageWebPath = value;
                    OnPropertyChanged("DirectionImageWebPath");
                }
            }
        }
        public string DirectionImageID { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    //public class DirectionalImage
    //{
    //    public string Guid { get; set; }
    //    public string FileExtention { get; set; }
    //    public string Description { get; set; }
    //    public string WebPath { get; set; }
    //    public EventImageType Type { get; set; }
    //}

    //public enum EventImageType
    //{
    //    Directional=1, Group=2
    //};
}


