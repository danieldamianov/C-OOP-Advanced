using System;
using System.Linq;

namespace _3_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            CustomStack<int> customStack = new CustomStack<int>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] split = input.Split(new char[] {' ',','} ,StringSplitOptions.RemoveEmptyEntries);
                switch (split[0])
                {
                    case "Push":
                        foreach (var number in split.Skip(1).Select(int.Parse).ToArray())
                        {
                            customStack.Push(number);
                        }
                        break;
                    case "Pop":
                        if (customStack.Count == 0)
                        {
                            Console.WriteLine("No elements");
                        }
                        else
                        {
                            customStack.Pop();
                        }
                        break;
                }
            }
            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
