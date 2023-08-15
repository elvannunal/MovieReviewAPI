using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Entities.Dto;
using Entities.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Abstract;

namespace Services.Concrete;

public class AuthenticationService:IAuthenticationService
{ 
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    private User? _user;

    public AuthenticationService(
        IMapper mapper, 
        UserManager<User> userManager, 
        IConfiguration configuration)
    {
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration;
    }
    public async Task<IdentityResult> RegisterUser(UserRegisterDto userRegister)
    {
        var user = _mapper.Map<User>(userRegister);

        var result = await _userManager.CreateAsync(user, userRegister.Password);

        if (result.Succeeded)
        {
            foreach (var roleName in userRegister.Roles)
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
        }

        return result;
    }
    
    public async Task<bool> LoginUser(UserLoginDto userLoginDto)
    {
        _user = await _userManager.FindByNameAsync(userLoginDto.UserName);
        var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userLoginDto.Password));
        return result;
    }

    
    public async Task<string> GenerateTokenOptions()
    {
        var signinCredentials = GetSignInCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signinCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, _user.UserName)
        };

        var roles = await _userManager
            .GetRolesAsync(_user);

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        return claims;
    }
    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, 
        List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");

        var tokenOptions = new JwtSecurityToken(
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signinCredentials);
            
        return tokenOptions;
    }

    private SigningCredentials GetSignInCredentials()
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
        var secretkey = new SymmetricSecurityKey(key);
        return new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
    }
}