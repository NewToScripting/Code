using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inspire.Server.Proxy
{
    public class ObjectTranslatorHelper
    {


        static public Display.StatusEnum StringToStatusEnum(string statusenum)
        {
            switch (statusenum)
            {
                case "Online":
                   return Display.StatusEnum.Online;
                case "Offline":
                   return Display.StatusEnum.Offline;
                case "OutOfService":
                   return Display.StatusEnum.OutOfService;
                default:
                   return Display.StatusEnum.NotSet;
                   
            }
         
        }

        static public Schedule.ModeEnum StringToModeEnum(string mode)
        {
            switch (mode)
            {
                case "Default":
                   return Schedule.ModeEnum.Default;
                case "Shuffle":
                   return Schedule.ModeEnum.Shuffle;
                case "DoNotMix":
                    return Schedule.ModeEnum.DoNotMix;
                case "Intersperse":
                   return Schedule.ModeEnum.Intersperse;
                default:
                   return Schedule.ModeEnum.Default;
            }
        }
        static public Schedule.ScheduleTypeEnum StringToTypeEnum(string type)
        { 
            //ScheduleTypeEnum { Default, Continuous, Triggerable, Sleep, Daily, Weekly, Yearly}
            switch (type)
            {
                case "Default":
                    return Schedule.ScheduleTypeEnum.Default;
                case "Continuous":
                    return Schedule.ScheduleTypeEnum.Continuous;
                case "Daily":
                    return Schedule.ScheduleTypeEnum.Daily;
                case "Sleep":
                    return Schedule.ScheduleTypeEnum.Sleep;
                case "Yearly":
                    return Schedule.ScheduleTypeEnum.Yearly;
                case "Weekly":
                    return Schedule.ScheduleTypeEnum.Weekly;
                case "Monthly":
                    return Schedule.ScheduleTypeEnum.Monthly;
                case "Touchscreen":
                    return Schedule.ScheduleTypeEnum.Touchscreen;
                default:
                    return Schedule.ScheduleTypeEnum.Continuous;
            }
        }

       


    }
}
