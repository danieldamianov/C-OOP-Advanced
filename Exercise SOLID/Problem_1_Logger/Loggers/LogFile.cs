using Problem_1_Logger.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1_Logger.Loggers
{
    public class LogFile : ILogFile
    {
        public LogFile()
        {
            this.Size = 0;
        }

        public int Size { get; private set; }

        public void Write(string message)
        {
            this.Size += message.Where(ch => char.IsLetter(ch)).Sum(ch => ch);
        }
    }
}
