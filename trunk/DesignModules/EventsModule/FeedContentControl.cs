using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.ComponentModel;
using EventsModule.EventTemplates;
using EventsModule.EventTemplates.RoomEvents;
using Inspire.Events.Proxy;
using Inspire.Services.WeakEventHandlers;

namespace EventsModule
{
    public class FeedContentControl : ContentControl , INotifyPropertyChanged , IDisposable , IWeakEventListener
    {

        public static readonly DependencyProperty DateTime1ForegroundProperty = DependencyProperty.Register("DateTime1Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty DateTime1FontSizeProperty = DependencyProperty.Register("DateTime1FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty DateTime1FontStyleProperty = DependencyProperty.Register("DateTime1FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty DateTime1FontFamilyProperty = DependencyProperty.Register("DateTime1FontFamily", typeof(FontFamily), typeof(FeedContentControl));
        public static readonly DependencyProperty DateTime2ForegroundProperty = DependencyProperty.Register("DateTime2Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty DateTime2FontSizeProperty = DependencyProperty.Register("DateTime2FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty DateTime2FontStyleProperty = DependencyProperty.Register("DateTime2FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty DateTime2FontFamilyProperty = DependencyProperty.Register("DateTime2FontFamily", typeof(FontFamily), typeof(FeedContentControl));
        public static readonly DependencyProperty DateTime3ForegroundProperty = DependencyProperty.Register("DateTime3Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty DateTime3FontSizeProperty = DependencyProperty.Register("DateTime3FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty DateTime3FontStyleProperty = DependencyProperty.Register("DateTime3FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty DateTime3FontFamilyProperty = DependencyProperty.Register("DateTime3FontFamily", typeof(FontFamily), typeof(FeedContentControl));
        public static readonly DependencyProperty DateTime4ForegroundProperty = DependencyProperty.Register("DateTime4Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty DateTime4FontSizeProperty = DependencyProperty.Register("DateTime4FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty DateTime4FontStyleProperty = DependencyProperty.Register("DateTime4FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty DateTime4FontFamilyProperty = DependencyProperty.Register("DateTime4FontFamily", typeof(FontFamily), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField1ForegroundProperty = DependencyProperty.Register("NameField1Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField1FontSizeProperty = DependencyProperty.Register("NameField1FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField1FontStyleProperty = DependencyProperty.Register("NameField1FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField1FontFamilyProperty = DependencyProperty.Register("NameField1FontFamily", typeof(FontFamily), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField2ForegroundProperty = DependencyProperty.Register("NameField2Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField2FontSizeProperty = DependencyProperty.Register("NameField2FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField2FontStyleProperty = DependencyProperty.Register("NameField2FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField2FontFamilyProperty = DependencyProperty.Register("NameField2FontFamily", typeof(FontFamily), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField3ForegroundProperty = DependencyProperty.Register("NameField3Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField3FontSizeProperty = DependencyProperty.Register("NameField3FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField3FontStyleProperty = DependencyProperty.Register("NameField3FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField3FontFamilyProperty = DependencyProperty.Register("NameField3FontFamily", typeof(FontFamily), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField4ForegroundProperty = DependencyProperty.Register("NameField4Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField4FontSizeProperty = DependencyProperty.Register("NameField4FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField4FontStyleProperty = DependencyProperty.Register("NameField4FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty NameField4FontFamilyProperty = DependencyProperty.Register("NameField4FontFamily", typeof(FontFamily), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField1ForegroundProperty = DependencyProperty.Register("DescField1Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField1FontSizeProperty = DependencyProperty.Register("DescField1FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField1FontStyleProperty = DependencyProperty.Register("DescField1FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField1FontFamilyProperty = DependencyProperty.Register("DescField1FontFamily", typeof(FontFamily), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField2ForegroundProperty = DependencyProperty.Register("DescField2Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField2FontSizeProperty = DependencyProperty.Register("DescField2FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField2FontStyleProperty = DependencyProperty.Register("DescField2FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField2FontFamilyProperty = DependencyProperty.Register("DescField2FontFamily", typeof(FontFamily), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField3ForegroundProperty = DependencyProperty.Register("DescField3Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField3FontSizeProperty = DependencyProperty.Register("DescField3FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField3FontStyleProperty = DependencyProperty.Register("DescField3FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField3FontFamilyProperty = DependencyProperty.Register("DescField3FontFamily", typeof(FontFamily), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField4ForegroundProperty = DependencyProperty.Register("DescField4Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField4FontSizeProperty = DependencyProperty.Register("DescField4FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField4FontStyleProperty = DependencyProperty.Register("DescField4FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty DescField4FontFamilyProperty = DependencyProperty.Register("DescField4FontFamily", typeof(FontFamily), typeof(FeedContentControl));
        public static readonly DependencyProperty IntField1ForegroundProperty = DependencyProperty.Register("IntField1Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty IntField1FontSizeProperty = DependencyProperty.Register("IntField1FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty IntField1FontStyleProperty = DependencyProperty.Register("IntField1FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty IntField1FontFamilyProperty = DependencyProperty.Register("IntField1FontFamily", typeof(FontFamily), typeof(FeedContentControl));
        public static readonly DependencyProperty IntField2ForegroundProperty = DependencyProperty.Register("IntField2Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty IntField2FontSizeProperty = DependencyProperty.Register("IntField2FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty IntField2FontStyleProperty = DependencyProperty.Register("IntField2FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty IntField2FontFamilyProperty = DependencyProperty.Register("IntField2FontFamily", typeof(FontFamily), typeof(FeedContentControl));
        public static readonly DependencyProperty DecimalField1ForegroundProperty = DependencyProperty.Register("DecimalField1Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty DecimalField1FontSizeProperty = DependencyProperty.Register("DecimalField1FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty DecimalField1FontStyleProperty = DependencyProperty.Register("DecimalField1FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty DecimalField1FontFamilyProperty = DependencyProperty.Register("DecimalField1FontFamily", typeof(FontFamily), typeof(FeedContentControl));
        public static readonly DependencyProperty DecimalField2ForegroundProperty = DependencyProperty.Register("DecimalField2Foreground", typeof(SolidColorBrush), typeof(FeedContentControl));
        public static readonly DependencyProperty DecimalField2FontSizeProperty = DependencyProperty.Register("DecimalField2FontSize", typeof(int), typeof(FeedContentControl));
        public static readonly DependencyProperty DecimalField2FontStyleProperty = DependencyProperty.Register("DecimalField2FontStyle", typeof(FontStyle), typeof(FeedContentControl));
        public static readonly DependencyProperty DecimalField2FontFamilyProperty = DependencyProperty.Register("DecimalField2FontFamily", typeof(FontFamily), typeof(FeedContentControl));


        #region Properties
        public SolidColorBrush DateTime1Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(DateTime1ForegroundProperty);
            }
            set
            {
                SetValue(DateTime1ForegroundProperty, value);
                OnPropertyChanged("DateTime1Foreground");
            }
        }

        public int DateTime1FontSize
        {
            get
            {
                return (int)GetValue(DateTime1FontSizeProperty);
            }
            set
            {
                SetValue(DateTime1FontSizeProperty, value);
                OnPropertyChanged("DateTime1FontSize");
            }
        }

        public FontStyle DateTime1FontStyle
        {
            get
            {
                return (FontStyle)GetValue(DateTime1FontStyleProperty);
            }
            set
            {
                SetValue(DateTime1FontStyleProperty, value);
                OnPropertyChanged("DateTime1FontStyle");
            }
        }

        public FontFamily DateTime1FontFamily
        {
            get
            {
                return (FontFamily)GetValue(DateTime1FontFamilyProperty);
            }
            set
            {
                SetValue(DateTime1FontFamilyProperty, value);
                OnPropertyChanged("DateTime1FontFamily");
            }
        }

        public SolidColorBrush DateTime2Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(DateTime2ForegroundProperty);
            }
            set
            {
                SetValue(DateTime2ForegroundProperty, value);
                OnPropertyChanged("DateTime2Foreground");
            }
        }

        public int DateTime2FontSize
        {
            get
            {
                return (int)GetValue(DateTime2FontSizeProperty);
            }
            set
            {
                SetValue(DateTime2FontSizeProperty, value);
                OnPropertyChanged("DateTime2FontSize");
            }
        }

        public FontStyle DateTime2FontStyle
        {
            get
            {
                return (FontStyle)GetValue(DateTime2FontStyleProperty);
            }
            set
            {
                SetValue(DateTime1FontStyleProperty, value);
                OnPropertyChanged("DateTime2FontStyle");
            }
        }

        public FontFamily DateTime2FontFamily
        {
            get
            {
                return (FontFamily)GetValue(DateTime2FontFamilyProperty);
            }
            set
            {
                SetValue(DateTime2FontFamilyProperty, value);
                OnPropertyChanged("DateTime2FontFamily");
            }
        }

        public SolidColorBrush DateTime3Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(DateTime3ForegroundProperty);
            }
            set
            {
                SetValue(DateTime3ForegroundProperty, value);
                OnPropertyChanged("DateTime3Foreground");
            }
        }

        public int DateTime3FontSize
        {
            get
            {
                return (int)GetValue(DateTime3FontSizeProperty);
            }
            set
            {
                SetValue(DateTime3FontSizeProperty, value);
                OnPropertyChanged("DateTime3FontSize");
            }
        }

        public FontStyle DateTime3FontStyle
        {
            get
            {
                return (FontStyle)GetValue(DateTime3FontStyleProperty);
            }
            set
            {
                SetValue(DateTime3FontStyleProperty, value);
                OnPropertyChanged("DateTime3FontStyle");
            }
        }

        public FontFamily DateTime3FontFamily
        {
            get
            {
                return (FontFamily)GetValue(DateTime3FontFamilyProperty);
            }
            set
            {
                SetValue(DateTime3FontFamilyProperty, value);
                OnPropertyChanged("DateTime3FontFamily");
            }
        }

        public SolidColorBrush DateTime4Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(DateTime4ForegroundProperty);
            }
            set
            {
                SetValue(DateTime4ForegroundProperty, value);
                OnPropertyChanged("DateTime4Foreground");
            }
        }

        public int DateTime4FontSize
        {
            get
            {
                return (int)GetValue(DateTime4FontSizeProperty);
            }
            set
            {
                SetValue(DateTime4FontSizeProperty, value);
                OnPropertyChanged("DateTime4FontSize");
            }
        }

        public FontStyle DateTime4FontStyle
        {
            get
            {
                return (FontStyle)GetValue(DateTime4FontStyleProperty);
            }
            set
            {
                SetValue(DateTime4FontStyleProperty, value);
                OnPropertyChanged("DateTime4FontStyle");
            }
        }

        public FontFamily DateTime4FontFamily
        {
            get
            {
                return (FontFamily)GetValue(DateTime4FontFamilyProperty);
            }
            set
            {
                SetValue(DateTime4FontFamilyProperty, value);
                OnPropertyChanged("DateTime4FontFamily");
            }
        }

        public SolidColorBrush NameField1Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(NameField1ForegroundProperty);
            }
            set
            {
                SetValue(NameField1ForegroundProperty, value);
                OnPropertyChanged("NameField1Foreground");
            }
        }

        public int NameField1FontSize
        {
            get
            {
                return (int)GetValue(NameField1FontSizeProperty);
            }
            set
            {
                SetValue(NameField1FontSizeProperty, value);
                OnPropertyChanged("NameField1FontSize");
            }
        }

        public FontStyle NameField1FontStyle
        {
            get
            {
                return (FontStyle)GetValue(NameField1FontStyleProperty);
            }
            set
            {
                SetValue(NameField1FontStyleProperty, value);
                OnPropertyChanged("NameField1FontStyle");
            }
        }

        public FontFamily NameField1FontFamily
        {
            get
            {
                return (FontFamily)GetValue(NameField1FontFamilyProperty);
            }
            set
            {
                SetValue(NameField1FontFamilyProperty, value);
                OnPropertyChanged("NameField1FontFamily");
            }
        }

        public SolidColorBrush NameField2Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(NameField2ForegroundProperty);
            }
            set
            {
                SetValue(NameField2ForegroundProperty, value);
                OnPropertyChanged("NameField2Foreground");
            }
        }

        public int NameField2FontSize
        {
            get
            {
                return (int)GetValue(NameField2FontSizeProperty);
            }
            set
            {
                SetValue(NameField2FontSizeProperty, value);
                OnPropertyChanged("NameField2FontSize");
            }
        }

        public FontStyle NameField2FontStyle
        {
            get
            {
                return (FontStyle)GetValue(NameField2FontStyleProperty);
            }
            set
            {
                SetValue(NameField2FontStyleProperty, value);
                OnPropertyChanged("NameField2FontStyle");
            }
        }

        public FontFamily NameField2FontFamily
        {
            get
            {
                return (FontFamily)GetValue(NameField2FontFamilyProperty);
            }
            set
            {
                SetValue(NameField2FontFamilyProperty, value);
                OnPropertyChanged("NameField2FontFamily");
            }
        }

        public SolidColorBrush NameField3Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(NameField3ForegroundProperty);
            }
            set
            {
                SetValue(NameField3ForegroundProperty, value);
                OnPropertyChanged("NameField3Foreground");
            }
        }

        public int NameField3FontSize
        {
            get
            {
                return (int)GetValue(NameField3FontSizeProperty);
            }
            set
            {
                SetValue(NameField3FontSizeProperty, value);
                OnPropertyChanged("NameField3FontSize");
            }
        }

        public FontStyle NameField3FontStyle
        {
            get
            {
                return (FontStyle)GetValue(NameField3FontStyleProperty);
            }
            set
            {
                SetValue(NameField3FontStyleProperty, value);
                OnPropertyChanged("NameField3FontStyle");
            }
        }

        public FontFamily NameField3FontFamily
        {
            get
            {
                return (FontFamily)GetValue(NameField3FontFamilyProperty);
            }
            set
            {
                SetValue(NameField3FontFamilyProperty, value);
                OnPropertyChanged("NameField3FontFamily");
            }
        }

        public SolidColorBrush NameField4Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(NameField4ForegroundProperty);
            }
            set
            {
                SetValue(NameField4ForegroundProperty, value);
                OnPropertyChanged("NameField4Foreground");
            }
        }

        public int NameField4FontSize
        {
            get
            {
                return (int)GetValue(NameField4FontSizeProperty);
            }
            set
            {
                SetValue(NameField4FontSizeProperty, value);
                OnPropertyChanged("NameField4FontSize");
            }
        }

        public FontStyle NameField4FontStyle
        {
            get
            {
                return (FontStyle)GetValue(NameField4FontStyleProperty);
            }
            set
            {
                SetValue(NameField4FontStyleProperty, value);
                OnPropertyChanged("NameField4FontStyle");
            }
        }

        public FontFamily NameField4FontFamily
        {
            get
            {
                return (FontFamily)GetValue(NameField4FontFamilyProperty);
            }
            set
            {
                SetValue(NameField4FontFamilyProperty, value);
                OnPropertyChanged("NameField4FontFamily");
            }
        }

        public SolidColorBrush DescField1Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(DescField1ForegroundProperty);
            }
            set
            {
                SetValue(DescField1ForegroundProperty, value);
                OnPropertyChanged("DescField1Foreground");
            }
        }

        public int DescField1FontSize
        {
            get
            {
                return (int)GetValue(DescField1FontSizeProperty);
            }
            set
            {
                SetValue(DescField1FontSizeProperty, value);
                OnPropertyChanged("DescField1FontSize");
            }
        }

        public FontStyle DescField1FontStyle
        {
            get
            {
                return (FontStyle)GetValue(DescField1FontStyleProperty);
            }
            set
            {
                SetValue(DescField1FontStyleProperty, value);
                OnPropertyChanged("DescField1FontStyle");
            }
        }

        public FontFamily DescField1FontFamily
        {
            get
            {
                return (FontFamily)GetValue(DescField1FontFamilyProperty);
            }
            set
            {
                SetValue(DescField1FontFamilyProperty, value);
                OnPropertyChanged("DescField1FontFamily");
            }
        }

        public SolidColorBrush DescField2Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(DescField2ForegroundProperty);
            }
            set
            {
                SetValue(DescField2ForegroundProperty, value);
                OnPropertyChanged("DescField2Foreground");
            }
        }

        public int DescField2FontSize
        {
            get
            {
                return (int)GetValue(DescField2FontSizeProperty);
            }
            set
            {
                SetValue(DescField2FontSizeProperty, value);
                OnPropertyChanged("DescField2FontSize");
            }
        }

        public FontStyle DescField2FontStyle
        {
            get
            {
                return (FontStyle)GetValue(DescField2FontStyleProperty);
            }
            set
            {
                SetValue(DescField2FontStyleProperty, value);
                OnPropertyChanged("DescField2FontStyle");
            }
        }

        public FontFamily DescField2FontFamily
        {
            get
            {
                return (FontFamily)GetValue(DescField2FontFamilyProperty);
            }
            set
            {
                SetValue(DescField2FontFamilyProperty, value);
                OnPropertyChanged("DescField2FontFamily");
            }
        }

        public SolidColorBrush DescField3Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(DescField3ForegroundProperty);
            }
            set
            {
                SetValue(DescField3ForegroundProperty, value);
                OnPropertyChanged("DescField3Foreground");
            }
        }

        public int DescField3FontSize
        {
            get
            {
                return (int)GetValue(DescField3FontSizeProperty);
            }
            set
            {
                SetValue(DescField3FontSizeProperty, value);
                OnPropertyChanged("DescField3FontSize");
            }
        }

        public FontStyle DescField3FontStyle
        {
            get
            {
                return (FontStyle)GetValue(DescField3FontStyleProperty);
            }
            set
            {
                SetValue(DescField3FontStyleProperty, value);
                OnPropertyChanged("DescField3FontStyle");
            }
        }

        public FontFamily DescField3FontFamily
        {
            get
            {
                return (FontFamily)GetValue(DescField3FontFamilyProperty);
            }
            set
            {
                SetValue(DescField3FontFamilyProperty, value);
                OnPropertyChanged("DescField3FontFamily");
            }
        }

        public SolidColorBrush DescField4Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(DescField4ForegroundProperty);
            }
            set
            {
                SetValue(DescField4ForegroundProperty, value);
                OnPropertyChanged("DescField4Foreground");
            }
        }

        public int DescField4FontSize
        {
            get
            {
                return (int)GetValue(DescField4FontSizeProperty);
            }
            set
            {
                SetValue(DescField4FontSizeProperty, value);
                OnPropertyChanged("DescField4FontSize");
            }
        }

        public FontStyle DescField4FontStyle
        {
            get
            {
                return (FontStyle)GetValue(DescField4FontStyleProperty);
            }
            set
            {
                SetValue(DescField4FontStyleProperty, value);
                OnPropertyChanged("DescField4FontStyle");
            }
        }

        public FontFamily DescField4FontFamily
        {
            get
            {
                return (FontFamily)GetValue(DescField4FontFamilyProperty);
            }
            set
            {
                SetValue(DescField4FontFamilyProperty, value);
                OnPropertyChanged("DescField4FontFamily");
            }
        }

        public SolidColorBrush IntField1Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(IntField1ForegroundProperty);
            }
            set
            {
                SetValue(IntField1ForegroundProperty, value);
                OnPropertyChanged("IntField1Foreground");
            }
        }

        public int IntField1FontSize
        {
            get
            {
                return (int)GetValue(IntField1FontSizeProperty);
            }
            set
            {
                SetValue(IntField1FontSizeProperty, value);
                OnPropertyChanged("IntField1FontSize");
            }
        }

        public FontStyle IntField1FontStyle
        {
            get
            {
                return (FontStyle)GetValue(IntField1FontStyleProperty);
            }
            set
            {
                SetValue(IntField1FontStyleProperty, value);
                OnPropertyChanged("IntField1FontStyle");
            }
        }

        public FontFamily IntField1FontFamily
        {
            get
            {
                return (FontFamily)GetValue(IntField1FontFamilyProperty);
            }
            set
            {
                SetValue(IntField1FontFamilyProperty, value);
                OnPropertyChanged("IntField1FontFamily");
            }
        }

        public SolidColorBrush IntField2Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(IntField2ForegroundProperty);
            }
            set
            {
                SetValue(IntField2ForegroundProperty, value);
                OnPropertyChanged("IntField2Foreground");
            }
        }

        public int IntField2FontSize
        {
            get
            {
                return (int)GetValue(IntField2FontSizeProperty);
            }
            set
            {
                SetValue(IntField2FontSizeProperty, value);
                OnPropertyChanged("IntField2FontSize");
            }
        }

        public FontStyle IntField2FontStyle
        {
            get
            {
                return (FontStyle)GetValue(IntField2FontStyleProperty);
            }
            set
            {
                SetValue(IntField2FontStyleProperty, value);
                OnPropertyChanged("IntField2FontStyle");
            }
        }

        public FontFamily IntField2FontFamily
        {
            get
            {
                return (FontFamily)GetValue(IntField2FontFamilyProperty);
            }
            set
            {
                SetValue(IntField2FontFamilyProperty, value);
                OnPropertyChanged("IntField2FontFamily");
            }
        }

        public SolidColorBrush DecimalField1Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(DecimalField1ForegroundProperty);
            }
            set
            {
                SetValue(DecimalField1ForegroundProperty, value);
                OnPropertyChanged("DecimalField1Foreground");
            }
        }

