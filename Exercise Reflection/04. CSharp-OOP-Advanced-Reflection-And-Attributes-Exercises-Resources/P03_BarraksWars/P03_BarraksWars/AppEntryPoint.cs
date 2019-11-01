namespace _03BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    //using Microsoft.Extensions.DependencyInjection;
    using P03_BarraksWars.Core;
    using System;

    public class AppEntryPoint
    {
        public static void Main(string[] args)
        {
            //IServiceProvider serviceProvider = ConfigureServices();
            Provider provider = new Provider(new UnitRepository(), new UnitFactory());
            IRunnable engine = new Engine(provider);
            engine.Run();
            
        }

        //public static IServiceProvider ConfigureServices()
        //{
        //    IServiceCollection services = new ServiceCollection();

        //    services.AddTransient<IUnitFactory,UnitFactory>();
        //    services.AddSingleton<IRepository, UnitRepository>();

        //    IServiceProvider serviceProvider = services.BuildServiceProvider();

        //    return serviceProvider;
        //}
    }
}
