using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Exceptions;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.CourseDTOs;
//using Entities.TranslationConcrete;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Business.Services.Concrete
{
    public class CourseManager : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public CourseManager(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<Core.Utilities.Result.Abstract.IResult> AddCourseAsync(CreateCourseDto dto)
        {
            var course = _mapper.Map<Course>(dto);

            var uploadedPath = await _fileService.UploadAsync(dto.ImageUrl, "Course");
            course.ImageUrl = uploadedPath;

            course.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.CourseRepository.AddAsync(course);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0)
                return new ErrorResult("Kurs əlavə olunmadı");

            return new SuccessResult("Kurs əlavə olundu");

            //if (dto == null)
            //    return new ErrorResult("Məlumat tapılmadı");

            //var course = new Course
            //{
            //    CreatedAt = DateTime.UtcNow,
            //    Translations = new List<CourseTranslation>()
            //};

            //if (dto.ImageUrl != null)
            //{
            //    var uploadedPath = await _fileService.UploadAsync(dto.ImageUrl, "Course");
            //    course.ImageUrl = uploadedPath;
            //}


            //if (dto.Translations != null && dto.Translations.Any())
            //{
            //    foreach (var item in dto.Translations)
            //    {
            //        course.Translations.Add(new CourseTranslation
            //        {
            //            LanguageCode = item.LanguageCode,
            //            Name = item.Name,
            //            Description = item.Description
            //        });
            //    }
            //}
            //else
            //{
            //    return new ErrorResult("Ən az bir ədəd translation olmalıdır");
            //}

            //await _unitOfWork.CourseRepository.AddAsync(course);
            //var result = await _unitOfWork.SaveAsync();

            //if (result == 0)
            //    return new ErrorResult("Kurs əlavə olunmadı");

            //return new SuccessResult("Kurs əlavə olundu");
        }
        public async Task<Core.Utilities.Result.Abstract.IResult> Delete(Guid id)
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(
                c => c.Id == id
            );

            if (course == null)
                return new ErrorResult(ExceptionMessage.CourseNotFound);

            if (!string.IsNullOrEmpty(course.ImageUrl))
            {
                _fileService.Delete(course.ImageUrl);
            }

            _unitOfWork.CourseRepository.Delete(course);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0)
                return new ErrorResult("kurs silinmedi");
            return new SuccessResult("kurs silindi");
        }

        public async Task<IDataResult<List<GetAllCourseDto>>> GetAllCoursesAsync()
        {
            var courses = await _unitOfWork.CourseRepository.GetAllAsync(null, "Lessons");
            if (courses.Count == 0)
            {
                return new ErrorDataResult<List<GetAllCourseDto>>(new List<GetAllCourseDto>(), "Hələ kurs əlavə edilməyib");
            }
            var courseDtos = _mapper.Map<List<GetAllCourseDto>>(courses);
            return new SuccessDataResult<List<GetAllCourseDto>>(courseDtos, "Kurs məlumatları gətirildi");
        }

        public async Task<IDataResult<GetCourseDto>> GetCourseByIdAsync(Guid id)
        {
            var result = await _unitOfWork.CourseRepository.GetAsync(c => c.Id == id, "Lessons");
            if (result is null)
            {
                return new ErrorDataResult<GetCourseDto>(null!, $"{id}-li kurs tapıldı");
            }

            var dto = _mapper.Map<GetCourseDto>(result);
            return new SuccessDataResult<GetCourseDto>(dto, $"{id}-li kurs tapılmadı");
        }

        public async Task<Core.Utilities.Result.Abstract.IResult> UpdateCourseAsync(Guid id, UpdateCourseDto updateCourseDto)
        {
            //var existsCourse = await _unitOfWork.CourseRepository.GetAsync(c => c.Id == id
            //);

            //if (existsCourse == null)
            //    return new ErrorResult("Tapılmaıdı");

            //if (updateCourseDTO.Translations != null)
            //{
            //    var langCodes = updateCourseDTO.Translations.Select(t => t.LanguageCode).ToList();

            //    foreach (var oldTrans in existsCourse.Translations.ToList())
            //    {
            //        if (!langCodes.Contains(oldTrans.LanguageCode))
            //        {
            //            existsCourse.Translations.Remove(oldTrans);
            //        }
            //    }

            //    foreach (var transDto in updateCourseDTO.Translations)
            //    {
            //        var translation = existsCourse.Translations.FirstOrDefault(t => t.LanguageCode == transDto.LanguageCode);

            //        if (translation != null)
            //        {
            //            var newTranslation = _mapper.Map<CourseTranslation>(transDto);
            //            newTranslation.CreatedAt = DateTime.UtcNow;
            //            existsCourse.Translations.Add(newTranslation);
            //        }
            //        else
            //        {
            //            _mapper.Map(transDto, translation);
            //            translation.UpdatedAt = DateTime.UtcNow;
            //        }
            //    }
            //}

            var existsCourse = await _unitOfWork.CourseRepository.GetAsync(c => c.Id == id);

            if (existsCourse == null)
                return new ErrorResult("Tapılmaıdı");

            existsCourse.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.CourseRepository.Update(existsCourse);

            var saveResult = await _unitOfWork.SaveAsync();

            return saveResult>0 ? new SuccessResult("Kurs yeniləndi")
                : new ErrorResult("Kurs yenilənmədi");
        }
    }
}
