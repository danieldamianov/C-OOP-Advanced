using Problem_1_Logger.Appenders.Contracts;
using Problem_1_Logger.Layouts.Contracts;
using Problem_1_Logger.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_1_Logger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private readonly ILayout layout;
        public ReportLevel ReportLevel { get; set; }
        private int messagesAppended;

        public ConsoleAppender(ILayout layout)
        {
            messagesAppended = 0;
            this.layout = layout;
            this.ReportLevel = ReportLevel.Info;
        }

        public void Append(string date, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(string.Format(this.layout.Format, date, reportLevel.ToString().ToUpper(), message));
                this.messagesAppended++;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(
                $"Appender type: {this.GetType().Name}, " +
                $"Layout type: {this.layout.GetType().Name}, " +
                $"Report level: {this.ReportLevel.ToString().ToUpper()}, " +
                $"Messages appended: {this.messagesAppended}, ");
            return stringBuilder.ToString().Trim();
        }
    }
}
