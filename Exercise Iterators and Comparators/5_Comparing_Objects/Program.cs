using System;
using System.Collections.Generic;

namespace _5_Comparing_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                sortedSet.Add(new Person(input.Split()[0], int.Parse(input.Split()[1])));
                hashSet.Add(new Person(input.Split()[0], int.Parse(input.Split()[1])));
            }
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
