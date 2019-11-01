using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        public Knife(string name, string rarity) : base(name, 3, 4, 2, rarity)
        { }
    }
}
