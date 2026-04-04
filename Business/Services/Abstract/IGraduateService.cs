using Core.Utilities.Result.Abstract;
using Entities.DTOs.GraduateDTOs;

namespace Business.Services.Abstract
{
    public interface IGraduateService
    {
        Task<IDataResult<List<GetAllGraduatesDto>>> GetAllGraduatesAsync();
        Task<IDataResult<GetGraduateDto>> GetGraduateByIdAsync(Guid id);
        Task<IResult> DeleteGraduateAsync(Guid id);
        //Task<IResult> AddGraduateAsync(CreateGraduateDto dto);
        Task<IResult> UpdateGraduateAsync(Guid id, UpdateGraduateDto dto);
    }
}
