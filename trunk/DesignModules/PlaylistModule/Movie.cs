
using System.Windows.Media;

namespace PlaylistModule
{
    public class Movie : PlaylistFile
    {
        public Movie(){}

        public Movie(string uri,Stretch stretch)
        {
            Uri = uri;
            Stretch = stretch;
            IsPlaying = false;
        }

        public bool IsPlaying { get; set; }

        public new static string[] Extensions = { ".wmv", ".mp4", ".3g2", ".3gp", ".m4v", ".m2v", ".flv", ".mpg", ".avi", ".asx", ".mkv", ".mpeg" };
    }
}
