namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            string fullUnitTypeName = $"_03BarracksFactory.Models.Units.{unitType}";

            Type unitTypeVar = Type.GetType(fullUnitTypeName);

            IUnit unit = (IUnit)Activator.CreateInstance(unitTypeVar);

            return unit;
        }
    }
}
