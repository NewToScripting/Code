using System;
using System.Collections.Generic;

namespace Inspire.Server.Proxy
{
    public class DisplayTranslators
    {
        static public Display CommonDisplayOut(Inspire.Server.Proxy.DisplaysServiceReference.Display from)
        {
            Display to = new Display();

            to.GUID = from.GUID;
            to.ControllerModel = from.ControllerModel;
            to.ControllerType = from.ControllerType;
            to.DisplayName = from.DisplayName;
            to.Domain = from.Domain;
            to.Group = from.Group;
            to.HostName = from.HostName;
            to.HResolution = from.HResolution;
            to.IsPlayerCreated = from.IsPlayerCreated;
            to.Location = from.Location;
            to.MonitorModel = from.MonitorModel;
            to.MonitorSize = from.MonitorSize;
            to.MonitorType = from.MonitorType;
            to.Orientation = from.Orientation;
            to.OS = from.OS;
            to.SoftwareVersion = from.SoftwareVersion;
            to.Status = ObjectTranslatorHelper.StringToStatusEnum(from.Status);
            to.VResolution = from.VResolution;
            to.Group = from.Group;
            //to.Property = from.PropertyID;
            if (from.LastCommunication != null) to.LastCommunication = (DateTime)from.LastCommunication;
            to.ActiveFlag = from.ActiveFlag;

            return to;

        }

        static public Inspire.Server.Proxy.DisplaysServiceReference.Display ServiceDisplayOut(Display from)
        {
            Inspire.Server.Proxy.DisplaysServiceReference.Display to = new Inspire.Server.Proxy.DisplaysServiceReference.Display();

            to.GUID = from.GUID;
            to.ControllerModel = from.ControllerModel;
            to.ControllerType = from.ControllerType;
            to.DisplayName = from.DisplayName;
            to.Domain = from.Domain;
            to.Group = from.Group;
            to.HostName = from.HostName;
            to.HResolution = from.HResolution;
            to.IsPlayerCreated = from.IsPlayerCreated;
            to.Location = from.Location;
            to.MonitorModel = from.MonitorModel;
            to.MonitorSize = from.MonitorSize;
            to.MonitorType = from.MonitorType;
            to.Orientation = from.Orientation;
            to.OS = from.OS;
            to.SoftwareVersion = from.SoftwareVersion;
            to.Status = from.Status.ToString();
            to.VResolution = from.VResolution;
            to.Group = from.Group;
            //to.PropertyID = from.Property;
            to.LastCommunication = from.LastCommunication;
            to.ActiveFlag = from.ActiveFlag;

            return to;

        }
    }//class

    public class DisplayPropertyTranslators
    {
        static public Inspire.DisplayProperty CommonDisplayPropertyOut(Inspire.Server.Proxy.DisplayPropertyServiceReference.DisplayProperty from)
        {
            DisplayProperty to = new DisplayProperty();

            to.PropertyName = from.PropertyName;
            to.GUID = from.GUID;
            to.PropertyDescription = from.PropertyDescription;

            return to;

        }

        static public Inspire.Server.Proxy.DisplayPropertyServiceReference.DisplayProperty ServiceDisplayPropertyOut(Inspire.DisplayProperty from)
        {
            Inspire.Server.Proxy.DisplayPropertyServiceReference.DisplayProperty to = new Inspire.Server.Proxy.DisplayPropertyServiceReference.DisplayProperty();

            to.PropertyName = from.PropertyName;
            to.GUID = from.GUID;
            to.PropertyDescription = from.PropertyDescription;

            return to;

        }



    }


    public class DisplayGroupTranslators
    {
        static public Inspire.DisplayGroup CommonDisplayGroupOut(Inspire.Server.Proxy.DisplayGroupsServiceReference.DisplayGroup from)
        {
            DisplayGroup to = new DisplayGroup();

            to.GUID = from.GUID;
            to.GroupName = from.GroupName;
            to.PropertyID = from.PropertyID;
            to.GroupDescription = from.GroupDescription;

            return to;

        }

