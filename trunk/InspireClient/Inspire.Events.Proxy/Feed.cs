using System;
using System.ComponentModel;

namespace Inspire.Events.Proxy
{
    public class FeedEntry
    {

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public string FeedID { get; set; }
        public string NameField1 { get; set; }
        public string NameField2 { get; set; }
        public string NameField3 { get; set; }
        public string NameField4 { get; set; }
        public string DescField1 { get; set; }
        public string DescField2 { get; set; }
        public string DescField3 { get; set; }
        public string DescField4 { get; set; }
        public string TextField1 { get; set; }
        public string TextField2 { get; set; }
        public int? IntField1 { get; set; }
        public int? IntField2 { get; set; }
        public decimal? DecimalField1 { get; set; }
        public decimal? DecimalField2 { get; set; }
        public DateTime? DateField1 { get; set; }
        public DateTime? DateField2 { get; set; }
        public DateTime? DateField3 { get; set; }
        public DateTime? DateField4 { get; set; }
        public Uri ImageWebPath { get; set;}
        public string ImageDescription { get; set;}


    }

    public class Feed : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public string GUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NameField1Def { get; set; }
        public string NameField2Def { get; set; }
        public string NameField3Def { get; set; }
        public string NameField4Def { get; set; }
        public string DescField1Def { get; set; }
        public string DescField2Def { get; set; }
        public string DescField3Def { get; set; }
        public string DescField4Def { get; set; }
        public string TextField1Def { get; set; }
        public string TextField2Def { get; set; }
        public string IntField1Def { get; set; }
        public string IntField2Def { get; set; }
        public string DecimalField1Def { get; set; }
        public string DecimalField2Def { get; set; }
        public string DateField1Def { get; set; }
        public string DateField2Def { get; set; }
        public string DateField3Def { get; set; }
        public string DateField4Def { get; set; }
        
    }
}