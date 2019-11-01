using System;
using System.Collections.Generic;
using System.Text;

public class FakeTarget : ITarget
{
    public int Health { get; private set; } = 1;

    public int GiveExperience()
    {
        return 555;
    }

    public bool IsDead()
    {
        return this.Health <= 0;
    }

    public void TakeAttack(int attackPoints)
    {
        this.Health -= attackPoints;
    }
}

