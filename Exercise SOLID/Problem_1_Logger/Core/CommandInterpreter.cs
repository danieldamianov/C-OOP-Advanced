using Problem_1_Logger.Appenders.Contracts;
using Problem_1_Logger.Appenders.Factories;
using Problem_1_Logger.Core.Contracts;
using Problem_1_Logger.Layouts.Contracts;
using Problem_1_Logger.Layouts.Factories;
using Problem_1_Logger.Loggers;
using Problem_1_Logger.Loggers.Contracts;
using Problem_1_Logger.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_1_Logger.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        IList<IAppender> appenders;
        IList<ILogger> loggers;
        ILayoutFactory layoutFactory;
        IAppenderFactory appenderFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.loggers = new List<ILogger>();
            this.layoutFactory = new LayoutFactory();
            this.appenderFactory = new AppenderFactory();
        }

        public void InitializeLoggers()
        {
            for (int i = 0; i < this.appenders.Count; i++)
            {
                loggers.Add(new Logger(appenders[i]));
            }
        }

        public void AddAppender(string[] args)
        {
            string appenderType = args[0];
            string layoutType = args[1];
            ILayout layout = layoutFactory.CreateLayout(layoutType);
            IAppender appender = appenderFactory.CreateAppender(appenderType,layout);
            if (args.Length == 3)
            {
                appender.ReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), args[2], true);
            }
            appenders.Add(appender);
        }

        public void AppendMessage(string[] args)
        {
            string reportLevel = args[0];
            string time = args[1];
            string message = args[2];
            foreach (var logger in loggers)
            {
                switch (reportLevel)
                {
                    case "INFO":
                        logger.Info(time, message);
                        break;
                    case "WARNING":
                        logger.Warning(time, message);
                        break;
                    case "ERROR":
                        logger.Error(time, message);
                        break;
                    case "CRITICAL":
                        logger.Critical(time, message);
                        break;
                    case "FATAL":
                        logger.Fatal(time, message);
                        break;
                }
            }
        }

        public void PrintInfo()
        {
            foreach (var logger in loggers)
            {
                Console.WriteLine(logger);
            }
        }
    }
}
