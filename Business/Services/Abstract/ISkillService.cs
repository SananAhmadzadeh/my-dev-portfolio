using Core.Utilities.Result.Abstract;
using Entities.DTOs.SkillDTOs;

namespace Business.Services.Abstract
{
    public interface ISkillService
    {
        Task<IDataResult<List<GetAllSkillsDto>>> GetAllSkillsAsync();
        Task<IDataResult<GetSkillDto>> GetSkillByIdAsync(Guid id);
        Task<IResult> AddSkillAsync(CreateSkillDto dto);
        Task<IResult> DeleteSkillAsync(Guid id);
        Task<IResult> UpdateSkillAsync(Guid id, UpdateSkillDto dto);
    }
}
