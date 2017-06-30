using System;
using System.Collections.Generic;
using Inspire.Events.Proxy.TemplateService;
using System.IO;

namespace Inspire.Events.Proxy
{
    /// <summary>
    /// Feed Template Proxy
    /// </summary>
    public class FeedTemplateProxy
    {
            /// <summary>
            /// Get Templates
            /// </summary>
            /// <returns></returns>
            static public List<FeedTemplate> GetTemplates()
            {
                List<FeedTemplate> templates = new List<FeedTemplate>();

                try
                {
                    TemplateServiceContractClient client = new TemplateServiceContractClient();
                    client.Endpoint.Address = SeverSettings.GetTemplateEndpoint();

                    Inspire.Events.Proxy.TemplateService.FeedTemplates proxyTemplates = client.GetTemplates();
                    
                    foreach (Inspire.Events.Proxy.TemplateService.FeedTemplate item in proxyTemplates)
                    {
                        var feedTemplate = new Inspire.Events.Proxy.FeedTemplate();
                        feedTemplate = InternalTemplateToFeedTemplate(item);
                        templates.Add(feedTemplate);
                    }
                }
                catch (Exception e)
                {
                    ProxyErrorHandler.Throw(e, "Error occured while getting templates");
                }

                return templates;

            }//end function
        
            /// <summary>
            /// Get Single Template
            /// </summary>
            /// <param name="templateID"></param>
            /// <returns></returns>
            static public FeedTemplate GetSingleTemplate(string templateID)
            { 
                var template = new Inspire.Events.Proxy.FeedTemplate();

                try
                {
                    TemplateServiceContractClient client = new TemplateServiceContractClient();
                    client.Endpoint.Address = SeverSettings.GetTemplateEndpoint();

                    int filesize;
                    Stream inStream;
                    Inspire.Events.Proxy.TemplateService.FeedTemplate proxyTemplate = client.GetSingleTemplate(templateID, out filesize, out inStream);
                    
                    template = InternalTemplateToFeedTemplate(proxyTemplate);
                    template.File = StreamToBytes.ReadFully(inStream, filesize);
                }
                catch (Exception e)
                {
                    ProxyErrorHandler.Throw(e, "Error occured while getting single template");
                }
                
                return template;

            }//end function

            /// <summary>
            /// Add Template
            /// </summary>
            /// <param name="template"></param>
            static public void AddTemplate(FeedTemplate template)
            {
                try
                {
                    Inspire.Events.Proxy.TemplateService.FeedTemplate proxyTemplate = FeedTemplateToInternalTemplate(template);
                    TemplateServiceContractClient client = new TemplateServiceContractClient();
                    client.Endpoint.Address = SeverSettings.GetTemplateEndpoint();
                    
                    Stream inStream = new MemoryStream(template.File);
                    client.AddTemplate(proxyTemplate, template.File.Length, inStream);
                }
                catch (Exception e)
                {
                    ProxyErrorHandler.Throw(e, "Error occured while adding template");
                }
                
            }//end function


            /// <summary>
            /// Delete Template
            /// </summary>
            /// <param name="templateID"></param>
            static public void DeleteTemplate(string templateID)
            {
                try
                {
                    TemplateServiceContractClient client = new TemplateServiceContractClient();
                    client.Endpoint.Address = SeverSettings.GetTemplateEndpoint();

                    client.DeleteTemplate(templateID);
                }
                catch (Exception e)
                {
                    ProxyErrorHandler.Throw(e, "Error occured while deleting template");
                }
                
            }//end function


            /// <summary>
            /// Internal Template To FeedTemplate
            /// </summary>
            /// <param name="from"></param>
            /// <returns></returns>
            private static Inspire.Events.Proxy.FeedTemplate InternalTemplateToFeedTemplate(Inspire.Events.Proxy.TemplateService.FeedTemplate from)
            {
                var to = new Inspire.Events.Proxy.FeedTemplate();

                to.Description = from.Description;
                to.Fields = (FeedTemplate.FieldsEnum)from.Fields;
                to.Guid = from.GUID;
                to.Name = from.Name;
                to.Rows = from.Rows;
                if (from.ThumbNail != null) to.Thumb_Nail = from.ThumbNail;
                to.Type = from.Type;

                return to;
            }

            /// <summary>
            /// Feed Template To Internal Template
            /// </summary>
            /// <param name="from"></param>
            /// <returns></returns>
            private static Inspire.Events.Proxy.TemplateService.FeedTemplate FeedTemplateToInternalTemplate(Inspire.Events.Proxy.FeedTemplate from)
            {
                var to = new Inspire.Events.Proxy.TemplateService.FeedTemplate();

                to.Description = from.Description;
                to.Fields = (int?)from.Fields;
                to.GUID = from.Guid;
                to.Name = from.Name;
                to.Rows = from.Rows;
                if (from.Thumb_Nail != null) to.ThumbNail = from.Thumb_Nail;
                to.Type = from.Type;

                return to;
            }



      }
}

