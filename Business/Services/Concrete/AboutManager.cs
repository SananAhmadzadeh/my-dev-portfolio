using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.AboutDTOs;

namespace Business.Services.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AboutManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddAboutAsync(CreateAboutDTO createAboutDTO)
        { 

            var newAbout = _mapper.Map<About>(createAboutDTO);

            await _unitOfWork.AboutRepository.AddAsync(newAbout);

            var saveResult = await _unitOfWork.SaveAsync();

            return saveResult > 0 ? new SuccessResult("Haqqımızda hissəsi əlavə edildi")
                : new ErrorResult("Haqqımızda hissəsi əlavə edilmədi");
        }

        public async Task<IResult> DeleteAboutAsync(Guid aboutId)
        {
            var deleteAbout = await _unitOfWork.AboutRepository.GetAsync(a=> a.Id == aboutId);

            if (deleteAbout == null)
            {
                return new ErrorResult("Haqqımızda hissəsi tapılmadı");
            }

            _unitOfWork.AboutRepository.Delete(deleteAbout);

            var saveResult = await _unitOfWork.SaveAsync();

            return saveResult > 0 ? new SuccessResult("Haqqımızda hissəsi silindi")
                     : new ErrorResult("Haqqımızda hissəsi silindi"); 
        }



        public async Task<IDataResult<GetAboutDTO>> GetAboutByIdAsync(Guid id)
        { 
            var result = await _unitOfWork.AboutRepository.GetAsync(a => a.Id == id);
            if(result is null )
                return new ErrorDataResult<GetAboutDTO>(_mapper.Map<GetAboutDTO>(result), $"{id} - li haqqımızda hissəsi tapılmadı");
            else
                return new SuccessDataResult<GetAboutDTO>(_mapper.Map<GetAboutDTO>(result), $"{id} - li haqqımızda hissəsi tapıldı");
        }

        public async Task<IDataResult<List<GetAllAboutDTO>>> GetAllAboutsAsync()
        {
            var result = await _unitOfWork.AboutRepository.GetAllAsync();

            if (result == null || !result.Any())
            {

                return new ErrorDataResult<List<GetAllAboutDTO>>("List edilə bilmədi");
            }

            var mappedResult = _mapper.Map<List<GetAllAboutDTO>>(result);

            return new SuccessDataResult<List<GetAllAboutDTO>>(mappedResult, "List edildi");
        }


        public async Task<IResult> UpdateAboutAsync(Guid id, UpdateAboutDTO dto)
        {
            var update = await _unitOfWork.AboutRepository.GetAsync(a => a.Id == id);

            if(update is null )
                return new ErrorResult($"{id} - li haqqımızda hissəsi tapılmadı");

            _mapper.Map(dto, update);

            await _unitOfWork.AboutRepository.Update(update);

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
                return new ErrorResult("Update edilə bilmədi");

            return new SuccessResult("Update edildi");
        }

    }
}