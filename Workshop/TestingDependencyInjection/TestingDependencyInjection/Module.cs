using CustomDependencyInjection.Modules;
using CustomDependencyInjection.Modules.Contracts;
using TestingDependencyInjection.Contracts;
using TestingDependencyInjection.Models;

namespace TestingDependencyInjection
{
    internal class Module : AbstractModule
    {
        public override void Configure()
        {
            this.CreateMapping<IReader, ConsoleReader>();
            this.CreateMapping<IWriter, ConsoleWriter>();
            this.CreateMapping<IWriter, FileWriter>();
        }
    }
}