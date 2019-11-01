using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private T field;

    public Box(T field)
    {
        this.field = field;
    }

    public override string ToString()
    {
        return $"{this.field.GetType().FullName}: {this.field}";
    }
}

