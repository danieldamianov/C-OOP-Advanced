using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1Database
{
    public class Database
    {
        private int[] values;

        public Database(int[] values)
        {
            if (values.Length != 16)
            {
                throw new InvalidOperationException("Values count must be 16!");
            }
            this.values = values;
        }

        public void Add(int value)
        {
            int index = this.GetFirstFreeIndex();
            if (index == 16)
            {
                throw new InvalidOperationException("Container is full!");
            }
            this.values[index] = value;
        }

        public void Remove()
        {
            int index = this.GetFirstFreeIndex();
            if (index == 0)
            {
                throw new InvalidOperationException("No elements in container!");
            }
            this.values[index - 1] = 0;
        }

        private int GetFirstFreeIndex()
        {
            for (int i = 0; i < this.values.Length; i++)
            {
                if (this.values[i] == 0)
                {
                    return i;
                }
            }
            return 16;
        }

        public int[] Fetch()
        {
            return this.values.Take(this.GetFirstFreeIndex()).ToArray();
        }
    }
}
