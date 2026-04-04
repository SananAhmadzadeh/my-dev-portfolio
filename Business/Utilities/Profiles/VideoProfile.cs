using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.VideoDTOs;

namespace Business.Utilities.Profiles
{
    public class VideoProfile : Profile
    {
        public VideoProfile()
        {
            CreateMap<CreateVideoDto, Video>();
            CreateMap<UpdateVideoDto, Video>();
            CreateMap<Video, GetVideoDto>();
            CreateMap<Video, GetAllVideoDto>();
        }
    }
}
