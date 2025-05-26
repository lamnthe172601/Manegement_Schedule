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
        public IActionResult SignUp(UserCreateDTO userCreateDTO)
        {
            if(_userService.CreateUser(userCreateDTO) == null)
            {
                return BadRequest(new { message = "Email đã tồn tại" });
            }
            else
            {
                return Ok(new { message = "Đăng ký thành công" });
            }     
        }

        [HttpPost("SignIn")]

        public IActionResult SignIn(UserLogin userLogin)
        {
            var user = _userService.GetUserByEmailAndPassword(userLogin.Email, userLogin.PasswordHash);
            if(user != null)
            {
                string token = _jwtConfig.GenerateToken(user);
                return Ok(new { message = "Đăng nhập thành công", data = token });
            }
            return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng" });
        }
        [HttpGet("DemoAuthor")]
        [Authorize(Roles = "Admin")]
        public IActionResult Demo()
        {
            return Ok(new { message = "Authorization success" });
        }
    }
}
