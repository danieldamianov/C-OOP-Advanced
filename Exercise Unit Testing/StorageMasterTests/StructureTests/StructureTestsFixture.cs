using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StructureTests
{
    [TestFixture]
    public class StructureTestsFixture
    {
        static Assembly assembly = Assembly.LoadFile(@"D:\външна памет\Dani's docs\C#\C# OOP Advanced\Exercise Unit Testing\StorageMaster\StorageMaster\obj\Debug\netcoreapp2.0\StorageMaster.dll");
        static Type[] types = assembly.GetExportedTypes();
        static Type typeOfProduct = types.First(t => t.Name == "Product");
        static Type typeOfVehicle = types.First(t => t.Name == "Vehicle");
        static Type typeOfStorage = types.First(t => t.Name == "Storage");

        [Test]
        public void TestAcessModifiersOfFieldsAndProperties()
        {
            foreach (var type in types)
            {
                Assert.That(type.GetFields().Length == 0);
                Assert.That(type.GetProperties().Where(p => p.SetMethod != null)
                    .Any(p => p.SetMethod.IsPublic) == false);
            }
        }

        [Test]
        public void TestProductType()
        {
            Assert.That(typeOfProduct.IsAbstract);

            ConstructorInfo constructor = typeOfProduct.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
                null, new Type[] { typeof(double), typeof(double) }, null);

            Assert.That(constructor.IsFamily);

            PropertyInfo pricePropertyInfo = typeOfProduct.GetProperty("Price");
            Assert.That(pricePropertyInfo.PropertyType == typeof(double));

            PropertyInfo weightPropertyInfo = typeOfProduct.GetProperty("Weight");
            Assert.That(pricePropertyInfo.PropertyType == typeof(double));
        }

        [Test]
        [TestCase("Gpu", 0.7)]
        [TestCase("HardDrive", 1)]
        [TestCase("Ram", 0.1)]
        [TestCase("SolidStateDrive", 0.2)]
        public void TestTypeThatDerivesFromProduct(string typeName, double weight)
        {
            Type typeOfItemThatderivesFromProduct = types.First(t => t.Name == typeName);

            Assert.That(typeOfItemThatderivesFromProduct.BaseType == typeOfProduct);

            ConstructorInfo constructor = typeOfItemThatderivesFromProduct
                .GetConstructor(new Type[] { typeof(double) });

            object typeThatDerivesFromProductObject;

            Assert.That(() => typeThatDerivesFromProductObject = constructor
            .Invoke(new object[] { -1 }),
                Throws.TargetInvocationException.With.InnerException
                .TypeOf(typeof(InvalidOperationException)));

            Assert.That(() => typeThatDerivesFromProductObject = constructor
            .Invoke(new object[] { -1 }),
                Throws.TargetInvocationException.With.InnerException
                .With.Message.EqualTo("Price cannot be negative!"));

            typeThatDerivesFromProductObject = constructor.Invoke(new object[] { 3 });

            Assert.That((double)typeOfItemThatderivesFromProduct.GetProperty("Weight")
                .GetValue(typeThatDerivesFromProductObject) == weight);
        }

        [Test]
        public void TestVehicleTypeDeclaratingMembers()
        {
            Assert.That(typeOfVehicle.IsAbstract);

            ConstructorInfo constructor = typeOfVehicle.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
                null, new Type[] { typeof(int) }, null);

            Assert.That(constructor.IsFamily);

            PropertyInfo propertyInfoCapacity = typeOfVehicle.GetProperty("Capacity");
            Assert.That(propertyInfoCapacity.PropertyType == typeof(int));


            PropertyInfo propertyInfoTrunk = typeOfVehicle.GetProperty("Trunk");
            Type expectedTrunkType = typeof(IReadOnlyCollection<>).MakeGenericType(typeOfProduct);
            Assert.That(propertyInfoTrunk.PropertyType == expectedTrunkType);

            PropertyInfo propertyInfoIsFull = typeOfVehicle.GetProperty("IsFull");
            Assert.That(propertyInfoIsFull.PropertyType == typeof(bool));

            PropertyInfo propertyInfoIsEmpty = typeOfVehicle.GetProperty("IsEmpty");
            Assert.That(propertyInfoIsFull.PropertyType == typeof(bool));
        }

        [Test]
        [TestCase("Van", 2)]
        [TestCase("Truck", 5)]
        [TestCase("Semi", 10)]
        public void TestTypesThatDEriveFromVehicleBehaviour(string typeName, int capacity)
        {
            Type typeOfItemThatderivesFromVehicle = types.First(t => t.Name == typeName);

            Assert.That(typeOfItemThatderivesFromVehicle.BaseType == typeOfVehicle);

            object instanceOfTypeOfItemThatDerivesFromVehicle = Activator
                .CreateInstance(typeOfItemThatderivesFromVehicle);

            PropertyInfo propertyInfoCapacity = typeOfVehicle.GetProperty("Capacity");
            Assert.That((int)propertyInfoCapacity.GetValue(instanceOfTypeOfItemThatDerivesFromVehicle) == capacity);

            MethodInfo methodInfoLoadProduct = typeOfVehicle.GetMethod("LoadProduct");
            Type typeofHardDrive = types.First(t => t.Name == "HardDrive");
            Type typeofGpu = types.First(t => t.Name == "Gpu");

            methodInfoLoadProduct.Invoke(instanceOfTypeOfItemThatDerivesFromVehicle, new object[]{Activator
                .CreateInstance(typeofHardDrive,new object[] { 3}) });

            methodInfoLoadProduct.Invoke(instanceOfTypeOfItemThatDerivesFromVehicle, new object[]{Activator
                .CreateInstance(typeofGpu,new object[] { 3}) });

            methodInfoLoadProduct.Invoke(instanceOfTypeOfItemThatDerivesFromVehicle, new object[]{Activator
                .CreateInstance(typeofHardDrive,new object[] { 3}) });

            if (typeName == "Van")
            {
                Assert.That(() => methodInfoLoadProduct
                    .Invoke(instanceOfTypeOfItemThatDerivesFromVehicle, new object[] { Activator.CreateInstance(typeofHardDrive, 3) })
                    , Throws.TargetInvocationException.With.InnerException.Message.EqualTo("Vehicle is full!"));
            }

            object trunk = typeOfItemThatderivesFromVehicle.GetProperty("Trunk")
                .GetValue(instanceOfTypeOfItemThatDerivesFromVehicle);

            int CountOfProducts = (int)trunk.GetType().GetProperty("Count")
                .GetValue(trunk);

            Assert.That(CountOfProducts == 3);
            PropertyInfo propertyInfoIsFull = typeOfVehicle.GetProperty("IsFull");

            if (typeName == "Van")
            {
                Assert.That((bool)propertyInfoIsFull.GetValue(instanceOfTypeOfItemThatDerivesFromVehicle) == true);
            }
            else
            {
                Assert.That((bool)propertyInfoIsFull.GetValue(instanceOfTypeOfItemThatDerivesFromVehicle) == false);
            }

            MethodInfo methodInfoUnload = typeOfVehicle.GetMethod("Unload");

            methodInfoUnload.Invoke(instanceOfTypeOfItemThatDerivesFromVehicle, new object[] { });
            methodInfoUnload.Invoke(instanceOfTypeOfItemThatDerivesFromVehicle, new object[] { });

            CountOfProducts = (int)trunk.GetType().GetProperty("Count")
                .GetValue(trunk);

            Assert.That(CountOfProducts == 1);

            PropertyInfo propertyInfoIsEmpty = typeOfVehicle.GetProperty("IsEmpty");

            Assert.That((bool)propertyInfoIsEmpty.GetValue(instanceOfTypeOfItemThatDerivesFromVehicle) == false);

            var productReturned = methodInfoUnload.Invoke(instanceOfTypeOfItemThatDerivesFromVehicle, new object[] { });
            Assert.That(productReturned.GetType().Name == "HardDrive");
            Assert.That((bool)propertyInfoIsEmpty.GetValue(instanceOfTypeOfItemThatDerivesFromVehicle) == true);

            Assert.That(() => methodInfoUnload.Invoke(instanceOfTypeOfItemThatDerivesFromVehicle, new object[] { })
            ,Throws.TargetInvocationException.With.InnerException.With.Message.EqualTo("No products left in vehicle!"));
        }

        [Test]
        public void TestStorageTypeDeclaringMembers()
        {
            Assert.That(typeOfStorage.IsAbstract);

            ConstructorInfo constructor = typeOfStorage.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
                null, new Type[] { typeof(string),typeof(int),typeof(int),typeof(IEnumerable<>).MakeGenericType(typeOfVehicle) }, null);

            Assert.That(constructor.IsFamily);

            PropertyInfo propertyInfoName = typeOfStorage.GetProperty("Name");
            Assert.That(propertyInfoName.PropertyType == typeof(string));

            PropertyInfo propertyInfoCapacity = typeOfStorage.GetProperty("Capacity");
            Assert.That(propertyInfoCapacity.PropertyType == typeof(int));

            PropertyInfo propertyInfoGarageSlots = typeOfStorage.GetProperty("GarageSlots");
            Assert.That(propertyInfoGarageSlots.PropertyType == typeof(int));

            PropertyInfo propertyInfoIsFull = typeOfStorage.GetProperty("IsFull");
            Assert.That(propertyInfoIsFull.PropertyType == typeof(bool));

            PropertyInfo propertyInfoGarage = typeOfStorage.GetProperty("Garage");
            Type expectedGarageType = typeof(IReadOnlyCollection<>).MakeGenericType(typeOfVehicle);
            Assert.That(propertyInfoGarage.PropertyType == expectedGarageType);

            PropertyInfo propertyInfoProducts = typeOfStorage.GetProperty("Products");
            Type expectedProductsType = typeof(IReadOnlyCollection<>).MakeGenericType(typeOfProduct);
            Assert.That(propertyInfoProducts.PropertyType == expectedProductsType);
        }
    }
}
