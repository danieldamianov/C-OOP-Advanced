using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.ObserverDesignPattern
{
    public interface IObserver
    {
        void NotifyAboutDead(int reward);
    }
}
