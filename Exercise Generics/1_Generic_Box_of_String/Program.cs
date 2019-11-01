using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<double> boxes = new List<double>(n);
        for (int i = 0; i < n; i++)
        {
            boxes.Add(double.Parse(Console.ReadLine())); 
        }
        double comparisonValue = double.Parse(Console.ReadLine());
        Console.WriteLine(CountGreaterValues<double>(boxes,comparisonValue));
    }

    public static int CountGreaterValues<T>(List<T> list, T comparisonValue) where T : IComparable<T>
    {
        int count = 0;
        foreach (var item in list)
        {
            if (comparisonValue.CompareTo(item) < 0 )
            {
                count++;
            }
        }
        return count;
    }
}

