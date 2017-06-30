using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inspire.Display.Service.SlideFileServiceReference;
using System.Configuration;
using System.ServiceModel;

namespace Inspire.Display.Service.ServerCommunication
{
    public class SlideFileProxy
    {
        public static ProxySlideFile GetSlideFile(string slideID)
        {
            string uri = ConfigurationManager.AppSettings["HttpType"] + ConfigurationManager.AppSettings["Servername"] + ConfigurationManager.AppSettings["SlideFileService"];

            GetSlideFileResponseMessage response = new GetSlideFileResponseMessage();
            GetSlideFileRequestMessage request = new GetSlideFileRequestMessage();
            request.SlideID = slideID;
            SlideFileManagerServiceContractClient client = new SlideFileManagerServiceContractClient();

            var endPoint = new EndpointAddress(uri);
            client.Endpoint.Address = endPoint;  

            response = client.GetSlideFile(request);

            ProxySlideFile proxySlideFile = new ProxySlideFile();

            proxySlideFile.SlideFileID = response.SlideFileID;
            proxySlideFile.SlideFileSize = response.SlideFileSize;
            proxySlideFile.SlideFileStream = response.SlideFileStream;

            return proxySlideFile;
        }
    }
}
