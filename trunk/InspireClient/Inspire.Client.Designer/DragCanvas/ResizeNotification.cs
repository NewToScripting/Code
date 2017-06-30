using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Inspire.Client.Designer.DragCanvas
{
    public class ResizeNotification : Control
    {
        static ResizeNotification()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResizeNotification), new FrameworkPropertyMetadata(typeof(ResizeNotification)));
        }
    }

    public class DoubleFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double d = (double)value;
            return Math.Round(d);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
