using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.TopicDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.Profiles
{
    public class TopicProfile:Profile
    {
        public TopicProfile()
        {
            CreateMap<Topic,GetAllTopicsDto>().ReverseMap();
            CreateMap<Topic, GetTopicDto>().ReverseMap();
            CreateMap<Topic, CreateTopicDto>().ReverseMap();
            CreateMap<Topic, UpdateTopicDto>().ReverseMap();
        }
    }
}
