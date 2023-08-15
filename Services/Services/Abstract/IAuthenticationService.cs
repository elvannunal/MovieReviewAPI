using Entities.Dto;
using Microsoft.AspNetCore.Identity;
using Services.Concrete;

namespace Services.Abstract;

public  interface IAuthenticationService
{
    public  Task<IdentityResult> RegisterUser(UserRegisterDto userRegister);
    public  Task<bool> LoginUser(UserLoginDto userLoginDto);
    public Task<string> GenerateTokenOptions();
}