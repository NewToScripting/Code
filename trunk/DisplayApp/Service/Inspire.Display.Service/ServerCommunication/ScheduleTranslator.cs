using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inspire.Display.Service.XML;

namespace Inspire.Display.Service.ServerCommunication
{
    public class ScheduleTranslator
    {
        public static Schedules Translate(ScheduleServiceReference.Schedules inputs)
        {
            Schedules outputs = new Schedules();

            foreach (ScheduleServiceReference.Schedule input in inputs)
            {
                Schedule output = new Schedule();

                if (input != null)
                {
                    output.GUID = input.GUID;
                    output.Name = input.Name;
                    output.Days = input.Days;
                    output.EndDate = input.EndDate;
                    output.EndTime = input.EndTime;
                    output.Mode = input.Mode;
                    output.Priority = input.Priority;
                    output.ScheduleSlides = TranslateScheduledSlides(ScheduledSlideServiceProxy.GetScheduledSlides(output.GUID));
                    output.StartDate = input.StartDate;
                    output.StartTime= input.StartTime;
                    output.Type = input.Type;
                    outputs.Add(output);
                }    
            }           
            
            return outputs;
        }


        private static ScheduleSlides TranslateScheduledSlides(ScheduledSlideServiceReference.ScheduledSlides proxySlides)
        {
            ScheduleSlides xmlSchedules = new ScheduleSlides();

            foreach (ScheduledSlideServiceReference.ScheduledSlide proxyslide in proxySlides)
            {
                ScheduleSlide xmlSchedule = new ScheduleSlide();
                

                if (proxyslide != null)
                {
                    xmlSchedule.GUID = proxyslide.GUID;
                    xmlSchedule.Buttons = TranslateButtons(proxyslide.Buttons);
                    xmlSchedule.Description = proxyslide.Description;
                    xmlSchedule.Duration = proxyslide.Duration;
                    xmlSchedule.HResolution = proxyslide.HResolution;
                    xmlSchedule.Name = proxyslide.Name;
                    xmlSchedule.OriginalSlideID = proxyslide.OriginalSlideID;
                    xmlSchedule.ScheduleID = proxyslide.ScheduleID;
                    //xmlSchedule.ThumbNail = proxyslide.ThumbNail;
                    xmlSchedule.Transition = proxyslide.Transition;
                    xmlSchedule.TransitionSpeed = proxyslide.TransitionSpeed;
                    xmlSchedule.Version = proxyslide.Version;
                    xmlSchedule.VResolution = proxyslide.VResolution;
                    xmlSchedules.Add(xmlSchedule);
                }
            }

            return xmlSchedules;
        }

        private static Buttons TranslateButtons(ScheduledSlideServiceReference.Buttons proxyButtons)
        {
            Buttons xmlButtons = new Buttons();

            foreach (ScheduledSlideServiceReference.Button proxyButton in proxyButtons)
            {
                Button xmlButton = new Button();


                if (proxyButton != null)
                {
                    xmlButton.GUID = proxyButton.GUID;
                    xmlButton.ButtonName = proxyButton.ButtonName;
                    xmlButton.ScheduledSlidSlideID = proxyButton.ScheduledSlideID;
                    xmlButton.SlideGuidToNavigateTo = proxyButton.SlideGuidToNavigateTo;
                    xmlButton.SlideID = proxyButton.SlideID;
                    xmlButtons.Add(xmlButton);
                }
            }

            return xmlButtons;
        }  

    }
}
