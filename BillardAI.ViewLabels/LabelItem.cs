using System.Drawing;

namespace BillardAI.ViewLabels
{
    public class LabelItem
    {
        public int Class { get; set; }
        public Point P1 { get; set; }
        public Point P2 { get; set; }

        public Point Midpoint => new Point( (P1.X + P2.X)/2, (P1.Y + P2.Y)/2 );

    }
}