        static public Inspire.Server.Proxy.DisplayGroupsServiceReference.DisplayGroup ServiceDisplayGroupOut(Inspire.DisplayGroup from)
        {
            Inspire.Server.Proxy.DisplayGroupsServiceReference.DisplayGroup to = new Inspire.Server.Proxy.DisplayGroupsServiceReference.DisplayGroup();

            to.GUID = from.GUID;
            to.GroupName = from.GroupName;
            to.PropertyID = from.PropertyID;
            to.GroupDescription = from.GroupDescription;

            return to;

        }



    }


    public class ScheduleTranslators
    {
        static public Inspire.Schedule CommonScheduleOut(Inspire.Server.Proxy.ScheduleServiceReference.Schedule from)
        {
            Inspire.Schedule to = new Inspire.Schedule();

            to.GUID = from.GUID;
            to.Name = from.Name;
            to.StartDate = from.StartDate;
            to.EndDate = from.EndDate;
            to.StartTime = from.StartTime;
            to.EndTime = from.EndTime;
            to.Days = (Schedule.DaysEnum)from.Days;
            to.Mode = ObjectTranslatorHelper.StringToModeEnum(from.Mode);
            to.Priority = from.Priority;
            to.Type = ObjectTranslatorHelper.StringToTypeEnum(from.Type);

            return to;

        }

        static public Inspire.Server.Proxy.ScheduleServiceReference.Schedule ServiceScheduleOut(Inspire.Schedule from)
        {
            Inspire.Server.Proxy.ScheduleServiceReference.Schedule to = new Inspire.Server.Proxy.ScheduleServiceReference.Schedule();

            to.GUID = from.GUID;
            to.Name = from.Name;
            to.StartDate = from.StartDate;
            to.EndDate = from.EndDate;
            to.StartTime = from.StartTime;
            to.EndTime = from.EndTime;
            to.Days = (int)from.Days;
            to.Mode = from.Mode.ToString();
            to.Priority = from.Priority;
            to.Type = from.Type.ToString();

            return to;

        }

    }


    public class SlideTranslators
    {

        static public Inspire.Server.Proxy.SlideServiceReference.Slide ServiceSlideOut(Inspire.Slide from)
        {
            Inspire.Server.Proxy.SlideServiceReference.Slide to = new Inspire.Server.Proxy.SlideServiceReference.Slide();

            to.GUID = from.GUID;
            to.Name = from.Name;
            to.Description = from.Description;
            to.HResolution = from.HResolution;
            to.VResolution = from.VResolution;
            to.Thumbnail = from.ThumbNail;
            to.DefaultDuration = from.DefaultDuration;
            to.LastModifiedDate = from.LastModifiedDate;
            to.ModifiedBy = from.ModifiedBy;
            to.SlideRules = SlideRuleTranslators.ReferenceSlideRuleOut(from.Rules);
            to.SlideTags = SlideTagTranslators.ReferenceTagsSlideTagOut(from.Tags);
            to.Buttons = SlideButtonTranslators.ProxyTouchScreenButtonOut(from.Buttons);

            return to;

        }


        static public Inspire.Slide CommonSlideOut(Inspire.Server.Proxy.SlideServiceReference.Slide from)
        {
            Inspire.Slide to = new Inspire.Slide();

            to.GUID = from.GUID;
            to.Name = from.Name;
            to.Description = from.Description;
            to.HResolution = from.HResolution;
            to.VResolution = from.VResolution;
            to.ThumbNail = from.Thumbnail;
            to.DefaultDuration = from.DefaultDuration;
            to.LastModifiedDate = from.LastModifiedDate;
            to.ModifiedBy = from.ModifiedBy;
            to.Rules = SlideRuleTranslators.CommonSlideRuleOut(from.SlideRules);
            to.Tags = SlideTagTranslators.CommonSlideTagOut(from.SlideTags);
            to.Buttons = SlideButtonTranslators.CommonTouchScreenButtonOut(from.Buttons);

            return to;

        }

