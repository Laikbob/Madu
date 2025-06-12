using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu
{
    class Snake : Figure
    {
        Derection direction; //текущее направление движения змейки

        public Snake(Point tail, int length, Derection direction)
        : base(CreateSnakePoints(tail, length)) // ← передаём список в Figure
        {
            this.direction = direction;
        }
        // Создаёт список точек, начиная с хвоста, 
        private static List<Point> CreateSnakePoints(Point tail, int length)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail.x + i, tail.y, tail.sym);
                points.Add(p);
            }
            return points;
        }
        // метот ползонья змейки
        internal void Move()
        {
            Point tail = plist.First();
            plist.Remove(tail);
            Point head = GetNextPoint();
            plist.Add(head);

            tail.Clear();
            head.Draw();
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                plist.Add(food);
                return true;
            }
            else
            {
                return false;
            }
        }


        public Point GetNextPoint()
        {
            Point head = plist.Last();  // Получаем последнюю точку (голова змейки)
            Point nextPoint = new Point(head);  // Копируем точку головы
            nextPoint.Move(1, direction);  // Перемещаем точку на 1 в заданном направлении
            nextPoint.sym = '*';  // Устанавливаем символ для головы змейки
            return nextPoint;
        }

        internal bool IsHitTail()
        {
            Point head = plist.Last(); // or .First(), depending on logic
            for (int i = 0; i < plist.Count - 1; i++) // skip the head
            {
                if (head.IsHit(plist[i]))
                    return true;
            }
            return false;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Derection.Left;
            else if (key == ConsoleKey.RightArrow)
                direction = Derection.Right;
            else if (key == ConsoleKey.DownArrow)
                direction = Derection.Down;
            else if (key == ConsoleKey.UpArrow)
                direction = Derection.Up;
        }
    }
}