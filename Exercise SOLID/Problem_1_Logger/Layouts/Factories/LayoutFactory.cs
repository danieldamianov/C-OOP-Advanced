using Problem_1_Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_1_Logger.Layouts.Factories
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            if (type == "SimpleLayout")
            {
                return new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                return new XmlLayout();
            }
            throw new ArgumentException("InvalidTypeOfLayout");
        }
    }
}
