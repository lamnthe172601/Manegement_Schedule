using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace Management_Schedule_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDTO>>> GetAllClasses()
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
        public async Task<ActionResult<ClassDTO>> GetClassById(int id)
        {
            try
            {
                var c = await _classService.GetClassByIdAsync(id);
                if (c == null)
                    return NotFound();
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
                    return NotFound();
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
                    return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }
    }
} 