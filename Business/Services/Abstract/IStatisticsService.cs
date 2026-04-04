using Core.Utilities.Result.Abstract;
using Entities.DTOs.GraduateDTOs;
using Entities.DTOs.StatisticsDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstract
{
    public interface IStatisticsService
    {
        Task<IDataResult<List<GetAllStatisticsDto>>> GetAllStatisticsAsync();
        Task<IDataResult<GetStatisticsDto>> GetStatisticsByIdAsync(Guid id);
        Task<IResult> AddStatisticsAsync(CreateStatisticsDto dto);
        Task<IResult> DeleteStatisticsAsync(Guid id);
        Task<IResult> UpdateStatisticsAsync(Guid id, UpdateStatisticsDto dto);
    }
}
