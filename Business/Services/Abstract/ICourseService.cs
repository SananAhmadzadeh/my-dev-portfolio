using Core.Utilities.Result.Abstract;
using Entities.DTOs.CourseDTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Services.Abstract
{
    public interface ICourseService
    {
        public Task<IDataResult<List<GetAllCourseDto>>> GetAllCoursesAsync();
        public Task<IDataResult<GetCourseDto>> GetCourseByIdAsync(Guid courseId);
        public Task<Core.Utilities.Result.Abstract.IResult> AddCourseAsync(CreateCourseDto dto);
        public Task<Core.Utilities.Result.Abstract.IResult> Delete(Guid id);
        public Task<Core.Utilities.Result.Abstract.IResult> UpdateCourseAsync(Guid id, UpdateCourseDto updateCourseDto);
    }
}
