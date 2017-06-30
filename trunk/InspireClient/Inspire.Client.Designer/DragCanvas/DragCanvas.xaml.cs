using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;
using Inspire.Client.Designer.DesignPropertyPanel;
using Inspire.Commands;
using Inspire.Common.Dialogs;
using Inspire.Common.Utility;
using Inspire.Designer.Commands;
using Inspire.Helpers;
using Inspire.Interfaces;
using Inspire.MediaObjects;
using Inspire.Server.Proxy;
using Inspire.Services;
using System.Windows.Threading;

namespace Inspire.Client.Designer.DragCanvas
{
    /// <summary>
    /// Interaction logic for DragCanvas.xaml
    /// </summary>
    public partial class DragCanvas : IDragCanvas , IDisposable , IInspireCanvas
    {

        public DragCanvas()
        {
            InitializeComponent();
            DataItems = new ObservableCollection<ContentControl>();

            GarbageItems = new List<ContentControl>();

            DataContext = this;

            selectionService = new SelectionService(DataItems);
            propertyPanelService = new PropertyPanelService();
            undoService = new UndoService();
            //Clipboard.Clear();
            //IsPlaying = false; TODO: update with parent reference
            //IsCreated = false; TODO: update with parent reference

            InspireCommands.SelectAllCommand.InputGestures.Add(new KeyGesture(Key.A, ModifierKeys.Control));
            InspireCommands.CutCommand.InputGestures.Add(new KeyGesture(Key.X, ModifierKeys.Control));
            InspireCommands.PasteCommand.InputGestures.Add(new KeyGesture(Key.V, ModifierKeys.Control));
            InspireCommands.CopyCommand.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Control));
            InspireCommands.UndoCommand.InputGestures.Add(new KeyGesture(Key.Z, ModifierKeys.Control));
            InspireCommands.RedoCommand.InputGestures.Add(new KeyGesture(Key.Y, ModifierKeys.Control));
            InspireCommands.MoveItemUpCommand.InputGestures.Add(new KeyGesture(Key.Up));
            InspireCommands.MoveItemDownCommand.InputGestures.Add(new KeyGesture(Key.Down));
            InspireCommands.MoveItemLeftCommand.InputGestures.Add(new KeyGesture(Key.Left));
            InspireCommands.MoveItemRightCommand.InputGestures.Add(new KeyGesture(Key.Right));
            InspireCommands.MoveItemUpShiftCommand.InputGestures.Add(new KeyGesture(Key.Up, ModifierKeys.Shift));
            InspireCommands.MoveItemDownShiftCommand.InputGestures.Add(new KeyGesture(Key.Down, ModifierKeys.Shift));
            InspireCommands.MoveItemLeftShiftCommand.InputGestures.Add(new KeyGesture(Key.Left, ModifierKeys.Shift));
            InspireCommands.MoveItemRightShiftCommand.InputGestures.Add(new KeyGesture(Key.Right, ModifierKeys.Shift));
        }

        public ObservableCollection<ContentControl> DataItems { get; set; }

        public int ZoomValue { get; set; }

        public bool OverWriteSlide { get; set; }

        public UndoService undoService { get; set; }

        public List<ContentControl> GarbageItems { get; set; }

        private delegate void SaveSlideDelegate(SlideFile slideFile);

        private delegate void HidePropertyPanelDelegate();

        private delegate void OneIntDelegate(int arg);

        private delegate void ClearSelectionDelegate();

        private delegate void CreateThumbDelegate(SlideFile slideFile, bool deleteThumbNail, bool saveLocal);

        private delegate void AddSlidetoCollectionDelegate(SlideFile slideFile);

        public Point DropPoint { get; set; }

        public Slide TempSlide { get; set; }

        public string NewSlideGuid { get; set; }

        public string SavedSlideGuid { get; set; }

        public bool IsOfflineSlide { get; set; }

        private string currentDesignContentControlGuid = string.Empty;

        private Point? rubberbandSelectionStartPoint;

        private List<ControlPosition> startControlPositions;

        private UserControl proptertyPanel;

        private void UserControl_Drop(object sender, DragEventArgs e)
        {
            DesignerCanvas_Drop(sender, e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case (Key.Delete):
                    DeleteCurrentSelection();
                    Focus();
                    break;
                default:
                    break;
            }
        }

        private void DesignerCanvas_Drop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);

            string[] fileFormats = e.Data.GetFormats();
            e.Effects = DragDropEffects.None;

            DropPoint = e.GetPosition(this);

            if (fileFormats[0] == "Inspire.Slide" || fileFormats[0] == "Inspire.SlideFile") // TODO: check based on type not string
            {
                //if(DataItems.Count > 1)
                //    DetatchReflections();

                //DataItems.Clear();

                //Files.ClearDirectory(Paths.ClientTempDirectory);

                try
                {
                    var slide = (Slide)e.Data.GetData(typeof(Slide)) ?? e.Data.GetData(typeof(SlideFile)) as Slide;

                    TempSlide = slide;

                    ICommand command = InspireCommands.LoadSlideCommand;
                    command.Execute(slide);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Loading Slide " + ex);
                }
            }
            if (fileFormats[0] == "Inspire.MediaObjects.MediaModule") // TODO: check based on type not string
            {

                var mediaModule = (MediaModule)e.Data.GetData(typeof(MediaModule));

                Assembly assembly =
                    Assembly.Load(AssemblyName.GetAssemblyName(Paths.ClientModulesDirectory + mediaModule.Assembly + ".dll"));

                foreach (var type in assembly.GetTypes())
                {
                    // Pick up a class
                    if (!type.IsClass) continue;
                    // If it does not implement the IMediaModule Interface, skip it
                    if (type.GetInterface("IMediaModule") == null) continue;

                    var imediaModule = (IMediaModule) Activator.CreateInstance(type);

                    DesignContentControl designContentControl = imediaModule.Execute(Width, Height);

                    if (designContentControl != null)
                    {
                        var controlHolder = new DesignControlHolder(designContentControl);

                        controlHolder.Content = designContentControl;

                        designContentControl.GUID = Guid.NewGuid().ToString();

                        designContentControl.Type = mediaModule.Type;

                        designContentControl.AssemblyInfo = Path.GetFileNameWithoutExtension(mediaModule.Assembly);

                        var command = new AddDesignItemCommand(DataItems, controlHolder, this, true);

                        if (undoService != null)
                        {
                            undoService.Execute(command);
                        }
                        else
                            command.Execute();
                    }
                }

            }
            else
            {
                var fileNames = e.Data.GetData(DataFormats.FileDrop, true) as string[];

                DropPoint = e.GetPosition(this);

                AddFilesToCanvas(fileNames);
            }
            UpdateZIndex();
            InvalidateVisual();
            // Mark the event as handled, so the control's native Drop handler is not called.
            e.Handled = true;
        }

        private delegate void LoadCanvasXamlDelegate(Slide slide);

        public void LoadSlideToCanvas(object sender, DoWorkEventArgs e) // (Slide slide)
        {
            var worker = (BackgroundWorker)sender;

            var args = e.Argument as List<object>;

            if (args != null)
            {
                var slide = (Slide)args[0];

                if (slide != null)
                {
                    string message;

                    bool slideErrored = false;

                    if (!slide.IsExternalFile && slide.IsOnline)
                    {
                        message = "Loading Slide from Server.......";

                        worker.ReportProgress(int.MinValue, message);

                        SlideFile slidefile = SlideManager.GetSlideFile(slide.GUID, worker, true);

                        if (slidefile != null && slidefile.File != null)
                        {
                            string filename = Paths.ClientTempDirectory + slidefile.GUID + ".insp";
                            Files.SaveStreamToFile(slidefile.File, filename);

                            message = "Unpacking Slide.......";

                            worker.ReportProgress(int.MinValue, message);

                            ZipUtil.NewUnZipFiles(filename, Paths.ClientTempDirectory + slidefile.GUID, "wookie", true);

                            File.Delete(filename);
                        }
                        else
                        {
                            slideErrored = true;
                            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                                                                                        {
                                                                                            var commonDialog =
                                                                                                new CommonDialog(
                                                                                                    "Slide Cannot Be Found",
                                                                                                    "There was an error retrieving the slide. Try loading the slide again, if the problem persists contact technical support.",
                                                                                                    "Ok", "Close");
                                                                                            commonDialog.ShowDialog();
                                                                                            InspireCommands.
                                                                                                RefreshSlidesCommand.
                                                                                                Execute(null, null);
                                                                                        }));

                        }
                    }
                    else if(!slide.IsOnline && !slide.IsExternalFile)
                    {
                        message = "Unpacking File.......";

                        worker.ReportProgress(int.MinValue, message);

                        ZipUtil.NewUnZipFiles(Paths.ClientLocalSlidePackagesDirectory + slide.GUID + ".insp", Paths.ClientTempDirectory + slide.GUID, "wookie", true);
                    }
                    else
                    {
                        message = "Loading Slide from File.......";

                        worker.ReportProgress(int.MinValue, message);

                        string slidePath = Paths.FindFirstLayerFolderPath(Paths.ClientTransferDirectory);

                        slidePath = Paths.ClientTransferDirectory + slidePath;

                        if (slidePath != null)
                        {
                            Files.CopyFolderToFolder(new DirectoryInfo(slidePath),
                                                     new DirectoryInfo(Paths.ClientTempDirectory + slide.GUID + "//"));
                        }
                    }

                    message = "Loading Slide to Canvas.......";

                    worker.ReportProgress(int.MinValue, message);

                    if (!slideErrored)
                    {
                        LoadCanvasXamlDelegate loadCanvasXamlDelegate = SlideXamlToCanvas;

                        Dispatcher.Invoke(DispatcherPriority.Normal, loadCanvasXamlDelegate, slide);
                    }
                }
            }
        }

        private void SlideXamlToCanvas(Slide slide)
        {
            try
            {
                var context = new ParserContext();
                context.BaseUri = new Uri(Paths.ClientTempDirectory + slide.GUID + @"/", UriKind.Absolute);
                Canvas canvas;
                using (var xamlFile = new FileStream(Paths.ClientTempDirectory + slide.GUID + @"/" + "Canvas.xaml", FileMode.Open, FileAccess.Read))
                {
                    canvas = XamlReader.Load(xamlFile, context) as Canvas;
                }
                if (canvas != null)
                {
                    InspireApp.CurrentSlideGuid = slide.GUID;

                    Width = slide.HResolution;
                    Height = slide.VResolution;
                    Visibility = Visibility.Visible;
                    Background = canvas.Background ?? Brushes.White;

                    Window mainApp = Application.Current.Windows[0];

                    if (mainApp != null)
                    {
                        var designWindow = mainApp.FindName("DesignerWindow") as UserControl;

                        if (designWindow != null)
                        {
                            var label = designWindow.FindName("lblNewSlide") as Label;
                            if (label != null) label.Visibility = Visibility.Collapsed;
                        }
                    }

                    while (canvas.Children.Count > 0)
                    {
                        var uiElement = canvas.Children[0] as DesignContentControl;

                        canvas.Children.Remove(uiElement);

                        if (uiElement == null) continue;

                        try
                        {
                            Assembly assembly = Assembly.Load(AssemblyName.GetAssemblyName(Paths.ClientModulesDirectory + uiElement.AssemblyInfo + ".dll"));

                            foreach (Type type in assembly.GetTypes())
                            {
                                // Pick up a class
                                if (type.IsClass)
                                {
                                    // If it does not implement the IMediaModule Interface, skip it
                                    if (type.GetInterface("IMediaModule") == null) continue;

                                    var imediaModule = (IMediaModule)Activator.CreateInstance(type);

                                    DesignContentControl designContentControl = imediaModule.CreateClientControl(uiElement);

                                    designContentControl.SetDesignerTransform();

                                    var designHolder = new DesignControlHolder(designContentControl);

                                    var left = Canvas.GetLeft(designContentControl);
                                    var top = Canvas.GetTop(designContentControl);

                                    designContentControl.Visibility = Visibility.Visible;

                                    Canvas.SetLeft(designHolder, left);
                                    Canvas.SetTop(designHolder, top);

                                    designHolder.Resources = AnimationLibrary.AnimationManager.GetStoryBoardFromTrigger(designContentControl);

                                    InspireApp.StopAnimations(designHolder);

                                    DataItems.Add(designHolder);
                                }
                            }
                        }
                        catch (FileNotFoundException ex)
                        {
                            var commonDialog = new CommonDialog("Error", "App not found: " + Path.GetFileNameWithoutExtension(ex.FileName) + ".  Please call 1-877-512-3451 for further assistance.");
                            commonDialog.ShowDialog();
                        }
                        catch (Exception)
                        {}
                    }

                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => AttachReflections(DataItems)));

                   // IsCreated = true; TODO: update with parent reference

                    TempSlide = slide;
                }
                else
                {
                    MessageBox.Show("Unable to Load Canvas from SlideLoad.");
                }
            }
            catch (Exception ex)
            {
                var commonDialog = new CommonDialog("Error", "The Slide was unable to load. The module failed to load. Please call technical support at 1-877-512-3451 for further assistance.");
                commonDialog.ShowDialog();

#if DEBUG
                MessageBox.Show("The Slide was unable to load." + ex.Message);
#endif
            }
        }

        internal void AddFilesToCanvas(string[] fileNames)
        {
            if (fileNames != null)
            {
                foreach (var fileName in fileNames)
                {
                    string fileExtension = Path.GetExtension(fileName);

                    bool fileAdded = false;

                    foreach (var inspireModule in InspireModules.IModules)
                    {
                        if(inspireModule.SupportedExtentions != null)
                        if(inspireModule.SupportedExtentions.Contains(fileExtension.ToLower()))
                        {
                            Assembly assembly = Assembly.Load(AssemblyName.GetAssemblyName(Paths.ClientModulesDirectory + inspireModule.ModuleDLL));

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

                                    var imediaModule = (IMediaModule)Activator.CreateInstance(type);

                                    DesignContentControl designContentControl = imediaModule.CreateContentControl(fileName);

                                    var designContentHolder = new DesignControlHolder(designContentControl);

                                    if (designContentControl != null)
                                    {
                                        designContentControl.GUID = Guid.NewGuid().ToString();

                                        designContentControl.IsNew = true;

                                        designContentControl.AssemblyInfo = Path.GetFileNameWithoutExtension(inspireModule.ModuleDLL);

                                        try
                                        {
                                            var command = new AddDesignItemCommand(DataItems,designContentHolder, this, true);

                                            if (undoService != null)
                                            {
                                                undoService.Execute(command);
                                            }
                                            else
                                                command.Execute();
                                            fileAdded = true;
                                            break;
                                        }
                                        catch (Exception ex)
                                        {
                                            // Todo: Remove this and add to log
                                            MessageBox.Show(ex.ToString());
                                        }

                                        selectionService.SelectItem(designContentHolder);
                                    }
                                }
                            }
                        }
                        if (fileAdded)
                            break;
                    }
                }
            }
        }

        //public static UndoService undoService;

        public SelectionService selectionService;

        public PropertyPanelService propertyPanelService;

        public void CopyCurrentSelection()
        {
            IEnumerable<ContentControl> selectedDesignerItems = selectionService.CurrentSelection.OfType<ContentControl>();

            string root = "<Canvas xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" >";


            foreach (DesignControlHolder item in selectedDesignerItems)
            {

                double top = Canvas.GetTop(item);
                double left = Canvas.GetLeft(item);
               //double rotation = item.RotateTransform.Angle;

                Canvas.SetTop((ContentControl)item.Content, Canvas.GetTop(item));
                Canvas.SetLeft((ContentControl)item.Content, Canvas.GetLeft(item));

                ((ContentControl) item.Content).Width = item.Width;
                ((ContentControl)item.Content).Height = item.Height;
                ((DesignContentControl) item.Content).RotateTransform = item.RotateTransform;
                ((DesignContentControl) item.Content).SkewTransform = item.SkewTransform;
                ((DesignContentControl) item.Content).ScaleTransform = item.ScaleTransform;
                ((DesignContentControl) item.Content).TranslateTransform = item.TranslateTransform;

                Assembly assembly =
                    Assembly.Load(
                        AssemblyName.GetAssemblyName(Paths.ClientModulesDirectory + ((DesignContentControl)item.Content).AssemblyInfo + ".dll"));

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

                        // designContentControl.SetPlayerTransform();
                        if (TempSlide != null)
                            root += imediaModule.CreatePlayerControl((DesignContentControl)item.Content, TempSlide.GUID);
                        else
                        {
                            root += imediaModule.CreatePlayerControl((DesignContentControl)item.Content, InspireApp.CurrentSlideGuid);
                        }
                    }
                }

            Canvas.SetTop(item, top);
            Canvas.SetLeft(item, left);

            ((ContentControl) item.Content).Width = double.NaN;
            ((ContentControl) item.Content).Height = double.NaN;
            }

            root += "</Canvas>";

            Clipboard.Clear();

            // This gets around a bug in the .Net 2.0 framework where the clipboard fails to open
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    Clipboard.SetData(DataFormats.Xaml, root);
                }
                catch
                { }
                System.Threading.Thread.Sleep(50);
            }

        }

        public void CutCurrentSelection()
        {
            CopyCurrentSelection();
            DeleteCurrentSelection();
        }

        private void UpdateZIndex()
        {
            try
            {
                var ordered = (from DesignControlHolder item in DataItems
                                                      orderby Canvas.GetZIndex(item)
                                                      select item).ToList();

                //for (int i = ordered.Count; i > 0; i--)
                //{
                //    Canvas.SetZIndex(ordered[i], i);
                //}
                for (int i = 0; i < ordered.Count; i++)
                {
                    Canvas.SetZIndex(ordered[i], i);
                }
            }
            catch (Exception)
            {
  
            }
        }

        public void DeleteCurrentSelection()
        {

            foreach (ContentControl item in selectionService.CurrentSelection.OfType<ContentControl>())
            {

                var command = new DeleteDesignItemCommand(DataItems, item, this);
                undoService.Execute(command);

            }

            selectionService.ClearSelection();
            UpdateZIndex();
            HidePropertyPanel();
        }

        private void InspireCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!DesignWindow.GetDesignerWindow().IsPlaying)
            {
                base.OnMouseDown(e);
                if (e.Source.GetType().Name != "DesignContentControl")
                {
                    selectionService.ClearSelection();
                }

                DesignControlHolder elementBeingDragged = FindCanvasChild(e.Source as DependencyObject);
                if (elementBeingDragged == null || elementBeingDragged.IsLocked)
                    return;

                if ((Keyboard.Modifiers & (ModifierKeys.Shift | ModifierKeys.Control)) != ModifierKeys.None)
                    if (elementBeingDragged.IsSelected)
                    {
                        selectionService.RemoveFromSelection(elementBeingDragged);
                    }
                    else
                    {
                        selectionService.AddToSelection(elementBeingDragged);
                    }
                else if (!elementBeingDragged.IsSelected)
                {
                    selectionService.SelectItem(elementBeingDragged);
                }

                Focus();

                if (elementBeingDragged.GetType().Name == "DesignControlHolder" &&
                    selectionService.CurrentSelection.Count < 2)
                {
                    var designContentControl = elementBeingDragged;
                    designContentControl.Focus();
                    selectionService.SelectItem(designContentControl);
                    Window mainApp = Application.Current.Windows[0];
                    if (mainApp != null)
                    {
                        var designWindow = mainApp.FindName("DesignerWindow") as DesignWindow;
                        // Use reflection to determine if the panel is from the same module than one that may already be loaded.
                        if (designWindow.InspirePropertyControl.GetCurrentPanelAssemblyName() != ((ContentControl)designContentControl.Content).Content.GetType().Assembly.GetName().Name)
                        {
                            proptertyPanel =
                                propertyPanelService.GetPropertyPanel(
                                    ((DesignContentControl)designContentControl.Content));
                            designWindow.InspirePropertyControl.ShowPropertyPanel(proptertyPanel);
                        }
                        if (currentDesignContentControlGuid != designContentControl.GUID)
                        {
                            designWindow.InspirePropertyControl.SetDataContext();
                        }

                        currentDesignContentControlGuid = designContentControl.GUID;
                        //if (designWindow != null && currentDesignContentControlGuid != designContentControl.GUID)
                        //{
                        //    currentDesignContentControlGuid = designContentControl.GUID;

                        //    proptertyPanel =
                        //        propertyPanelService.GetPropertyPanel(
                        //            ((DesignContentControl) designContentControl.Content));
                        //    designWindow.InspirePropertyControl.ShowPropertyPanel(proptertyPanel);
                        //}
                    }
                }

                startControlPositions = new List<ControlPosition>();

                foreach (DesignControlHolder item in selectionService.CurrentSelection.OfType<DesignControlHolder>())
                {
                    ControlPosition cp = new ControlPosition(item);
                    startControlPositions.Add(cp);
                }

                //if (startControlPositions == null)
                //    startControlPositions = new List<ControlPosition>();

                //startControlPositions.Clear();

                //foreach (DesignControlHolder item in selectionService.CurrentSelection.OfType<DesignControlHolder>())
                //{
                //    var cp = new ControlPosition(item);
                //    startControlPositions.Add(cp);
                //}
            }
        }

        public DesignControlHolder FindCanvasChild(DependencyObject depObj)
        {
            while (depObj != null)
            {
                // If the current object is a UIElement which is a child of the
                // Canvas, exit the loop and return it.
                var elem = depObj as DesignControlHolder;
                if (elem != null && DataItems.Contains(elem))
                    break;

                // VisualTreeHelper works with objects of type Visual or Visual3D.
                // If the current object is not derived from Visual or Visual3D,
                // then use the LogicalTreeHelper to find the parent element.
                if (depObj is Visual || depObj is Visual3D)
                    depObj = VisualTreeHelper.GetParent(depObj);
                else
                    depObj = LogicalTreeHelper.GetParent(depObj);
            }
            return depObj as DesignControlHolder;
        }

        public void PasteClipboardItems()
        {
            if (DesignWindow.GetDesignerWindow().IsPlaying) return;
            if (!Clipboard.ContainsData(DataFormats.Xaml)) return;
            var clipboardItems = Clipboard.GetData(DataFormats.Xaml) as String;

            if (clipboardItems != null)
            {
                try
                {
                    var clipBoardCanvas = XamlReader.Load(new XmlTextReader(new StringReader(clipboardItems))) as Canvas;


                    if (clipBoardCanvas != null)
                        while (clipBoardCanvas.Children.Count > 0)
                        {
                            var contentControl = clipBoardCanvas.Children[0] as DesignContentControl;
                            clipBoardCanvas.Children.Remove(contentControl);
                            try
                            {
                                if (contentControl != null)// && contentControl.IsCopyable)
                                {
                                    contentControl.IsSelected = false;
                                    contentControl.GUID = Guid.NewGuid().ToString(); //Taking this out because it is messing up copying and pasting.

                                    var controlHolder = new DesignControlHolder(contentControl);

                                    Canvas.SetTop(controlHolder, Canvas.GetTop(contentControl) + 10);
                                    Canvas.SetLeft(controlHolder, Canvas.GetLeft(contentControl) + 10);


                                    var command = new AddDesignItemCommand(DataItems, controlHolder, this, false);

                                    if (undoService != null)
                                    {
                                        undoService.Execute(command);
                                    }
                                    else
                                        command.Execute();
                                }
                            }
                            catch (Exception ex)
                            {
                                // Todo: Remove this and add to log
                                MessageBox.Show(ex.ToString());
                            }
                        }
                }
                catch (Exception)
                {
                    //MessageBox.Show("Could not paste the selected item to the canvas. Recreate the item from the components panel."); // TODO: Fix the items that cannot be pasted.
                    var commonDialog = new CommonDialog("Error", "Could not paste the selected item to the canvas. Recreate the item from the components panel.");
                    commonDialog.ShowDialog();
                    Clipboard.Clear();
                    //throw;
                }
                    
            }
        }

        #region Save Slide Methods

        [STAThread]
        public void SaveCanvasToSlide(object sender, DoWorkEventArgs e) //(string sender)
        {
            var worker = (BackgroundWorker)sender;

            var slideFile = new SlideFile();

            var args = e.Argument as List<object>;

            slideFile.GUID = Guid.NewGuid().ToString();

            if (args != null)
            {
                slideFile.Name = args[0].ToString();
                slideFile.Description = args[1].ToString();
                slideFile.HResolution = Convert.ToDouble(args[2].ToString());
                slideFile.VResolution = Convert.ToDouble(args[3].ToString());
                slideFile.Background = args[4].ToString();
            }

            ClearSelectionDelegate clearSelectionDelegate = selectionService.ClearSelection;

            Dispatcher.Invoke(DispatcherPriority.Normal, clearSelectionDelegate);

            worker.ReportProgress(20, "Creating Slide");

            CreateThumbDelegate createThumbDelegate = CreateThumbNail;

            Dispatcher.Invoke(DispatcherPriority.Normal, createThumbDelegate, slideFile, false, false);

            worker.ReportProgress(40, "Compressing Slide");

            ZipUtil.NewZipFiles(Path.Combine(Paths.SaveDirectory, InspireApp.CurrentSlideGuid), Paths.ClientTransferDirectory + slideFile.GUID + ".insp", "wookie");

            slideFile.File = File.ReadAllBytes(Paths.ClientTransferDirectory + slideFile.GUID + ".insp");

            // Set IsSaving to true, this way the slide panel with show the saving dialog on the slide while it is saving. When it is finished
            // saving set IsSaving to false
            slideFile.IsSaving = true;

            // Set IsOnline to false until the upload has succeeded, this way the slide panel with show that the slide is offline until the file is finished uploading.
            slideFile.IsOnline = false;

            worker.ReportProgress(50, "Saving the slide locally.");

            // Copy local so if the save fails we still have it.
            File.Copy(Paths.ClientTransferDirectory + slideFile.GUID + ".insp", Paths.ClientLocalSlidePackagesDirectory + slideFile.GUID + ".insp");

            Files.ClearDirectory(Paths.SaveDirectory);

            AddSlideToCollection(slideFile);

            // Writing the offline slide files with the new offline slide
            SlideCollection.SerializeOfflineSlidesToXML(SlideItemCollection.Slides);

            try
            {
                worker.ReportProgress(70,"Starting Upload Process.");

                SaveSlideDelegate workerDelegate = SlideManager.AddSlideFile;

                workerDelegate.BeginInvoke(slideFile, null, null);

               // AddSlideToCollection(slideFile);

                if (TempSlide != null)
                {
                    if (string.IsNullOrEmpty(SavedSlideGuid))
                        SavedSlideGuid = TempSlide.GUID;
                }

                TempSlide = slideFile;
            }
            catch (Exception ex)
            {
                var commonDialog = new CommonDialog("Error", "There was an error saving the slide. If the problem persists contact technical support. : " + ex.Message);
                commonDialog.ShowDialog();
            }
        }

        private void AddSlideToCollection(Slide slideFile)
        {
            AddSlidetoCollectionDelegate addSlidetoCollectionDelegate = SlideItemCollection.Slides.Add;

            Dispatcher.Invoke(DispatcherPriority.Normal, addSlidetoCollectionDelegate, slideFile);

            if (OverWriteSlide)
            {
                int slideIndex = 0;
                bool match = false;

                foreach (Slide slide in SlideItemCollection.Slides)
                {
                    if(TempSlide!= null)
                    if (slide.GUID == TempSlide.GUID)
                    {
                        match = true;
                        slideIndex = SlideItemCollection.Slides.IndexOf(slide);
                    }
                }
                if (match)
                {
                    OneIntDelegate removeOldSlide = SlideItemCollection.Slides.RemoveAt;
                    Dispatcher.Invoke(DispatcherPriority.Normal, removeOldSlide, slideIndex);
                }
            }
            NewSlideGuid = slideFile.GUID;
        }

        [STAThread]
        public void ExportCanvasToSlide(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;

            var slideFile = new SlideFile();

            var args = e.Argument as List<string>;

            string saveFilePath = string.Empty;

            bool saveLocal = false;

            slideFile.GUID = Guid.NewGuid().ToString();
            if (args != null)
            {
                slideFile.Name = args[0];
                slideFile.Description = args[1];
                slideFile.HResolution = Convert.ToDouble(args[2]);
                slideFile.VResolution = Convert.ToDouble(args[3]);
                slideFile.Background = args[4];
                saveFilePath = args[5];
                saveLocal = Convert.ToBoolean(args[6]) ;
            }

            //worker.ReportProgress(int.MinValue, message);

            //Files.ClearDirectory(Paths.ClientTempDirectory);

            ClearSelectionDelegate clearSelectionDelegate = selectionService.ClearSelection;

            Dispatcher.Invoke(DispatcherPriority.Normal, clearSelectionDelegate);

            string message = "Copying Files";

            worker.ReportProgress(int.MinValue, message);
            try
            {
                CreateThumbDelegate createThumbDelegate = CreateThumbNail;

                Dispatcher.Invoke(DispatcherPriority.Normal, createThumbDelegate, slideFile, true, saveLocal);

                message = "Packing Slides";

                worker.ReportProgress(int.MinValue, message);

                string dirToZip = Paths.SaveDirectory;

                if (saveLocal)
                {
                    saveFilePath = Paths.ClientLocalSlidePackagesDirectory + slideFile.GUID + ".insp";
                    dirToZip = Path.Combine(dirToZip, InspireApp.CurrentSlideGuid);
                }

                if (!String.IsNullOrEmpty(saveFilePath))
                {
                    if (File.Exists(saveFilePath))
                        File.Delete(saveFilePath);

                    ZipUtil.NewZipFiles(dirToZip, saveFilePath, "wookie");
                }

                if (saveLocal)
                {
                    AddSlideToCollection(slideFile);
                    SlideCollection.SerializeOfflineSlidesToXML(SlideItemCollection.Slides);
                }

                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => AttachReflections(
                                                                                           DataItems)));

                Files.ClearDirectory(Paths.SaveDirectory);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CreateThumbNail(SlideFile slideFile, bool isExport, bool isSaveLocal)
        {
            if(isExport)
            {
                var slide = new Slide(slideFile);
                Slide.SerializeToXML(slide, Paths.SaveDirectory);
                ThumbnailCreator.ExportToPng(Paths.SaveDirectory + "ThumbNail.png");
            }
            else
            {
                slideFile.ThumbNail = ThumbnailCreator.ExportToPng(Paths.ClientTempDirectory + "ThumbNail.png");

                // Copy the file to the local slide directory in case it is lost during save. We will clean these up on load.

                if (File.Exists(Paths.ClientTempDirectory + "ThumbNail.png"))
                    File.Copy(Paths.ClientTempDirectory + "ThumbNail.png", Paths.ClientLocalSlideImagesDirectory + slideFile.GUID + ".png");

                File.Delete(Paths.ClientTempDirectory + "ThumbNail.png");
            }

            if (isSaveLocal)
            {
                slideFile.ThumbNail = ThumbnailCreator.ExportToPng(Paths.ClientLocalSlideImagesDirectory + slideFile.GUID + ".png");
            }

            slideFile.LastModifiedDate = DateTime.Now;

            slideFile.ModifiedBy = User.UserName;

            Canvas oldCanvas = CreateCanvasXaml(slideFile);

            while (oldCanvas.Children.Count > 0)
            {
                var uiElement = oldCanvas.Children[0] as ContentControl;
                oldCanvas.Children.Remove(uiElement);
                
                DataItems.Add(uiElement);
            }
        }

        private Canvas CreateCanvasXaml(SlideFile slideFile)
        {
            var originalCanvasItems = new Canvas();

            slideFile.Buttons = new SlideButtons();

            if (TempSlide == null)
                InspireApp.CurrentSlideGuid = slideFile.GUID;
            else
            {
                InspireApp.CurrentSlideGuid = !string.IsNullOrEmpty(SavedSlideGuid) ? SavedSlideGuid : TempSlide.GUID;
            }

            string xamlPath = Paths.SaveDirectory + InspireApp.CurrentSlideGuid + "\\" + "Canvas.xaml";

            var savDirect = Path.Combine(Paths.SaveDirectory , InspireApp.CurrentSlideGuid);

            if(!Directory.Exists(savDirect))
                Directory.CreateDirectory(savDirect);

            string canvasBackground = slideFile.Background;

            double canvasWidth = slideFile.HResolution;

            double canvasHeight = slideFile.VResolution;

            if (slideFile.Background == null)
                canvasBackground = "White";

            string root = "<Canvas xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"" + " Background=\"" + canvasBackground + "\"" + " Height=\"" + canvasHeight + "\"" + " Width=\"" + canvasWidth + "\"" + " >";

            while (DataItems.Count > 0)
            {
                var designContentControlHolder = DataItems[0] as DesignControlHolder;
                if (designContentControlHolder != null)
                {
                    var designContentControl = designContentControlHolder.Content as DesignContentControl;
                    if (designContentControl != null)
                    {
                        designContentControl.SlideID = slideFile.GUID;

                        Assembly assembly = Assembly.Load(AssemblyName.GetAssemblyName(Paths.ClientModulesDirectory + designContentControl.AssemblyInfo + ".dll") );

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

                                DataItems.Remove(designContentControlHolder);

                                var left = Canvas.GetLeft(designContentControlHolder);
                                var top = Canvas.GetTop(designContentControlHolder);

                                var holderResources = AnimationLibrary.AnimationManager.CopyStoryBoardForHolder(designContentControlHolder.Resources);

                                designContentControl.Resources = designContentControlHolder.Resources;

                                int zIndex = Canvas.GetZIndex(designContentControlHolder);

                                Canvas.SetZIndex(designContentControl, zIndex);

                                Canvas.SetLeft(designContentControl, left);
                                Canvas.SetTop(designContentControl, top);

                                designContentControl.Width = designContentControlHolder.Width;
                                designContentControl.Height = designContentControlHolder.Height;

                                var visibility = designContentControlHolder.Visibility;

                                designContentControl.Visibility = visibility;

                                designContentControl.IsLocked = designContentControlHolder.IsLocked;

                                designContentControl.IsHitTestVisible = designContentControlHolder.IsHitTestVisible;

                                designContentControl.RotateTransform = designContentControlHolder.RotateTransform;
                                designContentControl.TranslateTransform = designContentControlHolder.TranslateTransform;
                                designContentControl.ScaleTransform = designContentControlHolder.ScaleTransform;

                                var rules = imediaModule.GetRules(designContentControl);

                                if (rules != null)
                                    foreach (var rule in rules)
                                        slideFile.Rules.Add(new SlideRule { Rule = rule, SlideID = slideFile.GUID });

                                if (designContentControl.IsTouchEnabled)
                                    slideFile.Buttons.Add(new SlideButton { ButtonName = designContentControl.ButtonName, GUID = designContentControl.GUID, SlideID = slideFile.GUID });

                                var lastStoryBoardBegin = AnimationLibrary.AnimationManager.SaveAnimations(designContentControl, PlayingMonitor.PlayingEvent, PlayingMonitor.StopEvent, new Size(canvasWidth, canvasHeight));

                                if (new TimeSpan(slideFile.DefaultDuration.Value.Hour, slideFile.DefaultDuration.Value.Minute, slideFile.DefaultDuration.Value.Second) < lastStoryBoardBegin)
                                {
                                    var lastBeginConv = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0).Add(lastStoryBoardBegin.Add(TimeSpan.FromSeconds(3)));

                                    slideFile.DefaultDuration = lastBeginConv;
                                }

                                try
                                {

                                    if (new TimeSpan(slideFile.DefaultDuration.Value.Hour, slideFile.DefaultDuration.Value.Minute, slideFile.DefaultDuration.Value.Second) < TimeSpan.FromSeconds(8))
                                        slideFile.DefaultDuration = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 10);
                                    //// designContentControl.SetPlayerTransform();
                                    //if (TempSlide != null)
                                    //    root += imediaModule.CreatePlayerControl(designContentControl, InspireApp.CurrentSlideGuid);
                                    //else
                                    //{

                                    if (holderResources.Count > 0)
                                        AnimationLibrary.AnimationManager.SaveParentStoryBordToTrigger(designContentControl, holderResources);

                                        root += imediaModule.CreatePlayerControl(designContentControl, InspireApp.CurrentSlideGuid);
                                   // }
                                }
                                catch (Exception ex)
                                {
                                    if (ex is FailedToCreateModuleException)
                                    {
                                        var commonDialog = new CommonDialog("Save Failed",
                                                                                     ex.Message +
                                                                                     " Please ensure the file(s) being added to the canvas still exist and try again.");
                                        commonDialog.ShowDialog();
                                    }
                                }

                                designContentControlHolder.Resources = holderResources;

                                designContentControl.Visibility = visibility;

                                designContentControl.Triggers.Clear();
                                designContentControl.Width = double.NaN;
                                designContentControl.Height = double.NaN;
                                designContentControl.RotateTransform = new RotateTransform(0);
                                designContentControl.IsHitTestVisible = true;
                                // designContentControl.SetDesignerTransform();

                                //root += XamlWriter.Save(contentControl);
                                originalCanvasItems.Children.Add(designContentControlHolder);

                            }
                        }
                    }
                }
            }
            //if (TempSlide != null)
            //    Files.DeleteOldSlideFolder(TempSlide.GUID);

            root += "</Canvas>";

            TextWriter xmlCanvas = new StringWriter(new StringBuilder(root));

            using (var streamWriter = new StreamWriter(xamlPath))
            {
                streamWriter.Write(xmlCanvas);
                xmlCanvas.Close();
                streamWriter.Close();
            }

            return originalCanvasItems;
        }

        #endregion

        //public static readonly RoutedEvent HidePropertiesEvent = EventManager.RegisterRoutedEvent("HideProperties", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(FrameworkElement));

        //// Provide CLR accessors for the event
        //public event RoutedEventHandler HideProperties
        //{
        //    add { AddHandler(HidePropertiesEvent, value); }
        //    remove { RemoveHandler(HidePropertiesEvent, value); }
        //}

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if (DesignWindow.GetDesignerWindow().IsPlaying) return;

            if (e.Source == this)
            {
                // in case that this click is the start of a 
                // drag operation we cache the start point
                rubberbandSelectionStartPoint = (e.GetPosition(this));

                // if you click directly on the canvas all 
                // selected items are 'de-selected'
                selectionService.ClearSelection();
                //propertyPanelService.GetPropertyPanel(null); TODO: if null, handle canvas properties
                Focus();

                HidePropertyPanelDelegate hidePropertyPanelDelegate = HidePropertyPanel;

                Dispatcher.BeginInvoke(DispatcherPriority.Render, hidePropertyPanelDelegate);

                e.Handled = true;
            }
           e.Handled = true;
        }

        public void HidePropertyPanel()
        {
            var mainApp = Application.Current.Windows[0];

            if (mainApp != null)
            {
                var designWindow = mainApp.FindName("DesignerWindow") as DesignWindow;
                if (designWindow != null)
                {
                    var designPropertyControl =
                        designWindow.FindName("InspirePropertyControl") as DesignPropertyControl;
                    if (designPropertyControl != null)
                    {
                        designPropertyControl.ClearAnimationPanel();

                        var propertyGrid = designPropertyControl.FindName("ControlPropertyGrid") as PropertyPanelPart;

                        //RoutedEventArgs newEventArgs = new RoutedEventArgs(HidePropertiesEvent);
                        if (propertyGrid != null)
                        {
                            if (propertyGrid.Children.Count > 0)
                            {
                                propertyGrid.Children.RemoveAt(0);

                                //UserControl pPanel = propertyGrid.Children[0] as UserControl;
                                //if (pPanel != null && pPanel is IDisposable) // ((IPropertyPanel)pPanel).HidePropertyPanel();
                                //    ((IDisposable)pPanel).Dispose();
                            }
                            currentDesignContentControlGuid = null;
                        }
                    }
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (DesignWindow.GetDesignerWindow().IsPlaying) return;

            // if mouse button is not pressed we have no drag operation, ...
            if (e.LeftButton != MouseButtonState.Pressed)
                rubberbandSelectionStartPoint = null;

            // ... but if mouse button is pressed and start
            // point value is set we do have one
            if (rubberbandSelectionStartPoint.HasValue)
            {
                // create rubberband adorner
                var adornerLayer = AdornerLayer.GetAdornerLayer(this);
                if (adornerLayer != null)
                {
                    var adorner = new RubberbandAdorner(this, DataItems, rubberbandSelectionStartPoint);
                    if (true)
                    {
                        adornerLayer.Add(adorner);
                    }
                }
            }
            e.Handled = true;
        }

        private void InspireCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DesignWindow.GetDesignerWindow().IsPlaying) return;

            var endControlPositions = selectionService.CurrentSelection.OfType<DesignControlHolder>().Select(item => new ControlPosition(item)).ToList();

            if (!HasMoved(startControlPositions, endControlPositions)) return;
            var command = new MoveDesignItemCommand(startControlPositions, endControlPositions);
            undoService.Execute(command);
        }

        private bool HasMoved(List<ControlPosition> sControlPositions, List<ControlPosition> eControlPositions)
        {
            if(sControlPositions != null && eControlPositions != null)
                if (sControlPositions.Count > 0 && eControlPositions.Count > 0)
                    for (int i = 0; i < startControlPositions.Count; i++)
                    {
                        if (sControlPositions[i].DesignerCoordinate.X != eControlPositions[i].DesignerCoordinate.X)
                            return true;
                        if (sControlPositions[i].DesignerCoordinate.Y != eControlPositions[i].DesignerCoordinate.Y)
                            return true;
                        if (sControlPositions[i].DesignerRotateAngle != eControlPositions[i].DesignerRotateAngle)
                            return true;
                        if (sControlPositions[i].DesignerSize.Width != eControlPositions[i].DesignerSize.Width)
                            return true;
                        if (sControlPositions[i].DesignerSize.Height != eControlPositions[i].DesignerSize.Height)
                            return true;
                    }

            return false;
        }

        UndoService IDragCanvas.UndoService
        {
            get { return undoService; }
            set { undoService = value; }
        }

        public IEnumerable<ContentControl> GetDesignItems()
        {
            var dContentControls = new List<DesignContentControl>();
            foreach (ContentControl holderControl in DataItems)
            {
                dContentControls.Add((DesignContentControl)holderControl.Content);
            }
            return dContentControls;
        }

        public void Dispose()
        {
            ClearUndoGarbage();
            undoService.ClearHistory();
            foreach (ContentControl holderControl in DataItems)
            {
                if(holderControl.Content is IDisposable)
                    ((IDisposable)holderControl.Content).Dispose();
                holderControl.Content = null;
            }

            DataItems.Clear();

            // TODO: Clear File Folder

            selectionService = null;
            propertyPanelService = null;
            undoService = null;

            DataContext = null;

            TempSlide = null;
        }
    }
}