        public int DecimalField1FontSize
        {
            get
            {
                return (int)GetValue(DecimalField1FontSizeProperty);
            }
            set
            {
                SetValue(DecimalField1FontSizeProperty, value);
                OnPropertyChanged("DecimalField1FontSize");
            }
        }

        public FontStyle DecimalField1FontStyle
        {
            get
            {
                return (FontStyle)GetValue(DecimalField1FontStyleProperty);
            }
            set
            {
                SetValue(DecimalField1FontStyleProperty, value);
                OnPropertyChanged("DecimalField1FontStyle");
            }
        }

        public FontFamily DecimalField1FontFamily
        {
            get
            {
                return (FontFamily)GetValue(DecimalField1FontFamilyProperty);
            }
            set
            {
                SetValue(DecimalField1FontFamilyProperty, value);
                OnPropertyChanged("DecimalField1FontFamily");
            }
        }

        public SolidColorBrush DecimalField2Foreground
        {
            get
            {
                return (SolidColorBrush)GetValue(DecimalField2ForegroundProperty);
            }
            set
            {
                SetValue(DecimalField2ForegroundProperty, value);
                OnPropertyChanged("DecimalField2Foreground");
            }
        }

        public int DecimalField2FontSize
        {
            get
            {
                return (int)GetValue(DecimalField2FontSizeProperty);
            }
            set
            {
                SetValue(DecimalField2FontSizeProperty, value);
                OnPropertyChanged("DecimalField2FontSize");
            }
        }

