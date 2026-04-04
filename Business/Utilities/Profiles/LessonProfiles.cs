using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.LessonDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.Profiles
{
    public class LessonProfiles:Profile
    {
        public LessonProfiles()
        {
            CreateMap<Lesson, GetAllLessonDTO>().ReverseMap();
            CreateMap<Lesson, GetLessonDTO>().ReverseMap();
            CreateMap<CreateLessonDTO, Lesson>().ReverseMap();
            CreateMap<UpdateLessonDTO, Lesson>().ReverseMap();

        }
    }
}
