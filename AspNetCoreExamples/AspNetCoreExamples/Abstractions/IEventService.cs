using AspNetCoreExamples.Entities;

namespace AspNetCoreExamples.Abstractions;

public interface IEventService
{
    /// <summary>
    /// Получение всех активных (не завершенных) мероприятий
    /// </summary>
    /// <returns>Список активных мероприятий</returns>
    public Task<List<Event>> GetAllActiveEvents();
	
    /// <summary>
    /// Попытка добавить мероприятие в общий пул для возможности регистрации
    /// </summary>
    /// <param name="ev">Мероприятие которое пытаются добавить в список активных</param>
    /// <returns>успешность операции</returns>
    public Task<bool> RegisterNewEvent(Event ev);

}