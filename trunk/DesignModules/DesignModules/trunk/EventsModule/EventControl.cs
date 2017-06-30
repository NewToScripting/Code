using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Inspire.Services.WeakEventHandlers;

namespace EventsModule
{
    public class EventControl : StackPanel, IWeakEventListener
    {
        public TimeSpan SecondsPerPage { get; set; }

        List<TextBlock> EventColumns { get; set; }

        public EventControl()
        {
            LoadedEventManager.AddListener(this, this);
        }

        void EventControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public EventControl(List<BagOfNuts> eventData, string headerColumn)
        {
            var orderGroups =
                from p in eventData
                group p by p.GroupName into g
                select new { GroupName = g.Key, BagOfNuts = g };

            foreach (var orderGroup in orderGroups)
            {
                GroupControl groupControl = new GroupControl(orderGroup.BagOfNuts, EventColumns);
                Children.Add(groupControl);
            }

        }



        protected override void OnRenderSizeChanged(System.Windows.SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);


        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }

    public class EventRow :StackPanel
    {
        public EventRow()
        {
            Orientation =  Orientation.Horizontal;
        }

        public EventRow(BagOfNuts nut, List<TextBlock> eventColumns) : this()
        {
            //if (nut.MeetingName != null)
            //    Children.Add(new EventTextBlock(nut.MeetingPostAs));
            //if (nut.MeetingRoomName != null)
            //    Children.Add(new EventTextBlock(nut.MeetingRoomName));
            //if (nut.StartTime != null)
            //    Children.Add(new EventTextBlock(nut.StartTime.Value.ToShortTimeString()));
            //if (nut.EndTime != null)
            //    Children.Add(new EventTextBlock(nut.EndTime.Value.ToShortTimeString()));
        }
    }
}
