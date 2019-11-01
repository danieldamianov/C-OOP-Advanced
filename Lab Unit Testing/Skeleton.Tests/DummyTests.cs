using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class DummyTests
{
    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        Dummy dummy = new Dummy(20, 3);

        dummy.TakeAttack(10);

        Assert.AreEqual(10, dummy.Health);
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        Dummy dummy = new Dummy(0, 2);

        Assert.That
            (() => dummy.TakeAttack(10), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        Dummy dummy = new Dummy(0, 355);

        Assert.AreEqual(355, dummy.GiveExperience());
    }

    [Test]
    public void AliveDummyCanNotGiveXP()
    {
        Dummy dummy = new Dummy(1, 355);

        Assert.That(() => dummy.GiveExperience(),
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}


