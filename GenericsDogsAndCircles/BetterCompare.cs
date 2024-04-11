using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDogsAndCircles
{
    public class BetterCompare<T> where T : IComparable<T>
    {

        public BetterCompare() { }


        // using generics of T
        public T Largest(T x,T y, T z)
        {
            T max = x;
            if(y.CompareTo(max) > 0 )
            {
                max = y;
            }

            if(z.CompareTo(max) > 0 )
            { 
                max = z; 
            }
            return max;
        }
    }
}
