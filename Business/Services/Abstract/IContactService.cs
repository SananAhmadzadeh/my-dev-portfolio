using Core.Utilities.Result.Abstract;
using Entities.DTOs.ContactDTOs;

namespace Business.Services.Abstract
{
    public interface IContactService
    {
        Task<IDataResult<List<ContactDTO>>> GetContactInfosAsync();
    }
}
