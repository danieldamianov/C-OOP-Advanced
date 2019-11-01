using Heroes.ObserverDesignPattern;

namespace Heroes
{
    public interface IAttacker
    {
        void Attack();

        void SetTarget(ISubjectTargetable target);

        int Fortune { get; }
    }
}