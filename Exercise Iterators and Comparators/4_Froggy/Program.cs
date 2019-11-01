using System;
using System.Linq;
using System.Xml.Linq;

namespace _4_Froggy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Lake lake = new Lake
                (Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());

            Console.WriteLine(string.Join(", ",lake));
        }
    }
}
