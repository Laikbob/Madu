using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madu;

namespace Madu
{
    class WallBlock : Figure
    {
        public WallBlock(Point point) : base(new List<Point> { point })
        {
        }
    }

    class Walls
    {
        private List<Figure> wallList;
        private int mapWidth;
        private int mapHeight;
        private int score = 0;

        public Walls(int mapWidth, int mapHeight)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;

            wallList = new List<Figure>();

            // Добавляем только рамку
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '=');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '=');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '|');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '|');

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }

        

        public void GenerateRandomWalls(int count)
        {
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                int length = rnd.Next(3, 5);
                bool horizontal = rnd.Next(0, 2) == 0;

                int x, y;

                if (horizontal)
                {
                    x = rnd.Next(1, mapWidth - length - 1);
                    y = rnd.Next(1, mapHeight - 1);
                    HorizontalLine wallLine = new HorizontalLine(x, x + length - 1, y, '#');
                    wallList.Add(wallLine);
                }
                else
                {
                    x = rnd.Next(1, mapWidth - 1);
                    y = rnd.Next(1, mapHeight - length - 1);
                    VerticalLine wallLine = new VerticalLine(y, y + length - 1, x, '#');
                    wallList.Add(wallLine);
                }
            }
        }

        public bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                    return true;
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }


}
