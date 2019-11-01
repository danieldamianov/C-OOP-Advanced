using System;
using System.Collections.Generic;
using System.Text;

namespace _5_Comparing_Objects
{
    public class SecondPersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Age > y.Age)
            {
                return 1;
            }
            if (x.Age < y.Age)
            {
                return -1;
            }
            return 0;
        }
    }
}
