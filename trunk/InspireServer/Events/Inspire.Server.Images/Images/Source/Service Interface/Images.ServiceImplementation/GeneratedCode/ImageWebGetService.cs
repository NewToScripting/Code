//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using WCF = global::System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;
using Inspire.Server.Images.ServiceContracts;
using System.Configuration;

namespace Inspire.Server.Images.ServiceImplementation
{	
	
	public class ImageWebGetService : IImageWebGetServiceContract
	{
		

        public Stream GetImage(string filename)
        {
            try
            {
                string filepath = System.AppDomain.CurrentDomain.BaseDirectory + "/" + ConfigurationManager.AppSettings["ImageLocalFolder"].ToString() + "/" + filename;
                FileStream fs = File.OpenRead(filepath);
                WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
                return fs;
            }
            catch (System.Exception)
            {
                return null;
            }
            
        }

      
	
		
	}
	
	
	
}

