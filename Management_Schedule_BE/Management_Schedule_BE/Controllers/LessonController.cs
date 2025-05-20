using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace Management_Schedule_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDTO>>> GetAllLessons()
        {
            try
            {
                var lessons = await _lessonService.GetAllLessonsAsync();
                return Ok(lessons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LessonDTO>> GetLessonById(int id)
        {
            try
            {
                var lesson = await _lessonService.GetLessonByIdAsync(id);
                if (lesson == null)
                    return NotFound();
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<LessonDTO>> CreateLesson(CreateLessonDTO lessonDto)
        {
            try
            {
                var lesson = await _lessonService.CreateLessonAsync(lessonDto);
                return CreatedAtAction(nameof(GetLessonById), new { id = lesson.LessonID }, lesson);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Tên bài học đã tồn tại"))
                    return BadRequest(new { message = ex.Message });
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LessonDTO>> UpdateLesson(int id, UpdateLessonDTO lessonDto)
        {
            try
            {
                var lesson = await _lessonService.UpdateLessonAsync(id, lessonDto);
                if (lesson == null)
                    return NotFound();
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Tên bài học đã tồn tại"))
                    return BadRequest(new { message = ex.Message });
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLesson(int id)
        {
            try
            {
                var result = await _lessonService.DeleteLessonAsync(id);
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