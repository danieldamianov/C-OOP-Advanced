using System;
using System.Collections.Generic;
using System.Text;

public class Creature
{
    private int PrivateCreatureField;
    public int PublicCreatureField;

    //public int CreatureProperty { get; set; }

    public void CreatureMethod()
    {

    }
}


public class Human : Creature
{
    private int PrivateHumanField;
    public int PublicHumanField;

    //public int HumanProperty { get; set; }

    public void HumanMethod()
    {

    }
}

public class Worker : Human
{
    private int PrivateWorkerField;
    public int PublicWorkerField;

    //public int WorkerProperty { get; set; }

    public void WorkerMethod()
    {

    }
}
