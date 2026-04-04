using Core.Entities.Concrete.Auth;
using Core.Utilities.Result.Abstract;
using Entities.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstract
{
    public interface IAuthService
    {
        public Task<IResult> Register(RegisterDto register);
        public Task<IDataResult<TokenDto>> Login(LoginDto login);
    }
}
