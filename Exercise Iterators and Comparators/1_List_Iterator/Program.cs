using System;
using System.Collections.Generic;
using System.Linq;

namespace ListIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list;
            string input = Console.ReadLine();
            if (input.Split().Length == 1)
            {
                list = new List<string>();
            }
            else
            {
                list = input.Split().Skip(1).ToList();
            }
            ListIterator<string> listIterator = new ListIterator<string>(list);
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandSplit = input.Split();
                string command = commandSplit[0];
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listIterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            listIterator.Print();
                        }
                        catch (InvalidOperationException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(listIterator.HasNext());
                        break;
                    case "PrintAll":
                        foreach (var item in listIterator)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