        public FontStyle DecimalField2FontStyle
        {
            get
            {
                return (FontStyle)GetValue(DecimalField2FontStyleProperty);
            }
            set
            {
                SetValue(DecimalField2FontStyleProperty, value);
                OnPropertyChanged("DecimalField2FontStyle");
            }
        }

        public FontFamily DecimalField2FontFamily
        {
            get
            {
                return (FontFamily)GetValue(DecimalField2FontFamilyProperty);
            }
            set
            {
                SetValue(DecimalField2FontFamilyProperty, value);
                OnPropertyChanged("DecimalField2FontFamily");
            }
        }

        //public string TemplateDataSource
        //{
        //    get
        //    {
        //        return (string) GetValue(TemplateDataSourceProperty);
        //    }
        //    set
        //    {
        //        SetValue(TemplateDataSourceProperty, value);
        //        OnPropertyChanged("TemplateDataSource");
        //    }
        //}

        public FeedTemplate.FieldsEnum TemplateFields { get; set; }
        public string DisplayGuid { get; set; }
        public int SecondsPerPage { get; set; }
        public Uri TemplateFileName { get; set; }
        public int TemplateRows { get; set; }
        public string TemplateGuid { get; set; }
        public string TemplateDataSource { get; set; }
        public bool ShowAllRooms { get; set; }


