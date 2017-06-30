using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Inspire
{
    public class BoolToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ReverseBoolToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class NullToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is string)
                    if (value.ToString().Length > 0)
                        return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Visibility.Visible;
        }
    }

    public class NullToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is string)
                    if (value.ToString().Length > 0)
                        return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Visibility.Visible;
        }
    }

    [ValueConversion(typeof(DependencyObject), typeof(DependencyObject))]
    internal class ContentValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // This horrendous hack is necessary because the Content/BackContent of a ContentControl3D
            // is a logical child of the ContentControl3D, not the ContentPresenters that host the content.
            // In order to inform the Content/BackContent elements of which side they reside on, we must
            // attach the IsOnFrontSide property value to them via a value converter that is set on the
            // TemplateBinding of the ContentPresenters' Content property.  If we do not do this, then the
            // IsOnFrontSide property value does not get inherited by the elements shown in the control.
            // This is important when BringIntoView is called on an element in the ContentControl3D and we
            // need to figure out on which side of the control it exists.  This workaround is only for
            // the Content and BackContent, but not the elements created by the ContentTemplate or
            // BackContentTemplate properties.

            DependencyObject depObj = value as DependencyObject;
            string side = parameter as string;
            if (depObj != null && !String.IsNullOrEmpty(side))
            {
                bool? isOnFrontSide = side == "FRONT";
                ContentControl3D.SetIsOnFrontSide(depObj, isOnFrontSide);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class ImageConverter
    {
        public static BitmapImage Convert(Uri uri)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = uri;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();
            if(image.CanFreeze)
                image.Freeze();
            return image;
        }

        public static object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Color source = (Color)value;
                
                return new SolidColorBrush(source);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class ImageUriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Uri source = (Uri) value;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = source;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                if(image.CanFreeze)
                    image.Freeze();
                return image;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    public class ImageStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                try
                {
                    var source = new Uri(value.ToString(), UriKind.Relative);
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = source;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                    if (image.CanFreeze)
                        image.Freeze();
                    return image;
                }
                //catch (NotSupportedException)
                //{
                    // TODO: return thumbnail
                //}
                catch(Exception)
                {
                    return value;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    public class ImageAbsStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                try
                {
                    var source = new Uri(value.ToString(), UriKind.Absolute);
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = source;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                    if (image.CanFreeze)
                        image.Freeze();
                    return image;
                }
                //catch (NotSupportedException)
                //{
                // TODO: return thumbnail
                //}
                catch (Exception)
                {
                    return value;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    public class DurationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                DateTime dt = (DateTime)value;
                string durationTime = dt.Hour.ToString("00") + ":" + dt.Minute.ToString("00") + ":" + dt.Second.ToString("00");
                return durationTime;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    public class FullDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var dt = (DateTime)value;
                string dateTime = dt.DayOfWeek + ", " + DateHelper.GetMonthDisplayName(dt.Month) + " " + dt.Day + ", " + dt.Year;
                return dateTime;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class HtmlSanitizer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Remove HTML tags and empty newlines and spaces
            string returnString = Regex.Replace(value as string, "<.*?>", "");
            returnString = Regex.Replace(returnString, @"\n+\s+", "");//\n\n

            // Decode HTML entities
            returnString = HttpUtility.HtmlDecode(returnString);

            returnString = returnString.Replace("&nbsp;", " ");

            returnString = returnString.Replace("&#39;", "'");

            returnString = returnString.Replace("&apos;", "'");

            return returnString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class LineCleaner : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string returnString = Regex.Replace(value as string, @"\n", string.Empty);//\n\n
            returnString = Regex.Replace(returnString, "[\n\r\t]", "");
            return returnString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }



    public class ImageToByteConverter
    {
        public static object Convert(Image value)
        {
            if (value != null)
            {
                byte[] myImageBuffer;
                using(FileStream myStream = new FileStream(new Uri(value.Source.ToString()).LocalPath, FileMode.Open, FileAccess.Read))
                {
                // Create a buffer to hold the stream of bytes
                
                    myImageBuffer = new byte[myStream.Length];
                    // Read the bytes from this stream and put it into the image buffer
                    myStream.Read(myImageBuffer, 0, (int)myStream.Length);
                    myStream.Dispose();
                }
                //return ResizeImage(myImageBuffer);
                return myImageBuffer;
            }
            return null;
        }

        public static object ConvertBack(object value)
        {
            if (value != null && value is byte[])
            {
                Image img = new Image();

                BitmapImage bitImg = new BitmapImage();

                bitImg.BeginInit();

                using (MemoryStream ms = new MemoryStream(value as byte[]))
                {
                    bitImg.StreamSource = ms;

                    bitImg.EndInit();
                    img.Source = bitImg;
                    ms.Dispose();
                }

                return img;
            }
            return null;
        }

        //private static byte[] ResizeImage(byte[] imageBytes)
        //{
        //    int NewWidth = 240;
        //    int MaxHeight = 240;

        //    if (imageBytes == null)
        //    {
        //        return null;
        //    }

        //    MemoryStream ms = new MemoryStream(imageBytes);
        //    MemoryStream outStream = new MemoryStream();
        //    System.Drawing.Image FullsizeImage = System.Drawing.Image.FromStream(ms);

        //    // Prevent using images internal thumbnail
        //    FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
        //    FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);


        //    if (FullsizeImage.Width <= NewWidth)
        //    {
        //        NewWidth = FullsizeImage.Width;
        //    }


        //    int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
        //    if (NewHeight > MaxHeight)
        //    {
        //        // Resize with height instead
        //        NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
        //        NewHeight = MaxHeight;
        //    }

        //    System.Drawing.Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);

        //    // Clear handle to original file so that we can overwrite it if necessary
        //    FullsizeImage.Dispose();

        //    // Save resized picture
        //    NewImage.Save(outStream, ImageFormat.Png);
        //    return outStream.ToArray();


        //}//function
    }

    public class JScriptConverter : IMultiValueConverter, IValueConverter
    {
        private delegate object Evaluator(string code, object[] values);
        private static Evaluator evaluator;

        static JScriptConverter()
        {
            string source =
                @"import System; 

                class Eval
                {
                    public function Evaluate(code : String, values : Object[]) : Object
                    {
                        return eval(code);
                    }
                }";

            CompilerParameters cp = new CompilerParameters();
            cp.GenerateInMemory = true;
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                if (File.Exists(assembly.Location))
                    cp.ReferencedAssemblies.Add(assembly.Location);

            CompilerResults results = (new Microsoft.JScript.JScriptCodeProvider())
                .CompileAssemblyFromSource(cp, source);

            Assembly result = results.CompiledAssembly;

            Type eval = result.GetType("Eval");

            evaluator = (Delegate.CreateDelegate(
                typeof(Evaluator),
                Activator.CreateInstance(eval),
                "Evaluate") as Evaluator);
        }

        private bool trap;
        public bool TrapExceptions
        {
            get { return trap; }
            set { trap = true; }
        }

        public object Convert(object[] values, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                return evaluator(parameter.ToString(), values);
            }
            catch
            {
                if (trap)
                    return null;
                else
                    throw;
            }
        }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return Convert(new object[] { value }, targetType, parameter, culture);
        }


        public object[] ConvertBack(object value, Type[] targetTypes,
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class ReverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return !(bool)value;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ReverseIsEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return (value.ToString().Length > 0);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DropDownSelectedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return ((int)value > -1);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
  
}
