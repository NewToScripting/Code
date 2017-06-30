using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Windows.Threading;
using System.Xml.XPath;
using Inspire.Events.Proxy;
using Inspire.Services.WeakEventHandlers;

namespace EventsModule.EventTemplates
{
    /// <summary>
    /// Interaction logic for EventStack.xaml
    /// </summary>
    public partial class EventStack : INotifyPropertyChanged, IWeakEventListener, IDisposable
    {
        #region private

        private readonly DispatcherTimer loopTimer = new DispatcherTimer();

        private XElement eventsXML;

        private readonly List<FeedEntry> eventList = new List<FeedEntry>();

        private bool pullFeedFlag = true;

        private FeedEntry row1;
        private FeedEntry row2;
        private FeedEntry row3;
        private FeedEntry row4;
        private FeedEntry row5;
        private FeedEntry row6;
        private FeedEntry row7;
        private FeedEntry row8;
        private FeedEntry row9;
        private FeedEntry row10;
        private FeedEntry row11;
        private FeedEntry row12;
        private FeedEntry row13;
        private FeedEntry row14;
        private FeedEntry row15;
        private FeedEntry row16;
        private FeedEntry row17;
        private FeedEntry row18;
        private FeedEntry row19;
        private FeedEntry row20;

        private FeedEntry dummyrow1;
        private FeedEntry dummyrow2;
        private FeedEntry dummyrow3;
        private FeedEntry dummyrow4;
        private FeedEntry dummyrow5;
        private FeedEntry dummyrow6;
        private FeedEntry dummyrow7;
        private FeedEntry dummyrow8;
        private FeedEntry dummyrow9;
        private FeedEntry dummyrow10;
        private FeedEntry dummyrow11;
        private FeedEntry dummyrow12;
        private FeedEntry dummyrow13;
        private FeedEntry dummyrow14;
        private FeedEntry dummyrow15;
        private FeedEntry dummyrow16;
        private FeedEntry dummyrow17;
        private FeedEntry dummyrow18;
        private FeedEntry dummyrow19;
        private FeedEntry dummyrow20;

        private IEnumerable<XElement> itemsXML;

        private int cycleCount;

        private int currentCycle;

        private readonly int pageSeconds = 7;

        private readonly int templateRows = 5;

        private const string templateKey = "eventTemplate";

        private readonly Uri templateName;

        private readonly string displayGuid;

        private readonly string serverName;

        private readonly string sourceGuid;

        private readonly string filterStatus;

        private ControlTemplate eventTemplate1;

        #endregion

        #region Properties

        public static readonly RoutedEvent ChangeDataEvent = EventManager.RegisterRoutedEvent("ChangeData", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FrameworkElement));

        // Provide CLR accessors for the event
        public event RoutedEventHandler ChangeData
        {
            add { AddHandler(ChangeDataEvent, value); }
            remove { RemoveHandler(ChangeDataEvent, value); }
        }

        // This method raises the Tap event
        void RaiseChangeDataEvent()
        {
            if (EventTemplate != null)
            {
                try
                {
                    var newEventArgs = new RoutedEventArgs(ChangeDataEvent);
                    itemsControl.RaiseEvent(newEventArgs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + ": " + DateTime.Now);
                    //throw;
                }
            }
        }


        public ControlTemplate EventTemplate
        {
            get { return eventTemplate1; }
            set
            {
                if (value != eventTemplate1)
                {
                    eventTemplate1 = value;
                    OnPropertyChanged("EventTemplate");
                }
            }
        }

        #region Row Definitions

        public FeedEntry Row1
        {
            get { return row1; }
            set
            {
                if (value != row1)
                {
                    row1 = value;
                    OnPropertyChanged("Row1");
                }
            }
        }

        public FeedEntry Row2
        {
            get { return row2; }
            set
            {
                if (value != row2)
                {
                    row2 = value;
                    OnPropertyChanged("Row2");
                }
            }
        }

        public FeedEntry Row3
        {
            get { return row3; }
            set
            {
                if (value != row3)
                {
                    row3 = value;
                    OnPropertyChanged("Row3");
                }
            }
        }

        public FeedEntry Row4
        {
            get { return row4; }
            set
            {
                if (value != row4)
                {
                    row4 = value;
                    OnPropertyChanged("Row4");
                }
            }
        }

        public FeedEntry Row5
        {
            get { return row5; }
            set
            {
                if (value != row5)
                {
                    row5 = value;
                    OnPropertyChanged("Row5");
                }
            }
        }

