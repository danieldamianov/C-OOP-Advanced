using Problem_1_Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_1_Logger.Appenders.Contracts
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
