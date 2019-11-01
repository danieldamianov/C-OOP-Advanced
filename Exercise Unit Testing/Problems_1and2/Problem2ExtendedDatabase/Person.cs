using System;
using System.Collections.Generic;
using System.Text;

namespace Problem2ExtendedDatabase
{
    public class Person
    {
        public Person(long id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public long Id { get; set; }

        public string Name { get; set; }
    }
}
        