        static public Inspire.SlideFile CommonSlideFileOut(Inspire.Server.Proxy.SlideServiceReference.Slide from)
        {
            Inspire.SlideFile to = new Inspire.SlideFile();
            to.GUID = from.GUID;
            to.HResolution = from.HResolution;
            to.VResolution = from.VResolution;
            to.Name = from.Name;
            to.ThumbNail = from.Thumbnail;
            to.DefaultDuration = from.DefaultDuration;
            to.LastModifiedDate = from.LastModifiedDate;
            to.ModifiedBy = from.ModifiedBy;
            to.Rules = SlideRuleTranslators.CommonSlideRuleOut(from.SlideRules);
            to.Tags = SlideTagTranslators.CommonSlideTagOut(from.SlideTags);
            to.Buttons = SlideButtonTranslators.CommonTouchScreenButtonOut(from.Buttons);

            return to;

        }

        //static public Inspire.Server.Proxy.SlideFileServiceReference.SlideFile  ServiceSlideFileOut(Inspire.SlideFile from)
        //{
        //    Inspire.Server.Proxy.SlideFileServiceReference.SlideFile to = new Inspire.Server.Proxy.SlideFileServiceReference.SlideFile();
        //    to.File = from.File;
        //    to.GUID = from.GUID;
        //    //to.ThumbNail = 

        //    return to;

        //}


    }//end class



    public class ScheduledSlideTranslators
    {

        static public Inspire.ScheduledSlide CommonScheduledSlideOut(Inspire.Server.Proxy.ScheduledSlideServiceReference.ScheduledSlide from)
        {
            Inspire.ScheduledSlide to = new Inspire.ScheduledSlide();

            to.Description = from.Description;
            to.GUID = from.GUID;
            to.Name = from.Name;
            to.Duration = from.Duration;
            to.OriginalSlideId = from.OriginalSlideID;
            to.ScheduleId = from.ScheduleID;
            to.Transition = from.Transition;
            to.TransitionSpeed = from.TransitionSpeed;
            to.ThumbNail = from.ThumbNail;
            if (from.VResolution != null) to.VResolution = (double)from.VResolution;
            if (from.HResolution != null) to.HResolution = (double)from.HResolution;
            to.Buttons = ScheduledSlideButtonTranslators.CommonTouchScreenButtonOut(from.Buttons);
            //to.IgnoreAllRules = from.IgnoreAllRules;
            return to;

        }

        static public Inspire.Server.Proxy.ScheduledSlideServiceReference.ScheduledSlide ProxyScheduledSlideOut(Inspire.ScheduledSlide from)
        {
            Inspire.Server.Proxy.ScheduledSlideServiceReference.ScheduledSlide to = new Inspire.Server.Proxy.ScheduledSlideServiceReference.ScheduledSlide();

            to.GUID = from.GUID;
            to.Name = from.Name;
            to.Description = from.Description;
            to.Duration = (DateTime)from.Duration;
            to.OriginalSlideID = from.OriginalSlideId;
            to.ScheduleID = from.ScheduleId;
            to.Transition = from.Transition;
            to.TransitionSpeed = (int)from.TransitionSpeed;
            to.ThumbNail = from.ThumbNail;
            to.VResolution = from.VResolution;
            to.HResolution = from.HResolution;
            to.Buttons = ScheduledSlideButtonTranslators.ProxyTouchScreenButtonOut(from.Buttons);
            //to.IgnoreAllRules = from.IgnoreAllRules;
            return to;
            
        }



    }//end class

    //public class SlideNavagatorTranslators
    //{

    //    static public List<Inspire.SlideNavagation> CommonTouchScreenButtonOut(Inspire.Server.Proxy.ScheduledSlideServiceReference.SlideNavagations from)
    //    {
    //        List<Inspire.SlideNavagation> tos = new List<Inspire.SlideNavagation>();

