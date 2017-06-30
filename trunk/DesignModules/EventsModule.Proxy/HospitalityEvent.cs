using System;
using System.ComponentModel;

namespace Inspire.Events.Proxy
{
    public class HospitalityEvent : INotifyPropertyChanged
    {
        public string EventGUID
        {
            get { return eventGUID; }
            set
            {
                eventGUID = value;
                OnPropertyChanged("EventGUID");
            }
        }
        public string EventDefinitionGUID
        {
            get { return eventDefinitionGUID; }
            set
            {
                eventDefinitionGUID = value;
                OnPropertyChanged("EventDefinitionGUID");
            }
        }
        public string HotelName
        {
            get { return hotelName; }
            set
            {
                hotelName = value;
                OnPropertyChanged("HotelName");
            }
        }
        public string GroupName
        {
            get { return groupName; }
            set
            {
                groupName = value;
                OnPropertyChanged("GroupName");
            }
        }
        public string GroupLogo
        {
            get { return groupLogo; }
            set
            {
                groupLogo = value;
                OnPropertyChanged("GroupLogo");
            }
        }

        public string MeetingName
        {
            get { return meetingName; }
            set
            {
                meetingName = value;
                OnPropertyChanged("MeetingName");
            }
        }
        public string MeetingLogo
        {
            get { return meetingLogo; }
            set
            {
                meetingLogo = value;
                OnPropertyChanged("MeetingLogo");
            }
        }
        public string MeetingPostAs
        {
            get { return meetingPostAs; }
            set
            {
                meetingPostAs = value;
                OnPropertyChanged("MeetingPostAs");
            }
        }
        public string MeetingID
        {
            get { return meetingID; }
            set
            {
                meetingID = value;
                OnPropertyChanged("MeetingID");
            }
        }
        public string MeetingType
        {
            get { return meetingType; }
            set
            {
                meetingType = value;
                OnPropertyChanged("MeetingType");
            }
        }
        public string MeetingRoomID
        {
            get { return meetingRoomID; }
            set
            {
                meetingRoomID = value;
                OnPropertyChanged("MeetingRoomID");
            }
        }
        public string MeetingRoomName
        {
            get { return meetingRoomName; }
            set
            {
                meetingRoomName = value;
                OnPropertyChanged("MeetingRoomName");
            }
        }
        public string MeetingRoomLogo
        {
            get { return meetingRoomLogo; }
            set
            {
                meetingRoomLogo = value;
                OnPropertyChanged("MeetingRoomLogo");
            }
        }
        public string HostEventIdentifier
        {
            get { return hostEventIdentifier; }
            set
            {
                hostEventIdentifier = value;
                OnPropertyChanged("HostEventIdentifier");
            }
        }
        public bool? Postable
        { 
            get { return postable; }
            set
            {
                postable = value;
                OnPropertyChanged("Postable");
            }
        }
        public bool? Exhibit 
        { 
                get { return exhibit; }
            set
            {
                exhibit = value;
                OnPropertyChanged("Exhibit");
            }
        }
        public string BackupMeetingRoomSpace
        {
            get { return backupMeetingRoomSpace; }
            set
            {
                backupMeetingRoomSpace = value;
                OnPropertyChanged("BackupMeetingRoomSpace");
            }
        }
        public string OverflowMeetingRoomSpace
        {
            get { return overflowMeetingRoomSpace; }
            set
            {
                overflowMeetingRoomSpace = value;
                OnPropertyChanged("OverflowMeetingRoomSpace");
            }
        }
        //public DateTime? Date { get; set; }
        //public DateTime? StartDate { get; set; }
        //public DateTime? EndDate { get; set; }
        public DateTime? StartTime 
        { get { return startTime; }
            set
            {
                startTime = value;
                OnPropertyChanged("StartTime");
            } 
        }
        public DateTime? EndTime { get { return endTime; }
            set
            {
                endTime = value;
                OnPropertyChanged("EndTime");
            } }
        public bool? IsVisible { get { return isVisible; }
            set
            {
                isVisible = value;
                OnPropertyChanged("IsVisible");
            } }
        public string Alias 
        {
            get { return alias; }
            set
            {
                alias = value;
                OnPropertyChanged("Alias");
            }
        }
        public string DirectionalImage
        {
            get { return directionalImage; }
            set
            {
                directionalImage = value;
                OnPropertyChanged("DirectionalImage");
            } }

        private string eventGUID;
        private string eventDefinitionGUID;
        private string hotelName;
        private string groupName;
        private string groupLogo;
        private string meetingName;
        private string meetingLogo;
        private string meetingPostAs;
        private string meetingID;
        private string meetingType;
        private string meetingRoomID;
        private string meetingRoomName;
        private string meetingRoomLogo;
        private string hostEventIdentifier;
        private bool? postable;
        private bool? exhibit;
        private string backupMeetingRoomSpace;
        private string overflowMeetingRoomSpace;
        //private DateTime? Date { get; set; }
        //private DateTime? StartDate { get; set; }
        //private DateTime? EndDate { get; set; }
        private DateTime? startTime;
        private DateTime? endTime;
        private bool? isVisible;
        private string alias;
        private string directionalImage;

         public HospitalityEvent()
        {
            EventGUID = Guid.NewGuid().ToString();           
        }


         #region INotifyPropertyChanged Members

         public event PropertyChangedEventHandler PropertyChanged;

         protected virtual void OnPropertyChanged(string propertyName)
         {
             if (PropertyChanged != null)
                 PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
         }

         #endregion // INotifyPropertyChanged Members
    }
}
