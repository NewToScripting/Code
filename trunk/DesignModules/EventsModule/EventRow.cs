using System.Windows;
using System.Windows.Controls;
using Inspire.Events.Proxy;

namespace EventsModule
{
    public class EventRow : StackPanel
    {
        public EventRow()
        {
            Orientation = Orientation.Horizontal;
        }

        public EventRow(HospitalityEvent nut, ListBox eventColumns) : this()
        {
            VerticalAlignment = VerticalAlignment.Stretch;

            double mostHeight = 20;

            foreach (TextBlock block in eventColumns.Items)
            {
                //if (block.Height > maxHeight)
                //    maxHeight = block.Height;

                switch (block.Text)
                {
                    case ("MeetingPostAs"):
                        Children.Add(new EventTextBlock(nut.MeetingPostAs, block));
                        break;
                    case ("GroupName"):
                        Children.Add(new EventTextBlock(nut.GroupName, block));
                        break;
                    case ("StartTime"):
                        Children.Add(new EventTextBlock(nut.StartTime.Value.ToString("h:mm") + " " + nut.StartTime.Value.ToString("tt").ToLower(), block));
                        break;
                    case ("EndTime"):
                        Children.Add(new EventTextBlock(nut.EndTime.Value.ToString("h:mm") + " " + nut.EndTime.Value.ToString("tt").ToLower(), block));
                        break;
                    //case ("StartDate"):
                    //    Children.Add(new EventTextBlock(nut.StartDate.Value.ToShortTimeString(), block));
                    //    break;
                    //case ("EndDate"):
                    //    Children.Add(new EventTextBlock(nut.EndDate.Value.ToShortTimeString(), block));
                    //    break;
                    //case ("Date"):
                    //    Children.Add(new EventTextBlock(nut.Date.Value.ToShortTimeString(), block));
                    //    break;
                    //case ("GroupLogo"):
                    //    Children.Add(new LogoTextBlock(nut.GroupLogo, block));
                    //    break;
                    case ("MeetingRoomLogo"):
                        Children.Add(new LogoTextBlock(nut.MeetingRoomLogo, block));
                        break;
                    case ("MeetingLogo"):
                        Children.Add(new LogoTextBlock(nut.MeetingLogo, block));
                        break;
                    case ("HotelName"):
                        Children.Add(new EventTextBlock(nut.HotelName, block));
                        break;
                    case ("MeetingRoomName"):
                        Children.Add(new EventTextBlock(nut.MeetingRoomName, block));
                        break;
                    case ("MeetingType"):
                        Children.Add(new EventTextBlock(nut.MeetingType, block));
                        break;
                    case ("MeetingName"):
                        Children.Add(new EventTextBlock(nut.MeetingName, block));
                        break;
                    case ("DirectionalImage"):
                        if (nut.DirectionalImage != null)
                        {
                            if (!nut.DirectionalImage.EndsWith("/"))
                                Children.Add(new LogoTextBlock(nut.DirectionalImage, block)); //(nut.GroupLogo, block));
                        }
                        break;
                }

                foreach (UIElement uiElement in Children)
                {
                    uiElement.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                    if (uiElement.DesiredSize.Height > mostHeight)
                        mostHeight = uiElement.DesiredSize.Height;
                }
            }
            Height = mostHeight;
        }
    }
}
