using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu
{
    class HorizontalLine : Figure
    {
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
            : base(CreatePoints(xLeft, xRight, y, sym))
        {
        }

        private static List<Point> CreatePoints(int xLeft, int xRight, int y, char sym)
        {
            List<Point> points = new List<Point>();
            for (int x = xLeft; x <= xRight; x++)
            {
                points.Add(new Point(x, y, sym));
            }
            return points;
        }
    }

}