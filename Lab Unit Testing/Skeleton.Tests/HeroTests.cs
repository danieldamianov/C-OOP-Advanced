using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

[TestFixture]
public class HeroTests
{
    [Test]
    public void TestIfAHeroGainsXPWhenTheTargetDies()
    {
        Mock<ITarget> mockTarget = new Mock<ITarget>();
        Mock<IWeapon> mockWeapon = new Mock<IWeapon>();

        mockTarget.Setup(t => t.Health).Returns(0);
        mockTarget.Setup(t => t.GiveExperience()).Returns(555);
        mockTarget.Setup(t => t.IsDead()).Returns(mockTarget.Object.Health <= 0);

        mockWeapon.Setup(w => w.AttackPoints).Returns(10);
        mockWeapon.Setup(w => w.DurabilityPoints).Returns(222);

        Hero hero = new Hero("Pesho", mockWeapon.Object);

        hero.Attack(mockTarget.Object);

        Assert.AreEqual(555, hero.Experience);
    }
}

