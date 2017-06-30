using System;
using System.Windows.Forms;
using System.IO;
using Inspire.Server.Direction.Client.ServiceReference1;

namespace Inspire.Direction.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            DirectionServiceContractClient client = new DirectionServiceContractClient();
            dataGridView1.DataSource = client.GetAllImages();
                       
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
           // need to initialize header and position of first page.

            string filename = @"C:\test.jpg";
            FileStream infile = new FileStream(filename, FileMode.Open, FileAccess.Read);

            Byte[] test = new Byte[infile.Length];
            infile.Read(test, 0, test.Length);

            DirectionalImage image = new DirectionalImage();
            image.GUID = Guid.NewGuid().ToString();
            image.FileExtension = ".jpg";
            image.Description = "Crank Dat!";
                        
            DirectionServiceContractClient client = new DirectionServiceContractClient();

            client.AddImage(image, test);

            
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            DirectionServiceContractClient client = new DirectionServiceContractClient();
            
            DirectionalImage image = new DirectionalImage();
            image.GUID = "4BD71F8D-0567-4690-8E74-B168B0D5FF36";
            image.FileExtension= ".jpg";
            image.Description = "Crank Dat!";
            
            client.DeleteImage(image);

        }

        private void btnGetDirections_Click(object sender, EventArgs e)
        {
            DirectionServiceContractClient client = new DirectionServiceContractClient();
            dataGridView1.DataSource = client.GetDirections("5B437AAC-47CE-43DB-985C-85C4C508C673");
        }

        private void btnAddDirections_Click(object sender, EventArgs e)
        {
            //DirectionServiceContractClient client = new DirectionServiceContractClient();
            //Directions directions = new Directions();

            //Direction.Client.ServiceReference1.Direction direction = new Direction.Client.ServiceReference1.Direction();
            //direction.GUID = Guid.NewGuid().ToString();
            //direction.DisplayID = "5B437AAC-47CE-43DB-985C-85C4C508C673";
            //direction.DirectionImageID = Guid.NewGuid().ToString();
         
            //direction.Description = "Doo Doo";
            //directions.Add(direction);

            //client.AddDirection(directions);
        }

        private void btnDeleteDirection_Click(object sender, EventArgs e)
        {
            DirectionServiceContractClient client = new DirectionServiceContractClient();
            client.DeleteDirection("5B437AAC-47CE-43DB-985C-85C4C508C673");
        }
    }
}