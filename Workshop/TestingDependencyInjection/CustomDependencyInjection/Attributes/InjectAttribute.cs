using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDependencyInjection.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {

    }
    
}
