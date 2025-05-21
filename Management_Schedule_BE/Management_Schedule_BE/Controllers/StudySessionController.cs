using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Management_Schedule_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudySessionController : ODataController
    {
        private readonly IStudySessionService _studySessionService;

        public StudySessionController(IStudySessionService studySessionService)
        {
            _studySessionService = studySessionService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<StudySessionDTO>>> GetAllStudySessions()
        {
            try
            {
                var sessions = await _studySessionService.GetAllStudySessionsAsync();
                return Ok(sessions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<ActionResult<StudySessionDTO>> GetStudySessionById(int id)
        {
            try
            {
                var session = await _studySessionService.GetStudySessionByIdAsync(id);
                if (session == null)
                    return NotFound();
                return Ok(session);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudySessionDTO>> CreateStudySession(CreateStudySessionDTO dto)
        {
            try
            {
                var session = await _studySessionService.CreateStudySessionAsync(dto);
                return CreatedAtAction(nameof(GetStudySessionById), new { id = session.StudySessionId }, session);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Tên ca học đã tồn tại"))
                    return BadRequest(new { message = ex.Message });
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudySessionDTO>> UpdateStudySession(int id, UpdateStudySessionDTO dto)
        {
            try
            {
                var session = await _studySessionService.UpdateStudySessionAsync(id, dto);
                if (session == null)
                    return NotFound();
                return Ok(session);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Tên ca học đã tồn tại"))
                    return BadRequest(new { message = ex.Message });
                return StatusCode(500, new { message = "Đã xảy ra lỗi hệ thống!", detail = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudySession(int id)
        {
            try
            {
                var result = await _studySessionService.DeleteStudySessionAsync(id);
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