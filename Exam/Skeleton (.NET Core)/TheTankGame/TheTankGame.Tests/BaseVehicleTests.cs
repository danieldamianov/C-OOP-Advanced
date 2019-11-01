namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void TestProperties()
        {
            Assert.That(typeof(BaseVehicle).IsAbstract);
            BaseVehicle baseVehicle = new Revenger("MPO",20,13,12,13,14,new VehicleAssembler());
            Assert.AreEqual(baseVehicle.Model, "MPO");
            Assert.AreEqual(baseVehicle.Weight, 20);
            Assert.AreEqual(baseVehicle.Price, 13);
            Assert.AreEqual(baseVehicle.Attack, 12);
            Assert.AreEqual(baseVehicle.Defense, 13);
            Assert.AreEqual(baseVehicle.HitPoints, 14);

            baseVehicle.AddArsenalPart(new ArsenalPart("Model", 12, 13, 4));
            baseVehicle.AddEndurancePart(new EndurancePart("Model2", 14, 15, 6));
            baseVehicle.AddShellPart(new ShellPart("Model3", 17, 18, 9));

            baseVehicle.AddArsenalPart(new ArsenalPart("Model", 12, 13, 4));
            baseVehicle.AddEndurancePart(new EndurancePart("Model2", 14, 15, 6));
            baseVehicle.AddShellPart(new ShellPart("Model3", 17, 18, 9));

            string actualValue = baseVehicle.ToString();
            string[] lines = actualValue.Split(Environment.NewLine);
            actualValue = string.Join(Environment.NewLine, lines.Skip(1));

            string expectedValue =
                "Total Weight: 106,000\r\n" +
                "Total Price: 105,000\r\n" +
                "Attack: 20\r\n" +
                "Defense: 31\r\n" +
                "HitPoints: 26\r\n" +
                "Parts: Model, Model2, Model3, Model, Model2, Model3";
            Assert.AreEqual(expectedValue, actualValue);

            FieldInfo fieldInfo = typeof(BaseVehicle).GetField("orderedParts",BindingFlags.Instance | BindingFlags.NonPublic);
            IList<string> val = (IList<string>)fieldInfo.GetValue(baseVehicle);
            Assert.AreEqual("Model, Model, Model3, Model3, Model2, Model2", string.Join(", ", baseVehicle.Parts.Select(p => p.Model)));

            Assert.AreEqual(106.000, baseVehicle.TotalWeight);
            Assert.AreEqual(105.000, baseVehicle.TotalPrice);
            Assert.AreEqual(20, baseVehicle.TotalAttack);
            Assert.AreEqual(31, baseVehicle.TotalDefense);
            Assert.AreEqual(26, baseVehicle.TotalHitPoints);
            //Assert.AreEqual("Model, Model2, Model3, Model, Model2, Model3", baseVehicle.);

            BaseVehicle baseVehicle2 = new Revenger("s",1,1,1,1,1,new VehicleAssembler());
            Assert.That(() => baseVehicle2 = new Revenger("", 1, 1, 1, 1, 1, new VehicleAssembler()), Throws.ArgumentException);
            Assert.That(() => baseVehicle2 = new Revenger("d", 0, 1, 1, 1, 1, new VehicleAssembler()), Throws.ArgumentException);
            Assert.That(() => baseVehicle2 = new Revenger("d", 1, 0, 1, 1, 1, new VehicleAssembler()), Throws.ArgumentException);
            Assert.That(() => baseVehicle2 = new Revenger("d", 1, 1, -1, 1, 1, new VehicleAssembler()), Throws.ArgumentException);
            Assert.That(() => baseVehicle2 = new Revenger("d", 1, 1, 1, -1, 1, new VehicleAssembler()), Throws.ArgumentException);
            Assert.That(() => baseVehicle2 = new Revenger("d", 1, 1, 1, 1, -1, new VehicleAssembler()), Throws.ArgumentException);
            Assert.AreEqual(true, baseVehicle2.ToString().Contains("None"));
        }
    }
}