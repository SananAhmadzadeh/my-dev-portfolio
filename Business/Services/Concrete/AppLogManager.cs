using AutoMapper;
using Business.Services.Abstract;
using Core.Entities.DTOs;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;

namespace Business.Services.Concrete
{
    public class AppLogManager : IAppLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppLogManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllAppLogsDto>>> GetAllAppLogsAsync()
        {
            var applogs = await _unitOfWork.AppLogRepository.GetAllAsync();

            var applogsDto = _mapper.Map<List<GetAllAppLogsDto>>(applogs);

            if(applogsDto.Count > 0)
            {
                return new SuccessDataResult<List<GetAllAppLogsDto>>(applogsDto, "App logs retrieved successfully.");
            }
            else
            {
                return new ErrorDataResult<List<GetAllAppLogsDto>>(null, "No app logs found.");
            }
        }
    }
}
