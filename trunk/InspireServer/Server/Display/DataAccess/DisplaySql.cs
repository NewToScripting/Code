using System.Text;
using System;
using System.Data.SqlTypes;

namespace Inspire.Server.Display.DataAccess
{
    public class DisplaySql
    {

        //Display

        public static string GetDisplayFromGroupID(string guid)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT GUID,HostName,Domain,[Name],Location,HorizontalResolution,VerticalResolution,ControllerType,ControllerModel,MonitorModel,MonitorType,MonitorSize,");
            sql.Append(@"Orientation,[Status],SoftwareVersion,OS,ActiveFlag,GroupID,LastCommunication FROM Display WHERE GroupID = '" + guid + "'");
            return sql.ToString();
        }


        public static string GetDisplayFromDisplayID(string guid)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT [GUID],HostName,Domain,[Name],Location,HorizontalResolution,VerticalResolution,ControllerType, ControllerModel,MonitorModel,MonitorType,");
            sql.Append(@"MonitorSize,Orientation,[Status],SoftwareVersion,OS,ActiveFlag,GroupID,LastCommunication FROM Display WHERE [GUID] = '" + guid + "'");
            return sql.ToString();
        }

        public static string GetAllDisplays()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT [GUID],HostName,Domain,[Name],Location,HorizontalResolution,VerticalResolution,ControllerType, ControllerModel,MonitorModel,MonitorType,");
            sql.Append(@"MonitorSize,Orientation,[Status],SoftwareVersion,OS,ActiveFlag,GroupID,LastCommunication FROM Display");
            return sql.ToString();
        }


        public static string GetDisplayHostnames()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT HostName FROM Display");
            return sql.ToString();
        }

        public static string GetDisplayFromScheduleID(string guid)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT d.GUID, d.[HostName],d.Domain,d.Name,d.Location,d.HorizontalResolution,d.VerticalResolution,d.ControllerType,d.MonitorModel,d.MonitorSize,d.MonitorType,d.Orientation,d.Status,");
            sql.Append(@"d.ControllerModel,d.SoftwareVersion,d.OS,d.ActiveFlag,d.GroupID,d.LastCommunication FROM DisplayScheduleAssn Assn join display d on d.GUID = Assn.DisplayID WHERE Assn.ScheduleID = '" + guid + "'");
            return sql.ToString();
        }

        public static string UpdateDisplayActiveFlag()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"UPDATE Display SET ActiveFlag = '0' WHERE (LastCommunication IS Null) or (6 < DATEDIFF(minute, LastCommunication, GETDATE())) SELECT hostname From Display WHERE ActiveFlag = '0'");
            return sql.ToString();
        }

        public static string UpdateDisplay(string guid, string hostName, string domain, string name, string location, string horizontalResolution, string verticalResolution, string controllerType, string controllerModel, string monitorModel, string monitorType, string monitorSize, string orientation, string status, string oS, string softwareVersion, string activeFlag, string groupId, string lastCommunication)
        {
            string lasttime = "";
            if (lastCommunication != DateTime.MinValue.ToString())
                lasttime = lastCommunication.ToString();

            StringBuilder sql = new StringBuilder();
            sql.Append(@"UPDATE Display SET HostName = '" + hostName + "', Domain = '" + domain + "', [Name] = '" + name + "', Location = '" + location + "', HorizontalResolution = '" + horizontalResolution + "', VerticalResolution = '" + verticalResolution + "', ");
            sql.Append(@"ControllerType = '" + controllerType + "', ControllerModel = '" + controllerModel + "', MonitorModel = '" + monitorModel + "', MonitorType = '" + monitorType + "', MonitorSize = '" + monitorSize + "', Orientation = '" + orientation + "', ");
            sql.Append(@"[Status] = '" + status + "', OS = '" + oS + "', SoftwareVersion = '" + softwareVersion + "', ActiveFlag = '" + activeFlag + "', GroupID = '" + groupId + "', LastCommunication = '" + lasttime + "' WHERE GUID = '" + guid + "'");
            return sql.ToString();
        }

        public static string UpdateActiveFlag(string hostName)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"UPDATE Display SET ActiveFlag = '1', LastCommunication = GETDATE() WHERE HostName = '" + hostName + "'");
            return sql.ToString();
        }

        public static string GetDisplayWithDisplayID(string guid)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT [GUID], HostName, Domain, [Name], Location, HorizontalResolution, VerticalResolution, ControllerType, ControllerModel, MonitorModel, MonitorType, MonitorSize, Orientation, [Status], SoftwareVersion, OS, ActiveFlag, GroupID FROM Display WHERE [GUID] = '" + guid + "'");
            return sql.ToString();
        }

        public static string GetDisplayFromHostName(string hostName)
        {
             StringBuilder sql = new StringBuilder();
             sql.Append(@"SELECT [GUID] FROM Display WHERE HostName = '" + hostName + "'");
             return sql.ToString();
        }

        public static string DeleteDisplay(string guid)
        {
             StringBuilder sql = new StringBuilder();
             sql.Append(@"DELETE FROM Display Where GUID = '" + guid + "'");
             return sql.ToString();
        }

        public static string DeleteDisplayAssn(string guid)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"DELETE FROM DisplayScheduleAssn Where DisplayID = '" + guid + "'");
            return sql.ToString();
        }

        public static string DeleteDisplaySchedules(string guid)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"DELETE FROM Schedule Where [GUID] NOT IN (SELECT ScheduleID FROM DisplayScheduleAssn)");
            return sql.ToString();
        }


        public static string AddDislay(string guid, string hostName, string domain, string name, string location, string horizontalResolution, string verticalResolution, string controllerType, string controllerModel, string monitorModel, string monitorType, string monitorSize, string OS, string softwareVersion, string orientation, string status, string activeFlag, string groupID, DateTime? lastCommunication)
        {
            string lasttime = "";
            if (lastCommunication.Value != DateTime.MinValue)
                lasttime = lastCommunication.ToString();    

        StringBuilder sql = new StringBuilder();

            sql.Append(@"INSERT INTO Display (GUID, HostName, Domain, [Name], Location, HorizontalResolution, VerticalResolution, ControllerType, ControllerModel, MonitorModel, MonitorType, MonitorSize, OS, SoftwareVersion, Orientation, [Status], ActiveFlag, GroupID, LastCommunication ) ");
            sql.Append(@" VALUES ( '" + guid + "', '" + hostName + "', '" + domain + "', '" + name + "', '" + location + "', '" + horizontalResolution + "', '" + verticalResolution + "', '" + controllerType + "', '" + controllerModel + "', '" + monitorModel + "', '" + monitorType + "', '" + monitorSize + "', '" + OS + "', '" + softwareVersion + "', '" + orientation + "', '" + status + "', '" + activeFlag + "', '" + groupID + "', '" + lasttime + "')");
            return sql.ToString();
        }

        //Display Group

        public static string GetAllGroups()
        {
            string sql = @"SELECT GUID, [Name], Description, PropertyID FROM DisplayGroup";
            return sql;
        }

        public static string GetGroups(string guid)
        {
            string sql = @"SELECT GUID, [Name], Description, PropertyID FROM DisplayGroup WHERE PropertyID = '" + guid + "'";
            return sql;
        }

        public static string UpdateDisplayGroup(string guid, string name, string description, string propertyID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"UPDATE DisplayGroup SET [GUID] = '" + guid + "'");
            sql.Append(@",[Name] = '" + name + "'");
            sql.Append(@",[Description] = '" + description + "'");
            sql.Append(@",PropertyID = '" + propertyID + "' WHERE [GUID] = '" + propertyID + "'");

            return sql.ToString();
        }

        public static string AddDisplayGroup(string guid, string name, string description, string propertyID)
        {
            string sql = @"INSERT INTO DisplayGroup (GUID, [Name], Description, PropertyID) VALUES ('" + guid + "', '" + name + "', '" + description + "', '" + propertyID + "')";
            return sql;
        }
              
         
        //Display Property

         public static string GetDisplayProperties()
         {
             string sql = @"SELECT GUID,[Name],Description FROM DisplayProperty";
             return sql;
         }

         public static string UpdateDisplayProperty(string guid, string name, string description)
         {
              string sql = @"UPDATE DisplayProperty SET GUID = '" + guid +  "',[Name] = '" + name + "',Description = '" + description + "' WHERE GUID = '" + guid +"'";
              return sql;
         }


         public static string AddDisplayProperty(string guid, string name, string description)
         {
             string sql = @"INSERT INTO DisplayProperty (GUID, [Name], Description) VALUES ( '" + guid + "', '" + name + "', '" + description + "')";
             return sql;
         }
        
    }
}
