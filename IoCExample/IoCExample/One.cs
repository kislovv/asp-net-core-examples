namespace IoCExample;

public class One : IOne
{
    public One(ITwo two, I3 three)
    {
        Console.WriteLine($"{two} | {three}");
    }
}