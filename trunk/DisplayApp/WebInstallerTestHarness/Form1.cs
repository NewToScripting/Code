using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DisplayServiceInstallerClass;

namespace WebInstallerTestHarness
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            InstallerHelper.CreateAdminUserAccount("InspireAdmin", "PooPoo8", "Inspire Admin");
            //MessageBox.Show("Create App Pool");
            //InstallerHelper.CreateAppPool("IIS://localhost/W3SVC/AppPools", "InspireAppPool");
            //MessageBox.Show("App Pool Creds...");
            //InstallerHelper.ChangeAppPoolCreds("IIS://localhost/W3SVC/AppPools", "InspireAppPool", "InspireAdmin", "PooPoo8");
            //MessageBox.Show("Assign VDir to AppPool");
            //InstallerHelper.AssignVDirToAppPool("IIS://localhost/W3SVC/1/Root/Inspire", "InspireAppPool");
            //this.Context.Parameters["TARGETDIR"] = "C:\test";   

            //bool test = InstallerHelper.CheckForIIS6Compatibility();
            //MessageBox.Show(test.ToString());



        


        }

        private void button2_Click(object sender, EventArgs e)
        {
            InstallerHelper.RemoveAdminUserAccount("InspireAdmin");
        }

        private void button3_Click(object sender, EventArgs e)
        {                  
            bool test = InstallerHelper.AddNodeToMachineConfig();
        }

        private void button4_Click(object sender, EventArgs e)
        {
              bool test = InstallerHelper.RemoveNodeFromMachineConfig();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InstallerHelper.CreateVDir("IIS://localhost/W3SVC/1/Root", "Inspire", "C:/");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InstallerHelper.DeleteVirtualDirectory("Inspire");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            InstallerHelper.RemoveAppPool("IIS://localhost/W3SVC/AppPools", "InspireAppPool");
        }
    }
}
