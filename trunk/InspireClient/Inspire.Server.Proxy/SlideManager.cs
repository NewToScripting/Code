using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Inspire.Server.Proxy.SlideFileServiceReference;
using Inspire.Server.Proxy.SlideServiceReference;
using System.Web;


namespace Inspire.Server.Proxy
{
    /// <summary>
    /// Slide Manager
    /// </summary>
    public class SlideManager
    {
        static public bool IsSending { get; set; }

        /// <summary>
        /// Get Slides
        /// </summary>
        /// <returns></returns>
        static public List<Slide> GetSlides()
        {
            var slideList = new List<Slide>();

            try
            {
                SlideManagerServiceContractClient client = new SlideManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetSlideEndpoint();
                var slides = client.GetAllSlides();

                slideList.AddRange(slides.Select(SlideTranslators.CommonSlideOut));
            }//try
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting slides");
            }

            return slideList;
            
        }

        /// <summary>
        /// Get SlideFile
        /// </summary>
        /// <param name="slideID"></param>
        /// <param name="worker"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public SlideFile GetSlideFile(string slideID, BackgroundWorker worker, bool reportBack)
        {
            SlideFile slideout = new SlideFile();

            Stream stream = null;
            try
            {
                SlideManagerServiceContractClient client = new SlideManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetSlideEndpoint();
                Inspire.Server.Proxy.SlideServiceReference.Slide slide = client.GetSlide(slideID);
                slideout = SlideTranslators.CommonSlideFileOut(slide);
                
                SlideFileManagerServiceContractClient client2 = new SlideFileManagerServiceContractClient();
                client2.Endpoint.Address = SeverSettings.GetSlideFileEndpoint();

                int fileSize;
                
                slideout.GUID = client2.GetSlideFile(slideID, out fileSize, out stream);
                slideout.File = StreamToBytes.ReadFully(stream, fileSize, worker, reportBack);
               
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while getting slidefile");
            }
            finally
            {
                if (stream != null) stream.Dispose();
            }

           
            return slideout;
        }

        /// <summary>
        /// Add SlideFile
        /// </summary>
        /// <param name="slide"></param>
        static public void AddSlideFile(SlideFile slide)
        {
            bool transferGood = false;

           try
            {
                IsSending = true;
                HttpContext httpContext = HttpContext.Current;
                if (httpContext != null)
                {
                    httpContext.Response.BufferOutput = false;
                }

                SlideManagerServiceContractClient client = new SlideManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetSlideEndpoint();
                client.AddSlide(SlideTranslators.ServiceSlideOut(slide));

                using (Stream stream = new MemoryStream(slide.File))
                {
                    SlideFileManagerServiceContractClient client2 = new SlideFileManagerServiceContractClient();
                    client2.Endpoint.Address = SeverSettings.GetSlideFileEndpoint();
                    client2.AddSlideFile(slide.GUID, slide.File.Length, stream);
                    transferGood = true;
                    stream.Dispose();
                }

                Files.ClearDirectory(Paths.ClientTransferDirectory);
            }
           catch (Exception e)
           {
               transferGood = false;
               ProxyErrorHandler.Throw(e, "Error occured while adding slidefile");
               // TODO throw message back up to the UI.
               
           }
           finally
           {

               SlideItemCollection.RePopulateSlides(slide.GUID, transferGood);
               IsSending = false;
           }
            
        }

        /// <summary>
        /// Update SlideFile
        /// </summary>
        /// <param name="slide"></param>
        static public void UpdateSlideFile(SlideFile slide)
        {
            bool transferGood = false;
            try
            {
                IsSending = true;
                HttpContext httpContext = HttpContext.Current;
                if (httpContext != null)
                {
                    httpContext.Response.BufferOutput = false;
                }

                SlideManagerServiceContractClient client = new SlideManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetSlideEndpoint();
                client.UpdateSlide(SlideTranslators.ServiceSlideOut(slide));

                //Add SlideFile
                using (Stream stream = new MemoryStream(slide.File))
                {

                    SlideFileManagerServiceContractClient client2 = new SlideFileManagerServiceContractClient();
                    client2.Endpoint.Address = SeverSettings.GetSlideFileEndpoint();
                    client2.UpdateSlideFile(slide.GUID, slide.File.Length, stream);
                    transferGood = true;
                    stream.Dispose();
                }

                Files.ClearDirectory(Paths.ClientTransferDirectory);
            }

           catch (Exception e)
           {
               ProxyErrorHandler.Throw(e, "Error occured while updating slidefile");
               transferGood = false;
           }
            finally
            {
                IsSending = false;
                SlideItemCollection.RePopulateSlides(slide.GUID, transferGood);
            }
            
        }

        /// <summary>
        /// Delete SlideFile
        /// </summary>
        /// <param name="slideID"></param>
        static public void DeleteSlideFile(string slideID)
        {
            try
            {
                SlideManagerServiceContractClient client = new SlideManagerServiceContractClient();
                client.Endpoint.Address = SeverSettings.GetSlideEndpoint();
                client.DeleteSlide(slideID);

                SlideFileManagerServiceContractClient client2 = new SlideFileManagerServiceContractClient();
                client2.Endpoint.Address = SeverSettings.GetSlideFileEndpoint();
                client2.DeleteSlideFile(slideID);
            }
            catch (Exception e)
            {
                ProxyErrorHandler.Throw(e, "Error occured while deleting slidefile");
            }

            
        }
        
    }
}
 