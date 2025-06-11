using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madu;

namespace Madu
{
    class VerticalLine : Figure
    {
        public VerticalLine(int yUp, int yDown, int x, char sym)
            : base(CreatePoints(yUp, yDown, x, sym))
        {
        }

        private static List<Point> CreatePoints(int yUp, int yDown, int x, char sym)
        {
            List<Point> points = new List<Point>();
            for (int y = yUp; y <= yDown; y++)
            {
                points.Add(new Point(x, y, sym));
            }
            return points;
        }
    }
}