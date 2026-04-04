using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.ContactDTOs;

namespace Business.Utilities.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
            CreateMap<UserMessageDTO, UserMessage>().ReverseMap();
        }
    }
}
