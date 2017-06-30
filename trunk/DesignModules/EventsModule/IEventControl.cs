using System.Windows.Controls;

namespace EventsModule
{
    public interface IEventControl
    {
        ListBox EventColumns { get; set; }
        TextBlock HeaderRow { get; set; }
        int SecondsPerPage { get; set; }
        void UpdateAppearance();
    }
}