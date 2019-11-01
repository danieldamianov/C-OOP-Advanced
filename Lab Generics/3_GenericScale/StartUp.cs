using System;

namespace GenericScale
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Scale<int> scale =  new Scale<int>(1,2);
            Console.WriteLine(scale.GetHeavier());
        }
    }
}





