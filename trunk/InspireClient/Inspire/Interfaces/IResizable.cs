using System.Windows;

namespace Inspire.Interfaces
{
    public interface IResizable
    {
        void RePopulateBasedOnSize(SizeChangedInfo info);
    }
}
