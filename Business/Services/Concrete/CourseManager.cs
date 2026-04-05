using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Exceptions;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.CourseDTOs;


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
                return new ErrorDataResult<GetCourseDto>(null!, $"{id}-li kurs tapılmadı");
            }

            var dto = _mapper.Map<GetCourseDto>(result);
            return new SuccessDataResult<GetCourseDto>(dto, $"{id}-li kurs tapıldı");
        }

        public async Task<Core.Utilities.Result.Abstract.IResult> UpdateCourseAsync(Guid id, UpdateCourseDto updateCourseDto)
        {
            var existsCourse = await _unitOfWork.CourseRepository.GetAsync(c => c.Id == id);

            if (existsCourse == null)
                return new ErrorResult("Tapılmaıdı");

            _mapper.Map(updateCourseDto, existsCourse);

            existsCourse.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.CourseRepository.Update(existsCourse);

            var saveResult = await _unitOfWork.SaveAsync();

            return saveResult>0 ? new SuccessResult("Kurs yeniləndi")
                : new ErrorResult("Kurs yenilənmədi");
        }
    }
}
