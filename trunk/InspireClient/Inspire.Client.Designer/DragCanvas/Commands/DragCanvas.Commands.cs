using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Inspire.Client.Designer.Commands;
using Inspire.Designer.Commands;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Client.Designer.DragCanvas
{
    public partial class DragCanvas
    {
        private void BringToFrontExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var command = new BringToFrontCommand(DataItems, selectionService.CurrentSelection);

            if (undoService != null)
            {
                undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void BringToFrontCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (DesignWindow.GetDesignerWindow() != null && 
                !DesignWindow.GetDesignerWindow().IsPlaying);
        }

        private void BringForwardCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var command = new BringForwardCommand(DataItems, selectionService.CurrentSelection);

            if (undoService != null)
            {
                undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void BringForwardCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (selectionService != null && DesignWindow.GetDesignerWindow().IsPlaying == false)
                e.CanExecute = (selectionService.CurrentSelection.Count() > 0 && DataItems.Count > 1) && (DesignWindow.GetDesignerWindow() != null && 
                !DesignWindow.GetDesignerWindow().IsPlaying);
        }

        private void SendToBackCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var command = new SendToBackCommand(DataItems, selectionService.CurrentSelection);

            if (undoService != null)
            {
                undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void SendToBackCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (DesignWindow.GetDesignerWindow() != null &&
                            !DesignWindow.GetDesignerWindow().IsPlaying);
        }

        private void SendBackwardCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var command = new SendBackwardCommand(DataItems, selectionService.CurrentSelection);

            if (undoService != null)
            {
                undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void SendBackwardCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (selectionService != null && DesignWindow.GetDesignerWindow().IsPlaying == false)
                e.CanExecute = (selectionService.CurrentSelection.Count() > 0 && DataItems.Count > 1) &&(DesignWindow.GetDesignerWindow() != null &&
                            !DesignWindow.GetDesignerWindow().IsPlaying);
        }

        private void SelectAllExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var command = new SelectAllDesignItemsCommand();
            command.Execute();
        }

        private void SelectAllCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(DataItems.Count > 0)
                e.CanExecute = (DesignWindow.GetDesignerWindow() != null &&
                            !DesignWindow.GetDesignerWindow().IsPlaying);
        }


        private void FitToSlideCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var command = new FillSlideCommand(DataItems, selectionService.CurrentSelection, this);

            if (undoService != null)
            {
                undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void FitToSlideCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (selectionService.CurrentSelection.Count == 1)
                e.CanExecute = (DesignWindow.GetDesignerWindow() != null &&
                            !DesignWindow.GetDesignerWindow().IsPlaying);
        }

        private void AddReflectionCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            List<ISelectable> ordered = selectionService.CurrentSelection.ToList();

            var originalContentControl = (DesignControlHolder)ordered[0];

            var designContentControl = DesignReflection.GetReflectionContentControl(originalContentControl);

            var command = new AddDesignItemCommand(DataItems, designContentControl, this, false);

            if (undoService != null)
            {
                undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void AddReflectionCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (selectionService.CurrentSelection.Count == 1)
                e.CanExecute = (DesignWindow.GetDesignerWindow() != null &&
                            !DesignWindow.GetDesignerWindow().IsPlaying);
        }

        private void MoveItemUpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var command = new MoveDesignItemUpCommand(DataItems, selectionService.CurrentSelection, this);

            if (undoService != null)
            {
                undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void MoveItemUpCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (selectionService.CurrentSelection.Count > 0)
                e.CanExecute = true;
        }

        private void MoveItemDownExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var command = new MoveDesignItemDownCommand(DataItems, selectionService.CurrentSelection, this);

            if (undoService != null)
            {
                undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void MoveItemDownCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (selectionService.CurrentSelection.Count > 0)
                e.CanExecute = true;
        }

        private void MoveItemLeftExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var command = new MoveDesignItemLeftCommand(DataItems, selectionService.CurrentSelection, this);

            if (undoService != null)
            {
                undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void MoveItemLeftCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (selectionService.CurrentSelection.Count > 0)
                e.CanExecute = true;
        }

        private void MoveItemRightExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var command = new MoveDesignItemRightCommand(DataItems, selectionService.CurrentSelection, this);

            if (undoService != null)
            {
                undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void MoveItemRightCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (selectionService.CurrentSelection.Count > 0)
                e.CanExecute = true;
        }

        private void MoveItemUpShiftExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var command = new MoveDesignItemUpShiftCommand(DataItems, selectionService.CurrentSelection, this);

            if (undoService != null)
            {
                undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void MoveItemUpShiftCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (selectionService.CurrentSelection.Count > 0)
                e.CanExecute = true;
        }

        private void MoveItemDownShiftExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var command = new MoveDesignItemDownShiftCommand(DataItems, selectionService.CurrentSelection, this);

            if (undoService != null)
            {
                undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void MoveItemDownShiftCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (selectionService.CurrentSelection.Count > 0)
                e.CanExecute = true;
        }

        private void MoveItemLeftShiftExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var command = new MoveDesignItemLeftShiftCommand(DataItems, selectionService.CurrentSelection, this);

            if (undoService != null)
            {
                undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void MoveItemLeftShiftCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (selectionService.CurrentSelection.Count > 0)
                e.CanExecute = true;
        }

        private void MoveItemRightShiftExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var command = new MoveDesignItemRightShiftCommand(DataItems, selectionService.CurrentSelection, this);

            if (undoService != null)
            {
                undoService.Execute(command);
            }
            else
                command.Execute();
        }

        private void MoveItemRightShiftCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (selectionService.CurrentSelection.Count > 0)
                e.CanExecute = true;
        }

        public static void AttachReflections(IEnumerable canvasItems)
        {
            Utilities.AttachReflections(canvasItems);
        }

        public void DeleteReflection(string guid, IEnumerable<ContentControl> canvasItems)
        {
            int removeIndex = -1;
            foreach (var item in canvasItems)
            {
                if (item.Content is DesignReflection)
                {
                    if(((DesignReflection)item.Content).TargetGuid == guid)
                        removeIndex = DataItems.IndexOf(item);
                }
            }
            if(removeIndex > -1)
                DataItems.RemoveAt(removeIndex);
        }

        public void DetatchReflections(IEnumerable<ContentControl> canvasItems)
        {
            foreach (var item in canvasItems)
                if (item.Content is DesignReflection)
                {
                    ((DesignReflection) item.Content).ReflectionTarget = null;
                    //item.ClearValue(ContentProperty);
                }
            }

        public void ClearUndoGarbage()
        {
            foreach (var item in GarbageItems)
            {
                if (item.Content != null)
                {
                    if(((ContentControl)item.Content).Content is IDisposable)
                        ((IDisposable)((ContentControl)item.Content).Content).Dispose();
                    ((ContentControl) item.Content).Content = null;
                    item.Content = null;
                }
            }
        }

        /// <summary>
        /// For the purpose of keeping each controls id unique, for the purpose of button guids if a slide is copied the controls need to get a new guid.
        /// </summary>
        public void ReSeedContentControls()
        {
            var originalCollection = new List<KeyValuePair<string, string>>();

            foreach (DesignControlHolder contentControl in DataItems)
            {
                var designControl = contentControl.Content as DesignContentControl;
                var newGuid = Guid.NewGuid().ToString();
                originalCollection.Add(new KeyValuePair<string, string>(designControl.GUID, newGuid));
                designControl.GUID = newGuid;
            }

            ChangeFilterGuids(originalCollection);

            ChangeReflectionGuids(originalCollection);
        }

        private void ChangeReflectionGuids(List<KeyValuePair<string, string>> originalCollection)
        {
            var reflectionCollection =
                DataItems.Where(r => ((DesignContentControl) r.Content).Content is DesignReflection);

            foreach (var contentControl in reflectionCollection)
            {
                try
                {
                    ((DesignReflection)((DesignContentControl)contentControl.Content).Content).TargetGuid =
                        originalCollection.FirstOrDefault(s => s.Key == ((DesignReflection)((DesignContentControl)contentControl.Content).Content).TargetGuid).Value;
                }
                catch { } // Keep going

            }
        }

        private void ChangeFilterGuids(IEnumerable<KeyValuePair<string, string>> originalCollection)
        {
            var filterCollection = DataItems.Where(c => ((DesignContentControl) c.Content).Content is IFilter);

            foreach (var contentControl in filterCollection)
            {
                try
                {
                    ((IFilter)((DesignContentControl)contentControl.Content).Content).GuidToFilterOn =
                        originalCollection.FirstOrDefault(s => s.Key == ((IFilter)((DesignContentControl)contentControl.Content).Content).GuidToFilterOn).Value;
                }
                catch{} // Keep going
                
            }
        }


    }
}
