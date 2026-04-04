using Core.Utilities.Result.Abstract;
using Entities.DTOs.VacancyDTOs;

namespace Business.Services.Abstract
{
    public interface IVacancyService
    {
        Task<IDataResult<List<GetAllVacanciesDto>>> GetAllVacanciesAsync();
        Task<IDataResult<GetVacancyDto>> GetVacancyByIdAsync(Guid id);
        Task<IResult> AddVacancyAsync(CreateVacancyDto dto);
        Task<IResult> DeleteVacancyAsync(Guid id);
        Task<IResult> UpdateVacancyAsync(Guid id, UpdateVacancyDto dto);
    }
}
