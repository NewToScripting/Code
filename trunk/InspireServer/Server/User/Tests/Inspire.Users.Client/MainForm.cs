using System;
using System.Windows.Forms;
using Inspire.Server.Users.Client.ServiceReference1;

namespace Inspire.Users.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            //TODO: Call proxy method
        }

        private void btnGetUsers_Click(object sender, EventArgs e)
        {
            UserServiceContractClient client = new UserServiceContractClient();
            dataGridView1.DataSource = client.GetUsers();


        }
    }
}