using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Events;

namespace Business.Utilities.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile() 
        {
            CreateMap<GetEventDto, Event>().ReverseMap();

            CreateMap<CreateEventDto, Event>().ReverseMap();

            CreateMap<Event, GetAllEventDto>().ReverseMap();

            CreateMap<UpdateEventDto, Event>().ReverseMap();
        }
    }
}
