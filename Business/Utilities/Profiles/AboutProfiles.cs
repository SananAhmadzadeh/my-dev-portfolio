using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.AboutDTOs;

namespace Business.Utilities.Profiles
{
    public class AboutProfiles: Profile
    {
        public AboutProfiles()
        {
            CreateMap<CreateAboutDTO, About>();

            CreateMap<UpdateAboutDTO, About>();

            CreateMap<About, GetAboutDTO>();

            CreateMap<About, GetAllAboutDTO>();
        }
    }
}
