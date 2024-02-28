using AspNetCoreExamples.Entities;
using AutoMapper;

namespace AspNetCoreExamples.Configurations.Mapping;

public class EventMapperProfile : Profile
{
    public EventMapperProfile()
    {
        CreateMap<Models.Event, Event>().ReverseMap();
    }
}