using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Recommendations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.Profiles
{
    public class RecommendationProfile : Profile
    {
        public RecommendationProfile()
        {
            CreateMap<GetRecommendationDto,Recommendation>().ReverseMap();

            CreateMap<CreateRecommendationDto,Recommendation>().ReverseMap();

            CreateMap<Recommendation,GetAllRecommendationDto>().ReverseMap();

            CreateMap<UpdateRecommendationDto, Recommendation>().ReverseMap();

        }
    }
}
