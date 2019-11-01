using Problem_1_Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_1_Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        public XmlLayout()
        {
            this.Format = "<log>" + Environment.NewLine +
                          "    <date>{0}</date>" + Environment.NewLine +
                          "    <level>{1}</level>" + Environment.NewLine +
                          "    <message>{2}</message>" + Environment.NewLine +
                          "</log>";
        }

        public string Format { get; }
    }
}
