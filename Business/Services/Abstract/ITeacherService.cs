using Core.Utilities.Result.Abstract;
using Entities.DTOs.TeacherDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstract
{
    public interface ITeacherService
    {
        public Task<IDataResult<List<GetAllTeachersDto>>> GetAllTeachersAsync();
        public Task<IDataResult<GetTeacherDto>> GetTeacherByIdAsync(Guid id);
        public Task<IResult> AddTeacherAsync(CreateTeacherDto createTeacherDto);
        public Task<IResult> DeleteTeacherAsync(Guid id);
        public Task<IResult> UpdateTeacherAsync(Guid id, UpdateTeacherDto updateTeacherDto);
    }
}
