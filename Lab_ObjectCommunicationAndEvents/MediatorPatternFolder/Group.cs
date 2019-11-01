using Heroes.ObserverDesignPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.MediatorPatternFolder
{
    public class Group : IAttackGroup
    {
        private List<IAttacker> members;

        public Group()
        {
            this.members = new List<IAttacker>();
        }

        public void AddMember(IAttacker attacker)
        {
            this.members.Add(attacker);
        }

        public void GroupAttack()
        {
            foreach (var member in members)
            {
                member.Attack();
            }
        }

        public void SetGroupTarget(ISubjectTargetable target)
        {
            foreach (var member in members)
            {
                member.SetTarget(target);
            }
        }
    }
}
