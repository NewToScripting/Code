using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Events.Unit.Tests.EventServiceReference;
//using Inspire.Server.Events.DataAccess;


namespace Events.Unit.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class EventTests
    {
        private HospitalityEvent testEvent;
        private HospitalityEventDefinition eventDef;

        public EventTests()
        {
            testEvent = new HospitalityEvent();
            testEvent.EventId = Guid.NewGuid().ToString();
            testEvent.EventDefinitionId = Guid.NewGuid().ToString();
            testEvent.MeetingName = "test";


            eventDef = new HospitalityEventDefinition();
            //eventDef.EventId = Guid.NewGuid().ToString();
            //eventDef.EventDefinitionId = Guid.NewGuid().ToString();
            
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

       // [TestMethod]
        //public void AddEventUsingEndpoint()
        //{
        //    EventServiceContractClient client = new EventServiceContractClient();
        //    client.AddEvent(testEvent);
        //}


        //[TestMethod]
        //public void AddEventUsingEndpoint()
        //{
        //    EventServiceContractClient client = new EventServiceContractClient();
        //    client.AddEvent(testEvent);
        //}

        [TestMethod]
        public void GetEventsUsingEndpoint()
        {
            EventServiceContractClient client = new EventServiceContractClient();
            List<HospitalityEvent> events = client.GetEvents("B7EA503D-A29B-4F0D-827E-F1983FD0FDD7");
            Assert.IsNotNull(events);
        }

        //[TestMethod]
        //public void DeleteEventUsingEndpoint()
        //{
        //    EventServiceContractClient client = new EventServiceContractClient();
        //    client.DeleteEvent("013E7964-EC48-4400-A72B-02B50F323AC8");
        //}
        
              
        //[TestMethod]
        //public void AddEventDefinitionUsingEndpoint()
        //{
        //    EventServiceContractClient client = new EventServiceContractClient();
        //    client.AddEventDefinition(eventDef);
        //}

        //[TestMethod]
        //public void GetEventDefinitionsUsingEndpoint()
        //{
        //    EventServiceContractClient client = new EventServiceContractClient();
        //    List<HospitalityEventDefinition> events = client.GetEventDefinitions();
        //    Assert.IsNotNull(events);
        //}

        //[TestMethod]
        //public void DeleteEventDefinitionsUsingEndpoint()
        //{
        //    EventServiceContractClient client = new EventServiceContractClient();
        //    client.GetEventDefinitions("0C0C0B0E-7B40-4D7D-A7AB-65C3DD1BABD2");
        //}


        //[TestMethod]
        //public void GetEventFilteredUsingEndpoint()
        //{
        //    EventServiceContractClient client = new EventServiceContractClient();
        //    HospitalityEvents events = client.GetEventsFiltered("B7EA503D-A29B-4F0D-827E-F1983FD0FDD7", "display01");

        //}


        //[TestMethod]
        //public void GetEventNonFilteredUsingEndpoint()
        //{
        //    EventServiceContractClient client = new EventServiceContractClient();
        //    HospitalityEvents events = client.GetEventsNonFiltered("c7ea503d-a29b-4f0d-827e-f1983fd0fdd7", "97.76.187.195");
        //}

        //[TestMethod]
        //public void LoadNewEvents()
        //{
        //    EventServiceContractClient client = new EventServiceContractClient();
        //    client.LoadEvents();

        //}

        //[TestMethod]
        //public void GetDefaultEventDefinitionUsingEndpoint()
        //{
        //    HospitalityEventDefinition def = new HospitalityEventDefinition();

        //    EventServiceContractClient client = new EventServiceContractClient();
        //    def = client.GetDefaultEventDefinition();
        //}

        //[TestMethod]
        //public void GetEventFileFormatsUsingEndpoint()
        //{
        //    EventFileFormats items = new EventFileFormats();
        //    EventServiceContractClient client = new EventServiceContractClient();
        //    items = client.GetEventFileFormats();
        //}

        //[TestMethod]
        //public void GetEventFileFormatUsingEndpoint()
        //{
        //    EventFileFormat item = new EventFileFormat();
        //    EventServiceContractClient client = new EventServiceContractClient();
        //    item = client.GetEventFileFormat("1C7768D9-DAA4-432C-A9B4-6237A3969F84");
        //}

        //[TestMethod]
        //public void AddEventFileFormatUsingEndpoint()
        //{
        //    EventFileFormat item = new EventFileFormat();
        //    item.EventFileFormatGuid = Guid.NewGuid().ToString();
        //    item.EventFormatName = "test";

        //    EventServiceContractClient client = new EventServiceContractClient();
        //    client.AddEventFileFormat(item);
        //}

        //[TestMethod]
        //public void UpdateEventFileFormatUsingEndpoint()
        //{
        //    EventFileFormat item = new EventFileFormat();
        //    item.EventFileFormatGuid = "DDECB56F-EDB5-453D-A716-803293FA3696";
        //    item.EventFormatName = "updated";
                        
        //    EventServiceContractClient client = new EventServiceContractClient();
        //    client.UpdateEventFileFormat(item);
        //}


        //[TestMethod]
        //public void DeleteEventFileFormatUsingEndpoint()
        //{
        //    EventServiceContractClient client = new EventServiceContractClient();
        //    client.DeleteEventFileFormat("A8F8FB4D-E2C4-42E9-94FD-96CD81B3A539");
        //}

        //[TestMethod]
        //public void AddEventFileFormatUsingEndpoint()
        //{

        //    EventFileFormat item = new EventFileFormat();
        //    item.EventFileFormatGuid = Guid.NewGuid().ToString();

        //    FieldContract i = new FieldContract();

        //    i.GUID = Guid.NewGuid().ToString();
        //    i.Name = "test";
        //    i.Value = "test";
        //    i.EventFileFormatGuid = item.EventFileFormatGuid;


        //    item.FieldContracts = new FieldContracts();
        //    item.FieldContracts.Add(i);

        //    EventServiceContractClient client = new EventServiceContractClient();
        //    client.AddEventFileFormat(item);
        //}






    }
}
