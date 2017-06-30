using System.Windows.Media;

namespace RSSModule
{
    public interface IRSSControl
    {
        double RSSTitleFontSize { get; set;}

        Brush RSSTitleForeground { get; set;}

        FontFamily RSSTitleFontFamily { get; set;}
        
        double RSSDescriptionFontSize { get; set;}

        Brush RSSDescriptionForeground { get; set;}

        FontFamily RSSDescriptionFontFamily { get; set; }

        void Dispose();

        int RSSFeedSpeed { get; set; }
    }
}