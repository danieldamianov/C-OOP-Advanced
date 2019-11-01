using CustomDependencyInjection.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using TestingDependencyInjection.Contracts;

namespace TestingDependencyInjection
{
    class Engine : IEngine
    {
        [Inject]
        [Named("ConsoleReader")]
        IReader reader;
        [Inject]
        [Named("ConsoleWriter")]
        IWriter writerConsole;
        [Inject]
        [Named("FileWriter")]
        IWriter writerFile;

        public Engine()
        {

        }

        public Engine(IReader reader, IWriter writerConsole, IWriter writerFile)
        {
            this.reader = reader;
            this.writerConsole = writerConsole;
            this.writerFile = writerFile;
        }

        public void Run()
        {
            string content = this.reader.Read();
            this.writerFile.Write(content);
            this.writerConsole.Write(content);
        }
    }
}