        public FeedEntry Row6
        {
            get { return row6; }
            set
            {
                if (value != row6)
                {
                    row6 = value;
                    OnPropertyChanged("Row6");
                }
            }
        }

        public FeedEntry Row7
        {
            get { return row7; }
            set
            {
                if (value != row7)
                {
                    row7 = value;
                    OnPropertyChanged("Row7");
                }
            }
        }

        public FeedEntry Row8
        {
            get { return row8; }
            set
            {
                if (value != row8)
                {
                    row8 = value;
                    OnPropertyChanged("Row8");
                }
            }
        }

        public FeedEntry Row9
        {
            get { return row9; }
            set
            {
                if (value != row9)
                {
                    row9 = value;
                    OnPropertyChanged("Row9");
                }
            }
        }

        public FeedEntry Row10
        {
            get { return row10; }
            set
            {
                if (value != row10)
                {
                    row10 = value;
                    OnPropertyChanged("Row10");
                }
            }
        }

        public FeedEntry Row11
        {
            get { return row11; }
            set
            {
                if (value != row11)
                {
                    row11 = value;
                    OnPropertyChanged("Row11");
                }
            }
        }

        public FeedEntry Row12
        {
            get { return row12; }
            set
            {
                if (value != row12)
                {
                    row12 = value;
                    OnPropertyChanged("Row12");
                }
            }
        }

        public FeedEntry Row13
        {
            get { return row13; }
            set
            {
                if (value != row13)
                {
                    row13 = value;
                    OnPropertyChanged("Row13");
                }
            }
        }

        public FeedEntry Row14
        {
            get { return row14; }
            set
            {
                if (value != row14)
                {
                    row14 = value;
                    OnPropertyChanged("Row14");
                }
            }
        }

        public FeedEntry Row15
        {
            get { return row15; }
            set
            {
                if (value != row5)
                {
                    row15 = value;
                    OnPropertyChanged("Row15");
                }
            }
        }

        public FeedEntry Row16
        {
            get { return row16; }
            set
            {
                if (value != row16)
                {
                    row16 = value;
                    OnPropertyChanged("Row16");
                }
            }
        }

        public FeedEntry Row17
        {
            get { return row17; }
            set
            {
                if (value != row17)
                {
                    row17 = value;
                    OnPropertyChanged("Row17");
                }
            }
        }

        public FeedEntry Row18
        {
            get { return row18; }
            set
            {
                if (value != row18)
                {
                    row18 = value;
                    OnPropertyChanged("Row18");
                }
            }
        }

        public FeedEntry Row19
        {
            get { return row19; }
            set
            {
                if (value != row19)
                {
                    row19 = value;
                    OnPropertyChanged("Row19");
                }
            }
        }

        public FeedEntry Row20
        {
            get { return row20; }
            set
            {
                if (value != row20)
                {
                    row20 = value;
                    OnPropertyChanged("Row20");
                }
            }
        }

        public FeedEntry DummyRow1
        {
            get { return dummyrow1; }
            set
            {
                if (value != dummyrow1)
                {
                    dummyrow1 = value;
                    OnPropertyChanged("DummyRow1");
                }
            }
        }

        public FeedEntry DummyRow2
        {
            get { return dummyrow2; }
            set
            {
                if (value != dummyrow2)
                {
                    dummyrow2 = value;
                    OnPropertyChanged("DummyRow2");
                }
            }
        }

        public FeedEntry DummyRow3
        {
            get { return dummyrow3; }
            set
            {
                if (value != dummyrow3)
                {
                    dummyrow3 = value;
                    OnPropertyChanged("DummyRow3");
                }
            }
        }

        public FeedEntry DummyRow4
        {
            get { return dummyrow4; }
            set
            {
                if (value != dummyrow4)
                {
                    dummyrow4 = value;
                    OnPropertyChanged("DummyRow4");
                }
            }
        }

        public FeedEntry DummyRow5
        {
            get { return dummyrow5; }
            set
            {
                if (value != dummyrow5)
                {
                    dummyrow5 = value;
                    OnPropertyChanged("DummyRow5");
                }
            }
        }

        public FeedEntry DummyRow6
        {
            get { return dummyrow6; }
            set
            {
                if (value != dummyrow6)
                {
                    dummyrow6 = value;
                    OnPropertyChanged("DummyRow6");
                }
            }
        }

        public FeedEntry DummyRow7
        {
            get { return dummyrow7; }
            set
            {
                if (value != dummyrow7)
                {
                    dummyrow7 = value;
                    OnPropertyChanged("DummyRow7");
                }
            }
        }

