using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.Exceptions;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.Abstract;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.Recommendations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Concrete
{
    public class RecommendationManager : IRecommendationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;


        public RecommendationManager(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
        }




        public async Task<IDataResult<List<GetAllRecommendationDto>>> GetAllRecommendationAsync()
        {
            var recommendations = await _unitOfWork.RecommendationRepository.GetAllAsync();
            if (recommendations.Count == 0)
            {
                return new ErrorDataResult<List<GetAllRecommendationDto>>(_mapper.Map<List<GetAllRecommendationDto>>(recommendations)," Recommendation can not listed");
            }
            return new SuccessDataResult<List<GetAllRecommendationDto>>(_mapper.Map<List<GetAllRecommendationDto>>(recommendations), "Recommendation listed");

        }


        public async Task<IDataResult<GetRecommendationDto>> GetRecommendationById(Guid id)
        {
            var result = await _unitOfWork.RecommendationRepository.GetAsync(p => p.Id == id);
            if (result is null)
            {
                return new ErrorDataResult<GetRecommendationDto>(_mapper.Map<GetRecommendationDto>(result), $"Recommendation Not found with {id}");
            }
            return new SuccessDataResult<GetRecommendationDto>(_mapper.Map<GetRecommendationDto>(result), $"Recommendation found with {id}");
        }





        public async Task<IResult> AddRecommendationAsync(CreateRecommendationDto dto)
        {
            if (dto == null)
                return new ErrorResult("Data is null");

            if (dto.IconUrl == null)
                return new ErrorResult("Fayl seçilməyib");

            var uploadedFilePath =
                await _fileService.UploadAsync(dto.IconUrl, "Recommendation");

            var recommendation = _mapper.Map<Recommendation>(dto);
            recommendation.IconUrl = uploadedFilePath;
            recommendation.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.RecommendationRepository.AddAsync(recommendation);

            var result = await _unitOfWork.SaveAsync();
            if (result == 0)
                return new ErrorResult("Recommendation not added");

            return new SuccessResult("Recommendation Added");
        }







        public async Task<IResult> DeleteRecommendationAsync(Guid id)
        {
            var deleted = await _unitOfWork.RecommendationRepository.GetAsync(r => r.Id == id);

            _unitOfWork.RecommendationRepository.Delete(deleted);

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
            {
                return new ErrorResult("Can not deleted Recommendation");
            }

            return new SuccessResult("Recommendation deleted success");

        }

        public async Task<IResult> UpdateRecommendationAsync(Guid id, UpdateRecommendationDto dto)
        {
            var recommendation = await _unitOfWork.RecommendationRepository.GetAsync(r => r.Id == id);
            if(recommendation==null)
            {
                return new ErrorResult("Recommendation not found");
            }
             _mapper.Map(dto,recommendation);
            _unitOfWork.RecommendationRepository.Update(recommendation);
            var saveResult = await _unitOfWork.SaveAsync();
            if (saveResult == 0)
            {
                return new ErrorResult("Can not updated Recommendation");
            }

            return new SuccessResult("Recommendation updated success");

        }
    }
}
