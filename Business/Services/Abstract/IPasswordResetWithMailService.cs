using Core.Utilities.Result.Abstract;
using Entities.DTOs.SetPasswordDTOs;
using Microsoft.AspNetCore.Identity;

namespace Business.Services.Abstract
{
    public interface IPasswordResetWithMailService
    {
        Task<IDataResult<IdentityResult>> SetPassword(SetPasswordDto dto);
    }
}
