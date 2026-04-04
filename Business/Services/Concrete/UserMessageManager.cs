using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.ContactDTOs;

namespace Business.Services.Concrete
{
    public class UserMessageManager : IUserMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserMessageManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> CreateUserMessageAsync(UserMessageDTO userMessageDTO)
        {
            var result = _mapper.Map<UserMessage>(userMessageDTO);

            await _unitOfWork.UserMessageRepository.AddAsync(result);

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
                return new ErrorResult("Message added failed");

            return new SuccessResult("Message added success");
        }
    }
}
