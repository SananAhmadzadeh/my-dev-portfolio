using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Entities.Concrete.Auth;
using Core.Utilities.Exceptions;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.CourseDTOs;
using Entities.DTOs.GraduateDTOs;
using Entities.DTOs.StudentDTOs;
using Microsoft.AspNetCore.Identity;

namespace Business.Services.Concrete
{
    public class GraduateManager : IGraduateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly UserManager<AppUser> _userManager;
        public GraduateManager(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
            _userManager = userManager;
        }

        public async Task<IResult> DeleteGraduateAsync(Guid id)
        {
            var dbGraduates = await _unitOfWork.GraduateRepository.GetAsync(a => a.Id == id);
            if (dbGraduates is null)
                return new ErrorResult("mezun tapilmadi");
            _unitOfWork.GraduateRepository.Delete(dbGraduates);
            var result = await _unitOfWork.SaveAsync();
            if (result == 0)
                return new ErrorResult("mezun silinmedi.");
            return new SuccessResult("mezun silindi");
        }
        public async Task<IDataResult<List<GetAllGraduatesDto>>> GetAllGraduatesAsync()
        {
            var dbGraduates = await _unitOfWork.GraduateRepository.GetAllAsync(null);
            if (dbGraduates.Count == 0)
                return new ErrorDataResult<List<GetAllGraduatesDto>>(_mapper.Map<List<GetAllGraduatesDto>>(dbGraduates), "mezunlar tapilmadi");
            return new SuccessDataResult<List<GetAllGraduatesDto>>(_mapper.Map<List<GetAllGraduatesDto>>(dbGraduates), "mezunlar tapildi");
        }
        public async Task<IDataResult<GetGraduateDto>> GetGraduateByIdAsync(Guid id)
        {
            var dbGraduates = await _unitOfWork.GraduateRepository.GetAsync(a => a.Id == id);
            if (dbGraduates is null)
                return new ErrorDataResult<GetGraduateDto>(_mapper.Map<GetGraduateDto>(dbGraduates), $"{id} - mezun tapildi");
            return new SuccessDataResult<GetGraduateDto>(_mapper.Map<GetGraduateDto>(dbGraduates), $"mezun tapilmadi ");
        }

        public async Task<IResult> UpdateGraduateAsync(Guid id, UpdateGraduateDto dto)
        {
            var graduate = await _unitOfWork.GraduateRepository.GetAsync(g => g.Id == id);
            if (graduate == null)
                return new ErrorResult("Mezun tapılmadı");

            _mapper.Map(dto, graduate);

            await _unitOfWork.GraduateRepository.Update(graduate);

            _mapper.Map(dto, graduate);

            _unitOfWork.GraduateRepository.Update(graduate);

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
                return new ErrorResult("Graduate yenilənmədi");

            return new SuccessResult("Graduate uğurla yeniləndi");
        }
    }
}
