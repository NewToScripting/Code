using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Inspire.Client.ScheduleWindow.Converters
{

    public class NoButtonWarningConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var buttons = value as IEnumerable<SlideButton>;
            if (buttons != null)
            {
                return (buttons.Where(b => string.IsNullOrEmpty(b.SlideGuidToNavigateTo)).Count() > 0) ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class NullEmptyToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null) return string.IsNullOrEmpty(value as string) ? Visibility.Visible : Visibility.Collapsed;
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class RulesToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var retStr = string.Empty;

            var rules = value as IEnumerable<SlideRule>;
            if (rules != null)
            {
                retStr = rules.Aggregate(string.Empty, (current, slideRule) => current + slideRule.Rule + "  ");
            }
            return retStr;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class RulesToMultiTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var retStr = string.Empty;

            var rules = value as IEnumerable<SlideRule>;
            if (rules != null)
            {
                var lstRules = rules.ToList();

                for (int i = 0; i < lstRules.Count; i++)
                {
                    retStr += i + 1 + ". " + lstRules[i].Rule + Environment.NewLine;
                }
            }
            return retStr;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
