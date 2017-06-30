using System.Windows.Media;

namespace Inspire
{
    public interface IFilterable{}
}

public interface IFilter
{
    string GuidToFilterOn { get; set; }
    FontFamily SelectedFontFamily { get; set; }
    SolidColorBrush CharacterForeground { get; set; }
    SolidColorBrush SelectedCharacterBrush { get; set; }
    SolidColorBrush GlowForeground { get; set; }
}
