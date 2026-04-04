using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.GraduateDTOs;
using Entities.DTOs.StatisticsDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.Profiles
{
    public class StatisticsProfiles : Profile
    {
        public StatisticsProfiles()
        {
            CreateMap<CreateStatisticsDto, Statistics>();
            CreateMap<UpdateStatisticsDto, Statistics>();
            CreateMap<Statistics, GetStatisticsDto>();
            CreateMap<Statistics, GetAllStatisticsDto>();
        }
    }
}
