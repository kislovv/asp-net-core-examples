using AspNetCoreExamples.Abstractions;
using AspNetCoreExamples.Entities;

namespace AspNetCoreExamples.Services;

public class EventService(IEventRepository eventRepository) : IEventService
{
    public async Task<List<Event>> GetAllActiveEvents()
    {
        var allEvents = await eventRepository.GetAllEvents();
        
        return allEvents
            .Where(ev => ev.EndedAt > DateTimeOffset.Now)
            .ToList();
    }

    public async Task<bool> RegisterNewEvent(Event ev)
    {
        throw new NotImplementedException();
    }
}