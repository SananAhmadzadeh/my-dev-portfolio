using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Entities.Concrete.Auth;
using Core.Utilities.Exceptions;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.StudentDTOs;
using Microsoft.AspNetCore.Identity;

namespace Business.Services.Concrete;

public class StudentManager : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPdfService _pdfService;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IEmailService _emailService;
    public StudentManager(IUnitOfWork unitOfWork, IMapper mapper, IPdfService pdfService, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _pdfService = pdfService;
        _userManager = userManager;
        _roleManager = roleManager;
        _emailService = emailService;
    }

    public async Task<IResult> AddStudentAsync(CreateStudentDto dto)
    {
        var existingUser = await _userManager.FindByEmailAsync(dto.Email);
        if (existingUser != null)
            return new ErrorResult("Bu email artıq mövcuddur");
        var group = await _unitOfWork.EfGroupRepository
      .GetAsync(g => g.Id == dto.GroupId);

        if (group == null)
        {
            return new ErrorResult("Belə bir qrup mövcud deyil");
        }
        var user = _mapper.Map<AppUser>(dto);
        var userResult = await _userManager.CreateAsync(user);

        if (!userResult.Succeeded)
            return new ErrorResult(userResult.Errors.First().Description);

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var resetUrl =
            $"https://frontend.skillupit.az/set-password?userId={user.Id}&token={token}";

        await _emailService.SendEmailAsync(
            user.Email,
            "Şifrənizi təyin edin",
            $@"
        Salam {user.FullName},<br/><br/>
        Siz sistemə tələbə kimi əlavə edildiniz.<br/>
        Şifrənizi təyin etmək üçün link:<br/><br/>
        <a href='{resetUrl}'>Şifrəni təyin et</a><br/><br/>
        SkillUpIT Team
        ");
        if (!await _roleManager.RoleExistsAsync("Student"))
            await _roleManager.CreateAsync(new IdentityRole("Student"));

        await _userManager.AddToRoleAsync(user, "Student");

        var student = _mapper.Map<Student>(dto);
        student.AppUserId = user.Id;

        if (dto.CertificateUrl != null)
        {
            var uploadPath = await _pdfService
                .UploadAsync(dto.CertificateUrl, "StudentCertificates");
            student.CertificateUrl = uploadPath;
        }

        await _unitOfWork.StudentRepository.AddAsync(student);
        var saveResult = await _unitOfWork.SaveAsync();

        if (saveResult == 0)
            return new ErrorResult("Student əlavə edilə bilmədi");

        return new SuccessResult("Student uğurla əlavə edildi");
    }

    public async Task<IDataResult<List<GetAllStudentsDto>>> GetAllStudentsAsync()
    {
        var students = await _unitOfWork.StudentRepository
            .GetAllAsync(null, "AppUser");

        var mappedStudents = _mapper.Map<List<GetAllStudentsDto>>(students);

        if (!mappedStudents.Any())
            return new ErrorDataResult<List<GetAllStudentsDto>>(mappedStudents, "No students found");

        return new SuccessDataResult<List<GetAllStudentsDto>>(mappedStudents, "Students listed");
    }
    public async Task<IDataResult<GetStudentDto>> GetStudentByIdAsync(Guid id)
    {
        var student = await _unitOfWork.StudentRepository
            .GetAsync(s => s.Id == id, "AppUser");

        if (student == null)
            return new ErrorDataResult<GetStudentDto>(null, "Telebe tapilmadi");

        var mappedStudent = _mapper.Map<GetStudentDto>(student);

        return new SuccessDataResult<GetStudentDto>(mappedStudent, "Telebe tapildi");
    }

    public async Task<IResult> DeleteStudentAsync(Guid id)
    {
        var student = await _unitOfWork.StudentRepository
            .GetAsync(s => s.Id == id, "AppUser");

        if (student == null)
            return new ErrorResult("Telebe tapilmadi");

        _unitOfWork.StudentRepository.Delete(student);

        if (student.AppUser != null)
        {
            await _userManager.DeleteAsync(student.AppUser);
        }

        var saveResult = await _unitOfWork.SaveAsync();
        if (saveResult == null)
            return new ErrorResult("Telebe silinmedi");

        return new SuccessResult("Telebe silindi");
    }

    public async Task<IResult> UpdateStudentAsync(Guid id, UpdateStudentDto dto)
    {
        // 1️⃣ Mövcud student və AppUser al
        var student = await _unitOfWork.StudentRepository.GetAsync(s => s.Id == id);
        if (student == null)
            return new ErrorResult("Student tapılmadı");

        var appUser = await _userManager.FindByIdAsync(student.AppUserId);
        if (appUser == null)
            return new ErrorResult("Student-in AppUser-i tapılmadı");

        if (!string.IsNullOrWhiteSpace(dto.Address))
            student.Address = dto.Address;

        student.DateOfBirth = dto.DateOfBirth ?? student.DateOfBirth;
        student.GroupId = dto.GroupId ?? student.GroupId;

        student.UpdatedAt = DateTime.UtcNow;

        if (!string.IsNullOrWhiteSpace(dto.FullName))
            appUser.FullName = dto.FullName;

        if (!string.IsNullOrWhiteSpace(dto.UserName))
            appUser.UserName = dto.UserName;

        if (!string.IsNullOrWhiteSpace(dto.Email))
            appUser.Email = dto.Email;

        if (!string.IsNullOrWhiteSpace(dto.PhoneNumber))
            appUser.PhoneNumber = dto.PhoneNumber;
        student.DateOfBirth = dto.DateOfBirth ?? student.DateOfBirth;
        student.GroupId = dto.GroupId ?? student.GroupId;
        if (dto.GroupId.HasValue)
        {
            var groupExists = await _unitOfWork.EfGroupRepository
                .GetAllAsync(g => g.Id == dto.GroupId.Value);

            if (groupExists==null)
                return new ErrorResult("Belə bir qrup mövcud deyil");

            student.GroupId = dto.GroupId.Value;
        }

        if (dto.CertificateUrl != null)
        {
            var uploadPath = await _pdfService.UploadAsync(dto.CertificateUrl, "StudentCertificates");
            if (string.IsNullOrEmpty(uploadPath))
                return new ErrorResult("Sertifikat yüklənmədi");

            var graduate = new Graduate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

                Address = student.Address,
                DateOfBirth = student.DateOfBirth,
                GroupId = student.GroupId,
                IsCertificate = true,
                CertificateUrl = uploadPath,

                FullName = appUser.FullName,
                UserName = appUser.UserName,
                Email = appUser.Email,
                PhoneNumber = appUser.PhoneNumber,

                Password = appUser.PasswordHash
            };

            await _unitOfWork.GraduateRepository.AddAsync(graduate);

            // Student və AppUser sil
            _unitOfWork.StudentRepository.Delete(student);
            var deleteUserResult = await _userManager.DeleteAsync(appUser);
            if (!deleteUserResult.Succeeded)
                return new ErrorResult("AppUser silinmədi");

            await _unitOfWork.SaveAsync();

            return new SuccessResult("Student Graduate-ə köçürüldü");
        }

        // 5️⃣ Sertifikat yoxdursa → sadəcə update
        _unitOfWork.StudentRepository.Update(student);

        var updateUserResult = await _userManager.UpdateAsync(appUser);
        if (!updateUserResult.Succeeded)
            return new ErrorResult("AppUser yenilənmədi");

        await _unitOfWork.SaveAsync();

        return new SuccessResult("Student yeniləndi");
    }


}