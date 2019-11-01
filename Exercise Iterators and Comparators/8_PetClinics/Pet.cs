using System;
using System.Collections.Generic;
using System.Text;

namespace _8_PetClinics
{
    public class Pet
    {
        private string name;
        private int age;
        private string kind;
        public string Name => this.name;

        public Pet(string name, int age, string kind)
        {
            this.name = name;
            this.age = age;
            this.kind = kind;
        }

        public override string ToString()
        {
            return $"{this.name} {this.age} {this.kind}";
        }
    }
}
