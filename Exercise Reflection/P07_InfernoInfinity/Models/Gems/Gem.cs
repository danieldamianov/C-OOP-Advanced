using P07_InfernoInfinity.Models.Contracts;
using P07_InfernoInfinity.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Gems
{
    public abstract class Gem : IGem
    {
        private GemClarity gemClarity;

        private int strength;
        private int agility;
        private int vitality;

        protected Gem(string gemClarity, int strength, int agility, int vitality)
        {
            this.gemClarity = Enum.Parse<GemClarity>(gemClarity,false);
            this.strength = strength;
            this.agility = agility;
            this.vitality = vitality;
            this.IncreaseStatsDependingOnGemClarity();
        }

        private void IncreaseStatsDependingOnGemClarity()
        {
            this.strength += (int)this.gemClarity;
            this.agility += (int)this.gemClarity;
            this.vitality += (int)this.gemClarity;
        }

        public int GemStrengthIncreasement => this.strength;
        public int GemAgilityIncreasement => this.agility;
        public int GemVitalityIncreasement => this.vitality;
    }
}
