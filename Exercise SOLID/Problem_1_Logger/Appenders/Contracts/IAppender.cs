using Problem_1_Logger.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_1_Logger.Appenders.Contracts
{
    public interface IAppender
    {
        void Append(string date, ReportLevel reportLevel, string message);

        ReportLevel ReportLevel { get; set; }
    }
}
