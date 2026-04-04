using Core.Utilities.Result.Abstract;
using Entities.DTOs.GraduateDTOs;
using Entities.DTOs.StudentDTOs;

namespace Business.Services.Abstract;

public interface IStudentService
{
    Task<IDataResult<List<GetAllStudentsDto>>> GetAllStudentsAsync();
    Task<IDataResult<GetStudentDto>> GetStudentByIdAsync(Guid id);
    Task<IResult> AddStudentAsync(CreateStudentDto dto);
    Task<IResult> DeleteStudentAsync(Guid id);
    Task<IResult> UpdateStudentAsync(Guid id, UpdateStudentDto dto);
}