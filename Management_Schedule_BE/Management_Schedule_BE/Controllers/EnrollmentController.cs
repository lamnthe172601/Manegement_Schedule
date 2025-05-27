using Management_Schedule_BE.Data;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Management_Schedule_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly ApplicationDbContext _context;

        public EnrollmentController(
            IEnrollmentService enrollmentService,
            ApplicationDbContext context)
        {
            _enrollmentService = enrollmentService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<EnrollmentDTO>> CreateEnrollment([FromBody] CreateEnrollmentDTO enrollmentDto)
        {
            try
            {
                // Lấy Email từ token (ưu tiên claim 'email', fallback sang User.Identity.Name)
                var email = User.FindFirst("email")?.Value ?? User.Identity?.Name;
                if (string.IsNullOrEmpty(email))
                    return Unauthorized(new { message = "Không tìm thấy thông tin người dùng" });

                // Tìm StudentID từ Email
                var student = await _context.Students
                    .Include(s => s.User)
                    .FirstOrDefaultAsync(s => s.User.Email == email);

                if (student == null)
                    return Unauthorized(new { message = "Không tìm thấy thông tin học sinh" });

                var enrollment = await _enrollmentService.CreateEnrollmentAsync(student.StudentID, enrollmentDto);
                if (enrollment == null)
                    return NotFound(new { message = "Không tìm thấy lớp học" });
                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpGet("me")]
        public async Task<ActionResult<IEnumerable<EnrollmentDetailDTO>>> GetMyEnrollments()
        {
            try
            {
                // Lấy Email từ token (ưu tiên claim 'email', fallback sang User.Identity.Name)
                var email = User.FindFirst("email")?.Value ?? User.Identity?.Name;
                if (string.IsNullOrEmpty(email))
                    return Unauthorized(new { message = "Không tìm thấy thông tin người dùng" });

                // Tìm StudentID từ Email
                var student = await _context.Students
                    .Include(s => s.User)
                    .FirstOrDefaultAsync(s => s.User.Email == email);

                if (student == null)
                    return Unauthorized(new { message = "Không tìm thấy thông tin học sinh" });

                var enrollments = await _enrollmentService.GetStudentEnrollmentsAsync(student.StudentID);
                return Ok(enrollments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentDetailDTO>> GetEnrollmentById(int id)
        {
            try
            {
                var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
                if (enrollment == null)
                    return NotFound(new { message = "Không tìm thấy thông tin đăng ký" });

                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }
    }
} 