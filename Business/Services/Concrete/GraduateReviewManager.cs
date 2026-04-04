using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.DTOs.HomePageDTOs.GraduateReview;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Concrete
{
    public class GraduateReviewManager : IGraduateReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GraduateReviewManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GraduateReviewDto>>> GetReviewsAsync()
        {
            var reviews = await _unitOfWork.GraduateReviewRepository.GetAllWithGraduateAsync();

            var dtoList = _mapper.Map<List<GraduateReviewDto>>(reviews);

            return new SuccessDataResult<List<GraduateReviewDto>>(dtoList);
        }
    }
}
