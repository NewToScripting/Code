using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Inspire.Display.Service
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

        public static byte[] ReadFully(Stream stream, int initialLength)
        {
            byte[] buffer = new byte[initialLength];
            int read = 0;
            int chunk;

            using (stream)
            {
                while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0)
                {
                    read += chunk;

                    if (read == buffer.Length)
                    {
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
