using Heroes.MediatorPatternFolder;
using Heroes.ObserverDesignPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.CommandPatternFolder
{
    public class SetTargetOfAttackGroup : ICommand
    {
        private readonly IAttackGroup attackGroup;
        private readonly ISubjectTargetable target;

        public SetTargetOfAttackGroup(IAttackGroup attackGroup, ISubjectTargetable target)
        {
            this.attackGroup = attackGroup;
            this.target = target;
        }

        public void Execute()
        {
            this.attackGroup.SetGroupTarget(target);
        }
    }
}
