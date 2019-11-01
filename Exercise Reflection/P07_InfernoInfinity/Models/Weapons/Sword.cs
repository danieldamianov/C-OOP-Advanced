using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        public Sword(string name, string rarity) : base(name, 4, 6, 3, rarity)
        { }

    }
}
