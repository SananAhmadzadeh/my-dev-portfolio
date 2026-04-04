using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.SkillDTOs;

namespace Business.Services.Concrete
{
    public class SkillManager : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SkillManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddSkillAsync(CreateSkillDto dto)
        {
            var newSkill = _mapper.Map<Skill>(dto);

            await _unitOfWork.SkillRepository.AddAsync(newSkill);

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
            {
                return new ErrorResult("Can not added Skill");
            }

            return new SuccessResult("Skill added success");
        }

        public async Task<IResult> DeleteSkillAsync(Guid id)
        {
            var deletedSkill = await _unitOfWork.SkillRepository.GetAsync(s=> s.Id == id);

            await _unitOfWork.SkillRepository.Delete(deletedSkill);

            var saveResult = await _unitOfWork.SaveAsync();

            if(saveResult == 0)
            {
                return new ErrorResult($"Failed to delete skill with id {id}");
            }

            return new SuccessResult("Skill deleted success");
        }

        public async Task<IDataResult<List<GetAllSkillsDto>>> GetAllSkillsAsync()
        {
            var result = await _unitOfWork.SkillRepository.GetAllAsync();

            if(result.Count == 0)
            {
                return new ErrorDataResult<List<GetAllSkillsDto>>(_mapper.Map<List<GetAllSkillsDto>>(result), "Skills can not listed");
            }

            return new SuccessDataResult<List<GetAllSkillsDto>>(_mapper.Map<List<GetAllSkillsDto>>(result), "Skills listed");
        }

        public async Task<IDataResult<GetSkillDto>> GetSkillByIdAsync(Guid id)
        {
            var result = await _unitOfWork.SkillRepository.GetAsync(s => s.Id == id);

            if(result is null)
            {
                return new ErrorDataResult<GetSkillDto>(_mapper.Map<GetSkillDto>(result), "Skill can not listed");
            }

            return new SuccessDataResult<GetSkillDto>(_mapper.Map<GetSkillDto>(result), "Skill listed");
        }

        public async Task<IResult> UpdateSkillAsync(Guid id, UpdateSkillDto dto)
        {
            var skill = await _unitOfWork.SkillRepository.GetAsync(s => s.Id == id);

            if (skill is null)
                return new ErrorResult("Skill not found");

            _mapper.Map(dto, skill);

            await _unitOfWork.SkillRepository.Update(skill);

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
                return new ErrorResult("Can not update Skill");

            return new SuccessResult("Skill updated successfully");
        }
    }
}
