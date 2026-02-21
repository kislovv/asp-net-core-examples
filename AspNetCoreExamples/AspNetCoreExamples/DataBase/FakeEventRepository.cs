using AspNetCoreExamples.Abstractions;
using AspNetCoreExamples.Entities;

namespace AspNetCoreExamples.DataBase;

public class FakeEventRepository : IEventRepository
{
    private int _idSequence = 4;
    private readonly object _locker = new object();
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
        lock (_locker)
        {
            return Task.FromResult(_events);
        }
    }

    public Task<Event> AddEvent(Event ev)
    {
        lock (_locker)
        {
            ev.Id = _idSequence++;
            _events.Add(ev); 
        }
        
        return Task.FromResult(ev);
    }
}