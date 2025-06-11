using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu
{
    class Walls
    {
        List<Figure> wallList;  // список фигур

        public Walls(int mapWidth, int mapHeight)  // принимает габариты карты
        {
            wallList = new List<Figure>();

            // Отрисовка рамочки
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '=');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '=');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '|');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '|');

            // принцип полиморфизма (в список с фигурами добавляются объекты наследников)
            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);

        }


        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
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