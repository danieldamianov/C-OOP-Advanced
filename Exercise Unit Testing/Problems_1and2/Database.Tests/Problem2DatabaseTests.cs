using NUnit.Framework;
using Problem2ExtendedDatabase;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseTests
{
    [TestFixture]
    public class Problem2DatabaseTests
    {
        private ExtendedDatabase extendedDatabase;

        [SetUp]
        public void SetUp()
        {
            extendedDatabase = new ExtendedDatabase();
        }

        [Test]
        public void TestAddCommand()
        {
            extendedDatabase.Add(new Person(123, "Dani"));
            extendedDatabase.Add(new Person(1234, "Liya"));

            Assert.AreEqual(2, extendedDatabase.People.Count);
            Assert.AreEqual(123, extendedDatabase.FindPersonByName("Dani").Id);
        }

        [Test]
        public void TestIfAddCommandThrowsExceptionForDuplicatingName()
        {
            extendedDatabase.Add(new Person(1234, "Dani"));
            Assert.That
                (() => extendedDatabase.Add(new Person(1, "Dani")), Throws.InvalidOperationException.With.Message
                .EqualTo("Already person with that name in collection!"));
        }

        [Test]
        public void TestIfAddCommandThrowsExceptionForDuplicatingId()
        {
            extendedDatabase.Add(new Person(1234, "Dani"));
            Assert.That
                (() => extendedDatabase.Add(new Person(1234, "Liya")), Throws.InvalidOperationException.With.Message
                .EqualTo("Already person with that id in collection!"));
        }

        [Test]
        public void TestRemoveByNameCommandAndIfFindByNameCommandThrowsExceptionIfTheNameDoesNotExists()
        {
            extendedDatabase.Add(new Person(123, "Dani"));
            extendedDatabase.Add(new Person(1234, "Liya"));
            extendedDatabase.Add(new Person(12345, "Federica"));

            extendedDatabase.RemoveByName("Liya");

            Assert.AreEqual(2, extendedDatabase.People.Count);
            Assert.That(() => extendedDatabase.FindPersonByName("Liya"), Throws.InvalidOperationException
                .With.Message.EqualTo("No people with that name in collection!"));
        }

        [Test]
        public void TestRemoveByIdCommandAndIfFindByIdCommandThrowsExceptionIfTheIdDoesNotExists()
        {
            extendedDatabase.Add(new Person(123, "Dani"));
            extendedDatabase.Add(new Person(1234, "Liya"));
            extendedDatabase.Add(new Person(12345, "Federica"));

            extendedDatabase.RemoveById(123);

            Assert.AreEqual(2, extendedDatabase.People.Count);
            Assert.That(() => extendedDatabase.FindPersonById(123), Throws.InvalidOperationException
                .With.Message.EqualTo("No people with that id in collection!"));
        }

        [Test]
        public void TestIfFindByNameThrowsArgumentNullExceptionIfNameIsNull()
        {
            Assert.That(() => extendedDatabase.FindPersonByName(null),Throws.ArgumentNullException.With.Message
                .EqualTo(new ArgumentOutOfRangeException("Name","Name cannot be null!").Message));
        }

        [Test]
        public void TestIfFindByIdThrowsArgumentOutOfRangeExceptionIfIdIsNegativeOrZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDatabase.FindPersonById(-4));
        }
    }
}
