namespace AspNetCoreExamples.Entities;

public class Event
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Place { get; set; }
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset EndedAt { get; set; }
    public int Quota { get; set; }
}