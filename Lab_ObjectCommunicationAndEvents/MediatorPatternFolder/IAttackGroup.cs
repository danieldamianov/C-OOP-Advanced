using Heroes.ObserverDesignPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.MediatorPatternFolder
{
    public interface IAttackGroup
    {
        void AddMember(IAttacker attacker);

        void SetGroupTarget(ISubjectTargetable target);

        void GroupAttack();
    }
}
