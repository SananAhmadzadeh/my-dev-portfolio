using Core.Utilities.Result.Abstract;
using Entities.DTOs.ContactDTOs;

namespace Business.Services.Abstract
{
    public interface IUserMessageService
    {
        Task<IResult> CreateUserMessageAsync(UserMessageDTO userMessageDTO);
    }
}
