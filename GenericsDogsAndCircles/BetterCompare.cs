using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDogsAndCircles
{
    public class BetterCompare
    {
        public BetterCompare() { }

        public int Height { get; set; }

        public int CompareTo(Dog x, Dog y)
        {
            //if(x == null || y == null) return 1;
            return x.Height.CompareTo(y.Height);
        }
    }
}
