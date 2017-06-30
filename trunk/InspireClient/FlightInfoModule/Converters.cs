using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Effects;
using FlightInfoModule.Proxy;

namespace FlightInfoModule
{
    public class FlightStatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is Flight)
                {
                    var flight = (Flight) value;
                    if (flight.Status.ToLower().Contains("cancel"))
                    {
                        return new DropShadowEffect { BlurRadius = 8, Color = Color.FromRgb(255, 0, 0), Direction = 55.0, ShadowDepth = -1 };
                    }
                    if (flight.Status.ToLower().Contains("delay"))
                    {
                        return new DropShadowEffect { BlurRadius = 8, Color = Color.FromRgb(255, 165, 0), Direction = 55.0, ShadowDepth = -1};
                    }
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
