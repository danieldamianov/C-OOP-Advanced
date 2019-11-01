using System;
using System.Collections.Generic;

namespace GenericArrayCreator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create<string>(5, "Pesho");
            int[] integers = ArrayCreator.Create<int>(10, 33);
        }
    }
}

