using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.ComponentModel;

namespace EventsModule
{
    public class DataItem
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Field01 { get; set; }
        public string Field02 { get; set; }
        public string Field03 { get; set; }
        public string Field04 { get; set; }
        public string Field05 { get; set; }
        public string Field06 { get; set; }
        public string Field07 { get; set; }
        public string Field08 { get; set; }
        public string Field09 { get; set; }
        public string Field10 { get; set; }
      

        public Brush StartTimeForeground { get; set; }
        public Brush StartDateForeground { get; set; }
        public Brush EndTimeForeground { get; set; }
        public Brush EndDateForeground { get; set; }

        public Brush Field01Foreground { get; set; }
        public Brush Field02Foreground { get; set; }
        public Brush Field03Foreground { get; set; }
        public Brush Field04Foreground { get; set; }
        public Brush Field05Foreground { get; set; }
        public Brush Field06Foreground { get; set; }
        public Brush Field07Foreground { get; set; }
        public Brush Field08Foreground { get; set; }
        public Brush Field09Foreground { get; set; }
        public Brush Field10Foreground { get; set; }

        public int StartTimeFontSize { get; set; }
        public int StartDateFontSize { get; set; }
        public int EndTimeFontSize { get; set; }
        public int EndDateFontSize { get; set; }

        public int Field01FontSize { get; set; }
        public int Field02FontSize { get; set; }
        public int Field03FontSize { get; set; }
        public int Field04FontSize { get; set; }
        public int Field05FontSize { get; set; }
        public int Field06FontSize { get; set; }
        public int Field07FontSize { get; set; }
        public int Field08FontSize { get; set; }
        public int Field09FontSize { get; set; }
        public int Field10FontSize { get; set; }
    }

}
