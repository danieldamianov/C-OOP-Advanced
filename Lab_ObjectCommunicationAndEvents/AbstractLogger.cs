using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public abstract class AbstractLogger : IHandler
    {
        private IHandler successor;

        public abstract void Handle(LogType logType, string message);

        public void SetSuccessor(IHandler handler)
        {
            this.successor = handler;
        }

        protected void PassToSuccessor(LogType logType, string message)
        {
            if (this.successor != null)
            {
                successor.Handle(logType, message);
            }
        }
    }
}
