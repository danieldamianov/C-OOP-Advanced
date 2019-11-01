using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> stack;
        
        public Box()
        {
            this.stack = new Stack<T>();
        }

        public int Count => this.stack.Count;

        public void Add(T item)
        {
            this.stack.Push(item);
        }

        public T Remove()
        {
            return this.stack.Pop();
        }
    }
}