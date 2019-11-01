using CustomDependencyInjection;
using CustomDependencyInjection.Injectors;
using Microsoft.Extensions.DependencyInjection;
using System;
using TestingDependencyInjection.Contracts;
using TestingDependencyInjection.Models;

namespace TestingDependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            //IServiceProvider serviceCollection = ConfigureServices();
            //IEngine engine = serviceCollection.GetService<IEngine>();
            //engine.Run();

            Injector injector = DependencyInjector.CreateInjector(new Module());
            Engine engine = injector.Inject<Engine>();
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IReader, ConsoleReader>();
            serviceCollection.AddTransient<IWriter, FileWriter>();
            serviceCollection.AddTransient<IWriter, ConsoleWriter>();
            serviceCollection.AddTransient<IEngine, Engine>();
           
            return serviceCollection.BuildServiceProvider();
        }
    }
}
