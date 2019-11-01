using Problem_1_Logger.Appenders.Contracts;
using Problem_1_Logger.Core.Contracts;
using Problem_1_Logger.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_1_Logger.Core
{
    public class Engine : IEngine
    {
        ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
                

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            string input;
            string[] split;
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                split = input.Split();
                this.commandInterpreter.AddAppender(split);                
            }

            this.commandInterpreter.InitializeLoggers();

            while ((input = Console.ReadLine()) != "END")
            {
                split = input.Split('|');
                this.commandInterpreter.AppendMessage(split);
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
