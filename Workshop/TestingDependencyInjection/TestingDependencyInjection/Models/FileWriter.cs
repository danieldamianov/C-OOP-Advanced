using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestingDependencyInjection.Contracts;

namespace TestingDependencyInjection.Models
{
    class FileWriter : IWriter
    {
        public void Write(string content)
        {
            File.WriteAllText("log.txt", content);
        }
    }
}
