using AutoMapper;
using Business.Services.Abstract;
using Core.Entities.Concrete.Auth;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.DTOs.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Services.Concrete.Auth
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        IMapper _mapper;
        private IConfiguration _configuration;
        private readonly TokenOption _tokenOption;
        public AuthManager(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _configuration = configuration;
            _tokenOption = _configuration.GetSection("TokenOptions").Get<TokenOption>();
        }
        private async Task<TokenDto> CreateTokenAsync(AppUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOption.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var claims = new List<Claim>
            {
                  new Claim(ClaimTypes.NameIdentifier, user.Id),
                   new Claim(ClaimTypes.Name, user.UserName),
                   new Claim(ClaimTypes.Email, user.Email)
                             };

            var roles = await _userManager.GetRolesAsync(user);
            roles.ToList().ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));

            var token = new JwtSecurityToken(
                issuer: _tokenOption.Issuer,
                audience: _tokenOption.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_tokenOption.AccessTokenExpiration),
                signingCredentials: creds
            );

            return new TokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
        public async Task<IDataResult<TokenDto>> Login(LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null)
                return new ErrorDataResult<TokenDto>("İstifadəçi tapılmadı");

            var checkPassword = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!checkPassword)
                return new ErrorDataResult<TokenDto>("Şifrə yanlışdır");

            user.IsOnline = true;
            await _userManager.UpdateAsync(user);

            var token = await CreateTokenAsync(user);
            return new SuccessDataResult<TokenDto>(token, "Uğurla giriş edildi");
        }
        public async Task<IResult> Register(RegisterDto register)
        {
            var existUser = await _userManager.FindByEmailAsync(register.Email);
            if (existUser != null)
                return new ErrorResult("Bu email artıq qeydiyyatdan keçib");

            var user = _mapper.Map<AppUser>(register);

            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
                return new ErrorResult("İstifadəçi yaradıla bilmədi");

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }
            await _userManager.AddToRoleAsync(user, "User");

            return new SuccessResult("İstifadəçi yaradıldı");
        }
    }
}
