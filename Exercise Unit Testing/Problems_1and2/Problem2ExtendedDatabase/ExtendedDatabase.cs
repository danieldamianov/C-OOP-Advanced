using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem2ExtendedDatabase
{
    public class ExtendedDatabase
    {
        List<Person> people;

        public ExtendedDatabase()
        {
            people = new List<Person>();
        }

        public IReadOnlyCollection<Person> People => people.AsReadOnly();

        public void Add(Person person)
        {
            if (people.Any(p => p.Name == person.Name))
            {
                throw new InvalidOperationException("Already person with that name in collection!");
            }
            if (people.Any(p => p.Id == person.Id))
            {
                throw new InvalidOperationException("Already person with that id in collection!");
            }
            this.people.Add(person);
        }

        public void RemoveByName(string name)
        {
            Person person = this.FindPersonByName(name);
            this.people.RemoveAll(p => p.Name == person.Name);
        }

        public void RemoveById(long id)
        {
            Person person = this.FindPersonById(id);
            this.people.RemoveAll(p => p.Id == person.Id);
        }

        public Person FindPersonByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name","Name cannot be null!");
            }
            if (this.people.Any(p => p.Name == name) == false)
            {
                throw new InvalidOperationException("No people with that name in collection!");
            }
            return this.people.Single(p => p.Name == name);
        }

        public Person FindPersonById(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id", "Id cannot be negative or zero!");
            }
            if (this.people.Any(p => p.Id == id) == false)
            {
                throw new InvalidOperationException("No people with that id in collection!");
            }
            return this.people.Single(p => p.Id == id);
        }
        
    }
}
