namespace IoCExample;

public class Two : ITwo
{
    public Two(I3 _3)
    {
        Console.WriteLine(_3);
    }
}