        #endregion


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        
        public FeedContentControl()
        {
            
        }

        public void Dispose()
        {
            while(Content != null)
            {
                IDisposable disposable = (IDisposable)Content;
                disposable.Dispose();
                Content = null;
            }
        }

        public void PullNewFeed(string feedGuid)
        {
            if (Content.GetType() == typeof(EventStack))
            {
                EventStack eventStack = (EventStack) Content;
               // eventStack.PullNewFeed(feedGuid);
            }
            else if(Content.GetType() == typeof(RoomEvent))
            {
                
            }
        }

        public void ChangeScrollSpeed(int scrollSpeed)
        {
            if (Content.GetType() == typeof(EventStack))
            {
                EventStack eventStack = (EventStack)Content;
               // eventStack.ChangeScrollSpeed(scrollSpeed);
            }
            else if (Content.GetType() == typeof(RoomEvent))
            {

            }
        }

        public FeedContentControl(int _secondsPerPage, int _templateRows, string _displayGuid, string _templateGuid, Uri _templateFileName, string _templateDataSource, bool _showAllRooms)
        {
            LoadedEventManager.AddListener(this, this);

            IsHitTestVisible = false;
            DisplayGuid = _displayGuid;
            SecondsPerPage = _secondsPerPage;
            TemplateRows = _templateRows;
            TemplateGuid = _templateGuid;
            TemplateFileName = _templateFileName;
            TemplateDataSource = _templateDataSource;
            ShowAllRooms = _showAllRooms;

            // TODO: Need to get displayGuid here, if it is on the Client, then pass in Client
            if (DisplayGuid == null)
                DisplayGuid = "Client";
            string serverName;
            try
            {
                 serverName = Inspire.ClientConfigManager.GetServerName();
            }
            catch (Exception)
            {
                serverName = "";
            }
            
            //  string sourceName = "Hositality%20Events";
          //  Content = new EventStack(SecondsPerPage, TemplateRows, TemplateFileName, DisplayGuid, serverName, TemplateDataSource, ShowAllRooms);
        }

