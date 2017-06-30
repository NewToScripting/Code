namespace Inspire.Interfaces
{
    public interface ILockable
    {
        bool IsLocked { get; set; }
        void Lock();
        bool UnLock();

    }
}
