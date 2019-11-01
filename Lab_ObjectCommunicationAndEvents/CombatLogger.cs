using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class CombatLogger : AbstractLogger
    {
        public override void Handle(LogType logType, string message)
        {
            switch (logType)
            {
                case LogType.ATTACK:
                    Console.WriteLine($"Combat! {logType.ToString()}: {message}");
                    break;
                case LogType.MAGIC:
                    Console.WriteLine($"Combat! {logType.ToString()}: {message}");
                    break;
                default:
                    this.PassToSuccessor(logType, message);
                    break;
            }
        }
    }
}
