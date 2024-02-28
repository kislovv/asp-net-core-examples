using AspNetCoreExamples.Abstractions;
using AspNetCoreExamples.Entities;
using AspNetCoreExamples.Services;
using AutoFixture;
using Moq;
using XunitShouldExtension;

namespace AspNetExampleUnitTests;

public class EventServiceTests
{
    private Fixture _fixture = new Fixture();
    private Mock<IEventRepository> _eventRepositoryMock = new Mock<IEventRepository>();
    [Fact]
    public async Task Get_All_Events_Should_Be_Return_List_Actual_Events()
    {
        //stub
        var events = _fixture.Build<Event>()
            .Without(ev => ev.Place)
            .CreateMany(5)
            .ToList();
	
        //Делаем 1 завершеным чтобы проверить что 1 запись точно не вернется в результате
        events[0].EndedAt = DateTimeOffset.Now.AddDays(-1);
	
        //moq
        _eventRepositoryMock.Setup(repository => repository.GetAllEvents())
            .ReturnsAsync(events);

        var eventService = new EventService(_eventRepositoryMock.Object);
	
        var result = await eventService.GetAllActiveEvents();
        
        result.ShouldNotContain(events[0]);
    }
}