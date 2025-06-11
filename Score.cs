using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu
{
    public class Score
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Score(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
