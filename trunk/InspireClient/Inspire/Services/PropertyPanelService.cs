using System;
using System.Reflection;
using System.Windows.Controls;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Services
{
    public class PropertyPanelService
    {

        private UserControl propertyUserControl;

        public UserControl GetPropertyPanel(DesignContentControl contentControl)
        {

            Assembly assembly =
                Assembly.Load(
                    AssemblyName.GetAssemblyName(Paths.ClientModulesDirectory + contentControl.AssemblyInfo + ".dll"));

            foreach (Type type in assembly.GetTypes())
            {
                // Pick up a class
                if (type.IsClass)
                {
                    // If it does not implement the IMediaModule Interface, skip it
                    if (type.GetInterface("IMediaModule") == null)
                    {
                        continue;
                    }

                    var imediaModule = (IMediaModule) Activator.CreateInstance(type);

                    propertyUserControl = imediaModule.GetPropertyPanel();
                    break;
                }
            }
            propertyUserControl.DataContext = InspireApp.SelectedContext;

            return propertyUserControl;
        }
    }
}
