using Azure.Core;
using Google.Apis.Auth;
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
        private readonly IEmailService _emailService;

        public AuthenticationController(IEmailService emailService, IUserService userService, IConfiguration configuration, JWTConfig jwtConfig)
        {
            _userService = userService;
            _configuration = configuration;
            _jwtConfig = jwtConfig;
            _emailService = emailService;
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
        [HttpPost("login-google")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] GoogleLoginRequest request)
        {
            var googleClientId = _configuration["Authentication:Google:ClientId"];
            if(string.IsNullOrEmpty(googleClientId))
            {
                return BadRequest("Google ClientId is not configured.");
            }
            try
            {
                //confirm id with google
                var validationSettings = new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new[] { googleClientId }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, validationSettings);
                //process logic
                //check emails exits in database
                var user = _userService.GetUserByEmail(payload.Email);

                if (user != null)
                {
                    string token = _jwtConfig.GenerateToken(user);
                    return Ok(new { message = "Đăng nhập thành công", data = token });
                }
                else
                {
                    return Ok(new { Message = "Email not exits in email" });
                }
            }
            catch (InvalidJwtException)
            {
                return Unauthorized("Invalid Google token.");
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] SendOtpRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                
                return BadRequest(ModelState); 
            }
            try
            {
                string otp = EmailService.GenerateOtp();
                await _emailService.SendOtpEmailAsync(request.Email, otp);
                return Ok(new { Message = "Mã OTP đã được gửi thành công đến email của bạn." });
            }
            catch (ApplicationException appEx) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Đã xảy ra lỗi trong quá trình xử lý yêu cầu.", Details = appEx.Message });
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Đã có lỗi không mong muốn xảy ra. Vui lòng thử lại sau." });
            }
        }

        [HttpGet("DemoAuthor")]
        [Authorize(Roles = "Student")]
        public IActionResult Demo()
        {
            return Ok(new { message = "Authorization success" });
        }

    }
}
