namespace Heroes
{
    using Heroes.ObserverDesignPattern;
    using System;
    using System.Collections.Generic;

    public class Dragon : ISubjectTargetable
    {
        private const string THIS_DIED_EVENT = "{0} dies";

        private string id;
        private int hp;
        private int reward;
        private bool eventTriggered;
        private IHandler logger;
        private List<IObserver> observers;

        public Dragon(string id, int hp, int reward, IHandler logger)
        {
            this.id = id;
            this.hp = hp;
            this.reward = reward;
            this.logger = logger;
            observers = new List<IObserver>();
        }

        public bool IsDead
        {
            get => this.hp <= 0;
        }

        public void AddObserver(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.NotifyAboutDead(this.reward);
            }
        }

        public void ReceiveDamage(int damage)
        {
            if (!this.IsDead)
            {
                this.hp -= damage;
            }

            if (this.IsDead && !eventTriggered)
            {
                this.logger.Handle(LogType.EVENT, string.Format(THIS_DIED_EVENT, this));
                this.NotifyObservers();
                //Console.WriteLine(THIS_DIED_EVENT, this);
                this.eventTriggered = true;
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public override string ToString()
        {
            return this.id;
        }
    }
}
