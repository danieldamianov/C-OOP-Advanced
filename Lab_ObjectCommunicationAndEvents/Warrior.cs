namespace Heroes
{
    using System;

    public class Warrior : AbstractHero
    {
        private const string ATTACK_MESSAGE = "{0} damages {1} for {2}";

        public Warrior(string id, int damage, IHandler logger) : base(id, damage,logger)
        {
        }

        protected override void ExecuteClassSpecificAttack(ITarget target, int damage)
        {
            this.logger.Handle(LogType.ATTACK, string.Format(ATTACK_MESSAGE, this, target, damage));
            target.ReceiveDamage(damage);
            //Console.WriteLine(ATTACK_MESSAGE, this, target, damage);
        }
    }
}
