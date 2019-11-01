using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class CustomList<T> : IEnumerable<T>
    {
        public List<T> listOfItems;
        public List<T> listOfItems2;
        public T Name;

        public CustomList()
        {
            listOfItems = new List<T>();
            listOfItems2 = new List<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this.listOfItems,this.listOfItems2,this.Name);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class Enumerator : IEnumerator<T>
        {
            int currentItem;
            int count;

            public T Current
            {
                get
                {
                    switch (this.currentItem)
                    {
                        case 1:
                            return this.list1[this.count];
                        case 2:
                            return this.list2[this.count];
                        case 3:
                            return this.name;
                    }
                    throw new Exception("Error");
                }
            }


            object IEnumerator.Current => this.Current;

            private List<T> list1;
            private List<T> list2;
            private T name;

            public Enumerator(List<T> list1, List<T> list2, T name)
            {
                this.list1 = list1;
                this.list2 = list2;
                this.name = name;
                this.Reset();
            }

            public bool MoveNext()
            {
                if (this.currentItem == 1)
                {
                    this.count++;
                    if (this.count >= this.list1.Count)
                    {
                        this.count = 0;
                        this.currentItem = 2;
                    }
                    return true;
                }
                else if (this.currentItem == 2)
                {
                    this.count++;
                    if (this.count >= this.list1.Count)
                    {
                        this.count = 0;
                        this.currentItem = 3;
                    }
                    return true;
                }
                else if (this.currentItem == 3)
                {
                    return false;
                }
                return false;
            }

            public void Reset()
            {
                this.currentItem = 1;
                this.count = -1;
            }

            public void Dispose()
            { }
            
        }
    }
}
