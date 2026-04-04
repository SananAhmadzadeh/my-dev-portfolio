using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.VacancyDTOs;

namespace Business.Services.Concrete
{
    public class VacancyManager : IVacancyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VacancyManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddVacancyAsync(CreateVacancyDto dto)
        {
            var newVacancy = _mapper.Map<Vacancy>(dto);

            if (dto.SkillIds != null && dto.SkillIds.Any())
            {
                foreach (var skillId in dto.SkillIds)
                {
                    newVacancy.VacancySkills.Add(new VacancySkill
                    {
                        SkillId = skillId
                    });
                }
            }

            await _unitOfWork.VacancyRepository.AddAsync(newVacancy);

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
            {
                return new ErrorResult("Can not added Vacancy");
            }

            return new SuccessResult("Vacancy added success");
        }

        public async Task<IResult> DeleteVacancyAsync(Guid id)
        {
            var deletedVacancy = await _unitOfWork.VacancyRepository.GetAsync(v => v.Id == id);

            await _unitOfWork.VacancyRepository.Delete(deletedVacancy);

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
            {
                return new ErrorResult($"Failed to delete vacancy with id {id}");
            }

            return new SuccessResult("Vacancy deleted success");
        }

        public async Task<IDataResult<List<GetAllVacanciesDto>>> GetAllVacanciesAsync()
        {
            var result = await _unitOfWork.VacancyRepository.GetAllAsync(incudes: "VacancySkills.Skill");

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<GetAllVacanciesDto>>(_mapper.Map<List<GetAllVacanciesDto>>(result), "Vacancies can not listed");
            }

            return new SuccessDataResult<List<GetAllVacanciesDto>>(_mapper.Map<List<GetAllVacanciesDto>>(result), "Vacancies listed");
        }

        public async Task<IDataResult<GetVacancyDto>> GetVacancyByIdAsync(Guid id)
        {
            var result = await _unitOfWork.VacancyRepository.GetAsync(v => v.Id == id, incudes: "VacancySkills.Skill");

            if (result is null)
            {
                return new ErrorDataResult<GetVacancyDto>(_mapper.Map<GetVacancyDto>(result), "Vacancy can not listed");
            }

            return new SuccessDataResult<GetVacancyDto>(_mapper.Map<GetVacancyDto>(result), "Vacancy listed");
        }

        public async Task<IResult> UpdateVacancyAsync(Guid id, UpdateVacancyDto dto)
        {
            var vacancy = await _unitOfWork.VacancyRepository.GetAsync(v => v.Id == id, incudes: "VacancySkills");

            if (vacancy is null)
                return new ErrorResult("Vacancy not found");

            _mapper.Map(dto, vacancy);

            vacancy.VacancySkills.Clear();

            if (dto.SkillIds != null && dto.SkillIds.Any())
            {
                foreach (var skillId in dto.SkillIds)
                {
                    vacancy.VacancySkills.Add(new VacancySkill
                    {
                        SkillId = skillId
                    });
                }
            }

            await _unitOfWork.VacancyRepository.Update(vacancy);

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
                return new ErrorResult("Can not update Vacancy");

            return new SuccessResult("Vacancy updated successfully");
        }
    }
}
