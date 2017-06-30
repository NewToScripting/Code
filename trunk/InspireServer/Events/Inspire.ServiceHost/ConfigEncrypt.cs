//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Configuration;

//namespace Inspire.ServiceHost
//{
//    public class ConfigEncrypt
//    {
//        public static void Encrypt()
//        {
//            // Takes the executable file name without the
//            // .config extension.
//            try
//            {
//                // Open the configuration file and retrieve 
//                // the connectionStrings section.
//                string appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

//                Configuration config = ConfigurationManager.OpenExeConfiguration("Inspire.Server.ServiceHost.exe");

//                ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;

//                if (!section.SectionInformation.IsProtected)
//                {                    
//                    // Encrypt the section.
//                    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
//                }
//                // Save the current configuration.
//                config.Save();
               
//            }
//            catch (Exception ex)
//            {
                
//            }
//        }



//    }
//}
