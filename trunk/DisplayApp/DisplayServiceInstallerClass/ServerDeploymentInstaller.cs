using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Collections.Specialized;
using System.Windows.Forms;


namespace DisplayServiceInstallerClass
{
    [RunInstaller(true)]
    public partial class ServerDeploymentInstaller : Installer
    {
        public ServerDeploymentInstaller()
        {
            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
                       
            bool successful = true; 

            //successful = InstallerHelper.AddNodeToMachineConfig();
            //if (!successful)
            //{
            //    MessageBox.Show("Error adding node to Machine.config");
            //    successful = true;
            //}

            successful = InstallerHelper.CreateAdminUserAccount("InspireAdmin", "PooPoo8", "Inspire Admin");
            if (!successful)
            {
                MessageBox.Show("Error creating Admin User Account");
                successful = true;
            }
            
            successful = InstallerHelper.CreateAppPool("IIS://localhost/W3SVC/AppPools", "InspireAppPool");
            if (!successful)
            {
                MessageBox.Show("Error creating app pool");
                successful = true;
            }

            
            successful = InstallerHelper.ChangeAppPoolCreds("IIS://localhost/W3SVC/AppPools", "InspireAppPool", "InspireAdmin", "PooPoo8");
            if (!successful)
            {
                MessageBox.Show("Error setting app pool creds");
                successful = true;
            }
                       
            
            successful = InstallerHelper.CreateVDir("IIS://localhost/W3SVC/1/Root", "Inspire.Server", "C:/Program Files/Inspire/Server/Endpoint");
            if (!successful)
            {
                MessageBox.Show("Error creating virtual directory");
                successful = true;
            }

            
            successful = InstallerHelper.AssignVDirToAppPool("IIS://localhost/W3SVC/1/Root/Inspire.Server", "InspireAppPool");
            if (!successful)
            {
                MessageBox.Show("Error assigning app pool to virtual directory");
                successful = true;
            }
            
         
        }       

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);

            bool successful = true; 

            //successful = InstallerHelper.RemoveNodeFromMachineConfig();
            //if (!successful)
            //{
            //    MessageBox.Show("Error removing node from Machine.config");
            //    successful = true;
            //}               
            
            successful = InstallerHelper.DeleteVirtualDirectory("Inspire.Server");
            if (!successful)
            {
                MessageBox.Show("Error removing virtual directory");
                successful = true;
            }
            
            successful = InstallerHelper.RemoveAppPool("IIS://localhost/W3SVC/AppPools", "InspireAppPool");
            if (!successful)
            {
                MessageBox.Show("Error removing app pool");
                successful = true;
            }

            successful = InstallerHelper.RemoveAdminUserAccount("Inspire Admin");
            if (!successful)
            {
                MessageBox.Show("Error removing Admin User Account");
                successful = true;
            }     

        }

        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);

            bool successful = true; 

            //successful = InstallerHelper.RemoveNodeFromMachineConfig();
            //if (!successful)
            //{
            //    MessageBox.Show("Error removing node from Machine.config");
            //    successful = true;
            //}

            successful = InstallerHelper.DeleteVirtualDirectory("Inspire.Server");
            if (!successful)
            {
                MessageBox.Show("Error removing virtual directory");
                successful = true;
            }


            successful = InstallerHelper.RemoveAppPool("IIS://localhost/W3SVC/AppPools", "InspireAppPool");
            if (!successful)
            {
                MessageBox.Show("Error removing app pool");
                successful = true;
            }

            successful = InstallerHelper.RemoveAdminUserAccount("InspireAdmin");
            if (!successful)
            {
                MessageBox.Show("Error removing Admin User Account");
                successful = true;
            }

        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
       }
              
  
    }//class    
   
}//namespace
