using AutoMapper;
using Business.Services.Abstract;
using Core.Entities.Concrete.Auth;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.TeacherDTOs;
using Microsoft.AspNetCore.Identity;

namespace Business.Services.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;

        public TeacherManager(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IFileService fileService, IPasswordHasher<AppUser> passwordHasher, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
        }
        public async Task<IResult> AddTeacherAsync(CreateTeacherDto dto)
        {
            var user = _mapper.Map<AppUser>(dto);
            var userResult = await _userManager.CreateAsync(user);
            if (!userResult.Succeeded)
                return new ErrorResult(userResult.Errors.First().Description);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetUrl = $"https://frontend.skillupit.az/set-password?userId={user.Id}&token={token}";

            await _emailService.SendEmailAsync(
                user.Email,
                "Şifrənizi təyin edin",
                $@"
        Salam {user.FullName},
        Siz sistemə müəllim kimi əlavə edildiniz.
        Şifrənizi təyin etmək üçün aşağıdakı linkə keçin:
        <a href='{resetUrl}'>Şifrəni təyin et</a>
        Uğurlar!
        SkillUpIT Team
        "
            );

            if (!await _roleManager.RoleExistsAsync("Teacher"))
                await _roleManager.CreateAsync(new IdentityRole("Teacher"));

            await _userManager.AddToRoleAsync(user, "Teacher");

            var teacher = _mapper.Map<Teacher>(dto);
            teacher.AppUserId = user.Id;

            if (dto.ImageUrl != null)
            {
                var uploadPath = await _fileService.UploadAsync(dto.ImageUrl, "Teachers");
                teacher.ImageUrl = uploadPath ?? null;
            }
            else
            {
                teacher.ImageUrl = null;
            }

            await _unitOfWork.TeacherRepository.AddAsync(teacher);
            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
                return new ErrorResult("Teacher add failed");

            return new SuccessResult("Teacher added successfully");
        }

        public async Task<IResult> DeleteTeacherAsync(Guid id)
        {
            var teacher = await _unitOfWork.TeacherRepository.GetAsync(
                t => t.Id == id,
                 "AppUser"
            );

            if (teacher == null)
                return new ErrorResult("Teacher tapılmadı");

            _fileService.Delete(teacher.ImageUrl);

            _unitOfWork.TeacherRepository.Delete(teacher);

            if (teacher.AppUser != null)
            {
                var userDeleteResult = await _userManager.DeleteAsync(teacher.AppUser);
                if (!userDeleteResult.Succeeded)
                {
                    return new ErrorResult("Teacher-in AppUser-i silinə bilmədi");
                }
            }

            var result = await _unitOfWork.SaveAsync();
            if (result == 0)
                return new ErrorResult("Teacher silinmədi");

            return new SuccessResult("Teacher uğurla silindi");
        }

        public async Task<IDataResult<List<GetAllTeachersDto>>> GetAllTeachersAsync()
        {
            var teachers = await _unitOfWork.TeacherRepository.GetAllAsync(null, "AppUser");
            if (teachers == null || !teachers.Any())
                return new ErrorDataResult<List<GetAllTeachersDto>>("No teachers found");
            var teacherDtos = _mapper.Map<List<GetAllTeachersDto>>(teachers);
            return new SuccessDataResult<List<GetAllTeachersDto>>(teacherDtos);
        }
        public async Task<IDataResult<GetTeacherDto>> GetTeacherByIdAsync(Guid id)
        {
            var teacher = await _unitOfWork.TeacherRepository
                .GetAsync(t => t.Id == id, "AppUser");
            if (teacher == null)
                return new ErrorDataResult<GetTeacherDto>("melumat tapilmadi");
            var teacherDto = _mapper.Map<GetTeacherDto>(teacher);
            return new SuccessDataResult<GetTeacherDto>(teacherDto, "melumat getirildi");
        }


        public async Task<IResult> UpdateTeacherAsync(Guid id, UpdateTeacherDto dto)
        {
            var teacher = await _unitOfWork.TeacherRepository.GetAsync(t => t.Id == id);
            if (teacher == null)
                return new ErrorResult("melumat tapilmadi");

            var appUser = await _userManager.FindByIdAsync(teacher.AppUserId);
            if (appUser == null)
                return new ErrorResult("teacher-in AppUser-i tapılmadı");

            _mapper.Map(dto, teacher);

            _mapper.Map(dto, appUser);

            var userUpdateResult = await _userManager.UpdateAsync(appUser);
            if (!userUpdateResult.Succeeded)
                return new ErrorResult("AppUser yenilənmədi");

            _unitOfWork.TeacherRepository.Update(teacher);

            var saved = await _unitOfWork.SaveAsync();
            if (saved == 0)
                return new ErrorResult("Teacher not updated");

            return new SuccessResult("Teacher updated");
        }

        //if(updateTeacherDto.ImageFile != null)
        //{
        //    if (!string.IsNullOrEmpty(existsTeacher.ImageUrl))
        //    {
        //        _fileService.Delete(existsTeacher.ImageUrl);
        //    }
        //    existsTeacher.ImageUrl = await _fileService.UploadAsync(updateTeacherDto.ImageFile, "teachers");
        //}
    }
}

