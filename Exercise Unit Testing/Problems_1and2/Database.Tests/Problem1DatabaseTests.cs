using NUnit.Framework;
using Problem1Database;
using System;

namespace DatabaseTests
{
    [TestFixture]
    public class Problem1DatabaseTests
    {
        [Test]
        public void TestIfCreatingDatabaseWithInvalidSizeThrowsException()
        {
            Database database;
            Assert.That
                (() => database = new Database(new int[] { 1, 2, 3 }), Throws.InvalidOperationException.With
                .Message.EqualTo("Values count must be 16!"));
        }

        [Test]
        public void TestIfCreatingDatabaseWithValidSizeDoesNotThrowException()
        {
            Database database;
            Assert.DoesNotThrow(() => database = new Database(new int[16] { 1, 3, 4, 7, 8, 9, 0, 3, 4, 5, 600, 5, 6, 4, 5, 6 }));
        }

        [Test]
        public void TestFetchMethod()
        {
            int[] testArray = new int[16];
            testArray[0] = 1;
            testArray[1] = 2;
            testArray[2] = 3;
            testArray[3] = 4;
            Database database = new Database(testArray);
            Assert.AreEqual(4, database.Fetch().Length);
            Assert.AreEqual(1, database.Fetch()[0]);
            Assert.AreEqual(2, database.Fetch()[1]);
            Assert.AreEqual(3, database.Fetch()[2]);
            Assert.AreEqual(4, database.Fetch()[3]);
        }

        [Test]
        public void TestAddCommand()
        {
            int[] testArray = new int[16];
            Database database = new Database(testArray);
            database.Add(1);
            database.Add(2);
            database.Add(3);
            database.Add(4);
            database.Add(5);
            database.Add(6);
            database.Add(7);

            Assert.AreEqual(7, database.Fetch()[6]);
        }

        [Test]
        public void TestAddCommandThrowsExceptionWhenContainerIsFull()
        {
            int[] testArray = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            Database database = new Database(testArray);
            Assert.That
                (() => database.Add(1), Throws.InvalidOperationException.With.Message.EqualTo("Container is full!"));
        }

        [Test]
        public void TestRemoveCommand()
        {
            int[] testArray = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            Database database = new Database(testArray);
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            Assert.AreEqual(8, database.Fetch().Length);
        }

        [Test]
        public void TestIfRemoveCommandThrowsExceptonWhenEmptySequence()
        {
            int[] testArray = new int[16];
            testArray[0] = 100;
            Database database = new Database(testArray);
            database.Remove();
            Assert.That(() => database.Remove(),
                Throws.InvalidOperationException.With.Message.EqualTo("No elements in container!"));
        }

        [Test]
        public void TestVariousAddAndRemoveCases()
        {
            Database database = new Database(new int[16]);
            database.Add(4);
            database.Add(5);
            database.Add(6);
            database.Remove();
            database.Add(106);
            database.Add(107);
            database.Add(108);
            database.Add(109);
            database.Remove();
            database.Remove();

            Assert.AreEqual(4,database.Fetch()[0]);
            Assert.AreEqual(5,database.Fetch()[1]);
            Assert.AreEqual(106,database.Fetch()[2]);
            Assert.AreEqual(107,database.Fetch()[3]);

        }
    }
}
