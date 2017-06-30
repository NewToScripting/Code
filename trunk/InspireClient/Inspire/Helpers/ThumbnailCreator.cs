using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Inspire.Helpers
{
    public static class ThumbnailCreator
    {
        /// 
        /// Gets a JPG "screenshot" of the current UIElement 
        /// 
        /// UIElement to screenshot 
        /// Scale to render the screenshot 
        /// JPG Quality  
        /// Byte array of JPG data  
        public static byte[] GetJpgImage(FrameworkElement source, double scale, int quality, string exportPath)
        {

            double actualHeight = source.RenderSize.Height;
            double actualWidth = source.RenderSize.Width;

            double renderHeight = actualHeight * scale;
            double renderWidth = actualWidth * scale;

            // Get the size of canvas
            Size size = new Size(source.Width, source.Height);
            // Measure and arrange the surface
            // VERY IMPORTANT
            source.LayoutTransform = null;

            source.Measure(size);
            source.Arrange(new Rect(size));
            source.UpdateLayout();

            RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96, 96, PixelFormats.Pbgra32);

            VisualBrush sourceBrush = new VisualBrush(source);

            DrawingVisual drawingVisual = new DrawingVisual();

            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.PushTransform(new ScaleTransform(scale, scale));
                drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0), new Point(actualWidth, actualHeight)));
            }

            renderTarget.Render(drawingVisual);

            //JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            //encoder.QualityLevel = quality;
            encoder.Frames.Add(BitmapFrame.Create(renderTarget));

            Byte[] imageArray = new byte[] { };

            using (FileStream outStream = new FileStream(new Uri(exportPath).LocalPath, FileMode.Create))
            {
                encoder.Save(outStream);
                outStream.Close();
            }

            using (FileStream myStream = new FileStream(new Uri(exportPath).LocalPath,
                                FileMode.Open, FileAccess.Read))
            {
                // Create a buffer to hold the stream of bytes
                byte[] myImageBuffer = new byte[myStream.Length];
                // Read the bytes from this stream and put it into the image buffer
                myStream.Read(myImageBuffer, 0, (int)myStream.Length);
                myStream.Close();
            }

            return imageArray;
        }

        static public byte[] ExportToPng(string exportPath) // Uri path, UserControl surface
        {
            byte[] nothin = new byte[3];
            if (Paths.ClientTempDirectory == null) return nothin;

            var dragCanvas = InspireApp.CurrentDragCanvas;
            // Save current canvas transform
            if (dragCanvas != null)
            {

                //return GetJpgImage(dragCanvas, .2, 100, exportPath);

                Transform transform = dragCanvas.LayoutTransform;
                // reset current transform (in case it is scaled or rotated)
                dragCanvas.LayoutTransform = null;

                // Get the size of canvas
                Size size = new Size(dragCanvas.Width, dragCanvas.Height);
                // Measure and arrange the surface
                // VERY IMPORTANT
                dragCanvas.Measure(size);
                dragCanvas.Arrange(new Rect(size));
                dragCanvas.UpdateLayout();

                // Create a render bitmap and push the surface to it
                RenderTargetBitmap renderBitmap = new RenderTargetBitmap((int)size.Width,
                                                                         (int)size.Height,
                                                                         96d, 96d,
                                                                         PixelFormats.Pbgra32);


                renderBitmap.Render(dragCanvas);



                // Create a file stream for saving image
                using (
                    FileStream outStream =
                        new FileStream(new Uri(exportPath).LocalPath,
                                       FileMode.Create))
                {
                    // Use png encoder for our data
                    //PngBitmapEncoder encoder = new PngBitmapEncoder();
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.QualityLevel = 30;
                    // push the rendered bitmap to it
                    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                    // save the data to the stream
                    encoder.Save(outStream);
                    outStream.Close();
                }

                byte[] myImageBuffer;
                using (FileStream myStream =
                    new FileStream(new Uri(exportPath).LocalPath,
                                   FileMode.Open, FileAccess.Read))
                {
                    // Create a buffer to hold the stream of bytes
                    myImageBuffer = new byte[myStream.Length];
                    // Read the bytes from this stream and put it into the image buffer
                    myStream.Read(myImageBuffer, 0, (int)myStream.Length);
                    myStream.Close();
                }

                // Restore previously saved layout
                dragCanvas.LayoutTransform = transform;

                return ResizeImage(myImageBuffer);
            }
            return null;
        }

        static public byte[] LoadImagetoByteArray(string imagePath) // Uri path, UserControl surface
        {
            byte[] myImageBuffer;
            using (FileStream myStream =
                             new FileStream(new Uri(imagePath).LocalPath,
                                            FileMode.Open, FileAccess.Read))
            {
                // Create a buffer to hold the stream of bytes
                myImageBuffer = new byte[myStream.Length];
                // Read the bytes from this stream and put it into the image buffer
                myStream.Read(myImageBuffer, 0, (int)myStream.Length);
                myStream.Dispose();
            }

            return ResizeImage(myImageBuffer);

        }

        static public byte[] ResizeImage(byte[] imageBytes)
        {
            int newWidth = 120;
            const int maxHeight = 120;

            if (imageBytes == null)
            {
                return null;
            }

            byte[] returnArray;

            System.Drawing.Image fullsizeImage;
            using (var ms = new MemoryStream(imageBytes))
            {
                fullsizeImage = System.Drawing.Image.FromStream(ms);
                ms.Dispose();
            }

            // Prevent using images internal thumbnail
            fullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
            fullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);


            if (fullsizeImage.Width <= newWidth)
            {
                newWidth = fullsizeImage.Width;
            }


            int newHeight = fullsizeImage.Height * newWidth / fullsizeImage.Width;
            if (newHeight > maxHeight)
            {
                // Resize with height instead
                newWidth = fullsizeImage.Width * maxHeight / fullsizeImage.Height;
                newHeight = maxHeight;
            }

            System.Drawing.Image newImage = fullsizeImage.GetThumbnailImage(newWidth, newHeight, null,
                                                                            IntPtr.Zero);

            // Clear handle to original file so that we can overwrite it if necessary
            fullsizeImage.Dispose();
            using (var outStream = new MemoryStream())
            {
                // Save resized picture
                newImage.Save(outStream, ImageFormat.Png);
                newImage.Dispose();
                returnArray = outStream.ToArray();
                outStream.Dispose();
            }
            return returnArray;
        }
    }
}
