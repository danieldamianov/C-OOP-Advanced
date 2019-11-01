using Problem_1_Logger.Appenders;
using Problem_1_Logger.Appenders.Contracts;
using Problem_1_Logger.Core;
using Problem_1_Logger.Core.Contracts;
using Problem_1_Logger.Layouts;
using Problem_1_Logger.Layouts.Contracts;
using Problem_1_Logger.Loggers;
using Problem_1_Logger.Loggers.Contracts;
using Problem_1_Logger.Loggers.Enums;
using System;
using System.Linq;

namespace Problem_1_Logger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}