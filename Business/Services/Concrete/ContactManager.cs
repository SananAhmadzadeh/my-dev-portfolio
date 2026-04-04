using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.ContactDTOs;

namespace Business.Services.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<ContactDTO>>> GetContactInfosAsync()
        {
            var contacts = await _unitOfWork.ContactRepository.GetAllAsync(
                null,
                nameof(Contact.ContactItems)
            );
            var contactInfos = _mapper.Map<List<ContactDTO>>(contacts);

            return new SuccessDataResult<List<ContactDTO>>(contactInfos);
        }

    }
}
