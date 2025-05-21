using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Services;
using Management_Schedule_BE.Services.SystemSerivce;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Management_Schedule_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly JWTConfig _jwtConfig;

        public AuthenticationController(IUserService userService, IConfiguration configuration, JWTConfig jwtConfig)
        {
            _userService = userService;
            _configuration = configuration;
            _jwtConfig = jwtConfig;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserCreateDTO userCreateDTO)
        {
            if(_userService.CreateUserAsync(userCreateDTO) == null)
            {
                return Ok(new
                {
                    message = "duplicate email"
                });
            }
            
            return Ok(new
            {
                message = "Register succesfu",
                StatusCode = 200
            });
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(UserLogin userLogin)
        {
            var user = await _userService.GetUserByEmailAndPasswordAsync(userLogin.Email, userLogin.PasswordHash);
            if(user != null)
            {

                

                string token = _jwtConfig.GenerateToken(user);
                return Ok(new
                {
                    Success = true,
                    Message = "Authenticate success",
                    Data = token
                });
            }
            return Ok(new
            {
                message = "User or pass is not correct"
            });
        }
        [HttpGet("DemoAuthor")]
        [Authorize(Roles = "Student")]
        public IActionResult Demo()
        {
            return Ok(new
            {
                message = "Authorization success"
            });
        }
    }
}
