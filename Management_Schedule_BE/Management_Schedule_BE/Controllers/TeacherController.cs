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

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
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
    }
} 