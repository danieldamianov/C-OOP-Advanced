using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace DynamicListTests
{
    [TestFixture]
    public class LinkedListTests
    {
        static Assembly assembly = Assembly.LoadFile(@"D:\външна памет\Dani's docs\C#\C# OOP Advanced\Exercise Unit Testing\CustomLinkedList\CustomLinkedList\obj\Debug\netcoreapp2.0\CustomLinkedList.dll");
        static Type typeOfDynamicList = assembly.GetTypes().First(t => t.Name == "DynamicList`1");
        static Type[] parameters = new Type[] { typeof(string) };
        static Type typeOfDynamicListWithStrings = typeOfDynamicList.MakeGenericType(parameters);
        object DynamicListWithStrings;

        [SetUp]
        public void SetUpAssembly()
        {
            DynamicListWithStrings = Activator.CreateInstance(typeOfDynamicListWithStrings);
        }

        [Test]
        public void TestConstrictor()
        {
            int count = (int)typeOfDynamicListWithStrings.GetProperty("Count").GetValue(DynamicListWithStrings);
            Assert.AreEqual(0, count);
        }

        [Test]
        public void TestAddCommand()
        {
            MethodInfo addMethodInfo = typeOfDynamicListWithStrings.GetMethod("Add");
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "string1" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "string2" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "string3" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "string4" });

            Assert.AreEqual(4, typeOfDynamicListWithStrings.GetProperty("Count").GetValue(DynamicListWithStrings));
        }

        [Test]
        [TestCase(new string[] { "string1", "stirng2", "stirng3", "string4", "string5", "string6" }, 4)]
        [TestCase(new string[] { "string1", "stirng2", "stirng3", "string4", "string5", "string6" }, 0)]
        [TestCase(new string[] { "string1", "stirng2", "stirng3", "string4", "string5", "string6" }, 2)]
        [TestCase(new string[] { "string1", "stirng2", "stirng3", "string4", "string5", "string6" }, 5)]
        public void TestIfIndexerReturnsCorrectResults(string[] valuesToAdd, int indexToSearch)
        {
            MethodInfo addMethodInfo = typeOfDynamicListWithStrings.GetMethod("Add");
            foreach (var value in valuesToAdd)
            {
                addMethodInfo.Invoke(DynamicListWithStrings, new object[] { value });
            }
            MethodInfo indexerGetMethodInfo = typeOfDynamicListWithStrings.GetMethod("get_Item");
            string valueFromTheList = (string)indexerGetMethodInfo.Invoke(DynamicListWithStrings, new object[] { indexToSearch });
            Assert.AreEqual(valueFromTheList, valuesToAdd[indexToSearch]);
        }

        [Test]
        public void TestIfIdexerGetterThrowsArgumentOutOfRangeExceptionWhenInvalidIndexIsPassed()
        {
            MethodInfo addMethodInfo = typeOfDynamicListWithStrings.GetMethod("Add");

            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test" });

            MethodInfo indexerGetMethodInfo = typeOfDynamicListWithStrings.GetMethod("get_Item");

            Assert.That(() => indexerGetMethodInfo.Invoke(DynamicListWithStrings, new object[] { 1 }),
                Throws.TargetInvocationException.With.InnerException.InstanceOf(typeof(ArgumentOutOfRangeException)));

            Assert.That(() => indexerGetMethodInfo.Invoke(DynamicListWithStrings, new object[] { -1 }),
                Throws.TargetInvocationException.With.InnerException.InstanceOf(typeof(ArgumentOutOfRangeException)));
        }

        [Test]
        [TestCase(new string[] { "string1", "stirng2", "stirng3", "string4", "string5", "string6" }, 4)]
        [TestCase(new string[] { "string1", "stirng2", "stirng3", "string4", "string5", "string6" }, 0)]
        [TestCase(new string[] { "string1", "stirng2", "stirng3", "string4", "string5", "string6" }, 2)]
        [TestCase(new string[] { "string1", "stirng2", "stirng3", "string4", "string5", "string6" }, 5)]
        public void TestIfIndexerSetsCorrectResults(string[] valuesToAdd, int indexToSetValue)
        {
            MethodInfo addMethodInfo = typeOfDynamicListWithStrings.GetMethod("Add");
            foreach (var value in valuesToAdd)
            {
                addMethodInfo.Invoke(DynamicListWithStrings, new object[] { value });
            }
            MethodInfo indexerGetMethodInfo = typeOfDynamicListWithStrings.GetMethod("get_Item");
            MethodInfo indexerSetMethodInfo = typeOfDynamicListWithStrings.GetMethod("set_Item");
            indexerSetMethodInfo.Invoke(DynamicListWithStrings, new object[] { indexToSetValue, "FEDERICA" });
            Assert.AreEqual(indexerGetMethodInfo.Invoke(DynamicListWithStrings, new object[] { indexToSetValue }),
                "FEDERICA");
        }

        [Test]
        public void TestIfIdexerSetterThrowsArgumentOutOfRangeExceptionWhenInvalidIndexIsPassed()
        {
            MethodInfo addMethodInfo = typeOfDynamicListWithStrings.GetMethod("Add");

            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test" });

            MethodInfo indexerSetMethodInfo = typeOfDynamicListWithStrings.GetMethod("set_Item");

            Assert.That(() => indexerSetMethodInfo.Invoke(DynamicListWithStrings, new object[] { 1, "test" }),
                Throws.TargetInvocationException.With.InnerException.InstanceOf(typeof(ArgumentOutOfRangeException)));

            Assert.That(() => indexerSetMethodInfo.Invoke(DynamicListWithStrings, new object[] { -1, "test" }),
                Throws.TargetInvocationException.With.InnerException.InstanceOf(typeof(ArgumentOutOfRangeException)));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void TestRemoveAtNotTheTailMethod(int indexToRemoveAt)
        {
            MethodInfo addMethodInfo = typeOfDynamicListWithStrings.GetMethod("Add");
            MethodInfo removeAtMethodInfo = typeOfDynamicListWithStrings.GetMethod("RemoveAt");
            MethodInfo getIndexerMethodInfo = typeOfDynamicListWithStrings.GetMethod("get_Item");

            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test0" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test1" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test2" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test3" });
            removeAtMethodInfo.Invoke(DynamicListWithStrings, new object[] { indexToRemoveAt });

            string expectedValue = "test" + (indexToRemoveAt + 1);
            string actualValue = (string)getIndexerMethodInfo.
                Invoke(DynamicListWithStrings, new object[] { indexToRemoveAt });

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TestRemoveAtTheTailMethod()
        {
            MethodInfo addMethodInfo = typeOfDynamicListWithStrings.GetMethod("Add");
            MethodInfo removeAtMethodInfo = typeOfDynamicListWithStrings.GetMethod("RemoveAt");
            MethodInfo getIndexerMethodInfo = typeOfDynamicListWithStrings.GetMethod("get_Item");

            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test0" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test1" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test2" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test3" });
            removeAtMethodInfo.Invoke(DynamicListWithStrings, new object[] { 3 });


            Assert.That(() => getIndexerMethodInfo.Invoke(DynamicListWithStrings, new object[] { 3 }),
                Throws.TargetInvocationException.With.InnerException.InstanceOf(typeof(ArgumentOutOfRangeException)));

            string expectedValue = "test2";
            string actualValue = (string)getIndexerMethodInfo.
                Invoke(DynamicListWithStrings, new object[] { 2 });

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TestIfRemoveAtMethodThrowsArgumentAoutOfRangeExceptions()
        {
            MethodInfo removeAtMethodInfo = typeOfDynamicListWithStrings.GetMethod("RemoveAt");

            Assert.That(() => removeAtMethodInfo.Invoke(DynamicListWithStrings, new object[] { 3 }),
                Throws.TargetInvocationException.With.InnerException.InstanceOf(typeof(ArgumentOutOfRangeException)));

            Assert.That(() => removeAtMethodInfo.Invoke(DynamicListWithStrings, new object[] { -2343 }),
                Throws.TargetInvocationException.With.InnerException.InstanceOf(typeof(ArgumentOutOfRangeException)));
        }

        [Test]
        public void TestRemoveMethod()
        {
            MethodInfo removeMethodInfo = typeOfDynamicListWithStrings.GetMethod("Remove");
            MethodInfo addMethodInfo = typeOfDynamicListWithStrings.GetMethod("Add");

            PropertyInfo countPropertyInfo = typeOfDynamicListWithStrings.GetProperty("Count");

            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test0" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test1" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test2" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test3" });
            //should return 2 !
            int indexOfRemoveElement = (int)removeMethodInfo
                .Invoke(DynamicListWithStrings, new object[] { "test2" });

            int indexOfUnexistingElementToRemove = (int)removeMethodInfo
                .Invoke(DynamicListWithStrings, new object[] { "usexistingString" });

            Assert.AreEqual(3, (int)countPropertyInfo.GetValue(DynamicListWithStrings));
            Assert.AreEqual(2, indexOfRemoveElement);
            Assert.AreEqual(-1, indexOfUnexistingElementToRemove);
        }

        [Test]
        public void TestContainsMethod()
        {
            MethodInfo addMethodInfo = typeOfDynamicListWithStrings.GetMethod("Add");
            MethodInfo containsMethodInfo = typeOfDynamicListWithStrings.GetMethod("Contains");

            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test0" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test1" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test2" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test3" });

            bool notContains = (bool)containsMethodInfo.Invoke(DynamicListWithStrings, new object[] { "unexString" });
            bool Contains = (bool)containsMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test0" });

            Assert.That(notContains == false);
            Assert.That(Contains == true);
        }
        
        [Test]
        public void TestIndexOfMethod()
        {
            MethodInfo addMethodInfo = typeOfDynamicListWithStrings.GetMethod("Add");
            MethodInfo indexOfMethodInfo = typeOfDynamicListWithStrings.GetMethod("IndexOf");

            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test0" });
            addMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test1" });

            int index = (int)indexOfMethodInfo.Invoke(DynamicListWithStrings, new object[] { "test1" });

            Assert.AreEqual(1, index);
        }
    }
}
