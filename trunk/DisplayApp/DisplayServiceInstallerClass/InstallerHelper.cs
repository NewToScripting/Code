using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace DisplayServiceInstallerClass
{
    public class InstallerHelper
    {
        /// <summary>
        /// Configure Inspire user as admin
        /// </summary>
        /// <param name="user"></param>
        /// <param name="dirEntry"></param>
        /// <returns></returns>
        private static bool SetAdminUserAsAdmin(DirectoryEntry user, DirectoryEntry dirEntry)
        {
            try
            {
                DirectoryEntry grp;
                grp = dirEntry.Children.Find("Administrators", "group");
                if (grp != null) { grp.Invoke("Add", new object[] { user.Path.ToString() }); }
                return true;
            }
            catch
            {
                return false;
            }

        }//function

        /// <summary>
        /// Create Inspire Admin account
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static bool CreateAdminUserAccount(string login, string password, string fullName)
        {

            DirectoryEntry dirEntry = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
            DirectoryEntries entries = dirEntry.Children;

            try
            {
                DirectoryEntry existingUser = entries.Find(login);
                //Add exisiting user to admin group
                SetAdminUserAsAdmin(existingUser, dirEntry);
                
            }
            catch
            {
                try
                {
                    //User does not exist, add user to system
                    DirectoryEntry newUser = entries.Add(login, "user");
                    newUser.Properties["FullName"].Add(fullName);
                    newUser.Invoke("SetPassword", password);
                    newUser.CommitChanges();

                    SetAdminUserAsAdmin(newUser, dirEntry);                                       
                }
                catch 
                {                    
                   return false;
                }              
                
            }
            return true;
        }//function

        /// <summary>
        /// Remove Inspire Admin account
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static bool RemoveAdminUserAccount(string login)
        {

            DirectoryEntry dirEntry = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
            DirectoryEntries entries = dirEntry.Children;

            try
            {
                DirectoryEntry existingUser = entries.Find(login);
                entries.Remove(existingUser);
                existingUser.CommitChanges();
                return true;
            }
            catch
            {
                return true;
                //errors but still removes account               
            }

        }//function

        /// <summary>
        /// Create Inspire application pool
        /// </summary>
        /// <param name="metabasePath"></param>
        /// <param name="appPoolName"></param>
        /// <returns></returns>
        public static bool CreateAppPool(string metabasePath, string appPoolName)
        {
            //  metabasePath is of the form "IIS://<servername>/W3SVC/AppPools"
            //    for example "IIS://localhost/W3SVC/AppPools" 
            //  appPoolName is of the form "<name>", for example, "MyAppPool"
            //Console.WriteLine("\nCreating application pool named {0}/{1}:", metabasePath, appPoolName);

            DirectoryEntry newpool;
            DirectoryEntry apppools = new DirectoryEntry(metabasePath);

            try
            {
                DirectoryEntry existingpool;
                existingpool = apppools.Children.Find(appPoolName, "IIsApplicationPool");                
            }
            catch
            {
                try
                {   newpool = apppools.Children.Add(appPoolName, "IIsApplicationPool");
                    DirectoryEntry dirEntry = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
                    newpool.CommitChanges();                                       
                }
                catch 
                {
                    return false;
                }               
            }
            return true; 
        }

        /// <summary>
        /// Remove application pool
        /// </summary>
        /// <param name="metabasePath"></param>
        /// <param name="appPoolName"></param>
        /// <returns></returns>
        public static bool RemoveAppPool(string metabasePath, string appPoolName)
        {
            //  metabasePath is of the form "IIS://<servername>/W3SVC/AppPools"
            //    for example "IIS://localhost/W3SVC/AppPools" 
            //  appPoolName is of the form "<name>", for example, "MyAppPool"
            //Console.WriteLine("\nCreating application pool named {0}/{1}:", metabasePath, appPoolName);

            DirectoryEntry apppools = new DirectoryEntry(metabasePath);

            try
            {
                DirectoryEntry existingpool;
                existingpool = apppools.Children.Find(appPoolName, "IIsApplicationPool");
                apppools.Children.Remove(existingpool);
                existingpool.CommitChanges();
                return true;
            }
            catch
            {
                return true; 
                //always errors but removes the pool
            }
        }

        /// <summary>
        /// Assign virtual directory to application pool
        /// </summary>
        /// <param name="metabasePath"></param>
        /// <param name="appPoolName"></param>
        /// <returns></returns>
        public static bool AssignVDirToAppPool(string metabasePath, string appPoolName)
        {
            //  metabasePath is of the form "IIS://<servername>/W3SVC/<siteID>/Root[/<vDir>]"
            //    for example "IIS://localhost/W3SVC/1/Root/MyVDir" 
            //  appPoolName is of the form "<name>", for example, "MyAppPool"
            //Console.WriteLine("\nAssigning application {0} to the application pool named {1}:", metabasePath, appPoolName);

            try
            {
                DirectoryEntry vDir = new DirectoryEntry(metabasePath);
                string className = vDir.SchemaClassName.ToString();

                object[] param = { 0, appPoolName, true };
                vDir.Invoke("AppCreate3", param);
                vDir.Properties["AppIsolated"][0] = "2";
                return true;
            }

            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Create virtual directory
        /// </summary>
        /// <param name="metabasePath"></param>
        /// <param name="vDirName"></param>
        /// <param name="physicalPath"></param>
        /// <returns></returns>
        public static bool CreateVDir(string metabasePath, string vDirName, string physicalPath)
        {
            //  metabasePath is of the form "IIS://<servername>/<service>/<siteID>/Root[/<vdir>]"
            //    for example "IIS://localhost/W3SVC/1/Root" 
            //  vDirName is of the form "<name>", for example, "MyNewVDir"
            //  physicalPath is of the form "<drive>:\<path>", for example, "C:\Inetpub\Wwwroot"
            //Console.WriteLine("\nCreating virtual directory {0}/{1}, mapping the Root application to {2}:",metabasePath, vDirName, physicalPath);

            try
            {
                DirectoryEntry site = new DirectoryEntry(metabasePath);
                string className = site.SchemaClassName.ToString();
                if ((className.EndsWith("Server")) || (className.EndsWith("VirtualDir")))
                {
                    DirectoryEntries vdirs = site.Children;
                    DirectoryEntry newVDir = vdirs.Add(vDirName, (className.Replace("Service", "VirtualDir")));
                    newVDir.Properties["Path"][0] = physicalPath;
                    newVDir.Properties["AccessScript"][0] = true;
                    // These properties are necessary for an application to be created.
                    newVDir.Properties["AppFriendlyName"][0] = vDirName;
                    newVDir.Properties["AppIsolated"][0] = "1";
                    newVDir.Properties["AppRoot"][0] = "/LM" + metabasePath.Substring(metabasePath.IndexOf("/", ("IIS://".Length)));

                    newVDir.CommitChanges();                    

                }
                return true;
            }
            catch
            {
                return false;
            }


        }
   
        /// <summary>
        /// Delete virtual directory
        /// </summary>
        /// <param name="VirtualDirName"></param>
        /// <returns></returns>
        public static bool DeleteVirtualDirectory(string VirtualDirName)
        {
            try
            {
                DirectoryEntry Parent = new DirectoryEntry(@"IIS://localhost/W3SVC/1/Root");
                Object[] Parameters = { "IIsWebVirtualDir", VirtualDirName };
                Parent.Invoke("Delete", Parameters);
                return true;
            }
            catch 
            {
                return false;
            }          
        }

        /// <summary>
        /// Create application pool creds
        /// </summary>
        /// <param name="metabasePath"></param>
        /// <param name="appPoolName"></param>
        /// <param name="appPoolUser"></param>
        /// <param name="appPoolPass"></param>
        /// <returns></returns>
        public static bool ChangeAppPoolCreds(string metabasePath, string appPoolName, string appPoolUser, string appPoolPass)
        {
            /*modify metabasePath, appPoolName, appPoolUser and appPoolPass */

            DirectoryEntry newpool;
            DirectoryEntry apppools = new DirectoryEntry(metabasePath);

            try
            {
                newpool = apppools.Children.Find(appPoolName, "IIsApplicationPool");
                newpool.InvokeSet("AppPoolIdentityType", new Object[] { 3 });
                newpool.InvokeSet("WAMUserName", new Object[] { Environment.MachineName + @"\" + appPoolUser });
                newpool.InvokeSet("WAMUserPass", new Object[] { appPoolPass });
                newpool.Invoke("SetInfo", null);
                newpool.CommitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

       /// <summary>
       /// Add httpruntime node to machine.config
       /// </summary>
       /// <returns></returns>
        public static bool AddNodeToMachineConfig()
        {

            // Load the machine.config file into the XML document
            Uri baseUri = new Uri(typeof(string).Assembly.Location);
            Uri uri = new Uri(baseUri, "config\\machine.config");
            XmlDocument doc = new XmlDocument();
            doc.Load(uri.AbsolutePath);
            try
            {
                XmlNode httpnode = doc.SelectSingleNode("configuration/system.web/httpRuntime");
                
                if (httpnode == null)

                { 
                    // Finds the right node and change it to the new value.
                    XmlNode node = doc.SelectSingleNode("configuration/system.web");
                    //if (node == null)
                    //{
                    XmlAttribute maxLength = doc.CreateAttribute("maxRequestLength");
                    maxLength.Value = "2097151";

                    XmlNode httpRuntimeNode = doc.CreateNode(XmlNodeType.Element, "httpRuntime", "");  //httpRuntime
                    httpRuntimeNode.Attributes.Append(maxLength);

                    node.AppendChild(httpRuntimeNode);

                    doc.Save(uri.AbsolutePath);
                }

               return true;

            }
            catch (Exception)
            {
                return false;
            }
           
                  
        }

        /// <summary>
        /// Remove httpruntime node to machine.config
        /// </summary>
        /// <returns></returns>
        public static bool RemoveNodeFromMachineConfig()
        {

            // Load the machine.config file into the XML document
            Uri baseUri = new Uri(typeof(string).Assembly.Location);
            Uri uri = new Uri(baseUri, "config\\machine.config");
            XmlDocument doc = new XmlDocument();
            doc.Load(uri.AbsolutePath);
            try
            {
                XmlNode node = doc.SelectSingleNode("configuration/system.web/httpRuntime");
                node.ParentNode.RemoveChild(node);
                doc.Save(uri.AbsolutePath);
                return true;              
               
            }
            catch (Exception)
            {
                return false;
            }          
        }


        //public static bool CheckForIIS6Compatibility()
        //{
        //    string registryKey = @"Software\Microsoft\InetStp\Components\ASPNET";

        //    RegistryKey subKey = Registry.LocalMachine.OpenSubKey(registryKey);

        //    if (subKey == null)
        //        return false;
        //    else
        //        return true;

        //}

    }//class
}//namespace
