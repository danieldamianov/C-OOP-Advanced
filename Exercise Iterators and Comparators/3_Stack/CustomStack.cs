using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _3_Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private T[] data;
        private const int initialCapacity = 4;
        private int count;
        private int capacity;

        public CustomStack()
        {
            this.data = new T[initialCapacity];
            this.count = 0;
            this.capacity = initialCapacity;
        }

        public int Count => this.count;

        public void Push(T element)
        {
            if (this.count == this.data.Length)
            {
                Resize();
            }
            this.data[count] = element;
            this.count++;
        }

        public T Pop()
        {
            this.count--;
            return this.data[this.count];
        }

        private void Resize()
        {
            T[] help = new T[this.capacity];
            for (int i = 0; i < this.capacity; i++)
            {
                help[i] = this.data[i];
            }
            this.capacity *= 2;
            this.data = new T[this.capacity];
            for (int i = 0; i < this.count; i++)
            {
                this.data[i] = help[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
