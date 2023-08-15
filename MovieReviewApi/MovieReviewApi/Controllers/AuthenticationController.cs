using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Entities.Dto;

namespace MovieReviewApi.Controllers
{
    [ApiController]
    [Route("api/Authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult RegisterUser([FromBody] UserRegisterDto userRegister)
        {
            var result = _service.RegisterUser(userRegister);

            if (!result.Result.Succeeded)
            {
                foreach (var error in result.Result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }
        
        [HttpPost("login")]
   
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto user)
        {
            if (!await _service.LoginUser(user))
                return Unauthorized();
            
            var tokenDto = await _service.GenerateTokenOptions();

            return Ok(tokenDto);
        }

    }
}
