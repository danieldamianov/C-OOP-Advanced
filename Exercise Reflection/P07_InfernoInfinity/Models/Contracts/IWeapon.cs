using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Contracts
{
    public interface IWeapon
    {
        string Name { get; }
        int MinDamage { get; }
        int MaxDamage { get; }

        void AddGem(int index, IGem gem);
        void RemoveGem(int index);
    }
}
