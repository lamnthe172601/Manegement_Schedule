using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management_Schedule_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetAllUser()
        {
            var users = _userService.GetAllUser();
            if (users == Empty)
            {
                return Ok(new
                {
                    Message = "Empty user"
                });
            }
            return Ok(new
            {
                Message = "Success",
                data = users    
            });
        }
        [HttpPost]
        public IActionResult CreateUser(UserCreateDTO userCreateDTO)
        {
            if (_userService.CreateUser(userCreateDTO) == null)
            {
                return BadRequest(new { message = "Email đã tồn tại" });
            }
            else
            {
                return Ok(new { message = "Tạo tài khoản thành công" });
            }
        }
        [HttpPut("{email}")]
        public IActionResult UpdateUserByEmail(string email, UserUpdateDTO userUpdateDTO)
        {
            if (_userService.UpdateUser(email, userUpdateDTO) == null)
            {
                return BadRequest(new { message = "Email Không tồn tại" });
            }
            else
            {
                return Ok(new { 
                    message = "Update thành công",
                    data = userUpdateDTO
                });
            }
        }
        [HttpPut("profile/{email}")]
        public IActionResult UpdateProfileByEmail(string email, TeachStudentProfile profile)
        {
            _userService.UpdateProfile(email, profile);
            return Ok(new
            {
                message = "Update thành công",
                data = profile
            });
        }
        [HttpDelete("{email}")]
        public IActionResult DeleteUserByEmail(string email)
        {
            if (_userService.DeleteUser(email))
            {
                return Ok(new
                {
                    Message = "Delete success"
                });
            }
            return Ok(new
            {
                Message = "Delete fail"
            });
        }
        [HttpPost("update-password")]
        public IActionResult UpdatePasswordByEmail([FromBody] UpdatePasswordDTO updatePasswordDTO)
        {
            if(updatePasswordDTO.Password != updatePasswordDTO.ConfirmPassword)
            {
                return BadRequest(new
                {
                    Message = "password and confirm password is not match"
                });
            }
            _userService.UpdatePassword(updatePasswordDTO.Email, updatePasswordDTO.Password);
            return Ok(new
            {
                Message = "Update sucessfully"
            });
        }
    }
}
