using AspNetCoreExamples;
using AspNetCoreExamples.Abstractions;
using AspNetCoreExamples.Configurations.Mapping;
using AspNetCoreExamples.DataBase;
using AspNetCoreExamples.Entities;
using AspNetCoreExamples.Models;
using AspNetCoreExamples.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder();

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddSingleton<IEventRepository, FakeEventRepository>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<MyMiddleware>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<EventMapperProfile>();
});

var app = builder.Build();

app.MapRazorPages();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseMiddleware<MyMiddleware>();

app.MapGet("events/all",
    async ([FromServices] IEventService eventService, 
    [FromServices]IMapper mapper) =>
{
    var result = await eventService.GetAllActiveEvents();
    
    return result.Select(x => new EventResult
    {
        Id = x.Id,
        Name = x.Name,
        Place =  x.Place,
    });
});

app.MapPost("events/new",
    async ([FromServices] IEventService eventService, 
        CreateEventRequest request) =>
    {
        var result = await eventService.RegisterNewEvent(new Event
        {
            Name = request.Name,
            Place = request.Place,
            EndedAt = request.EndedAt,
            StartedAt = request.StartedAt,
            Quota = request.Quota,
        });
    
        return new EventResult
        {
            Id = result.Id,
            Place =  result.Place,
            Name = result.Name,
        };
    });


app.Run();