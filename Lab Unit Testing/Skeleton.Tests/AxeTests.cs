using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);
        axe.Attack(dummy);
        Assert.AreEqual(9, axe.DurabilityPoints);
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        Axe axe = new Axe(456, 0);
        Dummy dummy = new Dummy(2333, 456);
        Assert.That
            (() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}

