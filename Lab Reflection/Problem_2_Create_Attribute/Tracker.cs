using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);
        foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public))
        {
            SoftUniAttribute softUniAttribute = method.GetCustomAttribute<SoftUniAttribute>();
            if (softUniAttribute != null)
            {
                Console.WriteLine($"{method.Name} is written by {softUniAttribute}");
            }
            //else
            //{
            //    Console.WriteLine(4);
            //}
        }
    }
}

