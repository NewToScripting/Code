using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Inspire.Client.Designer;
using Inspire.Client.Designer.Commands;
using Inspire.Client.Designer.Dialogs;
using Inspire.Client.Designer.DragCanvas;
using Inspire.Client.ScheduleWindow.Dialogs;
using Inspire.Client.ScheduleWindow.ScheduledSlidePanel;
using Inspire.Commands;
using Inspire.Common.Dialogs;
using Inspire.Common.TreeViewModel;
using Inspire.Common.Utility;
using Inspire.Helpers;
using Inspire.Interfaces;
using Inspire.MediaObjects;
using Inspire.Server.Proxy;
using Application=System.Windows.Application;
using Clipboard=System.Windows.Clipboard;
using DataFormats=System.Windows.DataFormats;
using Label=System.Windows.Controls.Label;
using MessageBox=System.Windows.MessageBox;
using TreeView=System.Windows.Controls.TreeView;
using UserControl=System.Windows.Controls.UserControl;

namespace Inspire.Client
{
    public partial class MainWindow
    {

        private delegate void UpdateDisplaysDelegate();

        private void NewSlideExecuted(object sender, ExecutedRoutedEventArgs e)
        {

            List<Display> displays = DisplayManager.GetAllDisplays();

            if (!Designer.DesignWindow.IsDesignerMode && displays.Count > 0)
            {
                NewSlide newSlide = new NewSlide(displays);
                newSlide.ShowDialog();
            }
            else
            {
                CustomSlide customSlide = new CustomSlide();
                customSlide.ShowDialog();
            }
            e.Handled = true;
        }

        private void NewSlideCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (DesignerWindow != null && !DesignerWindow.IsPlaying && (User.UserPermision.Contains(PermissionTypes.Administrator) || User.UserPermision.Contains(PermissionTypes.ContentCreator)));
        }


        private void SchedulerNewSlideExecuted(object sender, ExecutedRoutedEventArgs e)
        {
             Window mainApp = Application.Current.Windows[0];

             if (mainApp != null)
             {
                 UserControl designWindow = mainApp.FindName("DesignerWindow") as UserControl;

                 if (designWindow != null)
                 {
                     Display tempDisplay;

                     var tabControl = designWindow.FindName("DesignerDragCanvasHolder") as System.Windows.Controls.TabControl;
                     if (tabControl != null)
                     {
                         Label label = (Label) designWindow.FindName("lblNewSlide");
                         label.Visibility = Visibility.Hidden;

                         InspireApp.CanvasExists = true;

                         var tabItem = new CloseableTabItem();

                         var dragCanvas = new DragCanvas();

                         InspireApp.CurrentDragCanvas = dragCanvas;
                         if (dragCanvas != null)
                         {
                             UserControl scheduleTreeControl =
                                 SchedulerWindow.FindName("SchedulerTreeControl") as UserControl;
                             if (scheduleTreeControl != null)
                             {
                                 TreeView ScheduleTree = scheduleTreeControl.FindName("ScheduleTree") as TreeView;

                                 if (ScheduleTree != null)
                                     if (ScheduleTree.SelectedItem != null)
                                     {
                                         tempDisplay =
                                             DisplayManager.GetSingleDisplay(
                                                 ((DisplayViewModel) ScheduleTree.SelectedItem).GUID);
                                         if (tempDisplay.VResolution > 0 && tempDisplay.HResolution > 0)
                                         {
                                             dragCanvas.Width = tempDisplay.HResolution;
                                             dragCanvas.Height = tempDisplay.VResolution;
                                             dragCanvas.Visibility = Visibility.Visible;

                                             tabItem.Header = "untitled-" + (tabControl.Items.Count + 1);
                                             tabItem.Content = dragCanvas;

                                             tabControl.Items.Add(tabItem);

                                             tabControl.SelectedItem = tabItem;

                                             //designerTab.IsSelected = true;
                                             ShowDesignerExecuted(this, null);
                                         }
                                     }
                             }
                         }
                     }
                 }
             }
            e.Handled = true;
        }