        public FeedContentControl(FeedContentControl _feedContentControl)
        {
            LoadedEventManager.AddListener(this, this);

            IsHitTestVisible = false;
            DisplayGuid = _feedContentControl.DisplayGuid;
            SecondsPerPage = _feedContentControl.SecondsPerPage;
            TemplateRows = _feedContentControl.TemplateRows;
            TemplateGuid = _feedContentControl.TemplateGuid;
            TemplateFileName = _feedContentControl.TemplateFileName;
            TemplateDataSource = _feedContentControl.TemplateDataSource;
            ShowAllRooms = _feedContentControl.ShowAllRooms;

            // TODO: Need to get displayGuid here, if it is on the Client, then pass in Client
            if (DisplayGuid == null)
                DisplayGuid = "Client";
            string serverName = Inspire.ClientConfigManager.GetServerName();
            //  string sourceName = "Hositality%20Events";
           // Content = new EventStack(SecondsPerPage, TemplateRows, TemplateFileName, DisplayGuid, serverName, TemplateDataSource, ShowAllRooms);
        }

        void EventContentControl_Loaded(object sender, EventArgs e)
        {
            if (NameField1Foreground == null)
                NameField1Foreground = Brushes.White;
            if (NameField2Foreground == null)
                NameField2Foreground = Brushes.White;
            if (NameField3Foreground == null)
                NameField3Foreground = Brushes.White;
            if (NameField4Foreground == null)
                NameField4Foreground = Brushes.White;
            if (DescField1Foreground == null)
                DescField1Foreground = Brushes.White;
            if (DescField2Foreground == null)
                DescField2Foreground = Brushes.White;
            if (DescField3Foreground == null)
                DescField3Foreground = Brushes.White;
            if (DescField4Foreground == null)
                DescField4Foreground = Brushes.White;
            if (DateTime1Foreground == null)
                DateTime1Foreground = Brushes.White;
            if (DateTime2Foreground == null)
                DateTime2Foreground = Brushes.White;
            if (DateTime3Foreground == null)
                DateTime3Foreground = Brushes.White;
            if (DateTime4Foreground == null)
                DateTime4Foreground = Brushes.White;
            if (IntField1Foreground == null)
                IntField1Foreground = Brushes.White;
            if (IntField2Foreground == null)
                IntField2Foreground = Brushes.White;
            if (IntField2Foreground == null)
                IntField2Foreground = Brushes.White;
            if (IntField2Foreground == null)
                IntField2Foreground = Brushes.White;
            if (DecimalField1Foreground == null)
                DecimalField1Foreground = Brushes.White;
            if (DecimalField2Foreground == null)
                DecimalField2Foreground = Brushes.White;

            if (NameField1FontFamily == null)
                NameField1FontFamily = new FontFamily("Arial");

        }

