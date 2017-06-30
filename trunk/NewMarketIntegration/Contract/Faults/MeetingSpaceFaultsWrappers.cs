namespace Newmarket.WebServices.MeetingSpaceFaults {
    
    
    public class DigitalSignageGenericFaultException : System.Web.Services.Protocols.SoapException {
        
        public DigitalSignageGenericFaultException(string message, System.Xml.XmlQualifiedName code, string actor, Newmarket.WebServices.MeetingSpaceFaults.DigitalSignageGenericFault detail) : 
                base(message, code, actor, DigitalSignageGenericFaultException.SerializeTypeToXml(detail)) {
        }
        
        public DigitalSignageGenericFaultException(string message, System.Xml.XmlQualifiedName code, string actor, System.Xml.XmlNode detail) : 
                base(message, code, actor, detail) {
        }
        
        public DigitalSignageGenericFaultException(System.Xml.XmlQualifiedName code, Newmarket.WebServices.MeetingSpaceFaults.DigitalSignageGenericFault detail) : 
                this("An exception occurred", code, "", detail) {
        }
        
        public virtual Newmarket.WebServices.MeetingSpaceFaults.DigitalSignageGenericFault TypedDetail {
            get {
                System.Xml.XmlElement detail = ((System.Xml.XmlElement)(base.Detail.FirstChild));
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.DigitalSignageGenericFault));
                return ((Newmarket.WebServices.MeetingSpaceFaults.DigitalSignageGenericFault)(xmlSerializer.Deserialize(new System.Xml.XmlNodeReader(detail))));
            }
        }
        
        public static System.Xml.XmlElement SerializeTypeToXml(Newmarket.WebServices.MeetingSpaceFaults.DigitalSignageGenericFault detail) {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.DigitalSignageGenericFault));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            xmlSerializer.Serialize(ms, detail);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(ms);
            System.Xml.XmlElement rootDetail = ((System.Xml.XmlElement)(xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, System.Web.Services.Protocols.SoapException.DetailElementName.Name, System.Web.Services.Protocols.SoapException.DetailElementName.Namespace)));
            rootDetail.AppendChild(xmlDoc.RemoveChild(xmlDoc.DocumentElement));
            return rootDetail;
        }
    }
    
    public class NoMeetingSpaceFoundFaultException : System.Web.Services.Protocols.SoapException {
        
        public NoMeetingSpaceFoundFaultException(string message, System.Xml.XmlQualifiedName code, string actor, Newmarket.WebServices.MeetingSpaceFaults.NoMeetingSpaceFoundFault detail) : 
                base(message, code, actor, NoMeetingSpaceFoundFaultException.SerializeTypeToXml(detail)) {
        }
        
        public NoMeetingSpaceFoundFaultException(string message, System.Xml.XmlQualifiedName code, string actor, System.Xml.XmlNode detail) : 
                base(message, code, actor, detail) {
        }
        
        public NoMeetingSpaceFoundFaultException(System.Xml.XmlQualifiedName code, Newmarket.WebServices.MeetingSpaceFaults.NoMeetingSpaceFoundFault detail) : 
                this("An exception occurred", code, "", detail) {
        }
        
        public virtual Newmarket.WebServices.MeetingSpaceFaults.NoMeetingSpaceFoundFault TypedDetail {
            get {
                System.Xml.XmlElement detail = ((System.Xml.XmlElement)(base.Detail.FirstChild));
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.NoMeetingSpaceFoundFault));
                return ((Newmarket.WebServices.MeetingSpaceFaults.NoMeetingSpaceFoundFault)(xmlSerializer.Deserialize(new System.Xml.XmlNodeReader(detail))));
            }
        }
        
        public static System.Xml.XmlElement SerializeTypeToXml(Newmarket.WebServices.MeetingSpaceFaults.NoMeetingSpaceFoundFault detail) {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.NoMeetingSpaceFoundFault));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            xmlSerializer.Serialize(ms, detail);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(ms);
            System.Xml.XmlElement rootDetail = ((System.Xml.XmlElement)(xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, System.Web.Services.Protocols.SoapException.DetailElementName.Name, System.Web.Services.Protocols.SoapException.DetailElementName.Namespace)));
            rootDetail.AppendChild(xmlDoc.RemoveChild(xmlDoc.DocumentElement));
            return rootDetail;
        }
    }
    
    public class InvalidDateTimeFaultException : System.Web.Services.Protocols.SoapException {
        
        public InvalidDateTimeFaultException(string message, System.Xml.XmlQualifiedName code, string actor, Newmarket.WebServices.MeetingSpaceFaults.InvalidDateTimeFault detail) : 
                base(message, code, actor, InvalidDateTimeFaultException.SerializeTypeToXml(detail)) {
        }
        
        public InvalidDateTimeFaultException(string message, System.Xml.XmlQualifiedName code, string actor, System.Xml.XmlNode detail) : 
                base(message, code, actor, detail) {
        }
        
        public InvalidDateTimeFaultException(System.Xml.XmlQualifiedName code, Newmarket.WebServices.MeetingSpaceFaults.InvalidDateTimeFault detail) : 
                this("An exception occurred", code, "", detail) {
        }
        
        public virtual Newmarket.WebServices.MeetingSpaceFaults.InvalidDateTimeFault TypedDetail {
            get {
                System.Xml.XmlElement detail = ((System.Xml.XmlElement)(base.Detail.FirstChild));
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.InvalidDateTimeFault));
                return ((Newmarket.WebServices.MeetingSpaceFaults.InvalidDateTimeFault)(xmlSerializer.Deserialize(new System.Xml.XmlNodeReader(detail))));
            }
        }
        
        public static System.Xml.XmlElement SerializeTypeToXml(Newmarket.WebServices.MeetingSpaceFaults.InvalidDateTimeFault detail) {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.InvalidDateTimeFault));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            xmlSerializer.Serialize(ms, detail);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(ms);
            System.Xml.XmlElement rootDetail = ((System.Xml.XmlElement)(xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, System.Web.Services.Protocols.SoapException.DetailElementName.Name, System.Web.Services.Protocols.SoapException.DetailElementName.Namespace)));
            rootDetail.AppendChild(xmlDoc.RemoveChild(xmlDoc.DocumentElement));
            return rootDetail;
        }
    }
    
    public class DateRangeTooLargeFaultException : System.Web.Services.Protocols.SoapException {
        
        public DateRangeTooLargeFaultException(string message, System.Xml.XmlQualifiedName code, string actor, Newmarket.WebServices.MeetingSpaceFaults.DateRangeTooLargeFault detail) : 
                base(message, code, actor, DateRangeTooLargeFaultException.SerializeTypeToXml(detail)) {
        }
        
        public DateRangeTooLargeFaultException(string message, System.Xml.XmlQualifiedName code, string actor, System.Xml.XmlNode detail) : 
                base(message, code, actor, detail) {
        }
        
        public DateRangeTooLargeFaultException(System.Xml.XmlQualifiedName code, Newmarket.WebServices.MeetingSpaceFaults.DateRangeTooLargeFault detail) : 
                this("An exception occurred", code, "", detail) {
        }
        
        public virtual Newmarket.WebServices.MeetingSpaceFaults.DateRangeTooLargeFault TypedDetail {
            get {
                System.Xml.XmlElement detail = ((System.Xml.XmlElement)(base.Detail.FirstChild));
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.DateRangeTooLargeFault));
                return ((Newmarket.WebServices.MeetingSpaceFaults.DateRangeTooLargeFault)(xmlSerializer.Deserialize(new System.Xml.XmlNodeReader(detail))));
            }
        }
        
        public static System.Xml.XmlElement SerializeTypeToXml(Newmarket.WebServices.MeetingSpaceFaults.DateRangeTooLargeFault detail) {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.DateRangeTooLargeFault));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            xmlSerializer.Serialize(ms, detail);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(ms);
            System.Xml.XmlElement rootDetail = ((System.Xml.XmlElement)(xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, System.Web.Services.Protocols.SoapException.DetailElementName.Name, System.Web.Services.Protocols.SoapException.DetailElementName.Namespace)));
            rootDetail.AppendChild(xmlDoc.RemoveChild(xmlDoc.DocumentElement));
            return rootDetail;
        }
    }
    
    public class InvalidPropertyKeyFaultException : System.Web.Services.Protocols.SoapException {
        
        public InvalidPropertyKeyFaultException(string message, System.Xml.XmlQualifiedName code, string actor, Newmarket.WebServices.MeetingSpaceFaults.InvalidPropertyKeyFault detail) : 
                base(message, code, actor, InvalidPropertyKeyFaultException.SerializeTypeToXml(detail)) {
        }
        
        public InvalidPropertyKeyFaultException(string message, System.Xml.XmlQualifiedName code, string actor, System.Xml.XmlNode detail) : 
                base(message, code, actor, detail) {
        }
        
        public InvalidPropertyKeyFaultException(System.Xml.XmlQualifiedName code, Newmarket.WebServices.MeetingSpaceFaults.InvalidPropertyKeyFault detail) : 
                this("An exception occurred", code, "", detail) {
        }
        
        public virtual Newmarket.WebServices.MeetingSpaceFaults.InvalidPropertyKeyFault TypedDetail {
            get {
                System.Xml.XmlElement detail = ((System.Xml.XmlElement)(base.Detail.FirstChild));
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.InvalidPropertyKeyFault));
                return ((Newmarket.WebServices.MeetingSpaceFaults.InvalidPropertyKeyFault)(xmlSerializer.Deserialize(new System.Xml.XmlNodeReader(detail))));
            }
        }
        
        public static System.Xml.XmlElement SerializeTypeToXml(Newmarket.WebServices.MeetingSpaceFaults.InvalidPropertyKeyFault detail) {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.InvalidPropertyKeyFault));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            xmlSerializer.Serialize(ms, detail);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(ms);
            System.Xml.XmlElement rootDetail = ((System.Xml.XmlElement)(xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, System.Web.Services.Protocols.SoapException.DetailElementName.Name, System.Web.Services.Protocols.SoapException.DetailElementName.Namespace)));
            rootDetail.AppendChild(xmlDoc.RemoveChild(xmlDoc.DocumentElement));
            return rootDetail;
        }
    }
    
    public class InvalidRoomGroupingFaultException : System.Web.Services.Protocols.SoapException {
        
        public InvalidRoomGroupingFaultException(string message, System.Xml.XmlQualifiedName code, string actor, Newmarket.WebServices.MeetingSpaceFaults.InvalidRoomGroupingFault detail) : 
                base(message, code, actor, InvalidRoomGroupingFaultException.SerializeTypeToXml(detail)) {
        }
        
        public InvalidRoomGroupingFaultException(string message, System.Xml.XmlQualifiedName code, string actor, System.Xml.XmlNode detail) : 
                base(message, code, actor, detail) {
        }
        
        public InvalidRoomGroupingFaultException(System.Xml.XmlQualifiedName code, Newmarket.WebServices.MeetingSpaceFaults.InvalidRoomGroupingFault detail) : 
                this("An exception occurred", code, "", detail) {
        }
        
        public virtual Newmarket.WebServices.MeetingSpaceFaults.InvalidRoomGroupingFault TypedDetail {
            get {
                System.Xml.XmlElement detail = ((System.Xml.XmlElement)(base.Detail.FirstChild));
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.InvalidRoomGroupingFault));
                return ((Newmarket.WebServices.MeetingSpaceFaults.InvalidRoomGroupingFault)(xmlSerializer.Deserialize(new System.Xml.XmlNodeReader(detail))));
            }
        }
        
        public static System.Xml.XmlElement SerializeTypeToXml(Newmarket.WebServices.MeetingSpaceFaults.InvalidRoomGroupingFault detail) {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.InvalidRoomGroupingFault));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            xmlSerializer.Serialize(ms, detail);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(ms);
            System.Xml.XmlElement rootDetail = ((System.Xml.XmlElement)(xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, System.Web.Services.Protocols.SoapException.DetailElementName.Name, System.Web.Services.Protocols.SoapException.DetailElementName.Namespace)));
            rootDetail.AppendChild(xmlDoc.RemoveChild(xmlDoc.DocumentElement));
            return rootDetail;
        }
    }
    
    public class InvalidEventKeyFaultException : System.Web.Services.Protocols.SoapException {
        
        public InvalidEventKeyFaultException(string message, System.Xml.XmlQualifiedName code, string actor, Newmarket.WebServices.MeetingSpaceFaults.InvalidEventKeyFault detail) : 
                base(message, code, actor, InvalidEventKeyFaultException.SerializeTypeToXml(detail)) {
        }
        
        public InvalidEventKeyFaultException(string message, System.Xml.XmlQualifiedName code, string actor, System.Xml.XmlNode detail) : 
                base(message, code, actor, detail) {
        }
        
        public InvalidEventKeyFaultException(System.Xml.XmlQualifiedName code, Newmarket.WebServices.MeetingSpaceFaults.InvalidEventKeyFault detail) : 
                this("An exception occurred", code, "", detail) {
        }
        
        public virtual Newmarket.WebServices.MeetingSpaceFaults.InvalidEventKeyFault TypedDetail {
            get {
                System.Xml.XmlElement detail = ((System.Xml.XmlElement)(base.Detail.FirstChild));
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.InvalidEventKeyFault));
                return ((Newmarket.WebServices.MeetingSpaceFaults.InvalidEventKeyFault)(xmlSerializer.Deserialize(new System.Xml.XmlNodeReader(detail))));
            }
        }
        
        public static System.Xml.XmlElement SerializeTypeToXml(Newmarket.WebServices.MeetingSpaceFaults.InvalidEventKeyFault detail) {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.InvalidEventKeyFault));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            xmlSerializer.Serialize(ms, detail);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(ms);
            System.Xml.XmlElement rootDetail = ((System.Xml.XmlElement)(xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, System.Web.Services.Protocols.SoapException.DetailElementName.Name, System.Web.Services.Protocols.SoapException.DetailElementName.Namespace)));
            rootDetail.AppendChild(xmlDoc.RemoveChild(xmlDoc.DocumentElement));
            return rootDetail;
        }
    }
    
    public class NoMeetingRoomsFoundFaultException : System.Web.Services.Protocols.SoapException {
        
        public NoMeetingRoomsFoundFaultException(string message, System.Xml.XmlQualifiedName code, string actor, Newmarket.WebServices.MeetingSpaceFaults.NoMeetingRoomsFoundFault detail) : 
                base(message, code, actor, NoMeetingRoomsFoundFaultException.SerializeTypeToXml(detail)) {
        }
        
        public NoMeetingRoomsFoundFaultException(string message, System.Xml.XmlQualifiedName code, string actor, System.Xml.XmlNode detail) : 
                base(message, code, actor, detail) {
        }
        
        public NoMeetingRoomsFoundFaultException(System.Xml.XmlQualifiedName code, Newmarket.WebServices.MeetingSpaceFaults.NoMeetingRoomsFoundFault detail) : 
                this("An exception occurred", code, "", detail) {
        }
        
        public virtual Newmarket.WebServices.MeetingSpaceFaults.NoMeetingRoomsFoundFault TypedDetail {
            get {
                System.Xml.XmlElement detail = ((System.Xml.XmlElement)(base.Detail.FirstChild));
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.NoMeetingRoomsFoundFault));
                return ((Newmarket.WebServices.MeetingSpaceFaults.NoMeetingRoomsFoundFault)(xmlSerializer.Deserialize(new System.Xml.XmlNodeReader(detail))));
            }
        }
        
        public static System.Xml.XmlElement SerializeTypeToXml(Newmarket.WebServices.MeetingSpaceFaults.NoMeetingRoomsFoundFault detail) {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Newmarket.WebServices.MeetingSpaceFaults.NoMeetingRoomsFoundFault));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            xmlSerializer.Serialize(ms, detail);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(ms);
            System.Xml.XmlElement rootDetail = ((System.Xml.XmlElement)(xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, System.Web.Services.Protocols.SoapException.DetailElementName.Name, System.Web.Services.Protocols.SoapException.DetailElementName.Namespace)));
            rootDetail.AppendChild(xmlDoc.RemoveChild(xmlDoc.DocumentElement));
            return rootDetail;
        }
    }
    
    public class FaultExceptionMapper : ExceptionHelper.FaultExceptionMapperBase {
        
        public override System.Web.Services.Protocols.SoapException LookupAndCreateException(System.Web.Services.Protocols.SoapException ex) {
            System.Xml.XmlQualifiedName qualifiedDetailName;
            if (((ex.Detail != null) 
                        && ex.Detail.HasChildNodes)) {
                qualifiedDetailName = new System.Xml.XmlQualifiedName(ex.Detail.FirstChild.LocalName, ex.Detail.FirstChild.NamespaceURI);
            }
            else {
                return null;
            }
            if (((qualifiedDetailName.Namespace == "http://htng.org/PWSWG/2007/01/DigitalSignage/Faults/Types") 
                        && (qualifiedDetailName.Name == "DigitalSignageGenericFault"))) {
                return new DigitalSignageGenericFaultException(ex.Message, ex.Code, ex.Actor, ex.Detail);
            }
            if (((qualifiedDetailName.Namespace == "http://htng.org/PWSWG/2007/01/DigitalSignage/Faults/Types") 
                        && (qualifiedDetailName.Name == "NoMeetingSpaceFoundFault"))) {
                return new NoMeetingSpaceFoundFaultException(ex.Message, ex.Code, ex.Actor, ex.Detail);
            }
            if (((qualifiedDetailName.Namespace == "http://htng.org/PWSWG/2007/01/DigitalSignage/Faults/Types") 
                        && (qualifiedDetailName.Name == "InvalidDateTimeFault"))) {
                return new InvalidDateTimeFaultException(ex.Message, ex.Code, ex.Actor, ex.Detail);
            }
            if (((qualifiedDetailName.Namespace == "http://htng.org/PWSWG/2007/01/DigitalSignage/Faults/Types") 
                        && (qualifiedDetailName.Name == "DateRangeTooLargeFault"))) {
                return new DateRangeTooLargeFaultException(ex.Message, ex.Code, ex.Actor, ex.Detail);
            }
            if (((qualifiedDetailName.Namespace == "http://htng.org/PWSWG/2007/01/DigitalSignage/Faults/Types") 
                        && (qualifiedDetailName.Name == "InvalidPropertyKeyFault"))) {
                return new InvalidPropertyKeyFaultException(ex.Message, ex.Code, ex.Actor, ex.Detail);
            }
            if (((qualifiedDetailName.Namespace == "http://htng.org/PWSWG/2007/01/DigitalSignage/Faults/Types") 
                        && (qualifiedDetailName.Name == "InvalidRoomGroupingFault"))) {
                return new InvalidRoomGroupingFaultException(ex.Message, ex.Code, ex.Actor, ex.Detail);
            }
            if (((qualifiedDetailName.Namespace == "http://htng.org/PWSWG/2007/01/DigitalSignage/Faults/Types") 
                        && (qualifiedDetailName.Name == "InvalidEventKeyFault"))) {
                return new InvalidEventKeyFaultException(ex.Message, ex.Code, ex.Actor, ex.Detail);
            }
            if (((qualifiedDetailName.Namespace == "http://htng.org/PWSWG/2007/01/DigitalSignage/Faults/Types") 
                        && (qualifiedDetailName.Name == "NoMeetingRoomsFoundFault"))) {
                return new NoMeetingRoomsFoundFaultException(ex.Message, ex.Code, ex.Actor, ex.Detail);
            }
            return null;
        }
    }
}
