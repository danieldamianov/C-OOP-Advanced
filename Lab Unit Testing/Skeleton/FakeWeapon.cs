using System;
using System.Collections.Generic;
using System.Text;

public class FakeWeapon : IWeapon
{
    public int AttackPoints => 10;

    public int DurabilityPoints => 222;

    public void Attack(ITarget target)
    {
        target.TakeAttack(this.AttackPoints);
    }
}