        public FeedEntry DummyRow8
        {
            get { return dummyrow8; }
            set
            {
                if (value != dummyrow8)
                {
                    dummyrow8 = value;
                    OnPropertyChanged("DummyRow8");
                }
            }
        }

        public FeedEntry DummyRow9
        {
            get { return dummyrow9; }
            set
            {
                if (value != dummyrow9)
                {
                    dummyrow9 = value;
                    OnPropertyChanged("DummyRow9");
                }
            }
        }

        public FeedEntry DummyRow10
        {
            get { return dummyrow10; }
            set
            {
                if (value != dummyrow10)
                {
                    dummyrow10 = value;
                    OnPropertyChanged("DummyRow10");
                }
            }
        }

        public FeedEntry DummyRow11
        {
            get { return dummyrow11; }
            set
            {
                if (value != dummyrow11)
                {
                    dummyrow11 = value;
                    OnPropertyChanged("DummyRow11");
                }
            }
        }

        public FeedEntry DummyRow12
        {
            get { return dummyrow12; }
            set
            {
                if (value != dummyrow12)
                {
                    dummyrow12 = value;
                    OnPropertyChanged("DummyRow12");
                }
            }
        }

        public FeedEntry DummyRow13
        {
            get { return dummyrow13; }
            set
            {
                if (value != dummyrow13)
                {
                    dummyrow13 = value;
                    OnPropertyChanged("DummyRow13");
                }
            }
        }

        public FeedEntry DummyRow14
        {
            get { return dummyrow14; }
            set
            {
                if (value != dummyrow14)
                {
                    dummyrow14 = value;
                    OnPropertyChanged("DummyRow14");
                }
            }
        }

        public FeedEntry DummyRow15
        {
            get { return dummyrow15; }
            set
            {
                if (value != dummyrow15)
                {
                    dummyrow15 = value;
                    OnPropertyChanged("DummyRow15");
                }
            }
        }

        public FeedEntry DummyRow16
        {
            get { return dummyrow16; }
            set
            {
                if (value != dummyrow16)
                {
                    dummyrow16 = value;
                    OnPropertyChanged("DummyRow16");
                }
            }
        }

        public FeedEntry DummyRow17
        {
            get { return dummyrow17; }
            set
            {
                if (value != dummyrow17)
                {
                    dummyrow17 = value;
                    OnPropertyChanged("DummyRow17");
                }
            }
        }

        public FeedEntry DummyRow18
        {
            get { return dummyrow18; }
            set
            {
                if (value != dummyrow18)
                {
                    dummyrow18 = value;
                    OnPropertyChanged("DummyRow18");
                }
            }
        }

        public FeedEntry DummyRow19
        {
            get { return dummyrow19; }
            set
            {
                if (value != dummyrow19)
                {
                    dummyrow19 = value;
                    OnPropertyChanged("DummyRow19");
                }
            }
        }

        public FeedEntry DummyRow20
        {
            get { return dummyrow20; }
            set
            {
                if (value != dummyrow20)
                {
                    dummyrow20 = value;
                    OnPropertyChanged("DummyRow20");
                }
            }
        }

#endregion


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

   #endregion

        #endregion

        #region ctor

        public EventStack()
        {
            
        }

        public EventStack(int _speed, int _templateRows, Uri _templateName, string _displayGuid, string _serverName, string _sourceGuid, bool _showAllRooms)
        {
            InitializeComponent();

            pageSeconds = _speed < 1 ? 6 : _speed;

            templateRows = _templateRows < 1 ? 10 : _templateRows;

            templateName = _templateName;

            displayGuid = !string.IsNullOrEmpty(_displayGuid) ? _displayGuid : "Client";
            serverName = !string.IsNullOrEmpty(_serverName) ? _serverName : "";
            sourceGuid = !string.IsNullOrEmpty(_sourceGuid) ? _sourceGuid : "";

            filterStatus = _showAllRooms ? "unfiltered" : "filtered";

            LoadEvents();

            ResourceDictionary resourceDictionary = new ResourceDictionary();

            resourceDictionary.Source = templateName; // TODO: Source too long Temp Location Adding to Playback Temp Directory

            EventTemplate = (ControlTemplate)resourceDictionary[templateKey];

            loopTimer.Interval = new TimeSpan(0, 0, pageSeconds);

            loopTimer.Start();

            DispatcherTimerTickEventManager.AddListener(loopTimer, this);

        }

        #endregion

        public void Dispose()
        {
            loopTimer.Stop();
            EventTemplate = null;
        }

