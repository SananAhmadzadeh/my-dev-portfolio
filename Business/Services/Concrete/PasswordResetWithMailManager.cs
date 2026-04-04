using Business.Services.Abstract;
using Core.Entities.Concrete.Auth;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.DTOs.SetPasswordDTOs;
using Microsoft.AspNetCore.Identity;

namespace Business.Services.Concrete
{
    public class PasswordResetWithMailManager : IPasswordResetWithMailService
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordResetWithMailManager(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IDataResult<IdentityResult>> SetPassword(SetPasswordDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null)
                return new ErrorDataResult<IdentityResult>("User not found");

            var result = await _userManager.ResetPasswordAsync(
                user,
                dto.Token,
                dto.NewPassword
            );

            if (!result.Succeeded)
                return new ErrorDataResult<IdentityResult>(
                    result.Errors.First().Description
                );

            return new SuccessDataResult<IdentityResult>(
                result,
                "Password successfully set"
            );
        }
    }
}
