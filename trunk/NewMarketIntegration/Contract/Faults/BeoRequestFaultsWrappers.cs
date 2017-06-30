namespace Newmarket.WebServices.Faults {
    
    
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
            return null;
        }
    }
}
