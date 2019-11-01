namespace TheTankGame.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        //private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            //this.isRunning = false;
        }

        public void Run()
        {
            while (true)
            {
                string commandAsString = this.reader.ReadLine();
                string result = this.commandInterpreter.ProcessInput(commandAsString.Split().ToList());
                this.writer.WriteLine(result);
                if (commandAsString == "Terminate")
                {
                    break;
                }
            }
        }
    }
}