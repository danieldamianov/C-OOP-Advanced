namespace Heroes
{
    using Heroes.CommandPatternFolder;
    using Heroes.MediatorPatternFolder;
    using Heroes.ObserverDesignPattern;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            AbstractLogger combatLogger = new CombatLogger();
            AbstractLogger eventLoggger = new EventLogger();
            combatLogger.SetSuccessor(eventLoggger);

            IAttacker warrior = new Warrior("dani", 10, combatLogger);
            IAttacker warrior2 = new Warrior("dani2", 10, combatLogger);
            IAttacker warrior3 = new Warrior("dani3", 10, combatLogger);
            ISubjectTargetable target = new Dragon("federica", 20, 1000, combatLogger);

            IExecutor executor = new CommandExecutor();
            
            IAttackGroup group = new Group();
            group.AddMember(warrior);
            group.AddMember(warrior2);
            group.AddMember(warrior3);

            ICommand setTargetOfAttackGroup = new SetTargetOfAttackGroup(group, target);
            ICommand attackCommand = new AttackGroupAttackCommand(group);

            executor.ExecuteCommand(setTargetOfAttackGroup);

            executor.ExecuteCommand(attackCommand);
            executor.ExecuteCommand(attackCommand);

            Console.WriteLine("Warrior fortune : " + warrior.Fortune);
            Console.WriteLine("Warrior fortune2 : " + warrior2.Fortune);
            Console.WriteLine("Warrior fortune3 : " + warrior3.Fortune);

        }
    }
}
