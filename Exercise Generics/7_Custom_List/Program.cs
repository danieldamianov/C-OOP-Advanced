using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        CustomList<string> customList = new CustomList<string>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var commandSplit = input.Split();
            switch (commandSplit[0])
            {
                case "Add":
                    customList.Add(commandSplit[1]);
                    break;
                case "Remove":
                    customList.Remove(int.Parse(commandSplit[1]));
                    break;
                case "Contains":
                    Console.WriteLine(customList.Contains(commandSplit[1]));
                    break;
                case "Swap":
                    customList.Swap(int.Parse(commandSplit[1]), int.Parse(commandSplit[2]));
                    break;
                case "Greater":
                    Console.WriteLine(customList.CountGreaterThan(commandSplit[1]));
                    break;
                case "Max":
                    Console.WriteLine(customList.Max());
                    break;
                case "Min":
                    Console.WriteLine(customList.Min());
                    break;
                case "Print":
                    foreach (var item in customList)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "Sort":
                    customList.Sort();
                    break;
            }
        }
    }
}

