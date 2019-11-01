using Problem_1_Logger.Appenders.Contracts;
using Problem_1_Logger.Layouts.Contracts;
using Problem_1_Logger.Loggers.Contracts;
using Problem_1_Logger.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Problem_1_Logger.Appenders
{
    public class FileAppender : IAppender
    {
        private const string path = "log.txt";
        private readonly ILayout layout;
        public readonly ILogFile logFile;
        public ReportLevel ReportLevel { get; set; }
        private int messagesAppended;

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.layout = layout;
            this.logFile = logFile;
            this.ReportLevel = ReportLevel.Info;
            this.messagesAppended = 0;
        }

        public void Append(string date, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                string text = string.Format(this.layout.Format, date, reportLevel.ToString().ToUpper(), message);
                File.AppendAllText(path, text + Environment.NewLine);
                this.logFile.Write(text);
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
                $"Messages appended: {this.messagesAppended}, " + 
                $"File size {this.logFile.Size}");
            return stringBuilder.ToString().Trim();
        }
    }
}
