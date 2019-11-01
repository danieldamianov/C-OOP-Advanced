using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace _5_Comparing_Objects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }
        public int Age { get; }

        public int CompareTo(Person other)
        {
            int firstResult = this.Name.CompareTo(other.Name);
            int secondResult = this.Age.CompareTo(other.Age);

            if (firstResult != 0)
            {
                return firstResult;
            }

            if (secondResult != 0)
            {
                return secondResult;
            }

            return 0;
            
        }

        public override bool Equals(object obj)
        {
            Person person = (Person)obj;
            if ((this.Name == person.Name) && (this.Age == person.Age))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int code = this.Name.Sum(x => x) + this.Age;
            foreach (var letter in this.Name)
            {
                code *= letter;
            }
            return code;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
