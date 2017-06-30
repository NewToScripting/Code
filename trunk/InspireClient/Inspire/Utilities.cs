using System;
using System.Collections;
using System.Windows.Controls;
using Inspire.MediaObjects;

namespace Inspire
{
    public static class Utilities
    {
        #region PrepareUrl

        /// <summary>
        /// Turns a potentially valid URL string into a properly formatted URL, when possible.
        /// </summary>
        public static string PrepareUrl(string url)
        {
            if (url == null)
                return null;

            string str = url.Trim().Replace('\\', '/');

            Uri uri;
            bool isRawLocalFilePath =
                Uri.TryCreate(str, UriKind.Absolute, out uri) &&
                uri.Scheme == Uri.UriSchemeFile &&
                !url.StartsWith("file:///", StringComparison.InvariantCultureIgnoreCase);

            if (isRawLocalFilePath)
                str = "file:///" + str;

            if (!Uri.IsWellFormedUriString(str, UriKind.Absolute))
                str = Uri.EscapeUriString(str);

            return str;
        }

        //public static string CopyFilesToTemp(string filePath)
        //{
        //    string newPath = string.Empty;
            
        //    if (File.Exists(Paths.ClientTempDirectory))
        //        Files.Copy(new Uri(oldSource).LocalPath, Paths.ClientTempDirectory);
        //    else
        //        Files.Move(new Uri(oldSource).LocalPath, tempPath);

        //    string newSource = designContentControl.GUID +
        //                       Path.GetExtension(image.Source.ToString());

        //    return newPath;
        //}

        #endregion // PrepareUrl

    #region Attach reflections

        public static void AttachReflections(IEnumerable canvasItems)
        {
            foreach (ContentControl item in canvasItems)
            {
                if (item is DesignContentControl)
                {
                    if (((DesignContentControl)item).Type == MediaType.Reflection)
                    {
                        var designReflection = item.Content as DesignReflection;
                        if (designReflection != null)
                        {
                            //DesignReflection designReflection = contentControl.Content as DesignReflection;
                            foreach (DesignContentControl control in canvasItems)
                            {
                                if (control.GUID == designReflection.TargetGuid)
                                {
                                    designReflection.ReflectionTarget = control;
                                    item.Content = designReflection;
                                }
                            }
                        }
                    }
                }
                else if(item is DesignControlHolder)
                {
                    if (((DesignContentControl)(item).Content).Type == MediaType.Reflection)
                    {
                        var designReflection = ((DesignContentControl)(item).Content).Content as DesignReflection;
                        if (designReflection != null)
                        {
                            //DesignReflection designReflection = contentControl.Content as DesignReflection;
                            foreach (ContentControl control in canvasItems)
                            {
                                if (((DesignContentControl)(control).Content).GUID == designReflection.TargetGuid)
                                {
                                    designReflection.ReflectionTarget = control.Content as DesignContentControl;
                                    ((DesignContentControl)(item).Content).Content = designReflection;
                                }
                            }
                        }
                    }
                }
            }
        }

#endregion

        public static string ConvertWhitespaceToSpaces(string value)
        {
            char[] arr = value.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                switch (arr[i])
                {
                    case '\t':
                    case '\r':
                    case '\n':
                        {
                            arr[i] = ' ';
                            break;
                        }
                }
            }
            return new string(arr);
        }

    }
}
