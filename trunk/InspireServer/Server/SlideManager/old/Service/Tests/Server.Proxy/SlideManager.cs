using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Proxy.SlidesServiceReference;

namespace Server.Proxy
{
    static public class SlideManager
    {
        
        static public Slides GetSlides()
        {
           SlideManagerServiceContractClient client = new SlideManagerServiceContractClient();
           Slides slides = client.GetAllSlides();
           return slides;
        }

        static public void AddSlide(Slide slide)
        {
            SlideManagerServiceContractClient client = new SlideManagerServiceContractClient();
            client.AddSlide(slide);
        }

        static public void UpdateSlide(Slide slide)
        {
            SlideManagerServiceContractClient client = new SlideManagerServiceContractClient();
            client.UpdateSlide(slide);
        }

        static public void DeleteSlide(string slideID)
        {
            SlideManagerServiceContractClient client = new SlideManagerServiceContractClient();
            client.DeleteSlide(slideID);
        }

    }
}
