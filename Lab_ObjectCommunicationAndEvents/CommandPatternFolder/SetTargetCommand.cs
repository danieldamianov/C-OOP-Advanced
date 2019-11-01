using Heroes.ObserverDesignPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.CommandPatternFolder
{
    public class SetTargetCommand : ICommand
    {
        IAttacker attacker;
        ISubjectTargetable target;

        public SetTargetCommand(IAttacker attacker, ISubjectTargetable target)
        {
            this.attacker = attacker;
            this.target = target;
        }

        public void Execute()
        {
            this.attacker.SetTarget(target);
        }
    }
}
