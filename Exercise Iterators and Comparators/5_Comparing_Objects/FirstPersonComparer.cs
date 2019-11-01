using System;
using System.Collections.Generic;
using System.Text;

namespace _5_Comparing_Objects
{
    public class FirstPersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Name.Length > y.Name.Length)
            {
                return 1;
            }
            if (x.Name.Length < y.Name.Length)
            {
                return -1;
            }
            char firstLettetOfX = char.ToLower(x.Name[0]);
            char firstLettetOfY = char.ToLower(y.Name[0]);
            if (firstLettetOfX > firstLettetOfY)
            {
                return 1;
            }
            if (firstLettetOfX < firstLettetOfY)
            {
                return -1;
            }
            return 0;
        }
    }
}
