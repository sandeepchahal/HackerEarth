


B obj = new B();
obj.Print("Hello");

public abstract class A
{
    public virtual void Print(string msg)
    {
        Console.WriteLine(msg);
    }
}

public class B : A
{
    public override void Print(string msg)
    {
        base.Print(msg:msg);
        Console.WriteLine("This is derived class");
    }
}


