using System;
using System.IO;
using System.Windows.Forms;
using Inspire.Server.SlideManager.DataAccess;
using Inspire.Server.SlideManager.DataContracts;
using SlideManger.Test.ServiceReference2;

namespace SlideManger.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Slide slide = new Slide();
         
            slide.GUID = Guid.NewGuid().ToString();
            slide.HResolution = 768;
            slide.VResolution = 1024;
            slide.Name = "Test From Test App";

            SlideDataAccess.AddSlide(slide);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SlideDataAccess.DeleteSlide("84F78B08-8185-48B8-B5EB-6D36E4F4243D");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SlideDataAccess.GetAllSlides();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SlideFileManagerServiceContractClient client = new SlideFileManagerServiceContractClient();
            
            Stream stream;
            string GUID = "7C5785DB-96F9-47C7-A324-7D142801255E";
            string slideID = client.GetSlideFile(GUID, out stream);

            byte[] bytes = ReadFully(stream, 3276856);

            int count = bytes.Length;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SlideFileManagerServiceContractClient client = new SlideFileManagerServiceContractClient();
            byte[] ret = new byte[1070];
            Stream stream = new MemoryStream(ret);

            string GUID = "7C5785DB-96F9-47C7-A324-9D1428012557";

            client.AddSlideFile(GUID,ret.Length,stream);
            int i = 1;
        }


        /// <summary>
        /// Reads data from a stream until the end is reached. The
        /// data is returned as a byte array. An IOException is
        /// thrown if any of the underlying IO calls fail.
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        /// <param name="initialLength">The initial buffer length</param>
        public static byte[] ReadFully(Stream stream, int initialLength)
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




    }
}
