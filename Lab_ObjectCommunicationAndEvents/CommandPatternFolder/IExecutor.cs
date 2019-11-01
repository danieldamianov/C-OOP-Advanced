using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.CommandPatternFolder
{
    public interface IExecutor
    {
        void ExecuteCommand(ICommand command);
    }
}
