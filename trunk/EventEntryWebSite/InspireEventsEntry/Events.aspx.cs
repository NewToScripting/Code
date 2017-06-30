using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using InspireEventsEntry.EventsServiceReference;
using InspireEventsEntry.RoomServiceReference;

namespace InspireEventsEntry
{
    public partial class Events : System.Web.UI.Page
    {
        private static string _eventDefGuid;
        private List<HospitalityEvent> _events;
 
        protected void Page_Load(object sender, EventArgs e)
        {
            EventServiceContractClient client = new EventServiceContractClient();
            HospitalityEventDefinition descId = client.GetDefaultEventDefinition();
            _eventDefGuid = descId.EventDefinitionGuid;
            this._events = client.GetEvents(descId.EventDefinitionGuid);

            this._events.Sort(delegate(HospitalityEvent p1, HospitalityEvent p2) { return p1.GroupName.CompareTo(p2.GroupName); });
            
            this.EventsGrid.DataSource = this._events;
            this.EventsGrid.DataBind();

            if (!base.IsPostBack)
            {
                this.ClearFields();
            }
        }


      
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (((!string.IsNullOrEmpty(this.TbGroupName.Text) && !string.IsNullOrEmpty(this.TbMeetingName.Text)) && (!string.IsNullOrEmpty(this.TbStartTime.Text) && !string.IsNullOrEmpty(this.TbStartDateInput.Text))) && (!string.IsNullOrEmpty(this.TbEndTime.Text) && !string.IsNullOrEmpty(this.TbEndDateInput.Text)))
            {
                try
                {
                    EventServiceContractClient client = new EventServiceContractClient();
                    DateTime startTime = DateTime.Parse(this.TbStartTime.Text);
                    DateTime startDate = DateTime.Parse(this.TbStartDateInput.Text);
                    DateTime endTime = DateTime.Parse(this.TbEndTime.Text);
                    DateTime endDate = DateTime.Parse(this.TbEndDateInput.Text);
                    HospitalityEvent hospEvent = new HospitalityEvent();
                    hospEvent.EventDefinitionId = _eventDefGuid;
                    hospEvent.EventId = Guid.NewGuid().ToString();
                    hospEvent.GroupName = this.TbGroupName.Text;
                    hospEvent.MeetingName = this.TbMeetingName.Text;
                    hospEvent.StartDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, startTime.Hour, startTime.Minute, 0);
                    hospEvent.EndDateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, endTime.Hour, endTime.Minute, 0);
                    hospEvent.MeetingRoomName = this.DdlGetRooms.SelectedItem.Text;
                    client.AddEvent(hospEvent);
                    List<HospitalityEvent> evnts = this.EventsGrid.DataSource as List<HospitalityEvent>;
                    if (evnts != null)
                    {
                        evnts.Add(hospEvent);
                        this.EventsGrid.DataBind();
                        this.ClearFields();
                    }
                    return;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            this.LblFail.Visible = true;
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            if (((!string.IsNullOrEmpty(this.TbGroupName.Text) && !string.IsNullOrEmpty(this.TbMeetingName.Text)) && (!string.IsNullOrEmpty(this.TbStartTime.Text) && !string.IsNullOrEmpty(this.TbStartDateInput.Text))) && ((!string.IsNullOrEmpty(this.TbEndTime.Text) && !string.IsNullOrEmpty(this.TbEndDateInput.Text)) && (this.EventsGrid.SelectedIndex != -1)))
            {
                try
                {
                    EventServiceContractClient client = new EventServiceContractClient();
                    DateTime startTime = DateTime.Parse(this.TbStartTime.Text);
                    DateTime startDate = DateTime.Parse(this.TbStartDateInput.Text);
                    DateTime endTime = DateTime.Parse(this.TbEndTime.Text);
                    DateTime endDate = DateTime.Parse(this.TbEndDateInput.Text);
                    HospitalityEvent hospEvent = ((List<HospitalityEvent>)this.EventsGrid.DataSource)[this.EventsGrid.SelectedIndex];
                    hospEvent.EventDefinitionId = _eventDefGuid;
                    hospEvent.GroupName = this.TbGroupName.Text;
                    hospEvent.MeetingName = this.TbMeetingName.Text;
                    hospEvent.StartDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, startTime.Hour, startTime.Minute, 0);
                    hospEvent.EndDateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, endTime.Hour, endTime.Minute, 0);
                    hospEvent.MeetingRoomName = this.DdlGetRooms.SelectedItem.Text;
                    client.UpdateEvent(hospEvent);
                    List<HospitalityEvent> evnts = this.EventsGrid.DataSource as List<HospitalityEvent>;
                    if (evnts != null)
                    {
                        evnts[this.EventsGrid.SelectedIndex] = hospEvent;
                        this.EventsGrid.DataBind();
                        this.ClearFields();
                    }
                    return;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            this.LblFail.Visible = true;
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            if (this.EventsGrid.SelectedIndex > -1)
            {
                HospitalityEvent selectedEvent = ((List<HospitalityEvent>)this.EventsGrid.DataSource)[this.EventsGrid.SelectedIndex];
                if (selectedEvent != null)
                {
                    EventServiceContractClient client = new EventServiceContractClient();
                    client.DeleteEvent(selectedEvent.EventId);
                    List<HospitalityEvent> evnts = this.EventsGrid.DataSource as List<HospitalityEvent>;
                    if (evnts != null)
                    {
                        int selInd = this.EventsGrid.SelectedIndex;
                        this.EventsGrid.SelectedIndex = -1;
                        evnts.RemoveAt(selInd);
                        this.EventsGrid.DataSource = evnts;
                        this.EventsGrid.DataBind();
                        this.ClearFields();
                    }
                }
            }
        }

        protected void ClearFields()
        {
            this.LblFail.Visible = false;
            this.TbGroupName.Text = "";
            this.TbMeetingName.Text = "";
            this.TbStartTime.Text = "08:00 AM";
            this.TbEndTime.Text = "05:00 PM";
            this.DdlGetRooms.SelectedIndex = 0;
        }

     
        protected void EventSelectionChanged(object sender, EventArgs e)
        {
            if (this.EventsGrid.SelectedIndex > (this.EventsGrid.Rows.Count - 1))
            {
                this.EventsGrid.SelectedIndex = -1;
            }
            else
            {
                HospitalityEvent selectedEvent = ((List<HospitalityEvent>)((GridView)sender).DataSource)[this.EventsGrid.SelectedIndex];
                if (selectedEvent != null)
                {
                    this.LblFail.Visible = false;
                    this.TbGroupName.Text = selectedEvent.GroupName;
                    this.TbMeetingName.Text = selectedEvent.MeetingName;
                    this.TbStartTime.Text = selectedEvent.StartDateTime.Value.ToShortTimeString();
                    this.TbEndTime.Text = selectedEvent.EndDateTime.Value.ToShortTimeString();
                    this.TbStartDateInput.Text = selectedEvent.EndDateTime.Value.ToShortDateString();
                    this.TbEndDateInput.Text = selectedEvent.EndDateTime.Value.ToShortDateString();
                    try
                    {
                        this.DdlGetRooms.SelectedValue = selectedEvent.MeetingRoomName;
                    }
                    catch (Exception)
                    {
                        this.DdlGetRooms.SelectedIndex = 0;
                    }
                }
            }
        }

       

    }

    public class RoomsProxy
    {
        static public Rooms GetRooms()
        {
            RoomsServiceContractClient client = new RoomsServiceContractClient();
            Rooms rooms = client.GetRooms();
            return rooms;
        }
    }
}