using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class EventLogger : AbstractLogger
    {
        public override void Handle(LogType logType, string message)
        {
            switch (logType)
            {
                case LogType.ERROR:
                    Console.WriteLine($"Event! {logType.ToString()}: {message}");
                    break;
                case LogType.EVENT:
                    Console.WriteLine($"Event! {logType.ToString()}: {message}");
                    break;
                case LogType.TARGET:
                    Console.WriteLine($"Event! {logType.ToString()}: {message}");
                    break;
                default:
                    this.PassToSuccessor(logType, message);
                    break;
            }
        }
    }
}
