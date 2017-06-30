//using System.ServiceModel;
//using System.Text;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using Inspire.Server.Display.ServiceImplementation;
//using Inspire.Server.DisplayAdmin.ServiceImplementation;
//using Inspire.Server.ScheduledSlideManager.ServiceImplementation;
//using Inspire.Server.ScheduleManager.ServiceImplementation;
//using Inspire.Server.SlideManager.ServiceImplementation;
//using Inspire.ServiceHost;
//using Inspire.Users.ServiceImplementation;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace ServiceTester
//{
//    /// <summary>
//    /// Summary description for UnitTest1
//    /// </summary>
//    [TestClass]
//    public class UnitTest1
//    {
//        public UnitTest1()
//        {
//            //
//            // TODO: Add constructor logic here
//            //
//        }

//        private TestContext testContextInstance;

//        /// <summary>
//        ///Gets or sets the test context which provides
//        ///information about and functionality for the current test run.
//        ///</summary>
//        public TestContext TestContext
//        {
//            get
//            {
//                return testContextInstance;
//            }
//            set
//            {
//                testContextInstance = value;
//            }
//        }

//        #region Additional test attributes
//        //
//        // You can use the following additional attributes as you write your tests:
//        //
//        // Use ClassInitialize to run code before running the first test in the class
//        // [ClassInitialize()]
//        // public static void MyClassInitialize(TestContext testContext) { }
//        //
//        // Use ClassCleanup to run code after all tests in a class have run
//        // [ClassCleanup()]
//        // public static void MyClassCleanup() { }
//        //
//        // Use TestInitialize to run code before running each test 
//        // [TestInitialize()]
//        // public void MyTestInitialize() { }
//        //
//        // Use TestCleanup to run code after each test has run
//        // [TestCleanup()]
//        // public void MyTestCleanup() { }
//        //
//        #endregion

//        [TestMethod]
//        public void StartServices()
//        {
         
//        ServiceHost ScheduleManagerService = null;
//        ServiceHost ClientDisplayService = null;
//        ServiceHost ClientDisplayPropertiesService = null;
//        ServiceHost ClientDisplayGroupsService = null;
//        ServiceHost SlideManagerService = null;
//        ServiceHost SlideFileManagerService = null;
//        ServiceHost ScheduledSlideManagerService = null;
//        ServiceHost UserService = null;
//        ServiceHost DisplayAdminService = null;

   
//            if (ScheduleManagerService != null) { ScheduleManagerService.Close(); }
//            if (ClientDisplayService != null) { ClientDisplayService.Close(); }
//            if (ClientDisplayPropertiesService != null) { ClientDisplayPropertiesService.Close(); }
//            if (ClientDisplayGroupsService != null) { ClientDisplayGroupsService.Close(); }
//            if (SlideManagerService != null) { SlideManagerService.Close(); }
//            if (SlideFileManagerService != null) { SlideFileManagerService.Close(); }
//            if (ScheduledSlideManagerService != null) { ScheduledSlideManagerService.Close(); }
//            if (UserService != null) { UserService.Close(); }
//            if (DisplayAdminService != null) { DisplayAdminService.Close(); }

//            // Create a ServiceHost for the CalculatorService type and 
//            // provide the base address.
//            ScheduleManagerService = new ServiceHost(typeof(Inspire.Server.ScheduleManager.ServiceImplementation.ScheduleManagerService));
//            ClientDisplayService = new ServiceHost(typeof(Inspire.Server.Display.ServiceImplementation.ClientDisplayService));
//            ClientDisplayPropertiesService = new ServiceHost(typeof(Inspire.Server.Display.ServiceImplementation.ClientDisplayPropertiesService));
//            ClientDisplayGroupsService = new ServiceHost(typeof(Inspire.Server.Display.ServiceImplementation.ClientDisplayGroupsService));

//            //Had to reference the Slide Manager DLL in the bin forlder for some reason, not the project...was giving error...
//            SlideManagerService = new ServiceHost(typeof(Inspire.Server.SlideManager.ServiceImplementation.SlideManagerService));
//            SlideFileManagerService = new ServiceHost(typeof(Inspire.Server.SlideManager.ServiceImplementation.SlideFileManagerService));

//            ScheduledSlideManagerService = new ServiceHost(typeof(Inspire.Server.ScheduledSlideManager.ServiceImplementation.ScheduledSlideManagerService));
//            UserService = new ServiceHost(typeof(Inspire.Users.ServiceImplementation.UserService));
//            DisplayAdminService = new ServiceHost(typeof(Inspire.Server.DisplayAdmin.ServiceImplementation.DisplayAdminService));



//            // Open the ServiceHostBase to create listeners and start 
//            // listening for messages.
//            ScheduleManagerService.Open();
//            ClientDisplayService.Open();
//            ClientDisplayPropertiesService.Open();
//            ClientDisplayGroupsService.Open(); 
//            SlideManagerService.Open(); 
//            SlideFileManagerService.Open();
//            ScheduledSlideManagerService.Open();
//            UserService.Open();
//            DisplayAdminService.Open();

          
//            ScheduleManagerService.Close();
//            ClientDisplayService.Close();
//            ClientDisplayPropertiesService.Close();
//            ClientDisplayGroupsService.Close();
//            SlideManagerService.Close();
//            SlideFileManagerService.Close();
//            ScheduledSlideManagerService.Close();
//            UserService.Close();
//            DisplayAdminService.Close();

            
//        }
        
//        [TestMethod]
//        public void TestMethod1()
//        {

//        }
//        [TestMethod]
//        public void TestMethod2()
//        {

//        }
//        [TestMethod]
//        public void TestMethod3()
//        {

//        }
//    }
//}