        void LoadEvents()
        {
            eventList.Clear();

            if(pullFeedFlag)
                PullFeed(sourceGuid);

            if (eventsXML == null)
                return;

            itemsXML = DisplayEventsByGroup(eventsXML);

            //int fieldCount = 

            foreach (var element in itemsXML)
            {
                FeedEntry feedEntry = new FeedEntry();

                if (element != null)
                {
                    if (!string.IsNullOrEmpty(element.Element("DateField1").Value))
                        feedEntry.DateField1 = Convert.ToDateTime(element.Element("DateField1").Value);

                    if (!string.IsNullOrEmpty(element.Element("DateField2").Value))
                        feedEntry.DateField2 = Convert.ToDateTime(element.Element("DateField2").Value);

                    if (!string.IsNullOrEmpty(element.Element("DateField3").Value))
                        feedEntry.DateField3 = Convert.ToDateTime(element.Element("DateField3").Value);

                    if (!string.IsNullOrEmpty(element.Element("DateField4").Value))
                        feedEntry.DateField4 = Convert.ToDateTime(element.Element("DateField4").Value);

                    if (!string.IsNullOrEmpty(element.Element("NameField1").Value))
                        feedEntry.NameField1 = element.Element("NameField1").Value;

                    if (!string.IsNullOrEmpty(element.Element("NameField2").Value))
                        feedEntry.NameField2 = element.Element("NameField2").Value;

                    if (!string.IsNullOrEmpty(element.Element("NameField3").Value))
                        feedEntry.NameField3 = element.Element("NameField3").Value;

                    if (!string.IsNullOrEmpty(element.Element("NameField4").Value))
                        feedEntry.NameField4 = element.Element("NameField4").Value;

                    if (!string.IsNullOrEmpty(element.Element("DateField1").Value))
                        feedEntry.DescField1 = element.Element("DescField1").Value;

                    if (!string.IsNullOrEmpty(element.Element("DateField1").Value))
                        feedEntry.DescField2 = element.Element("DescField2").Value;

                    if (!string.IsNullOrEmpty(element.Element("DateField1").Value))
                        feedEntry.DescField3 = element.Element("DescField3").Value;

                    if (!string.IsNullOrEmpty(element.Element("DateField1").Value))
                        feedEntry.DescField4 = element.Element("DescField4").Value;

                    if (!string.IsNullOrEmpty(element.Element("IntField1").Value))
                        feedEntry.IntField1 = Convert.ToInt32(element.Element("IntField1").Value);

                    if (!string.IsNullOrEmpty(element.Element("IntField2").Value))
                        feedEntry.IntField2 = Convert.ToInt32(element.Element("IntField2").Value);

                    if (!string.IsNullOrEmpty(element.Element("DecimalField1").Value))
                        feedEntry.DecimalField1 = Convert.ToDecimal(element.Element("DecimalField1").Value);
                    
                    if (!string.IsNullOrEmpty(element.Element("DecimalField2").Value))
                        feedEntry.DecimalField2 = Convert.ToDecimal(element.Element("DecimalField2").Value);

                    if (!string.IsNullOrEmpty(element.Element("ImageWebPath").Value))
                        feedEntry.ImageWebPath = new Uri((element.Element("ImageWebPath").Value), UriKind.RelativeOrAbsolute);

                    //feedEntry.ImageDescription = element.Element("ImageDesc").Value;

                }
                eventList.Add(feedEntry);
            }

            cycleCount = eventList.Count / templateRows;

            currentCycle = 0;

            FillTemplate();

            pullFeedFlag = false;

        }

        private void PullFeed(string feedGuid)
        {
            try
            {
                if ((!string.IsNullOrEmpty(serverName) && !string.IsNullOrEmpty(feedGuid) &&
                     !string.IsNullOrEmpty(displayGuid)) && displayGuid != "Client")
                {
                    eventsXML =
                        XElement.Load("http://" + serverName + "/feeds/service.svc/feed/" + filterStatus + "/" +
                                      feedGuid + "?display=" + displayGuid); //+ displayGuid
                    pullFeedFlag = false;
                }
                else
                {
                    try
                    {
                        eventsXML = XElement.Load("http://" + serverName + "/feeds/service.svc/feed/sample/");

                    }
                    catch (Exception ex)
                    {

                        eventsXML = null;
                        MessageBox.Show("The Server did not have a feed hosted at http://" + serverName +
                                        "/feeds/service.svc/feed/sample/ :" + ex);
                    }

                }
            }
            catch (Exception)
            {

                eventsXML = null;
            }
        }

