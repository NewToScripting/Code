using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EventsModule
{
    public class EventTextBlock : TextBlock
    {

        public EventTextBlock(string text, TextBlock textBlock)
        {
            IsHitTestVisible = false;
            TextAlignment = TextAlignment.Center;
            Text = text;
            Foreground = textBlock.Foreground;
        }
        
    }
}
