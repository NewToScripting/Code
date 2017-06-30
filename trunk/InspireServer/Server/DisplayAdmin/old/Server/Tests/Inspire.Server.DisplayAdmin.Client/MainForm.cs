//using System;
//using System.Drawing;
//using System.Windows.Forms;
//using System.IO;
//using Inspire.Server.DisplayAdmin.BusinessLogic;
//using Inspire.Server.Services.Client.ServiceReference1;


//namespace Inspire.Server.DisplayAdmin.Client
//{
//    public partial class MainForm : Form
//    {
//        public MainForm()
//        {
//            InitializeComponent();
//        }


//        private void SaveStreamToFile(Byte[] stream, String fileName)
//        {
//            using (FileStream file = new FileStream(fileName, FileMode.Create)) 
//            {
//                file.Write(stream, 0, stream.Length);
//                file.Flush();
//                file.Close();
//            }
//        }

//        public static Image ConvertByteArrayToImage(byte[] byteArray)
//        {
//            if (byteArray != null)
//            {
//                MemoryStream ms = new MemoryStream(byteArray, 0,
//                byteArray.Length);
//                ms.Write(byteArray, 0, byteArray.Length);
//                return Image.FromStream(ms, true);
//            }
//            return null;
//        }

       

//        private void button3_Click(object sender, EventArgs e)
//        {
//            DisplayAdminServiceContractClient client = new DisplayAdminServiceContractClient();
//            client.UpdateDisplays();
//        }

//        private void button4_Click(object sender, EventArgs e)
//        {
//            ResourceAccess.UpdateDisplays();
//        }

      
       

       

//    }
//}

