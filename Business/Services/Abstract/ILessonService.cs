using Core.Utilities.Result.Abstract;
using Entities.DTOs.LessonDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstract
{
    public interface ILessonService
    {
        public Task<IDataResult<List<GetAllLessonDTO>>> GetAllLessontsAsync();
        public Task<IDataResult<GetLessonDTO>> GetLessontByIdAsync(Guid id);
        public Task<IResult> AddLessonDtoAsync(CreateLessonDTO createLessonDTO);
        public Task<IResult> DeleteLessonDtoAsync(Guid id);
        public Task<IResult> UpdateLessonDtoAsync(Guid id, UpdateLessonDTO updateLessonDTO);
    }
}
