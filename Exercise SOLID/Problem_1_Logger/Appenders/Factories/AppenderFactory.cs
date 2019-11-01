using Problem_1_Logger.Appenders.Contracts;
using Problem_1_Logger.Layouts.Contracts;
using Problem_1_Logger.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_1_Logger.Appenders.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            switch (type)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout);
                case "FileAppender":
                    return new FileAppender(layout, new LogFile());
                default: throw new ArgumentException("InvalidAppenderType");
            }
        }
    }
}
