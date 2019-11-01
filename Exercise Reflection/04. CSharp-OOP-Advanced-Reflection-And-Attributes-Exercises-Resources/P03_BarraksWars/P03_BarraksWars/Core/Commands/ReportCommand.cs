using _03BarracksFactory.Contracts;
using P03_BarraksWars.Models.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Core.Commands
{
    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.repository = repository;
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

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
