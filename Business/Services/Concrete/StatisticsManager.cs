using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.Concrete.EfCore;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.GraduateDTOs;
using Entities.DTOs.StatisticsDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Concrete
{
    public class StatisticsManager : IStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatisticsManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddStatisticsAsync(CreateStatisticsDto dto)
        {
            var resultStatics = _mapper.Map<Statistics>(dto);

            await _unitOfWork.StatisticsRepository.AddAsync(resultStatics);

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
            {
                return new ErrorResult("Statistics is not added !");
            }

            return new SuccessResult("Statistics is added successfully!");
        }

        public async Task<IResult> DeleteStatisticsAsync(Guid id)
        {
            var deleted = await _unitOfWork.StatisticsRepository.GetAsync(st => st.Id == id);

            await _unitOfWork.StatisticsRepository.Delete(deleted);

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
            {
                return new ErrorResult("Statistics is not deleted!");
            }

            return new SuccessResult("Statistics is deleted successfully!");
        }
        public async Task<IDataResult<List<GetAllStatisticsDto>>> GetAllStatisticsAsync()
        {
            var result = await _unitOfWork.StatisticsRepository.GetAllAsync();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<GetAllStatisticsDto>>(_mapper.Map<List<GetAllStatisticsDto>>(result), "Statistics is not listed");
            }

            return new SuccessDataResult<List<GetAllStatisticsDto>>(_mapper.Map<List<GetAllStatisticsDto>>(result), "Statistics is listed");
        }

        public async Task<IDataResult<GetStatisticsDto>> GetStatisticsByIdAsync(Guid id)
        {
            var result = await _unitOfWork.StatisticsRepository.GetAsync(st => st.Id == id);

            if (result is null)
            {
                return new ErrorDataResult<GetStatisticsDto>(_mapper.Map<GetStatisticsDto>(result), "Statistics is not listed");
            }

            return new SuccessDataResult<GetStatisticsDto>(_mapper.Map<GetStatisticsDto>(result), "Statistics is listed");
        }

        public async Task<IResult> UpdateStatisticsAsync(Guid id, UpdateStatisticsDto dto)
        {
            var statistics = await _unitOfWork.StatisticsRepository.GetAsync(st => st.Id == id);


            var updated = _mapper.Map(dto,statistics);

            _unitOfWork.StatisticsRepository.Update(updated);
            var saveResult = await _unitOfWork.SaveAsync();
            if (saveResult == 0)
            {
                return new ErrorResult("Statistics is not updated");
            }

            return new SuccessResult("Statistics is updated successfully!");

        }
    }
}


