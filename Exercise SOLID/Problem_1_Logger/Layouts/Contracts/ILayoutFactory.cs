using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_1_Logger.Layouts.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
