using Core.Utilities.Result.Abstract;
using Entities.DTOs.HomePageDTOs.GraduateReview;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstract
{
    public interface IGraduateReviewService
    {
        public Task<IDataResult<List<GraduateReviewDto>>> GetReviewsAsync();
    }
}
