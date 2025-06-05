using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Management_Schedule_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ODataController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAllCourses()
        {
            try
            {
                var courses = await _courseService.GetAllCoursesAsync();
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<ActionResult<CourseDTO>> GetCourseById(int id)
        {
            try
            {
                var course = await _courseService.GetCourseByIdAsync(id);
                if (course == null)
                    return NotFound(new { message = "Không tìm thấy khóa học" });
                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<CourseDTO>> CreateCourse([FromForm] CreateCourseDTO courseDto)
        {
            try
            {
                var course = await _courseService.CreateCourseAsync(courseDto);
                return Ok(new {message="Tạo khóa học thành công!"});
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Tên khóa học đã tồn tại!"))
                    return BadRequest(new { message = ex.Message });
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDTO>> UpdateCourse(int id,[FromForm] UpdateCourseDTO courseDto)
        {
            try
            {
                var course = await _courseService.UpdateCourseAsync(id, courseDto);
                if (course == null)
                    return NotFound(new { message = "Không tìm thấy khóa học" });
                return Ok(course);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Tên khóa học đã tồn tại!"))
                    return BadRequest(new { message = ex.Message });
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            try
            {
                var result = await _courseService.DeleteCourseAsync(id);
                if (!result)
                    return NotFound(new { message = "Không tìm thấy khóa học" });
                return Ok(new { message = "Xóa khóa học thành công" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpPatch("{id}/selling-status")]
        public async Task<ActionResult> UpdateCourseSellingStatus(int id, [FromBody] UpdateCourseSellingStatusDTO dto)
        {
            try
            {
                var result = await _courseService.UpdateCourseSellingStatusAsync(id, dto.isSelling);
                if (!result)
                    return NotFound(new { message = "Không tìm thấy khóa học" });
                return Ok(new { message = dto.isSelling ? "Đã bật trạng thái bán khóa học" : "Đã tắt trạng thái bán khóa học" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }
    }
} 