        private IEnumerable<XElement> DisplayEventsByGroup(XElement eventsXMLUnsorted)
        {
            var groupNames = eventsXMLUnsorted.XPathSelectElements("//item");
            var sortedEvents = groupNames.OrderBy(t => t.Element("NameField1").Value).ThenBy(t => t.Element("DateField1").Value);
            return sortedEvents;
        }

        void loopTimer_Tick(object sender, EventArgs e)
        {
            
            if (currentCycle < cycleCount + 1)
            {
                FillTemplate();
            }
            else
            {
                LoadEvents();
            }
        }

        private void FillTemplate()
        {
            int visibleRows;

            if (currentCycle == cycleCount)
                visibleRows = eventList.Count - cycleCount * templateRows;
            else
                visibleRows = templateRows;

            Row1 = DummyRow1;
            Row2 = DummyRow2;
            Row3 = DummyRow3;
            Row4 = DummyRow4;
            Row5 = DummyRow5;
            Row6 = DummyRow6;
            Row7 = DummyRow7;
            Row8 = DummyRow8;
            Row9 = DummyRow9;
            Row10 = DummyRow10;
            Row11 = DummyRow11;
            Row12 = DummyRow12;
            Row13 = DummyRow13;
            Row14 = DummyRow14;
            Row15 = DummyRow15;
            Row16 = DummyRow16;
            Row17 = DummyRow17;
            Row18 = DummyRow18;
            Row19 = DummyRow19;
            Row20 = DummyRow20;

            DummyRow1 = visibleRows > 0 ? eventList[currentCycle * templateRows + 0] : null;
            DummyRow2 = visibleRows > 1 ? eventList[currentCycle * templateRows + 1] : null;
            DummyRow3 = visibleRows > 2 ? eventList[currentCycle * templateRows + 2] : null;
            DummyRow4 = visibleRows > 3 ? eventList[currentCycle * templateRows + 3] : null;
            DummyRow5 = visibleRows > 4 ? eventList[currentCycle * templateRows + 4] : null;
            DummyRow6 = visibleRows > 5 ? eventList[currentCycle * templateRows + 5] : null;
            DummyRow7 = visibleRows > 6 ? eventList[currentCycle * templateRows + 6] : null;
            DummyRow8 = visibleRows > 7 ? eventList[currentCycle * templateRows + 7] : null;
            DummyRow9 = visibleRows > 8 ? eventList[currentCycle * templateRows + 8] : null;
            DummyRow10 = visibleRows > 9 ? eventList[currentCycle * templateRows + 9] : null;
            DummyRow11 = visibleRows > 10 ? eventList[currentCycle * templateRows + 10] : null;
            DummyRow12 = visibleRows > 11 ? eventList[currentCycle * templateRows + 11] : null;
            DummyRow13 = visibleRows > 12 ? eventList[currentCycle * templateRows + 12] : null;
            DummyRow14 = visibleRows > 13 ? eventList[currentCycle * templateRows + 13] : null;
            DummyRow15 = visibleRows > 14 ? eventList[currentCycle * templateRows + 14] : null;
            DummyRow16 = visibleRows > 15 ? eventList[currentCycle * templateRows + 15] : null;
            DummyRow17 = visibleRows > 16 ? eventList[currentCycle * templateRows + 16] : null;
            DummyRow18 = visibleRows > 17 ? eventList[currentCycle * templateRows + 17] : null;
            DummyRow19 = visibleRows > 18 ? eventList[currentCycle * templateRows + 18] : null;
            DummyRow20 = visibleRows > 19 ? eventList[currentCycle * templateRows + 19] : null;

            if(Row1 == null)
            {
                Row1 = DummyRow1;
                Row2 = DummyRow2;
                Row3 = DummyRow3;
                Row4 = DummyRow4;
                Row5 = DummyRow5;
                Row6 = DummyRow6;
                Row7 = DummyRow7;
                Row8 = DummyRow8;
                Row9 = DummyRow9;
                Row10 = DummyRow10;
                Row11 = DummyRow11;
                Row12 = DummyRow12;
                Row13 = DummyRow13;
                Row14 = DummyRow14;
                Row15 = DummyRow15;
                Row16 = DummyRow16;
                Row17 = DummyRow17;
                Row18 = DummyRow18;
                Row19 = DummyRow19;
                Row20 = DummyRow20;
            }

            currentCycle++;

            RaiseChangeDataEvent();
        }

        public void PullNewFeed(string guid)
        {
            PullFeed(guid);
        }

        internal void ChangeScrollSpeed(int scrollSpeed)
        {
            loopTimer.Interval = new TimeSpan(0,0,scrollSpeed);
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(DispatcherTimerTickEventManager))
            {
                loopTimer_Tick(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
