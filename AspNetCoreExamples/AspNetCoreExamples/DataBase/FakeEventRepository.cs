using AspNetCoreExamples.Abstractions;
using AspNetCoreExamples.Entities;

namespace AspNetCoreExamples.DataBase;

public class FakeEventRepository : IEventRepository
{
    private readonly List<Event> _events =
    [
        new Event
        {
            Id = 1,
            Name = "A",
            Place = "Pl1",
            Quota = 10,
            StartedAt = DateTimeOffset.Now.AddDays(1),
            EndedAt = DateTimeOffset.Now.AddDays(2)
        },

        new Event
        {
            Id = 2,
            Name = "B",
            Place = "Pl2",
            Quota = 8,
            StartedAt = DateTimeOffset.Now.AddDays(-2),
            EndedAt = DateTimeOffset.Now.AddDays(1)
        },

        new Event
        {
            Id = 3,
            Name = "B",
            Place = "Pl3",
            Quota = 7,
            StartedAt = DateTimeOffset.Now.AddDays(-1),
            EndedAt = DateTimeOffset.Now.AddHours(-1)
        }
    ];

    public Task<List<Event>> GetAllEvents()
    {
        return Task.FromResult(_events);
    }
}