namespace Inspire.Interfaces
{
    public interface IDesignerCommand
    {

        void Execute();

        void Undo();

        void Redo();

        /// <summary>
        /// Title of the Command
        /// </summary>
        /// <remarks>Typically Used in undo list</remarks>
        string Title { get; set; }
    }
}
