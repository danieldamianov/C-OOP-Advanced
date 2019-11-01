using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListIterator
{
    public class ListIterator<T> : IEnumerable<T>
    {
        private readonly List<T> list;
        private int internalIndex;

        public ListIterator(List<T> list)
        {
            this.list = list;
            this.Reset();
        }

        public bool Move()
        {
            if (!this.HasNext())
            {
                return false;
            }
            this.internalIndex++;
            return true;
        }

        public bool HasNext()
        {
            return this.internalIndex < this.list.Count - 1;
        }

        public void Print()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.list[this.internalIndex]);
        }

        private void Reset()
        {
            this.internalIndex = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
