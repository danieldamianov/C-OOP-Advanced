using System;
using System.Collections.Generic;
using System.Text;
using TestingDependencyInjection.Contracts;

namespace TestingDependencyInjection.Models
{
    class ConsoleWriter : IWriter
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
