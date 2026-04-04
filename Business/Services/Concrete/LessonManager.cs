using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.Abstract;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.LessonDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Concrete
{
    public class LessonManager:ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LessonManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> AddLessonDtoAsync(CreateLessonDTO createLessonDTO)
        {
            var lesson = _mapper.Map<Lesson>(createLessonDTO);
            await _unitOfWork.LessonRepository.AddAsync(lesson);

            var result=await _unitOfWork.SaveAsync();
            if(result==0)
            {
                return new ErrorResult("Lesson could not be added");
            }
            return new SuccessResult("Lesson has been added successfully");
           
        }

        public async Task<IResult> DeleteLessonDtoAsync(Guid id)
        {
            var lesson = await _unitOfWork.LessonRepository.GetAsync(l => l.Id == id);
            if (lesson == null)
            {
                throw new NotFoundException(ExceptionMessage.LessonNotFound);
            }

            _unitOfWork.LessonRepository.Delete(lesson);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0)
            {
                return new ErrorResult("Lesson could not be deleted.");
            }

            return new SuccessResult("Lesson has been deleted successfully.");
        }

        
        public async Task<IDataResult<List<GetAllLessonDTO>>> GetAllLessontsAsync()
        {
            var lessons = await _unitOfWork.LessonRepository.GetAllAsync();
            if(lessons.Count==0)
            {
                return new ErrorDataResult<List<GetAllLessonDTO>>(_mapper.Map<List<GetAllLessonDTO>>(lessons), "No lessons found");
            }
            return new SuccessDataResult<List<GetAllLessonDTO>>(_mapper.Map<List<GetAllLessonDTO>>(lessons), "Lessons retrieved successfully");
        }

        public async Task<IDataResult<GetLessonDTO>> GetLessontByIdAsync(Guid id)
        {
            var result= await _unitOfWork.LessonRepository.GetAsync(l=>l.Id==id);
            if(result==null)
            {
                return new ErrorDataResult<GetLessonDTO>(_mapper.Map<GetLessonDTO>(result), "Lesson not found");
            }
            return new SuccessDataResult<GetLessonDTO>(_mapper.Map<GetLessonDTO>(result), "Lesson retrieved successfully");
        }

        public async Task<IResult> UpdateLessonDtoAsync(Guid id, UpdateLessonDTO updateLessonDTO)
        {
            var lesson = await _unitOfWork.LessonRepository.GetAsync(l => l.Id == id);
            if (lesson == null)
            {
                return new ErrorResult("Lesson not found.");
            }

            _mapper.Map(updateLessonDTO, lesson);
            var result = await _unitOfWork.SaveAsync();
            if (result == 0)
            {
                return new ErrorResult("Lesson could not be updated.");
            }

            return new SuccessResult("Lesson has been updated successfully.");
        }

    }
}
