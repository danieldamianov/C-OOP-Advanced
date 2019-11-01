using System;
using System.Collections.Generic;
using System.Text;

namespace P08_CreateCustomClassAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    class CustomClassAttribute : Attribute
    {
        public CustomClassAttribute(string author, int revision, string description, string[] reviewers)
        {
            Author = author;
            Revision = revision;
            Description = description;
            Reviewers = reviewers;
        }

        public string Author { get; set; }

        public int Revision { get; set; }

        public string Description { get; set; }

        public string[] Reviewers { get; set; }

        public void PrintAuthor()
        {
            Console.WriteLine($"Author: {this.Author}");
        }

        public void PrintRevision()
        {
            Console.WriteLine($"Revision: {this.Revision}");
        }

        public void PrintDescription()
        {
            Console.WriteLine($"Class description: {this.Description}");
        }

        public void PrintReviewers()
        {
            Console.WriteLine($"Reviewers: {string.Join(", ",this.Reviewers)}");
        }
    }
}