    //        if(from != null)
    //        {
    //              foreach (Inspire.Server.Proxy.ScheduledSlideServiceReference.SlideNavagation item in from)
    //                {
    //                    Inspire.SlideNavagation to = new Inspire.SlideNavagation();

    //                    to.ButtonID = item.ButtonID;
    //                    to.GUID = item.GUID;
    //                    to.ButtonName = item.ButtonName;
    //                    to.SlideGuidToNavigateTo = item.SlideGuidToNavigateTo;
    //                    to.ScheduledSlideID = item.ScheduledSlideID;
    //                    tos.Add(to);
    //                }

    //        }
          


    //        return tos;

    //    }
    //    static public Inspire.Server.Proxy.ScheduledSlideServiceReference.SlideNavagations ProxyTouchScreenButtonOut(List<Inspire.SlideNavagation> from)
    //    {
    //        Inspire.Server.Proxy.ScheduledSlideServiceReference.SlideNavagations tos = new Inspire.Server.Proxy.ScheduledSlideServiceReference.SlideNavagations();

    //        if (from != null)
    //        {

    //            foreach (Inspire.SlideNavagation item in from)
    //            {
    //                Inspire.Server.Proxy.ScheduledSlideServiceReference.SlideNavagation to = new Inspire.Server.Proxy.ScheduledSlideServiceReference.SlideNavagation();

    //                to.ButtonID = item.ButtonID;
    //                to.GUID = item.GUID;
    //                to.ButtonName= item.ButtonName;
    //                to.SlideGuidToNavigateTo = item.SlideGuidToNavigateTo;
    //                to.ScheduledSlideID = item.ScheduledSlideID;
    //                tos.Add(to);
    //            }

    //        }
    //        return tos;

    //    }
    //}//end class


    public class SlideButtonTranslators
    {

        static public SlideButtons CommonTouchScreenButtonOut(Inspire.Server.Proxy.SlideServiceReference.Buttons from)
        {
            var tos = new SlideButtons();
            if (from != null)
            {
                foreach (Inspire.Server.Proxy.SlideServiceReference.Button item in from)
                {
                    Inspire.SlideButton to = new Inspire.SlideButton();

                    to.ButtonName = item.ButtonName;
                    to.GUID = item.GUID;
                    to.SlideID = item.SlideID;
                    //to.ScheduledSlideID = item.ScheduledSlideID;
                    //to.SlideGuidToNavigateTo = item.SlideGuidToNavigateTo;
                    tos.Add(to);
                }
            }



            return tos;

        }

        static public Inspire.Server.Proxy.SlideServiceReference.Buttons ProxyTouchScreenButtonOut(List<Inspire.SlideButton> from)
        {
            Inspire.Server.Proxy.SlideServiceReference.Buttons tos = new Inspire.Server.Proxy.SlideServiceReference.Buttons();

            if (from != null)
            {
                foreach (Inspire.SlideButton item in from)
                {
                    Inspire.Server.Proxy.SlideServiceReference.Button to = new Inspire.Server.Proxy.SlideServiceReference.Button();

                    to.ButtonName = item.ButtonName;
                    to.GUID = item.GUID;
                    to.SlideID = item.SlideID;
                    //to.ScheduledSlideID = item.ScheduledSlideID;
                    //to.SlideGuidToNavigateTo = item.SlideGuidToNavigateTo;
                    tos.Add(to);
                }
            }
            return tos;

        }

    }//end class

    public class ScheduledSlideButtonTranslators
    {

        static public SlideButtons CommonTouchScreenButtonOut(Inspire.Server.Proxy.ScheduledSlideServiceReference.Buttons from)
        {
            var tos = new SlideButtons();
            if (from != null)
            {
                foreach (Inspire.Server.Proxy.ScheduledSlideServiceReference.Button item in from)
                {
                    Inspire.SlideButton to = new Inspire.SlideButton();

                    to.ButtonName = item.ButtonName;
                    to.GUID = item.GUID;
                    to.SlideID = item.SlideID;
                    to.ScheduledSlideID = item.ScheduledSlideID;
                    to.SlideGuidToNavigateTo = item.SlideGuidToNavigateTo;
                    tos.Add(to);
                }
            }



            return tos;

        }

