using Heroes.MediatorPatternFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.CommandPatternFolder
{
    public class AttackGroupAttackCommand : ICommand
    {
        private readonly IAttackGroup attackGroup;

        public AttackGroupAttackCommand(IAttackGroup attackGroup)
        {
            this.attackGroup = attackGroup;
        }

        public void Execute()
        {
            attackGroup.GroupAttack();
        }
    }
}
