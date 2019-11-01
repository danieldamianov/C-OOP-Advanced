using Problem_1_Logger.Appenders;
using Problem_1_Logger.Appenders.Contracts;
using Problem_1_Logger.Loggers.Contracts;
using Problem_1_Logger.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_1_Logger.Loggers
{
    public class Logger : ILogger
    {
        private readonly IAppender appender;

        public Logger(IAppender appender)
        {
            this.appender = appender;
        }

        public void Critical(string date, string message)
        {
            this.AppendMessage(date, ReportLevel.Critical, message);
        }

        public void Warning(string date, string message)
        {
            this.AppendMessage(date, ReportLevel.Warning, message);
        }

        public void Fatal(string date, string message)
        {
            this.AppendMessage(date, ReportLevel.Fatal, message);
        }

        public void Error(string date, string message)
        {
            this.AppendMessage(date, ReportLevel.Error, message);
        }

        public void Info(string date, string message)
        {
            this.AppendMessage(date, ReportLevel.Info, message);
        }

        private void AppendMessage(string date, ReportLevel reportLevel, string message)
        {
            this.appender.Append(date, reportLevel, message);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Logger info");
            stringBuilder.AppendLine(this.appender.ToString());
            return stringBuilder.ToString().Trim();
        }
    }
}
