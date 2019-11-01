using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDependencyInjection.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field)]
    public class NamedAttribute : Attribute
    {
        public NamedAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        
    }
}
