using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu
{
    class Point
    {
        public int x;
        public int y;
        public char sym;

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move(int offset, Derection direction)
        {
            if (direction == Derection.Right)
            {
                x = x + offset;
            }
            else if (direction == Derection.Left)
            {
                x = x - offset;
            }
            else if (direction == Derection.Up)
            {
                y = y - offset;
            }
            else if (direction == Derection.Down)
            {
                y = y + offset;
            }
        }
        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;


        }
        public void Clear()
        {
            sym = ' ';
            Draw();
        }

        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }




        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }
    }
}