using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Inspire.Interfaces;

namespace Inspire
{
    public class RoutingHelper
    {
        public static IInputElement FindControl(string guidToFilterOn)
        {
            if(InspireApp.IsPlayer)
            {
                try
                {
                var designItems = InspireApp.GetPlayerDesignItems();
                var contentHolder = designItems.FirstOrDefault(s => ((IDesignContentControl)s).GUID == guidToFilterOn);
                if (contentHolder != null)
                    return contentHolder;
                //return ((IEnumerable<DesignContentControl>)InspireApp.GetPlayerDesignItems()).FirstOrDefault(s => s.GUID == guidToFilterOn) as IInputElement;
                }
                catch (Exception)
                {
                    return null; // dont throw.
                }
            }
            if(InspireApp.IsPlaying)
            {
                try
                {
                    var designItems = InspireApp.GetDesignItems();
                    var contentHolder = designItems.FirstOrDefault(s => ((IDesignContentControl)s).GUID == guidToFilterOn);
                    if (contentHolder != null)
                    {
                        var content = contentHolder.Content as ContentControl;
                        if (content != null) return content.Content as IInputElement;
                    }
                    return null;
                }
                catch (Exception)
                {
                    return null; // dont throw.
                }
            }
            if(InspireApp.IsPreviewMode)
            {
                try
                {
                var designItems = InspireApp.GetCurrentPreviewDesignItems();
                var contentHolder = designItems.FirstOrDefault(s => ((IDesignContentControl)s).GUID == guidToFilterOn);
                if (contentHolder != null)
                    return contentHolder;
                }
                catch (Exception)
                {
                    return null; // dont throw.
                }
                
               // return ((IEnumerable<DesignContentControl>)InspireApp.GetCurrentPreviewDesignItems()).FirstOrDefault(s => s.GUID == guidToFilterOn) as IInputElement;   
            }
            return null;
        }
    }
}
