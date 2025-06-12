using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu
{
    public class Score
    {   
        // Свойство Name — имя игрока
        public string Name { get; set; }
        // Свойство Value — количество набранных очков
        public int Value { get; set; }
        // принимает имя и очки 
        public Score(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
