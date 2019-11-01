using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
{
    private const int initialCapacity = 2;
    private int count;
    private int capacity;
    private T[] data;

    public int Count => this.count;

    public CustomList()
    {
        this.count = 0;
        this.capacity = initialCapacity;
        this.data = new T[capacity];
    }

    public void Add(T element)
    {
        if (this.count == this.capacity)
        {
            DoubleSizeOfData();
        }
        this.data[this.count] = element;
        this.count++;
    }

    private void DoubleSizeOfData()
    {
        T[] oldData = new T[this.capacity];
        for (int i = 0; i < this.capacity; i++)
        {
            oldData[i] = this.data[i];
        }
        this.capacity *= 2;
        this.data = new T[this.capacity];
        for (int i = 0; i < this.capacity / 2; i++)
        {
            this.data[i] = oldData[i];
        }
    }

    public T Remove(int index)
    {
        T element = this.data[index];

        T[] helpData = new T[this.count - 1];
        for (int i = 0; i < index; i++)
        {
            helpData[i] = this.data[i];
        }
        for (int i = index + 1; i < this.count; i++)
        {
            helpData[i - 1] = this.data[i];
        }
        for (int i = 0; i < this.count - 1; i++)
        {
            this.data[i] = helpData[i];
        }
        count--;

        return element;
    }
    public bool Contains(T element)
    {
        for (int i = 0; i < this.count; i++)
        {
            if (this.data[i].CompareTo(element) == 0)
            {
                return true;
            }
        }
        return false;
    }
    public void Swap(int index1, int index2)
    {   
        T element = this.data[index1];
        this.data[index1] = this.data[index2];
        this.data[index2] = element;
    }
    public int CountGreaterThan(T element)
    {
        int count = 0;
        for (int i = 0; i < this.count; i++)
        {
            if (element.CompareTo(this.data[i]) < 0)
            {
                count++;
            }
        }
        return count;
    }
    public T Max()
    {
        T max = this.data[0];
        for (int i = 1; i < count; i++)
        {
            if (max.CompareTo(this.data[i]) < 0)
            {
                max = this.data[i];
            }
        }
        return max;
    }
    public T Min()
    {
        T min = this.data[0];
        for (int i = 1; i < count; i++)
        {
            if (min.CompareTo(this.data[i]) > 0)
            {
                min = this.data[i];
            }
        }
        return min;
    }

    public void Sort()
    {
        for (int i = 0; i < this.count - 1; i++)

            // Last i elements are already in place    
            for (int j = 0; j < this.count - i - 1; j++)
                if (this.data[j].CompareTo(this.data[j + 1]) > 0)
                    this.Swap(j, j + 1);
    }

    public IEnumerator<T> GetEnumerator()
    {
        var realData = new T[this.count];
        for (int i = 0; i < count; i++)
        {
            realData[i] = this.data[i];
        }
        return ((IEnumerable<T>)realData).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        var realData = new T[this.count];
        for (int i = 0; i < count; i++)
        {
            realData[i] = this.data[i];
        }
        return ((IEnumerable<T>)realData).GetEnumerator();
    }

    public T this[int index]
    {
        get
        {
            if (index >= this.count)
            {
                throw new IndexOutOfRangeException("Index out Of Range!");
            }
            return this.data[index];
        }
    }

}

