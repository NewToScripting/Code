
using System.Windows.Media;

namespace PlaylistModule
{
    public class Picture : PlaylistFile
    {
        public Picture(){}

        public Picture(string uri, Stretch stretch)
        {
            Uri = uri;
            Stretch = stretch;
        }

        public new static string[] Extensions = { ".jpg", ".png", ".gif", ".jpeg", ".bmp", ".pic", ".tiff", ".ico", ".wdp", ".wmp"};
    }
}
