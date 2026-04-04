using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.HomePageDTOs.WhyChooseUsSection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.Profiles
{
    public class WhyChooseUsProfile : Profile
    {
        public WhyChooseUsProfile()
        {
            CreateMap<WhyChooseUs, WhyChooseUsItemDto>();
        }
    }
}
