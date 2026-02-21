namespace AspNetCoreExamples.Models;

public class CreateEventRequest
{
    public string Name { get; set; } = null!;
    public string Place { get; set; } = null!;
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset EndedAt { get; set; }
    public int Quota { get; set; }
}