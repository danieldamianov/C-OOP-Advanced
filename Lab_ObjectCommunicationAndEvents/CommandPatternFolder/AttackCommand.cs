using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.CommandPatternFolder
{
    public class AttackCommand : ICommand
    {
        private readonly IAttacker attacker;

        public AttackCommand(IAttacker attacker)
        {
            this.attacker = attacker;
        }

        public void Execute()
        {
            this.attacker.Attack();
        }
    }
}
