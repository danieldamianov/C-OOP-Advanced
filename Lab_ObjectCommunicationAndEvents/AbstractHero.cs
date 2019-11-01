namespace Heroes
{
    using Heroes.ObserverDesignPattern;
    using System;

    public abstract class AbstractHero : IAttacker , IObserver
    {
        private const string TARGET_NULL_MESSAGE = "Target is null.";
        private const string NO_TARGET_MESSAGE = "{0} has no target.";
        private const string TARGET_DEAD_MESSAGE = "{0} is dead.";
        private const string SET_TARGET_MESSAGE = "{0} targets {1}.";

        private string id;
        private int damage;
        private int fortune;
        private ISubjectTargetable target;
        protected IHandler logger;

        protected AbstractHero(string id, int damage, IHandler logger)
        {
            this.id = id;
            this.damage = damage;
            this.logger = logger;
            this.fortune = 0;
        }

        public int Fortune => this.fortune;

        public void Attack()
        {
            if (this.target == null)
            {
                logger.Handle(LogType.ERROR, string.Format(NO_TARGET_MESSAGE, this));
                //Console.WriteLine(NO_TARGET_MESSAGE, this);
            }
            else if (this.target.IsDead)
            {
                logger.Handle(LogType.ERROR, string.Format(TARGET_DEAD_MESSAGE, this.target));
                //Console.WriteLine(TARGET_DEAD_MESSAGE, this.target);
            }
            else
            {
                this.target.AddObserver(this);
                this.ExecuteClassSpecificAttack(this.target, this.damage);
            }
        }

        public void SetTarget(ISubjectTargetable target)
        {
            if (target == null)
            {
                logger.Handle(LogType.ERROR, TARGET_NULL_MESSAGE);
                //Console.WriteLine(TARGET_NULL_MESSAGE);
            }
            else
            {
                this.target = target;
                logger.Handle(LogType.TARGET, string.Format(SET_TARGET_MESSAGE, this,target));
                //Console.WriteLine(SET_TARGET_MESSAGE, this, target);
            }
        }

        protected abstract void ExecuteClassSpecificAttack(ITarget target, int damage);

        public override string ToString()
        {
            return this.id;
        }

        public void NotifyAboutDead(int reward)
        {
            this.fortune += reward;
        }
    }
}
