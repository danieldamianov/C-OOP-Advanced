using P07_InfernoInfinity.Models.Contracts;
using P07_InfernoInfinity.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int minDamage;
        private int maxDamage;
        private IGem[] gems;
        private Rarity rarity;

        private int strength;
        private int agility;
        private int vitality;

        private Weapon()
        {
            this.strength = 0;
            this.agility = 0;
            this.vitality = 0;
        }

        protected Weapon(string name, int minDamage, int maxDamage, int socketsNumber, string rarity) : this()
        {
            this.Name = name;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.gems = new IGem[socketsNumber];
            this.rarity = Enum.Parse<Rarity>(rarity, false);
            this.ChangeStatsDependingOnRarity();
        }

        private void ChangeStatsDependingOnRarity()
        {
            this.MaxDamage *= (int)this.rarity;
            this.MinDamage *= (int)this.rarity;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                name = value;
            }

        }
        public int MinDamage
        {
            get
            {
                var minDamageReturn = this.minDamage;
                minDamageReturn += (this.strength * 2);
                minDamageReturn += (this.agility);
                return minDamageReturn;
            }
            private set
            {
                this.minDamage = value;
            }
        }
        public int MaxDamage
        {
            get
            {
                var maxDamageReturn = this.maxDamage;
                maxDamageReturn += (this.strength * 3);
                maxDamageReturn += (this.agility * 4);
                return maxDamageReturn;
            }
            private set
            {
                this.maxDamage = value;
            }
        }

        public void AddGem(int index, IGem gem)
        {
            if (index < 0 || index >= this.gems.Length)
            {
                return;
            }
            if (this.gems[index] != null)
            {
                this.strength -= this.gems[index].GemStrengthIncreasement;
                this.agility -= this.gems[index].GemAgilityIncreasement;
                this.vitality -= this.gems[index].GemVitalityIncreasement;
            }
            this.gems[index] = gem;

            this.strength += gem.GemStrengthIncreasement;
            this.agility += gem.GemAgilityIncreasement;
            this.vitality += gem.GemVitalityIncreasement;
        }

        public void RemoveGem(int index)
        {
            if (index < 0 || index >= this.gems.Length || this.gems[index] == null)
            {
                return;
            }
            IGem gem = this.gems[index];
            this.gems[index] = null;
            this.strength -= gem.GemStrengthIncreasement;
            this.agility -= gem.GemAgilityIncreasement;
            this.vitality -= gem.GemVitalityIncreasement;
        }

        public override string ToString()
        {
            return $"{this.name}: {this.MinDamage}-{this.MaxDamage} Damage," +
                $" +{this.strength} Strength, +{this.agility} Agility, +{this.vitality} Vitality";
        }
    }
}
