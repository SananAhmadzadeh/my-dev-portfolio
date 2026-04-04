using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.DTOs.HomePageDTOs.PopularCoursesSection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Concrete
{
    public class PopularCoursesManager : IPopularCoursesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PopularCoursesManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public async Task<IDataResult<List<PopularCourseDto>>> GetPopularCoursesAsync()
        //{
        //    var courses = await _unitOfWork.PopularCoursesRepository.GetAllAsync();

        //    var popularCourses = courses
        //        .Where(c => c.StudentCount > 0)
        //        .ToList();

        //    var dtoList = _mapper.Map<List<PopularCourseDto>>(popularCourses);

        //    return new SuccessDataResult<List<PopularCourseDto>>(
        //        dtoList,
        //        "Popular courses listed");
        //}

    }
}
