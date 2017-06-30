using System.Collections.Generic;
using System.ComponentModel;

namespace Inspire.Events.Proxy
{


    public class Group : INotifyPropertyChanged
    {
        private string groupImageWebPath;

        public string Guid { get; set; }
        public string Name { get; set; }

        public List<GroupAlias> Aliases { get; set; }
      
        public string GroupImageWebPath
        {
            get { return groupImageWebPath; }
            set
            {
                if (value != groupImageWebPath)
                {
                    groupImageWebPath = value;
                    OnPropertyChanged("GroupImageWebPath");
                }
            }
        }
        public string GroupImageID { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class GroupAlias
    {
        public string Guid { get; set; }
        public string Value { get; set; }
        public string GroupID { get; set; }

        public GroupAlias(){}

        public GroupAlias(string value, string groupId)
        {
            Guid = System.Guid.NewGuid().ToString();
            Value = value;
            GroupID = groupId;
        }

    }
}
