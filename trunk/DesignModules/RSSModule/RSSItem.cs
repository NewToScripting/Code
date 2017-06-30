using System.Windows.Documents;
using System.Windows;
using System.ComponentModel;
using System.Windows.Media;

namespace RSSModule
{
    public class RSSItem : DependencyObject , INotifyPropertyChanged
    {
        public RSSItem()
        {
            
        }

        public RSSItem(string title, double titleSize, Brush titleColor, FontFamily titleFFamily, FlowDocument description, double descSize, Brush descColor, FontFamily descFamily, string descriptionText)
        {
            Title = title;
            RSSItemTitleFontSize = titleSize;
            RSSItemTitleForeground = titleColor;
            RSSItemTitleFontFamily = titleFFamily;

            Description = description;
            DescriptionText = descriptionText;
            RSSItemDescriptionFontSize = descSize;
            RSSItemDescriptionForeground = descColor;
            RSSItemDescriptionFontFamily = descFamily;
        }



        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value);
            OnPropertyChanged("Title");
            }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(RSSItem), new UIPropertyMetadata(""));



        public FlowDocument Description
        {
            get { return (FlowDocument)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value);
            OnPropertyChanged("Description");
            }
        }

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(FlowDocument), typeof(RSSItem));



        public string DescriptionText
        {
            get { return (string)GetValue(DescriptionTextProperty); }
            set { SetValue(DescriptionTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DescriptionText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionTextProperty =
            DependencyProperty.Register("DescriptionText", typeof(string), typeof(RSSItem), new UIPropertyMetadata(string.Empty));

        


        public static DependencyProperty RSSItemTitleForegroundProperty = DependencyProperty.Register(
            "RSSTitleForeground", typeof(Brush), typeof(RSSItem));

        public static DependencyProperty RSSItemTitleFontFamilyProperty = DependencyProperty.Register(
            "RSSTitleFontFamily", typeof(FontFamily), typeof(RSSItem));

        public static DependencyProperty RSSItemTitleFontSizeProperty = DependencyProperty.Register(
            "RSSTitleFontSize", typeof(double), typeof(RSSItem));

        public static DependencyProperty RSSItemDescriptionForegroundProperty = DependencyProperty.Register(
            "RSSDescriptionForeground", typeof(Brush), typeof(RSSItem));

        public static DependencyProperty RSSItemDescriptionFontFamilyProperty = DependencyProperty.Register(
            "RSSDescriptionFontFamily", typeof(FontFamily), typeof(RSSItem));

        public static DependencyProperty RSSItemDescriptionFontSizeProperty = DependencyProperty.Register(
            "RSSDescriptionFontSize", typeof(double), typeof(RSSItem));


        public double RSSItemTitleFontSize
        {
            get
            {
                return (double)GetValue(RSSItemTitleFontSizeProperty);
            }
            set
            {
                SetValue(RSSItemTitleFontSizeProperty, value);
                OnPropertyChanged("RSSItemTitleFontSize");
            }
        }

        public Brush RSSItemTitleForeground
        {
            get { return (Brush)GetValue(RSSItemTitleForegroundProperty); }
            set
            {
                SetValue(RSSItemTitleForegroundProperty, value);
                OnPropertyChanged("RSSItemTitleForeground");
            }
        }

        public FontFamily RSSItemTitleFontFamily
        {
            get
            { return (FontFamily)GetValue(RSSItemTitleFontFamilyProperty); }
            set
            {
                SetValue(RSSItemTitleFontFamilyProperty, value);
                OnPropertyChanged("RSSItemTitleFontFamily");
            }

        }

        public double RSSItemDescriptionFontSize
        {
            get { return (double)GetValue(RSSItemDescriptionFontSizeProperty); }
            set
            {
                SetValue(RSSItemDescriptionFontSizeProperty, value);
                OnPropertyChanged("RSSItemDescriptionFontSize");
            }
        }

        public Brush RSSItemDescriptionForeground
        {
            get { return (Brush)GetValue(RSSItemDescriptionForegroundProperty); }
            set
            {
                SetValue(RSSItemDescriptionForegroundProperty, value);
                OnPropertyChanged("RSSItemDescriptionForeground");
            }
        }

        public FontFamily RSSItemDescriptionFontFamily
        {
            get { return (FontFamily)GetValue(RSSItemDescriptionFontFamilyProperty); }
            set
            {
                SetValue(RSSItemDescriptionFontFamilyProperty, value);
                OnPropertyChanged("RSSItemDescriptionFontFamily");
            }
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
