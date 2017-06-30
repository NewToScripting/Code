using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Inspire.Interfaces;

namespace Inspire.Services
{
    public class UndoService : IUndoService
    {
        #region ctor
        public UndoService()
        {
            UndoCommands = new Stack<IDesignerCommand>();
            UndoTitles = new ObservableCollection<string>();
            RedoCommands = new Stack<IDesignerCommand>();
            RedoTitles = new ObservableCollection<string>();
        }
        #endregion

        #region Routed events bindng support

        public void OnExecuteUndo(object sender, ExecutedRoutedEventArgs e)
        {
            Undo();
        }

        public void OnCanExecuteUndo(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanUndo;
        }

        public void OnExecuteRedo(object sender, ExecutedRoutedEventArgs e)
        {
            Redo();
        }

        public void OnCanExecuteRedo(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanRedo;
        }

        #endregion

        #region IUndoService Members

        public Stack<IDesignerCommand> UndoCommands { get; protected set; }
        public Stack<IDesignerCommand> RedoCommands { get; protected set; }
        public ObservableCollection<string> UndoTitles { get; protected set; }
        public ObservableCollection<string> RedoTitles { get; protected set; }
        public bool CanUndo { get { return UndoCommands.Count > 0; } }
        public bool CanRedo { get { return RedoCommands.Count > 0; } }

        public void Execute(IDesignerCommand command)
        {
            if (command == null) return;
            // Execute command
            command.Execute();
            // Push command to undo history
            if (command is IDesignerCommand)
            {
                UndoCommands.Push(command);
                UndoTitles.Insert(0, command.Title);
                // Clear the redo history upon adding new undo entry. This is a typical logic for most applications
                RedoCommands.Clear();
                RedoTitles.Clear();
            }
        }

        public void Undo()
        {
            if (CanUndo)
            {
                IDesignerCommand command = UndoCommands.Pop();
                command.Undo();
                UndoTitles.RemoveAt(0);
                RedoCommands.Push(command);
                RedoTitles.Insert(0, command.Title);
            }
        }

        public void Redo()
        {
            if (CanRedo)
            {
                IDesignerCommand command = RedoCommands.Pop();
                RedoTitles.RemoveAt(0);
                //Execute(command);
                if (command != null)
                {
                    command.Execute();

                    if (command is IDesignerCommand)
                    {
                        UndoCommands.Push(command);
                        UndoTitles.Insert(0, command.Title);
                    }
                }
            }
        }

        public void ClearUndoHistory()
        {
            UndoCommands.Clear();
            UndoTitles.Clear();
        }

        public void ClearRedoHistory()
        {
            RedoCommands.Clear();
            RedoTitles.Clear();
        }

        public void ClearHistory()
        {
            ClearRedoHistory();
            ClearUndoHistory();
        }

        #endregion
    }
}
