using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.RegServiceReference;

namespace TestProject
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            RegistrationRequestMessage request = new RegistrationRequestMessage();
            RegistrationResponseMessage response = new RegistrationResponseMessage();

            request.Address1 = "123 Butthead circle";
            request.Address2 = "#1";
            request.City= "Clearwater";
            request.CompanyName = "Turd Farmers Inc.";
            request.Email = "this@isatest.com";
            request.FirstName = "Jeremy";
            request.LastName = "Haveard";
            request.Phone = "727-444-4444";
            request.RegKey = Guid.Empty;
            request.State = "FL";
            request.Zip = "33333";

            RegistrationServiceClient reg = new RegistrationServiceClient();

            response = reg.Register(request);



        }

        [TestMethod]
        public void TestMethod2()
        {
            //
            // TODO: Add test logic here
            //
        }
    }
}
