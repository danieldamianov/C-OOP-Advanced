using System;

public class Program
{
    static void Main(string[] args)
    {
        string firstLine = Console.ReadLine();          
        string secondLine = Console.ReadLine();          
        string thirdLine = Console.ReadLine();

        string[] firstLineSplitted = firstLine.Split();
        string[] secondLineSplitted = secondLine.Split();
        string[] thirdLineSplitted = thirdLine.Split();

        CustomTuple<string, string,string> firstTuple = new CustomTuple<string, string,string>
            (firstLineSplitted[0] + " " + firstLineSplitted[1], firstLineSplitted[2], firstLineSplitted[3]);

        CustomTuple<string, int, bool> secondTuple = new CustomTuple<string, int, bool>
            (secondLineSplitted[0],int.Parse(secondLineSplitted[1]),secondLineSplitted[2] == "drunk");

        CustomTuple<string, double, string> thirdTuple = new CustomTuple<string, double, string>
            (thirdLineSplitted[0], double.Parse(thirdLineSplitted[1]),thirdLineSplitted[2]);

        Console.WriteLine(firstTuple);
        Console.WriteLine(secondTuple);
        Console.WriteLine(thirdTuple);
    }
}

