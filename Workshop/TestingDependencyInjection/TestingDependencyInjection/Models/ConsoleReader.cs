using System;
using System.Collections.Generic;
using System.Text;
using TestingDependencyInjection.Contracts;

namespace TestingDependencyInjection.Models
{
    class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
