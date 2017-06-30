using System;
using System.ComponentModel;
using System.IO;

namespace Inspire.Server.Proxy
{
    public class StreamToBytes
    {
        /// <summary>
        /// Reads data from a stream until the end is reached. The
        /// data is returned as a byte array. An IOException is
        /// thrown if any of the underlying IO calls fail.
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        /// <param name="initialLength">The initial buffer length</param>
        public static byte[] ReadFully2(Stream stream, int initialLength)
        {
            // If we've been passed an unhelpful initial length, just
            // use 32K.
            if (initialLength < 1)
            {
                initialLength = 32768;
            }

            byte[] buffer = new byte[initialLength];
            int read = 0;

            int chunk;
            while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0)
            {
                read += chunk;

                // If we've reached the end of our buffer, check to see if there's
                // any more information
                if (read == buffer.Length)
                {
                    int nextByte = stream.ReadByte();

                    // End of stream? If so, we're done
                    if (nextByte == -1)
                    {
                        return buffer;
                    }

                    // Nope. Resize the buffer, put in the byte we've just
                    // read, and continue
                    byte[] newBuffer = new byte[buffer.Length * 2];
                    Array.Copy(buffer, newBuffer, buffer.Length);
                    newBuffer[read] = (byte)nextByte;
                    buffer = newBuffer;
                    read++;
                }
            }
            // Buffer is now too big. Shrink it.
            byte[] ret = new byte[read];
            Array.Copy(buffer, ret, read);
            return ret;
        }


        /// <summary>
        /// Reads data from a stream until the end is reached. The
        /// data is returned as a byte array. An IOException is
        /// thrown if any of the underlying IO calls fail.
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        /// <param name="initialLength">The initial buffer length</param>
        /// <param name="worker"></param>
        /// <param name="reportBack"></param>
        public static byte[] ReadFully(Stream stream, int initialLength, BackgroundWorker worker, bool reportBack)
        {
            byte[] buffer = new byte[initialLength];
            int read = 0;
            int chunk;

            using (stream)
            {
                while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0)
                {
                    if (read.Equals(0))
                    {
                        if (reportBack)
                            worker.ReportProgress(0, "Downloading files.");
                    }
                    else
                    {
                        if (reportBack)
                        {
                            var progress = Convert.ToInt32((read * 100) / buffer.Length);
                            worker.ReportProgress(progress, "Downloading files.");
                        }
                    }

                    read += chunk;

                    if (read == buffer.Length)
                    {
                        if(reportBack)
                            worker.ReportProgress(100, "Download Completed.");
                        stream.Dispose();
                        return buffer;
                    }

                }
            }

            stream.Dispose();
            return buffer;
        }
        


        }
    }

