using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.DTOs.HomePageDTOs.WhyChooseUsSection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Concrete
{
    public class WhyChooseUsManager : IWhyChooseUsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WhyChooseUsManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<WhyChooseUsItemDto>>> GetItemsAsync()
        {
            var items = await _unitOfWork.WhyChooseUsRepository.GetAllAsync();

            var dtoList = _mapper.Map<List<WhyChooseUsItemDto>>(items);

            return new SuccessDataResult<List<WhyChooseUsItemDto>>(dtoList);
        }
    }
}
