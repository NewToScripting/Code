using System.Collections.Generic;

namespace Inspire
{
    public class MediaTypes
    {
        public static readonly List<string> IMAGEFORMATS = new List<string> { ".jpg", ".png", ".gif", ".bmp", ".jpeg", ".tiff", ".ico", ".wdp", ".wmp" };
        public static readonly List<string> VIDEOFORMATS = new List<string> { ".wmv", ".mp4", ".3g2", ".3gp", ".m4v", ".m2v", ".flv", ".mpg", ".avi", ".asx", ".mkv", ".mpeg" };
        public static readonly List<string> QUICKTIMEFORMATS = new List<string> { ".mov", ".h264", ".hdmov" };
    }

    public enum MediaType
    {
        Image,
        Video,
        PowerPoint,
        Flash,
        RichText,
        ScrollText,
        Web,
        Events,
        QuickTime,
        Reflection,
        RSSFeed,
        XamlElement,
        Playlist
    }


}
