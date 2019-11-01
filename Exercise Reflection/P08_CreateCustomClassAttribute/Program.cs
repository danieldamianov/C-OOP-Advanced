using System;
using System.Reflection;

namespace P08_CreateCustomClassAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(TestClass);

            CustomClassAttribute customClassAttribute = type.GetCustomAttribute<CustomClassAttribute>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                typeof(CustomClassAttribute).GetMethod($"Print{input}").Invoke(customClassAttribute,new object[] { });
            }
        }
    }
}
