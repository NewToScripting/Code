using Inspire.Services;

namespace Inspire.Interfaces
{
    public interface IDragCanvas
    {
        UndoService UndoService { get; set; }
    }
}
