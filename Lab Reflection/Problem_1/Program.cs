using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {


        Spy spy = new Spy();

        string result = spy.CollectGettersAndSetters("System.Text.StringBuilder");

        Console.WriteLine(result);

        Console.WriteLine();

        string resultMy = spy.CollectGettersAndSettersError("System.Text.StringBuilder");

        Console.WriteLine(resultMy);

        Console.WriteLine(result == resultMy);
    }
}
