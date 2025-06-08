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
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAllUserAsync();
            if (!users.Any())
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
        public async Task<IActionResult> CreateUser([FromForm]UserCreateDTO userCreateDTO)
        {
            var result = await _userService.CreateUserAsync(userCreateDTO);
            if (result == null)
            {
                return BadRequest(new { message = "Email đã tồn tại" });
            }
            return Ok(new { message = "Tạo tài khoản thành công" });
        }

        [HttpPut("{email}")]
        public async Task<IActionResult> UpdateUserByEmail(string email, [FromForm] UserUpdateDTO userUpdateDTO)
        {
            var result = await _userService.UpdateUserAsync(email, userUpdateDTO);
            if (result == null)
            {
                return BadRequest(new { message = "Email Không tồn tại" });
            }
            return Ok(new { 
                message = "Update thành công",
                data = userUpdateDTO
            });
        }

        [HttpPut("profile/{email}")]
        public async Task<IActionResult> UpdateProfileByEmail(string email, [FromForm] TeachStudentProfile profile)
        {
            var result = await _userService.UpdateProfileAsync(email, profile);
            if (result == null)
            {
                return BadRequest(new { message = "Email không tồn tại" });
            }
            return Ok(new
            {
                message = "Update thành công",
                data = result
            });
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user != null)
            {
                return Ok(new
                {
                    Message = "Successfull",
                    data = user
                });
            }
            return Ok(new
            {
                Message = "fail data not exits"
            });
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteUserByEmail(string email)
        {
            var result = await _userService.DeleteUserAsync(email);
            if (result)
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
        public async Task<IActionResult> UpdatePasswordByEmail([FromBody] UpdatePasswordDTO updatePasswordDTO)
        {
            if(updatePasswordDTO.Password != updatePasswordDTO.ConfirmPassword)
            {
                return BadRequest(new
                {
                    Message = "password and confirm password is not match"
                });
            }
            var result = await _userService.UpdatePasswordAsync(updatePasswordDTO.Email, updatePasswordDTO.Password);
            if (result == null)
            {
                return BadRequest(new { message = "Email không tồn tại" });
            }
            return Ok(new
            {
                Message = "Update sucessfully"
            });
        }

        [HttpPost("by-admin")]
        public async Task<ActionResult<UserDTO>> AddUserByAdmin([FromForm] UserCreateByAdminDTO dto)
        {
            try
            {
                var user = await _userService.AddUserByAdminAsync(dto);
                if (user == null)
                    return BadRequest(new { message = "Email đã tồn tại!" });
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }
    }
}
