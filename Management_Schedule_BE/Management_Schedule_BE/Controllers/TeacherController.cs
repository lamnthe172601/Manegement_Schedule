using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Management_Schedule_BE.Services;
using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IScheduleService _scheduleService;

        public TeacherController(ITeacherService teacherService, IScheduleService scheduleService)
        {
            _teacherService = teacherService;
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return Ok(teachers);
        }

        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<TeacherDetailDTO>>> GetAllTeachersWithDetails()
        {
            var teachers = await _teacherService.GetAllTeachersWithDetailsAsync();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDTO>> GetTeacherById(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null)
                return NotFound();

            return Ok(teacher);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherDTO>> CreateTeacher(CreateTeacherDTO teacherDto)
        {
            var teacher = await _teacherService.CreateTeacherAsync(teacherDto);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.TeacherID }, teacher);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherDTO>> UpdateTeacher(int id, UpdateTeacherDTO teacherDto)
        {
            var teacher = await _teacherService.UpdateTeacherAsync(id, teacherDto);
            if (teacher == null)
                return NotFound();

            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            var result = await _teacherService.DeleteTeacherAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("{id}/classes")]
        public async Task<ActionResult<IEnumerable<TeacherClassDTO>>> GetTeacherClasses(int id)
        {
            try
            {
                var classes = await _scheduleService.GetTeacherClassesAsync(id);
                return Ok(classes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
} 