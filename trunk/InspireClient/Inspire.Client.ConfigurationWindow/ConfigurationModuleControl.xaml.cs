using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Inspire.Interfaces;
using Inspire.Services.WeakEventHandlers;

namespace Inspire.Client.ConfigurationWindow
{
    /// <summary>
    /// Interaction logic for ConfigurationModuleControl.xaml
    /// </summary>
    public partial class ConfigurationModuleControl : IWeakEventListener
    {

        private bool controlLoaded;

        private readonly ObservableCollection<ConfigurationModule> ModuleList;

        public ConfigurationModuleControl()
        {
            InitializeComponent();
            LoadedEventManager.AddListener(this, this);

            ModuleList = new ObservableCollection<ConfigurationModule>();

            configurationModulePanel.ItemsSource = ModuleList;
        }

        void ConfigurationModuleControl_Loaded(object sender, EventArgs e)
        {
            if (!controlLoaded)
            {
                int controlCount = 0;
                Window mainApp;
                if (Application.Current.Windows.Count > 1)
                    mainApp = Application.Current.Windows[1];
                else
                {
                    mainApp = Application.Current.Windows[0];
                }

                UserControl configureWindow;

                Grid configHolder = new Grid();

                                if (mainApp != null)
                                {
                                    configureWindow = mainApp.FindName("ConfigureWindow") as UserControl;
                                    if (configureWindow != null)
                                    {
                                        configHolder = configureWindow.FindName("ConfigurationWindowHolder") as Grid;
                                    }
                                }

                List<string> assemblyList = InspireModules.Assemblies;

                foreach (var asmbly in assemblyList) // TODO: Consolidate to InspireModules
                {
                    try
                    {
                        Assembly assembly =
                        Assembly.Load(AssemblyName.GetAssemblyName(Paths.ClientModulesDirectory + asmbly));

                        foreach (Type type in assembly.GetTypes())
                        {
                            // Pick up a class
                            if (type.IsClass)
                            {
                                // If it does not implement the IBase Interface, skip it
                                if (type.GetInterface("IConfigurable") == null)
                                {
                                    continue;
                                }

                                IConfigurable imediaModule = (IConfigurable)Activator.CreateInstance(type);

                                ConfigurationModule configurationModule = new ConfigurationModule();

                                try
                                {

                                    configurationModule.Name = imediaModule.GetConfigurationTitle();

                                    configurationModule.Assembly = type.Namespace;

                                    Stream imageStream =
                                        assembly.GetManifestResourceStream(type.Namespace + ".Resources.Image.png");

                                    if (imageStream != null)
                                    {
                                        BitmapFrame bmp = BitmapFrame.Create(imageStream);
                                        Image image = new Image();
                                        image.Source = bmp;
                                        configurationModule.ModuleImage = image;
                                    }

                                    ModuleList.Add(configurationModule);

                                    UserControl configurationControl = imediaModule.GetConfigurationWindow();

                                    configurationControl.Name = type.Namespace;

                                    if (controlCount > 0)
                                        configurationControl.Visibility = Visibility.Collapsed; // TODO: make Hidden, and Unhidden, this is a security risk.

                                    if (configHolder != null) configHolder.Children.Add(configurationControl);

                                    controlCount++;

                                }
                                finally
                                {
                                    controlLoaded = true;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // asmbly + "failed to load.";// TODO: Log this
                    }
                    
                }
            }
        }

        private void ModuleItem_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ConfigurationModule configurationModule = (ConfigurationModule)((ContentControl)sender).DataContext;

            Window mainApp = Application.Current.Windows[0];

            if (mainApp != null)
            {
                UserControl configureWindow = mainApp.FindName("ConfigureWindow") as UserControl;
                if (configureWindow != null)
                {
                    Grid configHolder = configureWindow.FindName("ConfigurationWindowHolder") as Grid;
                    if (configHolder != null)
                        foreach (UserControl control in configHolder.Children)
                        {
                            if (configurationModule.Assembly == control.Name)
                                control.Visibility = Visibility.Visible;
                            else
                                control.Visibility = Visibility.Collapsed;
                        }

                }
            }
            e.Handled = true;
        }

        private void Button_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                ConfigurationModuleControl_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
