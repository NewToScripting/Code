using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Inspire.Commands;
using Inspire.Common.Dialogs;
using Inspire.Server.Proxy;

namespace Inspire.Client.DesignWindow.DesignPropertyPanel
{
    /// <summary>
    /// Interaction logic for ScheduleSlideControl.xaml
    /// </summary>
    public partial class DesignSlideControl
    {

        private delegate void SaveSlideDelegate(SlideFile slideFile);

        public DesignSlideControl()
        {
            InitializeComponent();
            DesignSlideWrapPanel.ItemsSource = SlideItemCollection.Slides;
        }

        private void ListBoxItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Slide slide = (Slide)((Border)sender).DataContext;
            if (!slide.IsSaving)
            {
                DragDrop.DoDragDrop(this, slide, DragDropEffects.Copy);
            
                if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
                {
                    //DragCanvas.DataItems.Clear();
                    //DragCanvas.undoService.ClearHistory();
                    //DragCanvas.selectionService.ClearSelection();
                    //DragCanvas.IsPlaying = false;
                    //DragCanvas.IsCreated = true;
                    //Files.ClearDirectory(Paths.ClientTempDirectory);

                    try
                    {
                        //DragCanvas.TempSlide = slide;

                        ICommand command = InspireCommands.LoadSlideCommand;
                        command.Execute(slide);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Loading Slide " + ex);
                    }
                }
            }

        }

        private void DeleteSlideExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Slide slide = DesignSlideWrapPanel.SelectedItem as Slide;
            //MenuItem mItem = (MenuItem)sender;
            //ContextMenu cMenu = (ContextMenu)mItem.Parent;
            //Slide _slide = (Slide)cMenu.DataContext;
            if (slide != null)
                if (!slide.IsSaving)
                {
                    CommonDialog commonDialog = new CommonDialog("Delete Slide?","Are you sure you like to delete the slide?");
                    commonDialog.ShowDialog();
                    if (commonDialog.DialogResult == true)
                    {
                        if (slide.IsOnline)
                        {
                            SlideManager.DeleteSlideFile(slide.GUID);
                        }
                        SlideItemCollection.Slides.Remove(slide);

                        if (!slide.IsOnline)
                            SlideCollection.SerializeOfflineSlidesToXML(SlideItemCollection.Slides);
                    }

                }
            e.Handled = true;
        }

        private void DeleteSlideCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (User.UserPermision.Contains(PermissionTypes.Administrator) ||
                            User.UserPermision.Contains(PermissionTypes.ContentCreator));
        }

        private void UploadSlideToServerExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Source != null)
            {
                var s = (Slide) DesignSlideWrapPanel.SelectedItem;
                if (s != null)
                {
                    //Files.ClearDirectory(Paths.ClientTempDirectory);
                    if (File.Exists(Paths.ClientLocalSlidePackagesDirectory + s.GUID + ".insp"))
                    {
                        SlideFile slide = new SlideFile(s);
                        slide.File = File.ReadAllBytes(Paths.ClientLocalSlidePackagesDirectory + slide.GUID + ".insp");

                        slide.IsSaving = true;

                        //TODO: When Server is rebuilt, add slide.IsOnline to complete of AddSlideFile, as well as make sure IsSaving = false
                        //TODO: Also Delete and repopulate Offline Slide files when the upload completes
                        SaveSlideDelegate workerDelegate = SlideManager.AddSlideFile;

                        workerDelegate.BeginInvoke(slide, null, null);
                    }
                }
            }
        }

        private void UploadSlideToServerCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(!Designer.DesignWindow.IsDesignerMode && e.Source != null)
            {
                Slide slide = (Slide) DesignSlideWrapPanel.SelectedItem;
                if (slide != null) 
                    e.CanExecute = !slide.IsOnline;
            }
        }

        private void RefreshSlidesExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                btnRefresh.IsEnabled = false;
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                                                                                 {

                                                                                     DesignSlideWrapPanel.ItemsSource = null;

                                                                                    //SlideItemCollection.Slides.Clear();

                                                                                     SlideItemCollection.
                                                                                         UpdateOnlineSlideCollection(
                                                                                             SlideManager.GetSlides());

                                                                                     SlideItemCollection.LoadOffLineSlides();

                                                                                     //List<Slide> slCol = SlideManager.GetSlides();
                                                                                     //foreach (Slide slide in slCol)
                                                                                     //{
                                                                                     //    slide.IsOnline = true;
                                                                                     //    SlideItemCollection.Slides.Add(slide);
                                                                                     //}
                                                                                     DesignSlideWrapPanel.ItemsSource = SlideItemCollection.Slides;
                                                                                     btnRefresh.IsEnabled = true;

                                                                                     SlideItemCollection.SortSlidesByName();
                                                                                 }));
                
            }
            catch (Exception)
            {
                btnRefresh.IsEnabled = true;
            }
        }

        private void RefreshSlidesCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
