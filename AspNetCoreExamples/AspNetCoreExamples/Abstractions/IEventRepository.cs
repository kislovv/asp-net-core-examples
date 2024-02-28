using AspNetCoreExamples.Entities;

namespace AspNetCoreExamples.Abstractions;

public interface IEventRepository
{
    /// <summary>
    /// Получение всех мероприятий
    /// </summary>
    /// <returns>Список активных мероприятий</returns>
    public Task<List<Event>> GetAllEvents();
}