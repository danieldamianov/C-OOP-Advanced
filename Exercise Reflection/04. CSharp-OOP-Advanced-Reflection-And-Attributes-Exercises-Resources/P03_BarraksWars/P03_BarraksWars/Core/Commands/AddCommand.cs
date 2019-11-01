using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;
using P03_BarraksWars.Models.Units;

namespace _03BarracksFactory.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IRepository Repository
        {
            get
            {
                return this.repository;
            }
            private set
            {
                this.repository = value;
            }
        }
        public IUnitFactory UnitFactory
        {
            get
            {
                return this.unitFactory;
            }
            private set
            {
                this.unitFactory = value;
            }
        }

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
