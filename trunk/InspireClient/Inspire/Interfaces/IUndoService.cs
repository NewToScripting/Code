using System.Collections.Generic;
using System.Collections.ObjectModel;
using Inspire.Interfaces;

namespace Inspire.Services
{
    public interface IUndoService
    {
        /// <summary>
        /// Get the undo commands history.
        /// </summary>
        Stack<IDesignerCommand> UndoCommands { get; }

        /// <summary>
        /// Get the redo commands history.
        /// </summary>
        Stack<IDesignerCommand> RedoCommands { get; }

        /// <summary>
        /// Get the undo commands titles.
        /// </summary>
        ObservableCollection<string> UndoTitles { get; }

        /// <summary>
        /// Get the redo commands titles.
        /// </summary>
        ObservableCollection<string> RedoTitles { get; }

        /// <summary>
        ///  Gets a value indicating whether there is anything that can be undone.
        /// </summary>
        bool CanUndo { get; }

        /// <summary>
        /// Gets a value indicating whether there is anything that can be rolled forward.
        /// </summary>
        bool CanRedo { get; }

        /// <summary>
        /// This method puts the command to the Undo stack and then executes it.
        /// </summary>
        /// <param name="command">The command to be executed.</param>
        void Execute(IDesignerCommand command);

        /// <summary>
        /// Rollback the last command.
        /// </summary>
        void Undo();

        /// <summary>
        /// Rollback the last undone command.
        /// </summary>
        void Redo();

        /// <summary>
        /// Clear the undo history.
        /// </summary>
        void ClearUndoHistory();

        /// <summary>
        /// Clear the redo history.
        /// </summary>
        void ClearRedoHistory();

        /// <summary>
        /// Clear all the undo and redo history.
        /// </summary>
        void ClearHistory();
    }
}
