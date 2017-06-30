using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Inspire.Designer.Commands;
using Inspire.Helpers;
using Inspire.Interfaces;
using Inspire.MediaObjects;
using Inspire.Services.WeakEventHandlers;

namespace Inspire.Client.Designer.DesignPropertyPanel
{
    /// <summary>
    /// Interaction logic for DesignModuleControl.xaml
    /// </summary>
    public partial class DesignModuleControl : IWeakEventListener
    {
        private bool controlLoaded;

        private readonly ObservableCollection<MediaModule> ModuleList;
        private readonly ObservableCollection<MediaModule> AppsList;

        private readonly List<MediaModule> unSortedModules;

        public DesignModuleControl()
        {
            InitializeComponent();

            LoadedEventManager.AddListener(this, this);
            ModuleList = new ObservableCollection<MediaModule>();
            AppsList = new ObservableCollection<MediaModule>();
            unSortedModules = new List<MediaModule>();

            designModulePanel.ItemsSource = ModuleList;
            designAppPanel.ItemsSource = AppsList;
        }

        private void SortModules(IEnumerable<MediaModule> unSortedModules)
        {
            if (unSortedModules == null) throw new ArgumentNullException("unSortedModules");
            {
                List<MediaModule> mediaModules = unSortedModules.OrderBy(mediamodule => mediamodule.Name).ToList();
                foreach (var module in mediaModules)
                {
                    if(module.IsApp)
                        AppsList.Add(module);
                    else
                        ModuleList.Add(module);
                }
            }
        }

        void DesignModuleControl_Loaded(object sender, EventArgs e)
        {
            if (!controlLoaded)
            {
                // TODO: Change to only read purchased modules, consolidate with InspireModules
                List<string> assemblyList = InspireModules.Assemblies; 

                foreach (var asmbly in assemblyList)
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
                                if (type.GetInterface("IMediaModule") == null)
                                {
                                    continue;
                                }

                                IMediaModule imediaModule = (IMediaModule)Activator.CreateInstance(type);

                                MediaModule mediaModule = new MediaModule();

                                try
                                {
                                    mediaModule.Name = imediaModule.GetModuleName();

                                    mediaModule.Type = imediaModule.GetModuleType();

                                    mediaModule.IsPanelModule = imediaModule.GetIsPanelModule();

                                    mediaModule.IsApp = imediaModule.GetIsApp();

                                    mediaModule.Assembly = type.Namespace;

                                    if (mediaModule.IsPanelModule)
                                    {
                                        using (Stream imageStream =
                                            assembly.GetManifestResourceStream(type.Namespace + ".Resources.Image.png"))
                                        {

                                            if (imageStream != null)
                                            {
                                                BitmapFrame bmp = BitmapFrame.Create(imageStream);
                                                bmp.Freeze();
                                                imageStream.Dispose();
                                                Image image = new Image();
                                                image.Source = bmp;
                                                mediaModule.ModuleImage = image;
                                            }
                                        }

                                        unSortedModules.Add(mediaModule);
                                    }

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
                SortModules(unSortedModules);
            }
        }

        private void ModuleItem_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var mediaModuleSelected = (MediaModule)((ContentControl)sender).DataContext;   // TODO: Null Ref Exept
                DragDrop.DoDragDrop(designModulePanel, mediaModuleSelected, DragDropEffects.Copy);
                e.Handled = true;
            }
            catch (Exception ex)
            {
                e.Handled = true;
               // MessageBox.Show("Error Comming from " + sender + ex.Message);
            }
        }

        private void Button_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MediaModule mediaModule = (MediaModule)((ContentControl)sender).DataContext;

            Assembly assembly =
                Assembly.Load(AssemblyName.GetAssemblyName(Paths.ClientModulesDirectory + mediaModule.Assembly + ".dll"));

            if(InspireApp.CanvasExists)
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

                    IMediaModule imediaModule = (IMediaModule)Activator.CreateInstance(type);

                    
                   DragCanvas.DragCanvas canvas = UIHelper.GetCurrentDragCanvas() as DragCanvas.DragCanvas;

                   if (canvas != null)
                   {
                       DesignContentControl designContentControl = imediaModule.Execute(canvas.Width, canvas.Height);


                       if (designContentControl != null)
                       {

                           var controlHolder = new DesignControlHolder(designContentControl);

                           controlHolder.Content = designContentControl;

                           designContentControl.GUID = Guid.NewGuid().ToString();

                           designContentControl.Type = mediaModule.Type;

                           designContentControl.AssemblyInfo = mediaModule.Assembly;

                           AddDesignItemCommand command = new AddDesignItemCommand(canvas.DataItems,
                                                                                   controlHolder, canvas, false);
                           if (canvas.undoService != null)
                           {
                               canvas.undoService.Execute(command);
                           }
                           else
                               command.Execute();
                       }
                   }
                }
            }
            e.Handled = true;
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                DesignModuleControl_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