        static public Inspire.Server.Proxy.ScheduledSlideServiceReference.Buttons ProxyTouchScreenButtonOut(List<Inspire.SlideButton> from)
        {
            Inspire.Server.Proxy.ScheduledSlideServiceReference.Buttons tos = new Inspire.Server.Proxy.ScheduledSlideServiceReference.Buttons();

            if (from != null)
            {
                foreach (Inspire.SlideButton item in from)
                {
                    Inspire.Server.Proxy.ScheduledSlideServiceReference.Button to = new Inspire.Server.Proxy.ScheduledSlideServiceReference.Button();

                    to.ButtonName = item.ButtonName;
                    to.GUID = item.GUID;
                    to.SlideID = item.SlideID;
                    to.ScheduledSlideID = item.ScheduledSlideID;
                    to.SlideGuidToNavigateTo = item.SlideGuidToNavigateTo;
                    tos.Add(to);
                }
            }
            return tos;
        }

    }//end class

    public class SlideRuleTranslators
    {

        static public SlideRules CommonSlideRuleOut(Inspire.Server.Proxy.SlideServiceReference.SlideRules from)
        {
            var tos = new SlideRules();

            foreach (Inspire.Server.Proxy.SlideServiceReference.SlideRule item in from)
            {
                Inspire.SlideRule to = new Inspire.SlideRule();
                to.GUID = item.GUID;
                to.Rule = item.Rule;
                to.SlideID = item.SlideID;
                tos.Add(to);
            }

            return tos;

        }


        static public Inspire.Server.Proxy.SlideServiceReference.SlideRules ReferenceSlideRuleOut(List<Inspire.SlideRule> from)
        {

            Inspire.Server.Proxy.SlideServiceReference.SlideRules tos = new Inspire.Server.Proxy.SlideServiceReference.SlideRules();

                if (from != null)
                {
                    foreach (Inspire.SlideRule item in from)
                    {
                        Inspire.Server.Proxy.SlideServiceReference.SlideRule to = new Inspire.Server.Proxy.SlideServiceReference.SlideRule();

                        to.GUID = item.GUID;
                        to.Rule = item.Rule;
                        to.SlideID = item.SlideID;
                        tos.Add(to);
                    }
                }
            return tos;
        }
    }//end class


    public class SlideTagTranslators
    {

        static public SlideTags CommonSlideTagOut(Inspire.Server.Proxy.SlideServiceReference.SlideTags from)
        {
            var tos = new SlideTags();

            if (from != null)
            {

                foreach (Inspire.Server.Proxy.SlideServiceReference.SlideTag item in from)
                {
                    Inspire.SlideTag to = new Inspire.SlideTag();
                    to.GUID = item.GUID;
                    to.Tag = item.Tag;
                    to.SlideID = item.SlideID;
                    tos.Add(to);
                }
            }
            return tos;
        }


        static public Inspire.Server.Proxy.SlideServiceReference.SlideTags ReferenceTagsSlideTagOut(List<Inspire.SlideTag> from)
        {
            Inspire.Server.Proxy.SlideServiceReference.SlideTags tos = new Inspire.Server.Proxy.SlideServiceReference.SlideTags();

            if (from != null)
            {
                foreach (Inspire.SlideTag item in from)
                {
                    Inspire.Server.Proxy.SlideServiceReference.SlideTag to = new Inspire.Server.Proxy.SlideServiceReference.SlideTag();

                    to.GUID = item.GUID;
                    to.Tag = item.Tag;
                    to.SlideID = item.SlideID;
                    tos.Add(to);
                }
            }
            return tos;
        }
    }//end class
}//end namespace


