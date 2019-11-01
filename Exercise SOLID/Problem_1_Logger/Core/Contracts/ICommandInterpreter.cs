using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_1_Logger.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] args);

        void AppendMessage(string[] args);

        void InitializeLoggers();

        void PrintInfo();
    }
}
