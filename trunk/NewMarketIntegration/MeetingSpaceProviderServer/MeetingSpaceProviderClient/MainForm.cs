using System;
using System.Configuration;
using System.Windows.Forms;

namespace MeetingSpaceExportService
{
    using Newmarket.WebServices.MeetingSpace.client;
    using MeetingSpaceService_TestHarness.Inspire.Server.Events;
    using MeetingSpaceService_TestHarness;
    
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }
                
        /// <summary>
        /// 
        /// </summary>
        private void LoadEvents()
        {
            bool? filterVisible = ConfigFileManager.FilterVisible();

            HospitalityEvents currentEvents = new HospitalityEvents();

            MeetingSpaceResponse property = NewmarketEventProxy.GetProperty();
            HospitalityEvents events  = ProxyHelper.LoadEvents(property);

            string log = ConfigurationManager.AppSettings["WriteToTextLog"];

            foreach (HospitalityEvent item in events)
            {
                if (item.Postable != null)
                {
                    if (item.Postable == true)
                    {
                        if (log == "true" || log == "True")
                        {
                            FileLogger.Log(item);
                        }

                        currentEvents.Add(item);
                    }
                }
            }

            InspireServerProxy inspireProxy = new InspireServerProxy();
            inspireProxy.AddEvents(currentEvents);
        }
 
        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadEvents();
            Close();
        }
    }
   
}