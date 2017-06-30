
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

        public new static string[] Extensions = { ".wmv", ".avi", ".mpeg", ".mpg", ".mp4", ".mov" };
    }
}
