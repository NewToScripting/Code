using System.IO;
using System.Windows.Controls;

namespace Inspire.Client.Designer.DragCanvas
{
    public class InspireCanvas : Canvas
    {

        public enum FileType
        {
            Video,
            Image,
            QuickTime,
            Flash,
            PowerPoint,
            NotSupported,
        }


        public static FileType GetFileType(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();

            if (MediaTypes.IMAGEFORMATS.Contains(extension))
                return FileType.Image;

            if (MediaTypes.VIDEOFORMATS.Contains(extension))
                return FileType.Video;
            //TODO
            if (MediaTypes.QUICKTIMEFORMATS.Contains(extension))
                return FileType.QuickTime;
            if (extension == ".swf")
                return FileType.Flash;

            return FileType.NotSupported;
        }

    }
}