        private void SchedulerNewSlideCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (SchedulerWindow != null)
            {
                UserControl scheduleTreeControl = SchedulerWindow.FindName("SchedulerTreeControl") as UserControl;
                if (scheduleTreeControl != null)
                {
                    TreeView ScheduleTree = scheduleTreeControl.FindName("ScheduleTree") as TreeView;
                    if (ScheduleTree != null)
                    {
                        if (ScheduleTree.SelectedItem != null)
                            if (ScheduleTree.SelectedItem.GetType().Name == "DisplayViewModel")
                                e.CanExecute = true;
                    }
                }
            }
        }

        private void SaveSlideExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            string SlideName;
            string SlideDescription;
            bool saveComplete = false;

            if (InspireApp.CanvasExists)
            {
                var dragCanvas = UIHelper.GetCurrentDragCanvas() as DragCanvas;

                if (dragCanvas != null)
                    if (!Designer.DesignWindow.IsDesignerMode && !dragCanvas.IsOfflineSlide)
                        if (dragCanvas.TempSlide != null)
                        {
                            dragCanvas.OverWriteSlide = false;

                            ModifySlide modifyDialog = new ModifySlide();
                            modifyDialog.ShowDialog();
                            if (modifyDialog.DialogResult == false)
                                return;
                            if (modifyDialog.DialogResult == true)
                            {
                                if (modifyDialog.ModifyCurrentSlide)
                                {
                                    dragCanvas.OverWriteSlide = true;

                                    var tempGuid = dragCanvas.TempSlide.GUID;

                                    SlideName = dragCanvas.TempSlide.Name;

                                    SlideDescription = dragCanvas.TempSlide.Description;

                                    SaveSlideFile(SlideName, SlideDescription);

                                    InspireCommands.ClearScheduledSlidesCommand.Execute(null,SchedulerWindow);

                                    if (ScheduledSlideManager.IsSlideScheduled(tempGuid))
                                    {
                                        UpdateSchedules updateSchedulesDialog = new UpdateSchedules();
                                        updateSchedulesDialog.ShowDialog();
                                        if (updateSchedulesDialog.DialogResult == true)
                                            ScheduledSlideManager.UpdateOriginalSlideIds(dragCanvas.NewSlideGuid, tempGuid, true);
                                    }
                                    else
                                        ScheduledSlideManager.UpdateOriginalSlideIds(dragCanvas.NewSlideGuid, tempGuid, true);

                                    saveComplete = true;

                                }
                                else
                                {
                                    dragCanvas.ReSeedContentControls(); // Since we are creating a new slide from an existing slide, we need to give the controls unique id's

                                    saveComplete = SaveOrExportSlide(Designer.DesignWindow.IsDesignerMode, true);
                                }
                            }
                        }
                        else
                        {
                            saveComplete = SaveOrExportSlide(Designer.DesignWindow.IsDesignerMode, true);
                        }
                    else
                    {
                        saveComplete = SaveOrExportSlide(Designer.DesignWindow.IsDesignerMode, true);
                    }
            }

            if (saveComplete)
            {
                var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;

                if (dragCanvas != null)
                {
                    if (dragCanvas.TempSlide != null)
                        dragCanvas.TempSlide.GUID = dragCanvas.NewSlideGuid;

                    dragCanvas.NewSlideGuid = string.Empty;
                }
            }
            //DragCanvas.TempSlide = null;

            e.Handled = true;
        }

        private bool SaveOrExportSlide(bool isDesignerMode, bool saveLocal)
        {
            bool slideSaved = false;

            string slideName = string.Empty;
            string slideDescription = string.Empty;

            var dragCanvas = UIHelper.GetCurrentDragCanvas() as DragCanvas;

            if (dragCanvas.TempSlide != null)
            {
                if (!String.IsNullOrEmpty(dragCanvas.TempSlide.Name))
                    slideName = dragCanvas.TempSlide.Name;
                if (!String.IsNullOrEmpty(dragCanvas.TempSlide.Description))
                    slideDescription = dragCanvas.TempSlide.Description;

            }


            SaveSlide saveSlideDialog = new SaveSlide(slideName, slideDescription);

            saveSlideDialog.ShowDialog();
            if (saveSlideDialog.DialogResult == true)
            {
                slideName = saveSlideDialog.SlideName;
                slideDescription = saveSlideDialog.SlideDescription;

                if(!isDesignerMode)
                    try
                    {
                        SaveSlideFile(slideName, slideDescription);
                        slideSaved = true;
                    }
                    catch (Exception ex) // TODO: Create SaveSlideException
                    {
                        return false;
                        throw new Exception("Slide Failed to Save. Reason: " + ex.Message);
                    }
                else
                    try
                    {
                        ExportSlideFile(slideName, slideDescription, saveLocal);
                        slideSaved = true;
                    }
                    catch (Exception) // TODO: Create SaveSlideException
                    {
                        return false;
                        throw new Exception("Slide Failed to save2.");
                    }
            }
            return slideSaved;
        }

        private void ExportSlideFile(string name, string description, bool saveLocal)
        {
            if (!String.IsNullOrEmpty(name) && saveLocal)
            {
                CreateSlidePackage(name, description,"", true);
            }
            else
            {
                var exportSlideDialog = new SaveFileDialog
                                                       {
                                                           Filter = "Inspire Slides (*.insp) |*.insp",
                                                           FileName = name
                                                       };
                exportSlideDialog.ShowDialog();
                string filePath = exportSlideDialog.FileName;
                if (!String.IsNullOrEmpty(filePath))
                {
                    CreateSlidePackage(name, description, filePath, false);
                }
            }

            // throw new Exception("Not Done Yet");
        }

        private void CreateSlidePackage(string name, string description, string filePath, bool saveLocal)
        {
            Window mainApp = Application.Current.Windows[0];

            if (mainApp != null)
            {
                var designWindow = mainApp.FindName("DesignerWindow") as UserControl;

                if (designWindow != null)
                {
                    var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;

                    var dialog = new ProgressDialog();
                    dialog.Owner = this;
                    dialog.DialogText = "Saving Slide. Please wait....";
                   // dialog.AutoIncrementInterval = 100;

                    var args = new List<string>();

                    if (dragCanvas != null)
                    {
                        args.Add(name);
                        args.Add(description);
                        args.Add(dragCanvas.Width.ToString());
                        args.Add(dragCanvas.Height.ToString());
                        args.Add(dragCanvas.Background.ToString());
                        args.Add(filePath);
                        args.Add(saveLocal.ToString());

                        if (dragCanvas != null) dragCanvas.DetatchReflections(dragCanvas.DataItems);

                        dialog.RunWorkerThread(args, dragCanvas.ExportCanvasToSlide);

                        if (dialog.Error != null)
                        {
                            String msg = "An error occurred on the worker thread:\n\n {0}";
                            msg = String.Format(msg, dialog.Error);
                            MessageBox.Show(msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        private void SaveSlideFile(string slideName, string slideDescription)
        {
            if (InspireApp.CurrentDragCanvas != null)
            {
                var canvas = InspireApp.CurrentDragCanvas as DragCanvas;

                if (canvas != null)
                {
                    var dialog = new ProgressDialog
                                     {
                                         Owner = this,
                                         DialogText = "Saving Slide. Please wait....",
                                         ShowProgressBar = true
                                     };

                    var args = new List<object>();


                    args.Add(slideName);
                    args.Add(slideDescription);
                    args.Add(canvas.Width.ToString());
                    args.Add(canvas.Height.ToString());
                    args.Add(canvas.Background.ToString());

                    var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;

                    if (dragCanvas != null) dragCanvas.DetatchReflections(dragCanvas.DataItems);

                    dialog.RunWorkerThread(args, canvas.SaveCanvasToSlide);

                    if (dialog.Error != null)
                    {
                        var msg = "An error occurred on the worker thread:\n\n {0}";
                        msg = String.Format(msg, dialog.Error);
                        MessageBox.Show(msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    var tabControl = DesignerWindow.FindName("DesignerDragCanvasHolder") as System.Windows.Controls.TabControl;
                    if (tabControl != null)
                    {
                        TabItem tabItem;
                        if (tabControl.SelectedValue != null && tabControl.SelectedValue is TabItem)
                        {
                            tabItem = tabControl.SelectedValue as TabItem;
                            tabItem.Header = slideName;
                        }
                    }
                }
            }
        }


        private void SaveSlideCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            e.CanExecute = (dragCanvas != null && dragCanvas.DataItems != null && dragCanvas.DataItems.Count > 0 && InspireApp.CanvasExists && dragCanvas.selectionService != null &&
                            Designer.DesignWindow.GetDesignerWindow().IsPlaying == false & !SlideManager.IsSending && (User.UserPermision.Contains(PermissionTypes.Administrator) || User.UserPermision.Contains(PermissionTypes.ContentCreator)));
        }

        private void LoadSlideExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Slide slide = (Slide) e.Parameter;

            //var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;

            //if (dragCanvas != null)
            //{
            //    dragCanvas.DetatchReflections(dragCanvas.DataItems);

            //    dragCanvas.DataItems.Clear();

            //    dragCanvas.undoService.ClearHistory();

            //    dragCanvas.selectionService.ClearSelection();
            //}
            
            //Files.ClearDirectory(Paths.ClientTempDirectory);

            Designer.DesignWindow.GetDesignerWindow().IsPlaying = false;
            InspireApp.CanvasExists = true;

            if (DesignerWindow != null)
            {
                var tabControl =
                    DesignerWindow.FindName("DesignerDragCanvasHolder") as System.Windows.Controls.TabControl;
                if (tabControl != null)
                {
                    Label label = (Label) DesignerWindow.FindName("lblNewSlide");
                    label.Visibility = Visibility.Hidden;

                    InspireApp.CanvasExists = true;

                    var tabItem = new CloseableTabItem();

                    var dragCanvas = new DragCanvas();

                    dragCanvas.Width = slide.HResolution;
                    dragCanvas.Height = slide.VResolution;

                    InspireApp.CurrentDragCanvas = dragCanvas;

                    tabItem.Header = slide.Name;
                    tabItem.Content = dragCanvas;

                    tabControl.Items.Add(tabItem);

                    tabControl.SelectedItem = tabItem;

                    dragCanvas.TempSlide = slide;

                    ProgressDialog dialog = new ProgressDialog();
                    dialog.Owner = this;
                    dialog.DialogText = "Loading Slide. Please wait....";
                    dialog.ShowProgressBar = true;
                   // dialog.AutoIncrementInterval = 100;
                    

                    List<object> args = new List<object>();

                    args.Add(slide);

                    dialog.RunWorkerThread(args, dragCanvas.LoadSlideToCanvas);

                    if (dialog.Error != null)
                    {
                        String msg = "An error occurred on the worker thread:\n\n {0}";
                        msg = String.Format(msg, dialog.Error);
                        MessageBox.Show(msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void LoadSlideCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (!Designer.DesignWindow.GetDesignerWindow().IsPlaying);
        }

        private void EditSlideExecuted(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void EditSlideCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeleteSlideExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void DeleteSlideCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (!Designer.DesignWindow.GetDesignerWindow().IsPlaying && (User.UserPermision.Contains(PermissionTypes.Administrator) || User.UserPermision.Contains(PermissionTypes.ContentCreator)));
        }

        private void ClearSlideExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;

            if (dragCanvas != null)
            {
                var designContentControls = dragCanvas.DataItems.OfType<DesignControlHolder>();

                foreach (DesignControlHolder designContentControl in designContentControls)
                {

                    Assembly assembly =
                        Assembly.Load(
                            AssemblyName.GetAssemblyName(Paths.ClientModulesDirectory +
                                                         ((DesignContentControl) designContentControl.Content).
                                                             AssemblyInfo + ".dll"));

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

                            imediaModule.Dispose((DesignContentControl) designContentControl.Content);
                        }
                    }
                }

                
                dragCanvas.Background = Brushes.White;

                dragCanvas.DetatchReflections(dragCanvas.DataItems);
                dragCanvas.DataItems.Clear();

                dragCanvas.ClearUndoGarbage();

                dragCanvas.TempSlide = null;
                dragCanvas.IsOfflineSlide = false;
                dragCanvas.undoService.ClearHistory();
                dragCanvas.selectionService.ClearSelection();
                dragCanvas.HidePropertyPanel();
            }

            //Files.ClearDirectory(Paths.ClientTempDirectory);

            e.Handled = true;
        }

        private void ClearSlideCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            if (dragCanvas != null && dragCanvas.DataItems != null && InspireApp.CanvasExists && dragCanvas.selectionService != null && !Designer.DesignWindow.GetDesignerWindow().IsPlaying)
                e.CanExecute = true;
        }

        private void UndoCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            dragCanvas.undoService.Undo();
        }

        private void UndoCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            if (dragCanvas != null && dragCanvas.undoService != null && Designer.DesignWindow.GetDesignerWindow().IsPlaying == false)
                dragCanvas.undoService.OnCanExecuteUndo(sender, e);
        }

        private void RedoCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            dragCanvas.undoService.Redo();
        }

        private void RedoCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            if (dragCanvas != null && dragCanvas.undoService != null && Designer.DesignWindow.GetDesignerWindow().IsPlaying == false)
                dragCanvas.undoService.OnCanExecuteRedo(sender, e);
        }

        private void DeleteCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            if(dragCanvas != null)
                dragCanvas.DeleteCurrentSelection();
            
        }

        private void DeleteCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            if (dragCanvas != null && dragCanvas.selectionService != null && Designer.DesignWindow.GetDesignerWindow().IsPlaying == false)
                dragCanvas.selectionService.OnCanExecuteDelete(sender, e);
        }

        private void CopyCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
                InspireApp.IsCopying = true;
                dragCanvas.CopyCurrentSelection();
            }
            catch (Exception)
            {
                
            }
            finally
            {
                InspireApp.IsCopying = false;
            }
        }

        private void CopyCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            if (dragCanvas != null && dragCanvas.selectionService != null && Designer.DesignWindow.GetDesignerWindow().IsPlaying == false)
                e.CanExecute = (dragCanvas.selectionService.CurrentSelection.Count() > 0 && dragCanvas.selectionService.HasCopyableSelection);
        }

        private void DuplicateCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
                InspireApp.IsCopying = true;
                dragCanvas.CopyCurrentSelection();
                dragCanvas.PasteClipboardItems();

            }
            catch (Exception)
            {

            }
            finally
            {
                InspireApp.IsCopying = false;
            }
        }

        private void DuplicateCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            if (dragCanvas != null && dragCanvas.selectionService != null && Designer.DesignWindow.GetDesignerWindow().IsPlaying == false)
                e.CanExecute = (dragCanvas.selectionService.CurrentSelection.Count() > 0 && dragCanvas.selectionService.HasCopyableSelection);
        }

        private void PasteCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            dragCanvas.PasteClipboardItems();
        }

        private void PasteCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            try
            {
                var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
                if (dragCanvas != null && Clipboard.ContainsData(DataFormats.Xaml) && Designer.DesignWindow.GetDesignerWindow().IsPlaying == false)
                    e.CanExecute = true;
            }
            catch (Exception)
            {

                e.CanExecute = false;
            }
            
        }

        private void CutCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            dragCanvas.CutCurrentSelection();
        }

        private void CutCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            if (dragCanvas != null && dragCanvas.selectionService != null && Designer.DesignWindow.GetDesignerWindow().IsPlaying == false)
                e.CanExecute = dragCanvas.selectionService.CurrentSelection.Count() > 0;
        }

        private void ShowDesignerExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ConfigureWindow.Focus();
            ConfigureWindow.Visibility = Visibility.Collapsed;
            configurationTab.Visibility = Visibility.Collapsed;

            SchedulerWindow.Focus();
            SchedulerWindow.Visibility = Visibility.Collapsed;
            scheduleTab.Visibility = Visibility.Collapsed;

            DesignPane.IsSelected = true;

            DesignerWindow.Focus();
            DesignerWindow.Visibility = Visibility.Visible;
            designerHomeTab.Visibility = Visibility.Visible;
            designerFormatTab.Visibility = Visibility.Visible;
            //designerAnimationsTab.Visibility = Visibility.Visible;
            Selector.SetIsSelected(designerHomeTab, true);
        }

        private void ShowDesignerCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !Designer.DesignWindow.GetDesignerWindow().IsPlaying;
        }

        private void ShowSchedulerExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ConfigureWindow.Focus();
            ConfigureWindow.Visibility = Visibility.Collapsed;
            configurationTab.Visibility = Visibility.Collapsed;
            DesignerWindow.Focus();
            DesignerWindow.Visibility = Visibility.Collapsed;
            designerHomeTab.Visibility = Visibility.Collapsed;
            designerFormatTab.Visibility = Visibility.Collapsed;
            //designerAnimationsTab.Visibility = Visibility.Collapsed;
            SchedulerWindow.Focus();
            SchedulerWindow.Visibility = Visibility.Visible;
            scheduleTab.Visibility = Visibility.Visible;
            Selector.SetIsSelected(scheduleTab, true);
            if (!ToolBarPane.IsExpanded)
                ToolBarPane.IsExpanded = true;
        }

        private void ShowSchedulerCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !Designer.DesignWindow.GetDesignerWindow().IsPlaying;
        }

        private void ShowConfigurationExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ConfigureWindow.Focus();
            ConfigureWindow.Visibility = Visibility.Visible;
            configurationTab.Visibility = Visibility.Visible;
            DesignerWindow.Focus();
            DesignerWindow.Visibility = Visibility.Collapsed;
            designerHomeTab.Visibility = Visibility.Collapsed;
            designerFormatTab.Visibility = Visibility.Collapsed;
            //designerAnimationsTab.Visibility = Visibility.Collapsed;
            SchedulerWindow.Focus();
            SchedulerWindow.Visibility = Visibility.Collapsed;
            scheduleTab.Visibility = Visibility.Collapsed;
            Selector.SetIsSelected(configurationTab, true);
            if (!ToolBarPane.IsExpanded)
                ToolBarPane.IsExpanded = true;
        }

        private void ShowConfigurationCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !Designer.DesignWindow.GetDesignerWindow().IsPlaying;
        }

        private void UpdateDisplaysCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            UpdateDisplaysDelegate workerDelegate = DisplayAdmin.UpdateDisplays;
            workerDelegate.BeginInvoke(null, null);
        }

        private void UpdateDisplaysCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AlignBottomCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            AlignBottomCommand command = new AlignBottomCommand(dragCanvas.DataItems, dragCanvas.selectionService.CurrentSelection, dragCanvas);
            if (dragCanvas.undoService != null)
            {
                dragCanvas.undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void AlignBottomCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            CanAlignmentExecute(e);
        }


        private void AlignLeftCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            var command = new AlignLeftCommand(dragCanvas.DataItems, dragCanvas.selectionService.CurrentSelection, dragCanvas);
            if (dragCanvas.undoService != null)
            {
                dragCanvas.undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void AlignLeftCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            CanAlignmentExecute(e);
        }

        private void AlignHorizontalCentersCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            AlignHorizontalCentersCommand command = new AlignHorizontalCentersCommand(dragCanvas.DataItems, dragCanvas.selectionService.CurrentSelection, dragCanvas);
            if (dragCanvas.undoService != null)
            {
                dragCanvas.undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void AlignHorizontalCentersCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            CanAlignmentExecute(e);
        }

        private void AlignRightCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            AlignRightCommand command = new AlignRightCommand(dragCanvas.DataItems, dragCanvas.selectionService.CurrentSelection, dragCanvas);
            if (dragCanvas.undoService != null)
            {
                dragCanvas.undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void AlignRightCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            CanAlignmentExecute(e);
        }

        private void AlignTopCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            AlignTopCommand command = new AlignTopCommand(dragCanvas.DataItems, dragCanvas.selectionService.CurrentSelection, dragCanvas);
            if (dragCanvas.undoService != null)
            {
                dragCanvas.undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void AlignTopCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            CanAlignmentExecute(e);
        }

        private void AlignVerticalCentersCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            AlignVerticalCentersCommand command = new AlignVerticalCentersCommand(dragCanvas.DataItems, dragCanvas.selectionService.CurrentSelection, dragCanvas);
            if (dragCanvas.undoService != null)
            {
                dragCanvas.undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void AlignVerticalCentersCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            CanAlignmentExecute(e);
        }

        private void DistributeHorizontalCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            DistributeHorizontalCommand command = new DistributeHorizontalCommand(dragCanvas.DataItems, dragCanvas.selectionService.CurrentSelection, dragCanvas);
            if (dragCanvas.undoService != null)
            {
                dragCanvas.undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void DistributeHorizontalCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            CanAlignmentExecute(e);
        }

        private void DistributeVerticalCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            DistributeVerticalCommand command = new DistributeVerticalCommand(dragCanvas.DataItems, dragCanvas.selectionService.CurrentSelection, dragCanvas);
            if (dragCanvas.undoService != null)
            {
                dragCanvas.undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void DistributeVerticalCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            CanAlignmentExecute(e);
        }

        private void CanAlignmentExecute(CanExecuteRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            e.CanExecute = (dragCanvas != null && dragCanvas.selectionService != null && Designer.DesignWindow.GetDesignerWindow().IsPlaying == false &&
                            dragCanvas.selectionService.CurrentSelection.Count > 1);
        }

        [STAThread]
        private void PlayCanvasCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;

            FitDesignerToScreen();

            dragCanvas.ClipToBounds = true;

            Canvas tempCanvas = new Canvas();

            while (dragCanvas.DataItems.Count > 0)
            {
                ContentControl designContentControlHolder = dragCanvas.DataItems[0];
                dragCanvas.DataItems.Remove(designContentControlHolder);
                if (designContentControlHolder != null)
                {
                    var designContentControl = designContentControlHolder.Content as DesignContentControl;
                    Assembly assembly =
                        Assembly.Load(
                            AssemblyName.GetAssemblyName(Paths.ClientModulesDirectory +
                                                         designContentControl.AssemblyInfo + ".dll"));

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

                            InspireApp.PrepControlPositions(designContentControlHolder);

                            imediaModule.PlayControl(designContentControl, Paths.ClientTempDirectory, null);

                            InspireApp.StopAnimations(designContentControlHolder);

                            AnimationLibrary.AnimationManager.ApplyAnimations(designContentControlHolder, new Size(dragCanvas.Width, dragCanvas.Height));

                            tempCanvas.Children.Add(designContentControlHolder);
                        }
                    }
                }
            }

            while (tempCanvas.Children.Count > 0)
            {
                var uiElement = tempCanvas.Children[0] as ContentControl;
                tempCanvas.Children.Remove(uiElement);
                dragCanvas.DataItems.Add(uiElement);
            }

            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => DragCanvas.AttachReflections(
                                                                                           dragCanvas.DataItems)));

            dragCanvas.selectionService.ClearSelection();
            
            designerFormatTab.IsHitTestVisible = false;

            
            //ConfigurationDock.IsHitTestVisible = false;
            //ToolBarPane.IsHitTestVisible = false;
            DesignPane.IsHitTestVisible = false;
            SchedulePane.IsHitTestVisible = false;
            ConfigurePane.IsHitTestVisible = false;
            DesignPaneModulePanel.IsHitTestVisible = false;
            SchedulerTreeControl.IsHitTestVisible = false;
            ConfigurationTreeControl.IsHitTestVisible = false;

            DesignerWindow.PlayLock(true);
            quickAT.IsHitTestVisible = false;
            appMenu.IsHitTestVisible = false;

            DesignerWindow.StartTimer();
            Designer.DesignWindow.GetDesignerWindow().IsPlaying = true;
            InspireApp.IsPlaying = true;

        }

        private void FitDesignerToScreen()
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            Size designerWindow = new Size(DesignerWindow.Height, DesignerWindow.Width);
            Size canvasWindow = new Size(dragCanvas.Width, dragCanvas.Height);

            DesignerWindow.SetZoom(designerWindow, canvasWindow);
        }

        private void ResetDesignerZoom()
        {
            DesignerWindow.ResetZoom();
        }

        private void PlayCanvasCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            e.CanExecute = (dragCanvas != null && dragCanvas.DataItems != null && dragCanvas.DataItems.Count > 0 && !Designer.DesignWindow.GetDesignerWindow().IsPlaying);
        }


        private void StopCanvasCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;

            ResetDesignerZoom();

            if (dragCanvas != null)
            {
                dragCanvas.ClipToBounds = false;

                Canvas tempCanvas = new Canvas();

                while (dragCanvas.DataItems.Count > 0)
                {
                    ContentControl designContentControlHolder = dragCanvas.DataItems[0] as ContentControl;
                    dragCanvas.DataItems.Remove(designContentControlHolder);
                    if (designContentControlHolder != null)
                    {
                        var designContentControl = designContentControlHolder.Content as DesignContentControl;
                        Assembly assembly =
                            Assembly.Load(
                                AssemblyName.GetAssemblyName(Paths.ClientModulesDirectory +
                                                             designContentControl.AssemblyInfo + ".dll"));

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

                                imediaModule.StopControl(designContentControl, Paths.ClientTempDirectory, null);

                                //PlayingMonitor.RaiseStopEvent(designContentControlHolder);

                                InspireApp.StopAnimations(designContentControlHolder);

                                tempCanvas.Children.Add(designContentControlHolder);
                            }
                        }
                    }
                }

                while (tempCanvas.Children.Count > 0)
                {
                    var uiElement = tempCanvas.Children[0] as ContentControl;
                    tempCanvas.Children.Remove(uiElement);
                    dragCanvas.DataItems.Add(uiElement);
                }
            }

            designerFormatTab.IsHitTestVisible = true;
            //ConfigurationDock.IsHitTestVisible = true;

            DesignPane.IsHitTestVisible = true;
            SchedulePane.IsHitTestVisible = true;
            ConfigurePane.IsHitTestVisible = true;
            DesignPaneModulePanel.IsHitTestVisible = true;
            SchedulerTreeControl.IsHitTestVisible = true;
            ConfigurationTreeControl.IsHitTestVisible = true;

            quickAT.IsHitTestVisible = true;
            appMenu.IsHitTestVisible = true;

            DesignerWindow.PlayLock(false);
            DesignerWindow.StopTimer();
            Designer.DesignWindow.GetDesignerWindow().IsPlaying = false;
            InspireApp.IsPlaying = false;
        }

        private void StopCanvasCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = DesignerWindow != null && Designer.DesignWindow.GetDesignerWindow().IsPlaying;
        }

        private void PlayScheduleCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (SchedulerWindow != null)
            {
                UserControl scheduleTreeControl = SchedulerWindow.FindName("SchedulerTreeControl") as UserControl;
                if (scheduleTreeControl != null)
                {
                    TreeView ScheduleTree = scheduleTreeControl.FindName("ScheduleTree") as TreeView;
                    if (ScheduleTree != null)
                    {
                        if (ScheduleTree.SelectedItem != null)
                            if (ScheduleTree.SelectedItem.GetType().Name == "ScheduleViewModel")
                            {
                                ScheduledSlideControl scheduledSlideControl = SchedulerWindow.FindName("SchedulerSlideControl") as ScheduledSlideControl;

                                if (scheduledSlideControl != null)
                                {
                                    var scheduledSlide = (ScheduleViewModel) ScheduleTree.SelectedItem;
                                    PreviewCanvas previewCanvas = new PreviewCanvas(scheduledSlideControl.GetSlidesForPreview(scheduledSlide.GUID), ((DisplayViewModel)((ScheduleViewModel)ScheduleTree.SelectedItem).Parent).GUID, scheduledSlide.ScheduleType);
                                    previewCanvas.ShowDialog();
                                }
                            }
                    }
                }
            }
        }

        private void PlayScheduleCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (SchedulerWindow != null) // TODO make Static canexecute
            {
                UserControl scheduleTreeControl = SchedulerWindow.FindName("SchedulerTreeControl") as UserControl;
                if (scheduleTreeControl != null)
                {
                    TreeView ScheduleTree = scheduleTreeControl.FindName("ScheduleTree") as TreeView;
                    if (ScheduleTree != null)
                    {
                        if (ScheduleTree.SelectedItem != null)
                            if (ScheduleTree.SelectedItem.GetType().Name == "ScheduleViewModel")
                                e.CanExecute = true;
                    }
                }
            }
        }

        private void LoadOfflineFileDialogCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Inspire Slides (*.insp) |*.insp";
            openFileDialog.ShowDialog();

            try
            {
                if (!String.IsNullOrEmpty(openFileDialog.FileName))
                {
                    Files.ClearDirectory(Paths.ClientTransferDirectory);
                    ZipUtil.NewUnZipFiles(openFileDialog.FileName, Paths.ClientTransferDirectory, "wookie", true);

                    if (File.Exists(Paths.ClientTransferDirectory + "Slide.isf"))
                    {
                        Slide slide;
                        using (FileStream xamlFile = new FileStream(Paths.ClientTransferDirectory + "Slide.isf", FileMode.Open, FileAccess.Read))
                        {
                            slide = (Slide)XamlReader.Load(xamlFile);
                        }
                        if (slide != null)
                        {
                            slide.IsExternalFile = true;
                            //ICommand command = InspireCommands.LoadSlideCommand;
                            //command.Execute(slide);
                            InspireCommands.LoadSlideCommand.Execute(slide, this);

                            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
                            dragCanvas.undoService.ClearHistory();
                            dragCanvas.IsOfflineSlide = true;
                        }
                    }
                    else
                        throw new Exception("Could not find the slide details within the file.");
                }
                else
                    throw new Exception("Please select a slide/template to import.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void LoadOfflineFileDialogCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveSlideToServerCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = DesignerWindow != null && !Designer.DesignWindow.IsDesignerMode;
        }

        private void SaveSlideLocalCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExportSlideCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveSlideToServerExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            bool saveComplete = false;

            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;

            try
            {
                if (InspireApp.CanvasExists)
                {
                    if (!Designer.DesignWindow.IsDesignerMode)
                        if (dragCanvas.TempSlide != null)
                        {
                            var modifyDialog = new ModifySlide();
                            modifyDialog.ShowDialog();
                            if (modifyDialog.DialogResult == false)
                                return;
                            if (modifyDialog.DialogResult == true)
                            {
                                if (modifyDialog.ModifyCurrentSlide)
                                {
                                    string slideName = dragCanvas.TempSlide.Name;

                                    string slideDescription = dragCanvas.TempSlide.Description;

                                    SaveSlideFile(slideName, slideDescription);

                                    if (ScheduledSlideManager.IsSlideScheduled(dragCanvas.TempSlide.GUID))
                                    {
                                        var updateSchedulesDialog = new UpdateSchedules();
                                        updateSchedulesDialog.ShowDialog();
                                        if (updateSchedulesDialog.DialogResult == true)
                                            ScheduledSlideManager.UpdateOriginalSlideIds(dragCanvas.NewSlideGuid,
                                                                                         dragCanvas.TempSlide.GUID, true);
                                    }
                                    else
                                        ScheduledSlideManager.UpdateOriginalSlideIds(dragCanvas.NewSlideGuid, dragCanvas.TempSlide.GUID, true);

                                    saveComplete = true;

                                }
                                else
                                {
                                    saveComplete = SaveOrExportSlide(false, false);
                                }
                            }
                        }
                        else
                        {
                            saveComplete = SaveOrExportSlide(false, false);
                        }
                    else
                    {
                        saveComplete = SaveOrExportSlide(false, false);
                    }
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (saveComplete)
                    dragCanvas.NewSlideGuid = string.Empty;
                //DragCanvas.TempSlide = null;

                e.Handled = true;
            }
        }

        private void SaveSlideLocalExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            bool saveComplete = false;

            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;

            try
            {
                if (InspireApp.CanvasExists)
                {
                    saveComplete = SaveOrExportSlide(true, true);
                    dragCanvas.IsOfflineSlide = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (saveComplete)
                    dragCanvas.NewSlideGuid = string.Empty;
                //DragCanvas.TempSlide = null;

                e.Handled = true;
            }
        }

        private void ExportSlideExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            bool saveComplete = false;

            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;

            try
            {
                if (InspireApp.CanvasExists)
                {
                    saveComplete = SaveOrExportSlide(true, false);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (saveComplete)
                    dragCanvas.NewSlideGuid = string.Empty;
                //DragCanvas.TempSlide = null;

                e.Handled = true;
            }
        }

        private void ShowLayersPanelCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // TODO: Hook Up
        }

        private void ShowLayersPanelCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Rotate90RightCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            var command = new Rotate90RightCommand(dragCanvas.DataItems, dragCanvas.selectionService.CurrentSelection, dragCanvas);
            if (dragCanvas.undoService != null)
            {
                dragCanvas.undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void Rotate90RightCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            if (dragCanvas != null && dragCanvas.selectionService != null && Designer.DesignWindow.GetDesignerWindow().IsPlaying == false)
                e.CanExecute = (dragCanvas.selectionService.CurrentSelection.Count() > 0);
        }

        private void Rotate90LeftCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            var command = new Rotate90LeftCommand(dragCanvas.DataItems, dragCanvas.selectionService.CurrentSelection, dragCanvas);
            if (dragCanvas.undoService != null)
            {
                dragCanvas.undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void Rotate90LeftCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            if (dragCanvas != null && dragCanvas.selectionService != null && Designer.DesignWindow.GetDesignerWindow().IsPlaying == false)
                e.CanExecute = (dragCanvas.selectionService.CurrentSelection.Count() > 0);
        }

        private void FlipVerticalCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            var command = new FlipVerticalCommand(dragCanvas.DataItems, dragCanvas.selectionService.CurrentSelection, dragCanvas);
            if (dragCanvas.undoService != null)
            {
                dragCanvas.undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void FlipVerticalCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            if (dragCanvas != null && dragCanvas.selectionService != null && Designer.DesignWindow.GetDesignerWindow().IsPlaying == false)
                e.CanExecute = (dragCanvas.selectionService.CurrentSelection.Count() > 0);
        }

        private void FlipHorizontalCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            var command = new FlipHorizontalCommand(dragCanvas.DataItems, dragCanvas.selectionService.CurrentSelection, dragCanvas);
            if (dragCanvas.undoService != null)
            {
                dragCanvas.undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void FlipHorizontalCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var dragCanvas = InspireApp.CurrentDragCanvas as DragCanvas;
            if (dragCanvas != null && dragCanvas.selectionService != null && Designer.DesignWindow.GetDesignerWindow().IsPlaying == false)
                e.CanExecute = (dragCanvas.selectionService.CurrentSelection.Count() > 0);
        }
    }
}
