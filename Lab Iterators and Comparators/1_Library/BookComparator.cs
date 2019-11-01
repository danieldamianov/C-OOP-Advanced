using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Title != x.Title)
            {
                return x.Title.CompareTo(y.Title);
            }
            if (x.Year != y.Year)
            {
                return y.Year.CompareTo(x.Year);
            }
            return 0;
        }
    }
}
