using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Services
{
    public class SelectionService
    {
        private readonly ObservableCollection<ContentControl> canvasItems;

        public bool CanDelete
        {
            get
            {
                if (currentSelection != null) return currentSelection.Count > 0;
                return false;
            }
        }

        private List<ISelectable> currentSelection;
        public List<ISelectable> CurrentSelection
        {
            get
            {
                if (currentSelection == null)
                    currentSelection = new List<ISelectable>();

                return currentSelection;
            }
        }


        public bool HasCopyableSelection // TODO: Take this out once copy and paste is implemented correctly
        {
            get
            {
                if (currentSelection != null)
                {
                    bool canCopy = false;
                    foreach (var selectable in currentSelection)
                    {
                        //if (((DesignContentControl) selectable).IsCopyable)
                            canCopy = true;
                    }
                    return canCopy;
                }
                return false;
            }
        }

        public SelectionService(ObservableCollection<ContentControl> itemCollection)
        {
            canvasItems = itemCollection;
        }

        public void SelectItem(ISelectable item)
        {
            ClearSelection();
            AddToSelection(item);
            FrameworkElement element = (FrameworkElement)item;

            Application.Current.MainWindow.DataContext = element;
            InspireApp.SelectedContext = element;

        }

        public void AddToSelection(ISelectable item)
        {
            item.IsSelected = true;
            CurrentSelection.Add(item);
        }

        public void RemoveFromSelection(ISelectable item)
        {
            item.IsSelected = false;
            CurrentSelection.Remove(item);
        }

        public void ClearSelection()
        {
            CurrentSelection.ForEach(item => item.IsSelected = false);
            CurrentSelection.Clear();
        }

        public void SelectAll()
        {
            ClearSelection();
            CurrentSelection.AddRange(canvasItems.OfType<ISelectable>());
            CurrentSelection.ForEach(item => item.IsSelected = true);
        }

        public void OnCanExecuteDelete(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanDelete;
        }
    }
}
