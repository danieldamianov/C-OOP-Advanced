using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Core
{
    class Provider
    {
        private readonly IRepository repository;
        private readonly IUnitFactory unitFactory;

        public Provider(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public object ReturnInstance(Type interfaceType)
        {
            if (interfaceType == typeof(IUnitFactory))
            {
                return this.unitFactory;
            }
            if (interfaceType == typeof(IRepository))
            {
                return this.repository;
            }
            return null;
        }
    }
}
