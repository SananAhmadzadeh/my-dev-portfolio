using Core.Utilities.Result.Abstract;
using Entities.DTOs.Recommendations;
using Sprache;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstract
{
    public interface IRecommendationService
    {
        public Task<IDataResult<List<GetAllRecommendationDto>>> GetAllRecommendationAsync();

        public Task<IDataResult<GetRecommendationDto>> GetRecommendationById(Guid id);

        public Task<IResult> AddRecommendationAsync(CreateRecommendationDto createRecommendationDto);

        public Task<IResult> DeleteRecommendationAsync(Guid id); 

        public Task<IResult> UpdateRecommendationAsync(Guid id, UpdateRecommendationDto dto);
    }
}
