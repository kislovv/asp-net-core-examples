namespace AspNetCoreExamples.Models;

public class WeatherResult
{
    public required Main Main { get; set; }
}

public class Main
{
    public double Temp { get; set; }
}