        public void SetFontValues(FeedContentControl feedContentControl)
        {

            NameField1FontFamily = feedContentControl.NameField1FontFamily;
            NameField1FontSize = feedContentControl.NameField1FontSize;
            NameField1FontStyle = feedContentControl.NameField1FontStyle;
            NameField1Foreground = feedContentControl.NameField1Foreground;

            NameField2FontFamily = feedContentControl.NameField2FontFamily;
            NameField2FontSize = feedContentControl.NameField2FontSize;
            NameField2FontStyle = feedContentControl.NameField2FontStyle;
            NameField2Foreground = feedContentControl.NameField2Foreground;

            NameField3FontFamily = feedContentControl.NameField3FontFamily;
            NameField3FontSize = feedContentControl.NameField3FontSize;
            NameField3FontStyle = feedContentControl.NameField3FontStyle;
            NameField3Foreground = feedContentControl.NameField3Foreground;

            NameField4FontFamily = feedContentControl.NameField4FontFamily;
            NameField4FontSize = feedContentControl.NameField4FontSize;
            NameField4FontStyle = feedContentControl.NameField4FontStyle;
            NameField4Foreground = feedContentControl.NameField4Foreground;

            DescField1FontFamily = feedContentControl.DescField1FontFamily;
            DescField1FontSize = feedContentControl.DescField1FontSize;
            DescField1FontStyle = feedContentControl.DescField1FontStyle;
            DescField1Foreground = feedContentControl.DescField1Foreground;

            DescField2FontFamily = feedContentControl.DescField2FontFamily;
            DescField2FontSize = feedContentControl.DescField2FontSize;
            DescField2FontStyle = feedContentControl.DescField2FontStyle;
            DescField2Foreground = feedContentControl.DescField2Foreground;

            DescField3FontFamily = feedContentControl.DescField3FontFamily;
            DescField3FontSize = feedContentControl.DescField3FontSize;
            DescField3FontStyle = feedContentControl.DescField3FontStyle;
            DescField3Foreground = feedContentControl.DescField3Foreground;

            DescField4FontFamily = feedContentControl.DescField4FontFamily;
            DescField4FontSize = feedContentControl.DescField4FontSize;
            DescField4FontStyle = feedContentControl.DescField4FontStyle;
            DescField4Foreground = feedContentControl.DescField4Foreground;

            IntField1FontFamily = feedContentControl.IntField1FontFamily;
            IntField1FontSize = feedContentControl.IntField1FontSize;
            IntField1FontStyle = feedContentControl.IntField1FontStyle;
            IntField1Foreground = feedContentControl.IntField1Foreground;

            IntField2FontFamily = feedContentControl.IntField2FontFamily;
            IntField2FontSize = feedContentControl.IntField2FontSize;
            IntField2FontStyle = feedContentControl.IntField2FontStyle;
            IntField2Foreground = feedContentControl.IntField2Foreground;

            DecimalField1FontFamily = feedContentControl.DecimalField1FontFamily;
            DecimalField1FontSize = feedContentControl.DecimalField1FontSize;
            DecimalField1FontStyle = feedContentControl.DecimalField1FontStyle;
            DecimalField1Foreground = feedContentControl.DecimalField1Foreground;

            DecimalField2FontFamily = feedContentControl.DecimalField2FontFamily;
            DecimalField2FontSize = feedContentControl.DecimalField2FontSize;
            DecimalField2FontStyle = feedContentControl.DecimalField2FontStyle;
            DecimalField2Foreground = feedContentControl.DecimalField2Foreground;

            DateTime1FontFamily = feedContentControl.DateTime1FontFamily;
            DateTime1FontSize = feedContentControl.DateTime1FontSize;
            DateTime1FontStyle = feedContentControl.DateTime1FontStyle;
            DateTime1Foreground = feedContentControl.DateTime1Foreground;

            DateTime2FontFamily = feedContentControl.DateTime2FontFamily;
            DateTime2FontSize = feedContentControl.DateTime2FontSize;
            DateTime2FontStyle = feedContentControl.DateTime2FontStyle;
            DateTime2Foreground = feedContentControl.DateTime2Foreground;

            DateTime3FontFamily = feedContentControl.DateTime3FontFamily;
            DateTime3FontSize = feedContentControl.DateTime3FontSize;
            DateTime3FontStyle = feedContentControl.DateTime3FontStyle;
            DateTime3Foreground = feedContentControl.DateTime3Foreground;
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                EventContentControl_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
