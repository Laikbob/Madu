using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu
{
    class Figure   // базовый класс, по отношению к его наследникам (Snake, HorizontalLine, VerticalLine)
    {
        protected List<Point> plist;

        public void Draw()
        {
            foreach (Point p in plist)
            {
                p.Draw();
            }
        }

        // проверяет пересечение с другой фигурой
        internal bool IsHit(Figure figure)  // принимает фигуру
        {
            foreach (var p in plist)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }

        // проверяет пересечение с конкретной точкой
        private bool IsHit(Point point)  // принимает точку
        {
            foreach (var p in plist)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
}