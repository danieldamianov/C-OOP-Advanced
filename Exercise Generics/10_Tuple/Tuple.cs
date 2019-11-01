using System.Collections.Generic;
using System.Text;

public class CustomTuple<T1,T2,T3>
{
    public T1 item1 { get; set; }
    public T2 item2 { get; set; }
    public T3 item3 { get; set; }

    public CustomTuple(T1 item1, T2 item2, T3 item3)
    {
        this.item1 = item1;
        this.item2 = item2;
        this.item3 = item3;
    }

    public override string ToString()
    {
        return $"{this.item1} -> {this.item2} -> {this.item3}";
    }
}

