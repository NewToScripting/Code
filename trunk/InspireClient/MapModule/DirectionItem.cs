using System.Windows.Media;

namespace MapModule
{
    public class DirectionItem
    {
        public DirectionItem(){}

        public DirectionItem(int itemNumber, string direction, Brush brush)
        {
            ItemNumber = itemNumber;
            Direction = direction;
            Brush = brush;
        }

        public string Direction { get; set; }

        public int ItemNumber { get; set; }

        public Brush Brush { get; set; }
    }
}