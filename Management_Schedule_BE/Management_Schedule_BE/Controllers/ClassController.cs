using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.DTOs.ClassDTOs;
using Management_Schedule_BE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Management_Schedule_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ODataController
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<DetailedClassDTO>>> GetAllClasses()
        {
            try
            {
                var classes = await _classService.GetAllClassesAsync();
                return Ok(classes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<ActionResult<ClassDTO>> GetClassById(int id)
        {
            try
            {
                var c = await _classService.GetClassByIdAsync(id);
                if (c == null)
                    return NotFound(new { message = "Không tìm thấy lớp" });
                return Ok(c);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClassDTO>> CreateClass(CreateClassDTO classDto)
        {
            try
            {
                var c = await _classService.CreateClassAsync(classDto);
                return CreatedAtAction(nameof(GetClassById), new { id = c.ClassID }, c);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Tên lớp đã tồn tại"))
                    return BadRequest(new { message = ex.Message });
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClassDTO>> UpdateClass(int id, UpdateClassDTO classDto)
        {
            try
            {
                var c = await _classService.UpdateClassAsync(id, classDto);
                if (c == null)
                    return NotFound(new { message = "Không tìm thấy lớp" });
                return Ok(c);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Tên lớp đã tồn tại"))
                    return BadRequest(new { message = ex.Message });
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClass(int id)
        {
            try
            {
                var result = await _classService.DeleteClassAsync(id);
                if (!result)
                    return NotFound(new { message = "Không tìm thấy lớp" });
                return Ok(new { message = "Xóa lớp thành công" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpPatch("{id}/status")]
        public async Task<ActionResult> UpdateClassStatus(int id, [FromBody] UpdateClassStatusDTO dto)
        {
            try
            {
                var result = await _classService.UpdateClassStatusAsync(id, dto.Status);
                if (!result)
                    return NotFound(new { message = "Không tìm thấy lớp" });
                return Ok(new { message = "Cập nhật trạng thái lớp thành công" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpGet("student/{studentId}/enrolled")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<StudentEnrolledClassDTO>>> GetStudentEnrolledClasses(int studentId)
        {
            try
            {
                var classes = await _classService.GetStudentEnrolledClassesAsync(studentId);
                return Ok(classes);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Không tìm thấy học sinh"))
                    return NotFound(new { message = ex.Message });
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpGet("{classId}/students")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<StudentInClassDTO>>> GetStudentsInClass(int classId)
        {
            try
            {
                var students = await _classService.GetStudentsInClassAsync(classId);
                return Ok(students);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Không tìm thấy lớp học"))
                    return NotFound(new { message = ex.Message });
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpGet("basic")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<ClassBasicDTO>>> GetAllClassBasic()
        {
            try
            {
                var classes = await _classService.GetAllClassBasicAsync();
                return Ok(classes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }
    }
} 