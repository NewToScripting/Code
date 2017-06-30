using System;
using System.Collections.Generic;
using Inspire.Events.Proxy;

namespace EventsModule
{
    public class SampleEventManager
    {
        private static readonly List<HospitalityEvent> HospitalityEvents;

        static SampleEventManager()
        {
            HospitalityEvents = new List<HospitalityEvent>();

            var hospitalityEvent1 = new HospitalityEvent();
            var hospitalityEvent2 = new HospitalityEvent();
            var hospitalityEvent3 = new HospitalityEvent();
            var hospitalityEvent4 = new HospitalityEvent();
            var hospitalityEvent5 = new HospitalityEvent();
            var hospitalityEvent6 = new HospitalityEvent();
            var hospitalityEvent7 = new HospitalityEvent();
            var hospitalityEvent8 = new HospitalityEvent();
            var hospitalityEvent9 = new HospitalityEvent();
            var hospitalityEvent10 = new HospitalityEvent();
            var hospitalityEvent11 = new HospitalityEvent();
            var hospitalityEvent12 = new HospitalityEvent();
            var hospitalityEvent13 = new HospitalityEvent();
            var hospitalityEvent14 = new HospitalityEvent();
            var hospitalityEvent15 = new HospitalityEvent();
            var hospitalityEvent16 = new HospitalityEvent();
            var hospitalityEvent17 = new HospitalityEvent();
            var hospitalityEvent18 = new HospitalityEvent();
            var hospitalityEvent19 = new HospitalityEvent();
            var hospitalityEvent20 = new HospitalityEvent();
            var hospitalityEvent21 = new HospitalityEvent();
            var hospitalityEvent22 = new HospitalityEvent();

           
            HospitalityEvents.Add(hospitalityEvent1);
            HospitalityEvents.Add(hospitalityEvent2);
            HospitalityEvents.Add(hospitalityEvent3);
            HospitalityEvents.Add(hospitalityEvent4);
            HospitalityEvents.Add(hospitalityEvent5);
            HospitalityEvents.Add(hospitalityEvent6);
            HospitalityEvents.Add(hospitalityEvent7);
            HospitalityEvents.Add(hospitalityEvent8);
            HospitalityEvents.Add(hospitalityEvent9);
            HospitalityEvents.Add(hospitalityEvent10);
            HospitalityEvents.Add(hospitalityEvent11);
            HospitalityEvents.Add(hospitalityEvent12);
            HospitalityEvents.Add(hospitalityEvent13);
            HospitalityEvents.Add(hospitalityEvent14);
            HospitalityEvents.Add(hospitalityEvent15);
            HospitalityEvents.Add(hospitalityEvent16);
            HospitalityEvents.Add(hospitalityEvent17);
            HospitalityEvents.Add(hospitalityEvent18);
            HospitalityEvents.Add(hospitalityEvent19);
            HospitalityEvents.Add(hospitalityEvent20);
            HospitalityEvents.Add(hospitalityEvent21);
            HospitalityEvents.Add(hospitalityEvent22);


            SetMeetingName(HospitalityEvents);
            SetAlias(HospitalityEvents);
            SetGroupName(HospitalityEvents);
            //SetStartDate(HospitalityEvents);
            //SetEndDate(HospitalityEvents);
            SetStartTime(HospitalityEvents);
            SetEndTime(HospitalityEvents);
            SetMeetingRoomName(HospitalityEvents);
            SetMeetingPostAs(HospitalityEvents);
            SetDirectionalArrows(HospitalityEvents);
            SetGroupLogos(HospitalityEvents);

        }

        private static void SetDirectionalArrows(List<HospitalityEvent> hospitalityEvents)
        {
            foreach (var hospitalityEvent in hospitalityEvents)
            {
                hospitalityEvent.DirectionalImage = "pack://application:,,,/EventsModule;component/Resources/Images/arrow.png"; // "/EventsModule;component/Resources/Images/arrow.png";
            }
        }

        private static void SetGroupLogos(List<HospitalityEvent> hospitalityEvents)
        {
            foreach (var hospitalityEvent in hospitalityEvents)
            {
                hospitalityEvent.GroupLogo = "pack://application:,,,/EventsModule;component/Resources/Images/Logo.png"; // "/EventsModule;component/Resources/Images/arrow.png";
            }
        }

        private static void SetMeetingPostAs(IEnumerable<HospitalityEvent> hospitalityEvents)
        {
            int i = 1;
            foreach (var hospitalityEvent in hospitalityEvents)
            {
                if(i > 9)
                    hospitalityEvent.MeetingPostAs = "PostAs " + i;
                else
                    hospitalityEvent.MeetingPostAs = "PostAs 0" + i;
                i++;
            }
        }

        private static void SetMeetingRoomName(IEnumerable<HospitalityEvent> hospitalityEvents)
        {
            int i = 1;
            foreach (var hospitalityEvent in hospitalityEvents)
            {
                if (i > 9)
                    hospitalityEvent.MeetingRoomName = "Meeting Room " + i;
                else
                    hospitalityEvent.MeetingRoomName = "Meeting Room 0" + i;
                i++;
            }
        }

        private static void SetEndTime(IEnumerable<HospitalityEvent> hospitalityEvents)
        {
            int i = 2;
            foreach (var hospitalityEvent in hospitalityEvents)
            {
                hospitalityEvent.EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, i, 0, 0);
                i++;
            }      
        }

        private static void SetStartTime(IEnumerable<HospitalityEvent> hospitalityEvents)
        {
            int i = 1;
            foreach (var hospitalityEvent in hospitalityEvents)
            {
                hospitalityEvent.StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day, i,0,0);
                i++;
            }
        }

        //private static void SetEndDate(IEnumerable<HospitalityEvent> hospitalityEvents)
        //{
        //    foreach (var hospitalityEvent in hospitalityEvents)
        //    {
        //        hospitalityEvent.EndDate = DateTime.Today;
        //    }
        //}

        //private static void SetStartDate(IEnumerable<HospitalityEvent> hospitalityEvents)
        //{
        //    foreach (var hospitalityEvent in hospitalityEvents)
        //    {
        //        hospitalityEvent.StartDate = DateTime.Today;
        //    }
        //}

        private static void SetGroupName(IEnumerable<HospitalityEvent> hospitalityEvents)
        {
            int i = 1;
            foreach (var hospitalityEvent in hospitalityEvents)
            {
                if (i > 9)
                    hospitalityEvent.GroupName= "Group " + i;
                else
                    hospitalityEvent.GroupName = "Group 0" + i;
                i++;
            }
        }

        private static void SetAlias(IEnumerable<HospitalityEvent> hospitalityEvents)
        {
            int i = 1;
            foreach (var hospitalityEvent in hospitalityEvents)
            {
                if(i > 9)
                    hospitalityEvent.Alias = "Alias " + i;
                else
                    hospitalityEvent.Alias = "Alias 0" + i;
                i++;
            }
        }

        private static void SetMeetingName(IEnumerable<HospitalityEvent> hospitalityEvents)
        {
            int i = 1;
            foreach (var hospitalityEvent in hospitalityEvents)
            {
                if(i > 9)
                    hospitalityEvent.MeetingName = "Meeting Name " + i;
                else
                    hospitalityEvent.MeetingName = "Meeting Name 0" + i;
                i++;
            }
        }

        public static List<HospitalityEvent> GetEvents()
        {
            return HospitalityEvents;
        }

    }
}
