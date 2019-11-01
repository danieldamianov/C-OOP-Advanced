using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.CommandPatternFolder
{
    public class CommandExecutor : IExecutor
    {
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }
    }
}
