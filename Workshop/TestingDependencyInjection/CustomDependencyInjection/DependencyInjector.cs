using CustomDependencyInjection.Injectors;
using CustomDependencyInjection.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDependencyInjection
{
    public class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
